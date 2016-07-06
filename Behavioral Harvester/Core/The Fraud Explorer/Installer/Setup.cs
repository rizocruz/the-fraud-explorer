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
 * Description: Setup override procedures
 */

using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Reflection;
using System.IO;

namespace TFE_core.Installer
{
    [RunInstaller(true)]

    public class InstallerClass : System.Configuration.Install.Installer
    {
        public InstallerClass() : base()
        {
            this.Committed += new InstallEventHandler(MyInstaller_Committed);
            this.Committing += new InstallEventHandler(MyInstaller_Committing);
        }

        private void MyInstaller_Committing(object sender, InstallEventArgs e) { }

        private void MyInstaller_Committed(object sender, InstallEventArgs e)
        {
            try
            {
                Directory.SetCurrentDirectory(Path.GetDirectoryName
                (Assembly.GetExecutingAssembly().Location));
                Process.Start(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\mswow64svc.exe");
            }
            catch { }
        }
        public override void Install(IDictionary savedState)
        {
            base.Install(savedState);
        }

        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
        }

        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
        }
    }
}
