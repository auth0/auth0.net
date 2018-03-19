using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /jobs endpoints.
    /// </summary>
    public class JobsClient : ClientBase, IJobsClient
    {
        /// <summary>
        /// Creates a new instance of the ClientBase class.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public JobsClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Gets a job.
        /// </summary>
        /// <param name="id">The ID of the job to retrieve.</param>
        /// <returns>A <see cref="Job" /> instance containing the information about the job.</returns>
        /// <remarks>This is useful to check the status of a job.</remarks>
        public Task<Job> GetAsync(string id)
        {
            return Connection.GetAsync<Job>("jobs/{id}",
                new Dictionary<string, string>
                {
                    {"id", id}
                },
                null, null, null);
        }

        /// <summary>
        /// Imports users to a connection from a file using a long running job.
        /// </summary>
        /// <param name="connectionId">The connection identifier.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="file">The file.</param>
        /// <param name="upsert">Update the user if already exists</param>
        /// <param name="externalId">Customer defined id</param>
        /// <returns>Task&lt;Job&gt;.</returns>
        /// <remarks>The documentation for the file format is <a href="https://auth0.com/docs/bulk-import">here</a>.</remarks>
        public Task<Job> ImportUsersAsync(string connectionId, string fileName, Stream file, bool? upsert = null, string externalId = null)
        {
            var parameters = new Dictionary<string, object>
            {
                { "connection_id", connectionId },
                { "upsert", upsert },
                { "external_id", externalId }
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

            return Connection.PostAsync<Job>("jobs/users-imports", null, parameters, fileParameters, null, null, null);
        }

        /// <summary>
        /// Send an email to the specified user that asks them to click a link to verify their email address.
        /// </summary>
        /// <param name="request">The <see cref="VerifyEmailJobRequest" /> containing the information of the user whose email you want verified.</param>
        /// <returns>A <see cref="Job" /> instance containing the information about the job.</returns>
        public Task<Job> SendVerificationEmailAsync(VerifyEmailJobRequest request)
        {
            return Connection.PostAsync<Job>("jobs/verification-email", request, null, null, null, null, null);
        }
    }
}