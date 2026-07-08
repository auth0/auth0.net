using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.Core.Serialization;
using FluentAssertions;
using Xunit;

namespace Auth0.Core.UnitTests;

public class StringOrStringArrayJsonConverterTests
{
    private class Data
    {
        [JsonPropertyName("value")]
        [JsonConverter(typeof(StringOrStringArrayJsonConverter))]
        public object Value { get; set; }
    }

    private static Data Parse(string json) =>
        JsonSerializer.Deserialize<Data>(json, Auth0JsonSerializerOptions.Default);

    [Fact]
    public void Deserializes_single_string()
    {
        Parse("""{ "value": "test" }""").Value.Should().Be("test");
    }

    [Fact]
    public void Deserializes_array_as_string_array()
    {
        var value = Parse("""{ "value": ["value1", "value2"] }""").Value;
        value.Should().BeOfType<string[]>();
        ((string[])value).Should().Equal("value1", "value2");
    }

    [Fact]
    public void Returns_null_for_non_string_non_array()
    {
        Parse("""{ "value": 123 }""").Value.Should().BeNull();
    }

    [Fact]
    public void Returns_null_when_omitted()
    {
        Parse("{}").Value.Should().BeNull();
    }

    [Fact]
    public void Preserves_null_elements_in_array()
    {
        var value = Parse("""{ "value": ["a", null, "b"] }""").Value;
        value.Should().BeOfType<string[]>();
        ((string[])value).Should().Equal("a", null, "b");
    }
}
