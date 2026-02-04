namespace Auth0.ManagementApi;

public partial interface IStatsClient
{
    /// <summary>
    /// Retrieve the number of active users that logged in during the last 30 days.
    /// </summary>
    WithRawResponseTask<double> GetActiveUsersCountAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the number of logins, signups and breached-password detections (subscription required) that occurred each day within a specified date range.
    /// </summary>
    WithRawResponseTask<IEnumerable<DailyStats>> GetDailyAsync(
        GetDailyStatsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
