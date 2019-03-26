using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    public class GuardianClient : ClientBase, IGuardianClient
    {
        public GuardianClient(IApiConnection connection) : base(connection)
        {
        }

        public Task<CreateGuardianEnrollmentTicketResponse> CreateEnrollmentTicketAsync(CreateGuardianEnrollmentTicketRequest request)
        {
            return Connection
                .PostAsync<CreateGuardianEnrollmentTicketResponse>(
                "guardian/enrollments/ticket",
                request,
                null, null, null, null, null);
        }

        public Task DeleteEnrollmentAsync(string id)
        {
            return Connection
                .DeleteAsync<object>(
                "guardian/enrollments/{id}",
                new Dictionary<string, string> { { "id", id } },
                null);
        }

        public Task<GuardianEnrollment> GetEnrollmentAsync(string id)
        {
            return Connection
                .GetAsync<GuardianEnrollment>(
                "guardian/enrollments/{id}",
                new Dictionary<string, string> { { "id", id } },
                null, null, null);
        }

        public Task<IList<GuardianFactor>> GetFactorsAsync()
        {
            return Connection
                .GetAsync<IList<GuardianFactor>>(
                "guardian/factors",
                null, null, null, null);
        }

        public Task<GuardianSmsEnrollmentTemplates> GetSmsTemplatesAsync()
        {
            return Connection
                .GetAsync<GuardianSmsEnrollmentTemplates>(
                "guardian/factors/sms/templates",
                null, null, null, null);
        }

        public Task<GuardianSnsConfiguration> GetSnsConfigurationAsync()
        {
            return Connection
                .GetAsync<GuardianSnsConfiguration>(
                "guardian/factors/push-notification/providers/sns",
                null, null, null, null);
        }

        public Task<GuardianTwilioConfiguration> GetTwilioConfigurationAsync()
        {
            return Connection
                .GetAsync<GuardianTwilioConfiguration>(
                "guardian/factors/sms/providers/twilio",
                null, null, null, null);
        }

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

        public Task<GuardianSmsEnrollmentTemplates> UpdateSmsTemplatesAsync(GuardianSmsEnrollmentTemplates templates)
        {
            return Connection
                .PutAsync<GuardianSmsEnrollmentTemplates>(
                "guardian/factors/sms/templates",
                templates,
                null, null, null, null, null);
        }

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