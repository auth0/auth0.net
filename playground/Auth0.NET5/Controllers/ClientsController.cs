using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.ManagementApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth0.NETCore3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly AuthenticationApiClient _authClient;

        public ClientsController(IConfiguration configuration)
        {
            Configuration = configuration;
            _authClient = new AuthenticationApiClient(Configuration["Auth0:Domain"]);
        }

        public IConfiguration Configuration { get; }

        [HttpGet]
        public async Task<IEnumerable<Client>> Get()
        {
        

            var mgmntClient = new ManagementApi.ManagementApiClient(Configuration["Auth0:Domain"], Configuration["Auth0:ClientId"], Configuration["Auth0:ClientSecret"]);

            // Call 1
            await mgmntClient.Connections.GetAllAsync(new GetConnectionsRequest(), new ManagementApi.Paging.PaginationInfo());
            // Call 2
            await mgmntClient.ResourceServers.GetAllAsync(new ManagementApi.Paging.PaginationInfo());

            // Call 3
            return await mgmntClient.Clients.GetAllAsync(new GetClientsRequest(), new ManagementApi.Paging.PaginationInfo());
        }
    }
}
