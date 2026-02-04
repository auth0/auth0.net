using Auth0.ManagementApi.Anomaly;
using Auth0.ManagementApi.AttackProtection;
using Auth0.ManagementApi.Core;
using Auth0.ManagementApi.Emails;
using Auth0.ManagementApi.Guardian;
using Auth0.ManagementApi.Tenants;
using Auth0.ManagementApi.VerifiableCredentials;

namespace Auth0.ManagementApi;

/// <summary>
/// Auth0 Management API client with automatic token management.
///
/// Supports two initialization patterns:
///
/// 1. With an existing token:
///    <code>
///    var client = new ManagementClient(new ManagementClientOptions
///    {
///        Domain = "tenant.auth0.com",
///        Token = "your_token"
///    });
///    </code>
///
/// 2. With client credentials (automatic token acquisition and refresh):
///    <code>
///    var client = new ManagementClient(new ManagementClientOptions
///    {
///        Domain = "tenant.auth0.com",
///        ClientId = "your_client_id",
///        ClientSecret = "your_client_secret"
///    });
///    </code>
/// </summary>
public sealed class ManagementClient : IDisposable
{
    private readonly RawClient _client;
    private readonly HttpClient _httpClient;
    private readonly bool _ownsHttpClient;

    /// <summary>
    /// Creates a new Management API client instance.
    /// </summary>
    /// <param name="options">Configuration options for the client.</param>
    /// <exception cref="ArgumentNullException">Thrown when options is null.</exception>
    /// <exception cref="ArgumentException">Thrown when required authentication options are missing.</exception>
    public ManagementClient(ManagementClientOptions options)
    {
        if (options == null)
            throw new ArgumentNullException(nameof(options));

        ValidateOptions(options);

        var baseUrl = $"https://{options.Domain}/api/v2";
        var tokenSupplier = CreateTokenSupplier(options);

        _ownsHttpClient = options.HttpClient == null;
        _httpClient = options.HttpClient ?? new HttpClient();

        var clientOptions = new ClientOptions
        {
            BaseUrl = baseUrl,
            HttpClient = _httpClient,
            Timeout = options.Timeout ?? TimeSpan.FromSeconds(30),
            MaxRetries = options.MaxRetries ?? 2,
        };

        // Set up headers with dynamic token supplier
        var headers = new Headers(new Dictionary<string, string>
        {
            { "X-Fern-Language", "C#" },
            { "X-Fern-SDK-Name", "Auth0.ManagementApi" },
            { "X-Fern-SDK-Version", Version.Current },
        });

        // Add Authorization header with token supplier (supports Func<string>)
        Func<string> authHeaderSupplier = () => $"Bearer {tokenSupplier()}";
        headers["Authorization"] = authHeaderSupplier;

        // Add any additional headers
        if (options.AdditionalHeaders != null)
        {
            foreach (var header in options.AdditionalHeaders)
            {
                headers[header.Key] = new HeaderValue(header.Value);
            }
        }

        // Copy headers to ClientOptions
        foreach (var header in headers)
        {
            clientOptions.Headers[header.Key] = header.Value;
        }

        _client = new RawClient(clientOptions);

        // Initialize all sub-clients
        Actions = new ActionsClient(_client);
        Branding = new BrandingClient(_client);
        ClientGrants = new ClientGrantsClient(_client);
        Clients = new ClientsClient(_client);
        Connections = new ConnectionsClient(_client);
        CustomDomains = new CustomDomainsClient(_client);
        DeviceCredentials = new DeviceCredentialsClient(_client);
        EmailTemplates = new EmailTemplatesClient(_client);
        EventStreams = new EventStreamsClient(_client);
        Flows = new FlowsClient(_client);
        Forms = new FormsClient(_client);
        UserGrants = new UserGrantsClient(_client);
        Hooks = new HooksClient(_client);
        Jobs = new JobsClient(_client);
        LogStreams = new LogStreamsClient(_client);
        Logs = new LogsClient(_client);
        NetworkAcls = new NetworkAclsClient(_client);
        Organizations = new OrganizationsClient(_client);
        Prompts = new PromptsClient(_client);
        RefreshTokens = new RefreshTokensClient(_client);
        ResourceServers = new ResourceServersClient(_client);
        Roles = new RolesClient(_client);
        Rules = new RulesClient(_client);
        RulesConfigs = new RulesConfigsClient(_client);
        SelfServiceProfiles = new SelfServiceProfilesClient(_client);
        Sessions = new SessionsClient(_client);
        Stats = new StatsClient(_client);
        SupplementalSignals = new SupplementalSignalsClient(_client);
        Tickets = new TicketsClient(_client);
        TokenExchangeProfiles = new TokenExchangeProfilesClient(_client);
        UserBlocks = new UserBlocksClient(_client);
        Users = new UsersClient(_client);
        Anomaly = new AnomalyClient(_client);
        AttackProtection = new AttackProtectionClient(_client);
        Emails = new EmailsClient(_client);
        Guardian = new GuardianClient(_client);
        Keys = new Auth0.ManagementApi.Keys.KeysClient(_client);
        Tenants = new TenantsClient(_client);
        VerifiableCredentials = new VerifiableCredentialsClient(_client);
    }

