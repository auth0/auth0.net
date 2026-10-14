using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Runtime matching rules that determine which clients this profile governs.
/// </summary>
[Serializable]
public record ClientProfileApplyPolicy : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("external_metadata_type")]
    public required ClientProfileApplyPolicyExternalMetadataTypeEnum ExternalMetadataType { get; set; }

    [JsonPropertyName("external_metadata_created_by")]
    public required ClientProfileApplyPolicyExternalMetadataCreatedByEnum ExternalMetadataCreatedBy { get; set; }

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
