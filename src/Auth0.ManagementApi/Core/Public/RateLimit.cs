using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Represents rate limit information returned by the Management API on a
/// <see cref="TooManyRequestsError"/> (HTTP 429) response.
/// </summary>
public sealed class RateLimit
{
    /// <summary>
    /// The maximum number of requests the consumer is allowed to make,
    /// from the <c>x-ratelimit-limit</c> header. <c>null</c> if the header was absent.
    /// </summary>
    public long? Limit { get; init; }

    /// <summary>
    /// The number of requests remaining in the current rate limit window,
    /// from the <c>x-ratelimit-remaining</c> header. <c>null</c> if the header was absent.
    /// </summary>
    public long? Remaining { get; init; }

    /// <summary>
    /// The date and time at which the current rate limit window resets,
    /// from the <c>x-ratelimit-reset</c> header (Unix epoch seconds). <c>null</c> if the header was absent.
    /// </summary>
    public DateTimeOffset? Reset { get; init; }

    /// <summary>
    /// The time to wait before retrying, from the <c>retry-after</c> header. <c>null</c> if the header was absent.
    /// </summary>
    public TimeSpan? RetryAfter { get; init; }

    /// <summary>
    /// Client-level quota information, from the <c>Auth0-Client-Quota-Limit</c> header.
    /// <c>null</c> if the header was absent or malformed.
    /// </summary>
    public ClientQuotaLimit? ClientQuotaLimit { get; init; }

    /// <summary>
    /// Organization-level quota information, from the <c>Auth0-Organization-Quota-Limit</c> header.
    /// <c>null</c> if the header was absent or malformed.
    /// </summary>
    public OrganizationQuotaLimit? OrganizationQuotaLimit { get; init; }

    /// <summary>
    /// Parses rate limit information from the supplied response headers.
    /// </summary>
    public static RateLimit Parse(ResponseHeaders headers)
    {
        return new RateLimit
        {
            Limit = GetLong(headers, "x-ratelimit-limit"),
            Remaining = GetLong(headers, "x-ratelimit-remaining"),
            Reset = GetReset(headers, "x-ratelimit-reset"),
            RetryAfter = GetRetryAfter(headers, "retry-after"),
            ClientQuotaLimit = Auth0.ManagementApi.ClientQuotaLimit.Parse(
                GetString(headers, "Auth0-Client-Quota-Limit")
            ),
            OrganizationQuotaLimit = Auth0.ManagementApi.OrganizationQuotaLimit.Parse(
                GetString(headers, "Auth0-Organization-Quota-Limit")
            ),
        };
    }

    private static string? GetString(ResponseHeaders headers, string name)
    {
        return headers.TryGetValue(name, out var value) ? value : null;
    }

    private static long? GetLong(ResponseHeaders headers, string name)
    {
        if (
            headers.TryGetValue(name, out var value)
            && long.TryParse(value, out var result)
        )
        {
            return result;
        }

        return null;
    }

    private static DateTimeOffset? GetReset(ResponseHeaders headers, string name)
    {
        var seconds = GetLong(headers, name);
        if (seconds is null)
        {
            return null;
        }

        // Guard against out-of-range values: FromUnixTimeSeconds throws for
        // seconds outside the representable DateTimeOffset range.
        try
        {
            return DateTimeOffset.FromUnixTimeSeconds(seconds.Value);
        }
        catch (ArgumentOutOfRangeException)
        {
            return null;
        }
    }

    private static TimeSpan? GetRetryAfter(ResponseHeaders headers, string name)
    {
        var seconds = GetLong(headers, name);
        return seconds is null ? null : TimeSpan.FromSeconds(seconds.Value);
    }
}
