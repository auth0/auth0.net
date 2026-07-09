using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Auth0.AuthenticationApi.Models;

/// <summary>
/// Represents an access token response.
/// </summary>
public class AccessTokenResponse : TokenBase
{
    /// <summary>
    /// Identifier token.
    /// </summary>
    [JsonPropertyName("id_token")]
    public string IdToken { get; set; }

    /// <summary>
    /// Expiration time in seconds.
    /// </summary>
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }

    /// <summary>
    /// Refresh token.
    /// </summary>
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }
        
    public IDictionary<string, IEnumerable<string>> Headers { get; set; }
}