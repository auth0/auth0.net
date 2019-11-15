using Auth0.Core.Serialization;
using Newtonsoft.Json;
using System;

namespace Auth0.Core
{
    /// <summary>
    /// Contains information about an error returned from the API.
    /// </summary>
    [JsonConverter(typeof(ApiErrorConverter))]
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

        public static ApiError ParseOrDefault(string responseContent)
        {
            if (String.IsNullOrEmpty(responseContent))
                return default;

            try
            {
                return JsonConvert.DeserializeObject<ApiError>(responseContent);
            }
            catch (Exception)
            {
                return new ApiError
                {
                    Error = responseContent,
                    Message = responseContent
                };
            }
        }
    }
}