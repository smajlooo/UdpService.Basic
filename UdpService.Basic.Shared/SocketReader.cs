using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace UdpService.Basic.Shared
{
    public class SocketReader
    {
        Socket _serverSocket;

        public SocketReader(Socket serverSocket)
        {
            _serverSocket = serverSocket;
        }

        public string ReceiveTextFrom(ref EndPoint clientEp)
        {
            EndPoint c = (EndPoint)(new IPEndPoint(IPAddress.Any, 0));
            byte[] buffer = new byte[1024];
            
            _serverSocket.ReceiveFrom(buffer, ref clientEp);
            string req = Encoding.ASCII.GetString(buffer);
            return req.Substring(0, req.IndexOf('\0'));
        }
    }
}
