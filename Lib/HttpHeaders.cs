using System;
using System.Collections.Generic;
using System.Text;

namespace TrotiNet
{
    /// <summary>
    /// Container for a parsed copy of some headers relevant to the proxy,
    /// along with an unparsed copy of all the headers with their order
    /// unchanged
    /// </summary>
    public class HttpHeaders
    {
        /// <summary>
        /// Standard HTTP header names.
        /// </summary>
        public static class Names
        {
            /// <summary>
            /// Accept
            /// </summary>
            public static String ACCEPT = "Accept";
            /// <summary>
            /// Accept-Charset
            /// </summary>
            public static String ACCEPT_CHARSET = "Accept-Charset";
            /// <summary>
            /// Accept-Encoding
            /// </summary>
            public static String ACCEPT_ENCODING = "Accept-Encoding";
            /// <summary>
            /// Accept-Language
            /// </summary>
            public static String ACCEPT_LANGUAGE = "Accept-Language";
            /// <summary>
            /// Accept-Ranges
            /// </summary>
            public static String ACCEPT_RANGES = "Accept-Ranges";
            /// <summary>
            /// Accept-Patch
            /// </summary>
            public static String ACCEPT_PATCH = "Accept-Patch";
            /// <summary>
            /// Access-Control-Allow-Credentials
            /// </summary>
            public static String ACCESS_CONTROL_ALLOW_CREDENTIALS = "Access-Control-Allow-Credentials";
            /// <summary>
            /// Access-Control-Allow-Headers
            /// </summary>
            public static String ACCESS_CONTROL_ALLOW_HEADERS = "Access-Control-Allow-Headers";
            /// <summary>
            /// Access-Control-Allow-Methods
            /// </summary>
            public static String ACCESS_CONTROL_ALLOW_METHODS = "Access-Control-Allow-Methods";
            /// <summary>
            /// Access-Control-Allow-Origin
            /// </summary>
            public static String ACCESS_CONTROL_ALLOW_ORIGIN = "Access-Control-Allow-Origin";
            /// <summary>
            /// Access-Control-Expose-Headers
            /// </summary>
            public static String ACCESS_CONTROL_EXPOSE_HEADERS = "Access-Control-Expose-Headers";
            /// <summary>
            /// Access-Control-Max-Age
            /// </summary>
            public static String ACCESS_CONTROL_MAX_AGE = "Access-Control-Max-Age";
            /// <summary>
            /// Access-Control-Request-Headers
            /// </summary>
            public static String ACCESS_CONTROL_REQUEST_HEADERS = "Access-Control-Request-Headers";
            /// <summary>
            /// Access-Control-Request-Method
            /// </summary>
            public static String ACCESS_CONTROL_REQUEST_METHOD = "Access-Control-Request-Method";
            /// <summary>
            /// Age
            /// </summary>
            public static String AGE = "Age";
            /// <summary>
            /// Allow
            /// </summary>
            public static String ALLOW = "Allow";
            /// <summary>
            /// Authorization
            /// </summary>
            public static String AUTHORIZATION = "Authorization";
            /// <summary>
            /// Cache-Control
            /// </summary>
            public static String CACHE_CONTROL = "Cache-Control";
            /// <summary>
            /// Connection
            /// </summary>
            public static String CONNECTION = "Connection";
            /// <summary>
            /// Content-Base
            /// </summary>
            public static String CONTENT_BASE = "Content-Base";
            /// <summary>
            /// Content-Encoding
            /// </summary>
            public static String CONTENT_ENCODING = "Content-Encoding";
            /// <summary>
            /// Content-Language
            /// </summary>
            public static String CONTENT_LANGUAGE = "Content-Language";
            /// <summary>
            /// Content-Length
            /// </summary>
            public static String CONTENT_LENGTH = "Content-Length";
            /// <summary>
            /// Content-Location
            /// </summary>
            public static String CONTENT_LOCATION = "Content-Location";
            /// <summary>
            /// Content-Transfer-Encoding
            /// </summary>
            public static String CONTENT_TRANSFER_ENCODING = "Content-Transfer-Encoding";
            /// <summary>
            /// Content-MD5
            /// </summary>
            public static String CONTENT_MD5 = "Content-MD5";
            /// <summary>
            /// Content-Range
            /// </summary>
            public static String CONTENT_RANGE = "Content-Range";
            /// <summary>
            /// Content-Type
            /// </summary>
            public static String CONTENT_TYPE = "Content-Type";
            /// <summary>
            /// Cookie
            /// </summary>
            public static String COOKIE = "Cookie";
            /// <summary>
            /// Date
            /// </summary>
            public static String DATE = "Date";
            /// <summary>
            /// ETag
            /// </summary>
            public static String ETAG = "ETag";
            /// <summary>
            /// Expect
            /// </summary>
            public static String EXPECT = "Expect";
            /// <summary>
            /// Expires
            /// </summary>
            public static String EXPIRES = "Expires";
            /// <summary>
            /// From
            /// </summary>
            public static String FROM = "From";
            /// <summary>
            /// Host
            /// </summary>
            public static String HOST = "Host";
            /// <summary>
            /// If-Match
            /// </summary>
            public static String IF_MATCH = "If-Match";
            /// <summary>
            /// If-Modified-Since
            /// </summary>
            public static String IF_MODIFIED_SINCE = "If-Modified-Since";
            /// <summary>
            /// If-None-Match
            /// </summary>
            public static String IF_NONE_MATCH = "If-None-Match";
            /// <summary>
            /// If-Range
            /// </summary>
            public static String IF_RANGE = "If-Range";
            /// <summary>
            /// If-Unmodified-Since
            /// </summary>
            public static String IF_UNMODIFIED_SINCE = "If-Unmodified-Since";
            /// <summary>
            /// Last-Modified
            /// </summary>
            public static String LAST_MODIFIED = "Last-Modified";
            /// <summary>
            /// Location
            /// </summary>
            public static String LOCATION = "Location";
            /// <summary>
            /// Max-Forwards
            /// </summary>
            public static String MAX_FORWARDS = "Max-Forwards";
            /// <summary>
            /// Origin
            /// </summary>
            public static String ORIGIN = "Origin";
            /// <summary>
            /// Pragma
            /// </summary>
            public static String PRAGMA = "Pragma";
            /// <summary>
            /// Proxy-Authenticate
            /// </summary>
            public static String PROXY_AUTHENTICATE = "Proxy-Authenticate";
            /// <summary>
            /// Proxy-Authorization
            /// </summary>
            public static String PROXY_AUTHORIZATION = "Proxy-Authorization";
            /// <summary>
            /// Range
            /// </summary>
            public static String RANGE = "Range";
            /// <summary>
            /// Referer
            /// </summary>
            public static String REFERER = "Referer";
            /// <summary>
            /// Retry-After
            /// </summary>
            public static String RETRY_AFTER = "Retry-After";
            /// <summary>
            /// Sec-WebSocket-Key1
            /// </summary>
            public static String SEC_WEBSOCKET_KEY1 = "Sec-WebSocket-Key1";
            /// <summary>
            /// Sec-WebSocket-Key2
            /// </summary>
            public static String SEC_WEBSOCKET_KEY2 = "Sec-WebSocket-Key2";
            /// <summary>
            /// Sec-WebSocket-Location
            /// </summary>
            public static String SEC_WEBSOCKET_LOCATION = "Sec-WebSocket-Location";
            /// <summary>
            /// Sec-WebSocket-Origin
            /// </summary>
            public static String SEC_WEBSOCKET_ORIGIN = "Sec-WebSocket-Origin";
            /// <summary>
            /// Sec-WebSocket-Protocol
            /// </summary>
            public static String SEC_WEBSOCKET_PROTOCOL = "Sec-WebSocket-Protocol";
            /// <summary>
            /// Sec-WebSocket-Version
            /// </summary>
            public static String SEC_WEBSOCKET_VERSION = "Sec-WebSocket-Version";
            /// <summary>
            /// Sec-WebSocket-Key
            /// </summary>
            public static String SEC_WEBSOCKET_KEY = "Sec-WebSocket-Key";
            /// <summary>
            /// Sec-WebSocket-Accept
            /// </summary>
            public static String SEC_WEBSOCKET_ACCEPT = "Sec-WebSocket-Accept";
            /// <summary>
            /// Server
            /// </summary>
            public static String SERVER = "Server";
            /// <summary>
            /// Set-Cookie
            /// </summary>
            public static String SET_COOKIE = "Set-Cookie";
            /// <summary>
            /// Set-Cookie2
            /// </summary>
            public static String SET_COOKIE2 = "Set-Cookie2";
            /// <summary>
            /// TE
            /// </summary>
            public static String TE = "TE";
            /// <summary>
            /// Trailer
            /// </summary>
            public static String TRAILER = "Trailer";
            /// <summary>
            /// Transfer-Encoding
            /// </summary>
            public static String TRANSFER_ENCODING = "Transfer-Encoding";
            /// <summary>
            /// Upgrade
            /// </summary>
            public static String UPGRADE = "Upgrade";
            /// <summary>
            /// User-Agent
            /// </summary>
            public static String USER_AGENT = "User-Agent";
            /// <summary>
            /// Vary
            /// </summary>
            public static String VARY = "Vary";
            /// <summary>
            /// Via
            /// </summary>
            public static String VIA = "Via";
            /// <summary>
            /// Warning
            /// </summary>
            public static String WARNING = "Warning";
            /// <summary>
            /// WebSocket-Location
            /// </summary>
            public static String WEBSOCKET_LOCATION = "WebSocket-Location";
            /// <summary>
            /// WebSocket-Origin
            /// </summary>
            public static String WEBSOCKET_ORIGIN = "WebSocket-Origin";
            /// <summary>
            /// WebSocket-Protocol
            /// </summary>
            public static String WEBSOCKET_PROTOCOL = "WebSocket-Protocol";
            /// <summary>
            /// WWW-Authenticate
            /// </summary>
            public static String WWW_AUTHENTICATE = "WWW-Authenticate";
        }

