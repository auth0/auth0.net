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

    /// <summary>
    /// The scopes that were actually granted for this token.
    /// </summary>
    /// <remarks>
    /// The authorization server returns the granted scope, which
    /// may be narrower than the scope that was requested. Compare this against the
    /// requested scope to detect an insufficient-scope grant.
    /// </remarks>
    [JsonPropertyName("scope")]
    public string Scope { get; set; }

    /// <summary>
    /// The type of the token issued, as a URN.
    /// </summary>
    /// <remarks>
    /// Returned by the token-exchange grant to indicate which kind of token was issued —
    /// for example <see cref="TokenType.AccessToken"/> for a normal access token, or
    /// <see cref="TokenType.SessionTransferToken"/> for an Auth0 Session Transfer Token.
    /// Null for flows that do not return this field.
    /// </remarks>
    [JsonPropertyName("issued_token_type")]
    public string IssuedTokenType { get; set; }

    public IDictionary<string, IEnumerable<string>> Headers { get; set; }
}