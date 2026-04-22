using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Configuration related to the My Organization Configuration for the client.
/// </summary>
[Serializable]
public record ClientMyOrganizationPatchConfiguration : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The connection profile ID that this client should validate against.
    /// </summary>
    [Optional]
    [JsonPropertyName("connection_profile_id")]
    public string? ConnectionProfileId { get; set; }

    /// <summary>
    /// The user attribute profile ID that this client should validate against.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_attribute_profile_id")]
    public string? UserAttributeProfileId { get; set; }

    /// <summary>
    /// The allowed connection strategies for the My Organization Configuration.
    /// </summary>
    [JsonPropertyName("allowed_strategies")]
    public IEnumerable<ClientMyOrganizationConfigurationAllowedStrategiesEnum> AllowedStrategies { get; set; } =
        new List<ClientMyOrganizationConfigurationAllowedStrategiesEnum>();

    [JsonPropertyName("connection_deletion_behavior")]
    public required ClientMyOrganizationDeletionBehaviorEnum ConnectionDeletionBehavior { get; set; }

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
