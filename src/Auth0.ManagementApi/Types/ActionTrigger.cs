using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record ActionTrigger : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The version of a trigger. v1, v2, etc.
    /// </summary>
    [Optional]
    [JsonPropertyName("version")]
    public string? Version { get; set; }

    /// <summary>
    /// status points to the trigger status.
    /// </summary>
    [Optional]
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// runtimes supported by this trigger.
    /// </summary>
    [Optional]
    [JsonPropertyName("runtimes")]
    public IEnumerable<string>? Runtimes { get; set; }

    /// <summary>
    /// Runtime that will be used when none is specified when creating an action.
    /// </summary>
    [Optional]
    [JsonPropertyName("default_runtime")]
    public string? DefaultRuntime { get; set; }

    /// <summary>
    /// compatible_triggers informs which other trigger supports the same event and api.
    /// </summary>
    [Optional]
    [JsonPropertyName("compatible_triggers")]
    public IEnumerable<ActionTriggerCompatibleTrigger>? CompatibleTriggers { get; set; }

    [Optional]
    [JsonPropertyName("binding_policy")]
    public ActionBindingTypeEnum? BindingPolicy { get; set; }

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
