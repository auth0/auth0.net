using System;
using System.Text.Json;
using Auth0.AuthenticationApi.Models;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests;

public class UserInfoDeserializationTests
{
    private static UserInfo Parse(string json) =>
        JsonSerializer.Deserialize<UserInfo>(json);

    [Fact]
    public void Can_read_standard_claims()
    {
        var json = """
        {
          "sub": "123456", "name": "Robert Smith", "given_name": "Robert",
          "family_name": "Smith", "middle_name": "Franklin", "nickname": "Bob",
          "preferred_username": "b.smith", "profile": "http://profiles.com/bsmith",
          "picture": "http://mycompany.com/bob_photo.jpg", "website": "http://mycompany.com/users/bob",
          "email": "bob@mycompany.com", "email_verified": true, "gender": "male",
          "birthdate": "0000-05-22", "zoneinfo": "Europe/Paris", "locale": "en-US",
          "phone_number": "+1 (604) 555-1234;ext5678", "phone_number_verified": false,
          "address": { "formatted": "123 Main St., Anytown, TX 77777", "street_address": "123 Main St.",
            "locality": "Anytown", "region": "Texas", "postal_code": "77777", "country": "US" },
          "updated_at": 1233233333
        }
        """;
        var userInfo = Parse(json);

        userInfo.UserId.Should().Be("123456");
        userInfo.FullName.Should().Be("Robert Smith");
        userInfo.FirstName.Should().Be("Robert");
        userInfo.LastName.Should().Be("Smith");
        userInfo.MiddleName.Should().Be("Franklin");
        userInfo.NickName.Should().Be("Bob");
        userInfo.PreferredUsername.Should().Be("b.smith");
        userInfo.Email.Should().Be("bob@mycompany.com");
        userInfo.EmailVerified.Should().Be(true);
        userInfo.Birthdate.Should().Be("0000-05-22");
        userInfo.Locale.Should().Be("en-US");
        userInfo.PhoneNumberVerified.Should().Be(false);
        userInfo.Address.Country.Should().Be("US");
        userInfo.UpdatedAt.Should().Be(new DateTime(2009, 1, 29, 12, 48, 53, DateTimeKind.Utc));
    }

    [Fact]
    public void Can_read_custom_locale_claim_as_compact_string()
    {
        var userInfo = Parse("""{ "sub": "123456", "locale": { "country": "US", "language": "en" } }""");

        userInfo.Locale.Should().NotBeNull();
        var locale = JsonDocument.Parse(userInfo.Locale).RootElement;
        locale.GetProperty("country").GetString().Should().Be("US");
        locale.GetProperty("language").GetString().Should().Be("en");
    }

    [Fact]
    public void Missing_values_are_null()
    {
        var userInfo = Parse("""{ "sub": "123456" }""");

        userInfo.FullName.Should().BeNull();
        userInfo.EmailVerified.Should().BeNull();
        userInfo.PhoneNumberVerified.Should().BeNull();
        userInfo.Address.Should().BeNull();
        userInfo.UpdatedAt.Should().BeNull();
    }

    [Fact]
    public void Can_read_additional_claims_via_new_json_property()
    {
        var userInfo = Parse("""
        {
          "sub": "123456",
          "http://acme.com/claims/groupIds": [ "bobsdepartment", "administrators" ],
          "http://acme.com/claims/manager": { "name": "John Doe" }
        }
        """);

        var groups = userInfo.AdditionalClaimsJson["http://acme.com/claims/groupIds"];
        groups.ValueKind.Should().Be(JsonValueKind.Array);
        groups[0].GetString().Should().Be("bobsdepartment");
        groups[1].GetString().Should().Be("administrators");

        userInfo.AdditionalClaimsJson["http://acme.com/claims/manager"]
            .GetProperty("name").GetString().Should().Be("John Doe");
    }

    [Fact]
    public void Obsolete_AdditionalClaims_shim_still_returns_jtokens()
    {
#pragma warning disable CS0618 // testing the obsolete member on purpose
        var userInfo = Parse("""
        {
          "sub": "123456",
          "http://acme.com/claims/groupIds": [ "bobsdepartment", "administrators" ],
          "http://acme.com/claims/manager": { "name": "John Doe" }
        }
        """);

        var groups = (JArray)userInfo.AdditionalClaims["http://acme.com/claims/groupIds"];
        groups.Count.Should().Be(2);
        ((string)groups[0]).Should().Be("bobsdepartment");

        dynamic manager = userInfo.AdditionalClaims["http://acme.com/claims/manager"];
        string managerName = manager.name;
        managerName.Should().Be("John Doe");
#pragma warning restore CS0618
    }

    [Fact]
    public void Scalar_additional_claim_is_captured()
    {
        var userInfo = Parse("""{ "sub": "123456", "login_count": 42 }""");

        userInfo.AdditionalClaimsJson["login_count"].GetInt32().Should().Be(42);

#pragma warning disable CS0618 // testing the obsolete member on purpose
        ((int)userInfo.AdditionalClaims["login_count"]).Should().Be(42);
#pragma warning restore CS0618
    }

    [Fact]
    public void Null_additional_claim_is_captured()
    {
        var userInfo = Parse("""{ "sub": "123456", "optional_claim": null }""");

        userInfo.AdditionalClaimsJson.Should().ContainKey("optional_claim");
        userInfo.AdditionalClaimsJson["optional_claim"].ValueKind.Should().Be(JsonValueKind.Null);

#pragma warning disable CS0618 // testing the obsolete member on purpose
        userInfo.AdditionalClaims["optional_claim"].Type.Should().Be(JTokenType.Null);
#pragma warning restore CS0618
    }
}
