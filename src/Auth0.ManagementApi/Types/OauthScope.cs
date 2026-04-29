using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(OauthScope.OauthScopeSerializer))]
[Serializable]
public readonly record struct OauthScope : IStringEnum
{
    /// <summary>
    /// Create Actions
    /// </summary>
    public static readonly OauthScope CreateActions = new(Values.CreateActions);

    /// <summary>
    /// Read Actions
    /// </summary>
    public static readonly OauthScope ReadActions = new(Values.ReadActions);

    /// <summary>
    /// Update Actions
    /// </summary>
    public static readonly OauthScope UpdateActions = new(Values.UpdateActions);

    /// <summary>
    /// Delete Actions
    /// </summary>
    public static readonly OauthScope DeleteActions = new(Values.DeleteActions);

    /// <summary>
    /// Read Anomaly Blocks
    /// </summary>
    public static readonly OauthScope ReadAnomalyBlocks = new(Values.ReadAnomalyBlocks);

    /// <summary>
    /// Delete Anomaly Blocks
    /// </summary>
    public static readonly OauthScope DeleteAnomalyBlocks = new(Values.DeleteAnomalyBlocks);

    /// <summary>
    /// Read Attack Protection
    /// </summary>
    public static readonly OauthScope ReadAttackProtection = new(Values.ReadAttackProtection);

    /// <summary>
    /// Update Attack Protection
    /// </summary>
    public static readonly OauthScope UpdateAttackProtection = new(Values.UpdateAttackProtection);

    /// <summary>
    /// Create Authentication Methods
    /// </summary>
    public static readonly OauthScope CreateAuthenticationMethods = new(
        Values.CreateAuthenticationMethods
    );

    /// <summary>
    /// Read Authentication Methods
    /// </summary>
    public static readonly OauthScope ReadAuthenticationMethods = new(
        Values.ReadAuthenticationMethods
    );

    /// <summary>
    /// Update Authentication Methods
    /// </summary>
    public static readonly OauthScope UpdateAuthenticationMethods = new(
        Values.UpdateAuthenticationMethods
    );

    /// <summary>
    /// Delete Authentication Methods
    /// </summary>
    public static readonly OauthScope DeleteAuthenticationMethods = new(
        Values.DeleteAuthenticationMethods
    );

    /// <summary>
    /// Read Branding
    /// </summary>
    public static readonly OauthScope ReadBranding = new(Values.ReadBranding);

    /// <summary>
    /// Update Branding
    /// </summary>
    public static readonly OauthScope UpdateBranding = new(Values.UpdateBranding);

    /// <summary>
    /// Delete Branding
    /// </summary>
    public static readonly OauthScope DeleteBranding = new(Values.DeleteBranding);

    /// <summary>
    /// Create Client Credentials
    /// </summary>
    public static readonly OauthScope CreateClientCredentials = new(Values.CreateClientCredentials);

    /// <summary>
    /// Read Client Credentials
    /// </summary>
    public static readonly OauthScope ReadClientCredentials = new(Values.ReadClientCredentials);

    /// <summary>
    /// Update Client Credentials
    /// </summary>
    public static readonly OauthScope UpdateClientCredentials = new(Values.UpdateClientCredentials);

    /// <summary>
    /// Delete Client Credentials
    /// </summary>
    public static readonly OauthScope DeleteClientCredentials = new(Values.DeleteClientCredentials);

    /// <summary>
    /// Create Client Grants
    /// </summary>
    public static readonly OauthScope CreateClientGrants = new(Values.CreateClientGrants);

    /// <summary>
    /// Read Client Grants
    /// </summary>
    public static readonly OauthScope ReadClientGrants = new(Values.ReadClientGrants);

    /// <summary>
    /// Update Client Grants
    /// </summary>
    public static readonly OauthScope UpdateClientGrants = new(Values.UpdateClientGrants);

    /// <summary>
    /// Delete Client Grants
    /// </summary>
    public static readonly OauthScope DeleteClientGrants = new(Values.DeleteClientGrants);

    /// <summary>
    /// Read Client Keys
    /// </summary>
    public static readonly OauthScope ReadClientKeys = new(Values.ReadClientKeys);

    /// <summary>
    /// Update Client Keys
    /// </summary>
    public static readonly OauthScope UpdateClientKeys = new(Values.UpdateClientKeys);

    /// <summary>
    /// Read Client Summary
    /// </summary>
    public static readonly OauthScope ReadClientSummary = new(Values.ReadClientSummary);

    /// <summary>
    /// Update Client Token Vault Privileged Access
    /// </summary>
    public static readonly OauthScope UpdateClientTokenVaultPrivilegedAccess = new(
        Values.UpdateClientTokenVaultPrivilegedAccess
    );

    /// <summary>
    /// Create Clients
    /// </summary>
    public static readonly OauthScope CreateClients = new(Values.CreateClients);

    /// <summary>
    /// Read Clients
    /// </summary>
    public static readonly OauthScope ReadClients = new(Values.ReadClients);

    /// <summary>
    /// Update Clients
    /// </summary>
    public static readonly OauthScope UpdateClients = new(Values.UpdateClients);

    /// <summary>
    /// Delete Clients
    /// </summary>
    public static readonly OauthScope DeleteClients = new(Values.DeleteClients);

    /// <summary>
    /// Create Connection Profiles
    /// </summary>
    public static readonly OauthScope CreateConnectionProfiles = new(
        Values.CreateConnectionProfiles
    );

    /// <summary>
    /// Read Connection Profiles
    /// </summary>
    public static readonly OauthScope ReadConnectionProfiles = new(Values.ReadConnectionProfiles);

    /// <summary>
    /// Update Connection Profiles
    /// </summary>
    public static readonly OauthScope UpdateConnectionProfiles = new(
        Values.UpdateConnectionProfiles
    );

    /// <summary>
    /// Delete Connection Profiles
    /// </summary>
    public static readonly OauthScope DeleteConnectionProfiles = new(
        Values.DeleteConnectionProfiles
    );

    /// <summary>
    /// Create Connections
    /// </summary>
    public static readonly OauthScope CreateConnections = new(Values.CreateConnections);

    /// <summary>
    /// Read Connections
    /// </summary>
    public static readonly OauthScope ReadConnections = new(Values.ReadConnections);

    /// <summary>
    /// Update Connections
    /// </summary>
    public static readonly OauthScope UpdateConnections = new(Values.UpdateConnections);

    /// <summary>
    /// Delete Connections
    /// </summary>
    public static readonly OauthScope DeleteConnections = new(Values.DeleteConnections);

    /// <summary>
    /// Create Connections Keys
    /// </summary>
    public static readonly OauthScope CreateConnectionsKeys = new(Values.CreateConnectionsKeys);

    /// <summary>
    /// Read Connections Keys
    /// </summary>
    public static readonly OauthScope ReadConnectionsKeys = new(Values.ReadConnectionsKeys);

    /// <summary>
    /// Update Connections Keys
    /// </summary>
    public static readonly OauthScope UpdateConnectionsKeys = new(Values.UpdateConnectionsKeys);

    /// <summary>
    /// Read Current User
    /// </summary>
    public static readonly OauthScope ReadCurrentUser = new(Values.ReadCurrentUser);

    /// <summary>
    /// Delete Current User
    /// </summary>
    public static readonly OauthScope DeleteCurrentUser = new(Values.DeleteCurrentUser);

    /// <summary>
    /// Create Current User Device Credentials
    /// </summary>
    public static readonly OauthScope CreateCurrentUserDeviceCredentials = new(
        Values.CreateCurrentUserDeviceCredentials
    );

    /// <summary>
    /// Delete Current User Device Credentials
    /// </summary>
    public static readonly OauthScope DeleteCurrentUserDeviceCredentials = new(
        Values.DeleteCurrentUserDeviceCredentials
    );

    /// <summary>
    /// Update Current User Identities
    /// </summary>
    public static readonly OauthScope UpdateCurrentUserIdentities = new(
        Values.UpdateCurrentUserIdentities
    );

    /// <summary>
    /// Update Current User Metadata
    /// </summary>
    public static readonly OauthScope UpdateCurrentUserMetadata = new(
        Values.UpdateCurrentUserMetadata
    );

    /// <summary>
    /// Create Custom Domains
    /// </summary>
    public static readonly OauthScope CreateCustomDomains = new(Values.CreateCustomDomains);

    /// <summary>
    /// Read Custom Domains
    /// </summary>
    public static readonly OauthScope ReadCustomDomains = new(Values.ReadCustomDomains);

    /// <summary>
    /// Update Custom Domains
    /// </summary>
    public static readonly OauthScope UpdateCustomDomains = new(Values.UpdateCustomDomains);

    /// <summary>
    /// Delete Custom Domains
    /// </summary>
    public static readonly OauthScope DeleteCustomDomains = new(Values.DeleteCustomDomains);

    /// <summary>
    /// Create Custom Signing Keys
    /// </summary>
    public static readonly OauthScope CreateCustomSigningKeys = new(Values.CreateCustomSigningKeys);

    /// <summary>
    /// Read Custom Signing Keys
    /// </summary>
    public static readonly OauthScope ReadCustomSigningKeys = new(Values.ReadCustomSigningKeys);

    /// <summary>
    /// Update Custom Signing Keys
    /// </summary>
    public static readonly OauthScope UpdateCustomSigningKeys = new(Values.UpdateCustomSigningKeys);

    /// <summary>
    /// Delete Custom Signing Keys
    /// </summary>
    public static readonly OauthScope DeleteCustomSigningKeys = new(Values.DeleteCustomSigningKeys);

    /// <summary>
    /// Read Device Credentials
    /// </summary>
    public static readonly OauthScope ReadDeviceCredentials = new(Values.ReadDeviceCredentials);

    /// <summary>
    /// Delete Device Credentials
    /// </summary>
    public static readonly OauthScope DeleteDeviceCredentials = new(Values.DeleteDeviceCredentials);

    /// <summary>
    /// Create Directory Provisionings
    /// </summary>
    public static readonly OauthScope CreateDirectoryProvisionings = new(
        Values.CreateDirectoryProvisionings
    );

    /// <summary>
    /// Read Directory Provisionings
    /// </summary>
    public static readonly OauthScope ReadDirectoryProvisionings = new(
        Values.ReadDirectoryProvisionings
    );

    /// <summary>
    /// Update Directory Provisionings
    /// </summary>
    public static readonly OauthScope UpdateDirectoryProvisionings = new(
        Values.UpdateDirectoryProvisionings
    );

    /// <summary>
    /// Delete Directory Provisionings
    /// </summary>
    public static readonly OauthScope DeleteDirectoryProvisionings = new(
        Values.DeleteDirectoryProvisionings
    );

    /// <summary>
    /// Create Email Provider
    /// </summary>
    public static readonly OauthScope CreateEmailProvider = new(Values.CreateEmailProvider);

    /// <summary>
    /// Read Email Provider
    /// </summary>
    public static readonly OauthScope ReadEmailProvider = new(Values.ReadEmailProvider);

    /// <summary>
    /// Update Email Provider
    /// </summary>
    public static readonly OauthScope UpdateEmailProvider = new(Values.UpdateEmailProvider);

    /// <summary>
    /// Delete Email Provider
    /// </summary>
    public static readonly OauthScope DeleteEmailProvider = new(Values.DeleteEmailProvider);

    /// <summary>
    /// Create Email Templates
    /// </summary>
    public static readonly OauthScope CreateEmailTemplates = new(Values.CreateEmailTemplates);

    /// <summary>
    /// Read Email Templates
    /// </summary>
    public static readonly OauthScope ReadEmailTemplates = new(Values.ReadEmailTemplates);

    /// <summary>
    /// Update Email Templates
    /// </summary>
    public static readonly OauthScope UpdateEmailTemplates = new(Values.UpdateEmailTemplates);

    /// <summary>
    /// Create Encryption Keys
    /// </summary>
    public static readonly OauthScope CreateEncryptionKeys = new(Values.CreateEncryptionKeys);

    /// <summary>
    /// Read Encryption Keys
    /// </summary>
    public static readonly OauthScope ReadEncryptionKeys = new(Values.ReadEncryptionKeys);

    /// <summary>
    /// Update Encryption Keys
    /// </summary>
    public static readonly OauthScope UpdateEncryptionKeys = new(Values.UpdateEncryptionKeys);

    /// <summary>
    /// Delete Encryption Keys
    /// </summary>
    public static readonly OauthScope DeleteEncryptionKeys = new(Values.DeleteEncryptionKeys);

    /// <summary>
    /// Read Event Deliveries
    /// </summary>
    public static readonly OauthScope ReadEventDeliveries = new(Values.ReadEventDeliveries);

    /// <summary>
    /// Update Event Deliveries
    /// </summary>
    public static readonly OauthScope UpdateEventDeliveries = new(Values.UpdateEventDeliveries);

    /// <summary>
    /// Create Event Streams
    /// </summary>
    public static readonly OauthScope CreateEventStreams = new(Values.CreateEventStreams);

    /// <summary>
    /// Read Event Streams
    /// </summary>
    public static readonly OauthScope ReadEventStreams = new(Values.ReadEventStreams);

    /// <summary>
    /// Update Event Streams
    /// </summary>
    public static readonly OauthScope UpdateEventStreams = new(Values.UpdateEventStreams);

    /// <summary>
    /// Delete Event Streams
    /// </summary>
    public static readonly OauthScope DeleteEventStreams = new(Values.DeleteEventStreams);

    /// <summary>
    /// Read Events
    /// </summary>
    public static readonly OauthScope ReadEvents = new(Values.ReadEvents);

    /// <summary>
    /// Read Federated Connections Tokens
    /// </summary>
    public static readonly OauthScope ReadFederatedConnectionsTokens = new(
        Values.ReadFederatedConnectionsTokens
    );

    /// <summary>
    /// Delete Federated Connections Tokens
    /// </summary>
    public static readonly OauthScope DeleteFederatedConnectionsTokens = new(
        Values.DeleteFederatedConnectionsTokens
    );

    /// <summary>
    /// Create Flows
    /// </summary>
    public static readonly OauthScope CreateFlows = new(Values.CreateFlows);

    /// <summary>
    /// Read Flows
    /// </summary>
    public static readonly OauthScope ReadFlows = new(Values.ReadFlows);

    /// <summary>
    /// Update Flows
    /// </summary>
    public static readonly OauthScope UpdateFlows = new(Values.UpdateFlows);

    /// <summary>
    /// Delete Flows
    /// </summary>
    public static readonly OauthScope DeleteFlows = new(Values.DeleteFlows);

    /// <summary>
    /// Read Flows Executions
    /// </summary>
    public static readonly OauthScope ReadFlowsExecutions = new(Values.ReadFlowsExecutions);

    /// <summary>
    /// Delete Flows Executions
    /// </summary>
    public static readonly OauthScope DeleteFlowsExecutions = new(Values.DeleteFlowsExecutions);

    /// <summary>
    /// Create Flows Vault Connections
    /// </summary>
    public static readonly OauthScope CreateFlowsVaultConnections = new(
        Values.CreateFlowsVaultConnections
    );

    /// <summary>
    /// Read Flows Vault Connections
    /// </summary>
    public static readonly OauthScope ReadFlowsVaultConnections = new(
        Values.ReadFlowsVaultConnections
    );

    /// <summary>
    /// Update Flows Vault Connections
    /// </summary>
    public static readonly OauthScope UpdateFlowsVaultConnections = new(
        Values.UpdateFlowsVaultConnections
    );

    /// <summary>
    /// Delete Flows Vault Connections
    /// </summary>
    public static readonly OauthScope DeleteFlowsVaultConnections = new(
        Values.DeleteFlowsVaultConnections
    );

    /// <summary>
    /// Create Forms
    /// </summary>
    public static readonly OauthScope CreateForms = new(Values.CreateForms);

    /// <summary>
    /// Read Forms
    /// </summary>
    public static readonly OauthScope ReadForms = new(Values.ReadForms);

    /// <summary>
    /// Update Forms
    /// </summary>
    public static readonly OauthScope UpdateForms = new(Values.UpdateForms);

    /// <summary>
    /// Delete Forms
    /// </summary>
    public static readonly OauthScope DeleteForms = new(Values.DeleteForms);

    /// <summary>
    /// Read Grants
    /// </summary>
    public static readonly OauthScope ReadGrants = new(Values.ReadGrants);

    /// <summary>
    /// Delete Grants
    /// </summary>
    public static readonly OauthScope DeleteGrants = new(Values.DeleteGrants);

    /// <summary>
    /// Read Group Members
    /// </summary>
    public static readonly OauthScope ReadGroupMembers = new(Values.ReadGroupMembers);

    /// <summary>
    /// Read Groups
    /// </summary>
    public static readonly OauthScope ReadGroups = new(Values.ReadGroups);

    /// <summary>
    /// Delete Groups
    /// </summary>
    public static readonly OauthScope DeleteGroups = new(Values.DeleteGroups);

    /// <summary>
    /// Create Guardian Enrollment Tickets
    /// </summary>
    public static readonly OauthScope CreateGuardianEnrollmentTickets = new(
        Values.CreateGuardianEnrollmentTickets
    );

    /// <summary>
    /// Read Guardian Enrollments
    /// </summary>
    public static readonly OauthScope ReadGuardianEnrollments = new(Values.ReadGuardianEnrollments);

    /// <summary>
    /// Delete Guardian Enrollments
    /// </summary>
    public static readonly OauthScope DeleteGuardianEnrollments = new(
        Values.DeleteGuardianEnrollments
    );

    /// <summary>
    /// Read Guardian Factors
    /// </summary>
    public static readonly OauthScope ReadGuardianFactors = new(Values.ReadGuardianFactors);

    /// <summary>
    /// Update Guardian Factors
    /// </summary>
    public static readonly OauthScope UpdateGuardianFactors = new(Values.UpdateGuardianFactors);

    /// <summary>
    /// Create Hooks
    /// </summary>
    public static readonly OauthScope CreateHooks = new(Values.CreateHooks);

    /// <summary>
    /// Read Hooks
    /// </summary>
    public static readonly OauthScope ReadHooks = new(Values.ReadHooks);

    /// <summary>
    /// Update Hooks
    /// </summary>
    public static readonly OauthScope UpdateHooks = new(Values.UpdateHooks);

    /// <summary>
    /// Delete Hooks
    /// </summary>
    public static readonly OauthScope DeleteHooks = new(Values.DeleteHooks);

    /// <summary>
    /// Create Log Streams
    /// </summary>
    public static readonly OauthScope CreateLogStreams = new(Values.CreateLogStreams);

    /// <summary>
    /// Read Log Streams
    /// </summary>
    public static readonly OauthScope ReadLogStreams = new(Values.ReadLogStreams);

    /// <summary>
    /// Update Log Streams
    /// </summary>
    public static readonly OauthScope UpdateLogStreams = new(Values.UpdateLogStreams);

    /// <summary>
    /// Delete Log Streams
    /// </summary>
    public static readonly OauthScope DeleteLogStreams = new(Values.DeleteLogStreams);

    /// <summary>
    /// Read Logs
    /// </summary>
    public static readonly OauthScope ReadLogs = new(Values.ReadLogs);

    /// <summary>
    /// Read Logs Users
    /// </summary>
    public static readonly OauthScope ReadLogsUsers = new(Values.ReadLogsUsers);

    /// <summary>
    /// Read Mfa Policies
    /// </summary>
    public static readonly OauthScope ReadMfaPolicies = new(Values.ReadMfaPolicies);

    /// <summary>
    /// Update Mfa Policies
    /// </summary>
    public static readonly OauthScope UpdateMfaPolicies = new(Values.UpdateMfaPolicies);

    /// <summary>
    /// Create Network Acls
    /// </summary>
    public static readonly OauthScope CreateNetworkAcls = new(Values.CreateNetworkAcls);

    /// <summary>
    /// Read Network Acls
    /// </summary>
    public static readonly OauthScope ReadNetworkAcls = new(Values.ReadNetworkAcls);

    /// <summary>
    /// Update Network Acls
    /// </summary>
    public static readonly OauthScope UpdateNetworkAcls = new(Values.UpdateNetworkAcls);

    /// <summary>
    /// Delete Network Acls
    /// </summary>
    public static readonly OauthScope DeleteNetworkAcls = new(Values.DeleteNetworkAcls);

    /// <summary>
    /// Create Organization Client Grants
    /// </summary>
    public static readonly OauthScope CreateOrganizationClientGrants = new(
        Values.CreateOrganizationClientGrants
    );

    /// <summary>
    /// Read Organization Client Grants
    /// </summary>
    public static readonly OauthScope ReadOrganizationClientGrants = new(
        Values.ReadOrganizationClientGrants
    );

    /// <summary>
    /// Delete Organization Client Grants
    /// </summary>
    public static readonly OauthScope DeleteOrganizationClientGrants = new(
        Values.DeleteOrganizationClientGrants
    );

    /// <summary>
    /// Create Organization Connections
    /// </summary>
    public static readonly OauthScope CreateOrganizationConnections = new(
        Values.CreateOrganizationConnections
    );

    /// <summary>
    /// Read Organization Connections
    /// </summary>
    public static readonly OauthScope ReadOrganizationConnections = new(
        Values.ReadOrganizationConnections
    );

    /// <summary>
    /// Update Organization Connections
    /// </summary>
    public static readonly OauthScope UpdateOrganizationConnections = new(
        Values.UpdateOrganizationConnections
    );

    /// <summary>
    /// Delete Organization Connections
    /// </summary>
    public static readonly OauthScope DeleteOrganizationConnections = new(
        Values.DeleteOrganizationConnections
    );

    /// <summary>
    /// Create Organization Discovery Domains
    /// </summary>
    public static readonly OauthScope CreateOrganizationDiscoveryDomains = new(
        Values.CreateOrganizationDiscoveryDomains
    );

    /// <summary>
    /// Read Organization Discovery Domains
    /// </summary>
    public static readonly OauthScope ReadOrganizationDiscoveryDomains = new(
        Values.ReadOrganizationDiscoveryDomains
    );

    /// <summary>
    /// Update Organization Discovery Domains
    /// </summary>
    public static readonly OauthScope UpdateOrganizationDiscoveryDomains = new(
        Values.UpdateOrganizationDiscoveryDomains
    );

    /// <summary>
    /// Delete Organization Discovery Domains
    /// </summary>
    public static readonly OauthScope DeleteOrganizationDiscoveryDomains = new(
        Values.DeleteOrganizationDiscoveryDomains
    );

    /// <summary>
    /// Create Organization Invitations
    /// </summary>
    public static readonly OauthScope CreateOrganizationInvitations = new(
        Values.CreateOrganizationInvitations
    );

    /// <summary>
    /// Read Organization Invitations
    /// </summary>
    public static readonly OauthScope ReadOrganizationInvitations = new(
        Values.ReadOrganizationInvitations
    );

    /// <summary>
    /// Delete Organization Invitations
    /// </summary>
    public static readonly OauthScope DeleteOrganizationInvitations = new(
        Values.DeleteOrganizationInvitations
    );

    /// <summary>
    /// Create Organization Member Roles
    /// </summary>
    public static readonly OauthScope CreateOrganizationMemberRoles = new(
        Values.CreateOrganizationMemberRoles
    );

    /// <summary>
    /// Read Organization Member Roles
    /// </summary>
    public static readonly OauthScope ReadOrganizationMemberRoles = new(
        Values.ReadOrganizationMemberRoles
    );

    /// <summary>
    /// Delete Organization Member Roles
    /// </summary>
    public static readonly OauthScope DeleteOrganizationMemberRoles = new(
        Values.DeleteOrganizationMemberRoles
    );

    /// <summary>
    /// Create Organization Members
    /// </summary>
    public static readonly OauthScope CreateOrganizationMembers = new(
        Values.CreateOrganizationMembers
    );

    /// <summary>
    /// Read Organization Members
    /// </summary>
    public static readonly OauthScope ReadOrganizationMembers = new(Values.ReadOrganizationMembers);

    /// <summary>
    /// Delete Organization Members
    /// </summary>
    public static readonly OauthScope DeleteOrganizationMembers = new(
        Values.DeleteOrganizationMembers
    );

    /// <summary>
    /// Create Organizations
    /// </summary>
    public static readonly OauthScope CreateOrganizations = new(Values.CreateOrganizations);

    /// <summary>
    /// Read Organizations
    /// </summary>
    public static readonly OauthScope ReadOrganizations = new(Values.ReadOrganizations);

    /// <summary>
    /// Update Organizations
    /// </summary>
    public static readonly OauthScope UpdateOrganizations = new(Values.UpdateOrganizations);

    /// <summary>
    /// Delete Organizations
    /// </summary>
    public static readonly OauthScope DeleteOrganizations = new(Values.DeleteOrganizations);

    /// <summary>
    /// Read Organizations Summary
    /// </summary>
    public static readonly OauthScope ReadOrganizationsSummary = new(
        Values.ReadOrganizationsSummary
    );

    /// <summary>
    /// Create Phone Providers
    /// </summary>
    public static readonly OauthScope CreatePhoneProviders = new(Values.CreatePhoneProviders);

    /// <summary>
    /// Read Phone Providers
    /// </summary>
    public static readonly OauthScope ReadPhoneProviders = new(Values.ReadPhoneProviders);

    /// <summary>
    /// Update Phone Providers
    /// </summary>
    public static readonly OauthScope UpdatePhoneProviders = new(Values.UpdatePhoneProviders);

    /// <summary>
    /// Delete Phone Providers
    /// </summary>
    public static readonly OauthScope DeletePhoneProviders = new(Values.DeletePhoneProviders);

    /// <summary>
    /// Create Phone Templates
    /// </summary>
    public static readonly OauthScope CreatePhoneTemplates = new(Values.CreatePhoneTemplates);

    /// <summary>
    /// Read Phone Templates
    /// </summary>
    public static readonly OauthScope ReadPhoneTemplates = new(Values.ReadPhoneTemplates);

    /// <summary>
    /// Update Phone Templates
    /// </summary>
    public static readonly OauthScope UpdatePhoneTemplates = new(Values.UpdatePhoneTemplates);

    /// <summary>
    /// Delete Phone Templates
    /// </summary>
    public static readonly OauthScope DeletePhoneTemplates = new(Values.DeletePhoneTemplates);

    /// <summary>
    /// Read Prompts
    /// </summary>
    public static readonly OauthScope ReadPrompts = new(Values.ReadPrompts);

    /// <summary>
    /// Update Prompts
    /// </summary>
    public static readonly OauthScope UpdatePrompts = new(Values.UpdatePrompts);

    /// <summary>
    /// Read Refresh Tokens
    /// </summary>
    public static readonly OauthScope ReadRefreshTokens = new(Values.ReadRefreshTokens);

    /// <summary>
    /// Update Refresh Tokens
    /// </summary>
    public static readonly OauthScope UpdateRefreshTokens = new(Values.UpdateRefreshTokens);

    /// <summary>
    /// Delete Refresh Tokens
    /// </summary>
    public static readonly OauthScope DeleteRefreshTokens = new(Values.DeleteRefreshTokens);

    /// <summary>
    /// Create Resource Servers
    /// </summary>
    public static readonly OauthScope CreateResourceServers = new(Values.CreateResourceServers);

    /// <summary>
    /// Read Resource Servers
    /// </summary>
    public static readonly OauthScope ReadResourceServers = new(Values.ReadResourceServers);

    /// <summary>
    /// Update Resource Servers
    /// </summary>
    public static readonly OauthScope UpdateResourceServers = new(Values.UpdateResourceServers);

    /// <summary>
    /// Delete Resource Servers
    /// </summary>
    public static readonly OauthScope DeleteResourceServers = new(Values.DeleteResourceServers);

    /// <summary>
    /// Create Role Members
    /// </summary>
    public static readonly OauthScope CreateRoleMembers = new(Values.CreateRoleMembers);

    /// <summary>
    /// Read Role Members
    /// </summary>
    public static readonly OauthScope ReadRoleMembers = new(Values.ReadRoleMembers);

    /// <summary>
    /// Delete Role Members
    /// </summary>
    public static readonly OauthScope DeleteRoleMembers = new(Values.DeleteRoleMembers);

    /// <summary>
    /// Create Roles
    /// </summary>
    public static readonly OauthScope CreateRoles = new(Values.CreateRoles);

    /// <summary>
    /// Read Roles
    /// </summary>
    public static readonly OauthScope ReadRoles = new(Values.ReadRoles);

    /// <summary>
    /// Update Roles
    /// </summary>
    public static readonly OauthScope UpdateRoles = new(Values.UpdateRoles);

    /// <summary>
    /// Delete Roles
    /// </summary>
    public static readonly OauthScope DeleteRoles = new(Values.DeleteRoles);

    /// <summary>
    /// Create Rules
    /// </summary>
    public static readonly OauthScope CreateRules = new(Values.CreateRules);

    /// <summary>
    /// Read Rules
    /// </summary>
    public static readonly OauthScope ReadRules = new(Values.ReadRules);

    /// <summary>
    /// Update Rules
    /// </summary>
    public static readonly OauthScope UpdateRules = new(Values.UpdateRules);

    /// <summary>
    /// Delete Rules
    /// </summary>
    public static readonly OauthScope DeleteRules = new(Values.DeleteRules);

    /// <summary>
    /// Read Rules Configs
    /// </summary>
    public static readonly OauthScope ReadRulesConfigs = new(Values.ReadRulesConfigs);

    /// <summary>
    /// Update Rules Configs
    /// </summary>
    public static readonly OauthScope UpdateRulesConfigs = new(Values.UpdateRulesConfigs);

    /// <summary>
    /// Delete Rules Configs
    /// </summary>
    public static readonly OauthScope DeleteRulesConfigs = new(Values.DeleteRulesConfigs);

    /// <summary>
    /// Create Scim Config
    /// </summary>
    public static readonly OauthScope CreateScimConfig = new(Values.CreateScimConfig);

    /// <summary>
    /// Read Scim Config
    /// </summary>
    public static readonly OauthScope ReadScimConfig = new(Values.ReadScimConfig);

    /// <summary>
    /// Update Scim Config
    /// </summary>
    public static readonly OauthScope UpdateScimConfig = new(Values.UpdateScimConfig);

    /// <summary>
    /// Delete Scim Config
    /// </summary>
    public static readonly OauthScope DeleteScimConfig = new(Values.DeleteScimConfig);

    /// <summary>
    /// Create Scim Token
    /// </summary>
    public static readonly OauthScope CreateScimToken = new(Values.CreateScimToken);

    /// <summary>
    /// Read Scim Token
    /// </summary>
    public static readonly OauthScope ReadScimToken = new(Values.ReadScimToken);

    /// <summary>
    /// Delete Scim Token
    /// </summary>
    public static readonly OauthScope DeleteScimToken = new(Values.DeleteScimToken);

    /// <summary>
    /// Read Self Service Profile Custom Texts
    /// </summary>
    public static readonly OauthScope ReadSelfServiceProfileCustomTexts = new(
        Values.ReadSelfServiceProfileCustomTexts
    );

    /// <summary>
    /// Update Self Service Profile Custom Texts
    /// </summary>
    public static readonly OauthScope UpdateSelfServiceProfileCustomTexts = new(
        Values.UpdateSelfServiceProfileCustomTexts
    );

    /// <summary>
    /// Create Self Service Profiles
    /// </summary>
    public static readonly OauthScope CreateSelfServiceProfiles = new(
        Values.CreateSelfServiceProfiles
    );

    /// <summary>
    /// Read Self Service Profiles
    /// </summary>
    public static readonly OauthScope ReadSelfServiceProfiles = new(Values.ReadSelfServiceProfiles);

    /// <summary>
    /// Update Self Service Profiles
    /// </summary>
    public static readonly OauthScope UpdateSelfServiceProfiles = new(
        Values.UpdateSelfServiceProfiles
    );

    /// <summary>
    /// Delete Self Service Profiles
    /// </summary>
    public static readonly OauthScope DeleteSelfServiceProfiles = new(
        Values.DeleteSelfServiceProfiles
    );

    /// <summary>
    /// Read Sessions
    /// </summary>
    public static readonly OauthScope ReadSessions = new(Values.ReadSessions);

    /// <summary>
    /// Update Sessions
    /// </summary>
    public static readonly OauthScope UpdateSessions = new(Values.UpdateSessions);

    /// <summary>
    /// Delete Sessions
    /// </summary>
    public static readonly OauthScope DeleteSessions = new(Values.DeleteSessions);

    /// <summary>
    /// Create Signing Keys
    /// </summary>
    public static readonly OauthScope CreateSigningKeys = new(Values.CreateSigningKeys);

    /// <summary>
    /// Read Signing Keys
    /// </summary>
    public static readonly OauthScope ReadSigningKeys = new(Values.ReadSigningKeys);

    /// <summary>
    /// Update Signing Keys
    /// </summary>
    public static readonly OauthScope UpdateSigningKeys = new(Values.UpdateSigningKeys);

    /// <summary>
    /// Create Sso Access Tickets
    /// </summary>
    public static readonly OauthScope CreateSsoAccessTickets = new(Values.CreateSsoAccessTickets);

    /// <summary>
    /// Delete Sso Access Tickets
    /// </summary>
    public static readonly OauthScope DeleteSsoAccessTickets = new(Values.DeleteSsoAccessTickets);

    /// <summary>
    /// Read Stats
    /// </summary>
    public static readonly OauthScope ReadStats = new(Values.ReadStats);

    /// <summary>
    /// Read Tenant Settings
    /// </summary>
    public static readonly OauthScope ReadTenantSettings = new(Values.ReadTenantSettings);

    /// <summary>
    /// Update Tenant Settings
    /// </summary>
    public static readonly OauthScope UpdateTenantSettings = new(Values.UpdateTenantSettings);

    /// <summary>
    /// Create Token Exchange Profiles
    /// </summary>
    public static readonly OauthScope CreateTokenExchangeProfiles = new(
        Values.CreateTokenExchangeProfiles
    );

    /// <summary>
    /// Read Token Exchange Profiles
    /// </summary>
    public static readonly OauthScope ReadTokenExchangeProfiles = new(
        Values.ReadTokenExchangeProfiles
    );

    /// <summary>
    /// Update Token Exchange Profiles
    /// </summary>
    public static readonly OauthScope UpdateTokenExchangeProfiles = new(
        Values.UpdateTokenExchangeProfiles
    );

    /// <summary>
    /// Delete Token Exchange Profiles
    /// </summary>
    public static readonly OauthScope DeleteTokenExchangeProfiles = new(
        Values.DeleteTokenExchangeProfiles
    );

    /// <summary>
    /// Create User Attribute Profiles
    /// </summary>
    public static readonly OauthScope CreateUserAttributeProfiles = new(
        Values.CreateUserAttributeProfiles
    );

    /// <summary>
    /// Read User Attribute Profiles
    /// </summary>
    public static readonly OauthScope ReadUserAttributeProfiles = new(
        Values.ReadUserAttributeProfiles
    );

    /// <summary>
    /// Update User Attribute Profiles
    /// </summary>
    public static readonly OauthScope UpdateUserAttributeProfiles = new(
        Values.UpdateUserAttributeProfiles
    );

    /// <summary>
    /// Delete User Attribute Profiles
    /// </summary>
    public static readonly OauthScope DeleteUserAttributeProfiles = new(
        Values.DeleteUserAttributeProfiles
    );

    /// <summary>
    /// Read User Idp Tokens
    /// </summary>
    public static readonly OauthScope ReadUserIdpTokens = new(Values.ReadUserIdpTokens);

    /// <summary>
    /// Create User Tickets
    /// </summary>
    public static readonly OauthScope CreateUserTickets = new(Values.CreateUserTickets);

    /// <summary>
    /// Create Users
    /// </summary>
    public static readonly OauthScope CreateUsers = new(Values.CreateUsers);

    /// <summary>
    /// Read Users
    /// </summary>
    public static readonly OauthScope ReadUsers = new(Values.ReadUsers);

    /// <summary>
    /// Update Users
    /// </summary>
    public static readonly OauthScope UpdateUsers = new(Values.UpdateUsers);

    /// <summary>
    /// Delete Users
    /// </summary>
    public static readonly OauthScope DeleteUsers = new(Values.DeleteUsers);

    /// <summary>
    /// Update Users App Metadata
    /// </summary>
    public static readonly OauthScope UpdateUsersAppMetadata = new(Values.UpdateUsersAppMetadata);

    /// <summary>
    /// Create Vdcs Templates
    /// </summary>
    public static readonly OauthScope CreateVdcsTemplates = new(Values.CreateVdcsTemplates);

    /// <summary>
    /// Read Vdcs Templates
    /// </summary>
    public static readonly OauthScope ReadVdcsTemplates = new(Values.ReadVdcsTemplates);

    /// <summary>
    /// Update Vdcs Templates
    /// </summary>
    public static readonly OauthScope UpdateVdcsTemplates = new(Values.UpdateVdcsTemplates);

    /// <summary>
    /// Delete Vdcs Templates
    /// </summary>
    public static readonly OauthScope DeleteVdcsTemplates = new(Values.DeleteVdcsTemplates);

    public OauthScope(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static OauthScope FromCustom(string value)
    {
        return new OauthScope(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(OauthScope value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(OauthScope value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OauthScope value) => value.Value;

    public static explicit operator OauthScope(string value) => new(value);

    internal class OauthScopeSerializer : JsonConverter<OauthScope>
    {
        public override OauthScope Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new OauthScope(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OauthScope value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OauthScope ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new OauthScope(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OauthScope value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        /// <summary>
        /// Create Actions
        /// </summary>
        public const string CreateActions = "create:actions";

        /// <summary>
        /// Read Actions
        /// </summary>
        public const string ReadActions = "read:actions";

        /// <summary>
        /// Update Actions
        /// </summary>
        public const string UpdateActions = "update:actions";

        /// <summary>
        /// Delete Actions
        /// </summary>
        public const string DeleteActions = "delete:actions";

        /// <summary>
        /// Read Anomaly Blocks
        /// </summary>
        public const string ReadAnomalyBlocks = "read:anomaly_blocks";

        /// <summary>
        /// Delete Anomaly Blocks
        /// </summary>
        public const string DeleteAnomalyBlocks = "delete:anomaly_blocks";

        /// <summary>
        /// Read Attack Protection
        /// </summary>
        public const string ReadAttackProtection = "read:attack_protection";

        /// <summary>
        /// Update Attack Protection
        /// </summary>
        public const string UpdateAttackProtection = "update:attack_protection";

        /// <summary>
        /// Create Authentication Methods
        /// </summary>
        public const string CreateAuthenticationMethods = "create:authentication_methods";

        /// <summary>
        /// Read Authentication Methods
        /// </summary>
        public const string ReadAuthenticationMethods = "read:authentication_methods";

        /// <summary>
        /// Update Authentication Methods
        /// </summary>
        public const string UpdateAuthenticationMethods = "update:authentication_methods";

        /// <summary>
        /// Delete Authentication Methods
        /// </summary>
        public const string DeleteAuthenticationMethods = "delete:authentication_methods";

        /// <summary>
        /// Read Branding
        /// </summary>
        public const string ReadBranding = "read:branding";

        /// <summary>
        /// Update Branding
        /// </summary>
        public const string UpdateBranding = "update:branding";

        /// <summary>
        /// Delete Branding
        /// </summary>
        public const string DeleteBranding = "delete:branding";

        /// <summary>
        /// Create Client Credentials
        /// </summary>
        public const string CreateClientCredentials = "create:client_credentials";

        /// <summary>
        /// Read Client Credentials
        /// </summary>
        public const string ReadClientCredentials = "read:client_credentials";

        /// <summary>
        /// Update Client Credentials
        /// </summary>
        public const string UpdateClientCredentials = "update:client_credentials";

        /// <summary>
        /// Delete Client Credentials
        /// </summary>
        public const string DeleteClientCredentials = "delete:client_credentials";

        /// <summary>
        /// Create Client Grants
        /// </summary>
        public const string CreateClientGrants = "create:client_grants";

        /// <summary>
        /// Read Client Grants
        /// </summary>
        public const string ReadClientGrants = "read:client_grants";

        /// <summary>
        /// Update Client Grants
        /// </summary>
        public const string UpdateClientGrants = "update:client_grants";

        /// <summary>
        /// Delete Client Grants
        /// </summary>
        public const string DeleteClientGrants = "delete:client_grants";

        /// <summary>
        /// Read Client Keys
        /// </summary>
        public const string ReadClientKeys = "read:client_keys";

        /// <summary>
        /// Update Client Keys
        /// </summary>
        public const string UpdateClientKeys = "update:client_keys";

        /// <summary>
        /// Read Client Summary
        /// </summary>
        public const string ReadClientSummary = "read:client_summary";

        /// <summary>
        /// Update Client Token Vault Privileged Access
        /// </summary>
        public const string UpdateClientTokenVaultPrivilegedAccess =
            "update:client_token_vault_privileged_access";

        /// <summary>
        /// Create Clients
        /// </summary>
        public const string CreateClients = "create:clients";

        /// <summary>
        /// Read Clients
        /// </summary>
        public const string ReadClients = "read:clients";

        /// <summary>
        /// Update Clients
        /// </summary>
        public const string UpdateClients = "update:clients";

        /// <summary>
        /// Delete Clients
        /// </summary>
        public const string DeleteClients = "delete:clients";

        /// <summary>
        /// Create Connection Profiles
        /// </summary>
        public const string CreateConnectionProfiles = "create:connection_profiles";

        /// <summary>
        /// Read Connection Profiles
        /// </summary>
        public const string ReadConnectionProfiles = "read:connection_profiles";

        /// <summary>
        /// Update Connection Profiles
        /// </summary>
        public const string UpdateConnectionProfiles = "update:connection_profiles";

        /// <summary>
        /// Delete Connection Profiles
        /// </summary>
        public const string DeleteConnectionProfiles = "delete:connection_profiles";

        /// <summary>
        /// Create Connections
        /// </summary>
        public const string CreateConnections = "create:connections";

        /// <summary>
        /// Read Connections
        /// </summary>
        public const string ReadConnections = "read:connections";

        /// <summary>
        /// Update Connections
        /// </summary>
        public const string UpdateConnections = "update:connections";

        /// <summary>
        /// Delete Connections
        /// </summary>
        public const string DeleteConnections = "delete:connections";

        /// <summary>
        /// Create Connections Keys
        /// </summary>
        public const string CreateConnectionsKeys = "create:connections_keys";

        /// <summary>
        /// Read Connections Keys
        /// </summary>
        public const string ReadConnectionsKeys = "read:connections_keys";

        /// <summary>
        /// Update Connections Keys
        /// </summary>
        public const string UpdateConnectionsKeys = "update:connections_keys";

        /// <summary>
        /// Read Current User
        /// </summary>
        public const string ReadCurrentUser = "read:current_user";

        /// <summary>
        /// Delete Current User
        /// </summary>
        public const string DeleteCurrentUser = "delete:current_user";

        /// <summary>
        /// Create Current User Device Credentials
        /// </summary>
        public const string CreateCurrentUserDeviceCredentials =
            "create:current_user_device_credentials";

        /// <summary>
        /// Delete Current User Device Credentials
        /// </summary>
        public const string DeleteCurrentUserDeviceCredentials =
            "delete:current_user_device_credentials";

        /// <summary>
        /// Update Current User Identities
        /// </summary>
        public const string UpdateCurrentUserIdentities = "update:current_user_identities";

        /// <summary>
        /// Update Current User Metadata
        /// </summary>
        public const string UpdateCurrentUserMetadata = "update:current_user_metadata";

        /// <summary>
        /// Create Custom Domains
        /// </summary>
        public const string CreateCustomDomains = "create:custom_domains";

        /// <summary>
        /// Read Custom Domains
        /// </summary>
        public const string ReadCustomDomains = "read:custom_domains";

        /// <summary>
        /// Update Custom Domains
        /// </summary>
        public const string UpdateCustomDomains = "update:custom_domains";

        /// <summary>
        /// Delete Custom Domains
        /// </summary>
        public const string DeleteCustomDomains = "delete:custom_domains";

        /// <summary>
        /// Create Custom Signing Keys
        /// </summary>
        public const string CreateCustomSigningKeys = "create:custom_signing_keys";

        /// <summary>
        /// Read Custom Signing Keys
        /// </summary>
        public const string ReadCustomSigningKeys = "read:custom_signing_keys";

        /// <summary>
        /// Update Custom Signing Keys
        /// </summary>
        public const string UpdateCustomSigningKeys = "update:custom_signing_keys";

        /// <summary>
        /// Delete Custom Signing Keys
        /// </summary>
        public const string DeleteCustomSigningKeys = "delete:custom_signing_keys";

        /// <summary>
        /// Read Device Credentials
        /// </summary>
        public const string ReadDeviceCredentials = "read:device_credentials";

        /// <summary>
        /// Delete Device Credentials
        /// </summary>
        public const string DeleteDeviceCredentials = "delete:device_credentials";

        /// <summary>
        /// Create Directory Provisionings
        /// </summary>
        public const string CreateDirectoryProvisionings = "create:directory_provisionings";

        /// <summary>
        /// Read Directory Provisionings
        /// </summary>
        public const string ReadDirectoryProvisionings = "read:directory_provisionings";

        /// <summary>
        /// Update Directory Provisionings
        /// </summary>
        public const string UpdateDirectoryProvisionings = "update:directory_provisionings";

        /// <summary>
        /// Delete Directory Provisionings
        /// </summary>
        public const string DeleteDirectoryProvisionings = "delete:directory_provisionings";

        /// <summary>
        /// Create Email Provider
        /// </summary>
        public const string CreateEmailProvider = "create:email_provider";

        /// <summary>
        /// Read Email Provider
        /// </summary>
        public const string ReadEmailProvider = "read:email_provider";

        /// <summary>
        /// Update Email Provider
        /// </summary>
        public const string UpdateEmailProvider = "update:email_provider";

        /// <summary>
        /// Delete Email Provider
        /// </summary>
        public const string DeleteEmailProvider = "delete:email_provider";

        /// <summary>
        /// Create Email Templates
        /// </summary>
        public const string CreateEmailTemplates = "create:email_templates";

        /// <summary>
        /// Read Email Templates
        /// </summary>
        public const string ReadEmailTemplates = "read:email_templates";

        /// <summary>
        /// Update Email Templates
        /// </summary>
        public const string UpdateEmailTemplates = "update:email_templates";

        /// <summary>
        /// Create Encryption Keys
        /// </summary>
        public const string CreateEncryptionKeys = "create:encryption_keys";

        /// <summary>
        /// Read Encryption Keys
        /// </summary>
        public const string ReadEncryptionKeys = "read:encryption_keys";

        /// <summary>
        /// Update Encryption Keys
        /// </summary>
        public const string UpdateEncryptionKeys = "update:encryption_keys";

        /// <summary>
        /// Delete Encryption Keys
        /// </summary>
        public const string DeleteEncryptionKeys = "delete:encryption_keys";

        /// <summary>
        /// Read Event Deliveries
        /// </summary>
        public const string ReadEventDeliveries = "read:event_deliveries";

        /// <summary>
        /// Update Event Deliveries
        /// </summary>
        public const string UpdateEventDeliveries = "update:event_deliveries";

        /// <summary>
        /// Create Event Streams
        /// </summary>
        public const string CreateEventStreams = "create:event_streams";

        /// <summary>
        /// Read Event Streams
        /// </summary>
        public const string ReadEventStreams = "read:event_streams";

        /// <summary>
        /// Update Event Streams
        /// </summary>
        public const string UpdateEventStreams = "update:event_streams";

        /// <summary>
        /// Delete Event Streams
        /// </summary>
        public const string DeleteEventStreams = "delete:event_streams";

        /// <summary>
        /// Read Events
        /// </summary>
        public const string ReadEvents = "read:events";

        /// <summary>
        /// Read Federated Connections Tokens
        /// </summary>
        public const string ReadFederatedConnectionsTokens = "read:federated_connections_tokens";

        /// <summary>
        /// Delete Federated Connections Tokens
        /// </summary>
        public const string DeleteFederatedConnectionsTokens =
            "delete:federated_connections_tokens";

        /// <summary>
        /// Create Flows
        /// </summary>
        public const string CreateFlows = "create:flows";

        /// <summary>
        /// Read Flows
        /// </summary>
        public const string ReadFlows = "read:flows";

        /// <summary>
        /// Update Flows
        /// </summary>
        public const string UpdateFlows = "update:flows";

        /// <summary>
        /// Delete Flows
        /// </summary>
        public const string DeleteFlows = "delete:flows";

        /// <summary>
        /// Read Flows Executions
        /// </summary>
        public const string ReadFlowsExecutions = "read:flows_executions";

        /// <summary>
        /// Delete Flows Executions
        /// </summary>
        public const string DeleteFlowsExecutions = "delete:flows_executions";

        /// <summary>
        /// Create Flows Vault Connections
        /// </summary>
        public const string CreateFlowsVaultConnections = "create:flows_vault_connections";

        /// <summary>
        /// Read Flows Vault Connections
        /// </summary>
        public const string ReadFlowsVaultConnections = "read:flows_vault_connections";

        /// <summary>
        /// Update Flows Vault Connections
        /// </summary>
        public const string UpdateFlowsVaultConnections = "update:flows_vault_connections";

        /// <summary>
        /// Delete Flows Vault Connections
        /// </summary>
        public const string DeleteFlowsVaultConnections = "delete:flows_vault_connections";

        /// <summary>
        /// Create Forms
        /// </summary>
        public const string CreateForms = "create:forms";

        /// <summary>
        /// Read Forms
        /// </summary>
        public const string ReadForms = "read:forms";

        /// <summary>
        /// Update Forms
        /// </summary>
        public const string UpdateForms = "update:forms";

        /// <summary>
        /// Delete Forms
        /// </summary>
        public const string DeleteForms = "delete:forms";

        /// <summary>
        /// Read Grants
        /// </summary>
        public const string ReadGrants = "read:grants";

        /// <summary>
        /// Delete Grants
        /// </summary>
        public const string DeleteGrants = "delete:grants";

        /// <summary>
        /// Read Group Members
        /// </summary>
        public const string ReadGroupMembers = "read:group_members";

        /// <summary>
        /// Read Groups
        /// </summary>
        public const string ReadGroups = "read:groups";

        /// <summary>
        /// Delete Groups
        /// </summary>
        public const string DeleteGroups = "delete:groups";

        /// <summary>
        /// Create Guardian Enrollment Tickets
        /// </summary>
        public const string CreateGuardianEnrollmentTickets = "create:guardian_enrollment_tickets";

        /// <summary>
        /// Read Guardian Enrollments
        /// </summary>
        public const string ReadGuardianEnrollments = "read:guardian_enrollments";

        /// <summary>
        /// Delete Guardian Enrollments
        /// </summary>
        public const string DeleteGuardianEnrollments = "delete:guardian_enrollments";

        /// <summary>
        /// Read Guardian Factors
        /// </summary>
        public const string ReadGuardianFactors = "read:guardian_factors";

        /// <summary>
        /// Update Guardian Factors
        /// </summary>
        public const string UpdateGuardianFactors = "update:guardian_factors";

        /// <summary>
        /// Create Hooks
        /// </summary>
        public const string CreateHooks = "create:hooks";

        /// <summary>
        /// Read Hooks
        /// </summary>
        public const string ReadHooks = "read:hooks";

        /// <summary>
        /// Update Hooks
        /// </summary>
        public const string UpdateHooks = "update:hooks";

        /// <summary>
        /// Delete Hooks
        /// </summary>
        public const string DeleteHooks = "delete:hooks";

        /// <summary>
        /// Create Log Streams
        /// </summary>
        public const string CreateLogStreams = "create:log_streams";

        /// <summary>
        /// Read Log Streams
        /// </summary>
        public const string ReadLogStreams = "read:log_streams";

        /// <summary>
        /// Update Log Streams
        /// </summary>
        public const string UpdateLogStreams = "update:log_streams";

        /// <summary>
        /// Delete Log Streams
        /// </summary>
        public const string DeleteLogStreams = "delete:log_streams";

        /// <summary>
        /// Read Logs
        /// </summary>
        public const string ReadLogs = "read:logs";

        /// <summary>
        /// Read Logs Users
        /// </summary>
        public const string ReadLogsUsers = "read:logs_users";

        /// <summary>
        /// Read Mfa Policies
        /// </summary>
        public const string ReadMfaPolicies = "read:mfa_policies";

        /// <summary>
        /// Update Mfa Policies
        /// </summary>
        public const string UpdateMfaPolicies = "update:mfa_policies";

        /// <summary>
        /// Create Network Acls
        /// </summary>
        public const string CreateNetworkAcls = "create:network_acls";

        /// <summary>
        /// Read Network Acls
        /// </summary>
        public const string ReadNetworkAcls = "read:network_acls";

        /// <summary>
        /// Update Network Acls
        /// </summary>
        public const string UpdateNetworkAcls = "update:network_acls";

        /// <summary>
        /// Delete Network Acls
        /// </summary>
        public const string DeleteNetworkAcls = "delete:network_acls";

        /// <summary>
        /// Create Organization Client Grants
        /// </summary>
        public const string CreateOrganizationClientGrants = "create:organization_client_grants";

        /// <summary>
        /// Read Organization Client Grants
        /// </summary>
        public const string ReadOrganizationClientGrants = "read:organization_client_grants";

        /// <summary>
        /// Delete Organization Client Grants
        /// </summary>
        public const string DeleteOrganizationClientGrants = "delete:organization_client_grants";

        /// <summary>
        /// Create Organization Connections
        /// </summary>
        public const string CreateOrganizationConnections = "create:organization_connections";

        /// <summary>
        /// Read Organization Connections
        /// </summary>
        public const string ReadOrganizationConnections = "read:organization_connections";

        /// <summary>
        /// Update Organization Connections
        /// </summary>
        public const string UpdateOrganizationConnections = "update:organization_connections";

        /// <summary>
        /// Delete Organization Connections
        /// </summary>
        public const string DeleteOrganizationConnections = "delete:organization_connections";

        /// <summary>
        /// Create Organization Discovery Domains
        /// </summary>
        public const string CreateOrganizationDiscoveryDomains =
            "create:organization_discovery_domains";

        /// <summary>
        /// Read Organization Discovery Domains
        /// </summary>
        public const string ReadOrganizationDiscoveryDomains =
            "read:organization_discovery_domains";

        /// <summary>
        /// Update Organization Discovery Domains
        /// </summary>
        public const string UpdateOrganizationDiscoveryDomains =
            "update:organization_discovery_domains";

        /// <summary>
        /// Delete Organization Discovery Domains
        /// </summary>
        public const string DeleteOrganizationDiscoveryDomains =
            "delete:organization_discovery_domains";

        /// <summary>
        /// Create Organization Invitations
        /// </summary>
        public const string CreateOrganizationInvitations = "create:organization_invitations";

        /// <summary>
        /// Read Organization Invitations
        /// </summary>
        public const string ReadOrganizationInvitations = "read:organization_invitations";

        /// <summary>
        /// Delete Organization Invitations
        /// </summary>
        public const string DeleteOrganizationInvitations = "delete:organization_invitations";

        /// <summary>
        /// Create Organization Member Roles
        /// </summary>
        public const string CreateOrganizationMemberRoles = "create:organization_member_roles";

        /// <summary>
        /// Read Organization Member Roles
        /// </summary>
        public const string ReadOrganizationMemberRoles = "read:organization_member_roles";

        /// <summary>
        /// Delete Organization Member Roles
        /// </summary>
        public const string DeleteOrganizationMemberRoles = "delete:organization_member_roles";

        /// <summary>
        /// Create Organization Members
        /// </summary>
        public const string CreateOrganizationMembers = "create:organization_members";

        /// <summary>
        /// Read Organization Members
        /// </summary>
        public const string ReadOrganizationMembers = "read:organization_members";

        /// <summary>
        /// Delete Organization Members
        /// </summary>
        public const string DeleteOrganizationMembers = "delete:organization_members";

        /// <summary>
        /// Create Organizations
        /// </summary>
        public const string CreateOrganizations = "create:organizations";

        /// <summary>
        /// Read Organizations
        /// </summary>
        public const string ReadOrganizations = "read:organizations";

        /// <summary>
        /// Update Organizations
        /// </summary>
        public const string UpdateOrganizations = "update:organizations";

        /// <summary>
        /// Delete Organizations
        /// </summary>
        public const string DeleteOrganizations = "delete:organizations";

        /// <summary>
        /// Read Organizations Summary
        /// </summary>
        public const string ReadOrganizationsSummary = "read:organizations_summary";

        /// <summary>
        /// Create Phone Providers
        /// </summary>
        public const string CreatePhoneProviders = "create:phone_providers";

        /// <summary>
        /// Read Phone Providers
        /// </summary>
        public const string ReadPhoneProviders = "read:phone_providers";

        /// <summary>
        /// Update Phone Providers
        /// </summary>
        public const string UpdatePhoneProviders = "update:phone_providers";

        /// <summary>
        /// Delete Phone Providers
        /// </summary>
        public const string DeletePhoneProviders = "delete:phone_providers";

        /// <summary>
        /// Create Phone Templates
        /// </summary>
        public const string CreatePhoneTemplates = "create:phone_templates";

        /// <summary>
        /// Read Phone Templates
        /// </summary>
        public const string ReadPhoneTemplates = "read:phone_templates";

        /// <summary>
        /// Update Phone Templates
        /// </summary>
        public const string UpdatePhoneTemplates = "update:phone_templates";

        /// <summary>
        /// Delete Phone Templates
        /// </summary>
        public const string DeletePhoneTemplates = "delete:phone_templates";

        /// <summary>
        /// Read Prompts
        /// </summary>
        public const string ReadPrompts = "read:prompts";

        /// <summary>
        /// Update Prompts
        /// </summary>
        public const string UpdatePrompts = "update:prompts";

        /// <summary>
        /// Read Refresh Tokens
        /// </summary>
        public const string ReadRefreshTokens = "read:refresh_tokens";

        /// <summary>
        /// Update Refresh Tokens
        /// </summary>
        public const string UpdateRefreshTokens = "update:refresh_tokens";

        /// <summary>
        /// Delete Refresh Tokens
        /// </summary>
        public const string DeleteRefreshTokens = "delete:refresh_tokens";

        /// <summary>
        /// Create Resource Servers
        /// </summary>
        public const string CreateResourceServers = "create:resource_servers";

        /// <summary>
        /// Read Resource Servers
        /// </summary>
        public const string ReadResourceServers = "read:resource_servers";

        /// <summary>
        /// Update Resource Servers
        /// </summary>
        public const string UpdateResourceServers = "update:resource_servers";

        /// <summary>
        /// Delete Resource Servers
        /// </summary>
        public const string DeleteResourceServers = "delete:resource_servers";

        /// <summary>
        /// Create Role Members
        /// </summary>
        public const string CreateRoleMembers = "create:role_members";

        /// <summary>
        /// Read Role Members
        /// </summary>
        public const string ReadRoleMembers = "read:role_members";

        /// <summary>
        /// Delete Role Members
        /// </summary>
        public const string DeleteRoleMembers = "delete:role_members";

        /// <summary>
        /// Create Roles
        /// </summary>
        public const string CreateRoles = "create:roles";

        /// <summary>
        /// Read Roles
        /// </summary>
        public const string ReadRoles = "read:roles";

        /// <summary>
        /// Update Roles
        /// </summary>
        public const string UpdateRoles = "update:roles";

        /// <summary>
        /// Delete Roles
        /// </summary>
        public const string DeleteRoles = "delete:roles";

        /// <summary>
        /// Create Rules
        /// </summary>
        public const string CreateRules = "create:rules";

        /// <summary>
        /// Read Rules
        /// </summary>
        public const string ReadRules = "read:rules";

        /// <summary>
        /// Update Rules
        /// </summary>
        public const string UpdateRules = "update:rules";

        /// <summary>
        /// Delete Rules
        /// </summary>
        public const string DeleteRules = "delete:rules";

        /// <summary>
        /// Read Rules Configs
        /// </summary>
        public const string ReadRulesConfigs = "read:rules_configs";

        /// <summary>
        /// Update Rules Configs
        /// </summary>
        public const string UpdateRulesConfigs = "update:rules_configs";

        /// <summary>
        /// Delete Rules Configs
        /// </summary>
        public const string DeleteRulesConfigs = "delete:rules_configs";

        /// <summary>
        /// Create Scim Config
        /// </summary>
        public const string CreateScimConfig = "create:scim_config";

        /// <summary>
        /// Read Scim Config
        /// </summary>
        public const string ReadScimConfig = "read:scim_config";

        /// <summary>
        /// Update Scim Config
        /// </summary>
        public const string UpdateScimConfig = "update:scim_config";

        /// <summary>
        /// Delete Scim Config
        /// </summary>
        public const string DeleteScimConfig = "delete:scim_config";

        /// <summary>
        /// Create Scim Token
        /// </summary>
        public const string CreateScimToken = "create:scim_token";

        /// <summary>
        /// Read Scim Token
        /// </summary>
        public const string ReadScimToken = "read:scim_token";

        /// <summary>
        /// Delete Scim Token
        /// </summary>
        public const string DeleteScimToken = "delete:scim_token";

        /// <summary>
        /// Read Self Service Profile Custom Texts
        /// </summary>
        public const string ReadSelfServiceProfileCustomTexts =
            "read:self_service_profile_custom_texts";

        /// <summary>
        /// Update Self Service Profile Custom Texts
        /// </summary>
        public const string UpdateSelfServiceProfileCustomTexts =
            "update:self_service_profile_custom_texts";

        /// <summary>
        /// Create Self Service Profiles
        /// </summary>
        public const string CreateSelfServiceProfiles = "create:self_service_profiles";

        /// <summary>
        /// Read Self Service Profiles
        /// </summary>
        public const string ReadSelfServiceProfiles = "read:self_service_profiles";

        /// <summary>
        /// Update Self Service Profiles
        /// </summary>
        public const string UpdateSelfServiceProfiles = "update:self_service_profiles";

        /// <summary>
        /// Delete Self Service Profiles
        /// </summary>
        public const string DeleteSelfServiceProfiles = "delete:self_service_profiles";

        /// <summary>
        /// Read Sessions
        /// </summary>
        public const string ReadSessions = "read:sessions";

        /// <summary>
        /// Update Sessions
        /// </summary>
        public const string UpdateSessions = "update:sessions";

        /// <summary>
        /// Delete Sessions
        /// </summary>
        public const string DeleteSessions = "delete:sessions";

        /// <summary>
        /// Create Signing Keys
        /// </summary>
        public const string CreateSigningKeys = "create:signing_keys";

        /// <summary>
        /// Read Signing Keys
        /// </summary>
        public const string ReadSigningKeys = "read:signing_keys";

        /// <summary>
        /// Update Signing Keys
        /// </summary>
        public const string UpdateSigningKeys = "update:signing_keys";

        /// <summary>
        /// Create Sso Access Tickets
        /// </summary>
        public const string CreateSsoAccessTickets = "create:sso_access_tickets";

        /// <summary>
        /// Delete Sso Access Tickets
        /// </summary>
        public const string DeleteSsoAccessTickets = "delete:sso_access_tickets";

        /// <summary>
        /// Read Stats
        /// </summary>
        public const string ReadStats = "read:stats";

        /// <summary>
        /// Read Tenant Settings
        /// </summary>
        public const string ReadTenantSettings = "read:tenant_settings";

        /// <summary>
        /// Update Tenant Settings
        /// </summary>
        public const string UpdateTenantSettings = "update:tenant_settings";

        /// <summary>
        /// Create Token Exchange Profiles
        /// </summary>
        public const string CreateTokenExchangeProfiles = "create:token_exchange_profiles";

        /// <summary>
        /// Read Token Exchange Profiles
        /// </summary>
        public const string ReadTokenExchangeProfiles = "read:token_exchange_profiles";

        /// <summary>
        /// Update Token Exchange Profiles
        /// </summary>
        public const string UpdateTokenExchangeProfiles = "update:token_exchange_profiles";

        /// <summary>
        /// Delete Token Exchange Profiles
        /// </summary>
        public const string DeleteTokenExchangeProfiles = "delete:token_exchange_profiles";

        /// <summary>
        /// Create User Attribute Profiles
        /// </summary>
        public const string CreateUserAttributeProfiles = "create:user_attribute_profiles";

        /// <summary>
        /// Read User Attribute Profiles
        /// </summary>
        public const string ReadUserAttributeProfiles = "read:user_attribute_profiles";

        /// <summary>
        /// Update User Attribute Profiles
        /// </summary>
        public const string UpdateUserAttributeProfiles = "update:user_attribute_profiles";

        /// <summary>
        /// Delete User Attribute Profiles
        /// </summary>
        public const string DeleteUserAttributeProfiles = "delete:user_attribute_profiles";

        /// <summary>
        /// Read User Idp Tokens
        /// </summary>
        public const string ReadUserIdpTokens = "read:user_idp_tokens";

        /// <summary>
        /// Create User Tickets
        /// </summary>
        public const string CreateUserTickets = "create:user_tickets";

        /// <summary>
        /// Create Users
        /// </summary>
        public const string CreateUsers = "create:users";

        /// <summary>
        /// Read Users
        /// </summary>
        public const string ReadUsers = "read:users";

        /// <summary>
        /// Update Users
        /// </summary>
        public const string UpdateUsers = "update:users";

        /// <summary>
        /// Delete Users
        /// </summary>
        public const string DeleteUsers = "delete:users";

        /// <summary>
        /// Update Users App Metadata
        /// </summary>
        public const string UpdateUsersAppMetadata = "update:users_app_metadata";

        /// <summary>
        /// Create Vdcs Templates
        /// </summary>
        public const string CreateVdcsTemplates = "create:vdcs_templates";

        /// <summary>
        /// Read Vdcs Templates
        /// </summary>
        public const string ReadVdcsTemplates = "read:vdcs_templates";

        /// <summary>
        /// Update Vdcs Templates
        /// </summary>
        public const string UpdateVdcsTemplates = "update:vdcs_templates";

        /// <summary>
        /// Delete Vdcs Templates
        /// </summary>
        public const string DeleteVdcsTemplates = "delete:vdcs_templates";
    }
}
