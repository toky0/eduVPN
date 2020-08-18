/*
    eduVPN - VPN for education and research

    Copyright: 2017-2020 The Commons Conservancy eduVPN Programme
    SPDX-License-Identifier: GPL-3.0+
*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace eduVPN.Models.Tests
{
    [TestClass()]
    public class OrganizationTests
    {
        [TestMethod()]
        public void OrganizationTest()
        {
            var culture = new System.Globalization.CultureInfo("en-US");
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = culture;
            System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = culture;
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;

            Organization org;

            org = new Organization();
            org.Load(new Dictionary<string, object>
                {
                    { "org_id", "https://idp.surfnet.nl" },
                    { "secure_internet_home", "https://nl.eduvpn.org/" },
                });
            Assert.AreEqual(new Uri("https://idp.surfnet.nl/"), org.Id, "ID URL incorrect");
            Assert.AreEqual(new Uri("https://nl.eduvpn.org/"), org.SecureInternetBase, "Secure internet home server base URL incorrect");
            Assert.AreEqual("idp.surfnet.nl", org.DisplayName, "Display name incorrect");

            org = new Organization();
            org.Load(new Dictionary<string, object>
                {
                    { "org_id", "https://idp.surfnet.nl" },
                    { "secure_internet_home", "https://nl.eduvpn.org/" },
                    {  "display_name", new Dictionary<string, object>() {
                        { "nl", "SURFnet bv" },
                        { "en", "SURFnet bv" },
                    }},
                    { "keyword_list", new Dictionary<string, object>() {
                        { "en", "SURFnet bv SURF konijn surf surfnet powered by" },
                        { "nl", "SURFnet bv SURF konijn powered by" },
                    }}
                });
            Assert.AreEqual(new Uri("https://idp.surfnet.nl/"), org.Id, "ID URL incorrect");
            Assert.AreEqual(new Uri("https://nl.eduvpn.org/"), org.SecureInternetBase, "Secure internet home server base URL incorrect");
            Assert.AreEqual("SURFnet bv", org.DisplayName, "Display name incorrect");

            // Test issues.
            try
            {
                org = new Organization();
                org.Load(new Dictionary<string, object>
                {
                    { "secure_internet_home", "https://nl.eduvpn.org/" },
                });
                Assert.Fail("Missing ID URL tolerated");
            } catch (eduJSON.MissingParameterException) {}

            try
            {
                org = new Organization();
                org.Load(new Dictionary<string, object>
                {
                    { "org_id", "https://idp.surfnet.nl" },
                });
                Assert.Fail("Missing secure internet home server base URL tolerated");
            } catch (eduJSON.MissingParameterException) {}
        }
    }
}
