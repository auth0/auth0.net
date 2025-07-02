using System;
using System.IO;
using Newtonsoft.Json;
using Xunit;
using FluentAssertions;
using Auth0.Core.Serialization;

namespace Auth0.Core.UnitTests;

public class StringOrObjectAsStringConverterTests
{
    internal class StringOrObjectAsStringConverterData
    {
        [JsonProperty("value")]
        [JsonConverter(typeof(StringOrObjectAsStringConverter))]
        public string Value { get; set; }
    }

    [Fact]
    public void Should_deserialize_string()
    {
        var content = "{ 'value': 'test' }";

        var parsed = JsonConvert.DeserializeObject<StringOrObjectAsStringConverterData>(content);

        Assert.Equal("test", parsed.Value);
    }

    [Fact]
    public void Should_deserialize_object_as_string()
    {
        var content = "{ 'value': { 'innerValue': 'test' } }";

        var parsed = JsonConvert.DeserializeObject<StringOrObjectAsStringConverterData>(content);

        Assert.Equal("{\n  \"innerValue\": \"test\"\n}", parsed.Value);
    }

    [Fact]
    public void Should_deserialize_when_omitted()
    {
        var content = "{}";

        var parsed = JsonConvert.DeserializeObject<StringOrObjectAsStringConverterData>(content);

        Assert.Null(parsed.Value);
    }

    [Fact]
    public void ReadJson_WithStringToken_ReturnsStringValue()
    {
        var converter = new StringOrObjectAsStringConverter();
        var json = "\"test string\"";
        var reader = new JsonTextReader(new StringReader(json));
        reader.Read();

        var result = converter.ReadJson(reader, typeof(string), null, new JsonSerializer());

        result.Should().Be("test string");
    }

    [Fact]
    public void ReadJson_WithObjectToken_ReturnsJsonObjectAsString()
    {
        var converter = new StringOrObjectAsStringConverter();
        var json = "{\"key\":\"value\",\"number\":42}";
        var reader = new JsonTextReader(new StringReader(json));
        reader.Read();

        var result = converter.ReadJson(reader, typeof(string), null, new JsonSerializer());

        result.Should().NotBeNull();
        result.ToString().Should().Contain("key");
        result.ToString().Should().Contain("value");
        result.ToString().Should().Contain("number");
        result.ToString().Should().Contain("42");
    }

    [Fact]
    public void ReadJson_WithEmptyStringToken_ReturnsEmptyString()
    {
        var converter = new StringOrObjectAsStringConverter();
        var json = "\"\"";
        var reader = new JsonTextReader(new StringReader(json));
        reader.Read();

        var result = converter.ReadJson(reader, typeof(string), null, new JsonSerializer());

        result.Should().Be("");
    }

    [Fact]
    public void ReadJson_WithNullStringToken_ReturnsEmptyString()
    {
        var converter = new StringOrObjectAsStringConverter();
        var json = "null";
        var reader = new JsonTextReader(new StringReader(json));
        reader.Read();

        var result = converter.ReadJson(reader, typeof(string), null, new JsonSerializer());

        result.Should().Be("");
    }

    [Fact]
    public void ReadJson_WithEmptyObjectToken_ReturnsEmptyObjectString()
    {
        var converter = new StringOrObjectAsStringConverter();
        var json = "{}";
        var reader = new JsonTextReader(new StringReader(json));
        reader.Read();

        var result = converter.ReadJson(reader, typeof(string), null, new JsonSerializer());

        result.Should().NotBeNull();
        result.ToString().Should().Be("{}");
    }

    [Fact]
    public void ReadJson_WithNestedObjectToken_ReturnsNestedObjectAsString()
    {
        var converter = new StringOrObjectAsStringConverter();
        var json = "{\"outer\":{\"inner\":\"value\"}}";
        var reader = new JsonTextReader(new StringReader(json));
        reader.Read();

        var result = converter.ReadJson(reader, typeof(string), null, new JsonSerializer());

        result.Should().NotBeNull();
        result.ToString().Should().Contain("outer");
        result.ToString().Should().Contain("inner");
        result.ToString().Should().Contain("value");
    }

    [Fact]
    public void CanConvert_WithAnyType_ReturnsTrue()
    {
        var converter = new StringOrObjectAsStringConverter();

        converter.CanConvert(typeof(string)).Should().BeTrue();
        converter.CanConvert(typeof(object)).Should().BeTrue();
        converter.CanConvert(typeof(int)).Should().BeTrue();
    }

    [Fact]
    public void CanWrite_ReturnsAlwaysFalse()
    {
        var converter = new StringOrObjectAsStringConverter();

        converter.CanWrite.Should().BeFalse();
    }

    [Fact]
    public void WriteJson_ThrowsNotImplementedException()
    {
        var converter = new StringOrObjectAsStringConverter();
        var writer = new JsonTextWriter(new StringWriter());

        var action = () => converter.WriteJson(writer, "test", new JsonSerializer());

        action.Should().Throw<NotImplementedException>();
    }
}