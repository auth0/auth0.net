using Auth0.ManagementApi;

namespace Auth0.ManagementApi.AttackProtection;

public partial interface IBotDetectionClient
{
    /// <summary>
    /// Get the Bot Detection configuration of your tenant.
    /// </summary>
    WithRawResponseTask<GetBotDetectionSettingsResponseContent> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the Bot Detection configuration of your tenant.
    /// </summary>
    WithRawResponseTask<UpdateBotDetectionSettingsResponseContent> UpdateAsync(
        UpdateBotDetectionSettingsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
