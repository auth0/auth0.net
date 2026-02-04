namespace Auth0.ManagementApi.Guardian.Factors.Duo;

public partial interface IDuoClient
{
    public ISettingsClient Settings { get; }
}
