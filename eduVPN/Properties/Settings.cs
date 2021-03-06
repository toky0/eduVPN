﻿/*
    eduVPN - VPN for education and research

    Copyright: 2017-2020 The Commons Conservancy eduVPN Programme
    SPDX-License-Identifier: GPL-3.0+
*/

using eduOAuth;
using eduVPN.Models;
using System;
using System.Configuration;
using System.Linq;

namespace eduVPN.Properties
{
    /// <summary>
    /// eduVPN settings
    /// </summary>
    public sealed partial class Settings : ApplicationSettingsBase
    {
        #region Fields

        /// <summary>
        /// Instance directory URI IDs as used in <see cref="Properties.Settings.Default"/> collection
        /// </summary>
        public static readonly string[] InstanceDirectoryId = new string[]
        {
            null,
            "SecureInternet",
            "InstituteAccess",
        };

        #endregion

        #region Properties

        /// <summary>
        /// Returns resource URI from settings
        /// </summary>
        /// <param name="key">The name of the setting</param>
        /// <returns>URI-Public keys-touple</returns>
        public Xml.ResourceRef GetResourceRef(string key)
        {
            return this[key] is Xml.ResourceRef res ?
                res :
                new Xml.ResourceRef()
                {
                    Uri = new Uri((string)this[key]),
                };
        }

        /// <summary>
        /// Server list discovery URL
        /// </summary>
        [ApplicationScopedSetting()]
        public Xml.ResourceRef ServerListDiscovery
        {
            get { return GetResourceRef("ServerListDiscovery"); }
        }

        /// <summary>
        /// Organization list discovery URL
        /// </summary>
        [ApplicationScopedSetting()]
        public Xml.ResourceRef OrganizationListDiscovery
        {
            get { return GetResourceRef("OrganizationListDiscovery"); }
        }

        /// <summary>
        /// Secure Internet discovery URL
        /// </summary>
        [ApplicationScopedSetting()]
        public Xml.ResourceRef SecureInternetDiscoveryDescr
        {
            get { return GetResourceRef("SecureInternetDiscoveryDescr"); }
        }

        /// <summary>
        /// Institute Access discovery URL
        /// </summary>
        [ApplicationScopedSetting()]
        public Xml.ResourceRef InstituteAccessDiscoveryDescr
        {
            get { return GetResourceRef("InstituteAccessDiscoveryDescr"); }
        }

        /// <summary>
        /// Self-updating discovery URL
        /// </summary>
        [ApplicationScopedSetting()]
        public Xml.ResourceRef SelfUpdateDescr
        {
            get { return GetResourceRef("SelfUpdateDescr"); }
        }

        /// GUID of the installer EXE bundle
        /// </summary>
        [ApplicationScopedSetting()]
        [SettingsDescription("GUID of the installer EXE bundle")]
        public string SelfUpdateBundleID { get; set; }

        /// <summary>
        /// Client ID
        /// </summary>
        [ApplicationScopedSetting()]
        [SettingsDescription("Client ID")]
        public string ClientID { get; set; }

        /// <summary>
        /// Client Title
        /// </summary>
        [ApplicationScopedSetting()]
        [SettingsDescription("Client Title")]
        public string ClientTitle { get; set; }

        #endregion

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

                // Versions before 1.0.4 used interface name, instead of ID.
                if (Default.GetPreviousVersion("OpenVPNInterface") is string iface_name &&
                    NetworkInterface.TryFromName(iface_name, out var iface))
                    Default.OpenVPNInterfaceID = iface.ID;

