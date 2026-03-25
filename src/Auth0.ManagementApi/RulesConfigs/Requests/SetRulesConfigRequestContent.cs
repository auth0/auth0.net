using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record SetRulesConfigRequestContent
{
    /// <summary>
    /// Value for a rules config variable.
    /// </summary>
    [JsonPropertyName("value")]
    public required string Value { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
