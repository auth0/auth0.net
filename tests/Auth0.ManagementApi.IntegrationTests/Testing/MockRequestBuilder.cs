using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class MockRequestBuilder
    {
        private string baseUrl;
        private bool liveMode;
        private string path;
        private HttpMethod method;
        private Dictionary<string, object> response;
        private Dictionary<string, object> expectedParams;
        private Mock<HttpClientHandler> mockHandler;

        public MockRequestBuilder(string baseUrl, bool liveMode = false)
        {
            this.baseUrl = baseUrl;
            this.liveMode = liveMode;
            this.mockHandler = new Mock<HttpClientHandler>(MockBehavior.Strict);
        }

        public MockRequestBuilder Request(string path, HttpMethod method = null)
        {
            this.path = path;
            this.method = method ?? HttpMethod.Get;
            return this;
        }

        public MockRequestBuilder ExpectParams(Dictionary<string, object> expectedParams)
        {
            this.expectedParams = expectedParams;
            return this;
        }

        public MockRequestBuilder Response(Dictionary<string, object> response)
        {
            this.response = response;
            return this;
        }

        public HttpMessageHandler Build()
        {
            var setup = mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req => req.Method == method && req.RequestUri.ToString().StartsWith($"{baseUrl}/{path}") && (expectedParams == null || ValidateRequestContent(req, expectedParams))),
                    ItExpr.IsAny<CancellationToken>()
                );

            if (liveMode)
            {
                setup.CallBase();
            }
            else
            {
                setup.ReturnsAsync(new HttpResponseMessage()
                 {
                     StatusCode = HttpStatusCode.OK,
                     Content = response != null ? new StringContent(JsonConvert.SerializeObject(response), Encoding.UTF8, "application/json") : null,
                 });
            }

            return mockHandler.Object;
        }

        private bool ValidateRequestContent(HttpRequestMessage content, Dictionary<string, object> contentParams)
        {
            var jsonContent = JsonNode.Parse(content.Content.ReadAsStringAsync().Result).AsObject();

            return contentParams.Aggregate(true, (acc, keyValue) =>
            {
                if (!acc)
                {
                    return false;
                }

                var hasKey = jsonContent.ContainsKey(keyValue.Key);

                if (!hasKey)
                {
                    throw new System.Exception($"Key '{keyValue.Key}' was not found in the request.");
                }
                return acc && jsonContent.ContainsKey(keyValue.Key);
            });
        }
    }
}