    private static void ValidateOptions(ManagementClientOptions options)
    {
        var hasToken = options.Token != null || options.TokenProvider != null;
        var hasClientId = options.ClientId != null;
        var hasClientSecret = options.ClientSecret != null;
        var hasCredentials = hasClientId && hasClientSecret;

        if (!hasToken && !hasCredentials)
        {
            throw new ArgumentException(
                "Either 'Token'/'TokenProvider' or both 'ClientId' and 'ClientSecret' must be provided.",
                nameof(options));
        }

        if (hasClientId && !hasClientSecret)
        {
            throw new ArgumentException(
                "'ClientSecret' is required when 'ClientId' is provided.",
                nameof(options));
        }

        if (!hasClientId && hasClientSecret)
        {
            throw new ArgumentException(
                "'ClientId' is required when 'ClientSecret' is provided.",
                nameof(options));
        }
    }

    private static Func<string> CreateTokenSupplier(ManagementClientOptions options)
    {
        // If a token provider function is provided, use it
        if (options.TokenProvider != null)
        {
            return options.TokenProvider;
        }

        // If a static token is provided, return it
        if (options.Token != null)
        {
            var token = options.Token;
            return () => token;
        }

        // Otherwise, create a TokenProvider for client credentials
        var tokenProvider = new TokenProvider(
            domain: options.Domain,
            clientId: options.ClientId!,
            clientSecret: options.ClientSecret!,
            audience: options.Audience,
            httpClient: options.HttpClient);

        return tokenProvider.GetToken;
    }

    /// <summary>Actions management.</summary>
    public ActionsClient Actions { get; }

    /// <summary>Branding settings management.</summary>
    public BrandingClient Branding { get; }

    /// <summary>Client grants management.</summary>
    public ClientGrantsClient ClientGrants { get; }

    /// <summary>OAuth applications management.</summary>
    public ClientsClient Clients { get; }

    /// <summary>Connections management.</summary>
    public ConnectionsClient Connections { get; }

    /// <summary>Custom domains management.</summary>
    public CustomDomainsClient CustomDomains { get; }

    /// <summary>Device credentials management.</summary>
    public DeviceCredentialsClient DeviceCredentials { get; }

    /// <summary>Email templates management.</summary>
    public EmailTemplatesClient EmailTemplates { get; }

    /// <summary>Event streams management.</summary>
    public EventStreamsClient EventStreams { get; }

    /// <summary>Flows management.</summary>
    public FlowsClient Flows { get; }

    /// <summary>Forms management.</summary>
    public FormsClient Forms { get; }

    /// <summary>User grants management.</summary>
    public UserGrantsClient UserGrants { get; }

    /// <summary>Hooks management.</summary>
    public HooksClient Hooks { get; }

    /// <summary>Background jobs management.</summary>
    public JobsClient Jobs { get; }

    /// <summary>Log streams management.</summary>
    public LogStreamsClient LogStreams { get; }

    /// <summary>Auth logs access.</summary>
    public LogsClient Logs { get; }

    /// <summary>Network ACLs management.</summary>
    public NetworkAclsClient NetworkAcls { get; }

    /// <summary>Organizations management.</summary>
    public OrganizationsClient Organizations { get; }

    /// <summary>Prompts customization.</summary>
    public PromptsClient Prompts { get; }

    /// <summary>Refresh tokens management.</summary>
    public RefreshTokensClient RefreshTokens { get; }

    /// <summary>Resource servers (APIs) management.</summary>
    public ResourceServersClient ResourceServers { get; }

    /// <summary>Roles management.</summary>
    public RolesClient Roles { get; }

    /// <summary>Rules management.</summary>
    public RulesClient Rules { get; }

    /// <summary>Rules configs management.</summary>
    public RulesConfigsClient RulesConfigs { get; }

    /// <summary>Self-service profiles management.</summary>
    public SelfServiceProfilesClient SelfServiceProfiles { get; }

    /// <summary>Sessions management.</summary>
    public SessionsClient Sessions { get; }

    /// <summary>Statistics access.</summary>
    public StatsClient Stats { get; }

    /// <summary>Supplemental signals management.</summary>
    public SupplementalSignalsClient SupplementalSignals { get; }

    /// <summary>Email/password reset tickets.</summary>
    public TicketsClient Tickets { get; }

    /// <summary>Token exchange profiles management.</summary>
    public TokenExchangeProfilesClient TokenExchangeProfiles { get; }

    /// <summary>User blocks management.</summary>
    public UserBlocksClient UserBlocks { get; }

    /// <summary>Users management.</summary>
    public UsersClient Users { get; }

    /// <summary>Anomaly detection settings.</summary>
    public AnomalyClient Anomaly { get; }

    /// <summary>Attack protection settings.</summary>
    public AttackProtectionClient AttackProtection { get; }

    /// <summary>Email provider settings.</summary>
    public EmailsClient Emails { get; }

    /// <summary>Guardian MFA settings.</summary>
    public GuardianClient Guardian { get; }

    /// <summary>Signing keys management.</summary>
    public Auth0.ManagementApi.Keys.KeysClient Keys { get; }

    /// <summary>Tenant settings.</summary>
    public TenantsClient Tenants { get; }

    /// <summary>Verifiable credentials management.</summary>
    public VerifiableCredentialsClient VerifiableCredentials { get; }

    /// <summary>
    /// Disposes the ManagementClient and releases resources.
    /// Only disposes the HttpClient if it was created internally (not provided via options).
    /// </summary>
    public void Dispose()
    {
        if (_ownsHttpClient)
        {
            _httpClient.Dispose();
        }
    }
}
