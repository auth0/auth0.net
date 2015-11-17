using Auth0.Api.Management.Clients;

namespace Auth0.Api.Management
{
    public interface IManagementClient
    {
        IClientsClient Clients { get; }

        IConnectionsClient Connections { get; }

        IDeviceCredentialsClient DeviceCredentials { get; }

        IEmailProviderClient EmailProvider { get; }

        IJobsClient Jobs { get; }

        IRulesClient Rules { get; }

        ITicketsClient Tickets { get; }

        IStatsClient Stats { get; }

        IUsersClient Users { get; }
    }
}