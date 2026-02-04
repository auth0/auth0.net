using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Tenants;

public partial interface ISettingsClient
{
    /// <summary>
    /// Retrieve tenant settings. A list of fields to include or exclude may also be specified.
    /// </summary>
    WithRawResponseTask<GetTenantSettingsResponseContent> GetAsync(
        GetTenantSettingsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update settings for a tenant.
    /// </summary>
    WithRawResponseTask<UpdateTenantSettingsResponseContent> UpdateAsync(
        UpdateTenantSettingsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
