using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateRuleResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Name of this rule.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// ID of this rule.
    /// </summary>
    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Whether the rule is enabled (true), or disabled (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Code to be executed when this rule runs.
    /// </summary>
    [Optional]
    [JsonPropertyName("script")]
    public string? Script { get; set; }

    /// <summary>
    /// Order that this rule should execute in relative to other rules. Lower-valued rules execute first.
    /// </summary>
    [Optional]
    [JsonPropertyName("order")]
    public double? Order { get; set; }

    /// <summary>
    /// Execution stage of this rule. Can be `login_success`, `login_failure`, or `pre_authorize`.
    /// </summary>
    [Optional]
    [JsonPropertyName("stage")]
    public string? Stage { get; set; }

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
