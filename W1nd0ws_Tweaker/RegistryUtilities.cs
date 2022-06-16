using System;
using Microsoft.Win32;
using System.Windows.Forms;

namespace WinHelper
{
    public static class RegistryUtilities
    {
        #region Rename Registry keys
        /// <summary>
        /// Renames a subkey of the passed in registry key since 
        /// the Framework totally forgot to include such a handy feature.
        /// </summary>
        /// <param name="path">The path in Registry that contains the key 
        /// you want to rename (must be writeable)</param>
        /// <param name="keyName">The name of the key that you want to rename
        /// </param>
        /// <param name="newKeyName">The new name of the RegistryKey</param>
        /// <returns>True if succeeds</returns>
        public static bool RenameSubKey(string path, string keyName, string newKeyName)
        {
            #region 64-bit Registry value
            try
            {
                if (Environment.Is64BitOperatingSystem && !Environment.Is64BitProcess)
                {
                    RegistryKey rk64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(path, RegistryKeyPermissionCheck.ReadWriteSubTree);

                    //Open the value from the original key 
                    object objValue = rk64.GetValue(keyName);
                    RegistryValueKind valKind = rk64.GetValueKind(keyName);

                    rk64.SetValue(newKeyName, objValue, valKind); //Create new key

                    rk64.DeleteValue(keyName); //Delete the old key

                    return true;
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Couldn't perform the operation.\n" +
                "If you see the same application twice, try the second option\n" +
                "(The one you didn't press on)\n" +
                "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                //return false;
            }
            catch (System.IO.IOException ex)
            {
                MessageBox.Show("Couldn't perform the operation.\n" +
                "The application doesn't have an uninstall option\n" +
                "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                //return false;
            }
            #endregion
            #region 32-bit Registry value
            try
            {
                using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(path, RegistryKeyPermissionCheck.ReadWriteSubTree))
                {
                    object objValue = rk.GetValue(keyName);
                    RegistryValueKind valKind = rk.GetValueKind(keyName);

                    rk.SetValue(newKeyName, objValue, valKind);

                    rk.DeleteValue(keyName);

                    return true;
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Couldn't perform the operation.\n" +
                "If you see the same application twice, try the second option\n" +
                "(The one you didn't press on)\n" +
                "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }
            catch (System.IO.IOException ex)
            {
                MessageBox.Show("Couldn't perform the operation.\n" +
                "The application doesn't have an uninstall option\n" +
                "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }
            #endregion
        }
        #endregion

        #region Search for the existence for a specific value in a specific path in Registry
        public static bool ValueExists(string Key, string Value)
        {
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(Key, false))
            {
                if (rk != null) return rk.GetValue(Value) != null;
            }

            if (Environment.Is64BitOperatingSystem && !Environment.Is64BitProcess)
            {
                RegistryKey regkey64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                return regkey64.OpenSubKey(Key).GetValue(Value) != null;
            }

            return false;
        }
        #endregion

        #region Modify Registry keys value
        /// <summary>
        /// Changes the value of a registry key
        /// </summary>
        /// <param name="path">The path in Registry that contains the key 
        /// you want to rename (must be writeable)</param>
        /// <param name="keyName">The name of the key that you want to change the value
        /// </param>
        /// <param name="newKeyValue">The new value</param>
        /// <returns>True if succeeds</returns>
        public static bool ChangeKeyValue(string path, string keyName, string newKeyValue)
        {
            #region 64-bit Registry value
            if (Environment.Is64BitOperatingSystem && !Environment.Is64BitProcess)
            {
                RegistryKey rk64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(path, RegistryKeyPermissionCheck.ReadWriteSubTree);

                RegistryValueKind valueKind = rk64.GetValueKind(keyName);

                rk64.SetValue(keyName, newKeyValue, valueKind); //Create new key

                return true;
            }
            #endregion
            #region 32-bit Registry value
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(path, RegistryKeyPermissionCheck.ReadWriteSubTree))
            {
                RegistryValueKind valKind = rk.GetValueKind(keyName); //Gets the value type

                rk.SetValue(keyName, newKeyValue, valKind); //Create new key

                return true;
            }
            #endregion
        }
        #endregion
    }
}