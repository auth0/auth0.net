using Auth0.Core;
using Auth0.Core.Exceptions;
using Auth0.Core.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Auth0.ManagementApi
{
    public class HttpClientManagementConnection : IManagementConnection, IDisposable
    {
        readonly HttpClient httpClient;
        bool shouldDisposeHttpClient;

        public HttpClientManagementConnection(HttpMessageHandler handler)
            : this(new HttpClient(handler ?? new HttpClientHandler()))
        {
            shouldDisposeHttpClient = true;
        }

        public HttpClientManagementConnection(HttpClient httpClient = null)
        {
            shouldDisposeHttpClient = false;
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.httpClient.DefaultRequestHeaders.Add("Auth0-Client", CreateAgentString());
        }

        public Task<T> GetAsync<T>(Uri uri, IDictionary<string, string> headers = null, JsonConverter[] converters = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            ApplyHeaders(request, headers);
            return SendRequest<T>(request);
        }

        public Task<T> SendAsync<T>(HttpMethod method, Uri uri, object body, IDictionary<string, string> headers = null, IList<FileUploadParameter> files = null)
        {
            var request = new HttpRequestMessage(method, uri) { Content = BuildMessageContent(body, files) };
            ApplyHeaders(request, headers);
            return SendRequest<T>(request);
        }

        private async Task<T> SendRequest<T>(HttpRequestMessage request, JsonConverter[] converters = null)
        {
            var response = await httpClient.SendAsync(request).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                throw new ErrorApiException(response.StatusCode, await ApiError.Parse(response).ConfigureAwait(false));

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return typeof(T) == typeof(string)
                ? (T)(object)content
                : JsonConvert.DeserializeObject<T>(content, converters);
        }

        private void ApplyHeaders(HttpRequestMessage message, IDictionary<string, string> headers)
        {
            if (headers == null) return;

            foreach (var pair in headers)
                if (pair.Key != null && pair.Value != null)
                    message.Headers.Add(pair.Key, pair.Value);
        }

        private HttpContent BuildMessageContent(object body, IList<FileUploadParameter> files = null)
        {
            if (body == null)
                return null;

            if (files != null && files.Count > 0)
                return CreateMultipartFormDataContent(files, body);

            if (body is IDictionary<string, object> parameters)
                return CreateFormUrlEncodedContent(parameters);

            return CreateJsonStringContent(body);
        }

        private static readonly JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

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

            var sdkVersion = typeof(HttpClientManagementConnection).GetTypeInfo().Assembly.GetName().Version;
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

        /// <summary>
        /// Disposes of any owned disposable resources such as the underlying <see cref="HttpClient"/>.
        /// </summary>
        /// <param name="disposing">Whether we are actually disposing (<see langword="true"/>) or not (<see langword="false")/>.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && shouldDisposeHttpClient)
            {
                httpClient.Dispose();
                shouldDisposeHttpClient = false;
            }
        }

        /// <summary>
        /// Disposes of any owned disposable resources such as the ApiConnection.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
    }
}