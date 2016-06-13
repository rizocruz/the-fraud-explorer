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
 * Description: Applications Analytics
 */

using System;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using TFE_core.Config;
using TFE_core.Networking;
using TFE_core.Crypto;

namespace TFE_core.Analytics
{
    class ApplicationsAnalytics { }
    public class WindowEvents
    {
        /// <summary>
        /// Method wrapper for native methods called from C#.
        /// </summary>

        #region Native Methods

        private class NativeMethods
        {
            [DllImport("user32.dll")]
            public static extern IntPtr GetForegroundWindow();

            [DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            public static extern int GetWindowThreadProcessId(IntPtr windowHandle, out int processId);

            [DllImport("user32.dll")]
            public static extern int GetWindowText(int hWnd, StringBuilder text, int count);
        }

        #endregion

        /// <summary>
        /// Logs the current window information
        /// </summary>

        #region Logs Window Titles

        private static log4net.ILog logWindowTitles = log4net.LogManager.GetLogger("applicationsAnalytics_Repo", typeof(ApplicationsAnalyticsLogger));
        private static string lastWindowTitle;

        public static void LogCurrentWindowInformation()
        {
            var activeWindowId = NativeMethods.GetForegroundWindow();

            if (activeWindowId.Equals(0)) return;

            int processId;
            NativeMethods.GetWindowThreadProcessId(activeWindowId, out processId);

            if (processId == 0) return;

            Process foregroundProcess = Process.GetProcessById(processId);

            var fileName = string.Empty;
            var windowTitle = string.Empty;

            try { if (!string.IsNullOrEmpty(foregroundProcess.MainModule.FileName)) fileName = foregroundProcess.MainModule.FileName; }
            catch (Exception) { }

            try { if (!string.IsNullOrEmpty(foregroundProcess.MainWindowTitle)) windowTitle = foregroundProcess.MainWindowTitle; }
            catch (Exception) { }

            try
            {
                if (string.IsNullOrEmpty(windowTitle))
                {
                    const int Count = 1024;
                    var sb = new StringBuilder(Count);
                    NativeMethods.GetWindowText((int)activeWindowId, sb, Count);
                    windowTitle = sb.ToString();
                }
            }
            catch (Exception) { }

            if (lastWindowTitle != windowTitle && windowTitle != "")
            {
                log4net.GlobalContext.Properties["ProcessId"] = Cryptography.EncRijndael(Convert.ToString(processId));
                log4net.GlobalContext.Properties["FileName"] = Cryptography.EncRijndael(TextHelpers.RemoveDiacritics(fileName));
                log4net.GlobalContext.Properties["ApplicationWindow"] = Cryptography.EncRijndael(TextHelpers.RemoveDiacritics(windowTitle));
                log4net.GlobalContext.Properties["IPAddress"] = Network.GetAllLocalIPv4(NetworkInterfaceType.Ethernet).FirstOrDefault();
                log4net.GlobalContext.Properties["AgentID"] = Settings.AgentID;
                logWindowTitles.Info("ApplicationEvent");

                lastWindowTitle = windowTitle;
            }
        }

        #endregion
    }
}