        /// <summary>
        /// Standard HTTP header values.
        /// </summary>
        public static class Values
        {
            /// <summary>
            /// application/x-www-form-urlencoded
            /// </summary>
            public static String APPLICATION_X_WWW_FORM_URLENCODED =
                   "application/x-www-form-urlencoded";
            /// <summary>
            /// base64
            /// </summary>
            public static String BASE64 = "base64";
            /// <summary>
            /// binary
            /// </summary>
            public static String BINARY = "binary";
            /// <summary>
            /// boundary
            /// </summary>
            public static String BOUNDARY = "boundary";
            /// <summary>
            /// bytes
            /// </summary>
            public static String BYTES = "bytes";
            /// <summary>
            /// charset
            /// </summary>
            public static String CHARSET = "charset";
            /// <summary>
            /// chunked
            /// </summary>
            public static String CHUNKED = "chunked";
            /// <summary>
            /// close
            /// </summary>
            public static String CLOSE = "close";
            /// <summary>
            /// compress
            /// </summary>
            public static String COMPRESS = "compress";
            /// <summary>
            /// 100-continue
            /// </summary>
            public static String CONTINUE = "100-continue";
            /// <summary>
            /// deflate
            /// </summary>
            public static String DEFLATE = "deflate";
            /// <summary>
            /// gzip
            /// </summary>
            public static String GZIP = "gzip";
            /// <summary>
            /// identity
            /// </summary>
            public static String IDENTITY = "identity";
            /// <summary>
            /// keep-alive
            /// </summary>
            public static String KEEP_ALIVE = "keep-alive";
            /// <summary>
            /// max-age
            /// </summary>
            public static String MAX_AGE = "max-age";
            /// <summary>
            /// max-stale
            /// </summary>
            public static String MAX_STALE = "max-stale";
            /// <summary>
            /// min-fresh
            /// </summary>
            public static String MIN_FRESH = "min-fresh";
            /// <summary>
            /// multipart/form-data
            /// </summary>
            public static String MULTIPART_FORM_DATA = "multipart/form-data";
            /// <summary>
            /// must-revalidate
            /// </summary>
            public static String MUST_REVALIDATE = "must-revalidate";
            /// <summary>
            /// no-cache
            /// </summary>
            public static String NO_CACHE = "no-cache";
            /// <summary>
            /// no-store
            /// </summary>
            public static String NO_STORE = "no-store";
            /// <summary>
            /// no-transform
            /// </summary>
            public static String NO_TRANSFORM = "no-transform";
            /// <summary>
            /// none
            /// </summary>
            public static String NONE = "none";
            /// <summary>
            /// only-if-cached
            /// </summary>
            public static String ONLY_IF_CACHED = "only-if-cached";
            /// <summary>
            /// private
            /// </summary>
            public static String PRIVATE = "private";
            /// <summary>
            /// proxy-revalidate
            /// </summary>
            public static String PROXY_REVALIDATE = "proxy-revalidate";
            /// <summary>
            /// public
            /// </summary>
            public static String PUBLIC = "public";
            /// <summary>
            /// quoted-printable
            /// </summary>
            public static String QUOTED_PRINTABLE = "quoted-printable";
            /// <summary>
            /// s-maxage
            /// </summary>
            public static String S_MAXAGE = "s-maxage";
            /// <summary>
            /// trailers
            /// </summary>
            public static String TRAILERS = "trailers";
            /// <summary>
            /// Upgrade
            /// </summary>
            public static String UPGRADE = "Upgrade";
            /// <summary>
            /// WebSocket
            /// </summary>
            public static String WEBSOCKET = "WebSocket";

        }

