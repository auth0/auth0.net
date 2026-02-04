using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Organizations;

public partial interface IEnabledConnectionsClient
{
    /// <summary>
    /// Retrieve details about a specific connection currently enabled for an Organization. Information returned includes details such as connection ID, name, strategy, and whether the connection automatically grants membership upon login.
    /// </summary>
    Task<Pager<OrganizationConnection>> ListAsync(
        string id,
        ListOrganizationConnectionsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Enable a specific connection for a given Organization. To enable a connection, it must already exist within your tenant; connections cannot be created through this action.
    ///
    /// <a href="https://auth0.com/docs/authenticate/identity-providers">Connections</a> represent the relationship between Auth0 and a source of users. Available types of connections include database, enterprise, and social.
    /// </summary>
    WithRawResponseTask<AddOrganizationConnectionResponseContent> AddAsync(
        string id,
        AddOrganizationConnectionRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details about a specific connection currently enabled for an Organization. Information returned includes details such as connection ID, name, strategy, and whether the connection automatically grants membership upon login.
    /// </summary>
    WithRawResponseTask<GetOrganizationConnectionResponseContent> GetAsync(
        string id,
        string connectionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Disable a specific connection for an Organization. Once disabled, Organization members can no longer use that connection to authenticate.
    ///
    /// <b>Note</b>: This action does not remove the connection from your tenant.
    /// </summary>
    Task DeleteAsync(
        string id,
        string connectionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Modify the details of a specific connection currently enabled for an Organization.
    /// </summary>
    WithRawResponseTask<UpdateOrganizationConnectionResponseContent> UpdateAsync(
        string id,
        string connectionId,
        UpdateOrganizationConnectionRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
