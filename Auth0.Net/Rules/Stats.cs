using Newtonsoft.Json;

namespace Auth0.Rules
{

    /// <summary>
    /// An object containing specific user stats.
    /// </summary>
    [JsonObject]
    public partial class Stats
    {

        /// <summary>
        /// The number of times the User has logged in.
        /// </summary>
        [JsonProperty("loginsCount")]
        public int LoginCount { get; set; }
    }
}