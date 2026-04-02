using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Clients;

[Serializable]
public record PatchClientCredentialRequestContent
{
    /// <summary>
    /// The ISO 8601 formatted date representing the expiration of the credential.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("expires_at")]
    public Optional<DateTime?> ExpiresAt { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
