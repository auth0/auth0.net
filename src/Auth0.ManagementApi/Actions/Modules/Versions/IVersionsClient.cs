using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Actions.Modules;

public partial interface IVersionsClient
{
    /// <summary>
    /// List all published versions of a specific Actions Module.
    /// </summary>
    Task<Pager<ActionModuleVersion>> ListAsync(
        string id,
        GetActionModuleVersionsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new immutable version of an Actions Module from the current draft version. This publishes the draft as a new version that can be referenced by actions, while maintaining the existing draft for continued development.
    /// </summary>
    WithRawResponseTask<CreateActionModuleVersionResponseContent> CreateAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the details of a specific, immutable version of an Actions Module.
    /// </summary>
    WithRawResponseTask<GetActionModuleVersionResponseContent> GetAsync(
        string id,
        string versionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
