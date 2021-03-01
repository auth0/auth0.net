using Auth0.Core.Http;
using Auth0.ManagementApi.Clients;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Auth0.ManagementApi
{
    /// <summary>
    /// Represents the Management API client.
    /// </summary>
    public class ManagementApiClient : IDisposable
    {
        IDisposable connectionToDispose;

        /// <summary>
        /// Contains all the methods to call the /blacklists/tokens endpoints.
        /// </summary>
        public BlacklistedTokensClient BlacklistedTokens { get; }

        /// <summary>
        /// Contains all the methods to call the /branding endpoints.
        /// </summary>
        public BrandingClient Branding { get; }

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
        /// Contains all the methods to all the /log-streams endpoints.
        /// </summary>
        public LogStreamsClient LogStreams { get; }

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
        /// Contains all the methods to call the /hooks endpoints.
        /// </summary>
        public HooksClient Hooks { get; }

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
        /// <param name="baseUri"><see cref="Uri"/> of the tenant to manage.</param>
        /// <param name="managementConnection"><see cref="IManagementConnection"/> to facilitate communication with server.</param>
        public ManagementApiClient(string token, Uri baseUri, IManagementConnection managementConnection = null)
        {
            if (managementConnection == null)
            {
                var ownedManagementConnection = new HttpClientManagementConnection();
                managementConnection = ownedManagementConnection;
                connectionToDispose = ownedManagementConnection;
            }

            var defaultHeaders = CreateDefaultHeaders(token);

            BlacklistedTokens = new BlacklistedTokensClient(managementConnection, baseUri, defaultHeaders);
            Branding = new BrandingClient(managementConnection, baseUri, defaultHeaders);
            ClientGrants = new ClientGrantsClient(managementConnection, baseUri, defaultHeaders);
            Clients = new ClientsClient(managementConnection, baseUri, defaultHeaders);
            Connections = new ConnectionsClient(managementConnection, baseUri, defaultHeaders);
            CustomDomains = new CustomDomainsClient(managementConnection, baseUri, defaultHeaders);
            DeviceCredentials = new DeviceCredentialsClient(managementConnection, baseUri, defaultHeaders);
            EmailProvider = new EmailProviderClient(managementConnection, baseUri, defaultHeaders);
            EmailTemplates = new EmailTemplatesClient(managementConnection, baseUri, defaultHeaders);
            Guardian = new GuardianClient(managementConnection, baseUri, defaultHeaders);
            Hooks = new HooksClient(managementConnection, baseUri, defaultHeaders);
            Jobs = new JobsClient(managementConnection, baseUri, defaultHeaders);
            Logs = new LogsClient(managementConnection, baseUri, defaultHeaders);
            LogStreams = new LogStreamsClient(managementConnection, baseUri, defaultHeaders);
            ResourceServers = new ResourceServersClient(managementConnection, baseUri, defaultHeaders);
            Roles = new RolesClient(managementConnection, baseUri, defaultHeaders);
            Rules = new RulesClient(managementConnection, baseUri, defaultHeaders);
            Stats = new StatsClient(managementConnection, baseUri, defaultHeaders);
            TenantSettings = new TenantSettingsClient(managementConnection, baseUri, defaultHeaders);
            Tickets = new TicketsClient(managementConnection, baseUri, defaultHeaders);
            UserBlocks = new UserBlocksClient(managementConnection, baseUri, defaultHeaders);
            Users = new UsersClient(managementConnection, baseUri, defaultHeaders);
        }

        public ManagementApiClient(string domain, string clientId, string clientSecret, IManagementConnection managementConnection = null, ICache cache = null)
        {
            var baseUri = new Uri($"https://{domain}/api/v2");
            if (managementConnection == null)
            {
                var ownedManagementConnection = new HttpClientManagementConnection();
                managementConnection = ownedManagementConnection;
                connectionToDispose = ownedManagementConnection;
            }

            var tokenConnection = new TokenHttpClientManagementConnection(domain, clientId, clientSecret, managementConnection, cache != null ? cache : new MemoryCache());

            var defaultHeaders = CreateDefaultHeaders(null);

            BlacklistedTokens = new BlacklistedTokensClient(tokenConnection, baseUri, defaultHeaders);
            Branding = new BrandingClient(tokenConnection, baseUri, defaultHeaders);
            ClientGrants = new ClientGrantsClient(tokenConnection, baseUri, defaultHeaders);
            Clients = new ClientsClient(tokenConnection, baseUri, defaultHeaders);
            Connections = new ConnectionsClient(tokenConnection, baseUri, defaultHeaders);
            CustomDomains = new CustomDomainsClient(tokenConnection, baseUri, defaultHeaders);
            DeviceCredentials = new DeviceCredentialsClient(tokenConnection, baseUri, defaultHeaders);
            EmailProvider = new EmailProviderClient(tokenConnection, baseUri, defaultHeaders);
            EmailTemplates = new EmailTemplatesClient(tokenConnection, baseUri, defaultHeaders);
            Guardian = new GuardianClient(tokenConnection, baseUri, defaultHeaders);
            Hooks = new HooksClient(tokenConnection, baseUri, defaultHeaders);
            Jobs = new JobsClient(tokenConnection, baseUri, defaultHeaders);
            Logs = new LogsClient(tokenConnection, baseUri, defaultHeaders);
            LogStreams = new LogStreamsClient(tokenConnection, baseUri, defaultHeaders);
            ResourceServers = new ResourceServersClient(tokenConnection, baseUri, defaultHeaders);
            Roles = new RolesClient(tokenConnection, baseUri, defaultHeaders);
            Rules = new RulesClient(tokenConnection, baseUri, defaultHeaders);
            Stats = new StatsClient(tokenConnection, baseUri, defaultHeaders);
            TenantSettings = new TenantSettingsClient(tokenConnection, baseUri, defaultHeaders);
            Tickets = new TicketsClient(tokenConnection, baseUri, defaultHeaders);
            UserBlocks = new UserBlocksClient(tokenConnection, baseUri, defaultHeaders);
            Users = new UsersClient(tokenConnection, baseUri, defaultHeaders);
        }

        private static Dictionary<string, string> CreateDefaultHeaders(string token)
        {
            var headers = new Dictionary<string, string> {
                { "Auth0-Client", CreateAgentString() } };

            if (!string.IsNullOrEmpty(token))
                headers.Add("Authorization", $"Bearer {token}");

            return headers;
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
        /// <param name="disposing">Whether we are actually disposing (<see langword="true"/>) or not (<see langword="false"/>).</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && connectionToDispose != null)
            {
                connectionToDispose.Dispose();
                connectionToDispose = null;
            }
        }

        /// <summary>
        /// Disposes of any owned disposable resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        private static string CreateAgentString()
        {
#if NET452
            var target = "NET452";
#endif
#if NETSTANDARD2_0
            var target = "NETSTANDARD2.0";
#endif

            var sdkVersion = typeof(HttpClientManagementConnection).Assembly.GetName().Version;
            var agentJson = JsonConvert.SerializeObject(new
            {
                name = "Auth0.Net",
                version = sdkVersion.Major + "." + sdkVersion.Minor + "." + sdkVersion.Revision,
                env = new
                {
                    target
                }
            }, Formatting.None);
            return Utils.Base64UrlEncode(Encoding.UTF8.GetBytes(agentJson));
        }
    }
}
