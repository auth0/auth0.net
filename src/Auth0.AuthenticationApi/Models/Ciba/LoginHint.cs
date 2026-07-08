using System.Text.Json;
using System.Text.Json.Serialization;

namespace Auth0.AuthenticationApi.Models.Ciba;

/// <summary>
/// Contains information about the user to contact for authentication.
/// </summary>
public class LoginHint
{
    [JsonPropertyName("format")]
    public string Format { get; set; }

    /// <summary>
    /// Issuer of the ID Token.
    /// This value should match the 'Issuer' value configured in the well-known configuration.
    /// </summary>
    [JsonPropertyName("iss")]
    public string Issuer { get; set; }

    [JsonPropertyName("sub")]
    public string Subject { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this, Auth0.Core.Serialization.Auth0JsonSerializerOptions.Default);
    }
}
