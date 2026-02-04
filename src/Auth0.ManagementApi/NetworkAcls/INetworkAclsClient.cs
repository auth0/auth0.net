using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

public partial interface INetworkAclsClient
{
    /// <summary>
    /// Get all access control list entries for your client.
    /// </summary>
    Task<Pager<NetworkAclsResponseContent>> ListAsync(
        ListNetworkAclsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new access control list for your client.
    /// </summary>
    Task CreateAsync(
        CreateNetworkAclRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a specific access control list entry for your client.
    /// </summary>
    WithRawResponseTask<GetNetworkAclsResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update existing access control list for your client.
    /// </summary>
    WithRawResponseTask<SetNetworkAclsResponseContent> SetAsync(
        string id,
        SetNetworkAclRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete existing access control list for your client.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update existing access control list for your client.
    /// </summary>
    WithRawResponseTask<UpdateNetworkAclResponseContent> UpdateAsync(
        string id,
        UpdateNetworkAclRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