        enum HeaderType
        {
            Uint,
            String,
            Strings
        }

        /// <summary>
        /// Cache-Control header value
        /// </summary>
        public string CacheControl
        {
            get { return GetItem<string>("Cache-Control"); }
            set { SetItem("Cache-Control", value, HeaderType.String); }
        }

        /// <summary>
        /// Connection header value
        /// </summary>
        public string[] Connection
        {
            get { return GetItem<string[]>("connection"); }
            set { SetItem("Connection", value, HeaderType.Strings); }
        }

        /// <summary>
        /// Content-Encoding header value
        /// </summary>
        public string ContentEncoding
        {
            get { return GetItem<string>("content-encoding"); }
            set { SetItem("Content-Encoding", value, HeaderType.String); }
        }

        /// <summary>
        /// Content-Length header value
        /// </summary>
        public uint? ContentLength
        {
            get { return GetItem<uint?>("content-length"); }
            set { SetItem("Content-Length", value, HeaderType.Uint); }
        }

        /// <summary>
        /// Expires header value
        /// </summary>
        public string Expires
        {
            get { return GetItem<string>("Expires"); }
            set { SetItem("Expires", value, HeaderType.String); }
        }

        /// <summary>
        /// Pragma header value
        /// </summary>
        public string Pragma
        {
            get { return GetItem<string>("Pragma"); }
            set { SetItem("Pragma", value, HeaderType.String); }
        }

