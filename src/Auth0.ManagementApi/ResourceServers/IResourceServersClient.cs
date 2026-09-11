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
    /// Create a new API associated with your tenant. Note that all new APIs must be registered with Auth0. For more information, read <see href="https://www.auth0.com/docs/get-started/apis"> APIs</see>.
    /// </summary>
    WithRawResponseTask<CreateResourceServerResponseContent> CreateAsync(
        CreateResourceServerRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Search resource servers using SCIM or Lucene filter syntax with low-latency, eventually consistent results. Use the parser parameter to specify "scim" or "lucene" syntax (default: "lucene"). This endpoint provides an alternative to the standard GET /resource-servers endpoint with better performance for complex queries.
    /// Results may not reflect recent updates immediately.
    ///
    /// The `signing_secret` field is not supported by this endpoint.
    /// </summary>
    Task<Pager<ResourceServerSearchResponse>> SearchAsync(
        SearchResourceServersRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve <see href="https://auth0.com/docs/apis">API</see> details with the given ID.
    /// </summary>
    WithRawResponseTask<GetResourceServerResponseContent> GetAsync(
        string id,
        GetResourceServerRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an existing API by ID. For more information, read <see href="https://www.auth0.com/docs/get-started/apis/api-settings">API Settings</see>.
    /// </summary>
    WithRawResponseTask DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Change an existing API setting by resource server ID. For more information, read <see href="https://www.auth0.com/docs/get-started/apis/api-settings">API Settings</see>.
    /// </summary>
    WithRawResponseTask<UpdateResourceServerResponseContent> UpdateAsync(
        string id,
        UpdateResourceServerRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
