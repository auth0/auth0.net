using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Models
{
    public interface IGuardianClient
    {
        /// <summary>
        ///     Generate an email with a link to start the Guardian enrollment process.
        /// </summary>
        /// <param name="request">
        ///     The <see cref="CreateGuardianEnrollmentTicketRequest" /> containing the information about the
        ///     user who should be enrolled.
        /// </param>
        /// <returns>A <see cref="CreateGuardianEnrollmentTicketResponse" /> with the details of the ticket that was created.</returns>
        Task<CreateGuardianEnrollmentTicketResponse> CreateEnrollmentTicketAsync(
            CreateGuardianEnrollmentTicketRequest request);

        /// <summary>
        ///     Deletes an enrollment.
        /// </summary>
        /// <param name="id">The ID of the enrollment.</param>
        /// <returns></returns>
        Task DeleteEnrollmentAsync(string id);

        /// <summary>
        ///     Retrieves an enrollment.
        /// </summary>
        /// <param name="id">The ID of the enrollment.</param>
        /// <returns></returns>
        Task<GuardianEnrollment> GetEnrollmentAsync(string id);

        /// <summary>
        ///     Retrieves all factors. Useful to check factor enablement and trial status.
        /// </summary>
        /// <returns>List of <see cref="GuardianFactor" /> with the available factors.</returns>
        Task<IList<GuardianFactor>> GetFactorsAsync();

        /// <summary>
        ///     Retrieves enrollment and verification templates. You can use it to check the current values for your templates.
        /// </summary>
        /// <returns>A <see cref="GuardianSmsEnrollmentTemplates" /> containing the templates.</returns>
        Task<GuardianSmsEnrollmentTemplates> GetSmsTemplatesAsync();

        /// <summary>
        ///     Returns provider configuration for AWS SNS
        /// </summary>
        /// <returns>A <see cref="GuardianSnsConfiguration" /> containing Amazon SNS configuration.</returns>
        Task<GuardianSnsConfiguration> GetSnsConfigurationAsync();

        /// <summary>
        ///     Returns configuration for the Guardian Twilio provider.
        /// </summary>
        /// <returns><see cref="GuardianTwilioConfiguration" /> with the Twilio configuration.</returns>
        Task<GuardianTwilioConfiguration> GetTwilioConfigurationAsync();

        /// <summary>
        ///     Enable or Disable a Guardian factor.
        /// </summary>
        /// <param name="request">The <see cref="UpdateGuardianFactorRequest" /> containing the details of the factor to update.</param>
        /// <returns>The <see cref="UpdateGuardianFactorResponse" /> indicating the status of the factor.</returns>
        Task<UpdateGuardianFactorResponse> UpdateFactorAsync(UpdateGuardianFactorRequest request);

        /// <summary>
        ///     Updates enrollment and verification templates. Useful to send custom messages on SMS enrollment and verification.
        /// </summary>
        /// <param name="templates">A <see cref="GuardianSmsEnrollmentTemplates" /> containing the updated templates.</param>
        /// <returns>A <see cref="GuardianSmsEnrollmentTemplates" /> containing the templates.</returns>
        Task<GuardianSmsEnrollmentTemplates> UpdateSmsTemplatesAsync(GuardianSmsEnrollmentTemplates templates);

        /// <summary>
        ///     Updates provider configuration for Amazon SNS.
        /// </summary>
        /// <param name="request">The <see cref="UpdateGuardianSnsConfigurationRequest" /> containing Amazon SNS configuration.</param>
        /// <returns><see cref="GuardianSnsConfiguration" /> with updated Amazon SNS configuration.</returns>
        Task<GuardianSnsConfiguration> UpdateSnsConfigurationAsync(UpdateGuardianSnsConfigurationRequest request);

        /// <summary>
        ///     Configure the Guardian Twilio provider.
        /// </summary>
        /// <param name="request">
        ///     The <see cref="UpdateGuardianTwilioConfigurationRequest" /> containing the configuration
        ///     settings.
        /// </param>
        /// <returns>The <see cref="GuardianTwilioConfiguration" /> containing the updated configuration settings.</returns>
        Task<GuardianTwilioConfiguration> UpdateTwilioConfigurationAsync(
            UpdateGuardianTwilioConfigurationRequest request);
    }
}