        /// <summary>
        /// Map { header name } -> { header string value }
        /// </summary>
        /// <remarks>
        /// Keys are stored in lower-case characters.
        /// Values have their spaces and trailing newlines trimmed.
        /// </remarks>
        public Dictionary<string, string> Headers { get; protected set; }

        /// <summary>
        /// HTTP headers as received (newline markers may have been fixed)
        /// </summary>
        /// <remarks>
        /// If RemoveHeader has been called, then HeadersInOrder will be
        /// modified. In particular, the header ordering may change.
        /// </remarks>
        public string HeadersInOrder { get; protected set; }

        /// <summary>
        /// Host header value
        /// </summary>
        public string Host
        {
            get { return GetItem<string>("host"); }
            set { SetItem("Host", value, HeaderType.String); }
        }

        /// <summary>
        /// Map { header name } -> { header parsed value }
        /// </summary>
        /// <remarks>
        /// Keys are stored in lower-case characters.
        /// </remarks>
        Dictionary<string, object> ParsedHeaders;

        /// <summary>
        /// Proxy-Connection header value
        /// </summary>
        /// <remarks>
        /// Proxy-Connection is not officially part of HTTP/1.1
        /// </remarks>
        public string[] ProxyConnection
        {
            get { return GetItem<string[]>("proxy-connection"); }
            set { SetItem("Proxy-Connection", value, HeaderType.Strings); }
        }

