using Auth0.Core;
using Auth0.Core.ApiClients;
using Auth0.ManagementApi.Client.Diagnostics;
using Auth0.ManagementApi.Client.Exceptions;
using Newtonsoft.Json;
using PortableRest;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Client
{
    public class ApiConnection : RestClient, IApiConnection
    {
        private readonly string token;
        private readonly DiagnosticsHeader diagnostics;

        public ApiConnection(string token, string baseUrl, DiagnosticsHeader diagnostics)
        {
            this.token = token;
            this.diagnostics = diagnostics;
            BaseUrl = baseUrl;

            // Ensure user agent is set on all requests
            SetUserAgent<ApiConnection>();
        }

        public async Task<T> DeleteAsync<T>(string resource, IDictionary<string, string> urlSegments) where T : class
        {
            return await RunAsync<T>(resource,
                HttpMethod.Delete,
                ContentTypes.Json,
                urlSegments,
                null,
                null,
                null, 
                null).ConfigureAwait(false);
        }

        public async Task<T> GetAsync<T>(string resource, IDictionary<string, string> urlSegments, IDictionary<string, string> queryStrings) where T : class
        {
            return await RunAsync<T>(resource,
                HttpMethod.Get,
                ContentTypes.Json, 
                urlSegments,
                queryStrings,
                null,
                null, 
                null).ConfigureAwait(false);
        }

        public async Task<T> PostAsync<T>(string resource, ContentTypes contentTypes, object body, IDictionary<string, object> parameters, IList<FileUploadParameter> fileParameters, IDictionary<string, string> urlSegments, IDictionary<string, object> headers) where T : class
        {
            return await RunAsync<T>(resource,
                HttpMethod.Post,
                contentTypes, 
                urlSegments,
                null,
                parameters ??
                new Dictionary<string, object>
                {
                    { "body", body}
                }, 
                headers, 
                fileParameters).ConfigureAwait(false);
        }

        public async Task<T> PatchAsync<T>(string resource, object body, Dictionary<string, string> urlSegments) where T : class
        {
            return await RunAsync<T>(resource,
                new HttpMethod("PATCH"), 
                ContentTypes.Json,
                urlSegments,
                null,
                new Dictionary<string, object>
                {
                    { "body", body}
                },
                null, 
                null).ConfigureAwait(false);
        }

        private async Task<T> RunAsync<T>(string resource, HttpMethod httpMethod, ContentTypes contentTypes, IDictionary<string, string> urlSegments, IDictionary<string, string> queryStrings, IDictionary<string, object> parameters, IDictionary<string, object> headers, IList<FileUploadParameter> fileParameters) where T : class
        {
            var request = new RestRequest(resource, httpMethod)
            {
                ContentType = contentTypes,
                JsonSerializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }
            };

            // Apply the URL Segments
            if (urlSegments != null)
            {
                foreach (var pair in urlSegments)
                {
                    if (pair.Key != null && pair.Value != null)
                        request.AddUrlSegment(pair.Key, pair.Value);
                }
            }

            // Apply the Query strings
            if (queryStrings != null)
            {
                foreach (var pair in queryStrings)
                {
                    if (pair.Key != null && pair.Value != null)
                        request.AddQueryString(pair.Key, pair.Value);
                }
            }

            // Apply the Parameters
            if (parameters != null)
            {
                foreach (var pair in parameters)
                {
                    if (pair.Key != null && pair.Value != null)
                        request.AddParameter(pair.Key, pair.Value);
                }
            }

            // Apply the file parameters
            if (fileParameters != null)
            {
                foreach (var parameter in fileParameters)
                {
                    request.AddFileParameter(parameter.Key, parameter.FileStream, parameter.Filename);
                }
            }

            // Add the diagnostics header, unless user explicitly opted out of it
            if (!object.ReferenceEquals(diagnostics, DiagnosticsHeader.Suppress))
                request.AddHeader("Auth0-Client", diagnostics.ToString());

            // Set the authorization header
            if (headers == null || (headers != null && !headers.ContainsKey("Authorization"))) // Auth header can be overriden by passing custom value in headers dictionary
                request.AddHeader("Authorization", string.Format("Bearer {0}", token));

            // Apply other headers
            if (headers != null)
            {
                foreach (var pair in headers)
                {
                    if (pair.Key != null && pair.Value != null)
                        request.AddHeader(pair.Key, pair.Value);
                }
            }

            // Send the request
            var response = await SendAsync<T>(request).ConfigureAwait(false);

            await HandleErrors(response);

            return response.Content;
        }

        private async Task HandleErrors<T>(RestResponse<T> response) where T : class
        {
            if (!response.HttpResponseMessage.IsSuccessStatusCode)
            {
                if (response.Exception != null)
                    throw new ApiException(response.Exception.Message, response.Exception);;

                ApiError apiError = null;

                // Grab the content
                if (response.HttpResponseMessage.Content != null)
                {
                    string responseContent = await response.HttpResponseMessage.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(responseContent))
                    {
                        apiError = JsonConvert.DeserializeObject<ApiError>(responseContent, new JsonSerializerSettings
                        {
                            // Suppress any parsing errors of payload
                            Error = (sender, args) => { args.ErrorContext.Handled = true; }
                        });
                    }
                }

                throw new ApiException(response.HttpResponseMessage.StatusCode, apiError);
            }
        }
    }
}