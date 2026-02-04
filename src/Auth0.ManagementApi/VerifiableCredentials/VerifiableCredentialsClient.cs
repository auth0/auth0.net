using Auth0.ManagementApi.Core;
using Auth0.ManagementApi.VerifiableCredentials.Verification;

namespace Auth0.ManagementApi.VerifiableCredentials;

public partial class VerifiableCredentialsClient : IVerifiableCredentialsClient
{
    private RawClient _client;

    internal VerifiableCredentialsClient(RawClient client)
    {
        _client = client;
        Verification = new VerificationClient(_client);
    }

    public IVerificationClient Verification { get; }
}
