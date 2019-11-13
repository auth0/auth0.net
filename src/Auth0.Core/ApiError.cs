using Auth0.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

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

        public static async Task<ApiError> Parse(HttpResponseMessage response)
        {
            if (response.Content == null)
                return null;

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (string.IsNullOrEmpty(content))
                return null;

            try
            {
                return JsonConvert.DeserializeObject<ApiError>(content);
            }
            catch (Exception)
            {
                return new ApiError
                {
                    Error = content,
                    Message = content
                };
            }
        }
    }
}