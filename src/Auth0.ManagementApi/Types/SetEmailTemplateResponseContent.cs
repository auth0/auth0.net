using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record SetEmailTemplateResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("template")]
    public required EmailTemplateNameEnum Template { get; set; }

    /// <summary>
    /// Body of the email template.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("body")]
    public Optional<string?> Body { get; set; }

    /// <summary>
    /// Senders `from` email address.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("from")]
    public Optional<string?> From { get; set; }

    /// <summary>
    /// URL to redirect the user to after a successful action.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("resultUrl")]
    public Optional<string?> ResultUrl { get; set; }

    /// <summary>
    /// Subject line of the email.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("subject")]
    public Optional<string?> Subject { get; set; }

    /// <summary>
    /// Syntax of the template body.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("syntax")]
    public Optional<string?> Syntax { get; set; }

    /// <summary>
    /// Lifetime in seconds that the link within the email will be valid for.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("urlLifetimeInSeconds")]
    public Optional<double?> UrlLifetimeInSeconds { get; set; }

    /// <summary>
    /// Whether the `reset_email` and `verify_email` templates should include the user's email address as the `email` parameter in the returnUrl (true) or whether no email address should be included in the redirect (false). Defaults to true.
    /// </summary>
    [Optional]
    [JsonPropertyName("includeEmailInRedirect")]
    public bool? IncludeEmailInRedirect { get; set; }

    /// <summary>
    /// Whether the template is enabled (true) or disabled (false).
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("enabled")]
    public Optional<bool?> Enabled { get; set; }

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
