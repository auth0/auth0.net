using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateVerifiableCredentialTemplateResponseContent
    : IJsonOnDeserialized,
        IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// The id of the template.
    /// </summary>
    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The name of the template.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The type of the template.
    /// </summary>
    [Optional]
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// The dialect of the template.
    /// </summary>
    [Optional]
    [JsonPropertyName("dialect")]
    public string? Dialect { get; set; }

    [Optional]
    [JsonPropertyName("presentation")]
    public MdlPresentationRequest? Presentation { get; set; }

    /// <summary>
    /// The custom certificate authority.
    /// </summary>
    [Optional]
    [JsonPropertyName("custom_certificate_authority")]
    public string? CustomCertificateAuthority { get; set; }

    /// <summary>
    /// The well-known trusted issuers, comma separated.
    /// </summary>
    [Optional]
    [JsonPropertyName("well_known_trusted_issuers")]
    public string? WellKnownTrustedIssuers { get; set; }

    /// <summary>
    /// The date and time the template was created.
    /// </summary>
    [Optional]
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// The date and time the template was created.
    /// </summary>
    [Optional]
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

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
