using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Connections.DirectoryProvisioning;

public partial interface ISynchronizationsClient
{
    /// <summary>
    /// Request an on-demand synchronization of the directory.
    /// </summary>
    WithRawResponseTask<CreateDirectorySynchronizationResponseContent> CreateAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
