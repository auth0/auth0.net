using System.Text.Json.Serialization;

namespace Auth0.AuthenticationApi.Models;

/// <summary>
/// Base class for all authentication tokens.
/// </summary>
public abstract class TokenBase
{
    /// <summary>
    /// Access token.
    /// </summary>
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }

    /// <summary>
    /// Type of token.
    /// </summary>
    [JsonPropertyName("token_type")]
    public string TokenType { get; set; }
}