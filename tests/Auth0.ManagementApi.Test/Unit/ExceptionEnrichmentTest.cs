using System;
using System.Net;
using System.Net.Http;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit;

[TestFixture]
public class ExceptionEnrichmentTest
{
    private static object Body(string json) => JsonUtils.Deserialize<object>(json);

    [Test]
    public void Message_UsesApiMessage_WhenBodyHasMessage()
    {
        var ex = new BadRequestError(Body("""{"message": "Payload validation error."}"""));
        Assert.That(ex.Message, Is.EqualTo("Payload validation error."));
    }

    [Test]
    public void Message_UsesErrorDescription_WhenMessageMissing()
    {
        var ex = new BadRequestError(Body("""{"error_description": "invalid scope"}"""));
        Assert.That(ex.Message, Is.EqualTo("invalid scope"));
    }

    [Test]
    public void Message_FallsBackToDefault_WhenBodyHasNoUsableFields()
    {
        var ex = new BadRequestError(Body("""{"unrelated": "x"}"""));
        Assert.That(ex.Message, Is.EqualTo("BadRequestError"));
    }

    [Test]
    public void Message_FallsBackToDefault_WhenBodyIsNotAnObject()
    {
        var ex = new BadRequestError(Body("""["not","an","object"]"""));
        Assert.That(ex.Message, Is.EqualTo("BadRequestError"));
    }

