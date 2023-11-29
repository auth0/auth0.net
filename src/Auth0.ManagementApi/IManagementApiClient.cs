namespace Auth0.ManagementApi
{
  using Clients;
  using System;

  public interface IManagementApiClient : IDisposable
  {
    /// <summary>
    /// Contains all the methods to call the /actions endpoints.
    /// </summary>
    IActionsClient Actions { get; }

    /// <summary>
    /// Contains all the methods to call the /attack-protection endpoints.
    /// </summary>
    IAttackProtectionClient AttackProtection { get; }

    /// <summary>
    /// Contains all the methods to call the /blacklists/tokens endpoints.
    /// </summary>
    IBlacklistedTokensClient BlacklistedTokens { get; }

    /// <summary>
    /// Contains all the methods to call the /branding endpoints.
    /// </summary>
    IBrandingClient Branding { get; }

    /// <summary>
    /// Contains all the methods to call the /client-grants endpoints
    /// </summary>
    IClientGrantsClient ClientGrants { get; }

    /// <summary>
    /// Contains all the methods to call the /clients endpoints.
    /// </summary>
    IClientsClient Clients { get; }

    /// <summary>
    /// Contains all the methods to call the /connections endpoints.
    /// </summary>
    IConnectionsClient Connections { get; }

    /// <summary>
    /// Contains all the methods to call the /custom-domains endpoints.
    /// </summary>
    ICustomDomainsClient CustomDomains { get; }

    /// <summary>
    /// Contains all the methods to call the /device-credentials endpoints.
    /// </summary>
    IDeviceCredentialsClient DeviceCredentials { get; }

    /// <summary>
    /// Contains all the methods to call the /emails/provider endpoints.
    /// </summary>
    IEmailProviderClient EmailProvider { get; }

    /// <summary>
    /// Contains all the methods to call the /email-templates endpoints.
    /// </summary>
    IEmailTemplatesClient EmailTemplates { get; }

    /// <summary>
    /// Contains all the methods to call the /grants endpoints.
    /// </summary>
    IGrantsClient Grants { get; }

    /// <summary>
    /// Contains all the methods to call the /guardian endpoints.
    /// </summary>
    IGuardianClient Guardian { get; }

    /// <summary>
    /// Contains all the methods to call the /jobs endpoints.
    /// </summary>
    IJobsClient Jobs { get; }

    /// <summary>
    /// Contains all the methods to call the /keys endpoints.
    /// </summary>
    IKeysClient Keys { get; }

    /// <summary>
    /// Contains all the methods to call the /logs endpoints.
    /// </summary>
    ILogsClient Logs { get; }

    /// <summary>
    /// Contains all the methods to all the /log-streams endpoints.
    /// </summary>
    ILogStreamsClient LogStreams { get; }

    /// <summary>
    /// Contains all the methods to call the /organizations endpoints.
    /// </summary>
    IOrganizationsClient Organizations { get; }

    /// <summary>
    /// Contains all the methods to call the /prompts endpoints.
    /// </summary>
    IPromptsClient Prompts { get; }

    /// <summary>
    /// Contains all the methods to call the /resource-servers endpoints.
    /// </summary>
    IResourceServersClient ResourceServers { get; }

    /// <summary>
    /// Contains all the methods to call the /roles endpoints.
    /// </summary>
    /// <value>The roles.</value>
    IRolesClient Roles { get; }

    /// <summary>
    /// Contains all the methods to call the /rules-configs endpoints.
    /// </summary>
    IRulesConfigClient RulesConfig { get; }

    /// <summary>
    /// Contains all the methods to call the /rules endpoints.
    /// </summary>
    IRulesClient Rules { get; }

    /// <summary>
    /// Contains all the methods to call the /hooks endpoints.
    /// </summary>
    IHooksClient Hooks { get; }

    /// <summary>
    /// Contains all the methods to call the /stats endpoints.
    /// </summary>
    IStatsClient Stats { get; }

    /// <summary>
    /// Contains all the methods to call the /tenants/settings endpoints.
    /// </summary>
    ITenantSettingsClient TenantSettings { get; set; }

    /// <summary>
    /// Contains all the methods to call the /tickets endpoints.
    /// </summary>
    ITicketsClient Tickets { get; }

    /// <summary>
    /// Contains all the methods to call the /user-blocks endpoints.
    /// </summary>
    IUserBlocksClient UserBlocks { get; }

    /// <summary>
    /// Contains all the methods to call the /users endpoints.
    /// </summary>
    IUsersClient Users { get; }

    /// <summary>
    /// Update the Access Token used with every request.
    /// </summary>
    /// <param name="token">The new and valid Auth0 Management API v2 token.</param>
    void UpdateAccessToken(string token);
  }
}
