using System;
using System.Diagnostics;

namespace StartupHelper
{
    public class WirelessNetworkInfo
    {
        public WirlessNetworkConnectionStatus ConnectionStatus { get; set; }
        public string SsidName { get; set; }

        public WirelessNetworkInfo()
        {
            this.ConnectionStatus = WirlessNetworkConnectionStatus.Unknown;
        }

        public static WirelessNetworkInfo GetWirelessNetworkInfo()
        {
            string netshInfo = GetNetshInfo();
            return ParseWirelessInfo(netshInfo);
        }

        public static WirelessNetworkInfo ParseWirelessInfo(string netshInfo)
        {
            WirelessNetworkInfo info = new WirelessNetworkInfo();
            string connectionStatus = GetBetween(netshInfo, "State", Environment.NewLine);
            connectionStatus = connectionStatus.Replace(":", "");
            connectionStatus = connectionStatus.Trim();

            if (connectionStatus.ToLower() == "Connected".ToLower())
            {
                info.ConnectionStatus = WirlessNetworkConnectionStatus.Connected;
            }
            else if (connectionStatus.ToLower() == "Disconnected".ToLower())
            {
                info.ConnectionStatus = WirlessNetworkConnectionStatus.Disconnected;
            }

            if (info.ConnectionStatus == WirlessNetworkConnectionStatus.Connected)
            {
                info.SsidName = GetBetween(netshInfo, "SSID", Environment.NewLine);
                info.SsidName = info.SsidName.Replace(":", "");
                info.SsidName = info.SsidName.Trim();
            }

            return info;
        }

        public static string GetNetshInfo()
        {
            // What is Netsh?
            // Netsh is a command-line scripting utility that allows you to, either locally or remotely, display or modify the network configuration of a computer that is currently running.
            // http://www.microsoft.com/resources/documentation/windows/xp/all/proddocs/en-us/netsh.mspx?mfr=true 
            ProcessStartInfo info = new ProcessStartInfo("netsh", "wlan show interfaces");
            info.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.System);// +@"system32";
            info.WindowStyle = ProcessWindowStyle.Hidden;
            info.CreateNoWindow = true;
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;
            Process proc = new Process();
            proc.StartInfo = info;
            proc.Start();
            string wirelessInfo = proc.StandardOutput.ReadToEnd();

            // Close process
            proc.Close();

            return wirelessInfo;
        }

        private static string GetBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
    }

}
