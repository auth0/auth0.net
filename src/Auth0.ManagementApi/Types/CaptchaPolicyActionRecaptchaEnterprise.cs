using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// reCAPTCHA Enterprise provider configuration.
/// </summary>
[Serializable]
public record CaptchaPolicyActionRecaptchaEnterprise : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The reCAPTCHA Enterprise site key.
    /// </summary>
    [Optional]
    [JsonPropertyName("site_key")]
    public string? SiteKey { get; set; }

    /// <summary>
    /// The Google Cloud project ID.
    /// </summary>
    [Optional]
    [JsonPropertyName("project_id")]
    public string? ProjectId { get; set; }

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
