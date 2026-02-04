using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Jobs;

public partial interface IUsersExportsClient
{
    /// <summary>
    /// Export all users to a file via a long-running job.
    /// </summary>
    WithRawResponseTask<CreateExportUsersResponseContent> CreateAsync(
        CreateExportUsersRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
