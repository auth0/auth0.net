using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Prompts;

public partial interface IPartialsClient
{
    /// <summary>
    /// Get template partials for a prompt
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> GetAsync(
        PartialGroupsEnum prompt,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Set template partials for a prompt
    /// </summary>
    Task SetAsync(
        PartialGroupsEnum prompt,
        Dictionary<string, object?> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
