using Auth0.Tests.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    public class AuthenticationApiClientTests : TestBase
    {
        [Fact]
        public async Task Disposes_connection_it_creates_on_dispose()
        {
            var authClient = new AuthenticationApiClient("https://docs.auth0.com");
            authClient.Dispose();
            await Assert.ThrowsAsync<ObjectDisposedException>(() => authClient.StartPasswordlessSmsFlowAsync(new Models.PasswordlessSmsRequest()));
        }

        [Fact]
        public void Does_not_dispose_connection_it_does_not_create()
        {
            var connection = new FakeConnection();
            var authClient = new AuthenticationApiClient("https://docs.auth0.com", connection);
            authClient.Dispose();
            Assert.False(connection.IsDisposed);
        }

        class FakeConnection : IAuthenticationConnection, IDisposable
        {
            public bool IsDisposed { get; private set; }

            public void Dispose()
            {
                IsDisposed = true;
            }

            public Task<T> GetAsync<T>(Uri uri, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default)
            {
                return Task.FromResult(default(T));
            }

            public Task<T> SendAsync<T>(HttpMethod method, Uri uri, object body, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default)
            {
                return Task.FromResult(default(T));
            }
        }
    }
}
