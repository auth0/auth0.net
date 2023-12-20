using Auth0.Core.Exceptions;
using Auth0.Core.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Auth0.AuthenticationApi
{
    /// <summary>
    /// Implements the <see cref="IAuthenticationConnection"/> using <see cref="HttpClient"/> which
    /// can be either supplied or automatically managed.
    /// </summary>
    public class HttpClientAuthenticationConnection : IAuthenticationConnection, IDisposable
    {
        static readonly JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DateParseHandling = DateParseHandling.DateTime };

        readonly HttpClient httpClient;
        readonly string agentString;
        bool ownHttpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientAuthenticationConnection"/> class.
        /// </summary>
        /// <param name="httpClient">Optional <see cref="HttpClient"/> to use when sending requests.</param>
        /// <remarks>
        /// If you supply a <see cref="HttpClient"/> it is your responsibility to manage its lifecycle and 
        /// dispose it when appropriate.
        /// If you do not supply a <see cref="HttpClient"/> one will be created automatically and disposed
        /// of when this object is disposed.
        /// </remarks>
        public HttpClientAuthenticationConnection(HttpClient httpClient = null)
        {
            ownHttpClient = httpClient == null;
            this.httpClient = httpClient ?? new HttpClient();
            if (ownHttpClient)
                this.httpClient.DefaultRequestHeaders.Add("Auth0-Client", CreateAgentString());
            else
                agentString = CreateAgentString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientAuthenticationConnection"/> class
        /// with a specific <see cref="HttpMessageHandler"/>.
        /// </summary>
        /// <param name="handler"><see cref="HttpMessageHandler"/> to use within the managed <see cref="HttpClient"/>.</param>
        public HttpClientAuthenticationConnection(HttpMessageHandler handler)
            : this(new HttpClient(handler ?? new HttpClientHandler()))
        {
            ownHttpClient = true;
        }

        /// <inheritdoc/>
        public async Task<T> GetAsync<T>(Uri uri, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, uri))
            {
                ApplyHeaders(request, headers);
                return await SendRequest<T>(request, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<T> SendAsync<T>(HttpMethod method, Uri uri, object body, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default)
        {
            using (var request = new HttpRequestMessage(method, uri) { Content = BuildMessageContent(body) })
            {
                ApplyHeaders(request, headers);
                return await SendRequest<T>(request, cancellationToken).ConfigureAwait(false);
            }
        }

        private async Task<T> SendRequest<T>(HttpRequestMessage request, CancellationToken cancellationToken = default)
        {
            if (!ownHttpClient)
                request.Headers.Add("Auth0-Client", agentString);

            using (var response = await httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false))
            {
                if (!response.IsSuccessStatusCode)
                    throw await ApiException.CreateSpecificExceptionAsync(response).ConfigureAwait(false);

                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                return typeof(T) == typeof(string)
                    ? (T)(object)content
                    : JsonConvert.DeserializeObject<T>(content, jsonSerializerSettings);
            }
        }

        private void ApplyHeaders(HttpRequestMessage request, IDictionary<string, string> headers)
        {
            if (headers == null) return;

            foreach (var pair in headers)
                if (pair.Key != null && pair.Value != null)
                    request.Headers.Add(pair.Key, pair.Value);
        }

        private HttpContent BuildMessageContent(object body)
        {
            if (body == null)
                return null;

            if (body is IDictionary<string, string> dictionary)
                return CreateFormUrlEncodedContent(dictionary);

            return CreateJsonStringContent(body);
        }

        private static HttpContent CreateJsonStringContent(object body)
        {
            var json = JsonConvert.SerializeObject(body, jsonSerializerSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private static HttpContent CreateFormUrlEncodedContent(IDictionary<string, string> parameters)
        {
            return new FormUrlEncodedContent(parameters.Select(p => new KeyValuePair<string, string>(p.Key, p.Value ?? "")));
        }

        private static string CreateAgentString()
        {
#if NET462
            var target = "NET462";
#endif
#if NETSTANDARD2_0
            var target = "NETSTANDARD2.0";
#endif

            var sdkVersion = typeof(HttpClientAuthenticationConnection).GetTypeInfo().Assembly.GetName().Version;
            var agentJson = JsonConvert.SerializeObject(new
            {
                name = "Auth0.Net",
                version = sdkVersion.Major + "." + sdkVersion.Minor + "." + sdkVersion.Revision,
                env = new { target }
            }, Formatting.None);
            return Utils.Base64UrlEncode(Encoding.UTF8.GetBytes(agentJson));
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
    }
}