        /// <summary>
        /// Referer (sic) header value
        /// </summary>
        public string Referer
        {
            get { return GetItem<string>("referer"); }
            set { SetItem("Referer", value, HeaderType.String); }
        }

        /// <summary>
        /// Transfer-Encoding header value
        /// </summary>
        public string[] TransferEncoding
        {
            get { return GetItem<string[]>("transfer-encoding"); }
            set { SetItem("Transfer-Encoding", value, HeaderType.Strings); }
        }

        /// <summary>
        /// Instantiate empty HTTP headers
        /// </summary>
        public HttpHeaders()
        {
            Headers = new Dictionary<string, string>();
            ParsedHeaders = new Dictionary<string, object>();
        }

        /// <summary>
        /// Read and parse HTTP headers from a connected socket
        /// </summary>
        public HttpHeaders(HttpSocket source): this()
        {
            StringBuilder sb = new StringBuilder(512);

            while (true)
            {
                var line = source.ReadAsciiLine();
                if (line.Length == 0)
                    break;
                sb.Append(line);
                sb.Append("\r\n"); // Note: if the header newline was
                    // incorrectly formatted (i.e. LF instead of CRLF),
                    // we correct it here. This is one point where our
                    // proxy is not fully transparent.

                var iSplit = line.IndexOf(':');
                if (iSplit <= 0)
                    throw new HttpProtocolBroken("No colon in HTTP header");

                // Header names are case-insensitive, but only some header 
                // values are.
                string HeaderName = line.Substring(0, iSplit).Trim().ToLower();
                string HeaderValue = line.Substring(iSplit + 1).Trim();
                if (IsHeaderValueCaseInsensitive(HeaderName))
                    HeaderValue = HeaderValue.ToLower();

                string previous_value = null;
                if (Headers.TryGetValue(HeaderName, out previous_value))
                {
                    // Duplicate headers: concatenate them
                    // (RFC 2616, section 4.2)

                    // However, this should only occur if the value of that
                    // header is a comma-separated list. In the real world,
                    // it has been observed that headers with
                    // non-comma-separated values, such as Content-Length, *are*
                    // in some rare cases repeated, so we should not concatenate
                    // the values.
                    if (!HeaderName.Equals("content-length"))
                        Headers[HeaderName] = previous_value + "," + HeaderValue;
                }
                else
                    Headers[HeaderName] = HeaderValue;
            }

            HeadersInOrder = sb.ToString();

            // Parse a subset of the header values.
            // If headers are added, don't forget to update RemoveHeader
            // as well.
            Connection = ParseMultipleStringValues("connection");
            ContentEncoding = ParseStringValue("content-encoding");
            ContentLength = ParseIntValue("content-length");
            Host = ParseStringValue("host");
            ProxyConnection = ParseMultipleStringValues("proxy-connection");
            Referer = ParseStringValue("referer");
            TransferEncoding = ParseMultipleStringValues("transfer-encoding");
        }

        /// <summary>
        /// Initialize a new instance with the provided set of
        /// HTTP headers
        /// </summary>
        public HttpHeaders(Dictionary<string, string> headers)
        {
            throw new NotImplementedException();
        }

        T GetItem<T>(string header_name)
        {
            System.Diagnostics.Debug.Assert(header_name.Equals(
                header_name.ToLower()));
            object o = null;
            ParsedHeaders.TryGetValue(header_name, out o);
            return (T)o;
        }

        /// <summary>
        /// Parse a HTTP header that is expected to contain a decimal value
        /// </summary>
        /// <param name="HeaderName">
        /// The header name, in lower-case
        /// </param>
        protected uint? ParseIntValue(string HeaderName)
        {
            System.Diagnostics.Debug.Assert(HeaderName.Equals(
                HeaderName.ToLower()));

            try
            {
                string value = null;
                if (!Headers.TryGetValue(HeaderName, out value))
                    return null;
                return UInt32.Parse(value);
            }
            catch { return null; }
        }

