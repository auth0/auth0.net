using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Auth0.Core
{
    /// <summary>
    /// Represents a delegated refresh token.
    /// </summary>
    public class DelegatedRefreshToken : DelegatedTokenBase
    {
        /// <summary>
        /// The refresh token.
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }


    }
}
