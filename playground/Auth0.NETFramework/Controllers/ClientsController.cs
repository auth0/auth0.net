using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.ManagementApi.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Http;

namespace Auth0.NETCore3.Controllers
{
    public class ClientsController : ApiController
    {
        private readonly AuthenticationApiClient _authClient;

        public ClientsController()
        {
            _authClient = new AuthenticationApiClient(ConfigurationManager.AppSettings["Auth0Domain"]);
        }

        [HttpGet]
        public async Task<IEnumerable<Client>> Get()
        {
            var token = await _authClient.GetTokenAsync(new ClientCredentialsTokenRequest
            {
                Audience = $"https://{ConfigurationManager.AppSettings["Auth0Domain"]}/api/v2/",
                ClientId = ConfigurationManager.AppSettings["Auth0ClientId"],
                ClientSecret = ConfigurationManager.AppSettings["Auth0ClientSecret"]
            });

            var mgmntClient = new ManagementApi.ManagementApiClient(token.AccessToken, ConfigurationManager.AppSettings["Auth0Domain"]);

            return await mgmntClient.Clients.GetAllAsync(new GetClientsRequest(), new ManagementApi.Paging.PaginationInfo());
        }
    }
}
