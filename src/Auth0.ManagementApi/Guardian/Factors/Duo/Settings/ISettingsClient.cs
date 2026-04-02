using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Guardian.Factors.Duo;

public partial interface ISettingsClient
{
    /// <summary>
    /// Retrieves the DUO account and factor configuration.
    /// </summary>
    WithRawResponseTask<GetGuardianFactorDuoSettingsResponseContent> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Set the DUO account configuration and other properties specific to this factor.
    /// </summary>
    WithRawResponseTask<SetGuardianFactorDuoSettingsResponseContent> SetAsync(
        SetGuardianFactorDuoSettingsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<UpdateGuardianFactorDuoSettingsResponseContent> UpdateAsync(
        UpdateGuardianFactorDuoSettingsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
