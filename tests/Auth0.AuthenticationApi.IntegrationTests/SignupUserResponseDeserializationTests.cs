using System.Text.Json;
using Auth0.AuthenticationApi.Models;
using FluentAssertions;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests;

public class SignupUserResponseDeserializationTests
{
    private static SignupUserResponse Parse(string json) =>
        JsonSerializer.Deserialize<SignupUserResponse>(json);

    [Theory]
    [InlineData("""{ "_id": "abc123" }""")]      // Standard connection
    [InlineData("""{ "id": "abc123" }""")]       // Custom connection
    [InlineData("""{ "user_id": "abc123" }""")]  // Custom connection external
    public void Resolves_Id_from_each_server_field(string json)
    {
        Parse(json).Id.Should().Be("abc123");
    }

    [Fact]
    public void Id_prefers_underscore_id_over_aliases()
    {
        var response = Parse("""{ "_id": "primary", "id": "secondary", "user_id": "tertiary" }""");

        response.Id.Should().Be("primary");
    }

    [Fact]
    public void Id_falls_back_to_id_when_underscore_id_absent()
    {
        var response = Parse("""{ "id": "secondary", "user_id": "tertiary" }""");

        response.Id.Should().Be("secondary");
    }

    [Fact]
    public void Id_is_null_when_no_identifier_present()
    {
        Parse("""{ "email": "user@example.com" }""").Id.Should().BeNull();
    }

    [Fact]
    public void Maps_all_fields_through_the_converter()
    {
        var response = Parse("""
        {
          "_id": "abc123", "email": "user@example.com", "email_verified": true,
          "username": "bsmith", "given_name": "Bob", "family_name": "Smith",
          "name": "Bob Smith", "nickname": "Bob", "picture": "https://example.com/p.png",
          "phone_number": "+15551234", "user_metadata": { "plan": "gold" }
        }
        """);

        response.Id.Should().Be("abc123");
        response.Email.Should().Be("user@example.com");
        response.EmailVerified.Should().BeTrue();
        response.Username.Should().Be("bsmith");
        response.GivenName.Should().Be("Bob");
        response.FamilyName.Should().Be("Smith");
        response.Name.Should().Be("Bob Smith");
        response.Nickname.Should().Be("Bob");
        response.Picture.Should().Be(new System.Uri("https://example.com/p.png"));
        response.PhoneNumber.Should().Be("+15551234");
        ((string)response.UserMetadata.GetProperty("plan").GetString()).Should().Be("gold");
    }
}