    [Test]
    public void ApiError_ExposesErrorAndErrorCodeAndMessage()
    {
        var ex = new BadRequestError(
            Body(
                """{"error": "Bad Request", "errorCode": "invalid_body", "message": "bad"}"""
            )
        );

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ex.ApiError, Is.Not.Null);
            Assert.That(ex.ApiError!.Error, Is.EqualTo("Bad Request"));
            Assert.That(ex.ErrorCode, Is.EqualTo("invalid_body"));
            Assert.That(ex.Description, Is.EqualTo("bad"));
        }
    }

    [Test]
    public void ApiError_IsNull_WhenNoErrorInfoPresent()
    {
        var ex = new BadRequestError(Body("""{"unrelated": "x"}"""));
        Assert.That(ex.ApiError, Is.Null);
    }

    [Test]
    public void RateLimit_ParsesHeaders_FromTooManyRequestsError()
    {
        var reset = DateTimeOffset.UtcNow.AddSeconds(120).ToUnixTimeSeconds();
        var raw = BuildRawResponse(
            (int)HttpStatusCode.TooManyRequests,
            ("x-ratelimit-limit", "100"),
            ("x-ratelimit-remaining", "0"),
            ("x-ratelimit-reset", reset.ToString()),
            ("retry-after", "30")
        );

        var ex = new TooManyRequestsError(Body("""{"message": "Too many requests"}"""), raw);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ex.Message, Is.EqualTo("Too many requests"));
            Assert.That(ex.RateLimit, Is.Not.Null);
            Assert.That(ex.RateLimit!.Limit, Is.EqualTo(100));
            Assert.That(ex.RateLimit.Remaining, Is.EqualTo(0));
            Assert.That(ex.RateLimit.Reset, Is.EqualTo(DateTimeOffset.FromUnixTimeSeconds(reset)));
            Assert.That(ex.RateLimit.RetryAfter, Is.EqualTo(TimeSpan.FromSeconds(30)));
        }
    }

    [Test]
    public void RateLimit_ParsesHeaders_CaseInsensitively()
    {
        // The Auth0 API returns these headers capitalized (e.g. "X-RateLimit-Limit"),
        // while RateLimit.Parse looks them up in lowercase. HTTP header lookups are
        // case-insensitive, so this must still resolve.
        var reset = DateTimeOffset.UtcNow.AddSeconds(60).ToUnixTimeSeconds();
        var raw = BuildRawResponse(
            (int)HttpStatusCode.TooManyRequests,
            ("X-RateLimit-Limit", "50"),
            ("X-RateLimit-Remaining", "10"),
            ("X-RateLimit-Reset", reset.ToString()),
            ("Retry-After", "15")
        );

        var ex = new TooManyRequestsError(Body("""{"message": "Too many requests"}"""), raw);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ex.RateLimit, Is.Not.Null);
            Assert.That(ex.RateLimit!.Limit, Is.EqualTo(50));
            Assert.That(ex.RateLimit.Remaining, Is.EqualTo(10));
            Assert.That(ex.RateLimit.Reset, Is.EqualTo(DateTimeOffset.FromUnixTimeSeconds(reset)));
            Assert.That(ex.RateLimit.RetryAfter, Is.EqualTo(TimeSpan.FromSeconds(15)));
        }
    }

    [Test]
    public void RateLimit_ReturnsNullValues_WhenHeadersMissing()
    {
        var raw = BuildRawResponse((int)HttpStatusCode.TooManyRequests);
        var ex = new TooManyRequestsError(Body("""{"message": "Too many requests"}"""), raw);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ex.RateLimit, Is.Not.Null);
            Assert.That(ex.RateLimit!.Limit, Is.Null);
            Assert.That(ex.RateLimit.Remaining, Is.Null);
            Assert.That(ex.RateLimit.Reset, Is.Null);
            Assert.That(ex.RateLimit.RetryAfter, Is.Null);
        }
    }

    [Test]
    public void RateLimit_IsNull_WhenNoRawResponse()
    {
        var ex = new TooManyRequestsError(Body("""{"message": "Too many requests"}"""));
        Assert.That(ex.RateLimit, Is.Null);
    }

    [Test]
    public void RateLimit_IsExposedOnBaseException_ForNon429Errors()
    {
        // RateLimit lives on the base ManagementApiException, so any error type can surface
        // rate limit headers when the API includes them (not just TooManyRequestsError).
        var reset = DateTimeOffset.UtcNow.AddSeconds(60).ToUnixTimeSeconds();
        var raw = BuildRawResponse(
            (int)HttpStatusCode.BadRequest,
            ("x-ratelimit-limit", "100"),
            ("x-ratelimit-remaining", "5"),
            ("x-ratelimit-reset", reset.ToString()),
            ("retry-after", "10")
        );

        ManagementApiException ex = new BadRequestError(
            Body("""{"message": "Payload validation error."}"""),
            raw
        );

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ex.RateLimit, Is.Not.Null);
            Assert.That(ex.RateLimit!.Limit, Is.EqualTo(100));
            Assert.That(ex.RateLimit.Remaining, Is.EqualTo(5));
            Assert.That(ex.RateLimit.Reset, Is.EqualTo(DateTimeOffset.FromUnixTimeSeconds(reset)));
            Assert.That(ex.RateLimit.RetryAfter, Is.EqualTo(TimeSpan.FromSeconds(10)));
        }
    }

    [Test]
    public void RateLimit_ParsesClientAndOrganizationQuota()
    {
        var raw = BuildRawResponse(
            (int)HttpStatusCode.TooManyRequests,
            ("Auth0-Client-Quota-Limit", "b=per_hour;q=100;r=90;t=3600,b=per_day;q=1000;r=950;t=86400"),
            ("Auth0-Organization-Quota-Limit", "b=per_hour;q=50;r=25;t=1800")
        );

        var ex = new TooManyRequestsError(Body("""{"message": "Too many requests"}"""), raw);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ex.RateLimit!.ClientQuotaLimit, Is.Not.Null);
            Assert.That(ex.RateLimit.ClientQuotaLimit!.PerHour!.Quota, Is.EqualTo(100));
            Assert.That(ex.RateLimit.ClientQuotaLimit.PerHour.Remaining, Is.EqualTo(90));
            Assert.That(ex.RateLimit.ClientQuotaLimit.PerHour.ResetAfter, Is.EqualTo(3600));
            Assert.That(ex.RateLimit.ClientQuotaLimit.PerDay!.Quota, Is.EqualTo(1000));
            Assert.That(ex.RateLimit.ClientQuotaLimit.PerDay.Remaining, Is.EqualTo(950));
            Assert.That(ex.RateLimit.ClientQuotaLimit.PerDay.ResetAfter, Is.EqualTo(86400));

            Assert.That(ex.RateLimit.OrganizationQuotaLimit, Is.Not.Null);
            Assert.That(ex.RateLimit.OrganizationQuotaLimit!.PerHour!.Quota, Is.EqualTo(50));
            Assert.That(ex.RateLimit.OrganizationQuotaLimit.PerHour.Remaining, Is.EqualTo(25));
            Assert.That(ex.RateLimit.OrganizationQuotaLimit.PerHour.ResetAfter, Is.EqualTo(1800));
            Assert.That(ex.RateLimit.OrganizationQuotaLimit.PerDay, Is.Null);
        }
    }

    [Test]
    public void RateLimit_QuotaIsNull_WhenHeadersMissing()
    {
        var raw = BuildRawResponse((int)HttpStatusCode.TooManyRequests);
        var ex = new TooManyRequestsError(Body("""{"message": "Too many requests"}"""), raw);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ex.RateLimit!.ClientQuotaLimit, Is.Null);
            Assert.That(ex.RateLimit.OrganizationQuotaLimit, Is.Null);
        }
    }

    [Test]
    public void RateLimit_QuotaBucketIsNull_WhenHeaderMalformed()
    {
        // Missing the required 'q' key in the bucket makes it unparseable.
        var raw = BuildRawResponse(
            (int)HttpStatusCode.TooManyRequests,
            ("Auth0-Client-Quota-Limit", "b=per_hour;r=90;t=3600")
        );

        var ex = new TooManyRequestsError(Body("""{"message": "Too many requests"}"""), raw);

        using (Assert.EnterMultipleScope())
        {
            // The header is present, so ClientQuotaLimit is non-null, but the bucket did not parse.
            Assert.That(ex.RateLimit!.ClientQuotaLimit, Is.Not.Null);
            Assert.That(ex.RateLimit.ClientQuotaLimit!.PerDay, Is.Null);
        }
    }

    [Test]
    public void RateLimit_Reset_IsNull_WhenHeaderOutOfRange()
    {
        // A value beyond DateTimeOffset's representable range must not throw
        // when RateLimit.Reset is accessed; it should surface as null.
        var raw = BuildRawResponse(
            (int)HttpStatusCode.TooManyRequests,
            ("x-ratelimit-reset", "99999999999999999")
        );

        var ex = new TooManyRequestsError(Body("""{"message": "Too many requests"}"""), raw);

        Assert.That(ex.RateLimit!.Reset, Is.Null);
    }

    [Test]
    public void RateLimit_QuotaValues_HandleLargeValues()
    {
        // Quota values can exceed int.MaxValue, so they are parsed as long.
        var quota = (long)int.MaxValue + 1;
        var remaining = (long)int.MaxValue + 2;
        var raw = BuildRawResponse(
            (int)HttpStatusCode.TooManyRequests,
            ("Auth0-Client-Quota-Limit", $"b=per_hour;q={quota};r={remaining};t=3600")
        );

        var ex = new TooManyRequestsError(Body("""{"message": "Too many requests"}"""), raw);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ex.RateLimit!.ClientQuotaLimit!.PerHour!.Quota, Is.EqualTo(quota));
            Assert.That(ex.RateLimit.ClientQuotaLimit.PerHour.Remaining, Is.EqualTo(remaining));
        }
    }

    [Test]
    public void RateLimit_UnknownQuotaBucket_IsIgnored()
    {
        // A bucket name other than per_hour/per_day must not be misclassified.
        var raw = BuildRawResponse(
            (int)HttpStatusCode.TooManyRequests,
            ("Auth0-Client-Quota-Limit", "b=per_minute;q=100;r=90;t=60")
        );

        var ex = new TooManyRequestsError(Body("""{"message": "Too many requests"}"""), raw);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ex.RateLimit!.ClientQuotaLimit, Is.Not.Null);
            Assert.That(ex.RateLimit.ClientQuotaLimit!.PerHour, Is.Null);
            Assert.That(ex.RateLimit.ClientQuotaLimit.PerDay, Is.Null);
        }
    }

    private static RawResponse BuildRawResponse(
        int statusCode,
        params (string Name, string Value)[] headers
    )
    {
        var response = new HttpResponseMessage((HttpStatusCode)statusCode)
        {
            RequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                "https://tenant.auth0.com/api/v2/users"
            ),
        };
        foreach (var (name, value) in headers)
        {
            response.Headers.TryAddWithoutValidation(name, value);
        }

        return new RawResponse
        {
            StatusCode = (HttpStatusCode)statusCode,
            Url = response.RequestMessage!.RequestUri!,
            Headers = ResponseHeaders.FromHttpResponseMessage(response),
        };
    }
}
