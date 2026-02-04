using Auth0.ManagementApi.VerifiableCredentials.Verification;

namespace Auth0.ManagementApi.VerifiableCredentials;

public partial interface IVerifiableCredentialsClient
{
    public IVerificationClient Verification { get; }
}
