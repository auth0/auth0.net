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
    /// Retrieves detailed list of all <see href="https://auth0.com/docs/authenticate/identity-providers">connections</see> that match the specified strategy. If no strategy is provided, all connections within your tenant are retrieved. This action can accept a list of fields to include or exclude from the resulting list of connections.
    ///
    /// This endpoint supports two types of pagination:
    /// <list type="bullet">
    /// <item><description>Offset pagination</description></item>
    /// <item><description>Checkpoint pagination</description></item>
    /// </list>
    ///
    /// Checkpoint pagination must be used if you need to retrieve more than 1000 connections.
    ///
    /// <para>Checkpoint Pagination</para>
    ///
    /// To search by checkpoint, use the following parameters:
    /// <list type="bullet">
    /// <item><description><c>from</c>: Optional id from which to start selection.</description></item>
    /// <item><description><c>take</c>: The total amount of entries to retrieve when using the from parameter. Defaults to 50.</description></item>
    /// </list>
    ///
    /// <b>Note</b>: The first time you call this endpoint using checkpoint pagination, omit the <c>from</c> parameter. If there are more results, a <c>next</c> value is included in the response. You can use this for subsequent API calls. When <c>next</c> is no longer included in the response, no pages are remaining.
    /// </summary>
    Task<Pager<ConnectionForList>> ListAsync(
        ListConnectionsQueryParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new connection according to the JSON object received in <c>body</c>.
    ///
    /// <b>Note:</b> If a connection with the same name was recently deleted and had a large number of associated users, the deletion may still be processing. Creating a new connection with that name before the deletion completes may fail or produce unexpected results.
    /// </summary>
    WithRawResponseTask<CreateConnectionResponseContent> CreateAsync(
        CreateConnectionRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details for a specified <see href="https://auth0.com/docs/authenticate/identity-providers">connection</see> along with options that can be used for identity provider configuration.
    /// </summary>
    WithRawResponseTask<GetConnectionResponseContent> GetAsync(
        string id,
        GetConnectionRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes a specific <see href="https://auth0.com/docs/authenticate/identity-providers">connection</see> from your tenant. This action cannot be undone. Once removed, users can no longer use this connection to authenticate.
    ///
    /// <b>Note:</b> If your connection has a large amount of users associated with it, please be aware that this operation can be long running after the response is returned and may impact concurrent <see href="https://auth0.com/docs/api/management/v2/connections/post-connections">create connection</see> requests, if they use an identical connection name.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update details for a specific <see href="https://auth0.com/docs/authenticate/identity-providers">connection</see>, including option properties for identity provider configuration.
    ///
    /// <b>Note</b>: If you use the <c>options</c> parameter, the entire <c>options</c> object is overriden. To avoid partial data or other issues, ensure all parameters are present when using this option.
    /// </summary>
    WithRawResponseTask<UpdateConnectionResponseContent> UpdateAsync(
        string id,
        UpdateConnectionRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves the status of an ad/ldap connection referenced by its <c>ID</c>. <c>200 OK</c> http status code response is returned  when the connection is online, otherwise a <c>404</c> status code is returned along with an error message
    /// </summary>
    Task CheckStatusAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
