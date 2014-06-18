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
                Console.WriteLine("-> " + RequestLine + " from HTTP referer " +
                    RequestHeaders.Referer);
            }

            protected override void OnReceiveResponse()
            {
                Console.WriteLine("<- " + ResponseStatusLine +
                    " with HTTP Content-Length: " +
                    (ResponseHeaders.ContentLength ?? 0));
            }
        }

        static void Main(string[] args)
        {
            int port = 12345;
            bool bUseIPv6 = false;

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
