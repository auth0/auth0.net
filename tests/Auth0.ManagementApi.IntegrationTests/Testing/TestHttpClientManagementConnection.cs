using Auth0.Core.Exceptions;
using Auth0.ManagementApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Auth0.Tests.Shared
{
    public class TestManagementApiClient : ManagementApiClient
    {
        private bool shouldDispose = false;
        public TestManagementApiClient(string token, Uri baseUri) : base(token, baseUri, new TestHttpClientManagementConnection())
        {
            shouldDispose = true;
        }

        public TestManagementApiClient(string token, string domain) : base(token, domain, new TestHttpClientManagementConnection())
        {
            shouldDispose = true;
        }

        public TestManagementApiClient(string token, Uri baseUrl, IManagementConnection connection = null) : base(token, baseUrl, connection)
        {
        }

        public TestManagementApiClient(string token, string domain, IManagementConnection connection) : base(token, domain, connection)
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (shouldDispose)
            {
                (connection as TestHttpClientManagementConnection).Dispose();
            }
        }
    }
    public class TestHttpClientManagementConnection : IManagementConnection, IDisposable
    {
        private HttpClientManagementConnection _connection;
        public TestHttpClientManagementConnection(HttpClient httpClient = null)
        {
            _connection = new HttpClientManagementConnection(httpClient);
        }

        public TestHttpClientManagementConnection(HttpMessageHandler handler)
        {
            _connection = new HttpClientManagementConnection(handler);
        }

        public async Task<T> GetAsync<T>(Uri uri, IDictionary<string, string> headers, JsonConverter[] converters = null, CancellationToken token = default)
        {
            var maxNrOfTries = 3;
            var nrOfTries = 0;
            var exponentialInterval = 1500;

            while (true)
            {
                try
                {
                    nrOfTries++;

                    return await _connection.GetAsync<T>(uri, headers, converters, token);
                } catch(Exception ex)
                {
                    if (!(ex is RateLimitApiException) || nrOfTries >= maxNrOfTries)
                    {
                        throw;
                    }
                }

                Thread.Sleep(nrOfTries * exponentialInterval);
            }
        }

        public async Task<T> SendAsync<T>(HttpMethod method, Uri uri, object body, IDictionary<string, string> headers, IList<FileUploadParameter> files = null, CancellationToken token = default)
        {
            var maxNrOfTries = 3;
            var nrOfTries = 0;
            var exponentialInterval = 1500;

            while (true)
            {
                try
                {
                    nrOfTries++;

                    return await _connection.SendAsync<T>(method, uri, body, headers, files, token);
                }
                catch (Exception ex)
                {
                    if (!(ex is RateLimitApiException) || nrOfTries >= maxNrOfTries)
                    {
                        throw;
                    }
                }

                Thread.Sleep(nrOfTries * exponentialInterval);
            }
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
