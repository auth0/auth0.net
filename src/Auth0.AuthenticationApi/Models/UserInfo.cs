using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using Auth0.Core.Serialization;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents user information returned from a standard OpenID Connect `/userinfo` endpoint.
    /// </summary>
    /// <remarks>
    /// See http://openid.net/specs/openid-connect-core-1_0.html#StandardClaims for more details.
    /// </remarks>
    public class UserInfo
    {
        /// <summary>
        /// Subject-Identifier for the user at the issuer. A unique value to identify the user.
        /// </summary>
        [JsonProperty("sub")]
        public string UserId { get; set; }

        /// <summary>
        /// Full name of the user in displayable form including all name parts, 
        /// possibly including titles and suffixes, ordered according to the user's locale and preferences.
        /// </summary>
        [JsonProperty("name")]
        public string FullName { get; set; }

        /// <summary>
        /// Given name(s) or first name(s) of the user. 
        /// </summary>
        /// <remarks>
        /// May contain multiple given names separated by space characters.
        /// </remarks>
        [JsonProperty("given_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Surname(s) or last name(s) of the user. 
        /// </summary>
        /// <remarks>
        /// May contain multiple given names separated by space characters or no family name at all.
        /// </remarks>
        [JsonProperty("family_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Middle name(s) of the user. 
        /// </summary>
        /// <remarks>
        /// May contain multiple middle names separated by space characters.
        /// </remarks>
        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Casual name of the user that may or may not be the same as <see cref="FirstName"/>. 
        /// </summary>
        /// <example>
        /// Nickname of 'Mike' might be returned for a <see cref="FirstName"/> of `Michael`.
        /// </example>
        [JsonProperty("nickname")]
        public string NickName { get; set; }

        /// <summary>
        /// Shorthand name by which the user wishes to be referred to at the RP, such as janedoe or j.doe. 
        /// </summary>
        /// <remarks>
        /// MAY be any valid JSON string including special characters such as @, /, or whitespace. 
        /// You MUST NOT rely upon this value being unique.
        /// </remarks>
        [JsonProperty("preferred_username")]
        public string PreferredUsername { get; set; }

        /// <summary>
        /// URL of the user's profile page.
        /// </summary>
        /// <remarks>
        /// The contents of this Web page SHOULD be about the End-User.
        /// </remarks>
        [JsonProperty("profile")]
        public string Profile { get; set; }

        /// <summary>
        /// URL of the user's profile picture.
        /// </summary>
        /// <remarks>
        /// Note that this URL SHOULD specifically reference a profile photo of the End-User suitable for 
        /// displaying when describing the user, rather than an arbitrary photo taken by the user.
        /// </remarks>
        [JsonProperty("picture")]
        public string Picture { get; set; }

        /// <summary>
        /// URL of the user's Web page or blog.
        /// </summary>
        /// <remarks>
        /// This Web page SHOULD contain information published by the End-User or an organization that
        /// the End-User is affiliated with.
        /// </remarks>
        [JsonProperty("website")]
        public string Website { get; set; }

        /// <summary>
        /// User's preferred e-mail address. 
        /// </summary>
        /// <remarks>
        /// You MUST NOT rely upon this value being unique.
        /// </remarks>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Whether the user's email address has been verified or not.
        /// </summary>
        /// <remarks>
        /// When this Claim Value is true, this means that the OP took affirmative steps to ensure that this e-mail 
        /// address was controlled by the user at the time the verification was performed. The means by which an 
        /// e-mail address is verified is context-specific, and dependent upon the trust framework or contractual 
        /// agreements within which the parties are operating.
        /// </remarks>
        [JsonProperty("email_verified")]
        public bool? EmailVerified { get; set; }

        /// <summary>
        /// User's gender.
        /// </summary>
        /// <remarks>
        /// Values defined by the specification include `female` and `male`.
        /// Other values MAY be used when neither of the defined values are applicable.
        /// </remarks>
        [JsonProperty("gender")]
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the user's birthday, represented as an ISO 8601:2004 [ISO8601‑2004] YYYY-MM-DD format. 
        /// The year MAY be 0000, indicating that it is omitted. To represent only the year, YYYY format is allowed. 
        /// </summary>
        [JsonProperty("birthdate")]
        public string Birthdate { get; set; }

        /// <summary>
        /// User's time zone as a "tz database name".
        /// </summary>
        /// <example><code>Europe/Paris</code> or <code>America/Los_Angeles</code>.</example>
        /// <remarks>
        /// See https://en.wikipedia.org/wiki/List_of_tz_database_time_zones for more details.
        /// </remarks>
        [JsonProperty("zoneinfo")]
        public string ZoneInformation { get; set; }

        /// <summary>
        /// User's locale, represented as a BCP47 language tag.
        /// </summary>
        /// <example><code>en-US</code> or <code>fr-CA</code></example>
        /// <remarks>
        /// Typically an ISO 639-1 Alpha-2 language code in lowercase and an 
        /// ISO 3166-1 Alpha-2 country code in uppercase, separated by a dash. 
        /// </remarks>
        [JsonProperty("locale")]
        [JsonConverter(typeof(StringOrObjectAsStringConverter))]
        public string Locale { get; set; }

        /// <summary>
        /// User's preferred telephone number.
        /// </summary>
        /// <example><code>+1 (425) 555-1212</code> or <code>+1 (604) 555-1234;ext=5678.</code></example>
        /// <remarks>
        /// E.164 is the RECOMMENDED format.
        /// If the phone number contains an extension, it is RECOMMENDED that the 
        /// extension be represented using the RFC 3966 extension syntax. 
        /// </remarks>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Whether the user's phone number has been verified or not.
        /// </summary>
        /// <remarks>
        /// When this Claim Value is true, this means that the OP took affirmative steps to ensure that this 
        /// phone number was controlled by the user at the time the verification was performed. 
        /// When true, the phone_number Claim MUST be in E.164 format and any extensions MUST be represented in RFC 3966 format.
        /// </remarks>
        [JsonProperty("phone_number_verified")]
        public bool? PhoneNumberVerified { get; set; }

        /// <summary>
        /// User's preferred postal/mailing address.
        /// </summary>
        [JsonProperty("address")]
        public UserInfoAddress Address { get; set; }

        /// <summary>
        /// Time and date the user's information was last updated. 
        /// </summary>
        [JsonProperty("updated_at")]
        [JsonConverter(typeof(FlexibleDateTimeConverter))]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Additional claims about the user.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalClaims { get; set; }
    }
}
