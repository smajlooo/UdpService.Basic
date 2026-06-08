using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UdpService.Basic.Contracts;

namespace UdpService.Basic.Service.Core
{
    public class ListBoxLogger : IServiceLogger
    {
        Action<string> _logServiceInformationDelegate;
        Action<string> _logRequestInformationDelegate;
        ListBox _lbxServiceInformation;
        ListBox _lbxRequestInformation;

        public ListBoxLogger(ListBox lbxServiceInformation, ListBox lbxRequestInformation)
        {
            _lbxServiceInformation = lbxServiceInformation;
            _lbxRequestInformation = lbxRequestInformation;
            _logServiceInformationDelegate = new Action<string>(LogServiceInformation);
            _logRequestInformationDelegate = new Action<string>(LogRequestInformation);
        }

        public void LogServiceInformation(string text)
        {
            if (_lbxServiceInformation.InvokeRequired)
            {
                _lbxServiceInformation.Invoke(_logServiceInformationDelegate, text);
            }
            else
            {
                _lbxServiceInformation.Items.Add(text);
            }
        }

        public void LogRequestInformation(string text)
        {
            if (_lbxRequestInformation.InvokeRequired)
            {
                _lbxRequestInformation.Invoke(_logRequestInformationDelegate, text);
            }
            else
            {
                _lbxRequestInformation.Items.Add(text);
            }
        }

    }
}
