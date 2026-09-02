using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Controls role visibility for organization administrators.
/// </summary>
[Serializable]
public record OrganizationTemplateRoleVisibilityPolicy : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("default_value")]
    public required OrganizationTemplateRoleVisibilityEnum DefaultValue { get; set; }

    /// <summary>
    /// Role-specific visibility overrides.
    /// </summary>
    [Optional]
    [JsonPropertyName("overrides")]
    public IEnumerable<OrganizationTemplateRoleVisibilityOverride>? Overrides { get; set; }

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
