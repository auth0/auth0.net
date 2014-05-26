using Newtonsoft.Json;

namespace Auth0.Rules
{

    /// <summary>
    /// Represents the root object, if you follow the example.
    /// </summary>
    /// <example>
    /// //Add this to your Node.js Rule.
    /// request.post({
    ///   url: 'http://YourWebApiEndpoint',
    ///   json: {
    ///     user: user,
    ///     context: context,
    ///     secretToken: "Uybh;osadhf;ohu(HOihjhn",
    ///   },
    ///   timeout: 15000
    /// }, function(err, response, body){
    ///   user.persistent.your_variable = body.your_variable;
    ///   callback(null, user, context);
    /// });
    /// </example>
    [JsonObject]
    public partial class Auth0Request
    {

        /// <summary>
        ///  The user object as it comes from the identity provider.
        /// </summary>
        [JsonProperty("user")]
        public Auth0User User { get; set; }

        /// <summary>
        /// An object containing contextual information of the current authentication transaction.
        /// </summary>
        [JsonProperty("context")]
        public Context Context { get; set; }

        /// <summary>
        /// A random string you specify to make sure the request is coming from your Auth0 Rule.
        /// </summary>
        [JsonProperty("secretToken")]
        public string SecretToken { get; set; }
    }

}