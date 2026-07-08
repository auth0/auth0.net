using System.Text.Json.Serialization;

namespace Auth0.AuthenticationApi.Models.Mfa;

public class MfaOobTokenResponse : TokenBase
{
    /// <summary>
    /// The duration in seconds that the access token is valid.
    /// </summary>
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }

    /// <summary>
    /// Error code returned in case of failure.
    /// </summary>
    [JsonPropertyName("error")]
    public string Error { get; set; }

    /// <summary>
    /// Description of the error.
    /// </summary>
    [JsonPropertyName("error_description")]
    public string ErrorDescription { get; set; }
}