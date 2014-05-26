using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.Rules
{

    /// <summary>
    ///  The user object as it comes from the identity provider.
    /// </summary>
    [JsonObject]
    public partial class Auth0User
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("clientID")]
        public string ClientId { get; set; }

        /// <summary>
        /// Email of the user.
        /// </summary>
        /// <remarks>
        /// If available from provider. E.g. twitter won't give you one. If using facebook or windows live, you will have to ask for extra user consent.
        /// </remarks>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        [JsonProperty("emails")]
        public List<string> Emails { get; set; }

        /// <summary>
        /// First name of the user (if available).
        /// </summary>
        [JsonProperty("given_name")]
        public string GivenName { get; set; }

        /// <summary>
        /// Last name of the user (if available).
        /// </summary>
        [JsonProperty("family_name")]
        public string FamilyName { get; set; }
        
        /// <summary>
        /// This is used when the user associates one account with a new one (e.g.: Google and Facebook different accounts, same person).
        /// </summary>
        [JsonProperty("identities")]
        public List<Identity> Identities { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("locale")]
        public string Locale { get; set; }

        /// <summary>
        /// The full name of the user (e.g.: John Foo). ALWAYS GENERATED.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// User name (if available, might not be unique across identity providers). ALWAYS GENERATED
        /// </summary>
        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        /// <summary>
        /// URL pointing to the user picture (if not available, will use gravatar.com with the email). ALWAYS GENERATED
        /// </summary>
        [JsonProperty("picture")]
        public string Picture { get; set; }

        /// <summary>
        /// A unique identifier of the user per identity provider, same for all apps (e.g.: google-oauth2|103547991597142817347). ALWAYS GENERATED
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("global_client_id")]
        public string GlobalClientId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("persistent")]
        public dynamic Persistent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("roles")]
        public List<string> Roles { get; set; }

    }
}