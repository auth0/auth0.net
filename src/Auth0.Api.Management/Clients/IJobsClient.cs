using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auth0.Core.Models;
using PortableRest.Extensions;

namespace Auth0.Api.Management.Clients
{
    public interface IJobsClient
    {
        /// <summary>
        /// Gets a job.
        /// </summary>
        /// <remarks>
        /// This is useful to check the status of a job.
        /// </remarks>
        /// <param name="id">The ID of the job to retrieve.</param>
        /// <returns>A <see cref="Job"/> instance containing the information about the job.</returns>
        Task<Job> Get(string id);

        /// <summary>
        /// Send an email to the specified user that asks them to click a link to verify their email address.
        /// </summary>
        /// <param name="request">The <see cref="VerifyEmailJobRequest"/> containing the information of the user whose email you want verified.</param>
        /// <returns>A <see cref="Job"/> instance containing the information about the job.</returns>
        Task<Job> SendVerificationEmail(VerifyEmailJobRequest request);

        Task<Job> ImportUsers(string connectionId, string fileName, Stream file);
    }
}