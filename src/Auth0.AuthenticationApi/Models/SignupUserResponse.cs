using System;

using System.Text.Json.Serialization;
using Auth0.AuthenticationApi.Serialization;

namespace Auth0.AuthenticationApi.Models;

/// <summary>
/// Represents the response from signing up a new user.
/// </summary>
[JsonConverter(typeof(SignupUserResponseConverter))]
public class SignupUserResponse
{
    /// <summary>
    /// Email address of the new user.
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    /// Indicates whether the email has been verified or not.
    /// </summary>
    /// <value><c>true</c> if the email is verified; otherwise, <c>false</c>.</value>
    [JsonPropertyName("email_verified")]
    public bool EmailVerified { get; set; }

    /// <summary>
    /// Unique identifier of the user.
    /// </summary>
    /// <remarks>
    /// The server can return `_id`, `id` or `user_id` depending on various factors.
    /// For convenience we expose it here as just one.
    /// </remarks>
    [JsonIgnore]
    public string Id { get; set; }

    /// <summary>
    /// Username of this user.
    /// </summary>
    [JsonPropertyName("username")]
    public string Username { get; set; }

    /// <summary>
    /// Given name of this user.
    /// </summary>
    [JsonPropertyName("given_name")]
    public string GivenName { get; set; }

    /// <summary>
    /// Family name of this user.
    /// </summary>
    [JsonPropertyName("family_name")]
    public string FamilyName { get; set; }

    /// <summary>
    /// Name of this user.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Nickname of this user.
    /// </summary>
    [JsonPropertyName("nickname")]
    public string Nickname { get; set; }

    /// <summary>
    /// Url to a picture of this user.
    /// </summary>
    [JsonPropertyName("picture")]
    public Uri Picture { get; set; }

    /// <summary>
    /// Metadata the user has read/write access to. 
    /// </summary>
    [JsonPropertyName("user_metadata")]
    public dynamic UserMetadata { get; set; }
        
    /// <summary>
    ///  The user's phone number.
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }
}