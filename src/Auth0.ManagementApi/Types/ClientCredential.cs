using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record ClientCredential : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// ID of the credential. Generated on creation.
    /// </summary>
    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The name given to the credential by the user.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The key identifier of the credential, generated on creation.
    /// </summary>
    [Optional]
    [JsonPropertyName("kid")]
    public string? Kid { get; set; }

    [Optional]
    [JsonPropertyName("alg")]
    public ClientCredentialAlgorithmEnum? Alg { get; set; }

    [Optional]
    [JsonPropertyName("credential_type")]
    public ClientCredentialTypeEnum? CredentialType { get; set; }

    /// <summary>
    /// The X509 certificate's Subject Distinguished Name
    /// </summary>
    [Optional]
    [JsonPropertyName("subject_dn")]
    public string? SubjectDn { get; set; }

    /// <summary>
    /// The X509 certificate's SHA256 thumbprint
    /// </summary>
    [Optional]
    [JsonPropertyName("thumbprint_sha256")]
    public string? ThumbprintSha256 { get; set; }

    /// <summary>
    /// The ISO 8601 formatted date the credential was created.
    /// </summary>
    [Optional]
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// The ISO 8601 formatted date the credential was updated.
    /// </summary>
    [Optional]
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// The ISO 8601 formatted date representing the expiration of the credential.
    /// </summary>
    [Optional]
    [JsonPropertyName("expires_at")]
    public DateTime? ExpiresAt { get; set; }

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
