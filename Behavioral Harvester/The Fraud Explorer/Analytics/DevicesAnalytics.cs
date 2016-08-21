/*
 * The Fraud Explorer
 * http://www.thefraudexplorer.com/
 *
 * Copyright (c) 2016 The Fraud Explorer
 * email: support@thefraudexplorer.com
 * Licensed under GNU GPL v3
 * http://www.thefraudexplorer.com/License
 *
 * Date: 2016-06-30 15:12:41 -0500 (Wed, 30 Jun 2016)
 * Revision: v0.9.6-beta
 *
 * Description: Devices Analytics
 */

using System;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using TFE_core.Config;
using TFE_core.Networking;
using TFE_core.Crypto;

namespace TFE_core.Analytics
{
    class DevicesAnalytics { }

    public class DevicesEvents
    {
        /// <summary>
        /// Procedure for get devices events
        /// </summary>

        #region Devices events

        private static readonly log4net.ILog logDevices = log4net.LogManager.GetLogger("devicesAnalytics_Repo", typeof(DevicesAnalyticsLogger));
        public static ManagementEventWatcher m_mewWatcher;

        public static void DevicesAnalytics()
        {
            try
            {
                WqlEventQuery weqQuery = new WqlEventQuery();
                weqQuery.EventClassName = "__InstanceOperationEvent";
                weqQuery.WithinInterval = new TimeSpan(0, 0, 3);
                weqQuery.Condition = @"TargetInstance ISA 'Win32_DiskDrive'";

                ManagementScope msScope = new ManagementScope("root\\CIMV2");
                msScope.Options.EnablePrivileges = true;
                m_mewWatcher = new ManagementEventWatcher(msScope, weqQuery);
                m_mewWatcher.EventArrived += new EventArrivedEventHandler(m_mewWatcher_EventArrived);
                m_mewWatcher.Start();
            }
            catch { };
        }

        #endregion

        /// <summary>
        /// Devices status
        /// </summary>

        #region Devices status 

        private static void m_mewWatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            bool bUSBEvent = false;

            try
            {
                foreach (PropertyData pdData in e.NewEvent.Properties)
                {
                    ManagementBaseObject mbo = (ManagementBaseObject)pdData.Value;

                    if (mbo != null)
                    {
                        foreach (PropertyData pdDataSub in mbo.Properties)
                        {
                            if (pdDataSub.Name == "InterfaceType" && pdDataSub.Value.ToString() == "USB")
                            {
                                bUSBEvent = true;
                                break;
                            }
                        }

                        if (bUSBEvent)
                        {
                            if (e.NewEvent.ClassPath.ClassName == "__InstanceCreationEvent")
                            {
                                log4net.GlobalContext.Properties["IPAddress"] = Network.GetAllLocalIPv4(NetworkInterfaceType.Ethernet).FirstOrDefault();
                                log4net.GlobalContext.Properties["AgentID"] = Settings.AgentID;
                                log4net.GlobalContext.Properties["DeviceAction"] = Cryptography.EncRijndael("Plugged");
                                log4net.GlobalContext.Properties["DeviceDrive"] = String.Empty;

                                foreach (ManagementObject partition in new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + mbo.Properties["DeviceID"].Value + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition").Get())
                                {
                                    foreach (ManagementObject disk in new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + partition["DeviceID"] + "'} WHERE AssocClass = Win32_LogicalDiskToPartition").Get())
                                    {
                                        log4net.GlobalContext.Properties["DeviceDrive"] = Cryptography.EncRijndael(disk["Name"] + "\\");
                                    }
                                }

                                if (log4net.GlobalContext.Properties["DeviceDrive"].ToString() != String.Empty) logDevices.Info("DevicesEvent");
                            }
                            else if (e.NewEvent.ClassPath.ClassName == "__InstanceDeletionEvent") { }
                        }
                    }

                    if (bUSBEvent == true) break;
                }
            }
            catch {};
        }

        #endregion  
    }    
}
