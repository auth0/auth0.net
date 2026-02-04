using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record EmailProviderCredentialsSchemaSmtpHost : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

    /// <summary>
    /// SMTP password.
    /// </summary>
    [Optional]
    [JsonPropertyName("smtp_pass")]
    public string? SmtpPass { get; set; }

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
