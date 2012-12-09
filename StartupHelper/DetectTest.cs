using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StartupHelper
{
    public partial class DetectTest : Form
    {
        public DetectTest()
        {
            InitializeComponent();

            string netsh = WirelessNetworkInfo.GetNetshInfo();
            this.textBox1.Text += netsh;

            WirelessNetworkInfo info = WirelessNetworkInfo.GetWirelessNetworkInfo();
            this.textBox1.Text += Environment.NewLine;
            this.textBox1.Text += "Connection Status: " + info.ConnectionStatus.ToString();
            if (info.ConnectionStatus == WirlessNetworkConnectionStatus.Connected)
            {
                this.textBox1.Text += Environment.NewLine;
                this.textBox1.Text += "SSID: " + info.SsidName;
            }
        }
    }
}
