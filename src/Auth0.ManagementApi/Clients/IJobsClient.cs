using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using Auth0.Core;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /jobs endpoints.
    /// </summary>
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
        Task<Job> GetAsync(string id);

        /// <summary>
        /// Imports users to a connection from a file using a long running job. 
        /// </summary>
        /// <remarks>
        /// The documentation for the file format is <a href="https://auth0.com/docs/bulk-import">here</a>.
        /// </remarks>
        /// <param name="connectionId">The connection identifier.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="file">The file.</param>
        /// <returns>Task&lt;Job&gt;.</returns>
        Task<Job> ImportUsersAsync(string connectionId, string fileName, Stream file);

        /// <summary>
        /// Send an email to the specified user that asks them to click a link to verify their email address.
        /// </summary>
        /// <param name="request">The <see cref="VerifyEmailJobRequest"/> containing the information of the user whose email you want verified.</param>
        /// <returns>A <see cref="Job"/> instance containing the information about the job.</returns>
        Task<Job> SendVerificationEmailAsync(VerifyEmailJobRequest request);

        #region Obsolete Methods
#pragma warning disable 1591

        [Obsolete("Use GetAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task<Job> Get(string id);

        [Obsolete("Use ImportUsersAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task<Job> ImportUsers(string connectionId, string fileName, Stream file);

        [Obsolete("Use SendVerificationEmailAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task<Job> SendVerificationEmail(VerifyEmailJobRequest request);

#pragma warning restore 1591
        #endregion
    }
}