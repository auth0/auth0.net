using Auth0.ManagementApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /jobs endpoints.
    /// </summary>
    public class JobsClient : BaseClient, IJobsClient
    {
        /// <summary>
        /// Initializes a new instance on <see cref="JobsClient"/>
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
        public JobsClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
            : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <summary>
        /// Gets a job.
        /// </summary>
        /// <remarks>
        /// This is useful to check the status of a job.
        /// </remarks>
        /// <param name="id">The ID of the job to retrieve.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Job"/> instance containing the information about the job.</returns>
        public Task<Job> GetAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<Job>(BuildUri($"jobs/{EncodePath(id)}"), DefaultHeaders, cancellationToken: cancellationToken);
        }

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
        public Task<Job> ImportUsersAsync(string connectionId, string fileName, Stream file, bool? upsert = null, string externalId = null, bool? sendCompletionEmail = null, CancellationToken cancellationToken = default)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            var parameters = new Dictionary<string, object>
            {
                { "connection_id", connectionId },
                { "upsert", upsert },
                { "external_id", externalId },
                { "send_completion_email", sendCompletionEmail }
            };

            var fileParameters = new List<FileUploadParameter>
            {
                new FileUploadParameter
                {
                    Key = "users",
                    Filename = fileName,
                    FileStream = file
                }
            };

            return Connection.SendAsync<Job>(HttpMethod.Post, BuildUri("jobs/users-imports"), parameters, DefaultHeaders, files: fileParameters, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Exports users from a connection to a file using a long running job.
        /// </summary>
        /// <remarks>
        /// The documentation for user exports can be found <a href="https://auth0.com/docs/users/bulk-user-exports">here</a>.
        /// </remarks>
        /// <param name="request">The <see cref="UsersExportsJobRequest"/> containing the information for the job to export users.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Job"/> instance containing the information about the job.</returns>
        public Task<Job> ExportUsersAsync(UsersExportsJobRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<Job>(HttpMethod.Post, BuildUri("jobs/users-exports"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Send an email to the specified user that asks them to click a link to verify their email address.
        /// </summary>
        /// <param name="request">The <see cref="VerifyEmailJobRequest"/> containing the information of the user whose email you want verified.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Job"/> instance containing the information about the job.</returns>
        public Task<Job> SendVerificationEmailAsync(VerifyEmailJobRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<Job>(HttpMethod.Post, BuildUri("jobs/verification-email"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }
    }
}
