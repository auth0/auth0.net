using System;
using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a Pushed Authorization Request response.
    /// </summary>
    public class PushedAuthorizationRequestResponse
    {
        /// <summary>
        /// The request URI corresponding to the authorization request posted.
        /// </summary>
        /// <remarks>
        /// This URI is a single-use reference to the respective request data in the subsequent authorization request.
        /// </remarks>
        [JsonProperty("request_uri")]
        public Uri RequestUri { get; set; }

        /// <summary>
        /// A number that represents the lifetime of the request URI in seconds as a positive integer.
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

    }
}