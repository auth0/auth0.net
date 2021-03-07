using System.Collections;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;
using System.Collections.Generic;
using Auth0.Core.Exceptions;

namespace Auth0.Core.UnitTests
{
    public class ApiErrorDeserializationTests
    {
        [Fact]
        public void Should_deserialize_extra_properties_like_mfa_response()
        {
            var content = "{\"error\": \"mfa_required\", \"error_description\": \"Multifactor authentication required\", \"mfa_token\": \"2x4b-r2d2-c3po-bb8-ig88\"}";

            var parsed = ApiError.Parse(content);

            Assert.Equal("mfa_required", parsed.Error);
            Assert.Equal("Multifactor authentication required", parsed.Message);
            Assert.Contains(parsed.ExtraData, (d) => d.Key == "mfa_token" && string.Equals(d.Value, "2x4b-r2d2-c3po-bb8-ig88"));
        }

        [Theory]
        [ClassData(typeof(ApiErrorDeserializationData))]
        public void Should_deserialize_all_error_structures_correctly(string content, ApiError expected)
        {
            var error = JsonConvert.DeserializeObject<ApiError>(content);

            error.Should().BeEquivalentTo(expected);
        }
    }

    public class ApiErrorDeserializationData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "{\"name\":\"Error\",\"code\":\"error_code\",\"description\":\"The Message\"}", new ApiError
                {
                    Error = "Error",
                    ErrorCode = "error_code",
                    Message = "The Message"
                } };
            yield return new object[] { "{\"error\": \"Error\",\"error_description\": \"The Message\"}", new ApiError
                 {
                     Error = "Error",
                     ErrorCode = null,
                     Message = "The Message"
                 } };
            yield return new object[] { "{\"error\": \"Error\", \"message\": \"The Message\", \"errorCode\": \"error_code\"}", new ApiError
                 {
                     Error = "Error",
                     ErrorCode = "error_code",
                     Message = "The Message"
                 } };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
