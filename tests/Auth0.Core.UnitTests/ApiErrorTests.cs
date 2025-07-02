using System.Net.Http;
using System.Threading.Tasks;

using FluentAssertions;
using Xunit;

using Auth0.Core.Exceptions;

namespace Auth0.Core.UnitTests;

public class ApiErrorTests
{
    [Fact]
    public async Task ParseFromHttpResponseMessage_WithNullResponse_ReturnsNull()
    {
        var result = await ApiError.Parse((HttpResponseMessage?)null);

        result.Should().BeNull();
    }

    [Fact]
    public async Task ParseFromHttpResponseMessage_WithNullContent_ReturnsNull()
    {
        var response = new HttpResponseMessage();
        response.Content = null;

        var result = await ApiError.Parse(response);

        result.Should().BeNull();
    }

    [Fact]
    public async Task ParseFromHttpResponseMessage_WithEmptyContent_ReturnsNull()
    {
        var response = new HttpResponseMessage();
        response.Content = new StringContent("");

        var result = await ApiError.Parse(response);

        result.Should().BeNull();
    }

    [Fact]
    public async Task ParseFromHttpResponseMessage_WithValidJsonContent_ReturnsApiError()
    {
        var json = """{"error":"invalid_request","errorCode":"E001","message":"Invalid parameter"}""";
        var response = new HttpResponseMessage();
        response.Content = new StringContent(json);

        var result = await ApiError.Parse(response);

        result.Should().NotBeNull();
        result.Error.Should().Be("invalid_request");
        result.ErrorCode.Should().Be("E001");
        result.Message.Should().Be("Invalid parameter");
    }

    [Fact]
    public void ParseFromString_WithValidJson_ReturnsApiError()
    {
        var json = """{"error":"unauthorized","message":"Access denied","extraData":{"mfa_required":"true"}}""";

        var result = ApiError.Parse(json);

        result.Should().NotBeNull();
        result.Error.Should().Be("unauthorized");
        result.Message.Should().Be("Access denied");
        result.ExtraData.Should().ContainKey("mfa_required").WhichValue.Should().Be("true");
    }

    [Fact]
    public void ParseFromString_WithPartialJson_ReturnsApiErrorWithAvailableFields()
    {
        var json = """{"error":"bad_request"}""";

        var result = ApiError.Parse(json);

        result.Should().NotBeNull();
        result.Error.Should().Be("bad_request");
        result.Message.Should().BeNull();
        result.ExtraData.Should().BeEmpty();
    }

    [Fact]
    public void ParseFromString_WithExtraData_ReturnsApiErrorWithExtraData()
    {
        var json = """{"error":"unauthorized","message":"Access denied","extraData":{"mfa_required":"true","retry":"false"}}""";

        var result = ApiError.Parse(json);

        result.Should().NotBeNull();
        result.Error.Should().Be("unauthorized");
        result.Message.Should().Be("Access denied");
        result.ExtraData.Should().ContainKey("mfa_required").WhichValue.Should().Be("true");
        result.ExtraData.Should().ContainKey("retry").WhichValue.Should().Be("false");
    }
    [Fact]
    public void ParseFromString_WithInvalidJson_ReturnsApiErrorWithContentAsErrorAndMessage()
    {
        var invalidJson = "This is not JSON";

        var result = ApiError.Parse(invalidJson);

        result.Should().NotBeNull();
        result.Error.Should().Be(invalidJson);
        result.Message.Should().Be(invalidJson);
        result.ErrorCode.Should().BeNull();
        result.ExtraData.Should().BeEmpty();
    }

    [Fact]
    public void ParseFromString_WithEmptyString_ReturnsNull()
    {
        var result = ApiError.Parse("");

        result.Should().BeNull();
    }

    [Fact]
    public void ParseFromString_WithNullString_ReturnsNull()
    {
        var result = ApiError.Parse(((string)null)!);

        result.Should().BeNull();
    }

    [Fact]
    public void ParseFromString_WithWhitespaceString_ReturnsNull()
    {
        var result = ApiError.Parse("   ");

        result.Should().BeNull();
    }

    [Fact]
    public void ExtraData_DefaultValue_IsEmptyDictionary()
    {
        var apiError = new ApiError();

        apiError.ExtraData.Should().NotBeNull();
        apiError.ExtraData.Should().BeEmpty();
    }
}