namespace Auth0.ManagementApi.Tenants;

public partial interface ITenantsClient
{
    public ISettingsClient Settings { get; }
}
