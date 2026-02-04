using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Microsoft Office 365 SSO configuration.
/// </summary>
[Serializable]
public record ClientAddonOffice365 : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Your Office 365 domain name. e.g. `acme-org.com`.
    /// </summary>
    [Optional]
    [JsonPropertyName("domain")]
    public string? Domain { get; set; }

    /// <summary>
    /// Optional Auth0 database connection for testing an already-configured Office 365 tenant.
    /// </summary>
    [Optional]
    [JsonPropertyName("connection")]
    public string? Connection { get; set; }

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
