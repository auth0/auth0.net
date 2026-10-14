using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.AttackProtection;

[Serializable]
public record CreateAttackProtectionCaptchaPolicyRequestContent
{
    /// <summary>
    /// Human-readable policy name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Description of the attack protection policy.
    /// </summary>
    [Optional]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Conflict resolution order. Lower number takes higher precedence. Must be unique per tenant.
    /// </summary>
    [JsonPropertyName("priority")]
    public required int Priority { get; set; }

    [JsonPropertyName("match")]
    public required AttackProtectionCaptchaPolicyMatch Match { get; set; }

    [JsonPropertyName("action")]
    public required AttackProtectionCaptchaPolicyActionInput Action { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
