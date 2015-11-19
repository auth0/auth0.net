using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Auth0.Core
{
    public class IdTokenDelegationRequest : DelegationRequestBase
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id_token")]
        public string IdToken { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceClientId"></param>
        /// <param name="targetClientId"></param>
        /// <param name="idToken"></param>
        public IdTokenDelegationRequest(string sourceClientId, string targetClientId, string idToken) : base(sourceClientId, targetClientId)
        {
            IdToken = IdToken;
        }


    }
}
