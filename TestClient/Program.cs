using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrotiNet;

namespace TestClient
{
    class Program
    {
        public class TestAuthentication : IProxyAuthenticator
        {
            public bool Authenticate(string username, string password)
            {
                if (username == "test" && password == "password")
                    return true;
                return false;
            }
        }

        public class TransparentProxy : ProxyLogic
        {
            public TransparentProxy(HttpSocket clientSocket)
                : base(clientSocket)
            {
                this.Authenticator = new TestAuthentication();
            }

            static new public TransparentProxy CreateProxy(HttpSocket clientSocket)
            {
                return new TransparentProxy(clientSocket);
            }

            protected override void OnReceiveRequest()
            {
                //Console.WriteLine(State.Username + "-> " + RequestLine + " from HTTP referer " +
                  //  RequestHeaders.Referer);
                
                // This is where I'd do filtering if needed

                var requestDetails = RequestDetails;
                Console.WriteLine("{0} | User: {1} | Host: {2} | Method: {3} | User-Agent: {4}",
                    requestDetails.Time.ToShortTimeString(),
                    requestDetails.Username,
                    requestDetails.Hostname,
                    requestDetails.Method,
                    requestDetails.UserAgent);

            }

            protected override void OnReceiveResponse()
            {
                //Console.WriteLine(State.Username + "<- " + ResponseStatusLine +
                  //  " with HTTP Content-Length: " +
                    //(ResponseHeaders.ContentLength ?? 0));

            }
        }

        static void Main(string[] args)
        {
            int port = 12345;
            bool bUseIPv6 = false;

            Console.WindowWidth = 200;
            

            var Server = new TcpServer(port, bUseIPv6);
            Server.Start(TransparentProxy.CreateProxy);

            Server.InitListenFinished.WaitOne();
            if (Server.InitListenException != null)
                throw Server.InitListenException;

            while (true)
                System.Threading.Thread.Sleep(1000);

        }
    }
}
