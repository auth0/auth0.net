using Auth0.ManagementApi;

namespace Auth0.ManagementApi.AttackProtection;

public partial interface IPhoneProviderProtectionClient
{
    /// <summary>
    /// Get the phone provider protection configuration for a tenant.
    /// </summary>
    WithRawResponseTask<GetPhoneProviderProtectionResponseContent> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the phone provider protection configuration for a tenant.
    /// </summary>
    WithRawResponseTask<PatchPhoneProviderProtectionResponseContent> PatchAsync(
        PatchPhoneProviderProtectionRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
