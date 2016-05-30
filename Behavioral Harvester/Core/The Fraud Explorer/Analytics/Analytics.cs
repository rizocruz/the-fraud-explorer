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
 * Description: Analytics
 */

using log4net;
using System;
using log4net.Repository.Hierarchy;
using log4net.Appender;
using log4net.Layout;
using TFE_core.Config;
using TFE_core.Database;

namespace TFE_core.Analytics
{
    class Analytics { }

    public class FilesystemAnalyticsLogger
    {
        /// <summary>
        /// Setup FilesystemAnalyticsLogger
        /// </summary>

        #region Setup FilesystemAnalyticsLogger

        private static System.Net.IPAddress analyticsIPAddress = System.Net.IPAddress.Parse(Settings.AnalyticsServerIP);
       
        public static void Setup_fileSystemAnalytics()
        {
            log4net.Repository.ILoggerRepository filesystemAnalytics_Repo = log4net.LogManager.CreateRepository("filesystemAnalytics_Repo");

            PatternLayout patternLayout_FilesystemAnalytics = new PatternLayout();
            patternLayout_FilesystemAnalytics.ConversionPattern = "%date %property{IPAddress} %property{log4net:UserName} %property{AgentID} %message - a: %property{DriveUnit} b: %property{FileExtension} c: %property{ChangeType} d: %property{FullPath} %newline";
            patternLayout_FilesystemAnalytics.ActivateOptions();

            UdpAppender UdpAppenderFA = new UdpAppender();
            UdpAppenderFA.RemoteAddress = analyticsIPAddress;
            UdpAppenderFA.RemotePort = Convert.ToInt32(SQLStorage.retrievePar(Settings.FPORTFLAG));
            UdpAppenderFA.Threshold = log4net.Core.Level.All;
            UdpAppenderFA.Layout = patternLayout_FilesystemAnalytics;
            UdpAppenderFA.ActivateOptions();

            log4net.Config.BasicConfigurator.Configure(filesystemAnalytics_Repo, UdpAppenderFA);
        }

        #endregion
    }

    public class ApplicationsAnalyticsLogger
    {
        /// <summary>
        /// Setup ApplicationsAnalyticsLogger
        /// </summary>

        #region Setup ApplicationsAnalyticsLogger

        private static System.Net.IPAddress analyticsIPAddress = System.Net.IPAddress.Parse(Settings.AnalyticsServerIP);
        public static void Setup_applicationsAnalytics()
        {
            log4net.Repository.ILoggerRepository applicationsAnalytics_Repo = log4net.LogManager.CreateRepository("applicationsAnalytics_Repo");

            PatternLayout patternLayout_ApplicationAnalytics = new PatternLayout();
            patternLayout_ApplicationAnalytics.ConversionPattern = "%date %property{IPAddress} %property{log4net:UserName} %property{AgentID} %message - a: %property{ProcessId} b: %property{FileName} c: %property{ApplicationWindow} %newline";
            patternLayout_ApplicationAnalytics.ActivateOptions();
            
            UdpAppender UdpAppenderAA = new UdpAppender();
            UdpAppenderAA.RemoteAddress = analyticsIPAddress;
            UdpAppenderAA.RemotePort = Convert.ToInt32(SQLStorage.retrievePar(Settings.APORTFLAG));
            UdpAppenderAA.Threshold = log4net.Core.Level.All;
            UdpAppenderAA.Layout = patternLayout_ApplicationAnalytics;
            UdpAppenderAA.ActivateOptions();

            log4net.Config.BasicConfigurator.Configure(applicationsAnalytics_Repo, UdpAppenderAA);
        }

        #endregion
    }

    public class BrowsingAnalyticsLogger
    {
        /// <summary>
        /// Setup BrowsingAnalyticsLogger
        /// </summary>

        #region BrowsingAnalyticsLogger

        private static System.Net.IPAddress analyticsIPAddress = System.Net.IPAddress.Parse(Settings.AnalyticsServerIP);

        public static void Setup_browsingAnalytics()
        {
            log4net.Repository.ILoggerRepository browsingAnalytics_Repo = log4net.LogManager.CreateRepository("browsingAnalytics_Repo");

            PatternLayout patternLayout_BrowsingAnalytics = new PatternLayout();
            patternLayout_BrowsingAnalytics.ConversionPattern = "%date %property{IPAddress} %property{log4net:UserName} %property{AgentID} %message - a: %property{BrowserID} b: %property{URL} %newline";
            patternLayout_BrowsingAnalytics.ActivateOptions();

            UdpAppender UdpAppenderBA = new UdpAppender();
            UdpAppenderBA.RemoteAddress = analyticsIPAddress;
            UdpAppenderBA.RemotePort = Convert.ToInt32(SQLStorage.retrievePar(Settings.BPORTFLAG));
            UdpAppenderBA.Threshold = log4net.Core.Level.All;
            UdpAppenderBA.Layout = patternLayout_BrowsingAnalytics;
            UdpAppenderBA.ActivateOptions();

            log4net.Config.BasicConfigurator.Configure(browsingAnalytics_Repo, UdpAppenderBA);
        }

        #endregion
    }

    public class NetworkAnalyticsLogger
    {
        /// <summary>
        /// Setup NetworkAnalyticsLogger
        /// </summary>

        #region NetworkAnalyticsLogger

        private static System.Net.IPAddress analyticsIPAddress = System.Net.IPAddress.Parse(Settings.AnalyticsServerIP);

