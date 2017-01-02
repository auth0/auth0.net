using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Newtonsoft.Json;
using System.Text;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Auth0.Core.Http
{
    /// <summary>
    /// The communication layer between the various API clients and the actual API backend.
    /// </summary>
    public class ApiConnection : IApiConnection
    {
        private readonly string baseUrl;
        private readonly string token;
        private readonly DiagnosticsHeader diagnostics;
        private readonly HttpClient httpClient;

        /// <summary>
        /// Contains information about the last API call made by the connection.
        /// </summary>
        public ApiInfo ApiInfo { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiConnection"/> class.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="baseUrl">The base URL of the requests.</param>
        /// <param name="diagnostics">The diagnostics. header</param>
        /// <param name="handler"></param>
        public ApiConnection(string token, string baseUrl, DiagnosticsHeader diagnostics, HttpMessageHandler handler = null)
        {
            this.token = token;
            this.diagnostics = diagnostics;
            this.baseUrl = baseUrl;

            httpClient = new HttpClient(handler ?? new HttpClientHandler());
        }

        /// <summary>
        /// Performs an HTTP DELETE.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource">The resource.</param>
        /// <param name="urlSegments">The URL segments.</param>
        /// <param name="queryStrings"></param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<T> DeleteAsync<T>(string resource, IDictionary<string, string> urlSegments, IDictionary<string, string> queryStrings) where T : class
        {
            return await RunAsync<T>(resource,
                HttpMethod.Delete, 
                null,
                urlSegments,
                queryStrings,
                null,
                null, 
                null, 
                null).ConfigureAwait(false);
        }

        /// <summary>
        /// Performs an HTTP GET.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource">The resource.</param>
        /// <param name="urlSegments">The URL segments.</param>
        /// <param name="queryStrings">The query strings.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="converters">The list of <see cref="JsonConverter"/> to use during deserialization.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<T> GetAsync<T>(string resource, IDictionary<string, string> urlSegments, IDictionary<string, string> queryStrings, IDictionary<string, object> headers, params JsonConverter[] converters) where T : class
        {
            return await RunAsync<T>(resource,
                HttpMethod.Get, 
                null, 
                urlSegments,
                queryStrings,
                null,
                headers, 
                null, 
                converters).ConfigureAwait(false);
        }

        /// <summary>
        /// Performs an HTTP POST.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource">The resource.</param>
        /// <param name="body">The body.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="fileParameters">The file parameters.</param>
        /// <param name="urlSegments">The URL segments.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="queryStrings">The query strings.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<T> PostAsync<T>(string resource, object body, IDictionary<string, object> parameters, IList<FileUploadParameter> fileParameters, IDictionary<string, string> urlSegments, IDictionary<string, object> headers, IDictionary<string, string> queryStrings) where T : class
        {
            return await RunAsync<T>(resource,
                HttpMethod.Post, 
                body, 
                urlSegments,
                queryStrings,
                parameters, 
                headers, 
                fileParameters, 
                null).ConfigureAwait(false);
        }

        /// <summary>
        /// Performs an HTTP PATCH.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource">The resource.</param>
        /// <param name="body">The body.</param>
        /// <param name="urlSegments">The URL segments.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<T> PatchAsync<T>(string resource, object body, Dictionary<string, string> urlSegments) where T : class
        {
            return await RunAsync<T>(resource,
                new HttpMethod("PATCH"), 
                body,
                urlSegments,
                null,
                null,
                null, 
                null, 
                null).ConfigureAwait(false);
        }

        /// <summary>
        /// Executes the request. All requests will pass through this method as it will apply the headers, do the JSON formatting, check for errors on return, etc.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource">The resource.</param>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="body">The body.</param>
        /// <param name="urlSegments">The URL segments.</param>
        /// <param name="queryStrings">The query strings.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="fileParameters">The file parameters.</param>
        /// <param name="converters">The list of <see cref="JsonConverter"/> to use during deserialization.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        private async Task<T> RunAsync<T>(string resource, HttpMethod httpMethod, object body, IDictionary<string, string> urlSegments, IDictionary<string, string> queryStrings, IDictionary<string, object> parameters, IDictionary<string, object> headers, IList<FileUploadParameter> fileParameters, params JsonConverter[] converters) where T : class
        {
            // Build the request URL
            var requestMessage = new HttpRequestMessage(httpMethod, BuildRequestUri(resource, urlSegments, queryStrings));

            // Get the message content
            if (httpMethod != HttpMethod.Get)
                requestMessage.Content = BuildMessageContent(body, parameters, fileParameters);

            // Apply the headers
            ApplyHeaders(requestMessage, headers);

            // Send the request
            var response = await httpClient.SendAsync(requestMessage).ConfigureAwait(false);

            // Handle API errors
            await HandleErrors(response);

            // Extract the relevate API headers
            ExtractApiInfo(response);

            // Deserialize the content
            string content = await response.Content.ReadAsStringAsync();

            if (typeof (T)== typeof (string)) // Let string content pass throug
                return (T)(object)content;

            return JsonConvert.DeserializeObject<T>(content, converters);
        }

        private void ExtractApiInfo(HttpResponseMessage response)
        {
            ApiInfo = ApiInfoParser.Parse(response.Headers);
        }

        private void ApplyHeaders(HttpRequestMessage message, IDictionary<string, object> headers)
        {
            // Add the diagnostics header, unless user explicitly opted out of it
            if (!object.ReferenceEquals(diagnostics, DiagnosticsHeader.Suppress))
                message.Headers.Add("Auth0-Client", diagnostics.ToString());

            // Set the authorization header
            if (headers == null || (headers != null && !headers.ContainsKey("Authorization"))) // Auth header can be overriden by passing custom value in headers dictionary
            {
                if (!string.IsNullOrEmpty(token))
                    message.Headers.Add("Authorization", string.Format("Bearer {0}", token));
            }

            // Add the user agent
            message.Headers.Add("User-Agent", ".NET/PCL");

            // Apply other headers
            if (headers != null)
            {
                foreach (var pair in headers)
                {
                    if (pair.Key != null && pair.Value != null)
                        message.Headers.Add(pair.Key, pair.Value.ToString());
                }
            }
        }

        /// <summary>
        /// Builds the content of the message. This will build the appropriate <see cref="HttpContent"/> for the request based on the type of the parameters passed in.
        /// </summary>
        /// <param name="body">The body.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="fileParameters">The file parameters.</param>
        /// <returns>HttpContent.</returns>
        private HttpContent BuildMessageContent(object body, IDictionary<string, object> parameters, IList<FileUploadParameter> fileParameters)
        {
            // If user sent in file parameters, then we handle this as a multipart content
            if (fileParameters != null && fileParameters.Count > 0)
            {
                var multipartContent = new MultipartFormDataContent();

                // Add the file parameters
                foreach (var fileParameter in fileParameters)
                {
                    if (string.IsNullOrEmpty(fileParameter.Filename))
                    {
                        multipartContent.Add(new StreamContent(fileParameter.FileStream), fileParameter.Key);
                    }
                    else
                    {
                        multipartContent.Add(new StreamContent(fileParameter.FileStream), fileParameter.Key, fileParameter.Filename);
                    }
                }

                // Add the other parameters
                foreach (var parameter in parameters)
                {
                    multipartContent.Add(new StringContent(Uri.EscapeDataString(parameter.Value?.ToString() ?? "")), parameter.Key);
                }

                return multipartContent;
            }
            else if (parameters != null)
            {
                return new FormUrlEncodedContent(parameters.Select(kvp => new KeyValuePair<string, string>(kvp.Key, kvp.Value?.ToString() ?? string.Empty)));
            }
            else // Serialize the body
                return new StringContent(JsonConvert.SerializeObject(body, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }), Encoding.UTF8, "application/json");
        }

        /// <summary>
        /// Builds up the URL for the request by substituting values for URL segments and adding query string parameters.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <param name="urlSegments">The URL segments.</param>
        /// <param name="queryStrings">The query strings.</param>
        /// <returns>Uri.</returns>
        private Uri BuildRequestUri(string resource, IDictionary<string, string> urlSegments, IDictionary<string, string> queryStrings)
        {
            return Utils.BuildUri(baseUrl, resource, urlSegments, queryStrings);
        }

        /// <summary>
        /// Handles errors returned from the API. It will check the response code, deserialize any relevant JSON error payload and throw an appropriate exception.
        /// </summary>
        /// <param name="response">The <see cref="HttpResponseMessage"/> returned from the API.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        /// <exception cref="ApiException"></exception>
        private async Task HandleErrors(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                ApiError apiError = null;

                // Grab the content
                if (response.Content != null)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(responseContent))
                    {
                        try
                        {
                            apiError = JsonConvert.DeserializeObject<ApiError>(responseContent);
                            if (apiError.StatusCode == 0)
                                apiError.StatusCode = (int)response.StatusCode;
                        }
                        catch (Exception ex)
                        {
                            apiError = new ApiError
                            {
                                Error = responseContent,
                                Message = responseContent,
                                StatusCode = (int) response.StatusCode
                            };
                        }
                    }
                }

                throw new ApiException(response.StatusCode, apiError);
            }
        }
    }
}