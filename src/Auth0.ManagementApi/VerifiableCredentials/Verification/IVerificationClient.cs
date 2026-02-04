namespace Auth0.ManagementApi.VerifiableCredentials.Verification;

public partial interface IVerificationClient
{
    public ITemplatesClient Templates { get; }
}
