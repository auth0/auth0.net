using Newtonsoft.Json;

namespace Auth0.Core.Models
{
    public class ClientCreateRequest : ClientBase
    {
        /// <summary>
        ///     True if the client is a heroku application, false otherwise
        /// </summary>
        [JsonProperty("is_heroku_app")]
        public bool? IsHerokuApp { get; set; }
    }
}