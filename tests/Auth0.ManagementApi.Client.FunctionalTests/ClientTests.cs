using System;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Auth0.ManagementApi.Client.FunctionalTests
{
    [TestClass]
    public class ClientTests : TestBase
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var apiClient = new ManagementApiClient(GetVariable("AUTH_TOKEN_CLIENTS"), new Uri(GetVariable("AUTH0_API_URL")));

            // Get all clients
            var clients = await apiClient.Clients.GetAll();

            // Check we are getting clients
            Assert.IsNotNull(clients);
        }
    }
}
