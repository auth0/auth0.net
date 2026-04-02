using Auth0.ManagementApi;

namespace Auth0.ManagementApi.RiskAssessments.Settings;

public partial interface INewDeviceClient
{
    /// <summary>
    /// Gets the risk assessment settings for the new device assessor
    /// </summary>
    WithRawResponseTask<GetRiskAssessmentsSettingsNewDeviceResponseContent> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates the risk assessment settings for the new device assessor
    /// </summary>
    WithRawResponseTask<UpdateRiskAssessmentsSettingsNewDeviceResponseContent> UpdateAsync(
        UpdateRiskAssessmentsSettingsNewDeviceRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
