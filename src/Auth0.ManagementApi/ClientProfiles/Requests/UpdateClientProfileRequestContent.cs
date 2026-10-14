using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateClientProfileRequestContent
{
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("description")]
    public Optional<string?> Description { get; set; }

    [Optional]
    [JsonPropertyName("client_configuration")]
    public ClientProfileClientConfiguration? ClientConfiguration { get; set; }

    [Optional]
    [JsonPropertyName("apply_policy")]
    public ClientProfileApplyPolicy? ApplyPolicy { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
