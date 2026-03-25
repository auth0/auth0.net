using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Password complexity requirements configuration
/// </summary>
[Serializable]
public record ConnectionPasswordOptionsComplexity : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Minimum password length required (1-72 characters)
    /// </summary>
    [Optional]
    [JsonPropertyName("min_length")]
    public int? MinLength { get; set; }

    /// <summary>
    /// Required character types that must be present in passwords. Valid options: uppercase, lowercase, number, special
    /// </summary>
    [Optional]
    [JsonPropertyName("character_types")]
    public IEnumerable<PasswordCharacterTypeEnum>? CharacterTypes { get; set; }

    [Optional]
    [JsonPropertyName("character_type_rule")]
    public PasswordCharacterTypeRulePolicyEnum? CharacterTypeRule { get; set; }

    [Optional]
    [JsonPropertyName("identical_characters")]
    public PasswordIdenticalCharactersPolicyEnum? IdenticalCharacters { get; set; }

    [Optional]
    [JsonPropertyName("sequential_characters")]
    public PasswordSequentialCharactersPolicyEnum? SequentialCharacters { get; set; }

    [Optional]
    [JsonPropertyName("max_length_exceeded")]
    public PasswordMaxLengthExceededPolicyEnum? MaxLengthExceeded { get; set; }

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
