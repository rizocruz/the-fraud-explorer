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
 * Description: Filesystem Analytics
 */

using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using TFE_core.Config;
using TFE_core.Networking;
using TFE_core.Crypto;
using System.Management;

namespace TFE_core.Analytics
{
    class FilesystemAnalytics { }

    class FileAnalytics
    {
        /// <summary>
        /// Filewatcher for analytics
        /// </summary>

        #region Analytics Filewatcher

        private static readonly log4net.ILog logFsw = log4net.LogManager.GetLogger("filesystemAnalytics_Repo", typeof(FilesystemAnalyticsLogger));

        public static void FileActivityWatcherAnalytics(string state, string drive, FileSystemWatcher unit)
        {
            if (state == "start")
            {                
                unit = new FileSystemWatcher(drive);
                unit.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Attributes | NotifyFilters.Security |
                                            NotifyFilters.Size | NotifyFilters.CreationTime;
                unit.Filter = "*.*";
                unit.IncludeSubdirectories = true;
                unit.EnableRaisingEvents = true;
                unit.Created += new FileSystemEventHandler(fswA_Trigger); unit.Changed += new FileSystemEventHandler(fswA_Trigger);
                unit.Deleted += new FileSystemEventHandler(fswA_Trigger); unit.Renamed += new RenamedEventHandler(fswA_Trigger);
            }
            else { unit.Dispose(); }
        }

        static void fswA_Trigger(object sender, FileSystemEventArgs e)
        {
            try
            {
                string ext = Path.GetExtension(e.FullPath).Replace(".", "").ToLower();

                if (ext == "") ext = "dir";
                if (FilesystemHelpers.filterCommonOperations(e.FullPath))
                {
                    log4net.GlobalContext.Properties["FileExtension"] = Cryptography.EncRijndael(ext);
                    log4net.GlobalContext.Properties["DriveUnit"] = Cryptography.EncRijndael((Path.GetPathRoot(e.FullPath)));
                    log4net.GlobalContext.Properties["ChangeType"] = Cryptography.EncRijndael(e.ChangeType.ToString());
                    log4net.GlobalContext.Properties["FullPath"] = Cryptography.EncRijndael(TextHelpers.RemoveDiacritics(e.FullPath));
                    log4net.GlobalContext.Properties["AgentID"] = Settings.AgentID;
                    log4net.GlobalContext.Properties["IPAddress"] = Network.GetAllLocalIPv4(NetworkInterfaceType.Ethernet).FirstOrDefault();
                    logFsw.Info("FilesystemEvent");
                }
            }
            catch { };
        }

        #endregion
    }
}
