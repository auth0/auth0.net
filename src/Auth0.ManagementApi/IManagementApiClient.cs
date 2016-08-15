using Auth0.Core.Http;
using Auth0.ManagementApi.Clients;

namespace Auth0.ManagementApi
{
    /// <summary>
    /// Represents the Management API client.
    /// </summary>
    public interface IManagementApiClient
    {
        /// <summary>
        /// Contains all the methods to call the /blacklists/tokens endpoints.
        /// </summary>
        IBlacklistedTokensClient BlacklistedTokens { get; }

        /// <summary>
        /// Contains all the methods to call the /client-grants endpoints
        /// </summary>
        IClientGrantsClient ClientGrants { get; }

        /// <summary>
        /// Contains all the methods to call the /clients endpoints.
        /// </summary>
        IClientsClient Clients { get; }

        /// <summary>
        /// Contains all the methods to call the /connections endpoints.
        /// </summary>
        IConnectionsClient Connections { get; }

        /// <summary>
        /// Contains all the methods to call the /device-credentials endpoints.
        /// </summary>
        IDeviceCredentialsClient DeviceCredentials { get; }

        /// <summary>
        /// Contains all the methods to call the /emails/provider endpoints.
        /// </summary>
        IEmailProviderClient EmailProvider { get; }

        /// <summary>
        /// Contains all the methods to call the /jobs endpoints.
        /// </summary>
        IJobsClient Jobs { get; }

        /// <summary>
        /// Contains a ll the methods to call the /logs endpoints.
        /// </summary>
        ILogsClient Logs { get; }

        /// <summary>
        /// Contains all the methods to call the /resource-servers endpoints.
        /// </summary>
        IResourceServersClient ResourceServers { get; }

        /// <summary>
        /// Contains all the methods to call the /rules endpoints.
        /// </summary>
        IRulesClient Rules { get; }

        /// <summary>
        /// Contains all the methods to call the /stats endpoints.
        /// </summary>
        IStatsClient Stats { get; }

        /// <summary>
        /// Contains all the methods to call the /tenants/settings endpoints.
        /// </summary>
        ITentantSettingsClient TenantSettings { get; set; }

        /// <summary>
        /// Contains all the methods to call the /tickets endpoints.
        /// </summary>
        ITicketsClient Tickets { get; }

        /// <summary>
        /// Contains all the methods to call the /user-blocks endpoints.
        /// </summary>
        IUserBlocksClient UserBlocks { get; }

        /// <summary>
        /// Contains all the methods to call the /users endpoints.
        /// </summary>
        IUsersClient Users { get; }

        /// <summary>
        /// Gets information about the last API call;
        /// </summary>
        ApiInfo GetLastApiInfo();
    }
}