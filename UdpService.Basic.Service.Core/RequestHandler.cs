using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdpService.Basic.Service.Core
{
    public class RequestHandler
    {
        string _req = "";

        public RequestHandler(string req)
        {
            _req = req;
        }

        public string GetResponse()
        {
            return _req + " received";
        }
    }
}
