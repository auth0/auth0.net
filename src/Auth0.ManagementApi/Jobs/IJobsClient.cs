using Auth0.ManagementApi.Jobs;

namespace Auth0.ManagementApi;

public partial interface IJobsClient
{
    public IUsersExportsClient UsersExports { get; }
    public IUsersImportsClient UsersImports { get; }
    public IVerificationEmailClient VerificationEmail { get; }
    public IErrorsClient Errors { get; }

    /// <summary>
    /// Retrieves a job. Useful to check its status.
    /// </summary>
    WithRawResponseTask<GetJobResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
