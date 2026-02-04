using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Branding;

public partial interface IThemesClient
{
    /// <summary>
    /// Create branding theme.
    /// </summary>
    WithRawResponseTask<CreateBrandingThemeResponseContent> CreateAsync(
        CreateBrandingThemeRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve default branding theme.
    /// </summary>
    WithRawResponseTask<GetBrandingDefaultThemeResponseContent> GetDefaultAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve branding theme.
    /// </summary>
    WithRawResponseTask<GetBrandingThemeResponseContent> GetAsync(
        string themeId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete branding theme.
    /// </summary>
    Task DeleteAsync(
        string themeId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update branding theme.
    /// </summary>
    WithRawResponseTask<UpdateBrandingThemeResponseContent> UpdateAsync(
        string themeId,
        UpdateBrandingThemeRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
