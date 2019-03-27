using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Rules
{

    /// <summary>
    /// Represents the root object POSTed from the Rules Engine, if you follow the example.
    /// </summary>
    /// <example>
    /// //Add this to your Node.js Rule. Be sure to replace the secret token with a different value.
    /// request.post({
    ///   url: 'http://YourWebApiEndpoint',
    ///   json: {
    /// user: user,
    /// context: context,
    /// secret_token: "SOMESECRETTOKEN",
    ///   },
    ///   timeout: 15000
    /// }, function(err, response, body){
    ///   user.persistent.your_variable = body.your_variable;
    ///   callback(null, user, context);
    /// });
    /// </example>
    public class RulesRequest
    {

        /// <summary>
        ///  The user object as it comes from the identity provider.
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }

        /// <summary>
        /// An object containing contextual information of the current authentication transaction.
        /// </summary>
        [JsonProperty("context")]
        public RulesContext Context { get; set; }

        /// <summary>
        /// A random string you specify to make sure the request is coming from your Auth0 Rule.
        /// </summary>
        [JsonProperty("secret_token")]
        public string SecretToken { get; set; }

    }
}
