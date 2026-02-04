using Auth0.ManagementApi;

namespace Auth0.ManagementApi.AttackProtection;

public partial interface ISuspiciousIpThrottlingClient
{
    /// <summary>
    /// Retrieve details of the Suspicious IP Throttling configuration of your tenant.
    /// </summary>
    WithRawResponseTask<GetSuspiciousIpThrottlingSettingsResponseContent> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the details of the Suspicious IP Throttling configuration of your tenant.
    /// </summary>
    WithRawResponseTask<UpdateSuspiciousIpThrottlingSettingsResponseContent> UpdateAsync(
        UpdateSuspiciousIpThrottlingSettingsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
