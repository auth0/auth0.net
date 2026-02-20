using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record GetActionModuleActionsResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A list of action references.
    /// </summary>
    [Optional]
    [JsonPropertyName("actions")]
    public IEnumerable<ActionModuleAction>? Actions { get; set; }

    /// <summary>
    /// The total number of actions using this module.
    /// </summary>
    [Optional]
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    /// <summary>
    /// The page index of the returned results.
    /// </summary>
    [Optional]
    [JsonPropertyName("page")]
    public int? Page { get; set; }

    /// <summary>
    /// The number of results requested per page.
    /// </summary>
    [Optional]
    [JsonPropertyName("per_page")]
    public int? PerPage { get; set; }

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
