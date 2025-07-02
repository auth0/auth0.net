using System;
using System.Collections;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;
using System.Collections.Generic;
using System.IO;
using Auth0.Core.Exceptions;
using Auth0.Core.Serialization;

namespace Auth0.Core.UnitTests;

public class ApiErrorDeserializationTests
{
    [Fact]
    public void Should_deserialize_extra_properties_like_mfa_response()
    {
        var content =
            "{\"error\": \"mfa_required\", \"error_description\": \"Multifactor authentication required\", \"mfa_token\": \"2x4b-r2d2-c3po-bb8-ig88\"}";

        var parsed = ApiError.Parse(content);

        Assert.Equal("mfa_required", parsed.Error);
        Assert.Equal("Multifactor authentication required", parsed.Message);
        Assert.Contains(parsed.ExtraData,
            (d) => d.Key == "mfa_token" && string.Equals(d.Value, "2x4b-r2d2-c3po-bb8-ig88"));
    }

    [Theory]
    [ClassData(typeof(ApiErrorDeserializationData))]
    public void Should_deserialize_all_error_structures_correctly(string content, ApiError expected)
    {
        var error = JsonConvert.DeserializeObject<ApiError>(content);

        error.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void CanConvert_WithClassType_ReturnsTrue()
    {
        var converter = new ApiErrorConverter();
        var result = converter.CanConvert(typeof(string));
        result.Should().BeTrue();
    }

    [Fact]
    public void CanConvert_WithValueType_ReturnsFalse()
    {
        var converter = new ApiErrorConverter();
        var result = converter.CanConvert(typeof(int));
        result.Should().BeFalse();
    }

    [Fact]
    public void CanWrite_ReturnsFalse()
    {
        var converter = new ApiErrorConverter();
        converter.CanWrite.Should().BeFalse();
    }

    [Fact]
    public void WriteJson_ThrowsNotImplementedException()
    {
        var converter = new ApiErrorConverter();
        var writer = new JsonTextWriter(new StringWriter());

        Action act = () => converter.WriteJson(writer, new object(), new JsonSerializer());

        act.Should().Throw<NotImplementedException>();
    }

    [Fact]
    public void ReadJson_WithMappedPropertyNames_MapsToCorrectProperties()
    {
        var converter = new ApiErrorConverter();
        var json = """{"code": "test_code", "name": "test_error", "description": "test_message"}""";
        var reader = new JsonTextReader(new StringReader(json));
        var serializer = new JsonSerializer();

        var result = converter.ReadJson(reader, typeof(TestApiError), null, serializer) as TestApiError;

        result.Should().NotBeNull();
        result.ErrorCode.Should().Be("test_code");
        result.Error.Should().Be("test_error");
        result.Message.Should().Be("test_message");
    }

    [Fact]
    public void ReadJson_WithErrorDescriptionProperty_MapsToMessage()
    {
        var converter = new ApiErrorConverter();
        var json = """{"error_description": "test_description"}""";
        var reader = new JsonTextReader(new StringReader(json));
        var serializer = new JsonSerializer();

        var result = converter.ReadJson(reader, typeof(TestApiError), null, serializer) as TestApiError;

        result.Should().NotBeNull();
        result.Message.Should().Be("test_description");
    }

    [Fact]
    public void ReadJson_WithUnmappedProperties_SetsPropertiesDirectly()
    {
        var converter = new ApiErrorConverter();
        var json = """{"customProperty": "custom_value"}""";
        var reader = new JsonTextReader(new StringReader(json));
        var serializer = new JsonSerializer();

        var result =
            converter.ReadJson(reader, typeof(TestApiErrorWithCustomProperty), null, serializer) as
                TestApiErrorWithCustomProperty;

        result.Should().NotBeNull();
        result.CustomProperty.Should().Be("custom_value");
    }

    [Fact]
    public void ReadJson_WithUnmappedPropertiesAndExtraDataDictionary_AddsToExtraData()
    {
        var converter = new ApiErrorConverter();
        var json = """{"unmappedProperty": "unmapped_value"}""";
        var reader = new JsonTextReader(new StringReader(json));
        var serializer = new JsonSerializer();

        var result =
            converter.ReadJson(reader, typeof(TestApiErrorWithExtraData), null,
                serializer) as TestApiErrorWithExtraData;

        result.Should().NotBeNull();
        result.ExtraData.Should().ContainKey("unmappedProperty");
        result.ExtraData["unmappedProperty"].Should().Be("unmapped_value");
    }

    [Fact]
    public void ReadJson_WithCaseInsensitivePropertyNames_MapsCorrectly()
    {
        var converter = new ApiErrorConverter();
        var json = """{"ERRORCODE": "test_code", "ERROR": "test_error"}""";
        var reader = new JsonTextReader(new StringReader(json));
        var serializer = new JsonSerializer();

        var result = converter.ReadJson(reader, typeof(TestApiError), null, serializer) as TestApiError;

        result.Should().NotBeNull();
        result.ErrorCode.Should().Be("test_code");
        result.Error.Should().Be("test_error");
    }

    [Fact]
    public void ReadJson_WithEmptyJson_ReturnsInstanceWithDefaultValues()
    {
        var converter = new ApiErrorConverter();
        var json = """{}""";
        var reader = new JsonTextReader(new StringReader(json));
        var serializer = new JsonSerializer();

        var result = converter.ReadJson(reader, typeof(TestApiError), null, serializer) as TestApiError;

        result.Should().NotBeNull();
        result.ErrorCode.Should().BeNull();
        result.Error.Should().BeNull();
        result.Message.Should().BeNull();
    }

    [Fact]
    public void ReadJson_WithReadOnlyProperties_IgnoresReadOnlyProperties()
    {
        var converter = new ApiErrorConverter();
        var json = """{"readOnlyProperty": "should_be_ignored", "errorCode": "test_code"}""";
        var reader = new JsonTextReader(new StringReader(json));
        var serializer = new JsonSerializer();

        var result =
            converter.ReadJson(reader, typeof(TestApiErrorWithReadOnlyProperty), null, serializer) as
                TestApiErrorWithReadOnlyProperty;

        result.Should().NotBeNull();
        result.ErrorCode.Should().Be("test_code");
        result.ReadOnlyProperty.Should().Be("default_value");
    }
}

public class ApiErrorDeserializationData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            "{\"name\":\"Error\",\"code\":\"error_code\",\"description\":\"The Message\"}", new ApiError
            {
                Error = "Error",
                ErrorCode = "error_code",
                Message = "The Message"
            }
        };
        yield return new object[]
        {
            "{\"error\": \"Error\",\"error_description\": \"The Message\"}", new ApiError
            {
                Error = "Error",
                ErrorCode = null,
                Message = "The Message"
            }
        };
        yield return new object[]
        {
            "{\"error\": \"Error\", \"message\": \"The Message\", \"errorCode\": \"error_code\"}", new ApiError
            {
                Error = "Error",
                ErrorCode = "error_code",
                Message = "The Message"
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class TestApiError
{
    public string ErrorCode { get; set; }
    public string Error { get; set; }
    public string Message { get; set; }
}

public class TestApiErrorWithCustomProperty
{
    public string CustomProperty { get; set; }
}

public class TestApiErrorWithExtraData
{
    public Dictionary<string, string> ExtraData { get; set; } = new();
}

public class TestApiErrorWithReadOnlyProperty
{
    public string ErrorCode { get; set; }
    public string ReadOnlyProperty { get; } = "default_value";
}