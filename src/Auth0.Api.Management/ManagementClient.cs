using System;
using Auth0.Api.Management.Clients;

namespace Auth0.Api.Management
{
    public class ManagementClient : IManagementClient
    {
        private readonly ApiConnection apiConnection;

        public IClientsClient Clients { get; }
        public IConnectionsClient Connections { get; }
        public IDeviceCredentialsClient DeviceCredentials { get; }
        public IRulesClient Rules { get; }
        public IUsersClient Users { get; }

        public ManagementClient(string token, Uri baseUri)
        {
            apiConnection = new ApiConnection(token, baseUri.AbsoluteUri);

            Clients = new ClientsClient(apiConnection);
            Connections = new ConnectionsClient(apiConnection);
            DeviceCredentials = new DeviceCredentialsClient(apiConnection);
            Rules = new RulesClient(apiConnection);
            Users = new UsersClient(apiConnection);
        }
    }
}