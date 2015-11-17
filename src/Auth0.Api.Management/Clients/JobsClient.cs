using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Auth0.Api.Management.Models;
using Auth0.Core.Models;
using PortableRest;

namespace Auth0.Api.Management.Clients
{
    public class JobsClient : ClientBase, IJobsClient
    {
        public JobsClient(IApiConnection connection)
            : base(connection)
        {
        }

        public Task<Job> Get(string id)
        {
            return Connection.GetAsync<Job>("jobs/{id}",
                new Dictionary<string, string>
                {
                    {"id", id}
                },
                null);
        }

        public Task<Job> SendVerificationEmail(VerifyEmailJobRequest request)
        {
            return Connection.PostAsync<Job>("jobs/verification-email", ContentTypes.Json, request, null, null, null, null);
        }

        public Task<Job> ImportUsers(string connectionId, string fileName, Stream file)
        {
            var parameters = new Dictionary<string, object>
            {
                { "connection_id", connectionId }
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

            return Connection.PostAsync<Job>("jobs/users-imports", ContentTypes.MultiPartFormData, null, parameters, fileParameters, null, null);
        }
    }
}