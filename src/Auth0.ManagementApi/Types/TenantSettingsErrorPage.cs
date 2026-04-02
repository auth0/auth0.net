using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Error page customization.
/// </summary>
[Serializable]
public record TenantSettingsErrorPage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Custom Error HTML (<see href="https://github.com/Shopify/liquid/wiki/Liquid-for-Designers">Liquid syntax</see> is supported).
    /// </summary>
    [Optional]
    [JsonPropertyName("html")]
    public string? Html { get; set; }

    /// <summary>
    /// Whether to show the link to log as part of the default error page (true, default) or not to show the link (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("show_log_link")]
    public bool? ShowLogLink { get; set; }

    /// <summary>
    /// URL to redirect to when an error occurs instead of showing the default error page.
    /// </summary>
    [Optional]
    [JsonPropertyName("url")]
    public string? Url { get; set; }

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
