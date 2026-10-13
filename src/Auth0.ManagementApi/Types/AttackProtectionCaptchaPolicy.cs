using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// An attack protection policy override for CAPTCHA.
/// </summary>
[Serializable]
public record AttackProtectionCaptchaPolicy : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// System-generated identifier for the policy.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Human-readable policy name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Description of the policy's purpose.
    /// </summary>
    [Optional]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Conflict resolution order. Lower number takes higher precedence.
    /// </summary>
    [JsonPropertyName("priority")]
    public required int Priority { get; set; }

    [JsonPropertyName("match")]
    public required AttackProtectionCaptchaPolicyMatch Match { get; set; }

    [JsonPropertyName("action")]
    public required AttackProtectionCaptchaPolicyAction Action { get; set; }

    /// <summary>
    /// ISO 8601 timestamp when the policy was created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// ISO 8601 timestamp when the policy was last updated.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedAt { get; set; }

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
