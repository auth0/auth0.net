using Auth0.Core.Exceptions;
using FluentAssertions;
using Xunit;

namespace Auth0.Core.UnitTests;

public class ApiErrorDeserializationTests
{
    [Fact]
    public void Should_deserialize_extra_properties_like_mfa_response()
    {
        var content =
            """{"error": "mfa_required", "error_description": "Multifactor authentication required", "mfa_token": "2x4b-r2d2-c3po-bb8-ig88"}""";

        var parsed = ApiError.Parse(content);

        parsed.Error.Should().Be("mfa_required");
        parsed.Message.Should().Be("Multifactor authentication required");
        parsed.ExtraData.Should().ContainKey("mfa_token")
            .WhichValue.Should().Be("2x4b-r2d2-c3po-bb8-ig88");
    }

    [Fact]
    public void Maps_camelcase_errorCode_alias_to_error_code()
    {
        var parsed = ApiError.Parse(
            """{"error": "Error", "message": "The Message", "errorCode": "error_code"}""");

        parsed.Error.Should().Be("Error");
        parsed.Message.Should().Be("The Message");
        parsed.ErrorCode.Should().Be("error_code");
    }

    [Fact]
    public void Maps_aliased_names_to_canonical_properties()
    {
        var parsed = ApiError.Parse(
            """{"code": "test_code", "name": "test_error", "description": "test_message"}""");

        parsed.ErrorCode.Should().Be("test_code");
        parsed.Error.Should().Be("test_error");
        parsed.Message.Should().Be("test_message");
    }

    [Fact]
    public void Maps_error_description_to_message()
    {
        var parsed = ApiError.Parse("""{"error_description": "test_description"}""");

        parsed.Message.Should().Be("test_description");
    }

    [Fact]
    public void Matches_keys_case_insensitively()
    {
        var parsed = ApiError.Parse("""{"ERRORCODE": "test_code", "ERROR": "test_error"}""");

        parsed.ErrorCode.Should().Be("test_code");
        parsed.Error.Should().Be("test_error");
    }

    [Fact]
    public void Empty_json_yields_all_null_fields()
    {
        var parsed = ApiError.Parse("{}");

        parsed.ErrorCode.Should().BeNull();
        parsed.Error.Should().BeNull();
        parsed.Message.Should().BeNull();
        parsed.ExtraData.Should().BeEmpty();
    }

    [Fact]
    public void Null_mapped_field_stays_null()
    {
        var parsed = ApiError.Parse("""{"code": null}""");

        parsed.ErrorCode.Should().BeNull();
    }

    [Fact]
    public void Non_string_mapped_field_kept_as_raw_text()
    {
        var parsed = ApiError.Parse("""{"code": 123}""");

        parsed.ErrorCode.Should().Be("123");
    }

    [Fact]
    public void Null_unmapped_field_becomes_empty_string()
    {
        var parsed = ApiError.Parse("""{"custom": null}""");

        parsed.ExtraData.Should().ContainKey("custom").WhichValue.Should().Be("");
    }
}
