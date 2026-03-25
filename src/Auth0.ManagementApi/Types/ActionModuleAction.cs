using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record ActionModuleAction : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The unique ID of the action.
    /// </summary>
    [Optional]
    [JsonPropertyName("action_id")]
    public string? ActionId { get; set; }

    /// <summary>
    /// The name of the action.
    /// </summary>
    [Optional]
    [JsonPropertyName("action_name")]
    public string? ActionName { get; set; }

    /// <summary>
    /// The ID of the module version this action is using.
    /// </summary>
    [Optional]
    [JsonPropertyName("module_version_id")]
    public string? ModuleVersionId { get; set; }

    /// <summary>
    /// The version number of the module this action is using.
    /// </summary>
    [Optional]
    [JsonPropertyName("module_version_number")]
    public int? ModuleVersionNumber { get; set; }

    /// <summary>
    /// The triggers that this action supports.
    /// </summary>
    [Optional]
    [JsonPropertyName("supported_triggers")]
    public IEnumerable<ActionTrigger>? SupportedTriggers { get; set; }

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
