/*
 * The Fraud Explorer
 * http://www.thefraudexplorer.com/
 *
 * Copyright (c) 2016 The Fraud Explorer
 * email: support@thefraudexplorer.com
 * Licensed under GNU GPL v3
 * http://www.thefraudexplorer.com/License
 *
 * Date: 2016-07
 * Revision: v0.9.7-beta
 *
 * Description: Core functions
 */

using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using The_Fraud_Explorer_Configurator.Crypto;

namespace The_Fraud_Explorer_Configurator.Core
{
    /// <summary>
    /// Make EXE procedure
    /// </summary>

    #region makeEXE procedure
    class CoreFunctions { }

    public class main
    {
        public static void makeEXE(TextBox mainServerAddress, TextBox analyticsServerAddress, CheckBox enableInputTextAnalytics, NumericUpDown heartbeat, 
            TextBox sqlPassword, TextBox finalExecutable, TextBox harvesterVersion, TextBox aeskeyCrypto, TextBox aesivCrypto, TextBox serverPWD, TextBox registryKeyBox, TextBox agentPostfixBox,
            NumericUpDown textPort)
        {
            string filepath = string.Empty;

            SaveFileDialog saveDlg = new SaveFileDialog();
            {
                saveDlg.FileName = "tfe-client.exe";
                saveDlg.Filter = "Executable Files (*.exe)|*.exe";

                if (saveDlg.ShowDialog() == DialogResult.OK) filepath = saveDlg.FileName;
                else return;
            }

            OpenFileDialog oFD = new OpenFileDialog();
            oFD.Filter = "Executable Files (*.exe)|*.exe";
            oFD.FileName = "The Fraud Explorer.exe";
            if (oFD.ShowDialog() == DialogResult.OK) File.Copy(oFD.FileName, filepath, true);

            // Global variables

            string tAnalytics;
            string heartBeat, sqlitePassword, exeName, AESkey, AESiv, serverPassword, registryKeyEntry, harvesterVer, agentPostfix;
            string tPort;
            string controlServerAddress, analyticsServerIP;

            string split = "-||-";

            // Main server address

            controlServerAddress = Ciphers.XMorEncryptText("http://" + mainServerAddress.Text.Replace("http://", ""));
            analyticsServerIP = Ciphers.XMorEncryptText(analyticsServerAddress.Text);

            // Data sources

            if (enableInputTextAnalytics.Checked == true) tAnalytics = "1";
            else tAnalytics = "0";
            tAnalytics = Ciphers.XMorEncryptText(tAnalytics);

            // Data UDP ports

            tPort = Ciphers.XMorEncryptText(textPort.Value.ToString());
         
            // General and Crypto options

            byte[] sqLitePWDhex = Encoding.Default.GetBytes(sqlPassword.Text);
            var hexString = BitConverter.ToString(sqLitePWDhex);
            hexString = hexString.Replace("-", "");
            hexString = "0x" + hexString;

            heartBeat = Ciphers.XMorEncryptText(heartbeat.Value.ToString());
            sqlitePassword = Ciphers.XMorEncryptText(hexString);
            exeName = Ciphers.XMorEncryptText(finalExecutable.Text);
            AESkey = Ciphers.XMorEncryptText(aeskeyCrypto.Text);
            AESiv = Ciphers.XMorEncryptText(aesivCrypto.Text);
            serverPassword = Ciphers.XMorEncryptText(serverPWD.Text);
            registryKeyEntry = Ciphers.XMorEncryptText(registryKeyBox.Text);
            harvesterVer = Ciphers.XMorEncryptText(harvesterVersion.Text);
            agentPostfix = Ciphers.XMorEncryptText(agentPostfixBox.Text);

            // Final binary string

            string info = split + controlServerAddress + "|" + analyticsServerIP + "|"  + tAnalytics + "|" + heartBeat + "|" + sqlitePassword + "|" + exeName + "|" + AESkey +
                         "|" + AESiv + "|" + serverPassword + "|" + registryKeyEntry + "|" + harvesterVer + "|" + agentPostfix + "|" + tPort + split;

            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            {
                BinaryWriter bw = new BinaryWriter(fs);
                fs.Position = fs.Length + 1;
                bw.Write(info);
                bw.Close();
            }

            MessageBox.Show("Fraud Triangle Analytics program created, enjoy!", "The Fraud Explorer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    #endregion
}
