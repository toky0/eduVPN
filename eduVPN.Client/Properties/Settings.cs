/*
    eduVPN - VPN for education and research

    Copyright: 2017-2020 The Commons Conservancy eduVPN Programme
    SPDX-License-Identifier: GPL-3.0+
*/

using System.Configuration;

namespace eduVPN.Client.Properties
{
    /// <summary>
    /// eduVPN client settings
    /// </summary>
    public sealed partial class Settings : ApplicationSettingsBase
    {
        #region Methods

        /// <summary>
        /// Initialize settings
        /// </summary>
        public static void Initialize()
        {
            if (Default.SettingsVersion == 0)
            {
                // Migrate settings from previous version.
                Default.Upgrade();
                Default.SettingsVersion = 1;
            }
        }

        #endregion
    }
}
