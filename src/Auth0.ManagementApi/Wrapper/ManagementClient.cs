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
/// Token handling is provided by an <see cref="ITokenProvider"/>:
/// <list type="bullet">
///   <item><see cref="DelegateTokenProvider"/> — retrieve tokens from a custom async source.</item>
///   <item><see cref="ClientCredentialsTokenProvider"/> — automatic token acquisition and refresh via OAuth 2.0 client credentials.</item>
/// </list>
///
/// Example (client credentials):
/// <code>
/// var client = new ManagementClient(new ManagementClientOptions
/// {
///     Domain = "tenant.auth0.com",
///     TokenProvider = new ClientCredentialsTokenProvider("tenant.auth0.com", "client_id", "client_secret")
/// });
/// </code>
/// </summary>
public sealed class ManagementClient : IManagementApiClient, IDisposable
{
    private readonly RawClient _client;
    private readonly HttpClient _httpClient;
    private readonly bool _ownsHttpClient;
    private readonly ITokenProvider _tokenProvider;

    /// <summary>
    /// Creates a new <see cref="ManagementClient"/> instance.
    /// </summary>
    /// <param name="options">Configuration options for the client.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="options"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <see cref="ManagementClientOptions.Domain"/> is empty, whitespace, or contains a scheme prefix.</exception>
    public ManagementClient(ManagementClientOptions options)
    {
        if (options == null) throw new ArgumentNullException(nameof(options));

        if (string.IsNullOrWhiteSpace(options.Domain))
            throw new ArgumentException(
                "Domain must not be empty or whitespace.", nameof(options));
        if (options.Domain.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
            options.Domain.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            throw new ArgumentException(
                "Domain must not include a scheme prefix (e.g. use 'tenant.auth0.com', not 'https://tenant.auth0.com').",
                nameof(options));
        if (options.TokenProvider == null)
            throw new ArgumentNullException(nameof(options), "TokenProvider must not be null.");

        _tokenProvider = options.TokenProvider;

        var baseUrl = $"https://{options.Domain}/api/v2";

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
        var headers = new Headers(new Dictionary<string, string>());

        if (options.AdditionalHeaders != null)
        {
            foreach (var header in options.AdditionalHeaders)
            {
                headers[header.Key] = new HeaderValue(header.Value);
            }
        }
        
        // Wire the async token supplier into the Authorization header.
        // HeaderValue supports Func<Task<string>> which is evaluated per-request.
        Func<Task<string>> authHeaderSupplier = async () =>
            $"Bearer {await _tokenProvider.GetTokenAsync(default).ConfigureAwait(false)}";
        headers["Authorization"] = authHeaderSupplier;

        foreach (var header in headers)
        {
            clientOptions.Headers[header.Key] = header.Value;
        }

        _client = new RawClient(clientOptions);

        Actions = new ActionsClient(_client);
        Branding = new BrandingClient(_client);
        ClientGrants = new ClientGrantsClient(_client);
        Clients = new ClientsClient(_client);
        ConnectionProfiles = new ConnectionProfilesClient(_client);
        Connections = new ConnectionsClient(_client);
        CustomDomains = new CustomDomainsClient(_client);
        DeviceCredentials = new DeviceCredentialsClient(_client);
        EmailTemplates = new EmailTemplatesClient(_client);
        EventStreams = new EventStreamsClient(_client);
        Flows = new FlowsClient(_client);
        Forms = new FormsClient(_client);
        UserGrants = new UserGrantsClient(_client);
        Groups = new GroupsClient(_client);
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
        UserAttributeProfiles = new UserAttributeProfilesClient(_client);
        UserBlocks = new UserBlocksClient(_client);
        Users = new UsersClient(_client);
        Anomaly = new AnomalyClient(_client);
        AttackProtection = new AttackProtectionClient(_client);
        Emails = new EmailsClient(_client);
        Guardian = new GuardianClient(_client);
        Keys = new Auth0.ManagementApi.Keys.KeysClient(_client);
        RiskAssessments = new Auth0.ManagementApi.RiskAssessments.RiskAssessmentsClient(_client);
        Tenants = new TenantsClient(_client);
        VerifiableCredentials = new VerifiableCredentialsClient(_client);
    }

    /// <inheritdoc />
    public IActionsClient Actions { get; }

    /// <inheritdoc />
    public IBrandingClient Branding { get; }

    /// <inheritdoc />
    public IClientGrantsClient ClientGrants { get; }

    /// <inheritdoc />
    public IClientsClient Clients { get; }

    /// <inheritdoc />
    public IConnectionProfilesClient ConnectionProfiles { get; }

    /// <inheritdoc />
    public IConnectionsClient Connections { get; }

    /// <inheritdoc />
    public ICustomDomainsClient CustomDomains { get; }

    /// <inheritdoc />
    public IDeviceCredentialsClient DeviceCredentials { get; }

    /// <inheritdoc />
    public IEmailTemplatesClient EmailTemplates { get; }

    /// <inheritdoc />
    public IEventStreamsClient EventStreams { get; }

    /// <inheritdoc />
    public IFlowsClient Flows { get; }

    /// <inheritdoc />
    public IFormsClient Forms { get; }

    /// <inheritdoc />
    public IUserGrantsClient UserGrants { get; }

    /// <inheritdoc />
    public IGroupsClient Groups { get; }

    /// <inheritdoc />
    public IHooksClient Hooks { get; }

    /// <inheritdoc />
    public IJobsClient Jobs { get; }

    /// <inheritdoc />
    public ILogStreamsClient LogStreams { get; }

    /// <inheritdoc />
    public ILogsClient Logs { get; }

    /// <inheritdoc />
    public INetworkAclsClient NetworkAcls { get; }

    /// <inheritdoc />
    public IOrganizationsClient Organizations { get; }

    /// <inheritdoc />
    public IPromptsClient Prompts { get; }

    /// <inheritdoc />
    public IRefreshTokensClient RefreshTokens { get; }

    /// <inheritdoc />
    public IResourceServersClient ResourceServers { get; }

    /// <inheritdoc />
    public IRolesClient Roles { get; }

    /// <inheritdoc />
    public IRulesClient Rules { get; }

    /// <inheritdoc />
    public IRulesConfigsClient RulesConfigs { get; }

    /// <inheritdoc />
    public ISelfServiceProfilesClient SelfServiceProfiles { get; }

    /// <inheritdoc />
    public ISessionsClient Sessions { get; }

    /// <inheritdoc />
    public IStatsClient Stats { get; }

    /// <inheritdoc />
    public ISupplementalSignalsClient SupplementalSignals { get; }

    /// <inheritdoc />
    public ITicketsClient Tickets { get; }

    /// <inheritdoc />
    public ITokenExchangeProfilesClient TokenExchangeProfiles { get; }

    /// <inheritdoc />
    public IUserAttributeProfilesClient UserAttributeProfiles { get; }

    /// <inheritdoc />
    public IUserBlocksClient UserBlocks { get; }

    /// <inheritdoc />
    public IUsersClient Users { get; }

    /// <inheritdoc />
    public IAnomalyClient Anomaly { get; }

    /// <inheritdoc />
    public IAttackProtectionClient AttackProtection { get; }

    /// <inheritdoc />
    public IEmailsClient Emails { get; }

    /// <inheritdoc />
    public IGuardianClient Guardian { get; }

    /// <inheritdoc />
    public Auth0.ManagementApi.Keys.IKeysClient Keys { get; }

    /// <inheritdoc />
    public Auth0.ManagementApi.RiskAssessments.IRiskAssessmentsClient RiskAssessments { get; }

    /// <inheritdoc />
    public ITenantsClient Tenants { get; }

    /// <inheritdoc />
    public IVerifiableCredentialsClient VerifiableCredentials { get; }

    /// <summary>
    /// Disposes the <see cref="ManagementClient"/> and releases managed resources.
    /// Only disposes the internal <see cref="HttpClient"/> if it was created by this instance.
    /// The <see cref="ITokenProvider"/> is not disposed — the caller owns it and is responsible for its lifetime.
    /// </summary>
    public void Dispose()
    {
        if (_ownsHttpClient)
        {
            _httpClient.Dispose();
        }
    }
}
