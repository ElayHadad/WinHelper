namespace WinHelper
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.imageButton2 = new ImageButton.ImageButton();
            this.CloseBtn = new ImageButton.ImageButton();
            this.icon = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.registry = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.info = new System.Windows.Forms.TabPage();
            this.txtBIOS = new System.Windows.Forms.Label();
            this.txtMB = new System.Windows.Forms.Label();
            this.txtGPU = new System.Windows.Forms.Label();
            this.txtBit = new System.Windows.Forms.Label();
            this.txtOS = new System.Windows.Forms.Label();
            this.txtCPU = new System.Windows.Forms.Label();
            this.programs = new System.Windows.Forms.TabPage();
            this.AutoUninstallCMD = new ImageButton.ImageButton();
            this.importSettings = new System.Windows.Forms.Button();
            this.listInstalled = new System.Windows.Forms.DataGridView();
            this.DisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstimatedSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegistryPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UninstallString = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.infoExport = new System.Windows.Forms.Button();
            this.installedCount = new System.Windows.Forms.Label();
            this.registryViewer = new System.Windows.Forms.TabPage();
            this.registryTreeView = new System.Windows.Forms.TreeView();
            this.devices = new System.Windows.Forms.TabPage();
            this.ConnectedDrives = new System.Windows.Forms.Label();
            this.ConnDrives = new System.Windows.Forms.ListView();
            this.Drive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FreeSpace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalSpace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DriveType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalConnectedUSB = new System.Windows.Forms.Label();
            this.ConnUSB = new System.Windows.Forms.ListView();
            this.DeviceID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PNPDeviceID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tweaks = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.bootTweaks = new System.Windows.Forms.TabPage();
            this.performanceTweaks = new System.Windows.Forms.TabPage();
            this.privacyTweaks = new System.Windows.Forms.TabPage();
            this.miscellaneousTweaks = new System.Windows.Forms.TabPage();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.registry.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.info.SuspendLayout();
            this.programs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AutoUninstallCMD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listInstalled)).BeginInit();
            this.registryViewer.SuspendLayout();
            this.devices.SuspendLayout();
            this.tweaks.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.imageButton2);
            this.panel1.Controls.Add(this.CloseBtn);
            this.panel1.Controls.Add(this.icon);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 49);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
            // 
            // imageButton2
            // 
            this.imageButton2.Image = ((System.Drawing.Image)(resources.GetObject("imageButton2.Image")));
            this.imageButton2.ImageHover = ((System.Drawing.Image)(resources.GetObject("imageButton2.ImageHover")));
            this.imageButton2.ImageNormal = ((System.Drawing.Image)(resources.GetObject("imageButton2.ImageNormal")));
            this.imageButton2.Location = new System.Drawing.Point(731, 3);
            this.imageButton2.Name = "imageButton2";
            this.imageButton2.Size = new System.Drawing.Size(30, 30);
            this.imageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageButton2.TabIndex = 12;
            this.imageButton2.TabStop = false;
            this.imageButton2.Click += new System.EventHandler(this.MinBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Image = ((System.Drawing.Image)(resources.GetObject("CloseBtn.Image")));
            this.CloseBtn.ImageHover = ((System.Drawing.Image)(resources.GetObject("CloseBtn.ImageHover")));
            this.CloseBtn.ImageNormal = ((System.Drawing.Image)(resources.GetObject("CloseBtn.ImageNormal")));
            this.CloseBtn.Location = new System.Drawing.Point(767, 3);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(30, 30);
            this.CloseBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CloseBtn.TabIndex = 10;
            this.CloseBtn.TabStop = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // icon
            // 
            this.icon.Image = ((System.Drawing.Image)(resources.GetObject("icon.Image")));
            this.icon.Location = new System.Drawing.Point(3, -1);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(50, 50);
            this.icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.icon.TabIndex = 13;
            this.icon.TabStop = false;
            this.icon.Click += new System.EventHandler(this.icon_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.registry);
            this.tabControl1.Controls.Add(this.tweaks);
            this.tabControl1.Location = new System.Drawing.Point(0, 48);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 401);
            this.tabControl1.TabIndex = 1;
            // 
            // registry
            // 
            this.registry.BackColor = System.Drawing.Color.Transparent;
            this.registry.Controls.Add(this.tabControl2);
            this.registry.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registry.Location = new System.Drawing.Point(4, 22);
            this.registry.Name = "registry";
            this.registry.Padding = new System.Windows.Forms.Padding(3);
            this.registry.Size = new System.Drawing.Size(792, 375);
            this.registry.TabIndex = 0;
            this.registry.Text = "Registry";
            // 
            // tabControl2
            // 
            this.tabControl2.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl2.Controls.Add(this.info);
            this.tabControl2.Controls.Add(this.programs);
            this.tabControl2.Controls.Add(this.registryViewer);
            this.tabControl2.Controls.Add(this.devices);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(786, 369);
            this.tabControl2.TabIndex = 0;
            // 
            // info
            // 
            this.info.Controls.Add(this.txtBIOS);
            this.info.Controls.Add(this.txtMB);
            this.info.Controls.Add(this.txtGPU);
            this.info.Controls.Add(this.txtBit);
            this.info.Controls.Add(this.txtOS);
            this.info.Controls.Add(this.txtCPU);
            this.info.Location = new System.Drawing.Point(4, 4);
            this.info.Margin = new System.Windows.Forms.Padding(2);
            this.info.Name = "info";
            this.info.Padding = new System.Windows.Forms.Padding(2);
            this.info.Size = new System.Drawing.Size(778, 337);
            this.info.TabIndex = 0;
            this.info.Text = "PC info";
            this.info.UseVisualStyleBackColor = true;
            // 
            // txtBIOS
            // 
            this.txtBIOS.AutoSize = true;
            this.txtBIOS.Location = new System.Drawing.Point(14, 245);
            this.txtBIOS.Name = "txtBIOS";
            this.txtBIOS.Size = new System.Drawing.Size(34, 19);
            this.txtBIOS.TabIndex = 6;
            this.txtBIOS.Text = "bios";
            // 
            // txtMB
            // 
            this.txtMB.AutoSize = true;
            this.txtMB.Location = new System.Drawing.Point(14, 190);
            this.txtMB.Name = "txtMB";
            this.txtMB.Size = new System.Drawing.Size(29, 19);
            this.txtMB.TabIndex = 5;
            this.txtMB.Text = "mb";
            // 
            // txtGPU
            // 
            this.txtGPU.AutoSize = true;
            this.txtGPU.Location = new System.Drawing.Point(14, 155);
            this.txtGPU.Name = "txtGPU";
            this.txtGPU.Size = new System.Drawing.Size(33, 19);
            this.txtGPU.TabIndex = 4;
            this.txtGPU.Text = "gpu";
            // 
            // txtBit
            // 
            this.txtBit.AutoSize = true;
            this.txtBit.BackColor = System.Drawing.Color.Transparent;
            this.txtBit.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBit.ForeColor = System.Drawing.Color.Black;
            this.txtBit.Location = new System.Drawing.Point(14, 50);
            this.txtBit.Name = "txtBit";
            this.txtBit.Size = new System.Drawing.Size(25, 19);
            this.txtBit.TabIndex = 3;
            this.txtBit.Text = "bit";
            // 
            // txtOS
            // 
            this.txtOS.AutoSize = true;
            this.txtOS.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOS.ForeColor = System.Drawing.Color.Black;
            this.txtOS.Location = new System.Drawing.Point(14, 15);
            this.txtOS.Name = "txtOS";
            this.txtOS.Size = new System.Drawing.Size(23, 19);
            this.txtOS.TabIndex = 2;
            this.txtOS.Text = "os";
            // 
            // txtCPU
            // 
            this.txtCPU.AutoSize = true;
            this.txtCPU.Location = new System.Drawing.Point(14, 85);
            this.txtCPU.Name = "txtCPU";
            this.txtCPU.Size = new System.Drawing.Size(32, 19);
            this.txtCPU.TabIndex = 0;
            this.txtCPU.Text = "cpu";
            // 
            // programs
            // 
            this.programs.BackColor = System.Drawing.Color.Black;
            this.programs.Controls.Add(this.AutoUninstallCMD);
            this.programs.Controls.Add(this.importSettings);
            this.programs.Controls.Add(this.listInstalled);
            this.programs.Controls.Add(this.infoExport);
            this.programs.Controls.Add(this.installedCount);
            this.programs.Location = new System.Drawing.Point(4, 4);
            this.programs.Name = "programs";
            this.programs.Padding = new System.Windows.Forms.Padding(3);
            this.programs.Size = new System.Drawing.Size(778, 337);
            this.programs.TabIndex = 1;
            this.programs.Text = "Installed programs";
            // 
            // AutoUninstallCMD
            // 
            this.AutoUninstallCMD.Image = ((System.Drawing.Image)(resources.GetObject("AutoUninstallCMD.Image")));
            this.AutoUninstallCMD.ImageHover = ((System.Drawing.Image)(resources.GetObject("AutoUninstallCMD.ImageHover")));
            this.AutoUninstallCMD.ImageNormal = ((System.Drawing.Image)(resources.GetObject("AutoUninstallCMD.ImageNormal")));
            this.AutoUninstallCMD.Location = new System.Drawing.Point(512, 1);
            this.AutoUninstallCMD.Name = "AutoUninstallCMD";
            this.AutoUninstallCMD.Size = new System.Drawing.Size(36, 30);
            this.AutoUninstallCMD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AutoUninstallCMD.TabIndex = 13;
            this.AutoUninstallCMD.TabStop = false;
            this.AutoUninstallCMD.Click += new System.EventHandler(this.AutoUninstallCMD_Click);
            // 
            // importSettings
            // 
            this.importSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(161)))), ((int)(((byte)(105)))));
            this.importSettings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.importSettings.ForeColor = System.Drawing.SystemColors.Control;
            this.importSettings.Location = new System.Drawing.Point(554, 2);
            this.importSettings.Name = "importSettings";
            this.importSettings.Size = new System.Drawing.Size(111, 26);
            this.importSettings.TabIndex = 6;
            this.importSettings.Text = "Import settings";
            this.importSettings.UseVisualStyleBackColor = false;
            this.importSettings.Click += new System.EventHandler(this.importSettings_Click);
            // 
            // listInstalled
            // 
            this.listInstalled.AllowUserToAddRows = false;
            this.listInstalled.AllowUserToDeleteRows = false;
            this.listInstalled.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listInstalled.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.listInstalled.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.listInstalled.BackgroundColor = System.Drawing.Color.Black;
            this.listInstalled.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listInstalled.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DisplayName,
            this.EstimatedSize,
            this.RegistryPath,
            this.UninstallString});
            this.listInstalled.Location = new System.Drawing.Point(0, 31);
            this.listInstalled.Name = "listInstalled";
            this.listInstalled.RowHeadersWidth = 51;
            this.listInstalled.Size = new System.Drawing.Size(776, 306);
            this.listInstalled.TabIndex = 3;
            this.listInstalled.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listInstalled_CellContentClick);
            this.listInstalled.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.listInstalled_CellEndEdit);
            this.listInstalled.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listInstalled_MouseClick);
            // 
            // DisplayName
            // 
            this.DisplayName.HeaderText = "App name";
            this.DisplayName.MinimumWidth = 6;
            this.DisplayName.Name = "DisplayName";
            this.DisplayName.Width = 97;
            // 
            // EstimatedSize
            // 
            this.EstimatedSize.HeaderText = "Estimated size";
            this.EstimatedSize.MinimumWidth = 6;
            this.EstimatedSize.Name = "EstimatedSize";
            this.EstimatedSize.ReadOnly = true;
            this.EstimatedSize.Width = 120;
            // 
            // RegistryPath
            // 
            this.RegistryPath.HeaderText = "Registry path";
            this.RegistryPath.MinimumWidth = 6;
            this.RegistryPath.Name = "RegistryPath";
            this.RegistryPath.ReadOnly = true;
            this.RegistryPath.Width = 115;
            // 
            // UninstallString
            // 
            this.UninstallString.HeaderText = "Uninstall option";
            this.UninstallString.MinimumWidth = 6;
            this.UninstallString.Name = "UninstallString";
            this.UninstallString.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UninstallString.Width = 112;
            // 
            // infoExport
            // 
            this.infoExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(161)))), ((int)(((byte)(105)))));
            this.infoExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.infoExport.ForeColor = System.Drawing.SystemColors.Control;
            this.infoExport.Location = new System.Drawing.Point(671, 2);
            this.infoExport.Name = "infoExport";
            this.infoExport.Size = new System.Drawing.Size(104, 26);
            this.infoExport.TabIndex = 5;
            this.infoExport.Text = "Export all info";
            this.infoExport.UseVisualStyleBackColor = false;
            this.infoExport.Click += new System.EventHandler(this.settingsExport_Click);
            // 
            // installedCount
            // 
            this.installedCount.AutoSize = true;
            this.installedCount.ForeColor = System.Drawing.Color.White;
            this.installedCount.Location = new System.Drawing.Point(2, 4);
            this.installedCount.Name = "installedCount";
            this.installedCount.Size = new System.Drawing.Size(208, 19);
            this.installedCount.TabIndex = 1;
            this.installedCount.Text = "Number of applications installed";
            // 
            // registryViewer
            // 
            this.registryViewer.Controls.Add(this.registryTreeView);
            this.registryViewer.Location = new System.Drawing.Point(4, 4);
            this.registryViewer.Name = "registryViewer";
            this.registryViewer.Size = new System.Drawing.Size(778, 337);
            this.registryViewer.TabIndex = 2;
            this.registryViewer.Text = "Registry Viewer";
            this.registryViewer.UseVisualStyleBackColor = true;
            // 
            // registryTreeView
            // 
            this.registryTreeView.Location = new System.Drawing.Point(-3, -3);
            this.registryTreeView.Name = "registryTreeView";
            this.registryTreeView.Size = new System.Drawing.Size(782, 341);
            this.registryTreeView.TabIndex = 0;
            // 
            // devices
            // 
            this.devices.Controls.Add(this.ConnectedDrives);
            this.devices.Controls.Add(this.ConnDrives);
            this.devices.Controls.Add(this.TotalConnectedUSB);
            this.devices.Controls.Add(this.ConnUSB);
            this.devices.Location = new System.Drawing.Point(4, 4);
            this.devices.Name = "devices";
            this.devices.Size = new System.Drawing.Size(778, 337);
            this.devices.TabIndex = 3;
            this.devices.Text = "Devices";
            this.devices.UseVisualStyleBackColor = true;
            // 
            // ConnectedDrives
            // 
            this.ConnectedDrives.AutoSize = true;
            this.ConnectedDrives.Location = new System.Drawing.Point(-1, 181);
            this.ConnectedDrives.Name = "ConnectedDrives";
            this.ConnectedDrives.Size = new System.Drawing.Size(165, 19);
            this.ConnectedDrives.TabIndex = 3;
            this.ConnectedDrives.Text = "Total of connected drives";
            // 
            // ConnDrives
            // 
            this.ConnDrives.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Drive,
            this.FreeSpace,
            this.TotalSpace,
            this.FileType,
            this.DriveType});
            this.ConnDrives.HideSelection = false;
            this.ConnDrives.Location = new System.Drawing.Point(-4, 201);
            this.ConnDrives.Name = "ConnDrives";
            this.ConnDrives.Size = new System.Drawing.Size(786, 136);
            this.ConnDrives.TabIndex = 2;
            this.ConnDrives.UseCompatibleStateImageBehavior = false;
            this.ConnDrives.View = System.Windows.Forms.View.Details;
            // 
            // Drive
            // 
            this.Drive.Text = "Drive";
            this.Drive.Width = 100;
            // 
            // FreeSpace
            // 
            this.FreeSpace.Text = "Free space";
            this.FreeSpace.Width = 100;
            // 
            // TotalSpace
            // 
            this.TotalSpace.Text = "Total space";
            this.TotalSpace.Width = 100;
            // 
            // FileType
            // 
            this.FileType.Text = "Format Type";
            this.FileType.Width = 100;
            // 
            // DriveType
            // 
            this.DriveType.Text = "Drive type";
            this.DriveType.Width = 100;
            // 
            // TotalConnectedUSB
            // 
            this.TotalConnectedUSB.AutoSize = true;
            this.TotalConnectedUSB.Location = new System.Drawing.Point(-1, 0);
            this.TotalConnectedUSB.Name = "TotalConnectedUSB";
            this.TotalConnectedUSB.Size = new System.Drawing.Size(204, 19);
            this.TotalConnectedUSB.TabIndex = 1;
            this.TotalConnectedUSB.Text = "Total of connected USB devices";
            // 
            // ConnUSB
            // 
            this.ConnUSB.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DeviceID,
            this.PNPDeviceID,
            this.Description});
            this.ConnUSB.HideSelection = false;
            this.ConnUSB.Location = new System.Drawing.Point(-4, 20);
            this.ConnUSB.Name = "ConnUSB";
            this.ConnUSB.Size = new System.Drawing.Size(786, 134);
            this.ConnUSB.TabIndex = 0;
            this.ConnUSB.UseCompatibleStateImageBehavior = false;
            this.ConnUSB.View = System.Windows.Forms.View.Details;
            // 
            // DeviceID
            // 
            this.DeviceID.Text = "Device ID";
            this.DeviceID.Width = 290;
            // 
            // PNPDeviceID
            // 
            this.PNPDeviceID.Text = "PNP Device ID";
            this.PNPDeviceID.Width = 290;
            // 
            // Description
            // 
            this.Description.Text = "Description";
            this.Description.Width = 200;
            // 
            // tweaks
            // 
            this.tweaks.Controls.Add(this.tabControl3);
            this.tweaks.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tweaks.Location = new System.Drawing.Point(4, 22);
            this.tweaks.Name = "tweaks";
            this.tweaks.Padding = new System.Windows.Forms.Padding(3);
            this.tweaks.Size = new System.Drawing.Size(792, 375);
            this.tweaks.TabIndex = 1;
            this.tweaks.Text = "Tweaks";
            this.tweaks.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl3.Controls.Add(this.bootTweaks);
            this.tabControl3.Controls.Add(this.performanceTweaks);
            this.tabControl3.Controls.Add(this.privacyTweaks);
            this.tabControl3.Controls.Add(this.miscellaneousTweaks);
            this.tabControl3.Location = new System.Drawing.Point(-4, 0);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(800, 379);
            this.tabControl3.TabIndex = 0;
            // 
            // bootTweaks
            // 
            this.bootTweaks.Location = new System.Drawing.Point(4, 4);
            this.bootTweaks.Name = "bootTweaks";
            this.bootTweaks.Padding = new System.Windows.Forms.Padding(3);
            this.bootTweaks.Size = new System.Drawing.Size(792, 347);
            this.bootTweaks.TabIndex = 0;
            this.bootTweaks.Text = "Boot tweaks";
            this.bootTweaks.UseVisualStyleBackColor = true;
            // 
            // performanceTweaks
            // 
            this.performanceTweaks.Location = new System.Drawing.Point(4, 4);
            this.performanceTweaks.Name = "performanceTweaks";
            this.performanceTweaks.Padding = new System.Windows.Forms.Padding(3);
            this.performanceTweaks.Size = new System.Drawing.Size(792, 347);
            this.performanceTweaks.TabIndex = 1;
            this.performanceTweaks.Text = "Performance tweaks";
            this.performanceTweaks.UseVisualStyleBackColor = true;
            // 
            // privacyTweaks
            // 
            this.privacyTweaks.Location = new System.Drawing.Point(4, 4);
            this.privacyTweaks.Name = "privacyTweaks";
            this.privacyTweaks.Size = new System.Drawing.Size(792, 347);
            this.privacyTweaks.TabIndex = 3;
            this.privacyTweaks.Text = "Privacy tweaks";
            this.privacyTweaks.UseVisualStyleBackColor = true;
            // 
            // miscellaneousTweaks
            // 
            this.miscellaneousTweaks.Location = new System.Drawing.Point(4, 4);
            this.miscellaneousTweaks.Name = "miscellaneousTweaks";
            this.miscellaneousTweaks.Size = new System.Drawing.Size(792, 347);
            this.miscellaneousTweaks.TabIndex = 2;
            this.miscellaneousTweaks.Text = "Miscellaneous tweaks";
            this.miscellaneousTweaks.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "W1nT3N_0Ptimizer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.registry.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.info.ResumeLayout(false);
            this.info.PerformLayout();
            this.programs.ResumeLayout(false);
            this.programs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AutoUninstallCMD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listInstalled)).EndInit();
            this.registryViewer.ResumeLayout(false);
            this.devices.ResumeLayout(false);
            this.devices.PerformLayout();
            this.tweaks.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage registry;
        private System.Windows.Forms.TabPage tweaks;
        private System.Windows.Forms.PictureBox icon;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage info;
        private System.Windows.Forms.TabPage programs;
        private System.Windows.Forms.Label txtCPU;
        private System.Windows.Forms.Label txtBit;
        private System.Windows.Forms.Label txtOS;
        private System.Windows.Forms.Label txtGPU;
        private System.Windows.Forms.Label txtMB;
        private System.Windows.Forms.Label txtBIOS;
        private System.Windows.Forms.Button infoExport;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage bootTweaks;
        private System.Windows.Forms.TabPage performanceTweaks;
        private System.Windows.Forms.TabPage miscellaneousTweaks;
        private System.Windows.Forms.TabPage privacyTweaks;
        private ImageButton.ImageButton CloseBtn;
        private ImageButton.ImageButton imageButton2;
        private System.Windows.Forms.DataGridView listInstalled;
        private System.Windows.Forms.TabPage registryViewer;
        private System.Windows.Forms.TreeView registryTreeView;
        private System.Windows.Forms.Button importSettings;
        private System.Windows.Forms.TabPage devices;
        private System.Windows.Forms.ListView ConnUSB;
        private System.Windows.Forms.ColumnHeader DeviceID;
        private System.Windows.Forms.ColumnHeader PNPDeviceID;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.Label TotalConnectedUSB;
        private System.Windows.Forms.Label ConnectedDrives;
        private System.Windows.Forms.ListView ConnDrives;
        private System.Windows.Forms.ColumnHeader Drive;
        private System.Windows.Forms.ColumnHeader FreeSpace;
        private System.Windows.Forms.ColumnHeader TotalSpace;
        private System.Windows.Forms.ColumnHeader FileType;
        private System.Windows.Forms.ColumnHeader DriveType;
        private System.Windows.Forms.Label installedCount;
        private ImageButton.ImageButton AutoUninstallCMD;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstimatedSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegistryPath;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UninstallString;
    }
}

