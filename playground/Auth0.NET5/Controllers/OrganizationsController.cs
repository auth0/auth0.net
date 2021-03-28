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
    public class OrganizationsController : ControllerBase
    {
        private readonly AuthenticationApiClient _authClient;

        public OrganizationsController(IConfiguration configuration)
        {
            Configuration = configuration;
            _authClient = new AuthenticationApiClient(Configuration["Auth0:Domain"]);
        }

        public IConfiguration Configuration { get; }

        [HttpGet]
        public async Task<IEnumerable<Organization>> Get()
        {
            var token = await _authClient.GetTokenAsync(new ClientCredentialsTokenRequest
            {
                Audience = $"https://{Configuration["Auth0:Domain"]}/api/v2/",
                ClientId = Configuration["Auth0:ClientId"],
                ClientSecret = Configuration["Auth0:ClientSecret"]
            });

            var mgmntClient = new ManagementApi.ManagementApiClient(token.AccessToken, Configuration["Auth0:Domain"]);

            return await mgmntClient.Organizations.GetAllAsync(new ManagementApi.Paging.PaginationInfo());
        }

        [HttpGet("{id}")]
        public async Task<Organization> Get(string id)
        {
            var token = await _authClient.GetTokenAsync(new ClientCredentialsTokenRequest
            {
                Audience = $"https://{Configuration["Auth0:Domain"]}/api/v2/",
                ClientId = Configuration["Auth0:ClientId"],
                ClientSecret = Configuration["Auth0:ClientSecret"]
            });

            var mgmntClient = new ManagementApi.ManagementApiClient(token.AccessToken, Configuration["Auth0:Domain"]);

            return await mgmntClient.Organizations.GetAsync(id);
        }

        [HttpPost()]
        public async Task<Organization> Post(OrganizationCreateRequest request)
        {
            var token = await _authClient.GetTokenAsync(new ClientCredentialsTokenRequest
            {
                Audience = $"https://{Configuration["Auth0:Domain"]}/api/v2/",
                ClientId = Configuration["Auth0:ClientId"],
                ClientSecret = Configuration["Auth0:ClientSecret"]
            });

            var mgmntClient = new ManagementApi.ManagementApiClient(token.AccessToken, Configuration["Auth0:Domain"]);

            return await mgmntClient.Organizations.CreateAsync(request);
        }

        [HttpPatch("{id}")]
        public async Task<Organization> Patch(string id, OrganizationUpdateRequest request)
        {
            var token = await _authClient.GetTokenAsync(new ClientCredentialsTokenRequest
            {
                Audience = $"https://{Configuration["Auth0:Domain"]}/api/v2/",
                ClientId = Configuration["Auth0:ClientId"],
                ClientSecret = Configuration["Auth0:ClientSecret"]
            });

            var mgmntClient = new ManagementApi.ManagementApiClient(token.AccessToken, Configuration["Auth0:Domain"]);

            return await mgmntClient.Organizations.UpdateAsync(id, request);
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            var token = await _authClient.GetTokenAsync(new ClientCredentialsTokenRequest
            {
                Audience = $"https://{Configuration["Auth0:Domain"]}/api/v2/",
                ClientId = Configuration["Auth0:ClientId"],
                ClientSecret = Configuration["Auth0:ClientSecret"]
            });

            var mgmntClient = new ManagementApi.ManagementApiClient(token.AccessToken, Configuration["Auth0:Domain"]);

            await mgmntClient.Organizations.DeleteAsync(id);
        }
    }
}
