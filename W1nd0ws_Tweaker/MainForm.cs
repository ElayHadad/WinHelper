using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Linq.Expressions;

namespace W1nd0ws_Tweaker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            #region Reading PC info
            //Reading the OS + Build
            string osName = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows NT\CurrentVersion", "ProductName", null);
            string releaseId = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ReleaseId", "").ToString();
            txtOS.Text = "You are running " + osName + " version " + releaseId;

            //Reading the architecture
            if (Directory.Exists("C:\\Program Files (x86)"))
                txtBit.Text = "You are working with 64-bit architecture";
            else
                txtBit.Text = "You are working with 32-bit architecture";

            //Reading the CPU
            string cpu = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0", "ProcessorNameString", null);
            byte coreCount = 0;
            foreach (var item in new ManagementObjectSearcher("Select * from Win32_Processor").Get())
                coreCount += byte.Parse(item["NumberOfCores"].ToString());
            //Counting Logical Cores by counting the folders in "HARDWARE\DESCRIPTION\System\CentralProcessor"
            RegistryKey keyCPU = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor", false);
            byte logicalCores = 0;
            foreach (string subKeysCPU in keyCPU.GetSubKeyNames())
                logicalCores++;
            //Final output
            txtCPU.Text = "Your CPU is: " + cpu + "\n                    Physical cores: " + coreCount + "\n                    Logical cores: " + logicalCores;

            //Reading the GPU (forcing to read 64x)
            string subkey = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\WinSAT";
            RegistryKey localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            // string gpu = localKey.OpenSubKey(subkey).GetValue("PrimaryAdapterString").ToString();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
            string graphicsCard = string.Empty;
            foreach (ManagementObject obj in searcher.Get())
            {
                if (obj["CurrentBitsPerPixel"] != null && obj["CurrentHorizontalResolution"] != null)
                {
                    graphicsCard = obj["Name"].ToString();
                }
            }
            txtGPU.Text = "Your GPU is: " + graphicsCard;

            //Reading motherboard manufacturer and model
            string mb = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\BIOS", "BaseBoardProduct", null);
            string mbManufacturer = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\BIOS", "SystemManufacturer", null);
            txtMB.Text = "Your MotherBoard model is: " + mb + "\nManufactured by: " + mbManufacturer;

            //Reading BIOS version and vendor
            string biosVer = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\BIOS", "BIOSVersion", null);
            string biosVen = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\BIOS", "BIOSVendor", null);
            string biosDate = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\BIOS", "BIOSReleaseDate", null);
            txtBIOS.Text = "Your BIOS Vendor is: " + biosVen + "\nYour BIOS Version is: " + biosVer + ", " + biosDate;
            #endregion
            GetInstalledSoftware();
            ReadRegistry();
            ConnectedUSB();
            DrivesConnected();
        }

        #region Form Design
        #region Close&Max&Min buttons
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion
        #region Form dragging
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        Point mousedownpoint = Point.Empty;

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        #endregion
        private void icon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello there user!\n" +
                "This app was made with sweat blood and tears.\n" +
                "I put a LOT of effort in it and I've done a huge research about Windows10.\n" +
                "Every single tweak and piece of code I put here was checked and confirmed as legit by me.\n" +
                "Moreover, most of the tweaks was taken directly from\n" +
                "Microsoft's documentation and some was taken from\n" +
                "other forums. NOT the shady ones ofcourse\n" +
                "Forums like; Calypto, Danske and etc..\n" +
                "(If you want to know and read more info to\n" +
                "what you're actually doing, it can be good to\n" +
                "google it and read for yourself).\n" +
                "\n" +
                "There is a lot hidden options in your system waiting to be unleashed!\n" +
                "I AM NOT RESPONSIBLE FOR ANYTHING, use by your own risk!\n" +
                "", "README", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
        #endregion

        private bool NotLaptop = SystemInformation.PowerStatus.BatteryChargeStatus == BatteryChargeStatus.NoSystemBattery;

        #region Convert size
        private String convertSize(double size)
        {
            String[] units = new String[] { "B", "KB", "MB", "GB", "TB", "PB" };

            double mod = 1024.0;

            int i = 0;

            while (size >= mod)
            {
                size /= mod;
                i++;
            }
            return Math.Round(size, 2) + units[i]; //with 2 decimals
        }
        #endregion

        #region Get all connected drives
        private void DrivesConnected()
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                ListViewItem item = new ListViewItem(new string[] { drive.Name, convertSize(Convert.ToDouble(drive.TotalFreeSpace)).ToString(), convertSize(Convert.ToDouble(drive.TotalSize)).ToString(), drive.DriveFormat, drive.DriveType.ToString() });
                ConnDrives.Items.Add(item);
            }
            ConnDrives.Sorting = SortOrder.Ascending; // Sort by alphabet
            ConnectedDrives.Text = "Total of " + ConnDrives.Items.Count.ToString() + " connected drives";
        }
        #endregion

        #region Get all connected USB devices
        private void ConnectedUSB()
        {
            var usbDevices = USBDeviceInfo.GetUSBDevices();
            foreach (var usbDevice in usbDevices)
            {
                ListViewItem item = new ListViewItem(new string[] { usbDevice.DeviceID, usbDevice.PnpDeviceID, usbDevice.Description });
                ConnUSB.Items.Add(item);
            }
            ConnUSB.Sorting = SortOrder.Ascending; // Sort by alphabet
            TotalConnectedUSB.Text = "Total of " + ConnUSB.Items.Count.ToString() + " connected USB devices";
        }
        #endregion

        #region Registry TreeView
        private void ReadRegistry()
        {
            #region Read HKEY_CLASSES_ROOT
            TreeNode rootNode = new TreeNode(Registry.ClassesRoot.Name, 0, 1);
            string[] rootSubKeys = Registry.ClassesRoot.GetSubKeyNames();
            foreach (string key in rootSubKeys)
            {
                TreeNode node = new TreeNode(key, 0, 1);
                try
                {
                    string[] subKeys = Registry.ClassesRoot.OpenSubKey(key).GetSubKeyNames();
                    foreach (string subKeysKey in subKeys)
                    {
                        node.Nodes.Add(subKeysKey, subKeysKey, 0, 1);
                    }

                    rootNode.Nodes.Add(node);
                }
                catch (Exception)
                { }
            }
            registryTreeView.Nodes.Add(rootNode);
            #endregion

            #region HKEY_CURRENT_CONFIG
            TreeNode configNode = new TreeNode(Registry.CurrentConfig.Name, 0, 1);
            string[] configSubKeys = Registry.CurrentConfig.GetSubKeyNames();
            foreach (string key in configSubKeys)
            {
                TreeNode node = new TreeNode(key, 0, 1);
                string[] subKeys =
                    Registry.CurrentConfig.OpenSubKey(key).GetSubKeyNames();
                foreach (string subKeysKey in subKeys)
                    node.Nodes.Add(subKeysKey, subKeysKey, 0, 1);

                configNode.Nodes.Add(node);
            }
            registryTreeView.Nodes.Add(configNode);
            #endregion

            #region HKEY_CURRENT_USER
            TreeNode currentUserNode = new TreeNode(Registry.CurrentUser.Name, 0, 1);
            string[] currentUserSubKeys = Registry.CurrentUser.GetSubKeyNames();
            foreach (string key in currentUserSubKeys)
            {
                TreeNode node = new TreeNode(key, 0, 1);
                string[] subKeys = Registry.CurrentUser.OpenSubKey(key).GetSubKeyNames();
                foreach (string subKeysKey in subKeys)
                    node.Nodes.Add(subKeysKey, subKeysKey, 0, 1);

                currentUserNode.Nodes.Add(node);
            }
            registryTreeView.Nodes.Add(currentUserNode);
            #endregion

            #region HKEY_LOCAL_MACHINE
            TreeNode localMachineNode = new TreeNode(Registry.LocalMachine.Name);
            string[] localMachineSubKeys = Registry.LocalMachine.GetSubKeyNames();
            foreach (string key in localMachineSubKeys)
            {
                TreeNode node = new TreeNode(key, 0, 1);

                try
                {
                    string[] subKeys =
                        Registry.LocalMachine.OpenSubKey(key, false).GetSubKeyNames();
                    foreach (string subKeysKey in subKeys)
                        node.Nodes.Add(subKeysKey, subKeysKey, 0, 1);
                }
                catch (Exception)
                {
                    //an exception is thrown if the user has no access to this subkey
                    //if this is the case, change the icon to show a dimmed folder
                    node.ImageIndex = 4;
                    node.SelectedImageIndex = 5;
                }

                localMachineNode.Nodes.Add(node);
            }
            registryTreeView.Nodes.Add(localMachineNode);
            #endregion

            #region HKEY_USERS
            TreeNode usersNode = new TreeNode(Registry.Users.Name);
            string[] usersSubKeys = Registry.Users.GetSubKeyNames();
            foreach (string key in usersSubKeys)
            {
                TreeNode node = new TreeNode(key, 0, 1);

                try
                {
                    string[] subKeys = Registry.Users.OpenSubKey(key).GetSubKeyNames();
                    foreach (string subKeysKey in subKeys)
                        node.Nodes.Add(subKeysKey, subKeysKey, 0, 1);
                }
                catch (Exception)
                {
                    //an exception is thrown if the user has no access to this subkey
                    //if this is the case, change the icon to show a dimmed folder
                    node.ImageIndex = 4;
                    node.SelectedImageIndex = 5;
                }

                usersNode.Nodes.Add(node);
            }
            registryTreeView.Nodes.Add(usersNode);
            #endregion
        }
        #endregion

        #region Installed programs tab
        private void GetInstalledSoftware()
        {
            #region Initialize Variables
            string displayName;
            int size;
            string uninstallString;
            RegistryKey key;
            int rowsCount = 0;
            #endregion

            #region Get all 32-bit applications installed
            /*
            // search in: CurrentUser
            key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                size = subkey.GetValue("EstimatedSize") as string;
                uRLUpdateInfo = subkey.GetValue("UninstallString") as string;

                if (displayName != null)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[rowsCount].Cells[0].Value = displayName;
                    dataGridView1.Rows[rowsCount].Cells[1].Value = size;
                    dataGridView1.Rows[rowsCount].Cells[2].Value = subkey.ToString();
                    rowsCount++;
                }
            }
            */

            // search in: LocalMachine_32
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                size = Convert.ToInt32(subkey.GetValue("EstimatedSize"));
                uninstallString = subkey.GetValue("UninstallString") as string;

                if (displayName != null)
                {
                    if (size != 0)
                    {
                        listInstalled.Rows.Add();
                        listInstalled.Rows[rowsCount].Cells[0].Value = displayName;
                        listInstalled.Rows[rowsCount].Cells[1].Value = size;
                        listInstalled.Rows[rowsCount].Cells[2].Value = subkey.ToString();
                        rowsCount++;
                    }
                    else
                    {
                        listInstalled.Rows.Add();
                        listInstalled.Rows[rowsCount].Cells[0].Value = displayName;
                        listInstalled.Rows[rowsCount].Cells[1].Value = null;
                        listInstalled.Rows[rowsCount].Cells[2].Value = subkey.ToString();
                        rowsCount++;
                    }
                }
            }

            // search in: LocalMachine_64
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                size = Convert.ToInt32(subkey.GetValue("EstimatedSize"));
                uninstallString = subkey.GetValue("UninstallString") as string;

                if (displayName != null)
                {
                    if (size != 0)
                    {
                        listInstalled.Rows.Add();
                        listInstalled.Rows[rowsCount].Cells[0].Value = displayName;
                        listInstalled.Rows[rowsCount].Cells[1].Value = size;
                        listInstalled.Rows[rowsCount].Cells[2].Value = subkey.ToString();
                        rowsCount++;
                    }
                    else
                    {
                        listInstalled.Rows.Add();
                        listInstalled.Rows[rowsCount].Cells[0].Value = displayName;
                        listInstalled.Rows[rowsCount].Cells[1].Value = null;
                        listInstalled.Rows[rowsCount].Cells[2].Value = subkey.ToString();
                        rowsCount++;
                    }
                }
            }
            #endregion

            #region Get all 64-bit applications installed
            /*
            // search in: CurrentUser
            key = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                size = subkey.GetValue("EstimatedSize") as string;
                uRLUpdateInfo = subkey.GetValue("UninstallString") as string;

                if (displayName != null)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[rowsCount].Cells[0].Value = displayName;
                    dataGridView1.Rows[rowsCount].Cells[1].Value = size;
                    dataGridView1.Rows[rowsCount].Cells[2].Value = subkey.ToString();
                    rowsCount++;
                }

            }
            */

            // search in: LocalMachine_32
            key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                size = Convert.ToInt32(subkey.GetValue("EstimatedSize"));
                uninstallString = subkey.GetValue("UninstallString") as string;

                if (displayName != null)
                {
                    if (size != 0)
                    {
                        listInstalled.Rows.Add();
                        listInstalled.Rows[rowsCount].Cells[0].Value = displayName;
                        listInstalled.Rows[rowsCount].Cells[1].Value = size;
                        listInstalled.Rows[rowsCount].Cells[2].Value = subkey.ToString();
                        rowsCount++;
                    }
                    else
                    {
                        listInstalled.Rows.Add();
                        listInstalled.Rows[rowsCount].Cells[0].Value = displayName;
                        listInstalled.Rows[rowsCount].Cells[1].Value = null;
                        listInstalled.Rows[rowsCount].Cells[2].Value = subkey.ToString();
                        rowsCount++;
                    }
                }
            }

            // search in: LocalMachine_64
            key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                size = Convert.ToInt32(subkey.GetValue("EstimatedSize"));
                uninstallString = subkey.GetValue("UninstallString") as string;

                if (displayName != null)
                {
                    if (size != 0)
                    {
                        listInstalled.Rows.Add();
                        listInstalled.Rows[rowsCount].Cells[0].Value = displayName;
                        listInstalled.Rows[rowsCount].Cells[1].Value = size;
                        listInstalled.Rows[rowsCount].Cells[2].Value = subkey.ToString();
                        rowsCount++;
                    }
                    else
                    {
                        listInstalled.Rows.Add();
                        listInstalled.Rows[rowsCount].Cells[0].Value = displayName;
                        listInstalled.Rows[rowsCount].Cells[1].Value = null;
                        listInstalled.Rows[rowsCount].Cells[2].Value = subkey.ToString();
                        rowsCount++;
                    }
                }
            }
            key.Close();
            #endregion

            listInstalled.Sort(listInstalled.Columns[0], ListSortDirection.Ascending); // Sort data

            #region Remove duplicates

            #region Simple duplicates
            for (int i = 0; i < listInstalled.Rows.Count; i++)
            {
                for (int j = 0; j < listInstalled.Rows.Count; j++)
                {
                    if (listInstalled.Rows[i].Cells[2].Value.ToString() == listInstalled.Rows[j].Cells[2].Value.ToString() && i != j)
                    {
                        listInstalled.Rows.Remove(listInstalled.Rows[j]);
                    }
                }
            }
            #endregion

            #region Wow6432Node duplicates
            for (int i = 0; i < listInstalled.Rows.Count; i++)
            {
                for (int j = 0; j < listInstalled.Rows.Count; j++)
                {
                    if (listInstalled.Rows[i].Cells[0].Value.ToString() == listInstalled.Rows[j].Cells[0].Value.ToString() && i != j)
                    {
                        if (listInstalled.Rows[i].Cells[2].Value.ToString().Contains("Wow6432Node") == true)
                            listInstalled.Rows.Remove(listInstalled.Rows[j]);
                        else
                            listInstalled.Rows.Remove(listInstalled.Rows[i]);
                    }
                }
            }
            #endregion

            #endregion

            #region Show the total of all installed applications
            installedCount.Text = "You have a total of " + listInstalled.Rows.Count + " applications installed.";
            #endregion

            UninstallOption();

            toolTip.SetToolTip(AutoUninstallCMD, "Create CMD script that uninstalls apps silently");
        }

        #region Update real-time if the uninstall option is enabled\disabled for selected application
        private void UninstallOption()
        {
            for (int i = 0; i < listInstalled.Rows.Count; i++)
            {
                string retrieveAppPath = listInstalled.Rows[i].Cells[2].Value.ToString(); //Registry Path
                retrieveAppPath = retrieveAppPath.Remove(0, 19); // Remove the first 19 characters

                #region Determine if the current state of the application's uninstall
                if (RegistryUtilities.ValueExists(retrieveAppPath, "UninstallString"))
                {
                    listInstalled.Rows[i].Cells[3].Value = true;
                }
                else if (RegistryUtilities.ValueExists(retrieveAppPath, "!UninstallString"))
                {
                    listInstalled.Rows[i].Cells[3].Value = false;
                }
                #endregion
                #region Determine if it's valid to change the application's uninstall option
                else
                {
                    DataGridViewCell cell = listInstalled.Rows[i].Cells[3];
                    DataGridViewCheckBoxCell chkCell = cell as DataGridViewCheckBoxCell;
                    chkCell.Value = false;
                    chkCell.FlatStyle = FlatStyle.Flat;
                    chkCell.Style.ForeColor = Color.DarkGray;
                    cell.ReadOnly = true;
                }
                #endregion
            }
        }
        #endregion

        #region Enable/Disable Uninstall option through DataGridView
        private void listInstalled_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //make DataGridCheckBoxColumn commit changes with single click  
            //use index of logout column  
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
                this.listInstalled.CommitEdit(DataGridViewDataErrorContexts.Commit);

            
            string retrieveAppPath = listInstalled.CurrentRow.Cells[2].Value.ToString(); //Registry Path
            retrieveAppPath = retrieveAppPath.Remove(0, 19); // Remove the first 19 characters
            try
            {
                if (Convert.ToBoolean(listInstalled.CurrentCell.Value) == true)
                {
                    RegistryUtilities.RenameSubKey(retrieveAppPath, "UninstallString", "!UninstallString");
                }
                else if (Convert.ToBoolean(listInstalled.CurrentCell.Value) == false)
                {
                    RegistryUtilities.RenameSubKey(retrieveAppPath, "!UninstallString", "UninstallString");
                }
            }
            catch (Exception ex) { }
            
            UninstallOption();
        }
        #endregion

        #region Export DataGridView data in different ways
        private void settingsExport_Click(object sender, EventArgs e)
        {
            #region Initialize MessageBox
            MessageBoxManager.Unregister();
            MessageBoxManager.Yes = "As script";
            MessageBoxManager.No = "As settings";
            MessageBoxManager.Register();
            DialogResult question = MessageBox.Show("Would you like to\n" +
                "save these as settings or to\n" +
                "export all as data?\n" +
                "", "README", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button3);
            #endregion

            #region Export all info as batch file
            if (question == DialogResult.Yes)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Batch File | *.cmd";
                var result = dialog.ShowDialog();
                if (result != DialogResult.OK)
                    return;

                List<string> lines = new List<string>();
                string filePath = dialog.FileName; // Save selected file path
                lines.Add("@echo off > nul\n");
                foreach (DataGridViewRow row in listInstalled.Rows)
                {
                    #region if uninstall option is disabled
                    if (row.Cells[3].Value.ToString() == "False" && (bool)row.Cells[3].ReadOnly == false)
                    {
                        lines.Add(":: " + row.Cells[0].Value.ToString());
                        lines.Add("REG ADD " + row.Cells[2].Value.ToString() + " /v !UninstallString /t REG_SZ /d " + Registry.GetValue(row.Cells[2].Value.ToString(), "!UninstallString", null));
                        lines.Add("REG DELETE " + row.Cells[2].Value.ToString() + " /v UninstallString /f");
                        lines.Add("");
                    }
                    #endregion

                    #region if app uninstall option is enabled
                    if (row.Cells[3].Value.ToString() == "True" && (bool)row.Cells[3].ReadOnly == false)
                    {
                        lines.Add(":: " + row.Cells[0].Value.ToString());
                        lines.Add("REG ADD " + row.Cells[2].Value.ToString() + " /v UninstallString /t REG_SZ /d " + Registry.GetValue(row.Cells[2].Value.ToString(), "UninstallString", null));
                        lines.Add("REG DELETE " + row.Cells[2].Value.ToString() + " /v !UninstallString /f");
                        lines.Add("");
                    }
                    #endregion
                }
                File.WriteAllLines(filePath, lines);

                MessageBox.Show(@"Batch file was created.");
            }
            #endregion

            #region Export all info as settings
            else if (question == DialogResult.No)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Text File|*.txt";
                var result = dialog.ShowDialog();
                if (result != DialogResult.OK)
                    return;
                List<string> lines = new List<string>();
                string filePath = dialog.FileName; // Save selected file path
                foreach (DataGridViewRow row in listInstalled.Rows)
                {
                    if (row.Cells[3].Value.ToString() == "False" && row.Cells[3].ReadOnly == false)
                        lines.Add(row.Cells[2].Value.ToString() + ";" + row.Cells[3].Value.ToString());
                }
                File.WriteAllLines(filePath, lines);

                MessageBox.Show(@"Text file was created.");
            }
            #endregion

            #region Cancel the operation
            else if (question == DialogResult.Cancel)
            {
                MessageBox.Show(@"Operation was cancelled.", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            #endregion
        }
        #endregion

        #region Change application name
        private void listInstalled_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string retrieveAppPath = listInstalled.CurrentRow.Cells[2].Value.ToString(); //Registry Path
            retrieveAppPath = retrieveAppPath.Remove(0, 19); // Remove the first 19 characters
            RegistryUtilities.ChangeKeyValue(retrieveAppPath, "DisplayName", listInstalled.CurrentRow.Cells[0].Value.ToString());
        }
        #endregion

        #region Import setting of the applications' uninstall option
        private void importSettings_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileChoose = new OpenFileDialog(); // Creating a new OpenFileDialog
            fileChoose.Filter = "Text File|*.txt"; // Look for txt files only
            fileChoose.Title = "Browse Text Files"; // New title for the dialog
            fileChoose.ShowDialog(); // Showing the created dialog
            string path = fileChoose.FileName; // Save selected file path

            #region Error handler; if no file was imported
            if (path == "")
            {
                MessageBox.Show(@"No file was imported.");
            }
            #endregion
            #region If file was imported
            else
            {
                #region Initialize variables
                List<string> lines = new List<string>();
                lines = File.ReadAllLines(path).ToList();
                string uninstallOption;
                #endregion

                foreach (DataGridViewRow row in listInstalled.Rows)
                {
                    foreach (string line in lines)
                    {
                        path = line;
                        uninstallOption = line;

                        #region remove everything after the ";"
                        int index = path.IndexOf(";");
                        if (index > 0)
                            path = path.Substring(0, index);
                        #endregion

                        uninstallOption = uninstallOption.Substring(uninstallOption.IndexOf('.') + 1); // Remove everything before the ";"

                        #region Apply settings file
                        if (row.Cells[2].Value.ToString() == path && row.Cells[3].Value.ToString() != uninstallOption)
                        {
                            string retrieveAppPath = row.Cells[2].Value.ToString(); //Registry Path
                            retrieveAppPath = retrieveAppPath.Remove(0, 19); // Remove the first 19 characters
                            RegistryUtilities.RenameSubKey(retrieveAppPath, "UninstallString", "!UninstallString");
                        }
                        #endregion
                    }
                }

                UninstallOption(); // Update DataGridView table

                MessageBox.Show(@"Text file was imported.");
            }
            #endregion
        }
        #endregion

        #region Context menu on MouseRightClick on selected cell
        private void listInstalled_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Copy"));
                int currentMouseOverRow = listInstalled.HitTest(e.X, e.Y).RowIndex;
                m.Show(listInstalled, new Point(e.X, e.Y));
                if (listInstalled.GetCellCount(DataGridViewElementStates.Selected) > 0)
                {
                    try
                    {
                        // Add the selection to the clipboard.
                        Clipboard.SetDataObject(listInstalled.GetClipboardContent());
                        // Replace the text box contents with the clipboard text. 

                        MessageBox.Show(Clipboard.GetText());
                    }
                    catch (System.Runtime.InteropServices.ExternalException)
                    {

                        MessageBox.Show("The Clipboard could not be accessed. Please try again.");
                    }
                }
            }
        }
        #endregion

        #region Create silent apps uninstall script
        private void AutoUninstallCMD_Click(object sender, EventArgs e)
        {
            #region create uninstall script of batch file
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Batch File | *.cmd";
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK)
                return;

            List<string> lines = new List<string>();
            string filePath = dialog.FileName; // Save selected file path
            lines.Add("@echo off > nul\n");
            foreach (DataGridViewRow row in listInstalled.SelectedRows)
            {
                #region if uninstall option is disabled
                if (row.Cells[3].Value.ToString() == "False" && (bool)row.Cells[3].ReadOnly == false)
                {
                    lines.Add(":: " + row.Cells[0].Value.ToString());
                    lines.Add(Registry.LocalMachine.OpenSubKey(row.Cells[2].Value.ToString().Remove(0, 19), false).GetValue("!UninstallString") + " /silent /verysilent /noquestion /Uninst /U /u /S /s /X /x /quiet /passive");
                }
                #endregion

                #region if app uninstall option is enabled
                if (row.Cells[3].Value.ToString() == "True" && (bool)row.Cells[3].ReadOnly == false)
                {
                    lines.Add(":: " + row.Cells[0].Value.ToString());
                    lines.Add(Registry.LocalMachine.OpenSubKey(row.Cells[2].Value.ToString().Remove(0, 19), false).GetValue("UninstallString") + " /silent /verysilent /noquestion /Uninst /U /u /S /s /X /x /quiet /passive");
                }
                #endregion
            }
            File.WriteAllLines(filePath, lines);

            MessageBox.Show(@"Batch file was created.");
            #endregion
        }
        #endregion

        #endregion
    }
}