/*
 * This file is part of the tutorial on how to use the TrotiNet library.
 *
 * In this example, we are going to rewrite HTML content arbitrarily.
 * OnReceiveResponse() decides whether the content should be rewritten.
 * If it should be, OnReceiveResponse calls RewriteHTML() to get the modified
 * output, then updates the headers and sends the response to the client.
 */

using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;

namespace TrotiNet.Example
{
    public class RewritingProxy : ProxyLogic
    {
        /// <summary>
        /// A simple regular expression for charset detection
        /// </summary>
        static Regex charset_regex = new Regex("charset=([\\w-]*)", RegexOptions.Compiled);

        public RewritingProxy(HttpSocket clientSocket)
            : base(clientSocket) 
        {
        }

        static new public RewritingProxy CreateProxy(HttpSocket clientSocket)
        {
            RewritingProxy result = new RewritingProxy(clientSocket);

            return result;
        }

        /// <summary>
        /// Guess the file encoding, judging from the response content type
        /// </summary>
        /// <param name="content">The input content</param>
        /// <returns>The input encoding, or null if it could not be
        /// determined</returns>
        Encoding GetFileEncoding(byte[] content)
        {
            string charset = null;

            // Check if the charset is specified in the response headers
            if (ResponseHeaders.Headers.ContainsKey("content-type"))
            {
                string contentType = ResponseHeaders.Headers["content-type"];
                Match m = charset_regex.Match(contentType);
                if (m.Success)
                    charset = m.Groups[1].Value;
            }

            if (charset == null)
            {
                // If the charset is not specified in the response headers,
                // ideally we should look for the charset in the set of
                // META tags of the page. We'll just bail out for now.
                return null;
            }

            try
            {
                return Encoding.GetEncoding(charset);
            }
            catch { }

            return null;
        }

        /// <summary>
        /// This is the core of the rewriting process.
        ///
        /// At this point, you have the entire HTML body.
        /// Change the content to your heart's content!
        /// </summary>
        /// <param name="input">The HTML body from the remote server</param>
        /// <returns>The HTML body to return to the client</returns>
        string ModifyHTML(string input)
        {

            return input;
        }

        protected override void OnReceiveResponse()
        {
            // Use the content-type field of the response headers to
            // Determine which HTTP content we want to modify.
            bool bModifyContent = false;
            if (ResponseHeaders.Headers.ContainsKey("content-type"))
                bModifyContent = ResponseHeaders.Headers["content-type"].
                    Contains("text/html");

            // Rewriting may also depend on the user agent.
#if false
            if (RequestHeaders.Headers.ContainsKey("user-agent"))
                if (RequestHeaders.Headers["user-agent"].ToLower().Contains("msie"))
                {
                    // ...
                }
#endif

            // Do not rewrite anything unless we got a 200 status code.
            if (ResponseStatusLine.StatusCode != 200)
                bModifyContent = false;

            if (!bModifyContent)
                // Propagate the content without modifying it.
                return;

            // Let's assume we need to retrieve the entire file before
            // we can do the rewriting. This is usually the case if the
            // content has been compressed by the remote server, or if we
            // want to build a DOM tree.
            byte[] response = GetContent();

            // From now on, the default State.NextStep ( == SendResponse()
            // at this point) must not be called, since we already read
            // the response.
            State.NextStep = null;

            // Decompress the message stream, if necessary
            Stream stream = GetResponseMessageStream(response);
            byte[] content = ReadEverything(stream);
            Encoding fileEncoding = GetFileEncoding(content);

            if (fileEncoding == null)
            {
                // We could not guess the file encoding, so it's better not
                // to modify anything.
                SendResponseStatusAndHeaders();
                SocketBP.TunnelDataTo(TunnelBP, response);
                return;
            }

            string text;
            using (stream = new MemoryStream(content))
            using (var sr = new StreamReader(stream, fileEncoding))
                text = sr.ReadToEnd();

            // We are now in a position to rewrite stuff.
            text = ModifyHTML(text);

            // Tell the browser not to cache our modified version.
            ResponseHeaders.CacheControl = "no-cache, no-store, must-revalidate";
            ResponseHeaders.Expires = "Fri, 01 Jan 1990 00:00:00 GMT";
            ResponseHeaders.Pragma = "no-cache";

            // Even if the response was originally transferred
            // by chunks, we are going to send it unchunked.
            // (We could send it chunked, though, by calling
            // TunnelChunkedDataTo, instead of TunnelDataTo.)
            ResponseHeaders.TransferEncoding = null;

            // Encode the modified content, and recompress it, as necessary.
            byte[] output = EncodeStringResponse(text, fileEncoding);
            ResponseHeaders.ContentLength = (uint)output.Length;

            // Finally, send the result.
            SendResponseStatusAndHeaders();
            SocketBP.TunnelDataTo(TunnelBP, output);

            // We are done with the request.
            // Note that State.NextStep has been set to null earlier.
        }

        protected override X509Certificate OnCertificateNeeded(string hostname)
        {
            // for https support you need to return a certificate here
            // you could create it with makecert.exe for example
            return null;
        }

        static byte[] ReadEverything(Stream input)
        {
            byte[] buffer = new byte[16 * 1024]; // ugly, but don't care
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    ms.Write(buffer, 0, read);
                return ms.ToArray();
            }
        }
    }
}
