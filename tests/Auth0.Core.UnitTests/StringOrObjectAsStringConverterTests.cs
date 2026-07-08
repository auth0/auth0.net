using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.Core.Serialization;
using FluentAssertions;
using Xunit;

namespace Auth0.Core.UnitTests;

public class StringOrObjectAsStringConverterTests
{
    private class Data
    {
        [JsonPropertyName("value")]
        [JsonConverter(typeof(StringOrObjectAsStringConverter))]
        public string Value { get; set; }
    }

    private static Data Parse(string json) =>
        JsonSerializer.Deserialize<Data>(json, Auth0JsonSerializerOptions.Default);

    [Fact]
    public void Deserializes_string()
    {
        Parse("""{ "value": "test" }""").Value.Should().Be("test");
    }

    [Fact]
    public void Deserializes_object_as_compact_string()
    {
        // Intentional change from Newtonsoft: compact JSON, not pretty-printed.
        Parse("""{ "value": { "innerValue": "test" } }""")
            .Value.Should().Be("""{"innerValue":"test"}""");
    }

    [Fact]
    public void Deserializes_array_as_compact_string()
    {
        Parse("""{ "value": [{"type":"x"}] }""")
            .Value.Should().Be("""[{"type":"x"}]""");
    }

    [Fact]
    public void Deserializes_empty_object()
    {
        Parse("""{ "value": {} }""").Value.Should().Be("{}");
    }

    [Fact]
    public void Deserializes_empty_array()
    {
        Parse("""{ "value": [] }""").Value.Should().Be("[]");
    }

    [Fact]
    public void Returns_null_when_omitted()
    {
        Parse("{}").Value.Should().BeNull();
    }
}
