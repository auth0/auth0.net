using Auth0.ManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Auth0.Core.Http;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /guardian endpoints.
    /// </summary>
    public class GuardianClient : BaseClient, IGuardianClient
    {
        /// <summary>
        /// Initializes a new instance of <see cref="GuardianClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
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
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="CreateGuardianEnrollmentTicketResponse" /> with the details of the ticket that was created.</returns>
        public Task<CreateGuardianEnrollmentTicketResponse> CreateEnrollmentTicketAsync(CreateGuardianEnrollmentTicketRequest request, CancellationToken cancellationToken = default)
        {
            return Connection
                .SendAsync<CreateGuardianEnrollmentTicketResponse>(
                HttpMethod.Post,
                BuildUri("guardian/enrollments/ticket"),
                request,
                DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Deletes an enrollment.
        /// </summary>
        /// <param name="id">The ID of the enrollment to delete.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteEnrollmentAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection
                .SendAsync<object>(
                HttpMethod.Delete,
                BuildUri($"guardian/enrollments/{EncodePath(id)}"),
                null,
                DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Retrieves an enrollment.
        /// </summary>
        /// <param name="id">The ID of the enrollment to retrieve.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="GuardianEnrollment"/> containing details of the enrollment.</returns>
        public Task<GuardianEnrollment> GetEnrollmentAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection
                .GetAsync<GuardianEnrollment>(
                BuildUri($"guardian/enrollments/{EncodePath(id)}"),
                DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Retrieves all factors. Useful to check factor enablement and trial status.
        /// </summary>
        /// <returns>List of <see cref="GuardianFactor" /> instances with the available factors.</returns>
        public Task<IList<GuardianFactor>> GetFactorsAsync(CancellationToken cancellationToken = default)
        {
            return Connection
                .GetAsync<IList<GuardianFactor>>(
                BuildUri("guardian/factors"),
                DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Retrieves enrollment and verification templates. You can use it to check the current values for your templates.
        /// </summary>
        /// <returns>A <see cref="GuardianSmsEnrollmentTemplates" /> containing the templates.</returns>
        public Task<GuardianSmsEnrollmentTemplates> GetSmsTemplatesAsync(CancellationToken cancellationToken = default)
        {
            return Connection
                .GetAsync<GuardianSmsEnrollmentTemplates>(
                BuildUri("guardian/factors/sms/templates"),
                DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Returns provider configuration for AWS SNS.
        /// </summary>
        /// <returns>A <see cref="GuardianSnsConfiguration" /> containing Amazon SNS configuration.</returns>
        public Task<GuardianSnsConfiguration> GetSnsConfigurationAsync(CancellationToken cancellationToken = default)
        {
            return Connection
                .GetAsync<GuardianSnsConfiguration>(
                BuildUri("guardian/factors/push-notification/providers/sns"),
                DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Returns configuration for the Guardian Twilio provider.
        /// </summary>
        /// <returns><see cref="GuardianTwilioConfiguration" /> with the Twilio configuration.</returns>
        public Task<GuardianTwilioConfiguration> GetTwilioConfigurationAsync(CancellationToken cancellationToken = default)
        {
            return Connection
                .GetAsync<GuardianTwilioConfiguration>(
                BuildUri("guardian/factors/sms/providers/twilio"),
                DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Enable or Disable a Guardian factor.
        /// </summary>
        /// <param name="request">The <see cref="UpdateGuardianFactorRequest" /> containing the details of the factor to update.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The <see cref="UpdateGuardianFactorResponse" /> indicating the status of the factor.</returns>
        public Task<UpdateGuardianFactorResponse> UpdateFactorAsync(UpdateGuardianFactorRequest request, CancellationToken cancellationToken = default)
        {
            var name = request.Factor.ToEnumString();

            return Connection
                .SendAsync<UpdateGuardianFactorResponse>(
                HttpMethod.Put,
                BuildUri($"guardian/factors/{name}"),
                new { enabled = request.IsEnabled },
                DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Updates enrollment and verification templates. Useful to send custom messages on SMS enrollment and verification.
        /// </summary>
        /// <param name="templates">A <see cref="GuardianSmsEnrollmentTemplates" /> containing the updated templates.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="GuardianSmsEnrollmentTemplates" /> containing the templates.</returns>
        public Task<GuardianSmsEnrollmentTemplates> UpdateSmsTemplatesAsync(GuardianSmsEnrollmentTemplates templates, CancellationToken cancellationToken = default)
        {
            return Connection
                .SendAsync<GuardianSmsEnrollmentTemplates>(
                HttpMethod.Put,
                BuildUri("guardian/factors/sms/templates"),
                templates,
                DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Configure the Guardian Twilio provider.
        /// </summary>
        /// <param name="request">
        /// The <see cref="UpdateGuardianTwilioConfigurationRequest" /> containing the configuration settings.
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The <see cref="GuardianTwilioConfiguration" /> containing the updated configuration settings.</returns>
        public Task<GuardianTwilioConfiguration> UpdateTwilioConfigurationAsync(UpdateGuardianTwilioConfigurationRequest request, CancellationToken cancellationToken = default)
        {
            return Connection
                .SendAsync<GuardianTwilioConfiguration>(
                HttpMethod.Put,
                BuildUri("guardian/factors/sms/providers/twilio"),
                request,
                DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Retrieve the enabled phone factors for multi-factor authentication
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="GuardianPhoneMessageTypes" /> containing the message types.</returns>
        public Task<GuardianPhoneMessageTypes> GetPhoneMessageTypesAsync(CancellationToken cancellationToken = default)
        {
            return Connection
                .GetAsync<GuardianPhoneMessageTypes>(
                    BuildUri("guardian/factors/phone/message-types"),
                    DefaultHeaders,
                    cancellationToken: cancellationToken
                 );
        }

        /// <summary>
        /// Update enabled phone factors for multi-factor authentication
        /// </summary>
        /// <param name="messageTypes">A <see cref="GuardianPhoneMessageTypes" /> containing the list of phone factors to enable on the tenan.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="GuardianPhoneMessageTypes" /> containing the message types.</returns>
        public Task<GuardianPhoneMessageTypes> UpdatePhoneMessageTypesAsync(GuardianPhoneMessageTypes messageTypes, CancellationToken cancellationToken = default)
        {
            return Connection
                .SendAsync<GuardianPhoneMessageTypes>(
                    HttpMethod.Put,
                    BuildUri("guardian/factors/phone/message-types"),
                    messageTypes,
                    DefaultHeaders,
                    cancellationToken: cancellationToken
                );
        }
    }
}
