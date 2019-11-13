using Auth0.ManagementApi.Clients;
using System;
using System.Net.Http;

namespace Auth0.ManagementApi
{
    /// <summary>
    /// Represents the Management API client.
    /// </summary>
    public class ManagementApiClient : IDisposable
    {
        private readonly IDisposable connectionToDispose;

        /// <summary>
        /// Contains all the methods to call the /blacklists/tokens endpoints.
        /// </summary>
        public BlacklistedTokensClient BlacklistedTokens { get; }

        /// <summary>
        /// Contains all the methods to call the /client-grants endpoints
        /// </summary>
        public ClientGrantsClient ClientGrants { get; }

        /// <summary>
        /// Contains all the methods to call the /clients endpoints.
        /// </summary>
        public ClientsClient Clients { get; }

        /// <summary>
        /// Contains all the methods to call the /connections endpoints.
        /// </summary>
        public ConnectionsClient Connections { get; }

        /// <summary>
        /// Contains all the methods to call the /custom-domains endpoints.
        /// </summary>
        public CustomDomainsClient CustomDomains { get; }

        /// <summary>
        /// Contains all the methods to call the /device-credentials endpoints.
        /// </summary>
        public DeviceCredentialsClient DeviceCredentials { get; }

        /// <summary>
        /// Contains all the methods to call the /emails/provider endpoints.
        /// </summary>
        public EmailProviderClient EmailProvider { get; }

        /// <summary>
        /// Contains all the methods to call the /email-templates endpoints.
        /// </summary>
        public EmailTemplatesClient EmailTemplates { get; }

        /// <summary>
        /// Contains all the methods to call the /guardian endpoints.
        /// </summary>
        public GuardianClient Guardian { get; }

        /// <summary>
        /// Contains all the methods to call the /jobs endpoints.
        /// </summary>
        public JobsClient Jobs { get; }

        /// <summary>
        /// Contains all the methods to call the /logs endpoints.
        /// </summary>
        public LogsClient Logs { get; }

        /// <summary>
        /// Contains all the methods to call the /resource-servers endpoints.
        /// </summary>
        public ResourceServersClient ResourceServers { get; }

        /// <summary>
        /// Contains all the methods to call the /roles endpoints.
        /// </summary>
        /// <value>The roles.</value>
        public RolesClient Roles { get; }

        /// <summary>
        /// Contains all the methods to call the /rules endpoints.
        /// </summary>
        public RulesClient Rules { get; }

        /// <summary>
        /// Contains all the methods to call the /stats endpoints.
        /// </summary>
        public StatsClient Stats { get; }

        /// <summary>
        /// Contains all the methods to call the /tenants/settings endpoints.
        /// </summary>
        public TenantSettingsClient TenantSettings { get; set; }

        /// <summary>
        /// Contains all the methods to call the /tickets endpoints.
        /// </summary>
        public TicketsClient Tickets { get; }

        /// <summary>
        /// Contains all the methods to call the /user-blocks endpoints.
        /// </summary>
        public UserBlocksClient UserBlocks { get; }

        /// <summary>
        /// Contains all the methods to call the /users endpoints.
        /// </summary>
        public UsersClient Users { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">A valid Auth0 Management API v2 token.</param>
        /// <param name="baseUrl">The URL of the tenant to manage.</param>
        /// <param name="handler">The <see cref="HttpMessageHandler"/> which is used for HTTP requests.</param>
        public ManagementApiClient(string token, Uri baseUri, IManagementConnection managementConnection = null)
        {
            if (managementConnection == null)
            {
                var ownedManagementConnection = new HttpClientManagementConnection();
                managementConnection = ownedManagementConnection;
                connectionToDispose = ownedManagementConnection;
            }

            // Ideally this wouldn't exist but it's a lot of internal code to change that is fragile
            var bridge = new ApiConnectionBridge(token, baseUri.OriginalString, managementConnection);

            BlacklistedTokens = new BlacklistedTokensClient(bridge);
            ClientGrants = new ClientGrantsClient(bridge);
            Clients = new ClientsClient(bridge);
            Connections = new ConnectionsClient(bridge);
            CustomDomains = new CustomDomainsClient(bridge);
            DeviceCredentials = new DeviceCredentialsClient(bridge);
            EmailProvider = new EmailProviderClient(bridge);
            EmailTemplates = new EmailTemplatesClient(bridge);
            Guardian = new GuardianClient(bridge);
            Jobs = new JobsClient(bridge);
            Logs = new LogsClient(bridge);
            ResourceServers = new ResourceServersClient(bridge);
            Roles = new RolesClient(bridge);
            Rules = new RulesClient(bridge);
            Stats = new StatsClient(bridge);
            TenantSettings = new TenantSettingsClient(bridge);
            Tickets = new TicketsClient(bridge);
            UserBlocks = new UserBlocksClient(bridge);
            Users = new UsersClient(bridge);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">A valid Auth0 Management API v2 token.</param>
        /// <param name="domain">Your Auth0 domain. <example>tenant.auth0.com</example></param>
        /// <param name="connection"></param>
        public ManagementApiClient(string token, string domain, IManagementConnection connection = null)
            : this(token, new Uri($"https://{domain}/api/v2"), connection)
        {
        }

        /// <summary>
        /// Disposes of any owned disposable resources.
        /// </summary>
        /// <param name="disposing">Whether we are actually disposing (<see langword="true"/>) or not (<see langword="false")/>.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && connectionToDispose != null)
            {
                connectionToDispose.Dispose();
            }
        }

        /// <summary>
        /// Disposes of any owned disposable resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