        /// <summary>
        /// Split a HTTP header value along the commas, and trim the spaces
        /// </summary>
        /// <param name="HeaderName">
        /// The header name, in lower-case
        /// </param>
        protected string[] ParseMultipleStringValues(string HeaderName)
        {
            System.Diagnostics.Debug.Assert(HeaderName.Equals(
                HeaderName.ToLower()));

            try
            {
                string value = null;
                if (!Headers.TryGetValue(HeaderName, out value))
                    return null;

                string[] values = value.Split(',');
                for (int i = 0; i < values.Length; i++)
                    values[i] = values[i].Trim();
                return values;
            }
            catch { return null; }
        }

        /// <summary>
        /// Retrieve a header value and trim the spaces
        /// </summary>
        /// <param name="HeaderName">
        /// The header name, in lower-case
        /// </param>
        protected string ParseStringValue(string HeaderName)
        {
            System.Diagnostics.Debug.Assert(HeaderName.Equals(
                HeaderName.ToLower()));

            try
            {
                string value = null;
                if (!Headers.TryGetValue(HeaderName, out value))
                    return null;
                return value.Trim();
            }
            catch { return null; }
        }

        bool IsHeaderValueCaseInsensitive(string HeaderName)
        {
            // Note: some other headers may be case-insensitive, but
            // the ones listed here really have to be lowerized,
            // because TrotiNet assumes so.

            System.Diagnostics.Debug.Assert(HeaderName.Equals(
                HeaderName.ToLower()));

            return
                HeaderName.Equals("connection") ||
                HeaderName.Equals("content-encoding") ||
                HeaderName.Equals("proxy-connection") ||
                HeaderName.Equals("transfer-encoding");
        }

        internal void SendTo(HttpSocket hs)
        {
            hs.WriteAsciiLine(HeadersInOrder);
            // Note: HeadersInOrder contains one trailing newline, so
            // WriteAsciiLine() will send two newlines (which is what we
            // want).
        }

        void SetItem(string HeaderName, object value, HeaderType ht)
        {
            string header_name = HeaderName.ToLower();

            // Does the key exist already?
            bool bHasKey;
            {
                string dummy;
                bHasKey = Headers.TryGetValue(header_name, out dummy);
            }

            // Update Headers
            string s = null;
            if (value == null)
            {
                if (!bHasKey)
                    // Nothing to remove
                    return;
                Headers.Remove(header_name);
            }
            else
            {
                switch(ht)
                {
                    case HeaderType.Uint:
                        s = value.ToString(); break;
                    case HeaderType.String:
                        s = (string)value; break;
                    case HeaderType.Strings:
                        s = String.Join(";", (string[])value); break;
                    default:
                        System.Diagnostics.Debug.Assert(false);
                        break;
                }
                Headers[header_name] = s;
            }

            // Update ParsedHeaders
            ParsedHeaders[header_name] = value;

            // Update HeadersInOrder
            if (bHasKey)
            {
                string[] items = HeadersInOrder.Split(CRLF_a,
                    StringSplitOptions.RemoveEmptyEntries);
                StringBuilder sb = new StringBuilder(512);
                foreach (string item in items)
                {
                    var iSplit = item.IndexOf(':');
                    System.Diagnostics.Debug.Assert(iSplit > 0);
                    var hn = item.Substring(0, iSplit).Trim().ToLower();
                    if (hn.Equals(header_name))
                    {
                        if (s == null)
                            // Skip (= remove) the header
                            continue;

                        sb.Append(HeaderName);
                        sb.Append(": ");
                        sb.Append(s);
                    }
                    else
                        sb.Append(item);
                    sb.Append("\r\n");
                }
                HeadersInOrder = sb.ToString();
            }
            else
                HeadersInOrder += HeaderName + ": " + s + "\r\n";
        }

        static readonly string[] CRLF_a = { "\r\n" };
    }
}
