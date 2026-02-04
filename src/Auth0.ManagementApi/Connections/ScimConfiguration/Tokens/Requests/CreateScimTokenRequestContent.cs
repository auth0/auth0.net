using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Connections.ScimConfiguration;

[Serializable]
public record CreateScimTokenRequestContent
{
    /// <summary>
    /// The scopes of the scim token
    /// </summary>
    [Optional]
    [JsonPropertyName("scopes")]
    public IEnumerable<string>? Scopes { get; set; }

    /// <summary>
    /// Lifetime of the token in seconds. Must be greater than 900
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("token_lifetime")]
    public Optional<int?> TokenLifetime { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
