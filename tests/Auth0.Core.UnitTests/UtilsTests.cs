using System;
using System.Collections.Generic;
using System.Text;
using Auth0.Core.Http;
using FluentAssertions;
using Xunit;

namespace Auth0.Core.UnitTests;

public class UtilsTests
{
    #region Base64Url

    [Fact]
    public void Base64UrlDecode_ValidBase64UrlString_ReturnsCorrectBytes()
    {
        var input = "SGVsbG8gV29ybGQ";
        var expected = Encoding.UTF8.GetBytes("Hello World");

        var result = Utils.Base64UrlDecode(input);

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Base64UrlDecode_StringWithUrlSafeCharacters_ReplacesAndDecodes()
    {
        var input = "SGVsbG8tV29ybGQ_";
        var expected = Encoding.UTF8.GetBytes("Hello-World?");

        var result = Utils.Base64UrlDecode(input);

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Base64UrlDecode_StringRequiringOnePadChar_AddsPaddingAndDecodes()
    {
        var input = "SGVsbG8";
        var expected = Encoding.UTF8.GetBytes("Hello");

        var result = Utils.Base64UrlDecode(input);

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Base64UrlDecode_StringRequiringTwoPadChars_AddsPaddingAndDecodes()
    {
        var input = "SGVsbA";
        var expected = Encoding.UTF8.GetBytes("Hell");

        var result = Utils.Base64UrlDecode(input);

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Base64UrlDecode_StringWithCorrectLength_NoExtraPaddingAdded()
    {
        var input = "SGVsbG8gV29ybGQ=";
        var expected = Encoding.UTF8.GetBytes("Hello World");

        var result = Utils.Base64UrlDecode(input);

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Base64UrlDecode_EmptyString_ReturnsEmptyByteArray()
    {
        var input = "";
        var expected = new byte[0];

        var result = Utils.Base64UrlDecode(input);

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Base64UrlDecode_SingleCharacter_ThrowsInvalidOperationException()
    {
        var input = "S";

        Assert.Throws<InvalidOperationException>(() => Utils.Base64UrlDecode(input));
    }

    [Fact]
    public void Base64UrlDecode_InvalidBase64String_ThrowsFormatException()
    {
        var input = "Invalid!@#$";

        Assert.Throws<FormatException>(() => Utils.Base64UrlDecode(input));
    }


    [Fact]
    public void Base64UrlEncode_WithEmptyByteArray_ReturnsEmptyString()
    {
        var input = new byte[0];
        var result = Utils.Base64UrlEncode(input);
        result.Should().Be(String.Empty);
    }

    [Fact]
    public void Base64UrlEncode_WithSingleByte_ReturnsCorrectBase64UrlString()
    {
        var input = new byte[] { 72 };
        var result = Utils.Base64UrlEncode(input);
        result.Should().Be("SA==");
    }

    [Fact]
    public void Base64UrlEncode_WithMultipleBytes_ReturnsCorrectBase64UrlString()
    {
        var input = Encoding.UTF8.GetBytes("Hello");
        var result = Utils.Base64UrlEncode(input);
        result.Should().Be("SGVsbG8=");
    }

    [Fact]
    public void Base64UrlEncode_WithBytesRequiringNoPadding_ReturnsStringWithoutPadding()
    {
        var input = Encoding.UTF8.GetBytes("Man");
        var result = Utils.Base64UrlEncode(input);
        result.Should().Be("TWFu");
    }

    [Fact]
    public void Base64UrlEncode_WithBytesRequiringOnePaddingChar_ReturnsStringWithOnePaddingChar()
    {
        var input = Encoding.UTF8.GetBytes("Ma");
        var result = Utils.Base64UrlEncode(input);
        result.Should().Be("TWE=");
    }

    [Fact]
    public void Base64UrlEncode_WithBytesRequiringTwoPaddingChars_ReturnsStringWithTwoPaddingChars()
    {
        var input = Encoding.UTF8.GetBytes("M");
        var result = Utils.Base64UrlEncode(input);
        result.Should().Be("TQ==");
    }

    [Fact]
    public void Base64UrlEncode_WithAllZeroBytes_ReturnsCorrectBase64UrlString()
    {
        var input = new byte[] { 0, 0, 0, 0 };
        var result = Utils.Base64UrlEncode(input);
        result.Should().Be("AAAAAA==");
    }

    [Fact]
    public void Base64UrlEncode_WithAllMaxValueBytes_ReturnsCorrectBase64UrlString()
    {
        var input = new byte[] { 255, 255, 255, 255 };
        var result = Utils.Base64UrlEncode(input);
        result.Should().Be("/////w==");
    }

    [Fact]
    public void Base64UrlEncode_WithLargeByteArray_ReturnsCorrectBase64UrlString()
    {
        var input = new byte[1000];
        for (int i = 0; i < input.Length; i++)
        {
            input[i] = (byte)(i % 256);
        }

        var result = Utils.Base64UrlEncode(input);
        result.Should().NotBeNullOrEmpty();
    }

    #endregion


    [Fact]
    public void AddQueryString_WithSingleParameter_ReturnsCorrectQueryString()
    {
        var queryStrings = new List<Tuple<string, string>>
        {
            new("key1", "value1")
        };

        var result = Utils.AddQueryString(queryStrings, false);

        result.Should().Be("key1=value1");
    }

    [Fact]
    public void AddQueryString_WithMultipleParameters_ReturnsCorrectQueryString()
    {
        var queryStrings = new List<Tuple<string, string>>
        {
            new("key1", "value1"),
            new("key2", "value2"),
            new("key3", "value3")
        };

        var result = Utils.AddQueryString(queryStrings, false);

        result.Should().Be("key1=value1&key2=value2&key3=value3");
    }

    [Fact]
    public void AddQueryString_WithSpecialCharacters_EscapesCorrectly()
    {
        var queryStrings = new List<Tuple<string, string>>
        {
            new("key with spaces", "value&with=special"),
            new("key+plus", "value%percent")
        };

        var result = Utils.AddQueryString(queryStrings, false);

        result.Should().Be("key%20with%20spaces=value%26with%3Dspecial&key%2Bplus=value%25percent");
    }

    [Fact]
    public void AddQueryString_WithNullValues_SkipsNullValues()
    {
        var queryStrings = new List<Tuple<string, string>>
        {
            new("key1", "value1"),
            new("key2", null),
            new("key3", "value3")
        };

        var result = Utils.AddQueryString(queryStrings, false);

        result.Should().Be("key1=value1&key3=value3");
    }

    [Fact]
    public void AddQueryString_WithNullValuesAndIncludeEmpty_IncludesKeysWithoutValues()
    {
        var queryStrings = new List<Tuple<string, string>>
        {
            new("key1", "value1"),
            new("key2", null),
            new("key3", "value3")
        };

        var result = Utils.AddQueryString(queryStrings, true);

        result.Should().Be("key1=value1&key2&key3=value3");
    }

    [Fact]
    public void AddQueryString_WithEmptyList_ReturnsEmptyString()
    {
        var queryStrings = new List<Tuple<string, string>>();

        var result = Utils.AddQueryString(queryStrings, false);

        result.Should().Be(string.Empty);
    }

    [Fact]
    public void AddQueryString_WithOnlyNullValues_ReturnsEmptyString()
    {
        var queryStrings = new List<Tuple<string, string>>
        {
            new("key1", null),
            new("key2", null)
        };

        var result = Utils.AddQueryString(queryStrings, false);

        result.Should().Be(string.Empty);
    }

    [Fact]
    public void AddQueryString_WithOnlyNullValuesAndIncludeEmpty_ReturnsKeysOnly()
    {
        var queryStrings = new List<Tuple<string, string>>
        {
            new("key1", null),
            new("key2", null)
        };

        var result = Utils.AddQueryString(queryStrings, true);

        result.Should().Be("key1&key2");
    }

    [Fact]
    public void AddQueryString_WithEmptyStringValues_IncludesEmptyValues()
    {
        var queryStrings = new List<Tuple<string, string>>
        {
            new("key1", ""),
            new("key2", "value2")
        };

        var result = Utils.AddQueryString(queryStrings, false);

        result.Should().Be("key1=&key2=value2");
    }

    [Fact]
    public void BuildUri_WithValidBaseUrlAndResource_ReturnsCorrectUri()
    {
        var result = Utils.BuildUri("https://example.com", "api/users", null, new Dictionary<string, string>());

        result.ToString().Should().Be("https://example.com/api/users");
    }

    [Fact]
    public void BuildUri_WithUrlSegments_ReplacesSegmentsInResource()
    {
        var urlSegments = new Dictionary<string, string> { { "id", "123" } };

        var result = Utils.BuildUri("https://example.com", "api/users/{id}", urlSegments,
            new Dictionary<string, string>());

        result.ToString().Should().Be("https://example.com/api/users/123");
    }

    [Fact]
    public void BuildUri_WithQueryStrings_AppendsQueryParameters()
    {
        var queryStrings = new Dictionary<string, string> { { "page", "1" }, { "size", "10" } };

        var result = Utils.BuildUri("https://example.com", "api/users", null, queryStrings);

        result.ToString().Should().Contain("page=1");
        result.ToString().Should().Contain("size=10");
        result.ToString().Should().StartWith("https://example.com/api/users?");
    }

    [Fact]
    public void BuildUri_WithExistingQueryStringInResource_AppendsWithAmpersand()
    {
        var queryStrings = new Dictionary<string, string> { { "filter", "active" } };

        var result = Utils.BuildUri("https://example.com", "api/users?sort=name", null, queryStrings);

        result.ToString().Should().Be("https://example.com/api/users?sort=name&filter=active");
    }

    [Fact]
    public void BuildUri_WithEmptyQueryStrings_ReturnsUriWithoutQueryString()
    {
        var result = Utils.BuildUri("https://example.com", "api/users", null, new Dictionary<string, string>());

        result.ToString().Should().Be("https://example.com/api/users");
    }

    [Fact]
    public void BuildUri_WithNullUrlSegments_ProcessesResourceWithoutReplacement()
    {
        var queryStrings = new Dictionary<string, string> { { "test", "value" } };

        var result = Utils.BuildUri("https://example.com", "api/users/{id}", null, queryStrings);

        result.ToString().Should().Be("https://example.com/api/users/{id}?test=value");
    }

    [Fact]
    public void BuildUri_WithMultipleUrlSegments_ReplacesAllSegments()
    {
        var urlSegments = new Dictionary<string, string> { { "userId", "123" }, { "postId", "456" } };
        var queryStrings = new Dictionary<string, string>();

        var result = Utils.BuildUri("https://example.com", "api/users/{userId}/posts/{postId}", urlSegments,
            queryStrings);

        result.ToString().Should().Be("https://example.com/api/users/123/posts/456");
    }

    [Fact]
    public void BuildUri_WithIncludeEmptyParametersTrue_IncludesEmptyQueryValues()
    {
        var queryStrings = new Dictionary<string, string> { { "param1", "value1" }, { "param2", null } };

        var result = Utils.BuildUri("https://example.com", "api/test", null, queryStrings, true);

        result.ToString().Should().Contain("param1=value1");
        result.ToString().Should().Contain("param2");
        result.ToString().Should().NotContain("param2=");
    }

    [Fact]
    public void BuildUri_WithIncludeEmptyParametersFalse_ExcludesEmptyQueryValues()
    {
        var queryStrings = new Dictionary<string, string> { { "param1", "value1" }, { "param2", null } };

        var result = Utils.BuildUri("https://example.com", "api/test", null, queryStrings, false);

        result.ToString().Should().Contain("param1=value1");
        result.ToString().Should().NotContain("param2");
    }

    [Fact]
    public void BuildUri_WithEmptyBaseUrl_ReturnsRelativeUri()
    {
        var result = Utils.BuildUri("", "api/users", null, new Dictionary<string, string>());

        result.ToString().Should().Be("api/users");
    }

    [Fact]
    public void BuildUri_WithSpecialCharactersInQueryValues_EscapesCharacters()
    {
        var queryStrings = new Dictionary<string, string> { { "search", "hello world" }, { "filter", "a&b" } };

        var result = Utils.BuildUri("https://example.com", "api/search", null, queryStrings);

        result.AbsoluteUri.Should().Contain("search=hello%20world");
        result.AbsoluteUri.Should().Contain("filter=a%26b");
    }

    [Fact]
    public void BuildUri_WithSpecialCharactersInUrlSegments_EscapesCharacters()
    {
        var urlSegments = new Dictionary<string, string> { { "id", "hello world" } };

        var result = Utils.BuildUri("https://example.com", "api/users/{id}", urlSegments,
            new Dictionary<string, string>());

        result.Should().Be(new Uri("https://example.com/api/users/hello%20world"));
    }

    [Fact]
    public void BuildUri_WithTrailingSlashInResource_RemovesTrailingSlash()
    {
        var result = Utils.BuildUri("https://example.com", "api/users/", null, new Dictionary<string, string>());

        result.ToString().Should().Be("https://example.com/api/users");
    }

    [Fact]
    public void BuildUri_WithNullValueInUrlSegments_ReplacesWithEmptyString()
    {
        var urlSegments = new Dictionary<string, string> { { "id", null } };

        var result = Utils.BuildUri("https://example.com", "api/users/{id}", urlSegments,
            new Dictionary<string, string>());

        result.AbsoluteUri.Should().Be("https://example.com/api/users");
    }

    [Fact]
    public void BuildUri_WithEmptyStringValues_HandlesCorrectly()
    {
        var queryStrings = new Dictionary<string, string> { { "param", "" } };

        var result = Utils.BuildUri("https://example.com", "api/test", null, queryStrings);

        result.ToString().Should().Be("https://example.com/api/test?param=");
    }


    [Fact]
    public void BuildUri_WithValidInputsAndTupleQueryStrings_ReturnsCorrectUri()
    {
        var baseUrl = "https://example.com";
        var resource = "/api/users";
        var urlSegments = new Dictionary<string, string> { { "id", "123" } };
        var queryStrings = new List<Tuple<string, string>>
        {
            new("param1", "value1"),
            new("param2", "value2")
        };

        var result = Utils.BuildUri(baseUrl, resource, urlSegments, queryStrings);

        result.ToString().Should().Be("https://example.com/api/users?param1=value1&param2=value2");
    }

    [Fact]
    public void BuildUri_WithEmptyQueryStringTuples_ReturnsUriWithoutQueryString()
    {
        var baseUrl = "https://example.com";
        var resource = "/api/users";
        var urlSegments = new Dictionary<string, string>();
        var queryStrings = new List<Tuple<string, string>>();

        var result = Utils.BuildUri(baseUrl, resource, urlSegments, queryStrings);

        result.ToString().Should().Be("https://example.com/api/users");
    }

    [Fact]
    public void BuildUri_WithNullQueryStringValueInTuple_ExcludesNullValue()
    {
        var baseUrl = "https://example.com";
        var resource = "/api/users";
        var urlSegments = new Dictionary<string, string>();
        var queryStrings = new List<Tuple<string, string>>
        {
            new("param1", "value1"),
            new("param2", null),
            new("param3", "value3")
        };

        var result = Utils.BuildUri(baseUrl, resource, urlSegments, queryStrings);

        result.ToString().Should().Be("https://example.com/api/users?param1=value1&param3=value3");
    }

    [Fact]
    public void BuildUri_WithNullQueryStringValueAndIncludeEmptyParametersTrue_IncludesParameterWithoutValue()
    {
        var baseUrl = "https://example.com";
        var resource = "/api/users";
        var urlSegments = new Dictionary<string, string>();
        var queryStrings = new List<Tuple<string, string>>
        {
            new("param1", "value1"),
            new("param2", null)
        };

        var result = Utils.BuildUri(baseUrl, resource, urlSegments, queryStrings, true);

        result.ToString().Should().Be("https://example.com/api/users?param1=value1&param2");
    }

    [Fact]
    public void BuildUri_WithUrlSegmentsAndTupleQueryStrings_ReplacesSegmentsAndAddsQueryString()
    {
        var baseUrl = "https://example.com";
        var resource = "/api/users/{id}";
        var urlSegments = new Dictionary<string, string> { { "id", "123" } };
        var queryStrings = new List<Tuple<string, string>>
        {
            new("filter", "active")
        };

        var result = Utils.BuildUri(baseUrl, resource, urlSegments, queryStrings);

        result.ToString().Should().Be("https://example.com/api/users/123?filter=active");
    }

    [Fact]
    public void BuildUri_WithResourceContainingQueryStringAndTupleQueryStrings_AppendsWithAmpersand()
    {
        var baseUrl = "https://example.com";
        var resource = "/api/users?existing=param";
        var urlSegments = new Dictionary<string, string>();
        var queryStrings = new List<Tuple<string, string>>
        {
            new("new", "param")
        };

        var result = Utils.BuildUri(baseUrl, resource, urlSegments, queryStrings);

        result.ToString().Should().Be("https://example.com/api/users?existing=param&new=param");
    }

    [Fact]
    public void BuildUri_WithSpecialCharactersInTupleQueryStrings_EscapesCharacters()
    {
        var baseUrl = "https://example.com";
        var resource = "/api/users";
        var urlSegments = new Dictionary<string, string>();
        var queryStrings = new List<Tuple<string, string>>
        {
            new("param with spaces", "value&with=special")
        };

        var result = Utils.BuildUri(baseUrl, resource, urlSegments, queryStrings);

        result.AbsoluteUri.Should().Be("https://example.com/api/users?param%20with%20spaces=value%26with%3Dspecial");
    }

    [Fact]
    public void BuildUri_WithNullUrlSegmentsAndTupleQueryStrings_ProcessesSuccessfully()
    {
        var baseUrl = "https://example.com";
        var resource = "/api/users";
        Dictionary<string, string>? urlSegments = null;
        var queryStrings = new List<Tuple<string, string>>
        {
            new("param", "value")
        };

        var result = Utils.BuildUri(baseUrl, resource, urlSegments, queryStrings);

        result.ToString().Should().Be("https://example.com/api/users?param=value");
    }
}