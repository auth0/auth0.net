using Auth0.AuthenticationApi;
using Auth0.Core.Exceptions;
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
    public class TestAuthenticationApiClient : AuthenticationApiClient
    {
        private bool shouldDispose = false;


        public TestAuthenticationApiClient(Uri baseUri) : base(baseUri, new TestHttpClientAuthenticationConnection())
        {
            shouldDispose = true;
        }

        public TestAuthenticationApiClient(string domain) : base(domain, new TestHttpClientAuthenticationConnection())
        {
            shouldDispose = true;
        }

        public TestAuthenticationApiClient(Uri baseUrl, IAuthenticationConnection connection = null) : base(baseUrl, connection)
        {
        }

        public TestAuthenticationApiClient(string domain, IAuthenticationConnection connection) : base(domain, connection)
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (shouldDispose)
            {
                (connection as TestHttpClientAuthenticationConnection).Dispose();
            }
        }
    }
    public class TestHttpClientAuthenticationConnection : IAuthenticationConnection, IDisposable
    {
        private HttpClientAuthenticationConnection _connection;
        public TestHttpClientAuthenticationConnection(HttpClient httpClient = null)
        {
            _connection = new HttpClientAuthenticationConnection(httpClient);
        }

        public TestHttpClientAuthenticationConnection(HttpMessageHandler handler)
        {
            _connection = new HttpClientAuthenticationConnection(handler);
        }

        public async Task<T> GetAsync<T>(Uri uri, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default)
        {
            var maxNrOfTries = 3;
            var nrOfTries = 0;
            var exponentialInterval = 1500;

            while (true)
            {
                try
                {
                    nrOfTries++;

                    return await _connection.GetAsync<T>(uri, headers, cancellationToken);
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

        public async Task<T> SendAsync<T>(HttpMethod method, Uri uri, object body, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default)
        {
            var maxNrOfTries = 3;
            var nrOfTries = 0;
            var exponentialInterval = 1500;

            while (true)
            {
                try
                {
                    nrOfTries++;

                    return await _connection.SendAsync<T>(method, uri, body, headers, cancellationToken);
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
