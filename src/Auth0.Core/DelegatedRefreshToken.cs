using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Auth0.Core
{
    public class DelegatedRefreshToken : DelegatedTokenBase
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }


    }
}
