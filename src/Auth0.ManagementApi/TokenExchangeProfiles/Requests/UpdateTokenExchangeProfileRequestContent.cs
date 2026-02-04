using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateTokenExchangeProfileRequestContent
{
    /// <summary>
    /// Friendly name of this profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Subject token type for this profile. When receiving a token exchange request on the Authentication API, the corresponding token exchange profile with a matching subject_token_type will be executed. This must be a URI.
    /// </summary>
    [Optional]
    [JsonPropertyName("subject_token_type")]
    public string? SubjectTokenType { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
