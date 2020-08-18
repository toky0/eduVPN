/*
    eduVPN - VPN for education and research

    Copyright: 2017-2020 The Commons Conservancy eduVPN Programme
    SPDX-License-Identifier: GPL-3.0+
*/

using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace eduVPN.Models
{
    /// <summary>
    /// An organization
    /// </summary>
    public class Organization : BindableBase, JSON.ILoadableItem
    {
        #region Properties

        /// <summary>
        /// Organization ID URL
        /// </summary>
        public Uri Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Uri _id;

        /// <summary>
        /// Secure Internet home server base URL
        /// </summary>
        public Uri SecureInternetBase
        {
            get { return _secure_internet_base; }
            set { SetProperty(ref _secure_internet_base, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Uri _secure_internet_base;

        /// <summary>
        /// Organization name to display in GUI
        /// </summary>
        public string DisplayName
        {
            get { return _display_name; }
            set { SetProperty(ref _display_name, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _display_name;

        /// <summary>
        /// Keywords
        /// </summary>
        public HashSet<string> Keywords
        {
            get { return _keywords; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private HashSet<string> _keywords = new HashSet<string>(StringComparer.CurrentCultureIgnoreCase);

        #endregion

        #region Methods

        /// <inheritdoc/>
        public override string ToString()
        {
            return DisplayName;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = obj as Organization;
            if (!_id.Equals(other._id))
                return false;

            return true;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion

        #region ILoadableItem Support

        /// <summary>
        /// Loads organization from a dictionary object (provided by JSON)
        /// </summary>
        /// <param name="obj">Key/value dictionary with <c>display_name</c>, <c>org_id</c>, <c>secure_internet_home</c>, and <c>keyword_list</c> elements.</param>
        /// <exception cref="eduJSON.InvalidParameterTypeException"><paramref name="obj"/> type is not <c>Dictionary&lt;string, object&gt;</c></exception>
        public void Load(object obj)
        {
            if (!(obj is Dictionary<string, object> obj2))
                throw new eduJSON.InvalidParameterTypeException(nameof(obj), typeof(Dictionary<string, object>), obj.GetType());

            // Set organization ID.
            Id = new Uri(eduJSON.Parser.GetValue<string>(obj2, "org_id"));

            // Set secure internet home server base URL.
            SecureInternetBase = new Uri(eduJSON.Parser.GetValue<string>(obj2, "secure_internet_home"));

            // Set display name.
            DisplayName = eduJSON.Parser.GetLocalizedValue(obj2, "display_name", out string display_name) ? display_name : Id.Host;

            // Set keyword list.
            Keywords.Clear();
            if (eduJSON.Parser.GetLocalizedValue(obj2, "keyword_list", out string keyword_list))
                foreach (var keyword in keyword_list.Split())
                    Keywords.Add(keyword);
        }

        #endregion
    }
}
