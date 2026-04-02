using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record SetGuardianFactorSmsTemplatesResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Message sent to the user when they are invited to enroll with a phone number.
    /// </summary>
    [JsonPropertyName("enrollment_message")]
    public required string EnrollmentMessage { get; set; }

    /// <summary>
    /// Message sent to the user when they are prompted to verify their account.
    /// </summary>
    [JsonPropertyName("verification_message")]
    public required string VerificationMessage { get; set; }

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
