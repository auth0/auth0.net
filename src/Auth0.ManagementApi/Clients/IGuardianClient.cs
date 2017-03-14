using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    public interface IGuardianClient
    {
        /// <summary>
        /// Generate an email with a link to start the Guardian enrollment process.
        /// </summary>
        /// <param name="request">The <see cref="CreateGuardianEnrollmentTicketRequest"/> containing the information about the user who should be enrolled.</param>
        /// <returns>A <see cref="CreateGuardianEnrollmentTicketResponse"/> with the details of the ticket that was created.</returns>
        Task<CreateGuardianEnrollmentTicketResponse> CreateEnrollmentTicket(
            CreateGuardianEnrollmentTicketRequest request);

        /// <summary>
        ///     Deletes an enrollment.
        /// </summary>
        /// <param name="id">The ID of the enrollment.</param>
        /// <returns></returns>
        Task DeleteEnrollment(string id);

        /// <summary>
        ///     Retrieves an enrollment.
        /// </summary>
        /// <param name="id">The ID of the enrollment.</param>
        /// <returns></returns>
        Task<GuardianEnrollment> GetEnrollment(string id);

        /// <summary>
        ///     Retrieves all factors. Useful to check factor enablement and trial status.
        /// </summary>
        /// <returns>List of <see cref="GuardianFactor" /> with the available factors.</returns>
        Task<IList<GuardianFactor>> GetFactorsAsync();

        /// <summary>
        ///     Retrieves enrollment and verification templates. You can use it to check the current values for your templates.
        /// </summary>
        /// <returns>A <see cref="GuardianSmsEnrollmentTemplates" /> containing the templates.</returns>
        Task<GuardianSmsEnrollmentTemplates> GetSmsTemplates();

        /// <summary>
        ///     Updates enrollment and verification templates. Useful to send custom messages on SMS enrollment and verification.
        /// </summary>
        /// <param name="templates">A <see cref="GuardianSmsEnrollmentTemplates" /> containing the updated templates.</param>
        /// <returns>A <see cref="GuardianSmsEnrollmentTemplates" /> containing the templates.</returns>
        Task<GuardianSmsEnrollmentTemplates> UpdateSmsTemplates(GuardianSmsEnrollmentTemplates templates);
    }
}