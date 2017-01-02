using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Auth0.AuthenticationApi;
using Auth0.ManagementApi;

namespace ConsoleWorkbench
{
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

                var handler = new HttpClientHandler
                {
                    Proxy = new WebProxy()
                };
                var api = new ManagementApiClient(token, "jerrie.auth0.com", handler);

                var clients = await api.Clients.GetAllAsync();

                Console.WriteLine($"The tenant has {clients.Count} clients");
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