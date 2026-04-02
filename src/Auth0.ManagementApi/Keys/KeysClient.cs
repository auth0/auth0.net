using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Keys;

public partial class KeysClient : IKeysClient
{
    private readonly RawClient _client;

    internal KeysClient(RawClient client)
    {
        _client = client;
        CustomSigning = new CustomSigningClient(_client);
        Encryption = new EncryptionClient(_client);
        Signing = new SigningClient(_client);
    }

    public ICustomSigningClient CustomSigning { get; }

    public IEncryptionClient Encryption { get; }

    public ISigningClient Signing { get; }
}
