namespace Auth0.ManagementApi;

public partial interface ISupplementalSignalsClient
{
    /// <summary>
    /// Get the supplemental signals configuration for a tenant.
    /// </summary>
    WithRawResponseTask<GetSupplementalSignalsResponseContent> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the supplemental signals configuration for a tenant.
    /// </summary>
    WithRawResponseTask<PatchSupplementalSignalsResponseContent> PatchAsync(
        UpdateSupplementalSignalsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
