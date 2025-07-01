using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class Utils
    {
        private readonly ManagementApiClient _apiClient;

        public Utils(ManagementApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        internal async Task<Client> CreateClient(ClientCreateRequest request = null)
        {
            request ??= new ClientCreateRequest()
            {
                Name = "Test client " + Guid.NewGuid(),
                Description = "This is a dummy client - TBD"
            };

            var client = await _apiClient.Clients.CreateAsync(request);
            return client;
        }
        
        internal async Task<Organization> CreateOrganization(OrganizationCreateRequest request = null)
        {
            request??= new OrganizationCreateRequest()
            {
                Name = "tbd-organisation",
                DisplayName = "Test organization display name",
            };
            
            var organization = await _apiClient.Organizations.CreateAsync(request);
            return organization;
        }
        
        internal async Task<ResourceServer> CreateResourceServer(ResourceServerCreateRequest request = null)
        {
            var identifier = Guid.NewGuid();
            request??= new ResourceServerCreateRequest
            {
                Identifier = identifier.ToString("N"),
                Name = $"{TestingConstants.ResourceServerPrefix} {identifier:N}",
                TokenLifetime = 1,
                TokenLifetimeForWeb = 1,
                SigningAlgorithm = SigningAlgorithm.HS256,
                SigningSecret = "thisismysecret0123456789",
                Scopes = new List<ResourceServerScope>
                {
                    new()
                    {
                        Value = "scope1",
                        Description = "Scope number 1"
                    }
                },
                AllowOfflineAccess = true,
                VerificationLocation = "https://abc.auth0.com/def",
                SkipConsentForVerifiableFirstPartyClients = true,
            };
            var resourceServer = await _apiClient.ResourceServers.CreateAsync(request);
            return resourceServer;
        }
    }
}