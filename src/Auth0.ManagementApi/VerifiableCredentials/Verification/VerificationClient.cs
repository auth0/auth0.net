using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.VerifiableCredentials.Verification;

public partial class VerificationClient : IVerificationClient
{
    private RawClient _client;

    internal VerificationClient(RawClient client)
    {
        _client = client;
        Templates = new TemplatesClient(_client);
    }

    public ITemplatesClient Templates { get; }
}
