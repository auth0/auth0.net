using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateClientProfileRequestContent
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("description")]
    public Optional<string?> Description { get; set; }

    [JsonPropertyName("client_configuration")]
    public required ClientProfileClientConfiguration ClientConfiguration { get; set; }

    [JsonPropertyName("apply_policy")]
    public required ClientProfileApplyPolicy ApplyPolicy { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
