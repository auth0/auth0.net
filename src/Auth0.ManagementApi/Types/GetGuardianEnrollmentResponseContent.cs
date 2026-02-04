using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record GetGuardianEnrollmentResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ID for this enrollment.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [Optional]
    [JsonPropertyName("status")]
    public GuardianEnrollmentStatus? Status { get; set; }

    /// <summary>
    /// Device name (only for push notification).
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Device identifier. This is usually the phone identifier.
    /// </summary>
    [Optional]
    [JsonPropertyName("identifier")]
    public string? Identifier { get; set; }

    /// <summary>
    /// Phone number.
    /// </summary>
    [Optional]
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    [Optional]
    [JsonPropertyName("enrolled_at")]
    public string? EnrolledAt { get; set; }

    [Optional]
    [JsonPropertyName("last_auth")]
    public string? LastAuth { get; set; }

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
