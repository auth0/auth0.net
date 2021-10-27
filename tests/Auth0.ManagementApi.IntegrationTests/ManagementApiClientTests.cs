using Auth0.Core.Http;
using Auth0.Tests.Shared;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class ManagementApiClientTests : TestBase
    {
        readonly HeaderGrabberConnection grabber = new();
        readonly ManagementApiClient management;
        readonly JObject payload;

        public ManagementApiClientTests()
        {
            management = new ManagementApiClient("fake", GetVariable("AUTH0_MANAGEMENT_API_URL"), grabber);

            management.TenantSettings.GetAsync(); // Cause headers to be "sent" to the grabber for testing
            payload = JObject.Parse(Encoding.ASCII.GetString(Utils.Base64UrlDecode(grabber.LastHeaders["Auth0-Client"])));
        }

        [Fact]
        public async Task Disposes_Connection_it_creates_on_dispose()
        {
            var diposeManagement = new ManagementApiClient("token", "test");
            diposeManagement.Dispose();
            await Assert.ThrowsAsync<ObjectDisposedException>(() => diposeManagement.Clients.GetAsync("1"));
        }

        [Fact]
        public void Does_not_dispose_connection_it_does_not_create()
        {
            var doNotDisposeConnection = new FakeConnection();
            var disposeManagement = new ManagementApiClient("token", "test", doNotDisposeConnection);
            disposeManagement.Dispose();
            Assert.False(doNotDisposeConnection.IsDisposed);
        }

        class FakeConnection : IManagementConnection, IDisposable
        {
            public bool IsDisposed { get; private set; }

            public void Dispose()
            {
                IsDisposed = true;
            }

            public Task<T> GetAsync<T>(Uri uri, IDictionary<string, string> headers = null, JsonConverter[] converters = null, CancellationToken cancellationToken = default)
            {
                return Task.FromResult(default(T));
            }

            public Task<T> SendAsync<T>(HttpMethod method, Uri uri, object body, IDictionary<string, string> headers = null, IList<FileUploadParameter> files = null, JsonConverter[] converters = null, CancellationToken cancellationToken = default)
            {
                return Task.FromResult(default(T));
            }
        }

        [Fact]
        public void Auth0Client_headers_added()
        {
            Assert.Contains(grabber.LastHeaders, k => k.Key == "Auth0-Client");
        }

        [Fact]
        public async Task Auth0Client_authorization_header_updated()
        {
            //Arrange
            string newToken = "new_token";

            //Act
            management.UpdateAccessToken(newToken);

            Models.Client result = await management.Clients.GetAsync("test_id");

            //Assert
            Assert.Contains(grabber.LastHeaders, v => v.Value == $"Bearer {newToken}");
        }

        [Fact]
        public void Auth0Client_payload_is_valid_base64_url_json()
        {
            Assert.NotNull(payload);
        }

        [Fact]
        public void Auth0Client_has_name_auth0_dot_net()
        {
            Assert.Equal("Auth0.Net", payload["name"].ToString());
        }

        [Fact]
        public void Auth0Client_has_version_from_auth_assembly()
        {
            var v = typeof(ManagementApiClient).Assembly.GetName().Version;
            Assert.Equal($"{v.Major}.{v.Minor}.{v.Revision}", payload["version"].ToString());
        }

        [Fact]
        public void Auth0Client_has_a_target_inside_env()
        {
            Assert.NotNull(payload["env"]["target"].ToString());
        }

        class HeaderGrabberConnection : IManagementConnection
        {
            public IDictionary<string, string> LastHeaders { get; private set; } = new Dictionary<string, string>();

            public Task<T> GetAsync<T>(Uri uri, IDictionary<string, string> headers = null, JsonConverter[] converters = null, CancellationToken cancellationToken = default)
            {
                LastHeaders = headers;
                return Task.FromResult(default(T));
            }

            public Task<T> SendAsync<T>(HttpMethod method, Uri uri, object body, IDictionary<string, string> headers = null, IList<FileUploadParameter> files = null, JsonConverter[] converters = null, CancellationToken cancellationToken = default)
            {
                LastHeaders = headers;
                return Task.FromResult(default(T));
            }
        }
    }
}
