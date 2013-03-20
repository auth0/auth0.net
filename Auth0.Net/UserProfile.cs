using System.Collections.Generic;
using JsonFx.Json;

namespace Auth0
{
    public class UserProfile
    {
        public string Email { get; set; }

        [JsonName("family_name")]
        public string FamilyName { get; set; }

        public string Gender { get; set; }

        [JsonName("given_name")]
        public string GivenName { get; set; }
        public string Locale { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Picture { get; set; }

        [JsonName("user_id")]
        public string UserId { get; set; }

        public IEnumerable<Identity> Identities { get; set; }

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
    }
}
