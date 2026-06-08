using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UdpService.Basic.Contracts;

namespace UdpService.Basic.Service.Core
{
    public class Server
    {
        Socket _serverSocket;
        IPEndPoint _ep;
        IServiceLogger _logger;

        public Server(IPAddress adr, int port, IServiceLogger logger)
        {
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _ep = new IPEndPoint(adr, port);
            _logger = logger;
        }

        public void Start()
        {
            _serverSocket.Bind(_ep);

            Thread t = new Thread(new ThreadStart(() =>
            {
                MessageQueue m = new MessageQueue(_serverSocket, _logger);
                m.HandleIncomingMessages();
            }));
            t.Start();

            _logger.LogServiceInformation("Server started");
        }

        public void Stop()
        {
            _serverSocket.Shutdown(SocketShutdown.Both);
            _serverSocket.Close();

            _logger.LogServiceInformation("Server stopped");
        }
    }
}
