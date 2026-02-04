using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record AttackProtectionUpdateCaptchaRecaptchaEnterprise : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The site key for the reCAPTCHA Enterprise provider.
    /// </summary>
    [JsonPropertyName("site_key")]
    public required string SiteKey { get; set; }

    /// <summary>
    /// The API key for the reCAPTCHA Enterprise provider.
    /// </summary>
    [JsonPropertyName("api_key")]
    public required string ApiKey { get; set; }

    /// <summary>
    /// The project ID for the reCAPTCHA Enterprise provider.
    /// </summary>
    [JsonPropertyName("project_id")]
    public required string ProjectId { get; set; }

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
