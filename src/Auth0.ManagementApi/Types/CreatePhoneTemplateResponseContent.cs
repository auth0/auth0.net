using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record CreatePhoneTemplateResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [Optional]
    [JsonPropertyName("channel")]
    public string? Channel { get; set; }

    [Optional]
    [JsonPropertyName("customizable")]
    public bool? Customizable { get; set; }

    [Optional]
    [JsonPropertyName("tenant")]
    public string? Tenant { get; set; }

    [JsonPropertyName("content")]
    public required PhoneTemplateContent Content { get; set; }

    [JsonPropertyName("type")]
    public required PhoneTemplateNotificationTypeEnum Type { get; set; }

    /// <summary>
    /// Whether the template is enabled (false) or disabled (true).
    /// </summary>
    [JsonPropertyName("disabled")]
    public required bool Disabled { get; set; }

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
