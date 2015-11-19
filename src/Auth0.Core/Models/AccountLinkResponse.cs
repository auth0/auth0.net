using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Auth0.Core.Models
{
    public class AccountLinkResponse
    {
        [JsonProperty("profileData")]
        public AccountLinkResponseProfiledata ProfileData { get; set; }

        [JsonProperty("connection")]
        public string Connection { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("isSocial")]
        public bool IsSocial { get; set; }
    }

    public class AccountLinkResponseProfiledata
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("email_verified")]
        public bool EmailVerified { get; set; }
    }
}
