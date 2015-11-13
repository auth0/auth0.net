using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Models;

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
            return Connection.PostAsync<Job>("jobs/verification-email", request, null);
        }
    }
}