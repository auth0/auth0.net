using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

public partial interface IResourceServersClient
{
    /// <summary>
    /// Retrieve details of all APIs associated with your tenant.
    /// </summary>
    Task<Pager<ResourceServer>> ListAsync(
        ListResourceServerRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new API associated with your tenant. Note that all new APIs must be registered with Auth0. For more information, read <a href="https://www.auth0.com/docs/get-started/apis"> APIs</a>.
    /// </summary>
    WithRawResponseTask<CreateResourceServerResponseContent> CreateAsync(
        CreateResourceServerRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve <a href="https://auth0.com/docs/apis">API</a> details with the given ID.
    /// </summary>
    WithRawResponseTask<GetResourceServerResponseContent> GetAsync(
        string id,
        GetResourceServerRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an existing API by ID. For more information, read <a href="https://www.auth0.com/docs/get-started/apis/api-settings">API Settings</a>.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Change an existing API setting by resource server ID. For more information, read <a href="https://www.auth0.com/docs/get-started/apis/api-settings">API Settings</a>.
    /// </summary>
    WithRawResponseTask<UpdateResourceServerResponseContent> UpdateAsync(
        string id,
        UpdateResourceServerRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
