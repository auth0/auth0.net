using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Options for the passkey authentication method
/// </summary>
[Serializable]
public record ConnectionPasskeyOptions : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("challenge_ui")]
    public ConnectionPasskeyChallengeUiEnum? ChallengeUi { get; set; }

    /// <summary>
    /// Enables or disables progressive enrollment of passkeys for the connection.
    /// </summary>
    [Optional]
    [JsonPropertyName("progressive_enrollment_enabled")]
    public bool? ProgressiveEnrollmentEnabled { get; set; }

    /// <summary>
    /// Enables or disables enrollment prompt for local passkey when user authenticates using a cross-device passkey for the connection.
    /// </summary>
    [Optional]
    [JsonPropertyName("local_enrollment_enabled")]
    public bool? LocalEnrollmentEnabled { get; set; }

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
