using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Branding.Phone;

public partial class PhoneClient : IPhoneClient
{
    private readonly RawClient _client;

    internal PhoneClient(RawClient client)
    {
        _client = client;
        Providers = new ProvidersClient(_client);
        Templates = new TemplatesClient(_client);
    }

    public IProvidersClient Providers { get; }

    public ITemplatesClient Templates { get; }
}
