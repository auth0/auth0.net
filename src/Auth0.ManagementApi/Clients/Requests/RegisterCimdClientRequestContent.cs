using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record RegisterCimdClientRequestContent
{
    /// <summary>
    /// URL to the Client ID Metadata Document. Acts as the unique identifier for upsert operations.
    /// </summary>
    [JsonPropertyName("external_client_id")]
    public required string ExternalClientId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
