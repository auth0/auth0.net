using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateRuleRequestContent
{
    /// <summary>
    /// Name of this rule.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Code to be executed when this rule runs.
    /// </summary>
    [JsonPropertyName("script")]
    public required string Script { get; set; }

    /// <summary>
    /// Order that this rule should execute in relative to other rules. Lower-valued rules execute first.
    /// </summary>
    [Optional]
    [JsonPropertyName("order")]
    public double? Order { get; set; }

    /// <summary>
    /// Whether the rule is enabled (true), or disabled (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
