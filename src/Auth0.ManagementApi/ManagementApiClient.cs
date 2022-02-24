using Auth0.Core.Http;
using Auth0.ManagementApi.Clients;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth0.ManagementApi
{
    /// <summary>
    /// Represents the Management API client.
    /// </summary>
    public class ManagementApiClient : IDisposable
    {
        private const string AuthorizationHeaderKey = "Authorization";

        protected readonly IManagementConnection connection;
        IDisposable connectionToDispose;

        /// <summary>
        /// Contains all the methods to call the /actions endpoints.
        /// </summary>
        public ActionsClient Actions { get; }

        /// <summary>
        /// Contains all the methods to call the /attack-protection endpoints.
        /// </summary>
        public AttackProtectionClient AttackProtection { get; }

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
        /// Contains all the methods to call the /keys endpoints.
        /// </summary>
        public KeysClient Keys { get; }

        /// <summary>
        /// Contains all the methods to call the /logs endpoints.
        /// </summary>
        public LogsClient Logs { get; }

        /// <summary>
        /// Contains all the methods to all the /log-streams endpoints.
        /// </summary>
        public LogStreamsClient LogStreams { get; }

        /// <summary>
        /// Contains all the methods to call the /organizations endpoints.
        /// </summary>
        public OrganizationsClient Organizations { get; }

        /// <summary>
        /// Contains all the methods to call the /prompts endpoints.
        /// </summary>
        public PromptsClient Prompts { get; }

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
        /// Contains all the methods to call the /rules-configs endpoints.
        /// </summary>
        public RulesConfigClient RulesConfig { get; }

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

        private Dictionary<string, string> DefaultHeaders { get; set; }

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

            connection = managementConnection;

            DefaultHeaders = CreateDefaultHeaders(token);

            Actions = new ActionsClient(managementConnection, baseUri, DefaultHeaders);
            AttackProtection = new AttackProtectionClient(managementConnection, baseUri, DefaultHeaders);
            BlacklistedTokens = new BlacklistedTokensClient(managementConnection, baseUri, DefaultHeaders);
            Branding = new BrandingClient(managementConnection, baseUri, DefaultHeaders);
            ClientGrants = new ClientGrantsClient(managementConnection, baseUri, DefaultHeaders);
            Clients = new ClientsClient(managementConnection, baseUri, DefaultHeaders);
            Connections = new ConnectionsClient(managementConnection, baseUri, DefaultHeaders);
            CustomDomains = new CustomDomainsClient(managementConnection, baseUri, DefaultHeaders);
            DeviceCredentials = new DeviceCredentialsClient(managementConnection, baseUri, DefaultHeaders);
            EmailProvider = new EmailProviderClient(managementConnection, baseUri, DefaultHeaders);
            EmailTemplates = new EmailTemplatesClient(managementConnection, baseUri, DefaultHeaders);
            Guardian = new GuardianClient(managementConnection, baseUri, DefaultHeaders);
            Hooks = new HooksClient(managementConnection, baseUri, DefaultHeaders);
            Jobs = new JobsClient(managementConnection, baseUri, DefaultHeaders);
            Keys = new KeysClient(managementConnection, baseUri, DefaultHeaders);
            Logs = new LogsClient(managementConnection, baseUri, DefaultHeaders);
            LogStreams = new LogStreamsClient(managementConnection, baseUri, DefaultHeaders);
            Prompts = new PromptsClient(managementConnection, baseUri, DefaultHeaders);
            Organizations = new OrganizationsClient(managementConnection, baseUri, DefaultHeaders);
            ResourceServers = new ResourceServersClient(managementConnection, baseUri, DefaultHeaders);
            Roles = new RolesClient(managementConnection, baseUri, DefaultHeaders);
            RulesConfig = new RulesConfigClient(managementConnection, baseUri, DefaultHeaders);
            Rules = new RulesClient(managementConnection, baseUri, DefaultHeaders);
            Stats = new StatsClient(managementConnection, baseUri, DefaultHeaders);
            TenantSettings = new TenantSettingsClient(managementConnection, baseUri, DefaultHeaders);
            Tickets = new TicketsClient(managementConnection, baseUri, DefaultHeaders);
            UserBlocks = new UserBlocksClient(managementConnection, baseUri, DefaultHeaders);
            Users = new UsersClient(managementConnection, baseUri, DefaultHeaders);
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


        private static Dictionary<string, string> CreateDefaultHeaders(string token)
        {
            var headers = new Dictionary<string, string> {
                { "Auth0-Client", CreateAgentString() } };

            if (!string.IsNullOrEmpty(token))
                headers.Add(AuthorizationHeaderKey, FormatAuthorizationHeaderValue(token));

            return headers;
        }

        /// <summary>
        /// Update the Access Token used with every request.
        /// </summary>
        /// <param name="token">The new and valid Auth0 Management API v2 token.</param>
        public void UpdateAccessToken(string token)
        {
            DefaultHeaders[AuthorizationHeaderKey] = FormatAuthorizationHeaderValue(token);
        }

        private static string FormatAuthorizationHeaderValue(string token)
        {
            return $"Bearer {token}";
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
