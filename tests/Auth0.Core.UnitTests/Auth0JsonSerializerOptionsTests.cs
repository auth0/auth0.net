using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.Core.Serialization;
using FluentAssertions;
using Xunit;

namespace Auth0.Core.UnitTests;

public class Auth0JsonSerializerOptionsTests
{
    private class Sample
    {
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
    }

    [Fact]
    public void Omits_null_properties_on_serialize()
    {
        var json = JsonSerializer.Serialize(
            new Sample { FirstName = "Bob", LastName = null },
            Auth0JsonSerializerOptions.Default);

        json.Should().Contain("first_name");
        json.Should().NotContain("last_name");
    }

    [Fact]
    public void Matches_property_names_case_insensitively_on_deserialize()
    {
        var result = JsonSerializer.Deserialize<Sample>(
            """{"FIRST_NAME":"Bob"}""", Auth0JsonSerializerOptions.Default);

        result.FirstName.Should().Be("Bob");
    }
}
