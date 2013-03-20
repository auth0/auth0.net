using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Auth0
{
    [DataContract]
    public class UserProfile
    {
        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "family_name")]
        public string FamilyName { get; set; }

        [DataMember(Name = "gender")]
        public string Gender { get; set; }

        [DataMember(Name = "given_name")]
        public string GivenName { get; set; }

        [DataMember(Name = "locale")]
        public string Locale { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "nickname")]
        public string Nickname { get; set; }

        [DataMember(Name = "picture")]
        public string Picture { get; set; }

        [DataMember(Name ="user_id")]
        public string UserId { get; set; }

        [DataMember(Name = "identities")]
        public IEnumerable<Identity> Identities { get; set; }

        public class Identity
        {
            [DataMember(Name ="access_token")]
            public string AccessToken { get; set; }
            [DataMember(Name ="provider")]
            public string Provider { get; set; }
            [DataMember(Name ="user_id")]
            public string UserId { get; set; }
            [DataMember(Name ="connection")]
            public string Connection { get; set; }
            [DataMember(Name ="isSocial")]
            public bool IsSocial { get; set; }
        }
    }
}
