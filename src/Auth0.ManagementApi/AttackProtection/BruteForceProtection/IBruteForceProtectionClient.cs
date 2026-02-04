using Auth0.ManagementApi;

namespace Auth0.ManagementApi.AttackProtection;

public partial interface IBruteForceProtectionClient
{
    /// <summary>
    /// Retrieve details of the Brute-force Protection configuration of your tenant.
    /// </summary>
    WithRawResponseTask<GetBruteForceSettingsResponseContent> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the Brute-force Protection configuration of your tenant.
    /// </summary>
    WithRawResponseTask<UpdateBruteForceSettingsResponseContent> UpdateAsync(
        UpdateBruteForceSettingsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
