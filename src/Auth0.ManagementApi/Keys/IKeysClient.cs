namespace Auth0.ManagementApi.Keys;

public partial interface IKeysClient
{
    public ICustomSigningClient CustomSigning { get; }
    public IEncryptionClient Encryption { get; }
    public ISigningClient Signing { get; }
}
