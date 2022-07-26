namespace Auth0.ManagementApi.Clients
{
  using System.IO;
  using System.Threading;
  using System.Threading.Tasks;
  using Models;

  public interface IJobsClient
  {
    /// <summary>
    /// Gets a job.
    /// </summary>
    /// <remarks>
    /// This is useful to check the status of a job.
    /// </remarks>
    /// <param name="id">The ID of the job to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Job"/> instance containing the information about the job.</returns>
    Task<Job> GetAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Imports users to a connection from a file using a long running job. 
    /// </summary>
    /// <remarks>
    /// The documentation for the file format is <a href="https://auth0.com/docs/bulk-import">here</a>.
    /// </remarks>
    /// <param name="connectionId">The connection identifier.</param>
    /// <param name="fileName">Name of the file.</param>
    /// <param name="file">The file.</param>
    /// <param name="upsert">Whether to update the user if already exists.</param>
    /// <param name="externalId">Customer-defined id.</param>
    /// <param name="sendCompletionEmail">Whether to send the user an email on import completion (true) or not (false).</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Job"/> instance containing the information about the job.</returns>
    Task<Job> ImportUsersAsync(string connectionId, string fileName, Stream file, bool? upsert = null, string externalId = null, bool? sendCompletionEmail = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Exports users from a connection to a file using a long running job. 
    /// </summary>
    /// <remarks>
    /// The documentation for user exports can be found <a href="https://auth0.com/docs/users/bulk-user-exports">here</a>.
    /// </remarks>
    /// <param name="request">The <see cref="UsersExportsJobRequest"/> containing the information for the job to export users.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Job"/> instance containing the information about the job.</returns>
    Task<Job> ExportUsersAsync(UsersExportsJobRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send an email to the specified user that asks them to click a link to verify their email address.
    /// </summary>
    /// <param name="request">The <see cref="VerifyEmailJobRequest"/> containing the information of the user whose email you want verified.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Job"/> instance containing the information about the job.</returns>
    Task<Job> SendVerificationEmailAsync(VerifyEmailJobRequest request, CancellationToken cancellationToken = default);
  }
}
