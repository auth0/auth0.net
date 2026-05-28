namespace Auth0.ManagementApi.Users.EffectivePermissions.Sources;

public partial interface ISourcesClient
{
    public IRolesClient Roles { get; }
}
