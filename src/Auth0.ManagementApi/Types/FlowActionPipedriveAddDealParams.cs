using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record FlowActionPipedriveAddDealParams : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("connection_id")]
    public required string ConnectionId { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [Optional]
    [JsonPropertyName("value")]
    public string? Value { get; set; }

    [Optional]
    [JsonPropertyName("user_id")]
    public FlowActionPipedriveAddDealParamsUserId? UserId { get; set; }

    [Optional]
    [JsonPropertyName("person_id")]
    public FlowActionPipedriveAddDealParamsPersonId? PersonId { get; set; }

    [Optional]
    [JsonPropertyName("organization_id")]
    public FlowActionPipedriveAddDealParamsOrganizationId? OrganizationId { get; set; }

    [Optional]
    [JsonPropertyName("stage_id")]
    public FlowActionPipedriveAddDealParamsStageId? StageId { get; set; }

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
