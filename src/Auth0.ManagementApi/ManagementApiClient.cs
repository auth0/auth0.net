using Auth0.Core.Http;
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
        readonly IApiConnection _apiConnection;

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
        /// Gets information about the last API call;
        /// </summary>
        public ApiInfo GetLastApiInfo()
        {
            return _apiConnection.ApiInfo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementApiClient"/> class.
        /// </summary>
        /// <param name="apiConnection"><see cref="IApiConnection" /> used to communicate between the client and Auth0.</param>
        public ManagementApiClient(IApiConnection apiConnection)
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
            Guardian = new GuardianClient(_apiConnection);
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
        /// Dispose of any managed resources such as the <see cref="IApiConnection"/>.
        /// </summary>
        /// <param name="disposing">Whether we are actually disposing (<see langword="true"/>) or not (<see langword="false")/>.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_apiConnection is IDisposable)
                    ((IDisposable)_apiConnection).Dispose();
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
