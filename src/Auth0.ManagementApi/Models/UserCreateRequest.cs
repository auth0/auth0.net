using Auth0.Core;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class UserCreateRequest : UserBase
    {

        /// <summary>
        /// Gets or sets the connection the user belongs to.
        /// </summary>
        [JsonProperty("connection")]
        public string Connection { get; set; }

        /// <summary>
        /// Gets or sets the user's password. This is mandatory on non-SMS connections.
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }

    }

}