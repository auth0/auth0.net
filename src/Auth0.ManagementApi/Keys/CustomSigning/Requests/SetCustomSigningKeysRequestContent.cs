using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Keys;

[Serializable]
public record SetCustomSigningKeysRequestContent
{
    /// <summary>
    /// An array of custom public signing keys.
    /// </summary>
    [JsonPropertyName("keys")]
    public IEnumerable<CustomSigningKeyJwk> Keys { get; set; } = new List<CustomSigningKeyJwk>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
