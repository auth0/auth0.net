using System.Text.Json.Serialization;

namespace Auth0.AuthenticationApi.Models.Mfa;

public class MfaChallengeResponse
{
    /// <summary>
    /// Type of challenge issued.
    /// </summary>
    [JsonPropertyName("challenge_type")]
    public string ChallengeType { get; set; }

    /// <summary>
    /// Code for out-of-band challenge (only if applicable).
    /// </summary>
    [JsonPropertyName("oob_code")]
    public string OobCode { get; set; }

    /// <summary>
    /// Method used for binding (only if applicable).
    /// </summary>
    [JsonPropertyName("binding_method")]
    public string BindingMethod { get; set; }
}