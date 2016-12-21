﻿using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace SyncthingTray.Utilities
{
    public static class RegistryUtil
    {
        private const string RegistryRun = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

        public static void SetStartup(bool value)
        {
            var rk = Registry.CurrentUser.OpenSubKey
                (RegistryRun, true);

            if (rk == null) throw new ArgumentException("Couldn't get write access to registry.");
            if (value)
                rk.SetValue(Application.ProductName, Application.ExecutablePath);
            else
                rk.DeleteValue(Application.ProductName, false);

        }

        public static bool GetStartup()
        {
            var rk = Registry.CurrentUser.OpenSubKey
                (RegistryRun, false);

            if (rk == null) throw new ArgumentException("Couldn't get read access to registry.");
            return !string.IsNullOrEmpty(rk.GetValue(Application.ProductName, string.Empty).ToString());
        }
    }
}
