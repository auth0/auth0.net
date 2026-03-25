using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// AWS addon configuration.
/// </summary>
[Serializable]
public record ClientAddonAws : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// AWS principal ARN, e.g. `arn:aws:iam::010616021751:saml-provider/idpname`
    /// </summary>
    [Optional]
    [JsonPropertyName("principal")]
    public string? Principal { get; set; }

    /// <summary>
    /// AWS role ARN, e.g. `arn:aws:iam::010616021751:role/foo`
    /// </summary>
    [Optional]
    [JsonPropertyName("role")]
    public string? Role { get; set; }

    /// <summary>
    /// AWS token lifetime in seconds
    /// </summary>
    [Optional]
    [JsonPropertyName("lifetime_in_seconds")]
    public int? LifetimeInSeconds { get; set; }

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
