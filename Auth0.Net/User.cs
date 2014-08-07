using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Auth0
{
    public class Identity
    {
        [JsonProperty(PropertyName ="access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName ="provider")]
        public string Provider { get; set; }

        [JsonProperty(PropertyName ="user_id")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName ="connection")]
        public string Connection { get; set; }

        [JsonProperty(PropertyName ="isSocial")]
        public bool IsSocial { get; set; }
    }

    public class User
    {
        [JsonProperty(PropertyName ="identities")]
        public IEnumerable<Identity> Identities { get; set; }

        [JsonProperty(PropertyName ="email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName ="family_name")]
        public string FamilyName { get; set; }

        [JsonProperty(PropertyName ="gender")]
        public string Gender { get; set; }

        [JsonProperty(PropertyName ="given_name")]
        public string GivenName { get; set; }

        [JsonProperty(PropertyName ="lastLogin")]
        public string LastLogin { get; set; }

        [JsonProperty(PropertyName ="locale")]
        public string Locale { get; set; }

        [JsonProperty(PropertyName ="loginsCount")]
        public string LoginsCount { get; set; }

        [JsonProperty(PropertyName ="name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName ="nickname")]
        public string Nickname { get; set; }

        [JsonProperty(PropertyName ="picture")]
        public string Picture { get; set; }

        [JsonProperty(PropertyName ="user_id")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "blocked")]
        public bool Blocked { get; set; }
    }
}