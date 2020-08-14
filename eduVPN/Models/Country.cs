/*
    eduVPN - VPN for education and research

    Copyright: 2017-2020 The Commons Conservancy eduVPN Programme
    SPDX-License-Identifier: GPL-3.0+
*/

using Prism.Mvvm;
using System.Diagnostics;

namespace eduVPN.Models
{
    /// <summary>
    /// Country
    /// </summary>
    public class Country : BindableBase
    {
        /// <summary>
        /// Two-letter ISO 3166 country code
        /// </summary>
        public string Code
        {
            get { return _code; }
            set { SetProperty(ref _code, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _code;

        /// <summary>
        /// Create a country
        /// </summary>
        /// <param name="code">Two-letter ISO 3166 country code</param>
        public Country(string code)
        {
            _code = code;
        }
    }
}
