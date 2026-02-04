using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;

namespace Auth0.ManagementApi.IntegrationTests;

public class Utils
{
    private readonly ManagementClient _apiClient;

    public Utils(ManagementClient apiClient)
    {
        _apiClient = apiClient;
    }

    internal async Task<CreateClientResponseContent> CreateClient(CreateClientRequestContent request = null)
    {
        request ??= new CreateClientRequestContent
        {
            Name = "Test client " + Guid.NewGuid(),
            Description = "This is a dummy client - TBD"
        };

        var client = await _apiClient.Clients.CreateAsync(request);
        return client;
    }

    internal async Task<CreateOrganizationResponseContent> CreateOrganization(CreateOrganizationRequestContent request = null)
    {
        request ??= new CreateOrganizationRequestContent
        {
            Name = "tbd-organisation",
            DisplayName = "Test organization display name",
        };

        var organization = await _apiClient.Organizations.CreateAsync(request);
        return organization;
    }

    internal async Task<CreateResourceServerResponseContent> CreateResourceServer(CreateResourceServerRequestContent request = null)
    {
        var identifier = Guid.NewGuid();
        request ??= new CreateResourceServerRequestContent
        {
            Identifier = identifier.ToString("N"),
            Name = $"{TestingConstants.ResourceServerPrefix} {identifier:N}",
            TokenLifetime = 1,
            SigningAlg = SigningAlgorithmEnum.Hs256,
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
            SkipConsentForVerifiableFirstPartyClients = true,
        };
        var resourceServer = await _apiClient.ResourceServers.CreateAsync(request);
        return resourceServer;
    }
}