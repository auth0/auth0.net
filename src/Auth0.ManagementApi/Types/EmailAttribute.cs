using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Configuration for the email attribute for users.
/// </summary>
[Serializable]
public record EmailAttribute : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("identifier")]
    public ConnectionAttributeIdentifier? Identifier { get; set; }

    /// <summary>
    /// Determines if the attribute is unique in a given connection
    /// </summary>
    [Optional]
    [JsonPropertyName("unique")]
    public bool? Unique { get; set; }

    /// <summary>
    /// Determines if property should be required for users
    /// </summary>
    [Optional]
    [JsonPropertyName("profile_required")]
    public bool? ProfileRequired { get; set; }

    [Optional]
    [JsonPropertyName("verification_method")]
    public VerificationMethodEnum? VerificationMethod { get; set; }

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
