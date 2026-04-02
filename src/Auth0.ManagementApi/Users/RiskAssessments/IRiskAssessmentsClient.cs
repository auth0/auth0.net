using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Users;

public partial interface IRiskAssessmentsClient
{
    /// <summary>
    /// Clear risk assessment assessors for a specific user
    /// </summary>
    Task ClearAsync(
        string id,
        ClearAssessorsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
