using Auth0.ManagementApi.Connections;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

public partial interface IConnectionsClient
{
    public Auth0.ManagementApi.Connections.IClientsClient Clients { get; }
    public IDirectoryProvisioningClient DirectoryProvisioning { get; }
    public Auth0.ManagementApi.Connections.IKeysClient Keys { get; }
    public IScimConfigurationClient ScimConfiguration { get; }
    public Auth0.ManagementApi.Connections.IUsersClient Users { get; }

    /// <summary>
    /// Retrieves detailed list of all <a href="https://auth0.com/docs/authenticate/identity-providers">connections</a> that match the specified strategy. If no strategy is provided, all connections within your tenant are retrieved. This action can accept a list of fields to include or exclude from the resulting list of connections.
    ///
    /// This endpoint supports two types of pagination:
    /// <ul>
    /// <li>Offset pagination</li>
    /// <li>Checkpoint pagination</li>
    /// </ul>
    ///
    /// Checkpoint pagination must be used if you need to retrieve more than 1000 connections.
    ///
    /// &lt;h2&gt;Checkpoint Pagination&lt;/h2&gt;
    ///
    /// To search by checkpoint, use the following parameters:
    /// <ul>
    /// <li><code>from</code>: Optional id from which to start selection.</li>
    /// <li><code>take</code>: The total amount of entries to retrieve when using the from parameter. Defaults to 50.</li>
    /// </ul>
    ///
    /// <b>Note</b>: The first time you call this endpoint using checkpoint pagination, omit the <code>from</code> parameter. If there are more results, a <code>next</code> value is included in the response. You can use this for subsequent API calls. When <code>next</code> is no longer included in the response, no pages are remaining.
    /// </summary>
    Task<Pager<ConnectionForList>> ListAsync(
        ListConnectionsQueryParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new connection according to the JSON object received in <code>body</code>.<br/>
    /// </summary>
    WithRawResponseTask<CreateConnectionResponseContent> CreateAsync(
        CreateConnectionRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details for a specified <a href="https://auth0.com/docs/authenticate/identity-providers">connection</a> along with options that can be used for identity provider configuration.
    /// </summary>
    WithRawResponseTask<GetConnectionResponseContent> GetAsync(
        string id,
        GetConnectionRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes a specific <a href="https://auth0.com/docs/authenticate/identity-providers">connection</a> from your tenant. This action cannot be undone. Once removed, users can no longer use this connection to authenticate.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update details for a specific <a href="https://auth0.com/docs/authenticate/identity-providers">connection</a>, including option properties for identity provider configuration.
    ///
    /// <b>Note</b>: If you use the <code>options</code> parameter, the entire <code>options</code> object is overriden. To avoid partial data or other issues, ensure all parameters are present when using this option.
    /// </summary>
    WithRawResponseTask<UpdateConnectionResponseContent> UpdateAsync(
        string id,
        UpdateConnectionRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves the status of an ad/ldap connection referenced by its <code>ID</code>. <code>200 OK</code> http status code response is returned  when the connection is online, otherwise a <code>404</code> status code is returned along with an error message
    /// </summary>
    Task CheckStatusAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
