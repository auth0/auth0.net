using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record FlowActionPipedriveAddPersonParams : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("connection_id")]
    public required string ConnectionId { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [Optional]
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [Optional]
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [Optional]
    [JsonPropertyName("owner_id")]
    public FlowActionPipedriveAddPersonParamsOwnerId? OwnerId { get; set; }

    [Optional]
    [JsonPropertyName("organization_id")]
    public FlowActionPipedriveAddPersonParamsOrganizationId? OrganizationId { get; set; }

    [Optional]
    [JsonPropertyName("fields")]
    public Dictionary<string, object?>? Fields { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
