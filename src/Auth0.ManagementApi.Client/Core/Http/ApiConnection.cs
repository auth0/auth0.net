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
    public class ApiConnection : IApiConnection
    {
        private readonly string baseUrl;
        private readonly string token;
        private readonly DiagnosticsHeader diagnostics;

        public ApiConnection(string token, string baseUrl, DiagnosticsHeader diagnostics)
        {
            this.token = token;
            this.diagnostics = diagnostics;
            this.baseUrl = baseUrl;
        }

        public async Task<T> DeleteAsync<T>(string resource, IDictionary<string, string> urlSegments) where T : class
        {
            return await RunAsync<T>(resource,
                HttpMethod.Delete, 
                null,
                urlSegments,
                null,
                null,
                null, 
                null).ConfigureAwait(false);
        }

        public async Task<T> GetAsync<T>(string resource, IDictionary<string, string> urlSegments, IDictionary<string, string> queryStrings, IDictionary<string, object> headers) where T : class
        {
            return await RunAsync<T>(resource,
                HttpMethod.Get, 
                null, 
                urlSegments,
                queryStrings,
                null,
                headers, 
                null).ConfigureAwait(false);
        }

        public async Task<T> PostAsync<T>(string resource, object body, IDictionary<string, object> parameters, IList<FileUploadParameter> fileParameters, IDictionary<string, string> urlSegments, IDictionary<string, object> headers, IDictionary<string, string> queryStrings) where T : class
        {
            return await RunAsync<T>(resource,
                HttpMethod.Post, 
                body, 
                urlSegments,
                queryStrings,
                parameters, 
                headers, 
                fileParameters).ConfigureAwait(false);
        }

        public async Task<T> PatchAsync<T>(string resource, object body, Dictionary<string, string> urlSegments) where T : class
        {
            return await RunAsync<T>(resource,
                new HttpMethod("PATCH"), 
                body,
                urlSegments,
                null,
                null,
                null, 
                null).ConfigureAwait(false);
        }

        private async Task<T> RunAsync<T>(string resource, HttpMethod httpMethod, object body, IDictionary<string, string> urlSegments, IDictionary<string, string> queryStrings, IDictionary<string, object> parameters, IDictionary<string, object> headers, IList<FileUploadParameter> fileParameters) where T : class
        {
            // Build the request URL
            var requestMessage = new HttpRequestMessage(httpMethod, BuildRequestUri(resource, urlSegments, queryStrings));

            // Get the message content
            if (httpMethod != HttpMethod.Get)
                requestMessage.Content = BuildMessageContent(body, parameters, fileParameters);

            // Apply the headers
            ApplyHeaders(requestMessage, headers);

            // Send the request
            var httpClient = new HttpClient();
            var response = await httpClient.SendAsync(requestMessage).ConfigureAwait(false);

            // Handle API errors
            await HandleErrors(response);

            // Deserialize the content
            string content = await response.Content.ReadAsStringAsync();

            if (typeof (T)== typeof (string)) // Let string content pass throug
                return (T)(object)content;

            return JsonConvert.DeserializeObject<T>(content);
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
                    multipartContent.Add(new StringContent(Uri.EscapeDataString(parameter.Value.ToString())), parameter.Key);
                }

                return multipartContent;
            }
            else if (parameters != null)
            {
                return new FormUrlEncodedContent(parameters.Select(kvp => new KeyValuePair<string, string>(kvp.Key, kvp.Value.ToString())));
            }
            else // Serialize the body
                return new StringContent(JsonConvert.SerializeObject(body, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }), Encoding.UTF8, "application/json");
        }

        private Uri BuildRequestUri(string resource, IDictionary<string, string> urlSegments, IDictionary<string, string> queryStrings)
        {
            return Utils.BuildUri(baseUrl, resource, urlSegments, queryStrings);
        }

        private async Task HandleErrors(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                //if (response.Exception != null)
                //    throw new ApiException(response.Exception.Message, response.Exception);;

                ApiError apiError = null;

                // Grab the content
                if (response.Content != null)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(responseContent))
                    {
                        apiError = JsonConvert.DeserializeObject<ApiError>(responseContent, new JsonSerializerSettings
                        {
                            // Suppress any parsing errors of payload
                            Error = (sender, args) => { args.ErrorContext.Handled = true; }
                        });
                    }
                }

                throw new ApiException(response.StatusCode, apiError);
            }
        }
    }
}