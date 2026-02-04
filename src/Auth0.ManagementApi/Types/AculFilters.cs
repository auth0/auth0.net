using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Optional filters to apply rendering rules to specific entities
/// </summary>
[Serializable]
public record AculFilters : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("match_type")]
    public AculMatchTypeEnum? MatchType { get; set; }

    /// <summary>
    /// Clients filter
    /// </summary>
    [Optional]
    [JsonPropertyName("clients")]
    public IEnumerable<AculClientFilter>? Clients { get; set; }

    /// <summary>
    /// Organizations filter
    /// </summary>
    [Optional]
    [JsonPropertyName("organizations")]
    public IEnumerable<AculOrganizationFilter>? Organizations { get; set; }

    /// <summary>
    /// Domains filter
    /// </summary>
    [Optional]
    [JsonPropertyName("domains")]
    public IEnumerable<AculDomainFilter>? Domains { get; set; }

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
