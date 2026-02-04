using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateUserRequestContent
{
    /// <summary>
    /// The user's email.
    /// </summary>
    [Optional]
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// The user's phone number (following the E.164 recommendation).
    /// </summary>
    [Optional]
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    [Optional]
    [JsonPropertyName("user_metadata")]
    public Dictionary<string, object?>? UserMetadata { get; set; }

    /// <summary>
    /// Whether this user was blocked by an administrator (true) or not (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("blocked")]
    public bool? Blocked { get; set; }

    /// <summary>
    /// Whether this email address is verified (true) or unverified (false). User will receive a verification email after creation if `email_verified` is false or not specified
    /// </summary>
    [Optional]
    [JsonPropertyName("email_verified")]
    public bool? EmailVerified { get; set; }

    /// <summary>
    /// Whether this phone number has been verified (true) or not (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("phone_verified")]
    public bool? PhoneVerified { get; set; }

    [Optional]
    [JsonPropertyName("app_metadata")]
    public Dictionary<string, object?>? AppMetadata { get; set; }

    /// <summary>
    /// The user's given name(s).
    /// </summary>
    [Optional]
    [JsonPropertyName("given_name")]
    public string? GivenName { get; set; }

    /// <summary>
    /// The user's family name(s).
    /// </summary>
    [Optional]
    [JsonPropertyName("family_name")]
    public string? FamilyName { get; set; }

    /// <summary>
    /// The user's full name.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The user's nickname.
    /// </summary>
    [Optional]
    [JsonPropertyName("nickname")]
    public string? Nickname { get; set; }

    /// <summary>
    /// A URI pointing to the user's picture.
    /// </summary>
    [Optional]
    [JsonPropertyName("picture")]
    public string? Picture { get; set; }

    /// <summary>
    /// The external user's id provided by the identity provider.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_id")]
    public string? UserId { get; set; }

    /// <summary>
    /// Name of the connection this user should be created in.
    /// </summary>
    [JsonPropertyName("connection")]
    public required string Connection { get; set; }

    /// <summary>
    /// Initial password for this user. Only valid for auth0 connection strategy.
    /// </summary>
    [Optional]
    [JsonPropertyName("password")]
    public string? Password { get; set; }

    /// <summary>
    /// Whether the user will receive a verification email after creation (true) or no email (false). Overrides behavior of `email_verified` parameter.
    /// </summary>
    [Optional]
    [JsonPropertyName("verify_email")]
    public bool? VerifyEmail { get; set; }

    /// <summary>
    /// The user's username. Only valid if the connection requires a username.
    /// </summary>
    [Optional]
    [JsonPropertyName("username")]
    public string? Username { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
