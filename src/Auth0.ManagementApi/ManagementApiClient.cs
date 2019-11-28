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
        readonly IDisposable connectionToDispose;

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

            managementConnection.SetDefaultHeaders(CreateDefaultHeaders(token));

            // Ideally this wouldn't exist but it's a lot of internal code to change that is fragile
            var bridge = new LegacyApiConnectionBridge(baseUri.OriginalString, managementConnection);

            BlacklistedTokens = new BlacklistedTokensClient(bridge);
            ClientGrants = new ClientGrantsClient(managementConnection, baseUri);
            Clients = new ClientsClient(managementConnection, baseUri);
            Connections = new ConnectionsClient(managementConnection, baseUri);
            CustomDomains = new CustomDomainsClient(managementConnection, baseUri);
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
