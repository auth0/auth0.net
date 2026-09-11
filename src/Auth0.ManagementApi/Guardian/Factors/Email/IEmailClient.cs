using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Guardian.Factors;

public partial interface IEmailClient
{
    /// <summary>
    /// TODO: Link this endpoint to relevant documentation when available.
    /// </summary>
    WithRawResponseTask<GetEmailFactorSettingsResponseContent> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// TODO: Link this endpoint to relevant documentation when available.
    /// </summary>
    WithRawResponseTask<SetEmailFactorSettingsResponseContent> SetAsync(
        SetEmailFactorSettingsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
