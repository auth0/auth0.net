using Auth0.Core.Http;
using Auth0.Tests.Shared;
using Newtonsoft.Json.Linq;
using System;
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
        public void Auth0Client_is_added_to_http_client_default_headers()
        {
            var client = SetupClient();
            Assert.Contains(client.DefaultRequestHeaders, k => k.Key == "Auth0-Client");
        }

        [Fact]
        public void Auth0Client_payload_is_valid_base64_url_json()
        {
            var client = SetupClient();
            var payload = GetPayload(client);
            Assert.NotNull(payload);
        }

        [Fact]
        public void Auth0Client_has_name_auth0_dot_net()
        {
            var client = SetupClient();
            var payload = GetPayload(client);

            Assert.Equal("Auth0.Net", payload["name"].ToString());
        }

        [Fact]
        public void Auth0Client_has_version_from_auth_assembly()
        {
            var client = SetupClient();
            var payload = GetPayload(client);

            var v = typeof(ManagementApiClient).Assembly.GetName().Version;
            Assert.Equal($"{v.Major}.{v.Minor}.{v.Revision}", payload["version"].ToString());
        }

        [Fact]
        public void Auth0Client_has_a_target_inside_env()
        {
            var client = SetupClient();
            var payload = GetPayload(client);

            Assert.NotNull(payload["env"]["target"].ToString());
        }

        private HttpClient SetupClient()
        {
            var httpClient = new HttpClient();
            var connection = new HttpClientManagementConnection(httpClient);
            new ManagementApiClient("fake", GetVariable("AUTH0_MANAGEMENT_API_URL"), connection);
            return httpClient;
        }

        private static JObject GetPayload(HttpClient client)
        {
            return DecodePayload(client.DefaultRequestHeaders.GetValues("Auth0-Client").First());
        }

        private static JObject DecodePayload(string payload)
        {
            var decoded = Encoding.ASCII.GetString(Utils.Base64UrlDecode(payload));
            return JObject.Parse(decoded);
        }

    }
}
