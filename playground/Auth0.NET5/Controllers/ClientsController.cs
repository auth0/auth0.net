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
            var token = await _authClient.GetTokenAsync(new ClientCredentialsTokenRequest
            {
                Audience = $"https://{Configuration["Auth0:Domain"]}/api/v2/",
                ClientId = Configuration["Auth0:ClientId"],
                ClientSecret = Configuration["Auth0:ClientSecret"]
            });

            var mgmntClient = new ManagementApi.ManagementApiClient(token.AccessToken, Configuration["Auth0:Domain"]);

            return await mgmntClient.Clients.GetAllAsync(new GetClientsRequest(), new ManagementApi.Paging.PaginationInfo());
        }
    }
}
