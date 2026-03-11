using Auth0.ManagementApi;
using Auth0.ManagementApi.Connections.ScimConfiguration;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Connections;

public partial interface IScimConfigurationClient
{
    public ITokensClient Tokens { get; }

    /// <summary>
    /// Retrieve a list of SCIM configurations of a tenant.
    /// </summary>
    Task<Pager<global::Auth0.ManagementApi.ScimConfiguration>> ListAsync(
        ListScimConfigurationsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a scim configuration by its <c>connectionId</c>.
    /// </summary>
    WithRawResponseTask<GetScimConfigurationResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a scim configuration for a connection.
    /// </summary>
    WithRawResponseTask<CreateScimConfigurationResponseContent> CreateAsync(
        string id,
        Optional<CreateScimConfigurationRequestContent?> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a scim configuration by its <c>connectionId</c>.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a scim configuration by its <c>connectionId</c>.
    /// </summary>
    WithRawResponseTask<UpdateScimConfigurationResponseContent> UpdateAsync(
        string id,
        UpdateScimConfigurationRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a scim configuration's default mapping by its <c>connectionId</c>.
    /// </summary>
    WithRawResponseTask<GetScimConfigurationDefaultMappingResponseContent> GetDefaultMappingAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
