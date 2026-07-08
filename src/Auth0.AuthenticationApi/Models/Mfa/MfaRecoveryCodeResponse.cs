using System.Text.Json.Serialization;

namespace Auth0.AuthenticationApi.Models.Mfa;

public class MfaRecoveryCodeResponse : TokenBase
{
    /// <summary>
    /// The duration in seconds that the access token is valid.
    /// </summary>
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }

    /// <summary>
    /// Recovery code to be stored securely for future use.
    /// </summary>
    [JsonPropertyName("recovery_code")]
    public string RecoveryCode { get; set; }
}