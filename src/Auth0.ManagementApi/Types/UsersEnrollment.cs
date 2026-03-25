using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record UsersEnrollment : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// ID of this enrollment.
    /// </summary>
    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [Optional]
    [JsonPropertyName("status")]
    public UserEnrollmentStatusEnum? Status { get; set; }

    /// <summary>
    /// Type of enrollment.
    /// </summary>
    [Optional]
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Name of enrollment (usually phone number).
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Device identifier (usually phone identifier) of this enrollment.
    /// </summary>
    [Optional]
    [JsonPropertyName("identifier")]
    public string? Identifier { get; set; }

    /// <summary>
    /// Phone number for this enrollment.
    /// </summary>
    [Optional]
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    [Optional]
    [JsonPropertyName("auth_method")]
    public UserEnrollmentAuthMethodEnum? AuthMethod { get; set; }

    /// <summary>
    /// Start date and time of this enrollment.
    /// </summary>
    [Optional]
    [JsonPropertyName("enrolled_at")]
    public DateTime? EnrolledAt { get; set; }

    /// <summary>
    /// Last authentication date and time of this enrollment.
    /// </summary>
    [Optional]
    [JsonPropertyName("last_auth")]
    public DateTime? LastAuth { get; set; }

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
