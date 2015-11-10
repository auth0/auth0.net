using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth0.Api.Management;
using Nito.AsyncEx;

namespace ConsoleTestWorkbench
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncContext.Run(() => MainAsync(args));
        }

        private static async void MainAsync(string[] args)
        {
            var apiClient = new ManagementClient(ConfigurationManager.AppSettings["ApiToken"], new Uri(ConfigurationManager.AppSettings["ApiBaseUrl"]));

            var clients = await apiClient.Clients.GetAll();
        }
    }
}
