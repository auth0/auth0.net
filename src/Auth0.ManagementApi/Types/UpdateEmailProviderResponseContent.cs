using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateEmailProviderResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Name of the email provider. Can be `mailgun`, `mandrill`, `sendgrid`, `ses`, `sparkpost`, `smtp`, `azure_cs`, `ms365`, or `custom`.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

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
    public EmailProviderCredentials? Credentials { get; set; }

    [Optional]
    [JsonPropertyName("settings")]
    public Dictionary<string, object?>? Settings { get; set; }

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
