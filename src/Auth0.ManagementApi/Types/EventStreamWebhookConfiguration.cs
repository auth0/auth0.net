using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Configuration specific to a webhook destination.
/// </summary>
[Serializable]
public record EventStreamWebhookConfiguration : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Target HTTP endpoint URL.
    /// </summary>
    [JsonPropertyName("webhook_endpoint")]
    public required string WebhookEndpoint { get; set; }

    [JsonPropertyName("webhook_authorization")]
    public required EventStreamWebhookAuthorizationResponse WebhookAuthorization { get; set; }

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
