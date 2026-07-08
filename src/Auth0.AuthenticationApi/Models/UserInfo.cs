using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

using Newtonsoft.Json.Linq;

using Auth0.Core.Serialization;

namespace Auth0.AuthenticationApi.Models;

/// <summary>
/// Represents user information returned from a standard OpenID Connect `/userinfo` endpoint.
/// </summary>
/// <remarks>
/// See http://openid.net/specs/openid-connect-core-1_0.html#StandardClaims for more details.
/// </remarks>
public class UserInfo
{
    /// <summary>Subject-Identifier for the user at the issuer. A unique value to identify the user.</summary>
    [JsonPropertyName("sub")]
    public string UserId { get; set; }

    /// <summary>Full name of the user in displayable form.</summary>
    [JsonPropertyName("name")]
    public string FullName { get; set; }

    /// <summary>Given name(s) or first name(s) of the user.</summary>
    [JsonPropertyName("given_name")]
    public string FirstName { get; set; }

    /// <summary>Surname(s) or last name(s) of the user.</summary>
    [JsonPropertyName("family_name")]
    public string LastName { get; set; }

    /// <summary>Middle name(s) of the user.</summary>
    [JsonPropertyName("middle_name")]
    public string MiddleName { get; set; }

    /// <summary>Casual name of the user.</summary>
    [JsonPropertyName("nickname")]
    public string NickName { get; set; }

    /// <summary>Shorthand name by which the user wishes to be referred to at the RP.</summary>
    [JsonPropertyName("preferred_username")]
    public string PreferredUsername { get; set; }

    /// <summary>URL of the user's profile page.</summary>
    [JsonPropertyName("profile")]
    public string Profile { get; set; }

    /// <summary>URL of the user's profile picture.</summary>
    [JsonPropertyName("picture")]
    public string Picture { get; set; }

    /// <summary>URL of the user's Web page or blog.</summary>
    [JsonPropertyName("website")]
    public string Website { get; set; }

    /// <summary>User's preferred e-mail address.</summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>Whether the user's email address has been verified or not.</summary>
    [JsonPropertyName("email_verified")]
    public bool? EmailVerified { get; set; }

    /// <summary>User's gender.</summary>
    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    /// <summary>User's birthday, ISO 8601:2004 YYYY-MM-DD format.</summary>
    [JsonPropertyName("birthdate")]
    public string Birthdate { get; set; }

    /// <summary>User's time zone as a "tz database name".</summary>
    [JsonPropertyName("zoneinfo")]
    public string ZoneInformation { get; set; }

    /// <summary>User's locale, represented as a BCP47 language tag.</summary>
    [JsonPropertyName("locale")]
    [JsonConverter(typeof(StringOrObjectAsStringConverter))]
    public string Locale { get; set; }

    /// <summary>User's preferred telephone number.</summary>
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }

    /// <summary>Whether the user's phone number has been verified or not.</summary>
    [JsonPropertyName("phone_number_verified")]
    public bool? PhoneNumberVerified { get; set; }

    /// <summary>User's preferred postal/mailing address.</summary>
    [JsonPropertyName("address")]
    public UserInfoAddress Address { get; set; }

    /// <summary>Time and date the user's information was last updated.</summary>
    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(Auth0.AuthenticationApi.FlexibleDateTimeConverter))]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Additional claims about the user, captured as raw JSON elements.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalClaimsJson { get; set; }
        = new Dictionary<string, JsonElement>();

    /// <summary>
    /// Additional claims about the user.
    /// </summary>
    /// <remarks>
    /// Computed on each access from <see cref="AdditionalClaimsJson"/>; the returned dictionary is a
    /// snapshot, so mutating it does not persist back onto the <see cref="UserInfo"/> instance.
    /// </remarks>
    [Obsolete("Use AdditionalClaimsJson. AdditionalClaims will be removed in a future major version.")]
    [JsonIgnore]
    public IDictionary<string, JToken> AdditionalClaims =>
        AdditionalClaimsJson.ToDictionary(
            kv => kv.Key,
            kv => JToken.Parse(kv.Value.GetRawText()));
}
