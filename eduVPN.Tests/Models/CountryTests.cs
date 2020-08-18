/*
    eduVPN - VPN for education and research

    Copyright: 2017-2020 The Commons Conservancy eduVPN Programme
    SPDX-License-Identifier: GPL-3.0+
*/

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eduVPN.Models.Tests
{
    [TestClass()]
    public class CountryTests
    {
        [TestMethod()]
        public void CountryTest()
        {
            var culture = new System.Globalization.CultureInfo("en-US");
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = culture;
            System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = culture;
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;

            foreach (var c in Country.Countries)
            {
                var country = new Country(c.Key);
                country.ToString();
            }

            Assert.AreEqual("Antarctica", new Country("AQ").ToString(), "Country name incorrect");
            Assert.AreEqual("Netherlands", new Country("NL").ToString(), "Country name incorrect");
        }
    }
}