using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// SAML2 addon indicator (no configuration settings needed for SAML2 addon).
/// </summary>
[Serializable]
public record ClientAddonSaml : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [Optional]
    [JsonPropertyName("mappings")]
    public Dictionary<string, object?>? Mappings { get; set; }

    [Optional]
    [JsonPropertyName("audience")]
    public string? Audience { get; set; }

    [Optional]
    [JsonPropertyName("recipient")]
    public string? Recipient { get; set; }

    [Optional]
    [JsonPropertyName("createUpnClaim")]
    public bool? CreateUpnClaim { get; set; }

    [Optional]
    [JsonPropertyName("mapUnknownClaimsAsIs")]
    public bool? MapUnknownClaimsAsIs { get; set; }

    [Optional]
    [JsonPropertyName("passthroughClaimsWithNoMapping")]
    public bool? PassthroughClaimsWithNoMapping { get; set; }

    [Optional]
    [JsonPropertyName("mapIdentities")]
    public bool? MapIdentities { get; set; }

    [Optional]
    [JsonPropertyName("signatureAlgorithm")]
    public string? SignatureAlgorithm { get; set; }

    [Optional]
    [JsonPropertyName("digestAlgorithm")]
    public string? DigestAlgorithm { get; set; }

    [Optional]
    [JsonPropertyName("issuer")]
    public string? Issuer { get; set; }

    [Optional]
    [JsonPropertyName("destination")]
    public string? Destination { get; set; }

    [Optional]
    [JsonPropertyName("lifetimeInSeconds")]
    public int? LifetimeInSeconds { get; set; }

    [Optional]
    [JsonPropertyName("signResponse")]
    public bool? SignResponse { get; set; }

    [Optional]
    [JsonPropertyName("nameIdentifierFormat")]
    public string? NameIdentifierFormat { get; set; }

    [Optional]
    [JsonPropertyName("nameIdentifierProbes")]
    public IEnumerable<string>? NameIdentifierProbes { get; set; }

    [Optional]
    [JsonPropertyName("authnContextClassRef")]
    public string? AuthnContextClassRef { get; set; }

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
