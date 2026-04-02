namespace Auth0.ManagementApi.Branding.Phone;

public partial interface IPhoneClient
{
    public IProvidersClient Providers { get; }
    public ITemplatesClient Templates { get; }
}
