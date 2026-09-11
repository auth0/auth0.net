using Auth0.ManagementApi.Guardian;

namespace Auth0.ManagementApi;

public partial interface IGuardianClient
{
    public Auth0.ManagementApi.Guardian.IEnrollmentsClient Enrollments { get; }
    public IFactorsClient Factors { get; }
    public IPoliciesClient Policies { get; }

    /// <summary>
    /// TODO: Link this endpoint to relevant documentation when available.
    /// </summary>
    WithRawResponseTask<GetGuardianSettingsResponseContent> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a tenant's guardian settings such as Remember Me
    /// </summary>
    WithRawResponseTask<SetGuardianSettingsResponseContent> SetAsync(
        SetGuardianSettingsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
