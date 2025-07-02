using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models.Mfa;

public class MfaOtpTokenResponse : TokenBase
{
    /// <summary>
    /// The duration in seconds that the access token is valid.
    /// </summary>
    [JsonProperty("expires_in")]
    public int ExpiresIn { get; set; }
}