                for (int source_index = (int)InstanceSourceType._start; source_index < (int)InstanceSourceType._end; source_index++)
                {
                    #pragma warning disable 0612 // This section contains legacy settings conversion.
                    if (Default.GetPreviousVersion(InstanceDirectoryId[source_index] + "ConfigHistory") is Xml.VPNConfigurationSettingsList settings_list &&
                        settings_list.Count > 0)
                    {
                        // Versions before 1.0.9 used different instance source settings. Convert them.
                        Xml.InstanceSourceSettingsBase h = null;
                        if (settings_list[0] is Xml.LocalVPNConfigurationSettings)
                        {
                            // Local authenticating instance source:
                            // - Convert instance list.
                            // - Set connecting instance by maximum popularity.
                            var h_local = new Xml.LocalInstanceSourceSettings();
                            foreach (var h_cfg in settings_list)
                            {
                                if (h_cfg is Xml.LocalVPNConfigurationSettings h_cfg_local)
                                {
                                    var instance = h_local.ConnectingInstanceList.FirstOrDefault(inst => inst.Base.AbsoluteUri == h_cfg_local.Instance.AbsoluteUri);
                                    if (instance == null)
                                    {
                                        // Add (instance, profile) pair.
                                        h_local.ConnectingInstanceList.Add(new Xml.InstanceRef()
                                        {
                                            Base = h_cfg_local.Instance,
                                            Popularity = h_cfg_local.Popularity,
                                            ProfileList = new Xml.ProfileRefList()
                                            {
                                                new Xml.ProfileRef()
                                                {
                                                    ID = h_cfg_local.Profile,
                                                    Popularity = h_cfg_local.Popularity
                                                }
                                            }
                                        });
                                    }
                                    else
                                    {
                                        // Instance already on the list. Update it.
                                        instance.Popularity = Math.Max(instance.Popularity, h_cfg_local.Popularity);
                                        if (instance.ProfileList.FirstOrDefault(prof => prof.ID == h_cfg_local.Profile) == null)
                                        {
                                            // Add profile to the instance.
                                            instance.ProfileList.Add(new Xml.ProfileRef()
                                            {
                                                ID = h_cfg_local.Profile,
                                                Popularity = h_cfg_local.Popularity
                                            });
                                        }
                                    }
                                }
                            }
                            h_local.ConnectingInstance = h_local.ConnectingInstanceList.Count > 0 ? h_local.ConnectingInstanceList.Aggregate((most_popular_instance, inst) => (most_popular_instance == null || inst.Popularity > most_popular_instance.Popularity ? inst : most_popular_instance))?.Base : null;
                            h = h_local;
                        }
                        else if (settings_list[0] is Xml.DistributedVPNConfigurationSettings h_cfg_distributed)
                        {
                            // Distributed authenticating instance source:
                            // - Convert authenticating instance.
                            // - Convert connecting instance.
                            h = new Xml.DistributedInstanceSourceSettings
                            {
                                AuthenticatingInstance = new Uri(h_cfg_distributed.AuthenticatingInstance),
                                ConnectingInstance = new Uri(h_cfg_distributed.LastInstance)
                            };
                        }
                        else if (settings_list[0] is Xml.FederatedVPNConfigurationSettings h_cfg_federated)
                        {
                            // Federated authenticating instance source:
                            // - Convert connecting instance.
                            h = new Xml.FederatedInstanceSourceSettings
                            {
                                ConnectingInstance = new Uri(h_cfg_federated.LastInstance)
                            };
                        }

                        Default[InstanceDirectoryId[source_index] + "InstanceSourceSettings"] = new Xml.InstanceSourceSettings() { InstanceSource = h };
                    }
                    #pragma warning restore 0612
                }

                // Versions before 1.0.14 used string dictionary for access token cache.
                if (Default.GetPreviousVersion("AccessTokens") is Xml.SerializableStringDictionary access_tokens)
                    foreach (var token in access_tokens)
                    {
                        var authorization_endpoint = new Uri(token.Key);

                        // Carefully decode access token as it might be damaged or encrypted using another session key.
                        try { Default.AccessTokenCache[authorization_endpoint.GetLeftPart(UriPartial.Authority) + "/"] = AccessToken.FromBase64String(token.Value); }
                        catch { };
                    }
            }
        }

        #endregion
     }
}
