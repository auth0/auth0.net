using System.Collections.Generic;
using JsonFx.Json;

namespace Auth0
{
    public class Identity
    {
        [JsonName("access_token")]
        public string AccessToken { get; set; }

        [JsonName("provider")]
        public string Provider { get; set; }

        [JsonName("user_id")]
        public string UserId { get; set; }

        [JsonName("connection")]
        public string Connection { get; set; }

        [JsonName("isSocial")]
        public bool IsSocial { get; set; }
    }

    public class User
    {
        [JsonName("identities")]
        public IEnumerable<Identity> Identities { get; set; }

        [JsonName("email")]
        public string Email { get; set; }

        [JsonName("family_name")]
        public string FamilyName { get; set; }

        [JsonName("gender")]
        public string Gender { get; set; }

        [JsonName("given_name")]
        public string GivenName { get; set; }

        [JsonName("lastLogin")]
        public string LastLogin { get; set; }

        [JsonName("locale")]
        public string Locale { get; set; }

        [JsonName("loginsCount")]
        public string LoginsCount { get; set; }

        [JsonName("name")]
        public string Name { get; set; }

        [JsonName("nickname")]
        public string Nickname { get; set; }

        [JsonName("picture")]
        public string Picture { get; set; }

        [JsonName("user_id")]
        public string UserId { get; set; }
    }
}