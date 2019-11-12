using Auth0.Core.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Auth0.Core.Http
{
    /// <summary>
    /// The communication layer between the API clients and the HTTP REST backend.
    /// </summary>
    public class ApiConnection : IApiConnection, IDisposable
    {
        private readonly string _agent = CreateAgentString();
        private readonly string _baseUrl;
        private readonly HttpClient _httpClient;
        private readonly string _token;
        private bool _disposeHttpClient;

        /// <summary>
        /// Contains information about the last API call made by the connection.
        /// </summary>
        public ApiInfo ApiInfo { get; private set; }

        /// <summary>
        /// Creates a new instance of ApiConnection using an optional <see cref="HttpMessageHandler"/>.
        /// </summary>
        /// <param name="token">A valid Auth0 Management API v2 token.</param>
        /// <param name="baseUrl">The URL of the tenant to manage.</param>
        /// <param name="handler">An optional <see cref="HttpMessageHandler"/> to modify outgoing requests.</param>
        public ApiConnection(string token, string baseUrl, HttpMessageHandler handler = null)
            : this(token, baseUrl, new HttpClient(handler ?? new HttpClientHandler()))
        {
            _disposeHttpClient = true;
        }

        /// <summary>
        /// Creates a new instance of ApiConnection using a provided <see cref="HttpClient"/>.
        /// </summary>
        /// <param name="token">A valid Auth0 Management API v2 token.</param>
        /// <param name="baseUrl">The URL of the tenant to manage.</param>
        /// <param name="httpClient">A <see cref="HttpClient"/> used to send outgoing requests.</param>
        public ApiConnection(string token, string baseUrl, HttpClient httpClient)
        {
            _token = token;
            _baseUrl = baseUrl;
            _disposeHttpClient = false;
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.DefaultRequestHeaders.Add("Auth0-Client", _agent);
        }

        private static string CreateAgentString()
        {
#if NET452
            var target = "NET452";
#endif
#if NETSTANDARD1_4
            var target = "NETSTANDARD1.4";
#endif
#if NETSTANDARD2_0
            var target = "NETSTANDARD2.0";
#endif

            var sdkVersion = typeof(ApiConnection).GetTypeInfo().Assembly.GetName().Version;
            var agentJson = JsonConvert.SerializeObject(new
            {
                name = "Auth0.Net",
                version = sdkVersion.Major + "." + sdkVersion.Minor + "." + sdkVersion.Revision,
                env = new
                {
                    target
                }
            }, Formatting.None);
            return Utils.Base64UrlEncode(Encoding.UTF8.GetBytes(agentJson));
        }

        private void ApplyHeaders(HttpRequestMessage message, IDictionary<string, object> headers)
        {
            // Set the authorization header
            if (headers == null || !headers.ContainsKey("Authorization"))
                // Auth header can be overridden by passing custom value in headers dictionary
                if (!string.IsNullOrEmpty(_token))
                    message.Headers.Add("Authorization", $"Bearer {_token}");

            // Apply other headers
            if (headers != null)
                foreach (var pair in headers)
                    if (pair.Key != null && pair.Value != null)
                        message.Headers.Add(pair.Key, pair.Value.ToString());
        }

        private HttpContent BuildMessageContent(object body, IDictionary<string, object> parameters,
            IList<FileUploadParameter> fileParameters)
        {
            // If user sent in file parameters, then we handle this as a multipart content
            if (fileParameters != null && fileParameters.Count > 0)
            {
                var multipartContent = new MultipartFormDataContent();

                // Add the file parameters
                foreach (var fileParameter in fileParameters)
                    if (string.IsNullOrEmpty(fileParameter.Filename))
                        multipartContent.Add(new StreamContent(fileParameter.FileStream), fileParameter.Key);
                    else
                        multipartContent.Add(new StreamContent(fileParameter.FileStream), fileParameter.Key,
                            fileParameter.Filename);

                // Add the other parameters
                foreach (var parameter in parameters)
                    multipartContent.Add(new StringContent(Uri.EscapeDataString(parameter.Value?.ToString() ?? "")),
                        parameter.Key);

                return multipartContent;
            }
            if (parameters != null)
                return
                    new FormUrlEncodedContent(
                        parameters.Select(
                            kvp => new KeyValuePair<string, string>(kvp.Key, kvp.Value?.ToString() ?? string.Empty)));
            return new StringContent(JsonConvert.SerializeObject(body, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            }), Encoding.UTF8, "application/json");
        }

        private Uri BuildRequestUri(string resource, IDictionary<string, string> queryStrings)
        {
            return Utils.BuildUri(_baseUrl, resource, null, queryStrings);
        }

        private void ExtractApiInfo(HttpResponseMessage response)
        {
            ApiInfo = ApiInfoParser.Parse(response.Headers);
        }

        private async Task HandleErrors(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                ApiError apiError = null;

                // Grab the content
                if (response.Content != null)
                {
                    var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    if (!string.IsNullOrEmpty(responseContent))
                        try
                        {
                            apiError = JsonConvert.DeserializeObject<ApiError>(responseContent);
                            if (apiError.StatusCode == 0)
                                apiError.StatusCode = (int)response.StatusCode;
                        }
                        catch (Exception)
                        {
                            apiError = new ApiError
                            {
                                Error = responseContent,
                                Message = responseContent,
                                StatusCode = (int)response.StatusCode
                            };
                        }
                }

                throw new ApiException(response.StatusCode, apiError);
            }
        }

        /// <summary>
        /// Executes the request. All requests will pass through this method as it will apply the headers, do the JSON
        /// formatting, check for errors on return, etc.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="resource">The resource.</param>
        /// <param name="body">The body.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="fileParameters">The file parameters.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="queryStrings">The query strings.</param>
        /// <param name="converters">The list of <see cref="JsonConverter" /> to use during deserialization.</param>
        /// 
        /// <returns>A <see cref="Task{T}"/> that represents the asynchronous Run operation.</returns>
        public async Task<T> RunAsync<T>(HttpMethod httpMethod, string resource, object body = null,
            IDictionary<string, object> parameters = null, IList<FileUploadParameter> fileParameters = null,
            IDictionary<string, object> headers = null, IDictionary<string, string> queryStrings = null,
            params JsonConverter[] converters) where T : class
        {
            // Build the request URL
            var requestMessage = new HttpRequestMessage(httpMethod, BuildRequestUri(resource, queryStrings));

            // Get the message content
            if (httpMethod != HttpMethod.Get)
                requestMessage.Content = BuildMessageContent(body, parameters, fileParameters);

            // Apply the headers
            ApplyHeaders(requestMessage, headers);

            // Send the request
            var response = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);

            // Extract the relevant API headers
            ExtractApiInfo(response);

            // Handle API errors
            await HandleErrors(response).ConfigureAwait(false);

            // Deserialize the content
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (typeof(T) == typeof(string)) // Let string content pass through
                return (T)(object)content;

            return JsonConvert.DeserializeObject<T>(content, converters);
        }

        /// Disposes of any owned disposable resources such as the ApiConnection.
        /// </summary>
        /// <param name="disposing">Whether we are actually disposing (<see langword="true"/>) or not (<see langword="false")/>.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposeHttpClient && disposing)
            {
                _httpClient.Dispose();
                _disposeHttpClient = false;
            }
        }

        /// <summary>
        /// Dispose of any managed resources such as the <see cref="HttpClient"/>.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
