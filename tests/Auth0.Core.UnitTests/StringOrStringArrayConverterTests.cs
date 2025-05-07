using System.IO;
using Auth0.Core.Serialization;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace Auth0.Core.UnitTests;

public class StringOrStringArrayJsonConverterTests
{
    internal class StringOrStringArrayJsonConverterData
    {
        [JsonProperty("value")]
        [JsonConverter(typeof(StringOrStringArrayJsonConverter))]
        public dynamic Value { get; set; }
    }
    
    [Fact]
    public void CanConvert_ShouldReturnTrue_ForAnyType()
    {
        // Act
        var converter = new StringOrStringArrayJsonConverter();
        var result = converter.CanConvert(typeof(object));

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ReadJson_ShouldDeserializeStringArray_WhenJsonIsArray()
    {
        // Arrange
        var json = "[\"value1\", \"value2\"]";
        var reader = new JsonTextReader(new StringReader(json));
        reader.Read();
        var converter = new StringOrStringArrayJsonConverter();

        // Act
        var result = converter.ReadJson(reader, typeof(string[]), null, new JsonSerializer());

        // Assert
        Assert.IsType<string[]>(result);
        Assert.Equal(new[] { "value1", "value2" }, result);
    }

    [Fact]
    public void ReadJson_ShouldDeserializeString_WhenJsonIsString()
    {
        // Arrange
        var json = "\"value\"";
        var reader = new JsonTextReader(new StringReader(json));
        reader.Read();
        var converter = new StringOrStringArrayJsonConverter();

        // Act
        var result = converter.ReadJson(reader, typeof(string), null, new JsonSerializer());

        // Assert
        Assert.IsType<string>(result);
        Assert.Equal("value", result);
    }

    [Fact]
    public void ReadJson_ShouldReturnNull_WhenJsonIsNotStringOrArray()
    {
        // Arrange
        var json = "123";
        var reader = new JsonTextReader(new StringReader(json));
        reader.Read();
        var converter = new StringOrStringArrayJsonConverter();

        // Act
        var result = converter.ReadJson(reader, typeof(object), null, new JsonSerializer());

        // Assert
        Assert.Null(result);
    }
    
    [Fact]
    public void Should_deserialize_string()
    {
        var content = "{ 'value': 'test' }";

        var parsed = JsonConvert.DeserializeObject<StringOrStringArrayJsonConverterData>(content);

        Assert.Equal("test", parsed.Value);
    }
        
    [Fact]
    public void Should_deserialize_object_as_string_array()
    {
        var content = "{ 'value': [\"value1\", \"value2\"] }";

        var parsed = JsonConvert.DeserializeObject<StringOrStringArrayJsonConverterData>(content);

        new[] { "value1", "value2" }.Should().BeEquivalentTo(parsed.Value);
    }
    
    [Fact]
    public void Should_deserialize_when_omitted()
    {
        var content = "{}";

        var parsed = JsonConvert.DeserializeObject<StringOrStringArrayJsonConverterData>(content);

        Assert.Null(parsed.Value);
    }
}
