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
 * Description: Main window configuration designer
 */

namespace The_Fraud_Explorer_Configurator
{
    partial class main_Configurator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>

        #region Designer variables

        private System.ComponentModel.IContainer components = null;

        #endregion

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>

        #region Clean up resources

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_Configurator));
            this.mainServerAddress = new System.Windows.Forms.TextBox();
            this.analyticsServerAddress = new System.Windows.Forms.TextBox();
            this.makeButton = new System.Windows.Forms.Button();
            this.httpMainServer_Label = new System.Windows.Forms.Label();
            this.mainServer_Label = new System.Windows.Forms.Label();
            this.analyticsServer_Label = new System.Windows.Forms.Label();
            this.NFLogo = new System.Windows.Forms.PictureBox();
            this.enableFilesystemAnalytics = new System.Windows.Forms.CheckBox();
            this.analyticsOptions = new System.Windows.Forms.GroupBox();
            this.enableEMailAnalytics = new System.Windows.Forms.CheckBox();
            this.groupPorts = new System.Windows.Forms.GroupBox();
            this.EMailsPort = new System.Windows.Forms.NumericUpDown();
            this.DevicesPort = new System.Windows.Forms.NumericUpDown();
            this.BrowsingPort = new System.Windows.Forms.NumericUpDown();
            this.InputTextPort = new System.Windows.Forms.NumericUpDown();
            this.ApplicationsPort = new System.Windows.Forms.NumericUpDown();
            this.PrintersPort = new System.Windows.Forms.NumericUpDown();
            this.NetworkPort = new System.Windows.Forms.NumericUpDown();
            this.FilesystemPort = new System.Windows.Forms.NumericUpDown();
            this.enableDevicesAnalytics = new System.Windows.Forms.CheckBox();
            this.enablePrinterAnalytics = new System.Windows.Forms.CheckBox();
            this.enableInputTextAnalytics = new System.Windows.Forms.CheckBox();
            this.enableNetworkAnalytics = new System.Windows.Forms.CheckBox();
            this.enableBrowsingAnalytics = new System.Windows.Forms.CheckBox();
            this.enableApplicationAnalytics = new System.Windows.Forms.CheckBox();
            this.generalOptions = new System.Windows.Forms.GroupBox();
            this.milliseconds = new System.Windows.Forms.Label();
            this.harvesterVersion = new System.Windows.Forms.TextBox();
            this.harvesterText = new System.Windows.Forms.Label();
            this.heartBeatDescription = new System.Windows.Forms.Label();
            this.finalExecutable = new System.Windows.Forms.TextBox();
            this.finalExecutableName = new System.Windows.Forms.Label();
            this.sqlPassword = new System.Windows.Forms.TextBox();
            this.internalSQLPassword = new System.Windows.Forms.Label();
            this.heartbeatValue = new System.Windows.Forms.Label();
            this.heartbeat = new System.Windows.Forms.NumericUpDown();
            this.cryptoOptions = new System.Windows.Forms.GroupBox();
            this.agentPostfixBox = new System.Windows.Forms.TextBox();
            this.postfixAgent = new System.Windows.Forms.Label();
            this.registryKeyBox = new System.Windows.Forms.TextBox();
            this.registryKey = new System.Windows.Forms.Label();
            this.serverPWD = new System.Windows.Forms.TextBox();
            this.serverPassword = new System.Windows.Forms.Label();
            this.aesivCrypto = new System.Windows.Forms.TextBox();
            this.aesIv = new System.Windows.Forms.Label();
            this.aeskeyCrypto = new System.Windows.Forms.TextBox();
            this.aesKey = new System.Windows.Forms.Label();
            this.TFETitle = new System.Windows.Forms.Label();
            this.UBA = new System.Windows.Forms.Label();
            this.horizontalLine = new System.Windows.Forms.Label();
            this.horizontalLineMiddle = new System.Windows.Forms.Label();
            this.mainServerConfiguration = new System.Windows.Forms.GroupBox();
            this.horizontalLineBottom = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NFLogo)).BeginInit();
            this.analyticsOptions.SuspendLayout();
            this.groupPorts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EMailsPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DevicesPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrowsingPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputTextPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApplicationsPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintersPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetworkPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilesystemPort)).BeginInit();
            this.generalOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heartbeat)).BeginInit();
            this.cryptoOptions.SuspendLayout();
            this.mainServerConfiguration.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainServerAddress
            // 
            this.mainServerAddress.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainServerAddress.Location = new System.Drawing.Point(264, 37);
            this.mainServerAddress.Name = "mainServerAddress";
            this.mainServerAddress.Size = new System.Drawing.Size(394, 22);
            this.mainServerAddress.TabIndex = 0;
            this.mainServerAddress.Text = "tfe-input.mydomain.com/update.xml";
            // 
            // analyticsServerAddress
            // 
            this.analyticsServerAddress.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analyticsServerAddress.Location = new System.Drawing.Point(264, 68);
            this.analyticsServerAddress.Name = "analyticsServerAddress";
            this.analyticsServerAddress.Size = new System.Drawing.Size(394, 22);
            this.analyticsServerAddress.TabIndex = 1;
            this.analyticsServerAddress.Text = "192.168.7.194";
            // 
            // makeButton
            // 
            this.makeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makeButton.Location = new System.Drawing.Point(594, 593);
            this.makeButton.Name = "makeButton";
            this.makeButton.Size = new System.Drawing.Size(103, 32);
            this.makeButton.TabIndex = 2;
            this.makeButton.Text = "Make EXE";
            this.makeButton.UseVisualStyleBackColor = true;
            this.makeButton.Click += new System.EventHandler(this.makeButton_Click);
            // 
            // httpMainServer_Label
            // 
            this.httpMainServer_Label.AutoSize = true;
            this.httpMainServer_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.httpMainServer_Label.Location = new System.Drawing.Point(42, 44);
            this.httpMainServer_Label.Name = "httpMainServer_Label";
            this.httpMainServer_Label.Size = new System.Drawing.Size(0, 15);
            this.httpMainServer_Label.TabIndex = 3;
            // 
            // mainServer_Label
            // 
            this.mainServer_Label.AutoSize = true;
            this.mainServer_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainServer_Label.Location = new System.Drawing.Point(6, 38);
            this.mainServer_Label.Name = "mainServer_Label";
            this.mainServer_Label.Size = new System.Drawing.Size(255, 15);
            this.mainServer_Label.TabIndex = 5;
            this.mainServer_Label.Text = "Main server address (Administration purpose)";
            // 
            // analyticsServer_Label
            // 
            this.analyticsServer_Label.AutoSize = true;
            this.analyticsServer_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analyticsServer_Label.Location = new System.Drawing.Point(6, 71);
            this.analyticsServer_Label.Name = "analyticsServer_Label";
            this.analyticsServer_Label.Size = new System.Drawing.Size(236, 15);
            this.analyticsServer_Label.TabIndex = 6;
            this.analyticsServer_Label.Text = "Analytics server IP (Splunk, ELK, LogTrust)";
            // 
            // NFLogo
            // 
            this.NFLogo.Image = ((System.Drawing.Image)(resources.GetObject("NFLogo.Image")));
            this.NFLogo.Location = new System.Drawing.Point(21, 15);
            this.NFLogo.Name = "NFLogo";
            this.NFLogo.Size = new System.Drawing.Size(77, 64);
            this.NFLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.NFLogo.TabIndex = 7;
            this.NFLogo.TabStop = false;
            // 
            // enableFilesystemAnalytics
            // 
            this.enableFilesystemAnalytics.AutoSize = true;
            this.enableFilesystemAnalytics.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableFilesystemAnalytics.Location = new System.Drawing.Point(19, 44);
            this.enableFilesystemAnalytics.Name = "enableFilesystemAnalytics";
            this.enableFilesystemAnalytics.Size = new System.Drawing.Size(84, 19);
            this.enableFilesystemAnalytics.TabIndex = 8;
            this.enableFilesystemAnalytics.Text = "Filesystem";
            this.enableFilesystemAnalytics.UseVisualStyleBackColor = true;
            this.enableFilesystemAnalytics.CheckedChanged += new System.EventHandler(this.enableFilesystemAnalytics_CheckedChanged);
            // 
            // analyticsOptions
            // 
            this.analyticsOptions.Controls.Add(this.enableEMailAnalytics);
            this.analyticsOptions.Controls.Add(this.groupPorts);
            this.analyticsOptions.Controls.Add(this.enableDevicesAnalytics);
            this.analyticsOptions.Controls.Add(this.enablePrinterAnalytics);
            this.analyticsOptions.Controls.Add(this.enableInputTextAnalytics);
            this.analyticsOptions.Controls.Add(this.enableNetworkAnalytics);
            this.analyticsOptions.Controls.Add(this.enableBrowsingAnalytics);
            this.analyticsOptions.Controls.Add(this.enableApplicationAnalytics);
            this.analyticsOptions.Controls.Add(this.enableFilesystemAnalytics);
            this.analyticsOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analyticsOptions.Location = new System.Drawing.Point(244, 275);
            this.analyticsOptions.Name = "analyticsOptions";
            this.analyticsOptions.Size = new System.Drawing.Size(229, 277);
            this.analyticsOptions.TabIndex = 9;
            this.analyticsOptions.TabStop = false;
            this.analyticsOptions.Text = "Harvester Sources";
            // 
            // enableEMailAnalytics
            // 
            this.enableEMailAnalytics.AutoSize = true;
            this.enableEMailAnalytics.Location = new System.Drawing.Point(19, 230);
            this.enableEMailAnalytics.Name = "enableEMailAnalytics";
            this.enableEMailAnalytics.Size = new System.Drawing.Size(68, 19);
            this.enableEMailAnalytics.TabIndex = 16;
            this.enableEMailAnalytics.Text = "E-Mails";
            this.enableEMailAnalytics.UseVisualStyleBackColor = true;
            this.enableEMailAnalytics.CheckedChanged += new System.EventHandler(this.enableEMailAnalytics_CheckedChanged);
            // 
            // groupPorts
            // 
            this.groupPorts.Controls.Add(this.EMailsPort);
            this.groupPorts.Controls.Add(this.DevicesPort);
            this.groupPorts.Controls.Add(this.BrowsingPort);
            this.groupPorts.Controls.Add(this.InputTextPort);
            this.groupPorts.Controls.Add(this.ApplicationsPort);
            this.groupPorts.Controls.Add(this.PrintersPort);
            this.groupPorts.Controls.Add(this.NetworkPort);
            this.groupPorts.Controls.Add(this.FilesystemPort);
            this.groupPorts.Location = new System.Drawing.Point(129, 20);
            this.groupPorts.Name = "groupPorts";
            this.groupPorts.Size = new System.Drawing.Size(87, 240);
            this.groupPorts.TabIndex = 15;
            this.groupPorts.TabStop = false;
            this.groupPorts.Text = "UDP Ports";
            // 
            // EMailsPort
            // 
            this.EMailsPort.Enabled = false;
            this.EMailsPort.Location = new System.Drawing.Point(11, 209);
            this.EMailsPort.Maximum = new decimal(new int[] {
            65500,
            0,
            0,
            0});
            this.EMailsPort.Name = "EMailsPort";
            this.EMailsPort.Size = new System.Drawing.Size(65, 21);
            this.EMailsPort.TabIndex = 22;
            this.EMailsPort.Value = new decimal(new int[] {
            5967,
            0,
            0,
            0});
            // 
            // DevicesPort
            // 
            this.DevicesPort.Enabled = false;
            this.DevicesPort.Location = new System.Drawing.Point(11, 183);
            this.DevicesPort.Maximum = new decimal(new int[] {
            65500,
            0,
            0,
            0});
            this.DevicesPort.Name = "DevicesPort";
            this.DevicesPort.Size = new System.Drawing.Size(65, 21);
            this.DevicesPort.TabIndex = 21;
            this.DevicesPort.Value = new decimal(new int[] {
            5964,
            0,
            0,
            0});
            // 
            // BrowsingPort
            // 
            this.BrowsingPort.Enabled = false;
            this.BrowsingPort.Location = new System.Drawing.Point(11, 156);
            this.BrowsingPort.Maximum = new decimal(new int[] {
            65500,
            0,
            0,
            0});
            this.BrowsingPort.Name = "BrowsingPort";
            this.BrowsingPort.Size = new System.Drawing.Size(65, 21);
            this.BrowsingPort.TabIndex = 20;
            this.BrowsingPort.Value = new decimal(new int[] {
            5962,
            0,
            0,
            0});
            // 
            // InputTextPort
            // 
            this.InputTextPort.Enabled = false;
            this.InputTextPort.Location = new System.Drawing.Point(11, 129);
            this.InputTextPort.Maximum = new decimal(new int[] {
            65500,
            0,
            0,
            0});
            this.InputTextPort.Name = "InputTextPort";
            this.InputTextPort.Size = new System.Drawing.Size(65, 21);
            this.InputTextPort.TabIndex = 19;
            this.InputTextPort.Value = new decimal(new int[] {
            5965,
            0,
            0,
            0});
            // 
            // ApplicationsPort
            // 
            this.ApplicationsPort.Enabled = false;
            this.ApplicationsPort.Location = new System.Drawing.Point(11, 102);
            this.ApplicationsPort.Maximum = new decimal(new int[] {
            65500,
            0,
            0,
            0});
            this.ApplicationsPort.Name = "ApplicationsPort";
            this.ApplicationsPort.Size = new System.Drawing.Size(65, 21);
            this.ApplicationsPort.TabIndex = 18;
            this.ApplicationsPort.Value = new decimal(new int[] {
            5961,
            0,
            0,
            0});
            // 
            // PrintersPort
            // 
            this.PrintersPort.Enabled = false;
            this.PrintersPort.Location = new System.Drawing.Point(11, 76);
            this.PrintersPort.Maximum = new decimal(new int[] {
            65500,
            0,
            0,
            0});
            this.PrintersPort.Name = "PrintersPort";
            this.PrintersPort.Size = new System.Drawing.Size(65, 21);
            this.PrintersPort.TabIndex = 17;
            this.PrintersPort.Value = new decimal(new int[] {
            5966,
            0,
            0,
            0});
            // 
            // NetworkPort
            // 
            this.NetworkPort.Enabled = false;
            this.NetworkPort.Location = new System.Drawing.Point(11, 50);
            this.NetworkPort.Maximum = new decimal(new int[] {
            65500,
            0,
            0,
            0});
            this.NetworkPort.Name = "NetworkPort";
            this.NetworkPort.Size = new System.Drawing.Size(65, 21);
            this.NetworkPort.TabIndex = 16;
            this.NetworkPort.Value = new decimal(new int[] {
            5963,
            0,
            0,
            0});
            // 
            // FilesystemPort
            // 
            this.FilesystemPort.Enabled = false;
            this.FilesystemPort.Location = new System.Drawing.Point(11, 23);
            this.FilesystemPort.Maximum = new decimal(new int[] {
            65500,
            0,
            0,
            0});
            this.FilesystemPort.Name = "FilesystemPort";
            this.FilesystemPort.Size = new System.Drawing.Size(65, 21);
            this.FilesystemPort.TabIndex = 15;
            this.FilesystemPort.Value = new decimal(new int[] {
            5960,
            0,
            0,
            0});
            // 
            // enableDevicesAnalytics
            // 
            this.enableDevicesAnalytics.AutoSize = true;
            this.enableDevicesAnalytics.Location = new System.Drawing.Point(19, 203);
            this.enableDevicesAnalytics.Name = "enableDevicesAnalytics";
            this.enableDevicesAnalytics.Size = new System.Drawing.Size(69, 19);
            this.enableDevicesAnalytics.TabIndex = 14;
            this.enableDevicesAnalytics.Text = "Devices";
            this.enableDevicesAnalytics.UseVisualStyleBackColor = true;
            this.enableDevicesAnalytics.CheckedChanged += new System.EventHandler(this.enableDevicesAnalytics_CheckedChanged);
            // 
            // enablePrinterAnalytics
            // 
            this.enablePrinterAnalytics.AutoSize = true;
            this.enablePrinterAnalytics.Location = new System.Drawing.Point(19, 97);
            this.enablePrinterAnalytics.Name = "enablePrinterAnalytics";
            this.enablePrinterAnalytics.Size = new System.Drawing.Size(68, 19);
            this.enablePrinterAnalytics.TabIndex = 13;
            this.enablePrinterAnalytics.Text = "Printers";
            this.enablePrinterAnalytics.UseVisualStyleBackColor = true;
            this.enablePrinterAnalytics.CheckedChanged += new System.EventHandler(this.enablePrinterAnalytics_CheckedChanged);
            // 
            // enableInputTextAnalytics
            // 
            this.enableInputTextAnalytics.AutoSize = true;
            this.enableInputTextAnalytics.Location = new System.Drawing.Point(19, 150);
            this.enableInputTextAnalytics.Name = "enableInputTextAnalytics";
            this.enableInputTextAnalytics.Size = new System.Drawing.Size(76, 19);
            this.enableInputTextAnalytics.TabIndex = 12;
            this.enableInputTextAnalytics.Text = "InputText";
            this.enableInputTextAnalytics.UseVisualStyleBackColor = true;
            this.enableInputTextAnalytics.CheckedChanged += new System.EventHandler(this.enableInputTextAnalytics_CheckedChanged);
            // 
            // enableNetworkAnalytics
            // 
            this.enableNetworkAnalytics.AutoSize = true;
            this.enableNetworkAnalytics.Location = new System.Drawing.Point(19, 70);
            this.enableNetworkAnalytics.Name = "enableNetworkAnalytics";
            this.enableNetworkAnalytics.Size = new System.Drawing.Size(71, 19);
            this.enableNetworkAnalytics.TabIndex = 11;
            this.enableNetworkAnalytics.Text = "Network";
            this.enableNetworkAnalytics.UseVisualStyleBackColor = true;
            this.enableNetworkAnalytics.CheckedChanged += new System.EventHandler(this.enableNetworkAnalytics_CheckedChanged);
            // 
            // enableBrowsingAnalytics
            // 
            this.enableBrowsingAnalytics.AutoSize = true;
            this.enableBrowsingAnalytics.Location = new System.Drawing.Point(19, 177);
            this.enableBrowsingAnalytics.Name = "enableBrowsingAnalytics";
            this.enableBrowsingAnalytics.Size = new System.Drawing.Size(77, 19);
            this.enableBrowsingAnalytics.TabIndex = 10;
            this.enableBrowsingAnalytics.Text = "Browsing";
            this.enableBrowsingAnalytics.UseVisualStyleBackColor = true;
            this.enableBrowsingAnalytics.CheckedChanged += new System.EventHandler(this.enableBrowsingAnalytics_CheckedChanged);
            // 
            // enableApplicationAnalytics
            // 
            this.enableApplicationAnalytics.AutoSize = true;
            this.enableApplicationAnalytics.Location = new System.Drawing.Point(19, 123);
            this.enableApplicationAnalytics.Name = "enableApplicationAnalytics";
            this.enableApplicationAnalytics.Size = new System.Drawing.Size(92, 19);
            this.enableApplicationAnalytics.TabIndex = 9;
            this.enableApplicationAnalytics.Text = "Applications";
            this.enableApplicationAnalytics.UseVisualStyleBackColor = true;
            this.enableApplicationAnalytics.CheckedChanged += new System.EventHandler(this.enableApplicationAnalytics_CheckedChanged);
            // 
            // generalOptions
            // 
            this.generalOptions.Controls.Add(this.milliseconds);
            this.generalOptions.Controls.Add(this.harvesterVersion);
            this.generalOptions.Controls.Add(this.harvesterText);
            this.generalOptions.Controls.Add(this.heartBeatDescription);
            this.generalOptions.Controls.Add(this.finalExecutable);
            this.generalOptions.Controls.Add(this.finalExecutableName);
            this.generalOptions.Controls.Add(this.sqlPassword);
            this.generalOptions.Controls.Add(this.internalSQLPassword);
            this.generalOptions.Controls.Add(this.heartbeatValue);
            this.generalOptions.Controls.Add(this.heartbeat);
            this.generalOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generalOptions.Location = new System.Drawing.Point(21, 275);
            this.generalOptions.Name = "generalOptions";
            this.generalOptions.Size = new System.Drawing.Size(210, 277);
            this.generalOptions.TabIndex = 10;
            this.generalOptions.TabStop = false;
            this.generalOptions.Text = "General Options";
            // 
            // milliseconds
            // 
            this.milliseconds.AutoSize = true;
            this.milliseconds.Location = new System.Drawing.Point(116, 93);
            this.milliseconds.Name = "milliseconds";
            this.milliseconds.Size = new System.Drawing.Size(76, 15);
            this.milliseconds.TabIndex = 11;
            this.milliseconds.Text = "milliseconds";
            // 
            // harvesterVersion
            // 
            this.harvesterVersion.Location = new System.Drawing.Point(16, 236);
            this.harvesterVersion.Name = "harvesterVersion";
            this.harvesterVersion.Size = new System.Drawing.Size(174, 21);
            this.harvesterVersion.TabIndex = 10;
            this.harvesterVersion.Text = "0.9.4";
            // 
            // harvesterText
            // 
            this.harvesterText.AutoSize = true;
            this.harvesterText.Location = new System.Drawing.Point(14, 216);
            this.harvesterText.Name = "harvesterText";
            this.harvesterText.Size = new System.Drawing.Size(101, 15);
            this.harvesterText.TabIndex = 9;
            this.harvesterText.Text = "Harvester version";
            // 
            // heartBeatDescription
            // 
            this.heartBeatDescription.Location = new System.Drawing.Point(14, 48);
            this.heartBeatDescription.Name = "heartBeatDescription";
            this.heartBeatDescription.Size = new System.Drawing.Size(190, 40);
            this.heartBeatDescription.TabIndex = 8;
            this.heartBeatDescription.Text = "Please specify the connection interval from agent to server";
            this.heartBeatDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // finalExecutable
            // 
            this.finalExecutable.Location = new System.Drawing.Point(16, 189);
            this.finalExecutable.Name = "finalExecutable";
            this.finalExecutable.Size = new System.Drawing.Size(174, 21);
            this.finalExecutable.TabIndex = 7;
            this.finalExecutable.Text = "mswow64svc";
            // 
            // finalExecutableName
            // 
            this.finalExecutableName.AutoSize = true;
            this.finalExecutableName.Location = new System.Drawing.Point(14, 168);
            this.finalExecutableName.Name = "finalExecutableName";
            this.finalExecutableName.Size = new System.Drawing.Size(135, 15);
            this.finalExecutableName.TabIndex = 6;
            this.finalExecutableName.Text = "Final Executable Name";
            // 
            // sqlPassword
            // 
            this.sqlPassword.Location = new System.Drawing.Point(16, 140);
            this.sqlPassword.Name = "sqlPassword";
            this.sqlPassword.Size = new System.Drawing.Size(174, 21);
            this.sqlPassword.TabIndex = 5;
            this.sqlPassword.Text = "MKh3sHv5XJBUFwhW";
            // 
            // internalSQLPassword
            // 
            this.internalSQLPassword.AutoSize = true;
            this.internalSQLPassword.Location = new System.Drawing.Point(14, 119);
            this.internalSQLPassword.Name = "internalSQLPassword";
            this.internalSQLPassword.Size = new System.Drawing.Size(134, 15);
            this.internalSQLPassword.TabIndex = 4;
            this.internalSQLPassword.Text = "SQL Storage Password";
            // 
            // heartbeatValue
            // 
            this.heartbeatValue.AutoSize = true;
            this.heartbeatValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.heartbeatValue.Location = new System.Drawing.Point(13, 32);
            this.heartbeatValue.Name = "heartbeatValue";
            this.heartbeatValue.Size = new System.Drawing.Size(108, 15);
            this.heartbeatValue.TabIndex = 3;
            this.heartbeatValue.Text = "Heartbeat value";
            // 
            // heartbeat
            // 
            this.heartbeat.Location = new System.Drawing.Point(17, 91);
            this.heartbeat.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.heartbeat.Name = "heartbeat";
            this.heartbeat.Size = new System.Drawing.Size(88, 21);
            this.heartbeat.TabIndex = 2;
            this.heartbeat.Value = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            // 
            // cryptoOptions
            // 
            this.cryptoOptions.Controls.Add(this.agentPostfixBox);
            this.cryptoOptions.Controls.Add(this.postfixAgent);
            this.cryptoOptions.Controls.Add(this.registryKeyBox);
            this.cryptoOptions.Controls.Add(this.registryKey);
            this.cryptoOptions.Controls.Add(this.serverPWD);
            this.cryptoOptions.Controls.Add(this.serverPassword);
            this.cryptoOptions.Controls.Add(this.aesivCrypto);
            this.cryptoOptions.Controls.Add(this.aesIv);
            this.cryptoOptions.Controls.Add(this.aeskeyCrypto);
            this.cryptoOptions.Controls.Add(this.aesKey);
            this.cryptoOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cryptoOptions.Location = new System.Drawing.Point(487, 275);
            this.cryptoOptions.Name = "cryptoOptions";
            this.cryptoOptions.Size = new System.Drawing.Size(210, 277);
            this.cryptoOptions.TabIndex = 11;
            this.cryptoOptions.TabStop = false;
            this.cryptoOptions.Text = "Cryptography";
            // 
            // agentPostfixBox
            // 
            this.agentPostfixBox.Location = new System.Drawing.Point(22, 236);
            this.agentPostfixBox.Name = "agentPostfixBox";
            this.agentPostfixBox.Size = new System.Drawing.Size(171, 21);
            this.agentPostfixBox.TabIndex = 9;
            this.agentPostfixBox.Text = "_agt";
            // 
            // postfixAgent
            // 
            this.postfixAgent.AutoSize = true;
            this.postfixAgent.Location = new System.Drawing.Point(19, 216);
            this.postfixAgent.Name = "postfixAgent";
            this.postfixAgent.Size = new System.Drawing.Size(76, 15);
            this.postfixAgent.TabIndex = 8;
            this.postfixAgent.Text = "Agent postfix";
            // 
            // registryKeyBox
            // 
            this.registryKeyBox.Location = new System.Drawing.Point(22, 190);
            this.registryKeyBox.Name = "registryKeyBox";
            this.registryKeyBox.Size = new System.Drawing.Size(170, 21);
            this.registryKeyBox.TabIndex = 7;
            this.registryKeyBox.Text = "TFE_64bit";
            // 
            // registryKey
            // 
            this.registryKey.AutoSize = true;
            this.registryKey.Location = new System.Drawing.Point(20, 171);
            this.registryKey.Name = "registryKey";
            this.registryKey.Size = new System.Drawing.Size(102, 15);
            this.registryKey.TabIndex = 6;
            this.registryKey.Text = "Boot Registry Key";
            // 
            // serverPWD
            // 
            this.serverPWD.Location = new System.Drawing.Point(22, 145);
            this.serverPWD.Name = "serverPWD";
            this.serverPWD.Size = new System.Drawing.Size(170, 21);
            this.serverPWD.TabIndex = 5;
            this.serverPWD.Text = "KGBz77";
            // 
            // serverPassword
            // 
            this.serverPassword.AutoSize = true;
            this.serverPassword.Location = new System.Drawing.Point(19, 126);
            this.serverPassword.Name = "serverPassword";
            this.serverPassword.Size = new System.Drawing.Size(99, 15);
            this.serverPassword.TabIndex = 4;
            this.serverPassword.Text = "Server Password";
            // 
            // aesivCrypto
            // 
            this.aesivCrypto.Location = new System.Drawing.Point(22, 99);
            this.aesivCrypto.MaxLength = 16;
            this.aesivCrypto.Name = "aesivCrypto";
            this.aesivCrypto.Size = new System.Drawing.Size(171, 21);
            this.aesivCrypto.TabIndex = 3;
            this.aesivCrypto.Text = "0uBu8ycVugDIJz60";
            // 
            // aesIv
            // 
            this.aesIv.AutoSize = true;
            this.aesIv.Location = new System.Drawing.Point(19, 78);
            this.aesIv.Name = "aesIv";
            this.aesIv.Size = new System.Drawing.Size(170, 15);
            this.aesIv.TabIndex = 2;
            this.aesIv.Text = "AES 16Bit IV / Data Exchange ";
            // 
            // aeskeyCrypto
            // 
            this.aeskeyCrypto.Location = new System.Drawing.Point(22, 50);
            this.aeskeyCrypto.MaxLength = 16;
            this.aeskeyCrypto.Name = "aeskeyCrypto";
            this.aeskeyCrypto.Size = new System.Drawing.Size(171, 21);
            this.aeskeyCrypto.TabIndex = 1;
            this.aeskeyCrypto.Text = "0uBu8ycVugDIJz60";
            // 
            // aesKey
            // 
            this.aesKey.AutoSize = true;
            this.aesKey.Location = new System.Drawing.Point(19, 29);
            this.aesKey.Name = "aesKey";
            this.aesKey.Size = new System.Drawing.Size(177, 15);
            this.aesKey.TabIndex = 0;
            this.aesKey.Text = "AES 16Bit Key / Data Exchange";
            // 
            // TFETitle
            // 
            this.TFETitle.AutoSize = true;
            this.TFETitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TFETitle.Location = new System.Drawing.Point(104, 15);
            this.TFETitle.Name = "TFETitle";
            this.TFETitle.Size = new System.Drawing.Size(264, 31);
            this.TFETitle.TabIndex = 12;
            this.TFETitle.Text = "The Fraud Explorer";
            // 
            // UBA
            // 
            this.UBA.AutoSize = true;
            this.UBA.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UBA.Location = new System.Drawing.Point(106, 50);
            this.UBA.Name = "UBA";
            this.UBA.Size = new System.Drawing.Size(447, 24);
            this.UBA.TabIndex = 13;
            this.UBA.Text = "User Behavior Analytics and Operational Intelligence";
            // 
            // horizontalLine
            // 
            this.horizontalLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.horizontalLine.Location = new System.Drawing.Point(0, 96);
            this.horizontalLine.Name = "horizontalLine";
            this.horizontalLine.Size = new System.Drawing.Size(721, 2);
            this.horizontalLine.TabIndex = 14;
            // 
            // horizontalLineMiddle
            // 
            this.horizontalLineMiddle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.horizontalLineMiddle.Location = new System.Drawing.Point(0, 246);
            this.horizontalLineMiddle.Name = "horizontalLineMiddle";
            this.horizontalLineMiddle.Size = new System.Drawing.Size(721, 2);
            this.horizontalLineMiddle.TabIndex = 15;
            // 
            // mainServerConfiguration
            // 
            this.mainServerConfiguration.Controls.Add(this.analyticsServer_Label);
            this.mainServerConfiguration.Controls.Add(this.mainServer_Label);
            this.mainServerConfiguration.Controls.Add(this.httpMainServer_Label);
            this.mainServerConfiguration.Controls.Add(this.analyticsServerAddress);
            this.mainServerConfiguration.Controls.Add(this.mainServerAddress);
            this.mainServerConfiguration.Location = new System.Drawing.Point(21, 116);
            this.mainServerConfiguration.Name = "mainServerConfiguration";
            this.mainServerConfiguration.Size = new System.Drawing.Size(676, 113);
            this.mainServerConfiguration.TabIndex = 16;
            this.mainServerConfiguration.TabStop = false;
            this.mainServerConfiguration.Text = "Main Server Configuation";
            // 
            // horizontalLineBottom
            // 
            this.horizontalLineBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.horizontalLineBottom.Location = new System.Drawing.Point(0, 576);
            this.horizontalLineBottom.Name = "horizontalLineBottom";
            this.horizontalLineBottom.Size = new System.Drawing.Size(721, 2);
            this.horizontalLineBottom.TabIndex = 17;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(478, 593);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(103, 32);
            this.exitButton.TabIndex = 18;
            this.exitButton.Text = "Cancel";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // main_Configurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 640);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.horizontalLineBottom);
            this.Controls.Add(this.mainServerConfiguration);
            this.Controls.Add(this.horizontalLineMiddle);
            this.Controls.Add(this.makeButton);
            this.Controls.Add(this.horizontalLine);
            this.Controls.Add(this.UBA);
            this.Controls.Add(this.TFETitle);
            this.Controls.Add(this.cryptoOptions);
            this.Controls.Add(this.generalOptions);
            this.Controls.Add(this.analyticsOptions);
            this.Controls.Add(this.NFLogo);
            this.Name = "main_Configurator";
            this.Text = "The Fraud Explorer Configurator";
            ((System.ComponentModel.ISupportInitialize)(this.NFLogo)).EndInit();
            this.analyticsOptions.ResumeLayout(false);
            this.analyticsOptions.PerformLayout();
            this.groupPorts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EMailsPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DevicesPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrowsingPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputTextPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApplicationsPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintersPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetworkPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilesystemPort)).EndInit();
            this.generalOptions.ResumeLayout(false);
            this.generalOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heartbeat)).EndInit();
            this.cryptoOptions.ResumeLayout(false);
            this.cryptoOptions.PerformLayout();
            this.mainServerConfiguration.ResumeLayout(false);
            this.mainServerConfiguration.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// <summary>
        /// Window Components
        /// </summary>

        #region Window Components

        private System.Windows.Forms.TextBox mainServerAddress;
        private System.Windows.Forms.TextBox analyticsServerAddress;
        private System.Windows.Forms.Button makeButton;
        private System.Windows.Forms.Label httpMainServer_Label;
        private System.Windows.Forms.Label mainServer_Label;
        private System.Windows.Forms.Label analyticsServer_Label;
        private System.Windows.Forms.PictureBox NFLogo;
        private System.Windows.Forms.CheckBox enableFilesystemAnalytics;
        private System.Windows.Forms.GroupBox analyticsOptions;
        private System.Windows.Forms.CheckBox enableBrowsingAnalytics;
        private System.Windows.Forms.CheckBox enableApplicationAnalytics;
        private System.Windows.Forms.CheckBox enableInputTextAnalytics;
        private System.Windows.Forms.CheckBox enableNetworkAnalytics;
        private System.Windows.Forms.GroupBox generalOptions;
        private System.Windows.Forms.Label heartbeatValue;
        private System.Windows.Forms.NumericUpDown heartbeat;
        private System.Windows.Forms.TextBox sqlPassword;
        private System.Windows.Forms.Label internalSQLPassword;
        private System.Windows.Forms.GroupBox cryptoOptions;
        private System.Windows.Forms.TextBox aeskeyCrypto;
        private System.Windows.Forms.Label aesKey;
        private System.Windows.Forms.TextBox aesivCrypto;
        private System.Windows.Forms.Label aesIv;
        private System.Windows.Forms.Label serverPassword;
        private System.Windows.Forms.TextBox serverPWD;
        private System.Windows.Forms.TextBox finalExecutable;
        private System.Windows.Forms.Label finalExecutableName;
        private System.Windows.Forms.CheckBox enablePrinterAnalytics;
        private System.Windows.Forms.CheckBox enableDevicesAnalytics;
        private System.Windows.Forms.Label TFETitle;
        private System.Windows.Forms.Label UBA;
        private System.Windows.Forms.Label horizontalLine;
        private System.Windows.Forms.Label horizontalLineMiddle;
        private System.Windows.Forms.GroupBox mainServerConfiguration;
        private System.Windows.Forms.Label horizontalLineBottom;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label registryKey;
        private System.Windows.Forms.TextBox registryKeyBox;
        private System.Windows.Forms.Label heartBeatDescription;
        private System.Windows.Forms.GroupBox groupPorts;
        private System.Windows.Forms.NumericUpDown FilesystemPort;
        private System.Windows.Forms.NumericUpDown NetworkPort;
        private System.Windows.Forms.NumericUpDown PrintersPort;
        private System.Windows.Forms.NumericUpDown ApplicationsPort;
        private System.Windows.Forms.NumericUpDown DevicesPort;
        private System.Windows.Forms.NumericUpDown BrowsingPort;
        private System.Windows.Forms.NumericUpDown InputTextPort;
        private System.Windows.Forms.CheckBox enableEMailAnalytics;
        private System.Windows.Forms.NumericUpDown EMailsPort;
        private System.Windows.Forms.TextBox harvesterVersion;
        private System.Windows.Forms.Label harvesterText;
        private System.Windows.Forms.TextBox agentPostfixBox;
        private System.Windows.Forms.Label postfixAgent;
        private System.Windows.Forms.Label milliseconds;

        #endregion
    }
}

