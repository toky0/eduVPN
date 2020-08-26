/*
    eduVPN - VPN for education and research

    Copyright: 2017-2020 The Commons Conservancy eduVPN Programme
    SPDX-License-Identifier: GPL-3.0+
*/

using eduVPN.JSON;
using eduVPN.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Threading.Tasks;

namespace eduVPN.Models.Tests
{
    [TestClass()]
    public class ServerSourceTests
    {
        [TestMethod()]
        public void ServerSourceTest()
        {
            const string server_source_json = @"{
  ""server_list"": [
    {
                ""server_type"": ""institute_access"",
      ""base_url"": ""https://sunset.nuonet.fr/"",
      ""display_name"": ""CNOUS"",
      ""support_contact"": [
        ""mailto:support-technique-nuo@listes.nuonet.fr""
      ]
    },
    {
                ""server_type"": ""secure_internet"",
      ""base_url"": ""https://eduvpn.rash.al/"",
      ""country_code"": ""AL"",
      ""support_contact"": [
        ""mailto:helpdesk@rash.al""
      ]
    }
  ]
}";
            var server_source_ia = new ServerSource();
            server_source_ia.LoadJSON(server_source_json);

            var srv = server_source_ia.ServerList[new Uri("https://sunset.nuonet.fr/")];
            Assert.AreEqual(InstanceSourceType.InstituteAccess, srv.Type, "Server type incorrect");
        }

        [TestMethod()]
        public void ServerSourceNetworkTest()
        {
            // .NET 3.5 allows Schannel to use SSL 3 and TLS 1.0 by default. Instead of hacking user computer's registry, extend it in runtime.
            // System.Net.SecurityProtocolType lacks appropriate constants prior to .NET 4.5.
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)0x0C00;
            var source = new ResourceRef()
            {
                Uri = new Uri("https://disco.eduvpn.org/v2/server_list.json"),
                PublicKeys = new MinisignPublicKeyDictionary()
            };
            source.PublicKeys.Add("RWRtBSX1alxyGX+Xn3LuZnWUT0w//B6EmTJvgaAxBMYzlQeI+jdrO6KF");

            // Load list of servers.
            var server_source_json = Xml.Response.Get(source);
            var server_source_ia = new ServerSource();
            server_source_ia.LoadJSON(server_source_json.Value);

            // Load all servers APIs.
            Parallel.ForEach(server_source_ia.ServerList.Values, srv =>
            {
                var uri_builder = new UriBuilder(srv.Base);
                uri_builder.Path += "info.json";
                try
                {
                    new Models.InstanceEndpoints().LoadJSON(Xml.Response.Get(uri_builder.Uri).Value);
                }
                catch (AggregateException ex)
                {
                    if (ex.InnerException is WebException ex_web && (ex_web.Status == WebExceptionStatus.ConnectFailure || ex_web.Status == WebExceptionStatus.SecureChannelFailure || ex_web.Status == WebExceptionStatus.Timeout))
                    {
                        // Ignore connection failure WebException(s), as some servers are not publicly available or have other issues.
                    }
                    else
                        throw;
                }
            });

            // Re-load list of servers.
            server_source_json = Xml.Response.Get(
                res: source,
                previous: server_source_json);
        }
    }
}