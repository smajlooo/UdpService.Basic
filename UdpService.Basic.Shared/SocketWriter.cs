using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace UdpService.Basic.Shared
{
    public class SocketWriter
    {
        Socket _serverSocket;

        public SocketWriter(Socket serverSocket)
        {
            _serverSocket = serverSocket;
        }

        public void SendTextTo(string text, EndPoint clientEp)
        {
            byte[] responsebuffer = Encoding.ASCII.GetBytes(text);
            _serverSocket.SendTo(responsebuffer, clientEp);
        }
    }
}
