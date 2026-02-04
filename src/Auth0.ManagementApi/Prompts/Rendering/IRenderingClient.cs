using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Prompts;

public partial interface IRenderingClient
{
    /// <summary>
    /// Get render setting configurations for all screens.
    /// </summary>
    Task<Pager<AculResponseContent>> ListAsync(
        ListAculsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Learn more about <a href='https://auth0.com/docs/customize/login-pages/advanced-customizations/getting-started/configure-acul-screens'>configuring render settings</a> for advanced customization.
    /// </summary>
    WithRawResponseTask<BulkUpdateAculResponseContent> BulkUpdateAsync(
        BulkUpdateAculRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get render settings for a screen.
    /// </summary>
    WithRawResponseTask<GetAculResponseContent> GetAsync(
        PromptGroupNameEnum prompt,
        ScreenGroupNameEnum screen,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Learn more about <a href='https://auth0.com/docs/customize/login-pages/advanced-customizations/getting-started/configure-acul-screens'>configuring render settings</a> for advanced customization.
    /// </summary>
    WithRawResponseTask<UpdateAculResponseContent> UpdateAsync(
        PromptGroupNameEnum prompt,
        ScreenGroupNameEnum screen,
        UpdateAculRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
