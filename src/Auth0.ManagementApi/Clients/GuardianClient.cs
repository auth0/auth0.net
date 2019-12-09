using Auth0.ManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /guardian endpoints.
    /// </summary>
    public class GuardianClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of <see cref="GuardianClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders"><see cref="IDictionary{string, string}"/> containing default headers included with every request this client makes.</param>
        public GuardianClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
            : base(connection, baseUri, defaultHeaders)
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
                .SendAsync<CreateGuardianEnrollmentTicketResponse>(
                HttpMethod.Post,
                BuildUri("guardian/enrollments/ticket"),
                request,
                DefaultHeaders);
        }

        /// <summary>
        /// Deletes an enrollment.
        /// </summary>
        /// <param name="id">The ID of the enrollment to delete.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteEnrollmentAsync(string id)
        {
            return Connection
                .SendAsync<object>(
                HttpMethod.Delete,
                BuildUri($"guardian/enrollments/{id}"),
                null,
                DefaultHeaders);
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
                BuildUri($"guardian/enrollments/{id}"),
                DefaultHeaders);
        }

        /// <summary>
        /// Retrieves all factors. Useful to check factor enablement and trial status.
        /// </summary>
        /// <returns>List of <see cref="GuardianFactor" /> instances with the available factors.</returns>
        public Task<IList<GuardianFactor>> GetFactorsAsync()
        {
            return Connection
                .GetAsync<IList<GuardianFactor>>(
                BuildUri("guardian/factors"),
                DefaultHeaders);
        }

        /// <summary>
        /// Retrieves enrollment and verification templates. You can use it to check the current values for your templates.
        /// </summary>
        /// <returns>A <see cref="GuardianSmsEnrollmentTemplates" /> containing the templates.</returns>
        public Task<GuardianSmsEnrollmentTemplates> GetSmsTemplatesAsync()
        {
            return Connection
                .GetAsync<GuardianSmsEnrollmentTemplates>(
                BuildUri("guardian/factors/sms/templates"),
                DefaultHeaders);
        }

        /// <summary>
        /// Returns provider configuration for AWS SNS.
        /// </summary>
        /// <returns>A <see cref="GuardianSnsConfiguration" /> containing Amazon SNS configuration.</returns>
        public Task<GuardianSnsConfiguration> GetSnsConfigurationAsync()
        {
            return Connection
                .GetAsync<GuardianSnsConfiguration>(
                BuildUri("guardian/factors/push-notification/providers/sns"),
                DefaultHeaders);
        }

        /// <summary>
        /// Returns configuration for the Guardian Twilio provider.
        /// </summary>
        /// <returns><see cref="GuardianTwilioConfiguration" /> with the Twilio configuration.</returns>
        public Task<GuardianTwilioConfiguration> GetTwilioConfigurationAsync()
        {
            return Connection
                .GetAsync<GuardianTwilioConfiguration>(
                BuildUri("guardian/factors/sms/providers/twilio"),
                DefaultHeaders);
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
                .SendAsync<UpdateGuardianFactorResponse>(
                HttpMethod.Put,
                BuildUri($"guardian/factors/{name}"),
                new { enabled = request.IsEnabled },
                DefaultHeaders);
        }

        /// <summary>
        /// Updates enrollment and verification templates. Useful to send custom messages on SMS enrollment and verification.
        /// </summary>
        /// <param name="templates">A <see cref="GuardianSmsEnrollmentTemplates" /> containing the updated templates.</param>
        /// <returns>A <see cref="GuardianSmsEnrollmentTemplates" /> containing the templates.</returns>
        public Task<GuardianSmsEnrollmentTemplates> UpdateSmsTemplatesAsync(GuardianSmsEnrollmentTemplates templates)
        {
            return Connection
                .SendAsync<GuardianSmsEnrollmentTemplates>(
                HttpMethod.Put,
                BuildUri("guardian/factors/sms/templates"),
                templates,
                DefaultHeaders);
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
                .SendAsync<GuardianTwilioConfiguration>(
                HttpMethod.Put,
                BuildUri("guardian/factors/sms/providers/twilio"),
                request,
                DefaultHeaders);
        }
    }
}