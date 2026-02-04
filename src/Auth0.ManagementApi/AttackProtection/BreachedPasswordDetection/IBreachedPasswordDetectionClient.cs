using Auth0.ManagementApi;

namespace Auth0.ManagementApi.AttackProtection;

public partial interface IBreachedPasswordDetectionClient
{
    /// <summary>
    /// Retrieve details of the Breached Password Detection configuration of your tenant.
    /// </summary>
    WithRawResponseTask<GetBreachedPasswordDetectionSettingsResponseContent> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update details of the Breached Password Detection configuration of your tenant.
    /// </summary>
    WithRawResponseTask<UpdateBreachedPasswordDetectionSettingsResponseContent> UpdateAsync(
        UpdateBreachedPasswordDetectionSettingsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
