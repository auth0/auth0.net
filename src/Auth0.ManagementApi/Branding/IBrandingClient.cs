using Auth0.ManagementApi.Branding;

namespace Auth0.ManagementApi;

public partial interface IBrandingClient
{
    public Auth0.ManagementApi.Branding.ITemplatesClient Templates { get; }
    public IThemesClient Themes { get; }
    public Auth0.ManagementApi.Branding.Phone.IPhoneClient Phone { get; }

    /// <summary>
    /// Retrieve branding settings.
    /// </summary>
    WithRawResponseTask<GetBrandingResponseContent> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update branding settings.
    /// </summary>
    WithRawResponseTask<UpdateBrandingResponseContent> UpdateAsync(
        UpdateBrandingRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
