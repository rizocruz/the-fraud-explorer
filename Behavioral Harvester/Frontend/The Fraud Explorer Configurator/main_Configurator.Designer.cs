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
            this.groupPorts = new System.Windows.Forms.GroupBox();
            this.InputTextPort = new System.Windows.Forms.NumericUpDown();
            this.enableInputTextAnalytics = new System.Windows.Forms.CheckBox();
            this.generalOptions = new System.Windows.Forms.GroupBox();
            this.dataSource = new System.Windows.Forms.Label();
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
            this.registryGroup = new System.Windows.Forms.GroupBox();
            this.specifyRegistryBoot = new System.Windows.Forms.Label();
            this.registryKeyBox = new System.Windows.Forms.TextBox();
            this.agentPostfixGroup = new System.Windows.Forms.GroupBox();
            this.agentPostfixBox = new System.Windows.Forms.TextBox();
            this.specifyPostfix = new System.Windows.Forms.Label();
            this.setServerPassword = new System.Windows.Forms.Label();
            this.verticalLineD = new System.Windows.Forms.Label();
            this.serverPWD = new System.Windows.Forms.TextBox();
            this.serverPassword = new System.Windows.Forms.Label();
            this.aesivCrypto = new System.Windows.Forms.TextBox();
            this.aesIv = new System.Windows.Forms.Label();
            this.aeskeyCrypto = new System.Windows.Forms.TextBox();
            this.aesKey = new System.Windows.Forms.Label();
            this.TFETitle = new System.Windows.Forms.Label();
            this.FTA = new System.Windows.Forms.Label();
            this.horizontalLine = new System.Windows.Forms.Label();
            this.horizontalLineMiddle = new System.Windows.Forms.Label();
            this.mainServerConfiguration = new System.Windows.Forms.GroupBox();
            this.horizontalLineBottom = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.verticalLineA = new System.Windows.Forms.Label();
            this.verticalLineB = new System.Windows.Forms.Label();
            this.verticalLineC = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NFLogo)).BeginInit();
            this.groupPorts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputTextPort)).BeginInit();
            this.generalOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heartbeat)).BeginInit();
            this.cryptoOptions.SuspendLayout();
            this.registryGroup.SuspendLayout();
            this.agentPostfixGroup.SuspendLayout();
            this.mainServerConfiguration.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainServerAddress
            // 
            this.mainServerAddress.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainServerAddress.Location = new System.Drawing.Point(202, 37);
            this.mainServerAddress.MaxLength = 60;
            this.mainServerAddress.Name = "mainServerAddress";
            this.mainServerAddress.Size = new System.Drawing.Size(456, 22);
            this.mainServerAddress.TabIndex = 0;
            this.mainServerAddress.Text = "tfe-input.mydomain.com/update.xml";
            // 
            // analyticsServerAddress
            // 
            this.analyticsServerAddress.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analyticsServerAddress.Location = new System.Drawing.Point(202, 68);
            this.analyticsServerAddress.MaxLength = 20;
            this.analyticsServerAddress.Name = "analyticsServerAddress";
            this.analyticsServerAddress.Size = new System.Drawing.Size(456, 22);
            this.analyticsServerAddress.TabIndex = 1;
            this.analyticsServerAddress.Text = "192.168.7.194";
            // 
            // makeButton
            // 
            this.makeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makeButton.Location = new System.Drawing.Point(594, 638);
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
            this.mainServer_Label.Size = new System.Drawing.Size(190, 15);
            this.mainServer_Label.TabIndex = 5;
            this.mainServer_Label.Text = "Main server address (Dashboard)";
            // 
            // analyticsServer_Label
            // 
            this.analyticsServer_Label.AutoSize = true;
            this.analyticsServer_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analyticsServer_Label.Location = new System.Drawing.Point(6, 71);
            this.analyticsServer_Label.Name = "analyticsServer_Label";
            this.analyticsServer_Label.Size = new System.Drawing.Size(184, 15);
            this.analyticsServer_Label.TabIndex = 6;
            this.analyticsServer_Label.Text = "Elastic storage server IP address";
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
            // groupPorts
            // 
            this.groupPorts.Controls.Add(this.InputTextPort);
            this.groupPorts.Location = new System.Drawing.Point(322, 92);
            this.groupPorts.Name = "groupPorts";
            this.groupPorts.Size = new System.Drawing.Size(112, 54);
            this.groupPorts.TabIndex = 15;
            this.groupPorts.TabStop = false;
            this.groupPorts.Text = "UDP Port";
            // 
            // InputTextPort
            // 
            this.InputTextPort.Enabled = false;
            this.InputTextPort.Location = new System.Drawing.Point(20, 21);
            this.InputTextPort.Maximum = new decimal(new int[] {
            65500,
            0,
            0,
            0});
            this.InputTextPort.Name = "InputTextPort";
            this.InputTextPort.Size = new System.Drawing.Size(74, 21);
            this.InputTextPort.TabIndex = 19;
            this.InputTextPort.Value = new decimal(new int[] {
            5965,
            0,
            0,
            0});
            // 
            // enableInputTextAnalytics
            // 
            this.enableInputTextAnalytics.AutoSize = true;
            this.enableInputTextAnalytics.Location = new System.Drawing.Point(237, 114);
            this.enableInputTextAnalytics.Name = "enableInputTextAnalytics";
            this.enableInputTextAnalytics.Size = new System.Drawing.Size(79, 19);
            this.enableInputTextAnalytics.TabIndex = 12;
            this.enableInputTextAnalytics.Text = "Input Text";
            this.enableInputTextAnalytics.UseVisualStyleBackColor = true;
            this.enableInputTextAnalytics.CheckedChanged += new System.EventHandler(this.enableInputTextAnalytics_CheckedChanged);
            // 
            // generalOptions
            // 
            this.generalOptions.Controls.Add(this.dataSource);
            this.generalOptions.Controls.Add(this.groupPorts);
            this.generalOptions.Controls.Add(this.milliseconds);
            this.generalOptions.Controls.Add(this.enableInputTextAnalytics);
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
            this.generalOptions.Location = new System.Drawing.Point(21, 266);
            this.generalOptions.Name = "generalOptions";
            this.generalOptions.Size = new System.Drawing.Size(676, 159);
            this.generalOptions.TabIndex = 10;
            this.generalOptions.TabStop = false;
            this.generalOptions.Text = "General Options";
            // 
            // dataSource
            // 
            this.dataSource.AutoSize = true;
            this.dataSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataSource.Location = new System.Drawing.Point(234, 89);
            this.dataSource.Name = "dataSource";
            this.dataSource.Size = new System.Drawing.Size(84, 15);
            this.dataSource.TabIndex = 16;
            this.dataSource.Text = "Data source";
            // 
            // milliseconds
            // 
            this.milliseconds.AutoSize = true;
            this.milliseconds.Location = new System.Drawing.Point(113, 112);
            this.milliseconds.Name = "milliseconds";
            this.milliseconds.Size = new System.Drawing.Size(76, 15);
            this.milliseconds.TabIndex = 11;
            this.milliseconds.Text = "milliseconds";
            // 
            // harvesterVersion
            // 
            this.harvesterVersion.Location = new System.Drawing.Point(484, 114);
            this.harvesterVersion.MaxLength = 10;
            this.harvesterVersion.Name = "harvesterVersion";
            this.harvesterVersion.Size = new System.Drawing.Size(174, 21);
            this.harvesterVersion.TabIndex = 10;
            this.harvesterVersion.Text = "0.9.7";
            // 
            // harvesterText
            // 
            this.harvesterText.AutoSize = true;
            this.harvesterText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.harvesterText.Location = new System.Drawing.Point(481, 92);
            this.harvesterText.Name = "harvesterText";
            this.harvesterText.Size = new System.Drawing.Size(118, 15);
            this.harvesterText.TabIndex = 9;
            this.harvesterText.Text = "Harvester version";
            // 
            // heartBeatDescription
            // 
            this.heartBeatDescription.Location = new System.Drawing.Point(14, 52);
            this.heartBeatDescription.Name = "heartBeatDescription";
            this.heartBeatDescription.Size = new System.Drawing.Size(190, 38);
            this.heartBeatDescription.TabIndex = 8;
            this.heartBeatDescription.Text = "Please specify the connection interval from agent to server";
            this.heartBeatDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // finalExecutable
            // 
            this.finalExecutable.Location = new System.Drawing.Point(484, 58);
            this.finalExecutable.MaxLength = 15;
            this.finalExecutable.Name = "finalExecutable";
            this.finalExecutable.Size = new System.Drawing.Size(174, 21);
            this.finalExecutable.TabIndex = 7;
            this.finalExecutable.Text = "mswow64svc";
            // 
            // finalExecutableName
            // 
            this.finalExecutableName.AutoSize = true;
            this.finalExecutableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finalExecutableName.Location = new System.Drawing.Point(481, 32);
            this.finalExecutableName.Name = "finalExecutableName";
            this.finalExecutableName.Size = new System.Drawing.Size(156, 15);
            this.finalExecutableName.TabIndex = 6;
            this.finalExecutableName.Text = "Final Executable Name";
            // 
            // sqlPassword
            // 
            this.sqlPassword.Location = new System.Drawing.Point(237, 58);
            this.sqlPassword.MaxLength = 20;
            this.sqlPassword.Name = "sqlPassword";
            this.sqlPassword.Size = new System.Drawing.Size(197, 21);
            this.sqlPassword.TabIndex = 5;
            this.sqlPassword.Text = "MKh3sHv5XJBUFwhW";
            // 
            // internalSQLPassword
            // 
            this.internalSQLPassword.AutoSize = true;
            this.internalSQLPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.internalSQLPassword.Location = new System.Drawing.Point(234, 32);
            this.internalSQLPassword.Name = "internalSQLPassword";
            this.internalSQLPassword.Size = new System.Drawing.Size(154, 15);
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
            this.heartbeat.Location = new System.Drawing.Point(16, 111);
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
            this.cryptoOptions.Controls.Add(this.registryGroup);
            this.cryptoOptions.Controls.Add(this.agentPostfixGroup);
            this.cryptoOptions.Controls.Add(this.setServerPassword);
            this.cryptoOptions.Controls.Add(this.verticalLineD);
            this.cryptoOptions.Controls.Add(this.serverPWD);
            this.cryptoOptions.Controls.Add(this.serverPassword);
            this.cryptoOptions.Controls.Add(this.aesivCrypto);
            this.cryptoOptions.Controls.Add(this.aesIv);
            this.cryptoOptions.Controls.Add(this.aeskeyCrypto);
            this.cryptoOptions.Controls.Add(this.aesKey);
            this.cryptoOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cryptoOptions.Location = new System.Drawing.Point(21, 441);
            this.cryptoOptions.Name = "cryptoOptions";
            this.cryptoOptions.Size = new System.Drawing.Size(676, 159);
            this.cryptoOptions.TabIndex = 11;
            this.cryptoOptions.TabStop = false;
            this.cryptoOptions.Text = "Cryptography";
            // 
            // registryGroup
            // 
            this.registryGroup.Controls.Add(this.specifyRegistryBoot);
            this.registryGroup.Controls.Add(this.registryKeyBox);
            this.registryGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registryGroup.Location = new System.Drawing.Point(341, 14);
            this.registryGroup.Name = "registryGroup";
            this.registryGroup.Size = new System.Drawing.Size(106, 135);
            this.registryGroup.TabIndex = 21;
            this.registryGroup.TabStop = false;
            this.registryGroup.Text = "Registry boot";
            // 
            // specifyRegistryBoot
            // 
            this.specifyRegistryBoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.specifyRegistryBoot.Location = new System.Drawing.Point(7, 29);
            this.specifyRegistryBoot.Name = "specifyRegistryBoot";
            this.specifyRegistryBoot.Size = new System.Drawing.Size(89, 51);
            this.specifyRegistryBoot.TabIndex = 22;
            this.specifyRegistryBoot.Text = "Specify the boot key in the registry";
            this.specifyRegistryBoot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // registryKeyBox
            // 
            this.registryKeyBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registryKeyBox.Location = new System.Drawing.Point(10, 98);
            this.registryKeyBox.MaxLength = 10;
            this.registryKeyBox.Name = "registryKeyBox";
            this.registryKeyBox.Size = new System.Drawing.Size(86, 21);
            this.registryKeyBox.TabIndex = 7;
            this.registryKeyBox.Text = "TFE_64bit";
            // 
            // agentPostfixGroup
            // 
            this.agentPostfixGroup.Controls.Add(this.agentPostfixBox);
            this.agentPostfixGroup.Controls.Add(this.specifyPostfix);
            this.agentPostfixGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agentPostfixGroup.Location = new System.Drawing.Point(225, 14);
            this.agentPostfixGroup.Name = "agentPostfixGroup";
            this.agentPostfixGroup.Size = new System.Drawing.Size(107, 135);
            this.agentPostfixGroup.TabIndex = 20;
            this.agentPostfixGroup.TabStop = false;
            this.agentPostfixGroup.Text = "Agent postfix";
            // 
            // agentPostfixBox
            // 
            this.agentPostfixBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agentPostfixBox.Location = new System.Drawing.Point(10, 98);
            this.agentPostfixBox.MaxLength = 5;
            this.agentPostfixBox.Name = "agentPostfixBox";
            this.agentPostfixBox.Size = new System.Drawing.Size(86, 21);
            this.agentPostfixBox.TabIndex = 9;
            this.agentPostfixBox.Text = "_agt";
            // 
            // specifyPostfix
            // 
            this.specifyPostfix.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.specifyPostfix.Location = new System.Drawing.Point(7, 29);
            this.specifyPostfix.Name = "specifyPostfix";
            this.specifyPostfix.Size = new System.Drawing.Size(99, 51);
            this.specifyPostfix.TabIndex = 17;
            this.specifyPostfix.Text = "Specify the agent pos-text for classification\r\n";
            this.specifyPostfix.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // setServerPassword
            // 
            this.setServerPassword.Location = new System.Drawing.Point(481, 50);
            this.setServerPassword.Name = "setServerPassword";
            this.setServerPassword.Size = new System.Drawing.Size(170, 49);
            this.setServerPassword.TabIndex = 10;
            this.setServerPassword.Text = "This password is used to authenticate each agent to the main server.";
            this.setServerPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // verticalLineD
            // 
            this.verticalLineD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.verticalLineD.Location = new System.Drawing.Point(461, 12);
            this.verticalLineD.Name = "verticalLineD";
            this.verticalLineD.Size = new System.Drawing.Size(2, 140);
            this.verticalLineD.TabIndex = 21;
            // 
            // serverPWD
            // 
            this.serverPWD.Location = new System.Drawing.Point(484, 115);
            this.serverPWD.MaxLength = 15;
            this.serverPWD.Name = "serverPWD";
            this.serverPWD.Size = new System.Drawing.Size(174, 21);
            this.serverPWD.TabIndex = 5;
            this.serverPWD.Text = "KGBz77";
            // 
            // serverPassword
            // 
            this.serverPassword.AutoSize = true;
            this.serverPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverPassword.Location = new System.Drawing.Point(481, 29);
            this.serverPassword.Name = "serverPassword";
            this.serverPassword.Size = new System.Drawing.Size(114, 15);
            this.serverPassword.TabIndex = 4;
            this.serverPassword.Text = "Server Password";
            // 
            // aesivCrypto
            // 
            this.aesivCrypto.Location = new System.Drawing.Point(22, 115);
            this.aesivCrypto.MaxLength = 16;
            this.aesivCrypto.Name = "aesivCrypto";
            this.aesivCrypto.Size = new System.Drawing.Size(171, 21);
            this.aesivCrypto.TabIndex = 3;
            this.aesivCrypto.Text = "0uBu8ycVugDIJz60";
            // 
            // aesIv
            // 
            this.aesIv.AutoSize = true;
            this.aesIv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aesIv.Location = new System.Drawing.Point(19, 91);
            this.aesIv.Name = "aesIv";
            this.aesIv.Size = new System.Drawing.Size(134, 15);
            this.aesIv.TabIndex = 2;
            this.aesIv.Text = "AES 16Bit Int Vector";
            // 
            // aeskeyCrypto
            // 
            this.aeskeyCrypto.Location = new System.Drawing.Point(22, 52);
            this.aeskeyCrypto.MaxLength = 16;
            this.aeskeyCrypto.Name = "aeskeyCrypto";
            this.aeskeyCrypto.Size = new System.Drawing.Size(171, 21);
            this.aeskeyCrypto.TabIndex = 1;
            this.aeskeyCrypto.Text = "0uBu8ycVugDIJz60";
            // 
            // aesKey
            // 
            this.aesKey.AutoSize = true;
            this.aesKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aesKey.Location = new System.Drawing.Point(19, 29);
            this.aesKey.Name = "aesKey";
            this.aesKey.Size = new System.Drawing.Size(97, 15);
            this.aesKey.TabIndex = 0;
            this.aesKey.Text = "AES 16Bit Key";
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
            // FTA
            // 
            this.FTA.AutoSize = true;
            this.FTA.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FTA.Location = new System.Drawing.Point(106, 50);
            this.FTA.Name = "FTA";
            this.FTA.Size = new System.Drawing.Size(332, 24);
            this.FTA.TabIndex = 13;
            this.FTA.Text = "Fraud Triangle Analytics Agent Builder";
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
            this.horizontalLineBottom.Location = new System.Drawing.Point(0, 619);
            this.horizontalLineBottom.Name = "horizontalLineBottom";
            this.horizontalLineBottom.Size = new System.Drawing.Size(721, 2);
            this.horizontalLineBottom.TabIndex = 17;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(478, 638);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(103, 32);
            this.exitButton.TabIndex = 18;
            this.exitButton.Text = "Cancel";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // verticalLineA
            // 
            this.verticalLineA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.verticalLineA.Location = new System.Drawing.Point(230, 279);
            this.verticalLineA.Name = "verticalLineA";
            this.verticalLineA.Size = new System.Drawing.Size(2, 140);
            this.verticalLineA.TabIndex = 19;
            // 
            // verticalLineB
            // 
            this.verticalLineB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.verticalLineB.Location = new System.Drawing.Point(482, 278);
            this.verticalLineB.Name = "verticalLineB";
            this.verticalLineB.Size = new System.Drawing.Size(2, 140);
            this.verticalLineB.TabIndex = 20;
            // 
            // verticalLineC
            // 
            this.verticalLineC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.verticalLineC.Location = new System.Drawing.Point(230, 454);
            this.verticalLineC.Name = "verticalLineC";
            this.verticalLineC.Size = new System.Drawing.Size(2, 140);
            this.verticalLineC.TabIndex = 22;
            // 
            // main_Configurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 683);
            this.Controls.Add(this.verticalLineC);
            this.Controls.Add(this.verticalLineB);
            this.Controls.Add(this.verticalLineA);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.horizontalLineBottom);
            this.Controls.Add(this.mainServerConfiguration);
            this.Controls.Add(this.horizontalLineMiddle);
            this.Controls.Add(this.makeButton);
            this.Controls.Add(this.horizontalLine);
            this.Controls.Add(this.FTA);
            this.Controls.Add(this.TFETitle);
            this.Controls.Add(this.cryptoOptions);
            this.Controls.Add(this.generalOptions);
            this.Controls.Add(this.NFLogo);
            this.Name = "main_Configurator";
            this.Text = "The Fraud Explorer Configurator";
            ((System.ComponentModel.ISupportInitialize)(this.NFLogo)).EndInit();
            this.groupPorts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InputTextPort)).EndInit();
            this.generalOptions.ResumeLayout(false);
            this.generalOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heartbeat)).EndInit();
            this.cryptoOptions.ResumeLayout(false);
            this.cryptoOptions.PerformLayout();
            this.registryGroup.ResumeLayout(false);
            this.registryGroup.PerformLayout();
            this.agentPostfixGroup.ResumeLayout(false);
            this.agentPostfixGroup.PerformLayout();
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
        private System.Windows.Forms.CheckBox enableInputTextAnalytics;
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
        private System.Windows.Forms.Label TFETitle;
        private System.Windows.Forms.Label FTA;
        private System.Windows.Forms.Label horizontalLine;
        private System.Windows.Forms.Label horizontalLineMiddle;
        private System.Windows.Forms.GroupBox mainServerConfiguration;
        private System.Windows.Forms.Label horizontalLineBottom;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TextBox registryKeyBox;
        private System.Windows.Forms.Label heartBeatDescription;
        private System.Windows.Forms.GroupBox groupPorts;
        private System.Windows.Forms.NumericUpDown InputTextPort;
        private System.Windows.Forms.TextBox harvesterVersion;
        private System.Windows.Forms.Label harvesterText;
        private System.Windows.Forms.TextBox agentPostfixBox;
        private System.Windows.Forms.Label milliseconds;
        private System.Windows.Forms.Label verticalLineA;
        private System.Windows.Forms.Label dataSource;
        private System.Windows.Forms.Label verticalLineB;
        private System.Windows.Forms.Label setServerPassword;
        private System.Windows.Forms.Label verticalLineD;
        private System.Windows.Forms.Label verticalLineC;
        private System.Windows.Forms.Label specifyRegistryBoot;
        private System.Windows.Forms.Label specifyPostfix;
        private System.Windows.Forms.GroupBox agentPostfixGroup;
        private System.Windows.Forms.GroupBox registryGroup;

        #endregion
    }
}

