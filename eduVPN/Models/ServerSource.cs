/*
    eduVPN - VPN for education and research

    Copyright: 2017-2020 The Commons Conservancy eduVPN Programme
    SPDX-License-Identifier: GPL-3.0+
*/

using Prism.Mvvm;
using System.Collections.Generic;

namespace eduVPN.Models
{
    /// <summary>
    /// An eduVPN server source
    /// </summary>
    public class ServerSource : BindableBase, JSON.ILoadableItem
    {
        #region Properties

        /// <summary>
        /// List of all available servers
        /// </summary>
        public Dictionary<System.Uri, Instance> ServerList { get; } = new Dictionary<System.Uri, Instance>();

        #endregion

        #region ILoadableItem Support

        /// <summary>
        /// Loads server source from a dictionary object (provided by JSON)
        /// </summary>
        /// <param name="obj">Key/value dictionary with <c>server_list</c> and other optional elements</param>
        /// <exception cref="eduJSON.InvalidParameterTypeException"><paramref name="obj"/> type is not <c>Dictionary&lt;string, object&gt;</c></exception>
        public virtual void Load(object obj)
        {
            if (!(obj is Dictionary<string, object> obj2))
                throw new eduJSON.InvalidParameterTypeException(nameof(obj), typeof(Dictionary<string, object>), obj.GetType());

            // Parse all servers listed.
            ServerList.Clear();
            foreach (var el in eduJSON.Parser.GetValue<List<object>>(obj2, "server_list"))
            {
                var server = new Instance();
                server.Load(el);
                ServerList.Add(server.Base, server);
            }
        }

        #endregion
    }
}
