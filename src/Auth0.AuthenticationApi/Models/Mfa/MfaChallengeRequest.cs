using Microsoft.IdentityModel.Tokens;

namespace Auth0.AuthenticationApi.Models.Mfa;

public class MfaChallengeRequest : IClientAuthentication
{
    /// <inheritdoc />
    public string ClientId { get; set; }

    /// <inheritdoc />
    public string ClientSecret { get; set; }

    /// <inheritdoc />
    public SecurityKey ClientAssertionSecurityKey { get; set; }

    /// <inheritdoc />
    public string ClientAssertionSecurityKeyAlgorithm { get; set; }

    /// <summary>
    /// The token received from mfa_required error.
    /// </summary>
    public string MfaToken { get; set; }

    /// <summary>
    /// A whitespace-separated list of challenge types accepted by your application.
    /// </summary>
    public string ChallengeType { get; set; }

    /// <summary>
    /// The ID of the authenticator to challenge.
    /// </summary>
    public string AuthenticatorId { get; set; }
}