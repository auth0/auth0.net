using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Emails;

[Serializable]
public record UpdateEmailProviderRequestContent
{
    [Optional]
    [JsonPropertyName("name")]
    public EmailProviderNameEnum? Name { get; set; }

    /// <summary>
    /// Whether the provider is enabled (true) or disabled (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Email address to use as "from" when no other address specified.
    /// </summary>
    [Optional]
    [JsonPropertyName("default_from_address")]
    public string? DefaultFromAddress { get; set; }

    [Optional]
    [JsonPropertyName("credentials")]
    public EmailProviderCredentialsSchema? Credentials { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("settings")]
    public Optional<Dictionary<string, object?>?> Settings { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
