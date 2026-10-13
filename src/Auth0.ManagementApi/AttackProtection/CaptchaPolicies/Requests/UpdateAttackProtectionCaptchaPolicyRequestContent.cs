using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.AttackProtection;

[Serializable]
public record UpdateAttackProtectionCaptchaPolicyRequestContent
{
    /// <summary>
    /// Human-readable policy name.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Description of the policy's purpose.
    /// </summary>
    [Optional]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Conflict resolution order. Lower number takes higher precedence. Must be unique per tenant.
    /// </summary>
    [Optional]
    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    [Optional]
    [JsonPropertyName("match")]
    public AttackProtectionCaptchaPolicyMatch? Match { get; set; }

    [Optional]
    [JsonPropertyName("action")]
    public AttackProtectionCaptchaPolicyActionInput? Action { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
