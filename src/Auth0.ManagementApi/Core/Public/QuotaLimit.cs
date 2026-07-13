using global::System.Collections.Generic;

namespace Auth0.ManagementApi;

/// <summary>
/// Represents the client quota headers (<c>Auth0-Client-Quota-Limit</c>) returned as part of a response.
/// </summary>
public sealed class ClientQuotaLimit
{
    /// <summary>
    /// The per-hour quota bucket, if present.
    /// </summary>
    public QuotaLimit? PerHour { get; init; }

    /// <summary>
    /// The per-day quota bucket, if present.
    /// </summary>
    public QuotaLimit? PerDay { get; init; }

    /// <summary>
    /// Parses the <c>Auth0-Client-Quota-Limit</c> header value into a <see cref="ClientQuotaLimit"/>.
    /// Returns <c>null</c> when the header is absent or empty.
    /// </summary>
    public static ClientQuotaLimit? Parse(string? headerValue)
    {
        if (!QuotaLimit.TryParseBuckets(headerValue, out var perHour, out var perDay))
        {
            return null;
        }

        return new ClientQuotaLimit { PerHour = perHour, PerDay = perDay };
    }
}

/// <summary>
/// Represents the organization quota headers (<c>Auth0-Organization-Quota-Limit</c>) returned as part of a response.
/// </summary>
public sealed class OrganizationQuotaLimit
{
    /// <summary>
    /// The per-hour quota bucket, if present.
    /// </summary>
    public QuotaLimit? PerHour { get; init; }

    /// <summary>
    /// The per-day quota bucket, if present.
    /// </summary>
    public QuotaLimit? PerDay { get; init; }

    /// <summary>
    /// Parses the <c>Auth0-Organization-Quota-Limit</c> header value into an <see cref="OrganizationQuotaLimit"/>.
    /// Returns <c>null</c> when the header is absent or empty.
    /// </summary>
    public static OrganizationQuotaLimit? Parse(string? headerValue)
    {
        if (!QuotaLimit.TryParseBuckets(headerValue, out var perHour, out var perDay))
        {
            return null;
        }

        return new OrganizationQuotaLimit { PerHour = perHour, PerDay = perDay };
    }
}

/// <summary>
/// Represents a single quota bucket returned in the Auth0 quota limit headers.
/// </summary>
public sealed class QuotaLimit
{
    /// <summary>
    /// The current configured quota.
    /// </summary>
    public long Quota { get; init; }

    /// <summary>
    /// The remaining quota.
    /// </summary>
    public long Remaining { get; init; }

    /// <summary>
    /// The number of seconds until the quota resets.
    /// </summary>
    public int ResetAfter { get; init; }

    /// <summary>
    /// Splits a quota header value (a comma-separated list of buckets) into its per-hour and per-day
    /// components. Returns <c>false</c> when the header is absent or empty.
    /// </summary>
    internal static bool TryParseBuckets(
        string? headerValue,
        out QuotaLimit? perHour,
        out QuotaLimit? perDay
    )
    {
        perHour = null;
        perDay = null;

        if (string.IsNullOrEmpty(headerValue))
        {
            return false;
        }

        foreach (var eachBucket in headerValue!.Split(','))
        {
            var quotaLimit = ParseBucket(eachBucket, out var bucket);
            if (bucket == "per_hour")
            {
                perHour = quotaLimit;
            }
            else if (bucket == "per_day")
            {
                perDay = quotaLimit;
            }
            // Unknown bucket names are ignored so a future bucket type is not
            // silently misclassified as per-day.
        }

        return true;
    }

    private static QuotaLimit? ParseBucket(string headerValue, out string? bucket)
    {
        bucket = null;

        if (string.IsNullOrEmpty(headerValue))
        {
            return null;
        }

        var kvp = new Dictionary<string, string>();
        foreach (var segment in headerValue.Split(';'))
        {
            var parts = segment.Split(new[] { '=' }, 2);
            if (parts.Length != 2 || parts[0].Length == 0 || parts[1].Length == 0)
            {
                return null;
            }

            // Duplicate keys indicate a malformed header.
            if (kvp.ContainsKey(parts[0]))
            {
                return null;
            }

            kvp[parts[0]] = parts[1];
        }

        if (
            !kvp.TryGetValue("b", out var bucketValue)
            || !kvp.TryGetValue("q", out var quota)
            || !kvp.TryGetValue("r", out var remaining)
            || !kvp.TryGetValue("t", out var resetAfter)
        )
        {
            return null;
        }

        if (
            !long.TryParse(quota, out var quotaLong)
            || !long.TryParse(remaining, out var remainingLong)
            || !int.TryParse(resetAfter, out var resetAfterInt)
        )
        {
            return null;
        }

        bucket = bucketValue;
        return new QuotaLimit
        {
            Quota = quotaLong,
            Remaining = remainingLong,
            ResetAfter = resetAfterInt,
        };
    }
}
