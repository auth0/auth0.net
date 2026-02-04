using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateUserRequestContent
{
    /// <summary>
    /// Whether this user was blocked by an administrator (true) or not (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("blocked")]
    public bool? Blocked { get; set; }

    /// <summary>
    /// Whether this email address is verified (true) or unverified (false). If set to false the user will not receive a verification email unless `verify_email` is set to true.
    /// </summary>
    [Optional]
    [JsonPropertyName("email_verified")]
    public bool? EmailVerified { get; set; }

    /// <summary>
    /// Email address of this user.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("email")]
    public Optional<string?> Email { get; set; }

    /// <summary>
    /// The user's phone number (following the E.164 recommendation).
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("phone_number")]
    public Optional<string?> PhoneNumber { get; set; }

    /// <summary>
    /// Whether this phone number has been verified (true) or not (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("phone_verified")]
    public bool? PhoneVerified { get; set; }

    [Optional]
    [JsonPropertyName("user_metadata")]
    public Dictionary<string, object?>? UserMetadata { get; set; }

    [Optional]
    [JsonPropertyName("app_metadata")]
    public Dictionary<string, object?>? AppMetadata { get; set; }

    /// <summary>
    /// Given name/first name/forename of this user.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("given_name")]
    public Optional<string?> GivenName { get; set; }

    /// <summary>
    /// Family name/last name/surname of this user.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("family_name")]
    public Optional<string?> FamilyName { get; set; }

    /// <summary>
    /// Name of this user.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("name")]
    public Optional<string?> Name { get; set; }

    /// <summary>
    /// Preferred nickname or alias of this user.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("nickname")]
    public Optional<string?> Nickname { get; set; }

    /// <summary>
    /// URL to picture, photo, or avatar of this user.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("picture")]
    public Optional<string?> Picture { get; set; }

    /// <summary>
    /// Whether this user will receive a verification email after creation (true) or no email (false). Overrides behavior of `email_verified` parameter.
    /// </summary>
    [Optional]
    [JsonPropertyName("verify_email")]
    public bool? VerifyEmail { get; set; }

    /// <summary>
    /// Whether this user will receive a text after changing the phone number (true) or no text (false). Only valid when changing phone number for SMS connections.
    /// </summary>
    [Optional]
    [JsonPropertyName("verify_phone_number")]
    public bool? VerifyPhoneNumber { get; set; }

    /// <summary>
    /// New password for this user. Only valid for database connections.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("password")]
    public Optional<string?> Password { get; set; }

    /// <summary>
    /// Name of the connection to target for this user update.
    /// </summary>
    [Optional]
    [JsonPropertyName("connection")]
    public string? Connection { get; set; }

    /// <summary>
    /// Auth0 client ID. Only valid when updating email address.
    /// </summary>
    [Optional]
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    /// <summary>
    /// The user's username. Only valid if the connection requires a username.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("username")]
    public Optional<string?> Username { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
