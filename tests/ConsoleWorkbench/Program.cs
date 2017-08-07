using System;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                string token = "";

//                var handler = new HttpClientHandler
//                {
//                    Proxy = new WebProxy
//                    {
//                        Credentials = new NetworkCredential("username", "password")
//                    }
//                };
//                var api = new AuthenticationApiClient("jerrie.auth0.com", new CustomMessageHandler());
//
//                var userInfo = await api.GetUserInfoAsync(token);

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
            catch (Exception ex)
            {
                throw;
            }
        }

        public static async Task ManagementApiMainAsync(string[] args)
        {
            try
            {
                string token = "";

                var api = new ManagementApiClient(token, "jerrie.auth0.com");

                ClientCreateRequest clientCreateRequest = new ClientCreateRequest()
                {
                    Name = "Test name",
                    ApplicationType = ClientApplicationType.NonInteractive,
                    ResourceServers = new ClientResourceServerAssociation[]
                    {
                        new ClientResourceServerAssociation
                        {
                            Identifier = "urn:test-api",
                            Scopes = new string[] { "read:appointments", "create:appointments" }
                        }
                    },
                    JwtConfiguration = new JwtConfiguration
                    {
                        SigningAlgorithm = "RS256",
                        LifetimeInSeconds = 3600
                    }
                };
                var createTask = await api.Clients.CreateAsync(clientCreateRequest);

                //Console.WriteLine($"The tenant has {clients.Count} clients");
            }
            catch (Exception ex)
            {
                throw;
            }
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