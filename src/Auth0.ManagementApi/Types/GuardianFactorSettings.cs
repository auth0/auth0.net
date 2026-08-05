using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Factor-specific settings. Only returned when include_settings=true.
/// </summary>
[Serializable]
public record GuardianFactorSettings : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// The length of the OTP code.
    /// </summary>
    [Optional]
    [JsonPropertyName("otp_length")]
    public int? OtpLength { get; set; }

    /// <summary>
    /// The OTP expiration time in seconds.
    /// </summary>
    [Optional]
    [JsonPropertyName("otp_expiration_time")]
    public int? OtpExpirationTime { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
