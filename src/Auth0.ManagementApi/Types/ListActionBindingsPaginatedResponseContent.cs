using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record ListActionBindingsPaginatedResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The total result count.
    /// </summary>
    [Optional]
    [JsonPropertyName("total")]
    public double? Total { get; set; }

    /// <summary>
    /// Page index of the results being returned. First page is 0.
    /// </summary>
    [Optional]
    [JsonPropertyName("page")]
    public double? Page { get; set; }

    /// <summary>
    /// Number of results per page.
    /// </summary>
    [Optional]
    [JsonPropertyName("per_page")]
    public double? PerPage { get; set; }

    /// <summary>
    /// The list of actions that are bound to this trigger in the order in which they will be executed.
    /// </summary>
    [Optional]
    [JsonPropertyName("bindings")]
    public IEnumerable<ActionBinding>? Bindings { get; set; }

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
