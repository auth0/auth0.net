using System.Text.Json.Serialization;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Users;

[Serializable]
public record UpdateUserAuthenticationMethodRequestContent
{
    /// <summary>
    /// A human-readable label to identify the authentication method.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Preferred phone authentication method
    /// </summary>
    [Optional]
    [JsonPropertyName("preferred_authentication_method")]
    public PreferredAuthenticationMethodEnum? PreferredAuthenticationMethod { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
