using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Configuration for the phone number attribute for users.
/// </summary>
[Serializable]
public record PhoneAttribute : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("identifier")]
    public ConnectionAttributeIdentifier? Identifier { get; set; }

    /// <summary>
    /// Determines if property should be required for users
    /// </summary>
    [Optional]
    [JsonPropertyName("profile_required")]
    public bool? ProfileRequired { get; set; }

    [Optional]
    [JsonPropertyName("signup")]
    public SignupVerified? Signup { get; set; }

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
