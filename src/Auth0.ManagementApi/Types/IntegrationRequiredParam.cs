using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Param are form input values, primarily utilized when specifying secrets and
/// configuration values for actions.
///
/// These are especially important for partner integrations -- but can be
/// exposed to tenant admins as well if they want to parameterize their custom
/// actions.
/// </summary>
[Serializable]
public record IntegrationRequiredParam : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("type")]
    public IntegrationRequiredParamTypeEnum? Type { get; set; }

    /// <summary>
    /// The name of the parameter.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The flag for if this parameter is required.
    /// </summary>
    [Optional]
    [JsonPropertyName("required")]
    public bool? Required { get; set; }

    /// <summary>
    /// The temp flag for if this parameter is required (experimental; for Labs use only).
    /// </summary>
    [Optional]
    [JsonPropertyName("optional")]
    public bool? Optional { get; set; }

    /// <summary>
    /// The short label for this parameter.
    /// </summary>
    [Optional]
    [JsonPropertyName("label")]
    public string? Label { get; set; }

    /// <summary>
    /// The lengthier description for this parameter.
    /// </summary>
    [Optional]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The default value for this parameter.
    /// </summary>
    [Optional]
    [JsonPropertyName("default_value")]
    public string? DefaultValue { get; set; }

    /// <summary>
    /// Placeholder text for this parameter.
    /// </summary>
    [Optional]
    [JsonPropertyName("placeholder")]
    public string? Placeholder { get; set; }

    /// <summary>
    /// The allowable options for this param.
    /// </summary>
    [Optional]
    [JsonPropertyName("options")]
    public IEnumerable<IntegrationRequiredParamOption>? Options { get; set; }

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
