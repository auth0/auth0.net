using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.ManagementApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth0.NETCore3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CleanupController : ControllerBase
    {
        private readonly AuthenticationApiClient _authClient;

        public CleanupController(IConfiguration configuration)
        {
            Configuration = configuration;
            _authClient = new AuthenticationApiClient(Configuration["Auth0:Domain"]);
        }

        public IConfiguration Configuration { get; }

        [HttpGet]
        public async Task<ActionResult> CleanUp()
        {
            var token = await _authClient.GetTokenAsync(new ClientCredentialsTokenRequest
            {
                Audience = $"https://{Configuration["Auth0:Domain"]}/api/v2/",
                ClientId = Configuration["Auth0:ClientId"],
                ClientSecret = Configuration["Auth0:ClientSecret"]
            });

            var mgmntClient = new ManagementApi.ManagementApiClient(token.AccessToken, Configuration["Auth0:Domain"]);

            // Apps
            var apps = await mgmntClient.Clients.GetAllAsync(new GetClientsRequest(), new ManagementApi.Paging.PaginationInfo(0, 100));
            var appsToDelete = apps.Where(app => app.Name.StartsWith("Integration testing"));

            foreach(var app in appsToDelete)
            {
                await mgmntClient.Clients.DeleteAsync(app.ClientId);
            }

            // Connections
            var conns = await mgmntClient.Connections.GetAllAsync(new GetConnectionsRequest(), new ManagementApi.Paging.PaginationInfo(0, 100));
            var connsToDelete = conns.Where(conn => conn.Name.StartsWith("Temp-Int-Test"));

            foreach (var conn in connsToDelete)
            {
                await mgmntClient.Connections.DeleteAsync(conn.Id);
            }


            return Ok();

        }
    }
}
