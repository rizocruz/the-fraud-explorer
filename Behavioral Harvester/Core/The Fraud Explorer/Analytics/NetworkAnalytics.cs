/*
 * The Fraud Explorer
 * http://www.thefraudexplorer.com/
 *
 * Copyright (c) 2016 The Fraud Explorer
 * email: support@thefraudexplorer.com
 * Licensed under GNU GPL v3
 * http://www.thefraudexplorer.com/License
 *
 * Date: 2016-05-30 15:12:41 -0500 (Wed, 30 May 2016)
 * Revision: v0.9.5
 *
 * Description: Network Analytics
 */

using SharpPcap;
using SharpPcap.AirPcap;
using SharpPcap.LibPcap;
using SharpPcap.WinPcap;
using System.Linq;
using System.Net.NetworkInformation;
using TFE_core.Config;
using TFE_core.Networking;
using TFE_core.Crypto;
using PacketDotNet;

namespace TFE_core.Analytics
{
    class NetworkAnalytics { }

    public class NetworkEvents
    {
        /// <summary>
        /// Procedure for network listening
        /// </summary>

        #region Network listening

        private static readonly log4net.ILog logNetwork = log4net.LogManager.GetLogger("networkAnalytics_Repo", typeof(NetworkAnalyticsLogger));

        public static void NetworkAnalytics()
        {
            var devices = CaptureDeviceList.Instance;

            int i = 0;
            var device = devices[i];

            foreach (var dev in devices)
            {
                try
                {
                    dev.OnPacketArrival += new PacketArrivalEventHandler(device_OnPacketArrival);
                    int readTimeoutMilliseconds = 1000;

                    if (dev is AirPcapDevice)
                    {
                        var airPcap = dev as AirPcapDevice;
                        airPcap.Open(SharpPcap.WinPcap.OpenFlags.DataTransferUdp, readTimeoutMilliseconds);
                    }
                    else if (dev is WinPcapDevice)
                    {
                        var winPcap = dev as WinPcapDevice;
                        winPcap.Open(SharpPcap.WinPcap.OpenFlags.DataTransferUdp | SharpPcap.WinPcap.OpenFlags.NoCaptureLocal, readTimeoutMilliseconds);
                    }
                    else if (dev is LibPcapLiveDevice)
                    {
                        var livePcapDevice = dev as LibPcapLiveDevice;
                        livePcapDevice.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);
                    }

                    dev.StartCapture();
                    i++;
                }
                catch { };
            }
        }

        #endregion

        /// <summary>
        /// Time and length of each received packet
        /// </summary>

        #region OnPacket Arrival 

        private static void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            var time = e.Packet.Timeval.Date;
            var len = e.Packet.Data.Length;

            var packet = PacketDotNet.Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);

            var tcpPacket = (TcpPacket)packet.Extract(typeof(TcpPacket));

            if (tcpPacket != null)
            {
                var ipPacket = (PacketDotNet.IpPacket)tcpPacket.ParentPacket;
                System.Net.IPAddress srcIp = ipPacket.SourceAddress;
                System.Net.IPAddress dstIp = ipPacket.DestinationAddress;
                int srcPort = tcpPacket.SourcePort;
                int dstPort = tcpPacket.DestinationPort;

                log4net.GlobalContext.Properties["PacketLenght"] = Cryptography.EncRijndael(len.ToString());
                log4net.GlobalContext.Properties["IPAddress"] = Network.GetAllLocalIPv4(NetworkInterfaceType.Ethernet).FirstOrDefault();
                log4net.GlobalContext.Properties["AgentID"] = Settings.AgentID;
                log4net.GlobalContext.Properties["SourceIP"] = Cryptography.EncRijndael(srcIp.ToString());
                log4net.GlobalContext.Properties["SourcePort"] = Cryptography.EncRijndael(srcPort.ToString());
                log4net.GlobalContext.Properties["DestinationIP"] = Cryptography.EncRijndael(dstIp.ToString());
                log4net.GlobalContext.Properties["DestinationPort"] = Cryptography.EncRijndael(dstPort.ToString());
                logNetwork.Info("NetworkEvent");
            }
        }

        #endregion
    }
}
