using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <inheritdoc />
    public class GuardianClient : ClientBase, IGuardianClient
    {
        /// <summary>
        /// Creates a new instance of <see cref="GuardianClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public GuardianClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <inheritdoc />
        public Task<CreateGuardianEnrollmentTicketResponse> CreateEnrollmentTicketAsync(CreateGuardianEnrollmentTicketRequest request)
        {
            return Connection
                .PostAsync<CreateGuardianEnrollmentTicketResponse>(
                "guardian/enrollments/ticket",
                request,
                null, null, null, null, null);
        }

        /// <inheritdoc />
        public Task DeleteEnrollmentAsync(string id)
        {
            return Connection
                .DeleteAsync<object>(
                "guardian/enrollments/{id}",
                new Dictionary<string, string> { { "id", id } },
                null);
        }

        /// <inheritdoc />
        public Task<GuardianEnrollment> GetEnrollmentAsync(string id)
        {
            return Connection
                .GetAsync<GuardianEnrollment>(
                "guardian/enrollments/{id}",
                new Dictionary<string, string> { { "id", id } },
                null, null, null);
        }

        /// <inheritdoc />
        public Task<IList<GuardianFactor>> GetFactorsAsync()
        {
            return Connection
                .GetAsync<IList<GuardianFactor>>(
                "guardian/factors",
                null, null, null, null);
        }

        /// <inheritdoc />
        public Task<GuardianSmsEnrollmentTemplates> GetSmsTemplatesAsync()
        {
            return Connection
                .GetAsync<GuardianSmsEnrollmentTemplates>(
                "guardian/factors/sms/templates",
                null, null, null, null);
        }

        /// <inheritdoc />
        public Task<GuardianSnsConfiguration> GetSnsConfigurationAsync()
        {
            return Connection
                .GetAsync<GuardianSnsConfiguration>(
                "guardian/factors/push-notification/providers/sns",
                null, null, null, null);
        }

        /// <inheritdoc />
        public Task<GuardianTwilioConfiguration> GetTwilioConfigurationAsync()
        {
            return Connection
                .GetAsync<GuardianTwilioConfiguration>(
                "guardian/factors/sms/providers/twilio",
                null, null, null, null);
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public Task<GuardianSmsEnrollmentTemplates> UpdateSmsTemplatesAsync(GuardianSmsEnrollmentTemplates templates)
        {
            return Connection
                .PutAsync<GuardianSmsEnrollmentTemplates>(
                "guardian/factors/sms/templates",
                templates,
                null, null, null, null, null);
        }

        /// <inheritdoc />
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