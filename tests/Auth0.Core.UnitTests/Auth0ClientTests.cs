using Auth0.Core.Http;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using Xunit;

namespace Auth0.Core.UnitTests
{
    public class Auth0ClientTests
    {
        [Fact]
        public void Auth0Client_is_added_to_http_client_default_headers()
        {
            var client = SetupClient();
            var headers = GetAuth0ClientHeaders(client);

            Assert.Single(headers);
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
        public void Auth0Client_has_version_from_core_assembly()
        {
            var client = SetupClient();
            var payload = GetPayload(client);

            var v = typeof(ApiConnection).GetTypeInfo().Assembly.GetName().Version;
            Assert.Equal($"{v.Major}.{v.Minor}.{v.Revision}", payload["version"].ToString());
        }

        [Fact]
        public void Auth0Client_has_a_target_inside_env()
        {
            var client = SetupClient();
            var payload = GetPayload(client);

            var v = typeof(ApiConnection).GetTypeInfo().Assembly.GetName().Version;
            Assert.NotNull(payload["env"]["target"].ToString());
        }

        private HttpClient SetupClient()
        {
            var httpClient = new HttpClient();
            var apiClient = new ApiConnection("abc", "nettest.auth0.com", httpClient);
            return httpClient;
        }

        private string[] GetAuth0ClientHeaders(HttpClient client)
        {
            return client.DefaultRequestHeaders.GetValues("Auth0-Client").ToArray();
        }

        private JObject GetPayload(HttpClient client)
        {
            var headers = GetAuth0ClientHeaders(client);
            var decoded = Encoding.ASCII.GetString(Utils.Base64UrlDecode(headers[0]));
            return JObject.Parse(decoded);
        }
    }
}
