using System.Collections;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;
using System.Collections.Generic;

namespace Auth0.Core.UnitTests
{
    public class ApiErrorDeserializationTests
    {
        [Theory]
        [ClassData(typeof(ApiErrorDeserializationData))]
        public void Should_deserialize_all_error_strucutures_correctly(string content, ApiError expected)
        {
            var error = JsonConvert.DeserializeObject<ApiError>(content);

            error.Should().BeEquivalentTo(expected);
        }
    }

    public class ApiErrorDeserializationData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "{\"name\":\"Error\",\"code\":\"error_code\",\"description\":\"The Message\",\"statusCode\":400}", new ApiError
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
            yield return new object[] { "{\"statusCode\": 400, \"error\": \"Error\", \"message\": \"The Message\", \"errorCode\": \"error_code\"}", new ApiError
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
