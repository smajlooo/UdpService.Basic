using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using UdpService.Basic.Contracts;
using UdpService.Basic.Shared;

namespace UdpService.Basic.Service.Core
{
    public class MessageQueue
    {
        Socket _serverSocket;
        IServiceLogger _logger;
        EndPoint _clientEp;
        SocketWriter _sw;
        SocketReader _sr;
        string _req = "";
        string _res = "";

        public MessageQueue(Socket serverSocket, IServiceLogger logger)
        {
            _serverSocket = serverSocket;
            _logger = logger;
            _clientEp = (EndPoint)(new IPEndPoint(IPAddress.Any, 0));
            _sw = new SocketWriter(_serverSocket);
            _sr = new SocketReader(_serverSocket);
        }

        public void HandleIncomingMessages()
        {
            _logger.LogServiceInformation("Server waiting for incoming requests");

            do
            {
                _req = _sr.ReceiveTextFrom(ref _clientEp);

                _logger.LogRequestInformation("Received: " + _req + " | " + _clientEp);

                _res = new RequestHandler(_req).GetResponse();
                _sw.SendTextTo(_res, _clientEp);

                _logger.LogRequestInformation("Sent: " + _res);

            } while (true);
        }
    }
}
