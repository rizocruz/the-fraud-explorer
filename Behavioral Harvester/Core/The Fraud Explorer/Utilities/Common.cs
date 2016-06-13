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
 * Description: Operating system
 */

using System;
using Microsoft.Win32;
using System.Diagnostics;
using TFE_core.Networking;
using System.Linq;

namespace TFE_core.Config
{
    class Common
    {
        /// <summary>
        /// Check registry key exists
        /// </summary>

        #region Check registry key exists

        public static bool existKey(string rKey)
        {
            RegistryKey AppKeyPOL, AppKeyAlternative; 
            
            AppKeyPOL = Registry.CurrentUser.OpenSubKey(Settings.registry_vars(Settings.RUNKEY));
            AppKeyAlternative = Registry.CurrentUser.OpenSubKey(Settings.HCKURunAlternative);

            if (AppKeyPOL == null && AppKeyAlternative == null) return false;
            else
            {
                if (AppKeyPOL != null)
                {
                    AppKeyPOL = Registry.CurrentUser.OpenSubKey(Settings.registry_vars(Settings.RUNKEY), true);
                    String[] Keys = AppKeyPOL.GetValueNames();
                    foreach (String c in Keys) if (c.Equals(rKey)) return true;
                    AppKeyPOL.Close();
                    return false;
                }
                if (AppKeyAlternative != null)
                {
                    AppKeyAlternative = Registry.CurrentUser.OpenSubKey(Settings.HCKURunAlternative, true);
                    String[] Keys = AppKeyAlternative.GetValueNames();
                    foreach (String c in Keys) if (c.Equals(rKey)) return true;
                    AppKeyAlternative.Close();
                    return false;
                }
            }
            return false;
        }

        #endregion

        /// <summary>
        /// Registry key installation
        /// </summary>

        #region Registry key installation
      
        public static void RegisterApp()
        {
                bool ALTERNATIVEREGPATH = false;
                RegistryKey AppKey;

                for (int i = 1; i <= Settings.registry_AppPath.Length-1;i++)
                {
                    RegistryKey base_registry = Registry.CurrentUser.OpenSubKey(Settings.registry_AppPath[i]);
                    if (base_registry == null) 
                    {
                        try
                        {                          
                            RegistryKey create_brecord = Registry.CurrentUser.CreateSubKey(Settings.registry_AppPath[i]);                           
                        }
                        catch (UnauthorizedAccessException) 
                        {
                            ALTERNATIVEREGPATH = true;
                            break;
                        }
                    }
                }

                if (ALTERNATIVEREGPATH == true)
                {
                    AppKey = Registry.CurrentUser.OpenSubKey(Settings.HCKURunAlternative, true);
                }
                else
                {
                    AppKey = Registry.CurrentUser.OpenSubKey(Settings.registry_vars(Settings.RUNKEY), true);
                }
                AppKey.SetValue(Settings.RegistryKeyValue, Settings.AppPath);
                AppKey.Close();
        }

        #endregion

        /// <summary>
        /// Operating system version
        /// </summary>

        #region Operating system version

        public static string OSVersion()
        {
            return Environment.OSVersion.Version.ToString()[0] + "." + Environment.OSVersion.Version.ToString()[2];
        }

        #endregion

        /// <summary>
        /// Filesystem directory preparation
        /// </summary>

        #region Filesystem directory preparation

        public static string SetAndCheckDir(string Directory)
        {
            string DirectoryForCheckOrCreate = null;
            switch (Directory)
            {
                case "InstallationPath":
                    DirectoryForCheckOrCreate = Settings.SoftwareBaseDir;
                    break;
                case "UpdaterFolder":
                    DirectoryForCheckOrCreate = Settings.SoftwareUpdater;
                    break;
                default:
                    break;
            }

            bool ifExists = System.IO.Directory.Exists(DirectoryForCheckOrCreate);

            if (!ifExists)
            {
                try
                {
                    System.IO.Directory.CreateDirectory(DirectoryForCheckOrCreate);
                }
                catch { };
            }

            return DirectoryForCheckOrCreate;
        }

        #endregion

        /// <summary>
        /// Process killing
        /// </summary>

        #region Process killing
  
        public static void KillProcess(string command, string uniqueID, string name)
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                if (process.ProcessName == name) process.Kill();
            }
            Network.SendData("process killed!", command, uniqueID, 1);
        }

        #endregion

        /// <summary>
        /// Prevent duplicate proccess running
        /// </summary>

        #region Prevent duplicate proccess running

        public static void preventDuplicate()
        {
            if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1) System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        #endregion

        /// <summary>
        /// Registry checks
        /// </summary>

        #region Registry checks

        public static void registryChecks()
        {
            Filesystem AppSourceFile = new Filesystem(System.Windows.Forms.Application.ExecutablePath);
            bool AppKeyExists = Common.existKey(Settings.RegistryKeyValue);

            if (!AppKeyExists)
            {
                // Copy executable agent to path, protect and registry

                Settings.AppPath = Common.SetAndCheckDir("InstallationPath") + "\\" + Settings.thefraudexplorer_executableName();
                AppSourceFile.CopyTo(Settings.AppPath);
                AppSourceFile = new Filesystem(Settings.AppPath);
                Common.RegisterApp();
                AppSourceFile.Protect();
            }
        }

        #endregion
    }
}