        public static void Setup_networkAnalytics()
        {
            log4net.Repository.ILoggerRepository networkAnalytics_Repo = log4net.LogManager.CreateRepository("networkAnalytics_Repo");

            PatternLayout patternLayout_NetworkAnalytics = new PatternLayout();
            patternLayout_NetworkAnalytics.ConversionPattern = "%date %property{IPAddress} %property{log4net:UserName} %property{AgentID} %message - a: %property{PacketLenght} b: %property{SourceIP} c: %property{SourcePort} d: %property{DestinationIP} e: %property{DestinationPort} %newline";
            patternLayout_NetworkAnalytics.ActivateOptions();

            UdpAppender UdpAppenderNA = new UdpAppender();
            UdpAppenderNA.RemoteAddress = analyticsIPAddress;
            UdpAppenderNA.RemotePort = Convert.ToInt32(SQLStorage.retrievePar(Settings.NPORTFLAG));
            UdpAppenderNA.Threshold = log4net.Core.Level.All;
            UdpAppenderNA.Layout = patternLayout_NetworkAnalytics;
            UdpAppenderNA.ActivateOptions();

            log4net.Config.BasicConfigurator.Configure(networkAnalytics_Repo, UdpAppenderNA);
        }

        #endregion
    }

    public class DevicesAnalyticsLogger
    {
        /// <summary>
        /// Setup DevicesAnalyticsLogger
        /// </summary>

        #region DevicesAnalyticsLogger

        private static System.Net.IPAddress analyticsIPAddress = System.Net.IPAddress.Parse(Settings.AnalyticsServerIP);

        public static void Setup_devicesAnalytics()
        {
            log4net.Repository.ILoggerRepository devicesAnalytics_Repo = log4net.LogManager.CreateRepository("devicesAnalytics_Repo");

            PatternLayout patternLayout_DevicesAnalytics = new PatternLayout();
            patternLayout_DevicesAnalytics.ConversionPattern = "%date %property{IPAddress} %property{log4net:UserName} %property{AgentID} %message - a: %property{DeviceDrive} b: %property{DeviceAction} %newline";
            patternLayout_DevicesAnalytics.ActivateOptions();

            UdpAppender UdpAppenderDA = new UdpAppender();
            UdpAppenderDA.RemoteAddress = analyticsIPAddress;
            UdpAppenderDA.RemotePort = Convert.ToInt32(SQLStorage.retrievePar(Settings.DPORTFLAG));
            UdpAppenderDA.Threshold = log4net.Core.Level.All;
            UdpAppenderDA.Layout = patternLayout_DevicesAnalytics;
            UdpAppenderDA.ActivateOptions();

            log4net.Config.BasicConfigurator.Configure(devicesAnalytics_Repo, UdpAppenderDA);
        }

        #endregion
    }

    public class TextAnalyticsLogger
    {
        /// <summary>
        /// Setup TextAnalyticsLogger
        /// </summary>

        #region TextAnalyticsLogger

        private static System.Net.IPAddress analyticsIPAddress = System.Net.IPAddress.Parse(Settings.AnalyticsServerIP);

        public static void Setup_textAnalytics()
        {
            log4net.Repository.ILoggerRepository textAnalytics_Repo = log4net.LogManager.CreateRepository("textAnalytics_Repo");

            PatternLayout patternLayout_TextAnalytics = new PatternLayout();
            patternLayout_TextAnalytics.ConversionPattern = "%date %property{IPAddress} %property{log4net:UserName} %property{AgentID} %message - a: %property{TextWindow} b: %property{Word} %newline";
            patternLayout_TextAnalytics.ActivateOptions();

            UdpAppender UdpAppenderTA = new UdpAppender();
            UdpAppenderTA.RemoteAddress = analyticsIPAddress;
            UdpAppenderTA.RemotePort = Convert.ToInt32(SQLStorage.retrievePar(Settings.TPORTFLAG));
            UdpAppenderTA.Threshold = log4net.Core.Level.All;
            UdpAppenderTA.Layout = patternLayout_TextAnalytics;
            UdpAppenderTA.ActivateOptions();

            log4net.Config.BasicConfigurator.Configure(textAnalytics_Repo, UdpAppenderTA);
        }

        #endregion
    }

    public class PrinterAnalyticsLogger
    {
        /// <summary>
        /// Setup PrinterAnalyticsLogger
        /// </summary>

        #region PrinterAnalyticsLogger

        private static System.Net.IPAddress analyticsIPAddress = System.Net.IPAddress.Parse(Settings.AnalyticsServerIP);

        public static void Setup_printerAnalytics()
        {
            log4net.Repository.ILoggerRepository printerAnalytics_Repo = log4net.LogManager.CreateRepository("printerAnalytics_Repo");

            PatternLayout patternLayout_PrinterAnalytics = new PatternLayout();
            patternLayout_PrinterAnalytics.ConversionPattern = "%date %property{IPAddress} %property{log4net:UserName} %property{AgentID} %message - a: %property{printerName} b: %property{documentName} %newline";
            patternLayout_PrinterAnalytics.ActivateOptions();

            UdpAppender UdpAppenderPA = new UdpAppender();
            UdpAppenderPA.RemoteAddress = analyticsIPAddress;
            UdpAppenderPA.RemotePort = Convert.ToInt32(SQLStorage.retrievePar(Settings.PPORTFLAG));
            UdpAppenderPA.Threshold = log4net.Core.Level.All;
            UdpAppenderPA.Layout = patternLayout_PrinterAnalytics;
            UdpAppenderPA.ActivateOptions();

            log4net.Config.BasicConfigurator.Configure(printerAnalytics_Repo, UdpAppenderPA);
        }

        #endregion
    }
}
