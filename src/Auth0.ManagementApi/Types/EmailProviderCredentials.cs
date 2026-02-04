using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Credentials required to use the provider.
/// </summary>
[Serializable]
public record EmailProviderCredentials : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// API User.
    /// </summary>
    [Optional]
    [JsonPropertyName("api_user")]
    public string? ApiUser { get; set; }

    /// <summary>
    /// AWS or SparkPost region.
    /// </summary>
    [Optional]
    [JsonPropertyName("region")]
    public string? Region { get; set; }

    /// <summary>
    /// SMTP host.
    /// </summary>
    [Optional]
    [JsonPropertyName("smtp_host")]
    public string? SmtpHost { get; set; }

    /// <summary>
    /// SMTP port.
    /// </summary>
    [Optional]
    [JsonPropertyName("smtp_port")]
    public int? SmtpPort { get; set; }

    /// <summary>
    /// SMTP username.
    /// </summary>
    [Optional]
    [JsonPropertyName("smtp_user")]
    public string? SmtpUser { get; set; }

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
