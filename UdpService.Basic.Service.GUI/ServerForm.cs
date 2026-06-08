using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using UdpService.Basic.Service.Core;
using UdpService.Basic.Contracts;

namespace UdpService.Basic.Service.GUI
{
    public partial class ServerForm : Form
    {
        Server _server;
        IServiceLogger _logger;

        public ServerForm()
        {
            InitializeComponent();
            _logger = new ListBoxLogger(lbxService, lbxRequest);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            IPAddress adr = IPAddress.Parse(tbxIp.Text);
            int port = Convert.ToInt32(tbxPort.Text);

            _server = new Server(adr, port, _logger);
            _server.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _server.Stop();
        }
    }
}
