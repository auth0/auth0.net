using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Newtonsoft.Json;
using PortableRest;
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

            // Ensure user agent is set on all requests
            //SetUserAgent<ApiConnection>();
        }

        public async Task<T> DeleteAsync<T>(string resource, IDictionary<string, string> urlSegments) where T : class
        {
            return await RunAsync<T>(resource,
                HttpMethod.Delete,
                ContentTypes.Json, 
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
                ContentTypes.Json, 
                null, 
                urlSegments,
                queryStrings,
                null,
                headers, 
                null).ConfigureAwait(false);
        }

        public async Task<T> PostAsync<T>(string resource, ContentTypes contentTypes, object body, IDictionary<string, object> parameters, IList<FileUploadParameter> fileParameters, IDictionary<string, string> urlSegments, IDictionary<string, object> headers, IDictionary<string, string> queryStrings) where T : class
        {
            return await RunAsync<T>(resource,
                HttpMethod.Post,
                contentTypes, 
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
                ContentTypes.Json, 
                body,
                urlSegments,
                null,
                null,
                null, 
                null).ConfigureAwait(false);
        }

        private async Task<T> RunAsync<T>(string resource, HttpMethod httpMethod, ContentTypes contentTypes, object body, IDictionary<string, string> urlSegments, IDictionary<string, string> queryStrings, IDictionary<string, object> parameters, IDictionary<string, object> headers, IList<FileUploadParameter> fileParameters) where T : class
        {
            // Build the request URL
            var requestMessage = new HttpRequestMessage(httpMethod, BuildRequestUri(resource, urlSegments, queryStrings));

            // Get the message content
            if (httpMethod != HttpMethod.Get)
                requestMessage.Content = BuildMessageContent(contentTypes, body, parameters, fileParameters);

            // Apply the headers
            ApplyHeaders(requestMessage, headers);

            // Send the request
            var httpClient = new HttpClient();
            var response = await httpClient.SendAsync(requestMessage).ConfigureAwait(false);

            // Handle API errors
            await HandleErrors(response);

            // Deserialize the content
            var content = await response.Content.ReadAsStringAsync();
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

        private HttpContent BuildMessageContent(ContentTypes contentType, object body, IDictionary<string, object> parameters, IList<FileUploadParameter> fileParameters)
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
            // Replace the URL Segments
            if (urlSegments != null)
            {
                foreach (var urlSegment in urlSegments)
                {
                    resource = resource.Replace(string.Format("{{{0}}}", urlSegment.Key), Uri.EscapeUriString(urlSegment.Value));
                }
            }

            // Add the query strings
            if (queryStrings != null)
            {
                var queryString = queryStrings
                    .Aggregate(new StringBuilder(), (sb, kvp) =>
                    {
                        if (sb.Length > 0)
                            sb = sb.Append("&");

                        if (kvp.Value != null)
                            return sb.Append(string.Format("{0}={1}", Uri.EscapeUriString(kvp.Key), Uri.EscapeDataString(kvp.Value)));

                        return sb;
                    })
                    .ToString();

                // If we have a querystring, append it to the resource
                if (!string.IsNullOrEmpty(queryString))
                {
                    if (resource.Contains("?"))
                        resource = string.Format("{0}&{1}", resource, queryString);
                    else
                        resource = string.Format("{0}?{1}", resource, queryString);
                }
            }

            resource = CombineUriParts(baseUrl, resource);

            return new Uri(resource, UriKind.RelativeOrAbsolute);
        }

        /// <summary>
        /// Combines URI parts, taking care of trailing and starting slashes.
        /// See http://stackoverflow.com/a/6704287
        /// </summary>
        /// <param name="uriParts">The URI parts to combine.</param>
        private static string CombineUriParts(params string[] uriParts)
        {
            var uri = string.Empty;
            if (uriParts != null && uriParts.Any())
            {
                uriParts = uriParts.Where(part => !string.IsNullOrWhiteSpace(part)).ToArray();
                char[] trimChars = { '\\', '/' };
                uri = (uriParts[0] ?? string.Empty).TrimEnd(trimChars);
                for (var i = 1; i < uriParts.Count(); i++)
                {
                    uri = string.Format("{0}/{1}", uri.TrimEnd(trimChars), (uriParts[i] ?? string.Empty).TrimStart(trimChars));
                }
            }
            return uri;
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