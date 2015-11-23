using Auth0.ManagementApi.Client.Clients;

namespace Auth0.ManagementApi.Client
{
    /// <summary>
    /// 
    /// </summary>
    public interface IManagementApiClient
    {
        IBlacklistedTokensClient BlacklistedTokens { get; }

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