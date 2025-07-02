using System;
using System.Net;
using System.Net.Http;

using FluentAssertions;
using Xunit;

using Auth0.Core.Exceptions;

namespace Auth0.Core.UnitTests;

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
        actual.ApiError.Message.Should()
            .BeEquivalentTo(
                "Your account has been blocked after multiple consecutive login attempts. We've sent you a notification via your preferred contact method with instructions on how to unblock it.");
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
            Reset = new DateTimeOffset(2020, 3, 31, 22, 38, 58, TimeSpan.Zero),
            RetryAfter = 22374,
            ClientQuotaLimit = new ClientQuotaLimit()
            {
                PerDay = new QuotaLimit()
                {
                    Quota = 100,
                    Remaining = 99,
                    ResetAfter = 22374
                },
                PerHour = new QuotaLimit()
                {
                    Quota = 10,
                    Remaining = 9,
                    ResetAfter = 774
                }
            }
        });
    }


    [Fact]
    public void DefaultConstructor_CreatesInstanceSuccessfully()
    {
        var exception = new RateLimitApiException();

        exception.Should().NotBeNull();
        exception.Message.Should().NotBeNullOrEmpty();
        exception.RateLimit.Should().BeNull();
        exception.ApiError.Should().BeNull();
    }

    [Fact]
    public void MessageConstructor_WithValidMessage_SetsMessage()
    {
        var message = "Test rate limit message";

        var exception = new RateLimitApiException(message);

        exception.Message.Should().Be(message);
        exception.RateLimit.Should().BeNull();
        exception.ApiError.Should().BeNull();
    }

    [Fact]
    public void MessageAndInnerExceptionConstructor_WithValidParameters_SetsProperties()
    {
        var message = "Rate limit exceeded";
        var innerException = new InvalidOperationException("Inner error");

        var exception = new RateLimitApiException(message, innerException);

        exception.Message.Should().Be(message);
        exception.InnerException.Should().Be(innerException);
        exception.RateLimit.Should().BeNull();
        exception.ApiError.Should().BeNull();
    }

    [Fact]
    public void RateLimitConstructor_WithRateLimit_SetsRateLimitAndDefaultMessage()
    {
        var rateLimit = new RateLimit();

        var exception = new RateLimitApiException(rateLimit);

        exception.Message.Should().Be("Rate limits exceeded");
        exception.RateLimit.Should().Be(rateLimit);
        exception.ApiError.Should().BeNull();
    }

    [Fact]
    public void RateLimitConstructor_WithRateLimitAndApiError_SetsAllProperties()
    {
        var rateLimit = new RateLimit();
        var apiError = new ApiError();

        var exception = new RateLimitApiException(rateLimit, apiError);

        exception.Message.Should().Be("Rate limits exceeded");
        exception.RateLimit.Should().Be(rateLimit);
        exception.ApiError.Should().Be(apiError);
    }

    [Fact]
    public void RateLimitConstructor_WithNullRateLimit_HandlesGracefully()
    {
        var exception = new RateLimitApiException((RateLimit?)null);

        exception.Message.Should().Be("Rate limits exceeded");
        exception.RateLimit.Should().BeNull();
        exception.ApiError.Should().BeNull();
    }

    [Fact]
    public void RateLimitConstructor_WithNullRateLimitAndApiError_HandlesGracefully()
    {
        var apiError = new ApiError();

        var exception = new RateLimitApiException(null, apiError);

        exception.Message.Should().Be("Rate limits exceeded");
        exception.RateLimit.Should().BeNull();
        exception.ApiError.Should().Be(apiError);
    }
    
    [Fact]
    public void Constructor_WithMessageAndInnerException_SetsMessageAndInnerException()
    {
        var message = "Test error message";
        var innerException = new InvalidOperationException("Inner exception");

        var exception = new ErrorApiException(message, innerException);

        exception.Message.Should().Be(message);
        exception.InnerException.Should().Be(innerException);
    }

    [Fact]
    public void Constructor_WithEmptyMessageAndInnerException_SetsEmptyMessageAndInnerException()
    {
        var message = string.Empty;
        var innerException = new NotImplementedException("Inner exception");

        var exception = new ErrorApiException(message, innerException);

        exception.Message.Should().Be(message);
        exception.InnerException.Should().Be(innerException);
    }

    [Fact]
    public void Constructor_WithMessageAndNullInnerException_SetsMessageAndNullInnerException()
    {
        var message = "Test error message";

        var exception = new ErrorApiException(message, null);

        exception.Message.Should().Be(message);
        exception.InnerException.Should().BeNull();
    }
    
    [Fact]
    public void DefaultConstructor_ShouldCreateInstanceWithDefaultValues()
    {
        var exception = new ErrorApiException();
    
        exception.Should().NotBeNull();
        exception.Message.Should().Be("Exception of type 'Auth0.Core.Exceptions.ErrorApiException' was thrown.");
        exception.InnerException.Should().BeNull();
        exception.ApiError.Should().BeNull();
        exception.StatusCode.Should().Be(default(HttpStatusCode));
    }

    [Fact]
    public void DefaultConstructor_ShouldInheritFromApiException()
    {
        var exception = new ErrorApiException();
    
        exception.Should().BeAssignableTo<ApiException>();
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
        responseMessage.Headers.Add("Auth0-Client-Quota-Limit",
            "b=per_hour;q=10;r=9;t=774,b=per_day;q=100;r=99;t=22374");
        responseMessage.Headers.Add("X-Quota-Organisation-Limit",
            "b=per_hour;q=10;r=9;t=774,b=per_day;q=100;r=99;t=22374");
        responseMessage.Headers.Add("Retry-After", "22374");
        return responseMessage;
    }
}