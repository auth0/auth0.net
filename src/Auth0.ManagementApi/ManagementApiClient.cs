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
        readonly IApiConnection connection;
        bool disposed;

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

        private ManagementApiClient(IApiConnection apiConnection)
        {
            connection = apiConnection;

            BlacklistedTokens = new BlacklistedTokensClient(connection);
            ClientGrants = new ClientGrantsClient(connection);
            Clients = new ClientsClient(connection);
            Connections = new ConnectionsClient(connection);
            CustomDomains = new CustomDomainsClient(connection);
            DeviceCredentials = new DeviceCredentialsClient(connection);
            EmailProvider = new EmailProviderClient(connection);
            EmailTemplates = new EmailTemplatesClient(connection);
            Guardian = new GuardianClient(connection);
            Jobs = new JobsClient(connection);
            Logs = new LogsClient(connection);
            ResourceServers = new ResourceServersClient(connection);
            Roles = new RolesClient(connection);
            Rules = new RulesClient(connection);
            Stats = new StatsClient(connection);
            TenantSettings = new TenantSettingsClient(connection);
            Tickets = new TicketsClient(connection);
            UserBlocks = new UserBlocksClient(connection);
            Users = new UsersClient(connection);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">A valid Auth0 Management API v2 token.</param>
        /// <param name="baseUrl">The URL of the tenant to manage.</param>
        /// <param name="handler">The <see cref="HttpMessageHandler"/> which is used for HTTP requests.</param>
        public ManagementApiClient(string token, Uri baseUri, HttpMessageHandler handler)
            : this(new ApiConnection(token, baseUri.AbsoluteUri, handler))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">A valid Auth0 Management API v2 token.</param>
        /// <param name="baseUrl">The URL of the tenant to manage.</param>
        /// <param name="httpClient">The <see cref="HttpClient"/> which is used for HTTP requests.</param>
        public ManagementApiClient(string token, Uri baseUri, HttpClient httpClient)
            : this(new ApiConnection(token, baseUri.AbsoluteUri, httpClient))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">A valid Auth0 Management API v2 token.</param>
        /// <param name="baseUrl">The URL of the tenant to manage.</param>
        public ManagementApiClient(string token, Uri baseUri)
            : this(token, baseUri, (HttpMessageHandler)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">A valid Auth0 Management API v2 token.</param>
        /// <param name="domain">Your Auth0 domain. <example>tenant.auth0.com</example></param>
        /// <param name="handler">The <see cref="HttpMessageHandler"/> which is used for HTTP requests.</param>
        public ManagementApiClient(string token, string domain, HttpMessageHandler handler)
            : this(token, new Uri($"https://{domain}/api/v2"), handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">A valid Auth0 Management API v2 token.</param>
        /// <param name="domain">Your Auth0 domain. <example>tenant.auth0.com</example></param>
        /// <param name="httpClient">The <see cref="HttpClient"/> which is used for HTTP requests.</param>
        public ManagementApiClient(string token, string domain, HttpClient httpClient)
            : this(token, new Uri($"https://{domain}/api/v2"), httpClient)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="domain">Your Auth0 domain, e.g. tenant.auth0.com.</param>
        public ManagementApiClient(string token, string domain)
            : this(token, new Uri($"https://{domain}/api/v2"), (HttpMessageHandler)null)
        {
        }

        /// <summary>
        /// Disposes of any owned disposable resources such as the ApiConnection.
        /// </summary>
        /// <param name="disposing">Whether we are actually disposing (<see langword="true"/>) or not (<see langword="false")/>.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                if (connection is IDisposable disposableConnection)
                    disposableConnection.Dispose();
                disposed = true;
            }
        }

        /// <summary>
        /// Disposes of any owned disposable resources such as the ApiConnection.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
