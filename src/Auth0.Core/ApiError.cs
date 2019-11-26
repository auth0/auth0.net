using Auth0.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.Core
{
    /// <summary>
    /// Error information captured from a failed API request.
    /// </summary>
    [JsonConverter(typeof(ApiErrorConverter))]
    public class ApiError
    {
        /// <summary>
        /// Description of the failing HTTP Status Code.
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; }

        /// <summary>
        /// Error code returned by the API.
        /// </summary>
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Description of the error.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Parse a <see cref="HttpResponseMessage"/> into an <see cref="ApiError"/> asynchronously.
        /// </summary>
        /// <param name="response"><see cref="HttpResponseMessage"/> to parse.</param>
        /// <returns><see cref="Task"/> representing the operation and associated <see cref="ApiError"/> on
        /// successful completion.</returns>
        public static async Task<ApiError> Parse(HttpResponseMessage response)
        {
            if (response == null || response.Content == null)
                return null;

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (String.IsNullOrEmpty(content))
                return null;

            try
            {
                return JsonConvert.DeserializeObject<ApiError>(content);
            }
            catch (JsonException)
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