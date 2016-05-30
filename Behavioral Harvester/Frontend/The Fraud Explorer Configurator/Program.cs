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
 * Description: Main Application
 */

using System;
using System.Windows.Forms;

namespace The_Fraud_Explorer_Configurator
{
    static class Program
    {
        /// <summary>
        /// Main application
        /// </summary>

        #region Main Application

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new main_Configurator());
        }

        #endregion
    }
}
