using Auth0.Core.Http;
using Auth0.Tests.Shared;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class ManagementApiClientTests : TestBase
    {
        [Fact]
        public async Task Disposes_Connection_it_creates_on_dispose()
        {
            var management = new ManagementApiClient("token", "test");
            management.Dispose();
            await Assert.ThrowsAsync<ObjectDisposedException>(() => management.Clients.GetAsync("1"));
        }

        [Fact]
        public void Does_not_dispose_connection_it_does_not_create()
        {
            var connection = new FakeConnection();
            var management = new ManagementApiClient("token", "test", connection);
            management.Dispose();
            Assert.False(connection.IsDisposed);
        }

        class FakeConnection : IManagementConnection, IDisposable
        {
            public bool IsDisposed { get; private set; }

            public void Dispose()
            {
                IsDisposed = true;
            }

            public Task<T> GetAsync<T>(Uri uri, IDictionary<string, string> headers = null, JsonConverter[] converters = null)
            {
                return default;
            }

            public Task<T> SendAsync<T>(HttpMethod method, Uri uri, object body, IDictionary<string, string> headers = null, IList<FileUploadParameter> files = null)
            {
                return default;
            }

            public void SetDefaultHeaders(IDictionary<string, string> headers)
            {
            }
        }

        [Fact]
        public void Auth0Client_headers_added()
        {
            var grabber = SetupHeaderGrab();
            Assert.Contains(grabber.LastHeaders, k => k.Key == "Auth0-Client");
        }

        [Fact]
        public void Auth0Client_payload_is_valid_base64_url_json()
        {
            var grabber = SetupHeaderGrab();
            var payload = GetPayload(grabber);
            Assert.NotNull(payload);
        }

        [Fact]
        public void Auth0Client_has_name_auth0_dot_net()
        {
            var grabber = SetupHeaderGrab();
            var payload = GetPayload(grabber);

            Assert.Equal("Auth0.Net", payload["name"].ToString());
        }

        [Fact]
        public void Auth0Client_has_version_from_auth_assembly()
        {
            var grabber = SetupHeaderGrab();
            var payload = GetPayload(grabber);

            var v = typeof(ManagementApiClient).Assembly.GetName().Version;
            Assert.Equal($"{v.Major}.{v.Minor}.{v.Revision}", payload["version"].ToString());
        }

        [Fact]
        public void Auth0Client_has_a_target_inside_env()
        {
            var grabber = SetupHeaderGrab();
            var payload = GetPayload(grabber);

            Assert.NotNull(payload["env"]["target"].ToString());
        }

        private HeaderGrabberConnection SetupHeaderGrab()
        {
            var grabber = new HeaderGrabberConnection();
            using (new ManagementApiClient("fake", GetVariable("AUTH0_MANAGEMENT_API_URL"), grabber))
                return grabber;
        }

        private static JObject GetPayload(HeaderGrabberConnection grabber)
        {
            return DecodePayload(grabber.LastHeaders["Auth0-Client"]);
        }

        private static JObject DecodePayload(string payload)
        {
            var decoded = Encoding.ASCII.GetString(Utils.Base64UrlDecode(payload));
            return JObject.Parse(decoded);
        }

        class HeaderGrabberConnection : IManagementConnection
        {
            IDictionary<string, string> defaultHeaders = new Dictionary<string, string>();

            public IDictionary<string, string> LastHeaders { get; private set; } = new Dictionary<string, string>();

            public Task<T> GetAsync<T>(Uri uri, IDictionary<string, string> headers = null, JsonConverter[] converters = null)
            {
                LastHeaders = new Dictionary<string, string>(defaultHeaders.Concat(headers));
                return default;
            }

            public Task<T> SendAsync<T>(HttpMethod method, Uri uri, object body, IDictionary<string, string> headers = null, IList<FileUploadParameter> files = null)
            {
                LastHeaders = new Dictionary<string, string>(defaultHeaders.Concat(headers));
                return default;
            }

            public void SetDefaultHeaders(IDictionary<string, string> headers)
            {
                LastHeaders = defaultHeaders = headers;
            }
        }
    }
}
