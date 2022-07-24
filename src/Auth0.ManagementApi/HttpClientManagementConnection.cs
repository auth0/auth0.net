using Auth0.Core.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Auth0.Core;

namespace Auth0.ManagementApi
{
    /// <summary>
    /// Implements <see cref="IManagementConnection"/> using <see cref="HttpClient"/>.
    /// </summary>
    public class HttpClientManagementConnection : IManagementConnection, IDisposable
    {
        static readonly JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DateParseHandling = DateParseHandling.DateTime };

        readonly HttpClient httpClient;
        readonly HttpClientManagementConnectionOptions options;
        bool ownHttpClient;

        readonly ConcurrentRandom random = new ConcurrentRandom();
        readonly int MAX_REQUEST_RETRY_JITTER = 250;
        readonly int MAX_REQUEST_RETRY_DELAY = 1000;
        readonly int MIN_REQUEST_RETRY_DELAY = 250;
        readonly int DEFAULT_NUMBER_RETRIES = 3;
        readonly int MAX_NUMBER_RETRIES = 10;
        readonly int BASE_DELAY = 250;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientManagementConnection"/> class.
        /// </summary>
        /// <param name="httpClient">Optional <see cref="HttpClient"/> to use. If not specified one will
        /// be created and be used for all requests made by this instance.</param>
        /// <param name="options">Optional <see cref="HttpClientManagementConnectionOptions"/> to use.</param>
        public HttpClientManagementConnection(HttpClient httpClient = null, HttpClientManagementConnectionOptions options = null)
        {
            ownHttpClient = httpClient == null;
            this.httpClient = httpClient ?? new HttpClient();
            this.options = options ?? new HttpClientManagementConnectionOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientManagementConnection"/> class.
        /// </summary>
        /// <param name="handler"><see cref="HttpMessageHandler"/> to use with the managed 
        /// <see cref="HttpClient"/> that will be created and used for all requests made
        /// by this instance.</param>
        /// <param name="options">Optional <see cref="HttpClientManagementConnectionOptions"/> to use.</param>
        public HttpClientManagementConnection(HttpMessageHandler handler, HttpClientManagementConnectionOptions options = null)
            : this(new HttpClient(handler ?? new HttpClientHandler()), options)
        {
            ownHttpClient = true;
        }

        /// <inheritdoc />
        public async Task<T> GetAsync<T>(Uri uri, IDictionary<string, string> headers, JsonConverter[] converters = null, CancellationToken cancellationToken = default)
        {
            return await Retry(async () => await GetAsyncInternal<T>(uri, headers, converters, cancellationToken)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<T> SendAsync<T>(HttpMethod method, Uri uri, object body, IDictionary<string, string> headers, IList<FileUploadParameter> files = null, JsonConverter[] converters = null, CancellationToken cancellationToken = default)
        {
            return await Retry(async () => await SendAsyncInternal<T>(method, uri, body, headers, files, converters, cancellationToken)).ConfigureAwait(false);
        }

        private async Task<T> GetAsyncInternal<T>(Uri uri, IDictionary<string, string> headers, JsonConverter[] converters = null, CancellationToken cancellationToken = default)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, uri))
            {
                ApplyHeaders(request.Headers, headers);
                return await SendRequest<T>(request, converters, cancellationToken).ConfigureAwait(false);
            }
        }

        private async Task<T> SendAsyncInternal<T>(HttpMethod method, Uri uri, object body, IDictionary<string, string> headers, IList<FileUploadParameter> files = null, JsonConverter[] converters = null, CancellationToken cancellationToken = default)
        {
            using (var request = new HttpRequestMessage(method, uri) { Content = BuildMessageContent(body, files) })
            {
                ApplyHeaders(request.Headers, headers);
                return await SendRequest<T>(request, converters, cancellationToken).ConfigureAwait(false);
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

        private async Task<T> SendRequest<T>(HttpRequestMessage request, JsonConverter[] converters = null, CancellationToken cancellationToken = default)
        {
            var response = await httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
            {
                if (!response.IsSuccessStatusCode)
                    throw await ApiException.CreateSpecificExceptionAsync(response).ConfigureAwait(false);

                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                return typeof(T) == typeof(string)
                    ? (T)(object)content
                    : JsonConvert.DeserializeObject<T>(content,
                        converters == null ? jsonSerializerSettings : new JsonSerializerSettings() { Converters = converters });
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

            if (body is Dictionary<string, object> parameters)
                foreach (var parameter in parameters)
                    if (parameter.Value != null)
                        content.Add(new StringContent(SerializeFormBodyValue(parameter.Value)), parameter.Key);

            return content;
        }

        private static string SerializeFormBodyValue(object value)
        {
            if (value is bool boolean) return boolean ? "true" : "false";
            return Uri.EscapeDataString(value.ToString());
        }

        private async Task<TResult> Retry<TResult>(Func<Task<TResult>> retryable)
        {
            int? configuredNrOfTries = options.NumberOfHttpRetries;
            var nrOfTries = 0;
            var nrOfTriesToAttempt = Math.Min(MAX_NUMBER_RETRIES, configuredNrOfTries ?? DEFAULT_NUMBER_RETRIES);

            while (true)
            {
                try
                {
                    nrOfTries++;

                    return await retryable();
                }
                catch (Exception ex)
                {
                    if (!(ex is RateLimitApiException) || nrOfTries >= nrOfTriesToAttempt)
                    {
                        throw;
                    }
                }

                // Use an exponential back-off with the formula:
                // max(MIN_REQUEST_RETRY_DELAY, min(MAX_REQUEST_RETRY_DELAY, (BASE_DELAY * (2 ** attempt - 1)) + random_between(0, MAX_REQUEST_RETRY_JITTER)))
                //
                // ✔ Each attempt increases base delay by (250ms * (2 ** attempt - 1))
                // ✔ Randomizes jitter, adding up to MAX_REQUEST_RETRY_JITTER (250ms)
                // ✔ Never less than MIN_REQUEST_RETRY_DELAY (250ms)
                // ✔ Never more than MAX_REQUEST_RETRY_DELAY (1000ms)

                var wait = Convert.ToInt32(BASE_DELAY * Math.Pow(2, nrOfTries - 1));
                wait = random.Next(wait + 1, wait + MAX_REQUEST_RETRY_JITTER);
                wait = Math.Min(wait, MAX_REQUEST_RETRY_DELAY);
                wait = Math.Max(wait, MIN_REQUEST_RETRY_DELAY);

                await Task.Delay(wait);
            }
        }
    }
}