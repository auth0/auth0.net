using System.Text.Json.Serialization;

namespace Auth0.AuthenticationApi.Models;

/// <summary>
/// Represents a Passwordless email response.
/// </summary>
public class PasswordlessEmailResponse
{
    /// <summary>
    /// Identifier of this request.
    /// </summary>
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    /// <summary>
    /// Email to which the request was sent.
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    /// Whether the email address has been verified (true) or has not been verified (false).
    /// </summary>
    [JsonPropertyName("email_verified")]
    public bool? EmailVerified { get; set; }
}