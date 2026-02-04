using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Android native app configuration.
/// </summary>
[Serializable]
public record ClientMobileAndroid : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// App package name found in AndroidManifest.xml.
    /// </summary>
    [Optional]
    [JsonPropertyName("app_package_name")]
    public string? AppPackageName { get; set; }

    /// <summary>
    /// SHA256 fingerprints of the app's signing certificate. Multiple fingerprints can be used to support different versions of your app, such as debug and production builds.
    /// </summary>
    [Optional]
    [JsonPropertyName("sha256_cert_fingerprints")]
    public IEnumerable<string>? Sha256CertFingerprints { get; set; }

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
