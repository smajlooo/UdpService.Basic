using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using UdpService.Basic.Shared;

namespace UdpService.Basic.Client.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            EndPoint servEp = new IPEndPoint(IPAddress.Loopback, 1147);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            string req = "";
            string res = "";

            SocketWriter sw = new SocketWriter(socket);
            SocketReader sr = new SocketReader(socket);

            do
            {

                Console.Write(":>>");
                req = Console.ReadLine();

                if(req == "exit")
                {
                    break;
                }

                sw.SendTextTo(req, servEp);

                res = sr.ReceiveTextFrom(ref servEp);
                Console.WriteLine($"{res} (server ${servEp})");

                Console.WriteLine();

            } while (req != "exit");
        }
    }
}
