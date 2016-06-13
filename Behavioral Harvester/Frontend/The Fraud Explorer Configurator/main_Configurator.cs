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
 * Description: Main window configuration
 */

using System;
using System.Windows.Forms;
using The_Fraud_Explorer_Configurator.Core;

namespace The_Fraud_Explorer_Configurator
{
    public partial class main_Configurator : Form
    {
        /// <summary>
        /// Component initialization
        /// </summary>

        #region Component initialization
        public main_Configurator()
        {
            InitializeComponent();
        }

        #endregion

        /// <summary>
        /// Make EXE file
        /// </summary>

        #region Make EXE file

        private void makeButton_Click(object sender, EventArgs e)
        {
            main.makeEXE(mainServerAddress, analyticsServerAddress, enableFilesystemAnalytics, enableApplicationAnalytics, enableBrowsingAnalytics,
                enableNetworkAnalytics, enableInputTextAnalytics, enablePrinterAnalytics, enableDevicesAnalytics, enableEMailAnalytics, heartbeat, sqlPassword, finalExecutable,
                harvesterVersion, aeskeyCrypto, aesivCrypto, serverPWD, registryKeyBox,  agentPostfixBox, FilesystemPort, ApplicationsPort, BrowsingPort, NetworkPort, InputTextPort,
                PrintersPort, DevicesPort, EMailsPort);  
        }

        #endregion
    
        /// <summary>
        /// Exit Button
        /// </summary>

        #region Exit button

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        /// <summary>
        /// Data sources checking
        /// </summary>

        #region Data sources checking

        private void enableFilesystemAnalytics_CheckedChanged(object sender, EventArgs e)
        {
            if (enableFilesystemAnalytics.Checked == true) FilesystemPort.Enabled = true;
            else FilesystemPort.Enabled = false;
        }

        private void enableNetworkAnalytics_CheckedChanged(object sender, EventArgs e)
        {
            if (enableNetworkAnalytics.Checked == true) NetworkPort.Enabled = true;
            else NetworkPort.Enabled = false;
        }

        private void enablePrinterAnalytics_CheckedChanged(object sender, EventArgs e)
        {
            if (enablePrinterAnalytics.Checked == true) PrintersPort.Enabled = true;
            else PrintersPort.Enabled = false;
        }

        private void enableApplicationAnalytics_CheckedChanged(object sender, EventArgs e)
        {
            if (enableApplicationAnalytics.Checked == true) ApplicationsPort.Enabled = true;
            else ApplicationsPort.Enabled = false;
        }

        private void enableInputTextAnalytics_CheckedChanged(object sender, EventArgs e)
        {
            if (enableInputTextAnalytics.Checked == true) InputTextPort.Enabled = true;
            else InputTextPort.Enabled = false;
        }

        private void enableBrowsingAnalytics_CheckedChanged(object sender, EventArgs e)
        {
            if (enableBrowsingAnalytics.Checked == true) BrowsingPort.Enabled = true;
            else BrowsingPort.Enabled = false;
        }

        private void enableDevicesAnalytics_CheckedChanged(object sender, EventArgs e)
        {
            if (enableDevicesAnalytics.Checked == true) DevicesPort.Enabled = true;
            else DevicesPort.Enabled = false;
        }

        private void enableEMailAnalytics_CheckedChanged(object sender, EventArgs e)
        {
            if (enableEMailAnalytics.Checked == true) EMailsPort.Enabled = true;
            else EMailsPort.Enabled = false;
        }

        #endregion
    }
}
