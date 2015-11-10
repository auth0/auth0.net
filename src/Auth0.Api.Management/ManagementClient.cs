using System;
using Auth0.Api.Management.Clients;

namespace Auth0.Api.Management
{
    public class ManagementClient : IManagementClient
    {
        private readonly ApiConnection apiConnection;

        public IClientsClient Clients { get; }

        public ManagementClient(string token, Uri baseUri)
        {
            apiConnection = new ApiConnection(token, baseUri.AbsoluteUri);

            Clients = new ClientsClient(apiConnection);
        }
    }
}