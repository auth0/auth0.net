using Auth0.Api.Management.Clients;

namespace Auth0.Api.Management
{
    public interface IManagementClient
    {
        IClientsClient Clients { get; }

        IConnectionsClient Connections { get; }

        IDeviceCredentialsClient DeviceCredentials { get; }

        IRulesClient Rules { get; }

        IUsersClient Users { get; }
    }
}