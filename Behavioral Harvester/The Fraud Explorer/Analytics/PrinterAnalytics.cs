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
 * Description: Printer Analytics
 */

using System;
using TFE_core.Config;
using System.Management;
using TFE_core.Networking;
using System.Net.NetworkInformation;
using System.Linq;
using TFE_core.Crypto;

namespace TFE_core.Analytics
{
    class PrinterAnalytics { }

    public class PrinterEventWatcherAsync
    {
        /// <summary>
        /// Procedure for get printer events
        /// </summary>

        #region Printer events

        private static readonly log4net.ILog logPrinter = log4net.LogManager.GetLogger("printerAnalytics_Repo", typeof(PrinterAnalyticsLogger));
        public string lastDocumentName = String.Empty;
        public string currentDocumentName = String.Empty;
        public string currentPrinterName = String.Empty;

        private void WmiEventHandler(object sender, EventArrivedEventArgs e)
        {
            currentDocumentName = ((ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value)["Document"].ToString();
            currentPrinterName = ((ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value)["Caption"].ToString();
            int index = currentPrinterName.IndexOf(",");
            currentPrinterName = currentPrinterName.Substring(0, index);

            if (currentDocumentName != lastDocumentName)
            {
                log4net.GlobalContext.Properties["IPAddress"] = Network.GetAllLocalIPv4(NetworkInterfaceType.Ethernet).FirstOrDefault();
                log4net.GlobalContext.Properties["AgentID"] = Settings.AgentID;
                log4net.GlobalContext.Properties["printerName"] = Cryptography.EncRijndael(TextHelpers.RemoveDiacritics(currentPrinterName));
                log4net.GlobalContext.Properties["documentName"] = Cryptography.EncRijndael(TextHelpers.RemoveDiacritics(currentDocumentName));
                logPrinter.Info("PrinterEvent");
            }

            lastDocumentName = String.Copy(currentDocumentName);
        }

        public PrinterEventWatcherAsync()
        {
            try
            {
                string ComputerName = "localhost";
                string WmiQuery;
                ManagementEventWatcher Watcher;
                ManagementScope Scope;
                
                if (!ComputerName.Equals("localhost", StringComparison.OrdinalIgnoreCase))
                {
                    ConnectionOptions Conn = new ConnectionOptions();
                    Conn.Username = "";
                    Conn.Password = "";
                    Conn.Authority = "ntlmdomain:DOMAIN";
                    Scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", ComputerName), Conn);
                }
                else Scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", ComputerName), null);

                Scope.Connect();
                WmiQuery = "Select * From __InstanceOperationEvent Within 0.1 " + "Where TargetInstance ISA 'Win32_PrintJob' ";
                Watcher = new ManagementEventWatcher(Scope, new EventQuery(WmiQuery));
                Watcher.EventArrived += new EventArrivedEventHandler(this.WmiEventHandler);
                Watcher.Start();
            }
            catch { }
        }
        #endregion
    }
}

