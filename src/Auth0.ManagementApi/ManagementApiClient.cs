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
        private readonly ApiConnection _apiConnection;

        /// <summary>
        /// Contains all the methods to call the /blacklists/tokens endpoints.
        /// </summary>
        /// <value>The blacklisted tokens.</value>
        public IBlacklistedTokensClient BlacklistedTokens { get; }

        /// <summary>
        /// Contains all the methods to call the /client-grants endpoints
        /// </summary>
        public IClientGrantsClient ClientGrants { get; }

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
        /// Contains all the methods to call the /custom-domains endpoints.
        /// </summary>
        public ICustomDomainsClient CustomDomains { get; }

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
        /// Contains all the methods to call the /email-templates endpoints.
        /// </summary>
        public IEmailTemplatesClient EmailTemplates { get; }

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
        /// Contains all the methods to call the /roles endpoints.
        /// </summary>
        /// <value>The roles.</value>
        public IRolesClient Roles { get; }

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
        public ITenantSettingsClient TenantSettings { get; set; }

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
            return _apiConnection.ApiInfo;
        }

        private ManagementApiClient(string token, Uri baseUri, ApiConnection apiConnection)
        {
            _apiConnection = apiConnection;

            BlacklistedTokens = new BlacklistedTokensClient(_apiConnection);
            ClientGrants = new ClientGrantsClient(_apiConnection);
            Clients = new ClientsClient(_apiConnection);
            Connections = new ConnectionsClient(_apiConnection);
            CustomDomains = new CustomDomainsClient(_apiConnection);
            DeviceCredentials = new DeviceCredentialsClient(_apiConnection);
            EmailProvider = new EmailProviderClient(_apiConnection);
            EmailTemplates = new EmailTemplatesClient(_apiConnection);
            Jobs = new JobsClient(_apiConnection);
            Logs = new LogsClient(_apiConnection);
            ResourceServers = new ResourceServersClient(_apiConnection);
            Roles = new RolesClient(_apiConnection);
            Rules = new RulesClient(_apiConnection);
            Stats = new StatsClient(_apiConnection);
            TenantSettings = new TenantSettingsClient(_apiConnection);
            Tickets = new TicketsClient(_apiConnection);
            UserBlocks = new UserBlocksClient(_apiConnection);
            Users = new UsersClient(_apiConnection);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        /// <param name="handler">The <see cref="HttpMessageHandler"/> which is used for HTTP requests</param>
        [Obsolete("Diagnostics are now automatic and not configurable. Please use a constructor without the DiagnosticsHeader parameter. This constructor will be removed in a future update.")]
        public ManagementApiClient(string token, Uri baseUri, DiagnosticsHeader diagnostics, HttpMessageHandler handler)
            : this(token, baseUri, handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        /// <param name="httpClient">The <see cref="HttpClient"/> which is used for HTTP requests</param>
        [Obsolete("Diagnostics are now automatic and not configurable. Please use a constructor without the DiagnosticsHeader parameter. This constructor will be removed in a future update.")]
        public ManagementApiClient(string token, Uri baseUri, DiagnosticsHeader diagnostics, HttpClient httpClient)
            : this(token, baseUri, httpClient)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        [Obsolete("Diagnostics are now automatic and not configurable. Please use a constructor without the DiagnosticsHeader parameter. This constructor will be removed in a future update.")]
        public ManagementApiClient(string token, Uri baseUri, DiagnosticsHeader diagnostics)
            : this(token, baseUri, (HttpMessageHandler)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="handler">The <see cref="HttpMessageHandler"/> which is used for HTTP requests</param>
        public ManagementApiClient(string token, Uri baseUri, HttpMessageHandler handler)
            : this(token, baseUri, new ApiConnection(token, baseUri.AbsoluteUri, handler))
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="httpClient">The <see cref="HttpClient"/> which is used for HTTP requests</param>
        public ManagementApiClient(string token, Uri baseUri, HttpClient httpClient)
            : this(token, baseUri, new ApiConnection(token, baseUri.AbsoluteUri, httpClient))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="baseUri">The base URI.</param>
        public ManagementApiClient(string token, Uri baseUri)
            : this(token, baseUri, (HttpMessageHandler)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="domain">Your Auth0 domain, e.g. tenant.auth0.com.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        /// <param name="handler">The <see cref="HttpMessageHandler"/> which is used for HTTP requests</param>
        [Obsolete("Diagnostics are now automatic and not configurable. Please use a constructor without the DiagnosticsHeader parameter. This constructor will be removed in a future update.")]
        public ManagementApiClient(string token, string domain, DiagnosticsHeader diagnostics, HttpMessageHandler handler)
            : this(token, new Uri($"https://{domain}/api/v2"), handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="domain">Your Auth0 domain, e.g. tenant.auth0.com.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        /// <param name="httpClient">The <see cref="HttpClient"/> which is used for HTTP requests</param>
        [Obsolete("Diagnostics are now automatic and not configurable. Please use a constructor without the DiagnosticsHeader parameter. This constructor will be removed in a future update.")]
        public ManagementApiClient(string token, string domain, DiagnosticsHeader diagnostics, HttpClient httpClient)
            : this(token, new Uri($"https://{domain}/api/v2"), httpClient)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="domain">Your Auth0 domain, e.g. tenant.auth0.com.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        [Obsolete("Diagnostics are now automatic and not configurable. Please use a constructor without the DiagnosticsHeader parameter. This constructor will be removed in a future update.")]
        public ManagementApiClient(string token, string domain, DiagnosticsHeader diagnostics)
            : this(token, new Uri($"https://{domain}/api/v2"), (HttpMessageHandler)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="domain">Your Auth0 domain, e.g. tenant.auth0.com.</param>
        /// <param name="handler">The <see cref="HttpMessageHandler"/> which is used for HTTP requests</param>
        public ManagementApiClient(string token, string domain, HttpMessageHandler handler)
            : this(token, new Uri($"https://{domain}/api/v2"), handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="domain">Your Auth0 domain, e.g. tenant.auth0.com.</param>
        /// <param name="httpClient">The <see cref="HttpClient"/> which is used for HTTP requests</param>
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

    }
}
