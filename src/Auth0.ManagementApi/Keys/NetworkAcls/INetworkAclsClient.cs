using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Keys;

public partial interface INetworkAclsClient
{
    /// <summary>
    /// Retrieve all keys used to verify HTTP Message Signatures on Network ACL rules, ordered by creation time descending.
    /// </summary>
    WithRawResponseTask<GetAllKeysNetworkAclsResponseContent> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new key used to verify HTTP Message Signatures on Network ACL rules.
    /// </summary>
    WithRawResponseTask<CreateKeysNetworkAclsResponseContent> CreateAsync(
        CreateKeysNetworkAclsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a specific key used to verify HTTP Message Signatures on Network ACL rules.
    /// </summary>
    WithRawResponseTask<NetworkAclKey> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a key used to verify HTTP Message Signatures on Network ACL rules
    /// </summary>
    WithRawResponseTask DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
