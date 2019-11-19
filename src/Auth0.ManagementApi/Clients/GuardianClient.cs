using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Interface with all the methods available for /guardian endpoints.
    /// </summary>
    public class GuardianClient : ClientBase
    {
        /// <summary>
        /// Creates a new instance of <see cref="GuardianClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="ILegacyApiConnection" /> which is used to communicate with the API.</param>
        public GuardianClient(ILegacyApiConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Generate an email with a link to start the Guardian enrollment process.
        /// </summary>
        /// <param name="request">
        /// The <see cref="CreateGuardianEnrollmentTicketRequest" /> containing the information about the user who should be enrolled.
        /// </param>
        /// <returns>A <see cref="CreateGuardianEnrollmentTicketResponse" /> with the details of the ticket that was created.</returns>
        public Task<CreateGuardianEnrollmentTicketResponse> CreateEnrollmentTicketAsync(CreateGuardianEnrollmentTicketRequest request)
        {
            return Connection
                .PostAsync<CreateGuardianEnrollmentTicketResponse>(
                "guardian/enrollments/ticket",
                request,
                null, null, null, null, null);
        }

        /// <summary>
        /// Deletes an enrollment.
        /// </summary>
        /// <param name="id">The ID of the enrollment to delete.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteEnrollmentAsync(string id)
        {
            return Connection
                .DeleteAsync<object>(
                "guardian/enrollments/{id}",
                new Dictionary<string, string> { { "id", id } },
                null);
        }

        /// <summary>
        /// Retrieves an enrollment.
        /// </summary>
        /// <param name="id">The ID of the enrollment to retrieve.</param>
        /// <returns>A <see cref="GuardianEnrollment"/> containing details of the enrollment.</returns>
        public Task<GuardianEnrollment> GetEnrollmentAsync(string id)
        {
            return Connection
                .GetAsync<GuardianEnrollment>(
                "guardian/enrollments/{id}",
                new Dictionary<string, string> { { "id", id } },
                null, null, null);
        }

        /// <summary>
        /// Retrieves all factors. Useful to check factor enablement and trial status.
        /// </summary>
        /// <returns>List of <see cref="GuardianFactor" /> instances with the available factors.</returns>
        public Task<IList<GuardianFactor>> GetFactorsAsync()
        {
            return Connection
                .GetAsync<IList<GuardianFactor>>(
                "guardian/factors",
                null, null, null, null);
        }

        /// <summary>
        /// Retrieves enrollment and verification templates. You can use it to check the current values for your templates.
        /// </summary>
        /// <returns>A <see cref="GuardianSmsEnrollmentTemplates" /> containing the templates.</returns>
        public Task<GuardianSmsEnrollmentTemplates> GetSmsTemplatesAsync()
        {
            return Connection
                .GetAsync<GuardianSmsEnrollmentTemplates>(
                "guardian/factors/sms/templates",
                null, null, null, null);
        }

        /// <summary>
        /// Returns provider configuration for AWS SNS.
        /// </summary>
        /// <returns>A <see cref="GuardianSnsConfiguration" /> containing Amazon SNS configuration.</returns>
        public Task<GuardianSnsConfiguration> GetSnsConfigurationAsync()
        {
            return Connection
                .GetAsync<GuardianSnsConfiguration>(
                "guardian/factors/push-notification/providers/sns",
                null, null, null, null);
        }

        /// <summary>
        /// Returns configuration for the Guardian Twilio provider.
        /// </summary>
        /// <returns><see cref="GuardianTwilioConfiguration" /> with the Twilio configuration.</returns>
        public Task<GuardianTwilioConfiguration> GetTwilioConfigurationAsync()
        {
            return Connection
                .GetAsync<GuardianTwilioConfiguration>(
                "guardian/factors/sms/providers/twilio",
                null, null, null, null);
        }

        /// <summary>
        /// Enable or Disable a Guardian factor.
        /// </summary>
        /// <param name="request">The <see cref="UpdateGuardianFactorRequest" /> containing the details of the factor to update.</param>
        /// <returns>The <see cref="UpdateGuardianFactorResponse" /> indicating the status of the factor.</returns>
        public Task<UpdateGuardianFactorResponse> UpdateFactorAsync(UpdateGuardianFactorRequest request)
        {
            var name = request.Factor == GuardianFactorName.PushNotifications ? "push-notification" : "sms";
            return Connection
                .PutAsync<UpdateGuardianFactorResponse>(
                "guardian/factors/{name}",
                new { enabled = request.IsEnabled },
                null, null,
                new Dictionary<string, string> { { "name", name } },
                null, null);
        }

        /// <summary>
        /// Updates enrollment and verification templates. Useful to send custom messages on SMS enrollment and verification.
        /// </summary>
        /// <param name="templates">A <see cref="GuardianSmsEnrollmentTemplates" /> containing the updated templates.</param>
        /// <returns>A <see cref="GuardianSmsEnrollmentTemplates" /> containing the templates.</returns>
        public Task<GuardianSmsEnrollmentTemplates> UpdateSmsTemplatesAsync(GuardianSmsEnrollmentTemplates templates)
        {
            return Connection
                .PutAsync<GuardianSmsEnrollmentTemplates>(
                "guardian/factors/sms/templates",
                templates,
                null, null, null, null, null);
        }

        /// <summary>
        /// Configure the Guardian Twilio provider.
        /// </summary>
        /// <param name="request">
        /// The <see cref="UpdateGuardianTwilioConfigurationRequest" /> containing the configuration settings.
        /// </param>
        /// <returns>The <see cref="GuardianTwilioConfiguration" /> containing the updated configuration settings.</returns>
        public Task<GuardianTwilioConfiguration> UpdateTwilioConfigurationAsync(UpdateGuardianTwilioConfigurationRequest request)
        {
            return Connection
                .PutAsync<GuardianTwilioConfiguration>(
                "guardian/factors/sms/providers/twilio",
                request,
                null, null, null, null, null);
        }
    }
}