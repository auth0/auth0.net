using Auth0.Core.Serialization;
using Newtonsoft.Json;
using Xunit;

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
}
