using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Jobs;

public partial interface IErrorsClient
{
    /// <summary>
    /// Retrieve error details of a failed job.
    /// </summary>
    WithRawResponseTask<ErrorsGetResponse> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
