using System;
using Auth0.Core.Http;
using Auth0.ManagementApi.Clients;

namespace Auth0.ManagementApi
{
    /// <summary>
    /// Represents the Management API client.
    /// </summary>
    public class ManagementApiClient : IManagementApiClient
    {
        private readonly ApiConnection apiConnection;

        /// <summary>
        /// Contains all the methods to call the /blacklists/tokens endpoints.
        /// </summary>
        /// <value>The blacklisted tokens.</value>
        public IBlacklistedTokensClient BlacklistedTokens { get; }

        /// <summary>
        /// Contains all the methods to call the /clients endpoints.
        /// </summary>
        /// <value>The clients.</value>
        public IClientsClient Clients { get; }

        /// <summary>
        /// Contains all the methods to call the /connections endpoints.
        /// </summary>
        /// <value>The connections.</value>
        public IConnectionsClient Connections { get; }

        /// <summary>
        /// Contains all the methods to call the /device-credentials endpoints.
        /// </summary>
        /// <value>The device credentials.</value>
        public IDeviceCredentialsClient DeviceCredentials { get; }

        /// <summary>
        /// Contains all the methods to call the /emails/provider endpoints.
        /// </summary>
        /// <value>The email provider.</value>
        public IEmailProviderClient EmailProvider { get; }

        /// <summary>
        /// Contains all the methods to call the /jobs endpoints.
        /// </summary>
        /// <value>The jobs.</value>
        public IJobsClient Jobs { get; }

        /// <summary>
        /// Contains all the methods to call the /rules endpoints.
        /// </summary>
        /// <value>The rules.</value>
        public IRulesClient Rules { get; }

        /// <summary>
        /// Contains all the methods to call the /stats endpoints.
        /// </summary>
        /// <value>The stats.</value>
        public IStatsClient Stats { get; }

        /// <summary>
        /// Contains all the methods to call the /tenants/settings endpoints.
        /// </summary>
        /// <value>The tenant settings.</value>
        public ITentantSettingsClient TenantSettings { get; set; }

        /// <summary>
        /// Contains all the methods to call the /tickets endpoints.
        /// </summary>
        /// <value>The tickets.</value>
        public ITicketsClient Tickets { get; }

        /// <summary>
        /// Contains all the methods to call the /users endpoints.
        /// </summary>
        /// <value>The users.</value>
        public IUsersClient Users { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        public ManagementApiClient(string token, Uri baseUri, DiagnosticsHeader diagnostics)
        {
            // If no diagnostics header structure was specified, then revert to the default one
            if (diagnostics == null)
            {
                diagnostics = DiagnosticsHeader.Default;
            }

            apiConnection = new ApiConnection(token, baseUri.AbsoluteUri, diagnostics);

            BlacklistedTokens = new BlacklistedTokensClient(apiConnection);
            Clients = new ClientsClient(apiConnection);
            Connections = new ConnectionsClient(apiConnection);
            DeviceCredentials = new DeviceCredentialsClient(apiConnection);
            EmailProvider = new EmailProviderClient(apiConnection);
            Jobs = new JobsClient(apiConnection);
            Rules = new RulesClient(apiConnection);
            Stats = new StatsClient(apiConnection);
            TenantSettings = new TentantSettingsClient(apiConnection);
            Tickets = new TicketsClient(apiConnection);
            Users = new UsersClient(apiConnection);

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="baseUri">The base URI.</param>
        public ManagementApiClient(string token, Uri baseUri)
            : this(token, baseUri, null)
        {
        }
    }
}