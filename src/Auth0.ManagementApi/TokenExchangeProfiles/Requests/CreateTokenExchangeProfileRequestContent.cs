using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateTokenExchangeProfileRequestContent
{
    /// <summary>
    /// Friendly name of this profile.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Subject token type for this profile. When receiving a token exchange request on the Authentication API, the corresponding token exchange profile with a matching subject_token_type will be executed. This must be a URI.
    /// </summary>
    [JsonPropertyName("subject_token_type")]
    public required string SubjectTokenType { get; set; }

    /// <summary>
    /// The ID of the Custom Token Exchange action to execute for this profile, in order to validate the subject_token. The action must use the custom-token-exchange trigger.
    /// </summary>
    [JsonPropertyName("action_id")]
    public required string ActionId { get; set; }

    [JsonPropertyName("type")]
    public required TokenExchangeProfileTypeEnum Type { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
