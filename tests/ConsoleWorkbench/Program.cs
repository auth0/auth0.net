using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;

namespace ConsoleWorkbench
{
    public class CustomMessageHandler : HttpClientHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("my-custom-header", "my-custom-value");
            
            return base.SendAsync(request, cancellationToken);
        }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            AuthenticationApiMainAsync(args).GetAwaiter().GetResult();
        }


        public static async Task AuthenticationApiMainAsync(string[] args)
        {
            var authenticationApiClient = new AuthenticationApiClient("jerrie.auth0.com", new CustomMessageHandler());
            var authenticationResponse = await authenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
            {
                ClientId = "",
                ClientSecret = "",
                Realm = "Username-Password-Authentication",
                Scope = "openid offline_access",
                Username = "jerrie@jerriepelser.com",
                Password = "password"
            });

            Console.WriteLine(authenticationResponse.IdToken);
        }

        public static async Task ManagementApiMainAsync(string[] args)
        {
            string token = "";

            var api = new ManagementApiClient(token, "jerrie.auth0.com");

            ClientCreateRequest clientCreateRequest = new ClientCreateRequest()
            {
                Name = "Test name",
                ApplicationType = ClientApplicationType.NonInteractive,
                ResourceServers = new[]
                {
                    new ClientResourceServerAssociation
                    {
                        Identifier = "urn:test-api",
                        Scopes = new[] { "read:appointments", "create:appointments" }
                    }
                },
                JwtConfiguration = new JwtConfiguration
                {
                    SigningAlgorithm = "RS256",
                    LifetimeInSeconds = 3600
                }
            };
            await api.Clients.CreateAsync(clientCreateRequest);
        }
    }

    public class WebProxy : IWebProxy
    {
        public Uri GetProxy(Uri destination)
        {
            return new Uri("http://localhost:8888");
        }

        public bool IsBypassed(Uri host)
        {
            return false;
        }

        public ICredentials Credentials { get; set; }
    }
}