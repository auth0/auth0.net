using Auth0.ManagementApi.Anomaly;
using Auth0.ManagementApi.AttackProtection;
using Auth0.ManagementApi.Emails;
using Auth0.ManagementApi.Guardian;
using Auth0.ManagementApi.Tenants;
using Auth0.ManagementApi.VerifiableCredentials;

namespace Auth0.ManagementApi;

public partial interface IManagementApiClient
{
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
    public IEventsClient Events { get; }
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
