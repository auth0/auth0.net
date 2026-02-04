using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Domain verification settings.
/// </summary>
[Serializable]
public record DomainVerification : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Domain verification methods.
    /// </summary>
    [Optional]
    [JsonPropertyName("methods")]
    public IEnumerable<DomainVerificationMethod>? Methods { get; set; }

    [Optional]
    [JsonPropertyName("status")]
    public DomainVerificationStatusEnum? Status { get; set; }

    /// <summary>
    /// The user0-friendly error message in case of failed verification. This field is relevant only for Custom Domains with Auth0-Managed Certificates.
    /// </summary>
    [Optional]
    [JsonPropertyName("error_msg")]
    public string? ErrorMsg { get; set; }

    /// <summary>
    /// The date and time when the custom domain was last verified. This field is relevant only for Custom Domains with Auth0-Managed Certificates.
    /// </summary>
    [Optional]
    [JsonPropertyName("last_verified_at")]
    public string? LastVerifiedAt { get; set; }

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
