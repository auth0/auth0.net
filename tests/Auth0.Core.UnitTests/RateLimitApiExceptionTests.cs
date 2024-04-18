using System;
using System.Net;
using System.Net.Http;
using Auth0.Core.Exceptions;
using FluentAssertions;
using Xunit;

namespace Auth0.Core.UnitTests
{
	public class RateLimitApiExceptionTests
	{
		[Fact]
		public void Should_deserialize_api_error_like_brute_force_response_from_auth_api()
		{
			var response = CreateResponseMessage(
				@"{ 
						""error"": ""too_many_attempts"", 
						""error_description"": ""Your account has been blocked after multiple consecutive login attempts. We've sent you a notification via your preferred contact method with instructions on how to unblock it.""
					}");

			var actual = RateLimitApiException.CreateAsync(response).GetAwaiter().GetResult();

			actual.ApiError.Error.Should().BeEquivalentTo("too_many_attempts");
			actual.ApiError.Message.Should().BeEquivalentTo("Your account has been blocked after multiple consecutive login attempts. We've sent you a notification via your preferred contact method with instructions on how to unblock it.");
		}

		[Fact]
		public void Should_deserialize_rate_limit()
		{
			var response = CreateResponseMessage(string.Empty);

			var actual = RateLimitApiException.CreateAsync(response).GetAwaiter().GetResult();

			actual.RateLimit.Should().BeEquivalentTo(new RateLimit
			{
				Limit = 10,
				Remaining = 5,
				Reset = new DateTimeOffset(2020, 3, 31, 22, 38, 58, TimeSpan.Zero)
			});
		}

		private static HttpResponseMessage CreateResponseMessage(string json)
		{
			var responseMessage = new HttpResponseMessage
			{
				StatusCode = HttpStatusCode.TooManyRequests,
				Content = new StringContent(json)
			};

			responseMessage.Headers.Add("x-ratelimit-limit", "10");
			responseMessage.Headers.Add("x-ratelimit-remaining", "5");
			responseMessage.Headers.Add("x-ratelimit-reset", "1585694338");

			return responseMessage;
		}
	}
}

