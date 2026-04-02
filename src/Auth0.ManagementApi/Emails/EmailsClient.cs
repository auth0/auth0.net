using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Emails;

public partial class EmailsClient : IEmailsClient
{
    private readonly RawClient _client;

    internal EmailsClient(RawClient client)
    {
        _client = client;
        Provider = new ProviderClient(_client);
    }

    public IProviderClient Provider { get; }
}
