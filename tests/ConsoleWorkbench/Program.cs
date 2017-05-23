using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Auth0.AuthenticationApi;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;

namespace ConsoleWorkbench
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ManagementApiMainAsync(args).GetAwaiter().GetResult();
        }


        public static async Task AuthenticationApiMainAsync(string[] args)
        {
            try
            {
                string token = "";

                var handler = new HttpClientHandler
                {
                    Proxy = new WebProxy()
                };
                var api = new AuthenticationApiClient("jerrie.auth0.com");

                var userInfo = await api.GetUserInfoAsync(token);

                Console.WriteLine(userInfo.Email);
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