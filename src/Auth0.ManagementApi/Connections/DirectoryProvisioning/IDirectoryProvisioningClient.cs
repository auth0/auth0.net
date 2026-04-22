using Auth0.ManagementApi;
using Auth0.ManagementApi.Connections.DirectoryProvisioning;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Connections;

public partial interface IDirectoryProvisioningClient
{
    public ISynchronizationsClient Synchronizations { get; }

    /// <summary>
    /// Retrieve a list of directory provisioning configurations of a tenant.
    /// </summary>
    Task<Pager<DirectoryProvisioning>> ListAsync(
        ListDirectoryProvisioningsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the directory provisioning configuration of a connection.
    /// </summary>
    WithRawResponseTask<GetDirectoryProvisioningResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a directory provisioning configuration for a connection.
    /// </summary>
    WithRawResponseTask<CreateDirectoryProvisioningResponseContent> CreateAsync(
        string id,
        Optional<CreateDirectoryProvisioningRequestContent?> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete the directory provisioning configuration of a connection.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the directory provisioning configuration of a connection.
    /// </summary>
    WithRawResponseTask<UpdateDirectoryProvisioningResponseContent> UpdateAsync(
        string id,
        Optional<UpdateDirectoryProvisioningRequestContent?> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the directory provisioning default attribute mapping of a connection.
    /// </summary>
    WithRawResponseTask<GetDirectoryProvisioningDefaultMappingResponseContent> GetDefaultMappingAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the configured synchronized groups for a connection directory provisioning configuration.
    /// </summary>
    Task<Pager<SynchronizedGroupPayload>> ListSynchronizedGroupsAsync(
        string id,
        ListSynchronizedGroupsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create or replace the selected groups for a connection directory provisioning configuration.
    /// </summary>
    Task SetAsync(
        string id,
        ReplaceSynchronizedGroupsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
