using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.AuthenticationApi.Models;

namespace Auth0.AuthenticationApi.Serialization;

/// <summary>
/// Deserializes <see cref="SignupUserResponse"/>, resolving the user identifier from
/// whichever of <c>_id</c>, <c>id</c> or <c>user_id</c> the server returned.
/// </summary>
/// <remarks>
/// System.Text.Json only reliably honours <c>[JsonInclude]</c> on non-public
/// <em>properties</em>, not on private <em>fields</em>; the latter silently fail to bind on
/// .NET Framework. This converter reads through a public-property surrogate so the mapping
/// works identically on every target framework.
/// </remarks>
internal class SignupUserResponseConverter : JsonConverter<SignupUserResponse>
{
    // Public-property mirror of SignupUserResponse used purely as the deserialization
    // target. It carries no converter attribute, so binding it does not recurse.
    private class Surrogate
    {
        [JsonPropertyName("_id")]
        public string UnderscoreId { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("email_verified")]
        public bool EmailVerified { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("given_name")]
        public string GivenName { get; set; }

        [JsonPropertyName("family_name")]
        public string FamilyName { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("nickname")]
        public string Nickname { get; set; }

        [JsonPropertyName("picture")]
        public Uri Picture { get; set; }

        [JsonPropertyName("user_metadata")]
        public JsonElement? UserMetadata { get; set; }

        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }
    }

    public override SignupUserResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var surrogate = JsonSerializer.Deserialize<Surrogate>(ref reader, options);
        if (surrogate == null)
            return null;

        return new SignupUserResponse
        {
            Id = surrogate.UnderscoreId ?? surrogate.Id ?? surrogate.UserId,
            Email = surrogate.Email,
            EmailVerified = surrogate.EmailVerified,
            Username = surrogate.Username,
            GivenName = surrogate.GivenName,
            FamilyName = surrogate.FamilyName,
            Name = surrogate.Name,
            Nickname = surrogate.Nickname,
            Picture = surrogate.Picture,
            UserMetadata = surrogate.UserMetadata,
            PhoneNumber = surrogate.PhoneNumber,
        };
    }

    public override void Write(Utf8JsonWriter writer, SignupUserResponse value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
