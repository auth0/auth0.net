using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

public partial interface IClientGrantsClient
{
    public Auth0.ManagementApi.ClientGrants.IOrganizationsClient Organizations { get; }

    /// <summary>
    /// Retrieve a list of <see href="https://auth0.com/docs/get-started/applications/application-access-to-apis-client-grants">client grants</see>, including the scopes associated with the application/API pair.
    /// </summary>
    Task<Pager<ClientGrantResponseContent>> ListAsync(
        ListClientGrantsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a client grant for a machine-to-machine login flow. To learn more, read <see href="https://www.auth0.com/docs/get-started/authentication-and-authorization-flow/client-credentials-flow">Client Credential Flow</see>.
    /// </summary>
    WithRawResponseTask<CreateClientGrantResponseContent> CreateAsync(
        CreateClientGrantRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a single <see href="https://auth0.com/docs/get-started/applications/application-access-to-apis-client-grants">client grant</see>, including the
    /// scopes associated with the application/API pair.
    /// </summary>
    WithRawResponseTask<GetClientGrantResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete the <see href="https://www.auth0.com/docs/get-started/authentication-and-authorization-flow/client-credentials-flow">Client Credential Flow</see> from your machine-to-machine application.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a client grant.
    /// </summary>
    WithRawResponseTask<UpdateClientGrantResponseContent> UpdateAsync(
        string id,
        UpdateClientGrantRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
