using System.Collections;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Auth0.Core.UnitTests
{
    [TestFixture]
    public class ApiErrorDeserializationTests
    {
        [Test, TestCaseSource(typeof(ApiErrorDeserializationData), "TestCases")]
        public void Should_deserialize_all_error_strucutures_correctly(string content, ApiError expected)
        {
            var error = JsonConvert.DeserializeObject<ApiError>(content);

            error.ShouldBeEquivalentTo(expected);
        }
    }

    public static class ApiErrorDeserializationData
    {
        public static IEnumerable TestCases()
        {
            yield return new TestCaseData("{\"name\":\"Error\",\"code\":\"error_code\",\"description\":\"The Message\",\"statusCode\":400}", new ApiError
                {
                    StatusCode = 400,
                    Error = "Error",
                    ErrorCode = "error_code",
                    Message = "The Message"
                });
            yield return new TestCaseData("{\"error\": \"Error\",\"error_description\": \"The Message\"}", new ApiError
                 {
                     StatusCode = 0,
                     Error = "Error",
                     ErrorCode = null,
                     Message = "The Message"
                 });
            yield return new TestCaseData("{\"statusCode\": 400, \"error\": \"Error\", \"message\": \"The Message\", \"errorCode\": \"error_code\"}", new ApiError
                 {
                     StatusCode = 400,
                     Error = "Error",
                     ErrorCode = "error_code",
                     Message = "The Message"
                 });
        }
    }
}
