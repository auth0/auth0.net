using Auth0.ManagementApi.Anomaly;
using Auth0.ManagementApi.AttackProtection;
using Auth0.ManagementApi.Core;
using Auth0.ManagementApi.Emails;
using Auth0.ManagementApi.Guardian;
using Auth0.ManagementApi.Tenants;
using Auth0.ManagementApi.VerifiableCredentials;

namespace Auth0.ManagementApi;

public partial class ManagementApiClient : IManagementApiClient
{
    private readonly RawClient _client;

    public ManagementApiClient(string? token = null, ClientOptions? clientOptions = null)
    {
        clientOptions ??= new ClientOptions();
        var clientOptionsWithAuth = clientOptions.Clone();
        var authHeaders = new Headers(
            new Dictionary<string, string>() { { "Authorization", $"Bearer {token ?? ""}" } }
        );
        foreach (var header in authHeaders)
        {
            clientOptionsWithAuth.Headers[header.Key] = header.Value;
        }
        _client = new RawClient(clientOptionsWithAuth);
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

    public IActionsClient Actions { get; }

    public IBrandingClient Branding { get; }

    public IClientGrantsClient ClientGrants { get; }

    public IClientsClient Clients { get; }

    public IConnectionProfilesClient ConnectionProfiles { get; }

    public IConnectionsClient Connections { get; }

    public ICustomDomainsClient CustomDomains { get; }

    public IDeviceCredentialsClient DeviceCredentials { get; }

    public IEmailTemplatesClient EmailTemplates { get; }

    public IEventStreamsClient EventStreams { get; }

    public IFlowsClient Flows { get; }

    public IFormsClient Forms { get; }

    public IUserGrantsClient UserGrants { get; }

    public IGroupsClient Groups { get; }

    public IHooksClient Hooks { get; }

    public IJobsClient Jobs { get; }

    public ILogStreamsClient LogStreams { get; }

    public ILogsClient Logs { get; }

    public INetworkAclsClient NetworkAcls { get; }

    public IOrganizationsClient Organizations { get; }

    public IPromptsClient Prompts { get; }

    public IRefreshTokensClient RefreshTokens { get; }

    public IResourceServersClient ResourceServers { get; }

    public IRolesClient Roles { get; }

    public IRulesClient Rules { get; }

    public IRulesConfigsClient RulesConfigs { get; }

    public ISelfServiceProfilesClient SelfServiceProfiles { get; }

    public ISessionsClient Sessions { get; }

    public IStatsClient Stats { get; }

    public ISupplementalSignalsClient SupplementalSignals { get; }

    public ITicketsClient Tickets { get; }

    public ITokenExchangeProfilesClient TokenExchangeProfiles { get; }

    public IUserAttributeProfilesClient UserAttributeProfiles { get; }

    public IUserBlocksClient UserBlocks { get; }

    public IUsersClient Users { get; }

    public IAnomalyClient Anomaly { get; }

    public IAttackProtectionClient AttackProtection { get; }

    public IEmailsClient Emails { get; }

    public IGuardianClient Guardian { get; }

    public Auth0.ManagementApi.Keys.IKeysClient Keys { get; }

    public Auth0.ManagementApi.RiskAssessments.IRiskAssessmentsClient RiskAssessments { get; }

    public ITenantsClient Tenants { get; }

    public IVerifiableCredentialsClient VerifiableCredentials { get; }
}
