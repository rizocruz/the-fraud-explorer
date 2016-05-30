/*
 * The Fraud Explorer
 * http://www.thefraudexplorer.com/
 *
 * Copyright (c) 2016 The Fraud Explorer
 * email: support@thefraudexplorer.com
 * Licensed under GNU GPL v3
 * http://www.thefraudexplorer.com/License
 *
 * Date: 2016-04-30 15:12:41 -0500 (Wed, 30 April 2016)
 * Revision: v0.9.4
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
        public static void makeEXE(TextBox mainServerAddress, TextBox analyticsServerAddress, CheckBox enableFilesystemAnalytics, CheckBox enableApplicationAnalytics, CheckBox enableBrowsingAnalytics,
            CheckBox enableNetworkAnalytics, CheckBox enableInputTextAnalytics, CheckBox enablePrinterAnalytics, CheckBox enableDevicesAnalytics, CheckBox enableEMailsAnalytics, NumericUpDown heartbeat, 
            TextBox sqlPassword, TextBox finalExecutable, TextBox harvesterVersion, TextBox aeskeyCrypto, TextBox aesivCrypto, TextBox serverPWD, TextBox registryKeyBox, TextBox agentPostfixBox,
            NumericUpDown filesystemPort, NumericUpDown windowsPort, NumericUpDown browsingPort, NumericUpDown networkPort, NumericUpDown textPort, NumericUpDown printerPort, NumericUpDown devicesPort, 
            NumericUpDown emailsPort)
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

            string fAnalytics, wAnalytics, bAnalytics, nAnalytics, tAnalytics, pAnalytics, dAnalytics, eAnalytics;
            string heartBeat, sqlitePassword, exeName, AESkey, AESiv, serverPassword, registryKeyEntry, harvesterVer, agentPostfix;
            string fPort, wPort, bPort, nPort, tPort, pPort, dPort, ePort;
            string controlServerAddress, analyticsServerIP;

            string split = "-||-";

            // Main server address

            controlServerAddress = Ciphers.XMorEncryptText("http://" + mainServerAddress.Text.Replace("http://", ""));
            analyticsServerIP = Ciphers.XMorEncryptText(analyticsServerAddress.Text);

            // Data sources

            if (enableFilesystemAnalytics.Checked == true) fAnalytics = "1";
            else fAnalytics = "0";
            fAnalytics = Ciphers.XMorEncryptText(fAnalytics);

            if (enableApplicationAnalytics.Checked == true) wAnalytics = "1";
            else wAnalytics = "0";
            wAnalytics = Ciphers.XMorEncryptText(wAnalytics);

            if (enableBrowsingAnalytics.Checked == true) bAnalytics = "1";
            else bAnalytics = "0";
            bAnalytics = Ciphers.XMorEncryptText(bAnalytics);

            if (enableNetworkAnalytics.Checked == true) nAnalytics = "1";
            else nAnalytics = "0";
            nAnalytics = Ciphers.XMorEncryptText(nAnalytics);

            if (enableInputTextAnalytics.Checked == true) tAnalytics = "1";
            else tAnalytics = "0";
            tAnalytics = Ciphers.XMorEncryptText(tAnalytics);

            if (enablePrinterAnalytics.Checked == true) pAnalytics = "1";
            else pAnalytics = "0";
            pAnalytics = Ciphers.XMorEncryptText(pAnalytics);

            if (enableDevicesAnalytics.Checked == true) dAnalytics = "1";
            else dAnalytics = "0";
            dAnalytics = Ciphers.XMorEncryptText(dAnalytics);

            if (enableEMailsAnalytics.Checked == true) eAnalytics = "1";
            else eAnalytics = "0";
            eAnalytics = Ciphers.XMorEncryptText(eAnalytics);

            // Data UDP ports

            fPort = Ciphers.XMorEncryptText(filesystemPort.Value.ToString());
            wPort = Ciphers.XMorEncryptText(windowsPort.Value.ToString());
            bPort = Ciphers.XMorEncryptText(browsingPort.Value.ToString());
            nPort = Ciphers.XMorEncryptText(networkPort.Value.ToString());
            tPort = Ciphers.XMorEncryptText(textPort.Value.ToString());
            pPort = Ciphers.XMorEncryptText(printerPort.Value.ToString());
            dPort = Ciphers.XMorEncryptText(devicesPort.Value.ToString());
            ePort = Ciphers.XMorEncryptText(emailsPort.Value.ToString());

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

            string info = split + controlServerAddress + "|" + analyticsServerIP + "|" + fAnalytics + "|" + wAnalytics + "|" + bAnalytics + "|" + nAnalytics + "|" + tAnalytics +
                "|" + pAnalytics + "|" + dAnalytics + "|" + eAnalytics + "|" + heartBeat + "|" + sqlitePassword + "|" + exeName + "|" + AESkey + "|" + AESiv + "|" + serverPassword +
                "|" + registryKeyEntry + "|" + harvesterVer + "|" + agentPostfix + "|" + fPort + "|" + wPort + "|" + bPort + "|" + nPort + "|" + tPort + "|" + pPort + "|" + dPort + 
                "|" + ePort + split;

            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            {
                BinaryWriter bw = new BinaryWriter(fs);
                fs.Position = fs.Length + 1;
                bw.Write(info);
                bw.Close();
            }

            MessageBox.Show("User Behavior Analytics program created, enjoy!", "The Fraud Explorer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    #endregion
}
