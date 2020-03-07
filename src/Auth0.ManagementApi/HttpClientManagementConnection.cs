using Auth0.Core.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Auth0.ManagementApi
{
    /// <summary>
    /// Implements <see cref="IManagementConnection"/> using <see cref="HttpClient"/>.
    /// </summary>
    public class HttpClientManagementConnection : IManagementConnection, IDisposable
    {
        static readonly JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        readonly HttpClient httpClient;
        bool ownHttpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientManagementConnection"/> class.
        /// </summary>
        /// <param name="httpClient">Optional <see cref="HttpClient"/> to use. If not specified one will
        /// be created and be used for all requests made by this instance.</param>
        public HttpClientManagementConnection(HttpClient httpClient = null)
        {
            ownHttpClient = httpClient == null;
            this.httpClient = httpClient ?? new HttpClient();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientManagementConnection"/> class.
        /// </summary>
        /// <param name="handler"><see cref="HttpMessageHandler"/> to use with the managed 
        /// <see cref="HttpClient"/> that will be created and used for all requests made
        /// by this instance.</param>
        public HttpClientManagementConnection(HttpMessageHandler handler)
            : this(new HttpClient(handler ?? new HttpClientHandler()))
        {
            ownHttpClient = true;
        }

        /// <inheritdoc />
        public async Task<T> GetAsync<T>(Uri uri, IDictionary<string, string> headers, JsonConverter[] converters = null)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, uri))
            {
                ApplyHeaders(request.Headers, headers);
                return await SendRequest<T>(request, converters).ConfigureAwait(false);
            }
        }

        /// <inheritdoc />
        public async Task<T> SendAsync<T>(HttpMethod method, Uri uri, object body, IDictionary<string, string> headers, IList<FileUploadParameter> files = null)
        {
            using (var request = new HttpRequestMessage(method, uri) { Content = BuildMessageContent(body, files) })
            {
                ApplyHeaders(request.Headers, headers);
                return await SendRequest<T>(request).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Disposes of any owned disposable resources such as the underlying <see cref="HttpClient"/> if owned.
        /// </summary>
        /// <param name="disposing">Whether we are actually disposing (<see langword="true"/>) or not (<see langword="false"/>).</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && ownHttpClient)
            {
                httpClient.Dispose();
                ownHttpClient = false;
            }
        }

        /// <summary>
        /// Disposes of any owned disposable resources such as the underlying <see cref="HttpClient"/> if owned.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        private async Task<T> SendRequest<T>(HttpRequestMessage request, JsonConverter[] converters = null)
        {
            var response = await httpClient.SendAsync(request).ConfigureAwait(false);
            {
                if (!response.IsSuccessStatusCode)
                    throw new ErrorApiException(response.StatusCode, await ApiError.Parse(response).ConfigureAwait(false));

                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                return typeof(T) == typeof(string)
                    ? (T)(object)content
                    : JsonConvert.DeserializeObject<T>(content, converters);
            }
        }

        private void ApplyHeaders(HttpHeaders current, IDictionary<string, string> input)
        {
            if (input == null) return;

            foreach (var pair in input)
                if (pair.Key != null && pair.Value != null)
                    current.Add(pair.Key, pair.Value);
        }

        private HttpContent BuildMessageContent(object body, IList<FileUploadParameter> files = null)
        {
            if (body == null)
                return null;

            var hasFiles = files != null && files.Count > 0;

            if (body is IDictionary<string, object> parameters)
                if (hasFiles)
                    return CreateMultipartFormDataContent(files, parameters);
                else
                    return CreateFormUrlEncodedContent(parameters);

            if (hasFiles)
                throw new ArgumentException("Body must be IDictionary<string, object> when specifying files.");

            return CreateJsonStringContent(body);
        }

        private static HttpContent CreateJsonStringContent(object body)
        {
            var json = JsonConvert.SerializeObject(body, jsonSerializerSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private static HttpContent CreateFormUrlEncodedContent(IDictionary<string, object> parameters)
        {
            return new FormUrlEncodedContent(parameters
                .Select(p => new KeyValuePair<string, string>(p.Key, p.Value?.ToString() ?? "")));
        }

        private static HttpContent CreateMultipartFormDataContent(IList<FileUploadParameter> files, object body)
        {
            var content = new MultipartFormDataContent();

            foreach (var file in files)
            {
                var stream = new StreamContent(file.FileStream);
                if (string.IsNullOrEmpty(file.Filename))
                    content.Add(stream, file.Key);
                else
                    content.Add(stream, file.Key, file.Filename);
            }

            if (body is Dictionary<string, string> parameters)
                foreach (var parameter in parameters)
                    content.Add(new StringContent(Uri.EscapeDataString(parameter.Value?.ToString() ?? "")), parameter.Key);

            return content;
        }
    }
}