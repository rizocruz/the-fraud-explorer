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
            main.makeEXE(mainServerAddress, analyticsServerAddress, enableInputTextAnalytics, heartbeat, sqlPassword, finalExecutable, harvesterVersion, aeskeyCrypto, aesivCrypto, 
                         serverPWD, registryKeyBox, agentPostfixBox, InputTextPort);  
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

        private void enableInputTextAnalytics_CheckedChanged(object sender, EventArgs e)
        {
            if (enableInputTextAnalytics.Checked == true) InputTextPort.Enabled = true;
            else InputTextPort.Enabled = false;
        }

        #endregion
    }
}
