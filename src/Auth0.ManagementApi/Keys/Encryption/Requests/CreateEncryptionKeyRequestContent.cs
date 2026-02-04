using System.Text.Json.Serialization;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Keys;

[Serializable]
public record CreateEncryptionKeyRequestContent
{
    [JsonPropertyName("type")]
    public required CreateEncryptionKeyType Type { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
