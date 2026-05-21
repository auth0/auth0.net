using Auth0.ManagementApi.Connections;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

public partial interface IConnectionsClient
{
    public IDirectoryProvisioningClient DirectoryProvisioning { get; }
    public IScimConfigurationClient ScimConfiguration { get; }
    public Auth0.ManagementApi.Connections.IClientsClient Clients { get; }
    public Auth0.ManagementApi.Connections.IKeysClient Keys { get; }
    public Auth0.ManagementApi.Connections.IUsersClient Users { get; }

    /// <summary>
    /// Retrieves detailed list of all [connections](https://auth0.com/docs/authenticate/identity-providers) that match the specified strategy. If no strategy is provided, all connections within your tenant are retrieved. This action can accept a list of fields to include or exclude from the resulting list of connections.
    ///
    /// This endpoint supports two types of pagination:
    ///
    /// - Offset pagination
    /// - Checkpoint pagination
    ///
    /// Checkpoint pagination must be used if you need to retrieve more than 1000 connections.
    ///
    /// **Checkpoint Pagination**
    ///
    /// To search by checkpoint, use the following parameters:
    ///
    /// - `from`: Optional id from which to start selection.
    /// - `take`: The total amount of entries to retrieve when using the from parameter. Defaults to 50.
    ///
    /// **Note**: The first time you call this endpoint using checkpoint pagination, omit the `from` parameter. If there are more results, a `next` value is included in the response. You can use this for subsequent API calls. When `next` is no longer included in the response, no pages are remaining.
    /// </summary>
    Task<Pager<ConnectionForList>> ListAsync(
        ListConnectionsQueryParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new connection according to the JSON object received in `body`.
    ///
    /// **Note:** If a connection with the same name was recently deleted and had a large number of associated users, the deletion may still be processing. Creating a new connection with that name before the deletion completes may fail or produce unexpected results.
    /// </summary>
    WithRawResponseTask<CreateConnectionResponseContent> CreateAsync(
        CreateConnectionRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details for a specified [connection](https://auth0.com/docs/authenticate/identity-providers) along with options that can be used for identity provider configuration.
    /// </summary>
    WithRawResponseTask<GetConnectionResponseContent> GetAsync(
        string id,
        GetConnectionRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes a specific [connection](https://auth0.com/docs/authenticate/identity-providers) from your tenant. This action cannot be undone. Once removed, users can no longer use this connection to authenticate.
    ///
    /// **Note:** If your connection has a large amount of users associated with it, please be aware that this operation can be long running after the response is returned and may impact concurrent [create connection](https://auth0.com/docs/api/management/v2/connections/post-connections) requests, if they use an identical connection name.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update details for a specific [connection](https://auth0.com/docs/authenticate/identity-providers), including option properties for identity provider configuration.
    ///
    /// **Note**: If you use the `options` parameter, the entire `options` object is overridden. To avoid partial data or other issues, ensure all parameters are present when using this option.
    /// </summary>
    WithRawResponseTask<UpdateConnectionResponseContent> UpdateAsync(
        string id,
        UpdateConnectionRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves the status of an ad/ldap connection referenced by its `ID`. `200 OK` http status code response is returned  when the connection is online, otherwise a `404` status code is returned along with an error message
    /// </summary>
    Task CheckStatusAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
