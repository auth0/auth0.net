using System;
using System.Net.Http;
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
        /// Contains all the methods to call the /client-grants endpoints
        /// </summary>
        public IClientGrantsClient ClientGrants { get;  }

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
        /// Contains all the methods to call the /logs endpoints.
        /// </summary>
        /// <value>The rules.</value>
        public ILogsClient Logs { get; }

        /// <summary>
        /// Contains all the methods to call the /resource-servers endpoints.
        /// </summary>
        public IResourceServersClient ResourceServers { get; }

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
        /// Contains all the methods to call the /user-blocks endpoints.
        /// </summary>
        public IUserBlocksClient UserBlocks { get; }

        /// <summary>
        /// Contains all the methods to call the /users endpoints.
        /// </summary>
        /// <value>The users.</value>
        public IUsersClient Users { get; }

        /// <summary>
        /// Gets information about the last API call;
        /// </summary>
        public ApiInfo GetLastApiInfo()
        {
            return apiConnection.ApiInfo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        /// <param name="handler">The <see cref="HttpMessageHandler"/> which is used for HTTP requests</param>
        public ManagementApiClient(string token, Uri baseUri, DiagnosticsHeader diagnostics, HttpMessageHandler handler)
        {
            // If no diagnostics header structure was specified, then revert to the default one
            if (diagnostics == null)
            {
                diagnostics = DiagnosticsHeader.Default;
            }

            apiConnection = new ApiConnection(token, baseUri.AbsoluteUri, diagnostics, handler);

            BlacklistedTokens = new BlacklistedTokensClient(apiConnection);
            ClientGrants = new ClientGrantsClient(apiConnection);
            Clients = new ClientsClient(apiConnection);
            Connections = new ConnectionsClient(apiConnection);
            DeviceCredentials = new DeviceCredentialsClient(apiConnection);
            EmailProvider = new EmailProviderClient(apiConnection);
            Jobs = new JobsClient(apiConnection);
            Logs = new LogsClient(apiConnection);
            ResourceServers = new ResourceServersClient(apiConnection);
            Rules = new RulesClient(apiConnection);
            Stats = new StatsClient(apiConnection);
            TenantSettings = new TentantSettingsClient(apiConnection);
            Tickets = new TicketsClient(apiConnection);
            UserBlocks = new UserBlocksClient(apiConnection);
            Users = new UsersClient(apiConnection);

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        public ManagementApiClient(string token, Uri baseUri, DiagnosticsHeader diagnostics)
            : this(token, baseUri, diagnostics, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="handler">The <see cref="HttpMessageHandler"/> which is used for HTTP requests</param>
        public ManagementApiClient(string token, Uri baseUri, HttpMessageHandler handler)
            : this(token, baseUri, null, handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="baseUri">The base URI.</param>
        public ManagementApiClient(string token, Uri baseUri)
            : this(token, baseUri, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="domain">Your Auth0 domain, e.g. mydomain.auth0.com.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        /// <param name="handler">The <see cref="HttpMessageHandler"/> which is used for HTTP requests</param>
        public ManagementApiClient(string token, string domain, DiagnosticsHeader diagnostics, HttpMessageHandler handler)
            : this(token, new Uri($"https://{domain}/api/v2"), diagnostics, handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="domain">Your Auth0 domain, e.g. mydomain.auth0.com.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        public ManagementApiClient(string token, string domain, DiagnosticsHeader diagnostics)
            : this(token, new Uri($"https://{domain}/api/v2"), diagnostics, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="domain">Your Auth0 domain, e.g. mydomain.auth0.com.</param>
        /// <param name="handler">The <see cref="HttpMessageHandler"/> which is used for HTTP requests</param>
        public ManagementApiClient(string token, string domain, HttpMessageHandler handler)
            : this(token, new Uri($"https://{domain}/api/v2"), null, handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="domain">Your Auth0 domain, e.g. mydomain.auth0.com.</param>
        public ManagementApiClient(string token, string domain)
            : this(token, new Uri($"https://{domain}/api/v2"), null, null)
        {
        }

    }
}