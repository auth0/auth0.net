using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <inheritdoc />
    public class JobsClient : ClientBase, IJobsClient
    {
        /// <summary>
        /// Creates a new instance on <see cref="JobsClient"/>
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection"/> which is used to communicate with the API.</param>
        public JobsClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <inheritdoc />
        public Task<Job> GetAsync(string id)
        {
            return Connection.GetAsync<Job>("jobs/{id}",
                new Dictionary<string, string>
                {
                    {"id", id}
                },
                null, null, null);
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public Task<Job> SendVerificationEmailAsync(VerifyEmailJobRequest request)
        {
            return Connection.PostAsync<Job>("jobs/verification-email", request, null, null, null, null, null);
        }
    }
}