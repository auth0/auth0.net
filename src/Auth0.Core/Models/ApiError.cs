using Newtonsoft.Json;

namespace Auth0.Core.Models
{
    /// <summary>
    /// Contains information about an error returned from the API.
    /// </summary>
    public class ApiError
    {
        /// <summary>
        /// The error description for the HTTP Status Code
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; }

        /// <summary>
        /// The error code returned by the API
        /// </summary>
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// The desription for the error.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// The HTTP Status code.
        /// </summary>
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }
    }
}