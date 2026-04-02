using Auth0.ManagementApi;
using Auth0.ManagementApi.RiskAssessments.Settings;

namespace Auth0.ManagementApi.RiskAssessments;

public partial interface ISettingsClient
{
    public INewDeviceClient NewDevice { get; }

    /// <summary>
    /// Gets the tenant settings for risk assessments
    /// </summary>
    WithRawResponseTask<GetRiskAssessmentsSettingsResponseContent> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates the tenant settings for risk assessments
    /// </summary>
    WithRawResponseTask<UpdateRiskAssessmentsSettingsResponseContent> UpdateAsync(
        UpdateRiskAssessmentsSettingsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
