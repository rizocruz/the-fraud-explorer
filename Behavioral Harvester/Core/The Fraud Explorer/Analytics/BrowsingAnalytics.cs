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
 * Description: Browsing Analytics
 */

using NDde.Client;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Windows.Automation;
using TFE_core.Config;
using TFE_core.Networking;
using TFE_core.Crypto;

namespace TFE_core.Analytics
{
    class BrowsingAnalytics { }

    public class BrowsersEvents
    {
        /// <summary>
        /// Timer procedure for Browser URL retrieval
        /// </summary>

        #region Browser URL retrieval procedure

        private static readonly log4net.ILog logBrowsingURLs = log4net.LogManager.GetLogger("browsingAnalytics_Repo", typeof(BrowsingAnalyticsLogger));
        private static string lastURLAccess;

        public static void BrowserProcess(string process)
        {
            Process[] ProcessName = Process.GetProcessesByName(process);
            if (ProcessName.Length != 0)
            {
                GetURL(process);

                string CurrentURL = GetURL(process);

                if (lastURLAccess != CurrentURL && CurrentURL != "")
                {
                    log4net.GlobalContext.Properties["URL"] = Cryptography.EncRijndael(TextHelpers.RemoveDiacritics(CurrentURL));
                    log4net.GlobalContext.Properties["IPAddress"] = Network.GetAllLocalIPv4(NetworkInterfaceType.Ethernet).FirstOrDefault();
                    log4net.GlobalContext.Properties["AgentID"] = Settings.AgentID;
                    log4net.GlobalContext.Properties["BrowserID"] = Cryptography.EncRijndael(process);
                    logBrowsingURLs.Info("URLEvent");

                    lastURLAccess = CurrentURL;
                }
            }
        }

        #endregion

        /// <summary>
        /// Get URL's from Browsers
        /// </summary>

        #region URL's from Chrome

        public static string GetURL(string Browser)
        {
            string ret = "";
            Process[] procs = Process.GetProcessesByName(Browser);

            foreach (Process proc in procs)
            {
                if (proc.MainWindowHandle == IntPtr.Zero) continue;

                AutomationElement elmChrome = AutomationElement.FromHandle(proc.MainWindowHandle);
                AutomationElement elmUrlBarChrome = null;

                // Google Chrome

                if (Browser == Settings.GoogleChrome_Browser)
                {
                    try
                    {
                        var elm1 = elmChrome.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "Google Chrome"));
                        if (elm1 == null) { continue; }
                        var elm2 = TreeWalker.RawViewWalker.GetLastChild(elm1);
                        var elm3 = elm2.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, ""));
                        var elm4 = TreeWalker.RawViewWalker.GetNextSibling(elm3);
                        var elm5 = elm4.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ToolBar));
                        var elm6 = elm5.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, ""));
                        elmUrlBarChrome = elm6.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
                    }
                    catch { continue; }

                    if (elmUrlBarChrome == null) continue;
                    if ((bool)elmUrlBarChrome.GetCurrentPropertyValue(AutomationElement.HasKeyboardFocusProperty)) continue;

                    AutomationPattern[] patterns = elmUrlBarChrome.GetSupportedPatterns();

                    if (patterns.Length == 1)
                    {
                        try
                        {
                            ret = ((ValuePattern)elmUrlBarChrome.GetCurrentPattern(patterns[0])).Current.Value;
                            return ret;
                        }
                        catch { }

                        if (ret != "")
                        {
                            if (Regex.IsMatch(ret, @"^(https:\/\/)?[a-zA-Z0-9\-\.]+(\.[a-zA-Z]{2,4}).*$"))
                            {
                                if (!ret.StartsWith("http")) ret = "http://" + ret;
                                return ret;
                            }
                        }
                        continue;
                    }
                    return ret;
                }

                // Mozilla Firefox

                if (Browser == Settings.MozillaFirefox_Browser)
                {
                    try
                    {
                        DdeClient dde = new DdeClient("firefox", "WWW_GetWindowInfo");
                        dde.Connect();
                        string url = dde.Request("URL", int.MaxValue);
                        string[] text = url.Split(new string[] { "\",\"" }, StringSplitOptions.RemoveEmptyEntries);
                        dde.Disconnect();
                        ret = text[0].Substring(1);

                        return ret;
                    }
                    catch { }
                }
            }

            return ret;

            #endregion
        }

    }
}
