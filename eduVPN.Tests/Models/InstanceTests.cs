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
    public class InstanceTests
    {
        [TestMethod()]
        public void InstanceTest()
        {
            Instance srv;

            srv = new Instance();
            srv.Load(new Dictionary<string, object>
                {
                    { "server_type", "institute_access" },
                    { "base_url", "https://surf.eduvpn.nl/" }
                });
            Assert.AreEqual(new Uri("https://surf.eduvpn.nl/"), srv.Base, "Base URI incorrect");
            Assert.AreEqual("surf.eduvpn.nl", srv.DisplayName, "Display name incorrect");

            srv = new Instance();
            srv.Load(new Dictionary<string, object>
                {
                    { "server_type", "institute_access" },
                    { "base_url", "https://surf.eduvpn.nl/" },
                    { "display_name", "SURF" }
                });
            Assert.AreEqual(new Uri("https://surf.eduvpn.nl/"), srv.Base, "Base URI incorrect");
            Assert.AreEqual("SURF", srv.DisplayName, "Display name incorrect");

            srv = new Instance();
            srv.Load(new Dictionary<string, object>
                {
                    { "server_type", "secure_internet" },
                    { "base_url", "https://surf.eduvpn.nl/" },
                    { "country_code", "NL" },
                    { "support_contact", new List<object>(){ "mailto:info@surf.nl" } },
                });
            Assert.AreEqual(new Uri("https://surf.eduvpn.nl/"), srv.Base, "Base URI incorrect");
            Assert.AreEqual("surf.eduvpn.nl", srv.DisplayName, "Display name incorrect");
            Assert.AreEqual("NL", srv.Country.Code, "Country code incorrect");

            // Test issues.
            try
            {
                srv = new Instance();
                srv.Load(new Dictionary<string, object>
                    {
                        { "base_url", "https://surf.eduvpn.nl/" },
                        { "display_name", "SURF" },
                    });
                Assert.Fail("Missing server type tolerated");
            } catch (eduJSON.MissingParameterException) {}

            try
            {
                srv = new Instance();
                srv.Load(new Dictionary<string, object>
                    {
                        { "server_type", "foo bar" },
                        { "base_url", "https://surf.eduvpn.nl/" },
                        { "display_name", "SURF" },
                    });
                Assert.Fail("Invalid server type tolerated");
            } catch (ArgumentOutOfRangeException) {}

            try
            {
                srv = new Instance();
                srv.Load(new Dictionary<string, object>
                    {
                        { "server_type", "secure_internet" },
                        { "display_name", "SURF" },
                    });
                Assert.Fail("Missing base URL tolerated");
            }
            catch (eduJSON.MissingParameterException) { }
        }
    }
}