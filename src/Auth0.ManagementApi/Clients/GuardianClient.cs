using System;
using System.Collections.Generic;
using System.Text;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    public class GuardianClient : ClientBase, IGuardianClient
    {
        public GuardianClient(IApiConnection connection) : base(connection)
        {
        }

        public Task DeleteEnrollment(string id)
        {
            return Connection.DeleteAsync<object>("guardian/enrollments/{id}", new Dictionary<string, string> {{"id", id}}, null);
        }

        public Task<GuardianEnrollment> GetEnrollment(string id)
        {
            return Connection.GetAsync<GuardianEnrollment>("guardian/enrollments/{id}",
                new Dictionary<string, string> {{"id", id}}, null, null, null);
        }

        public Task<IList<GuardianFactor>> GetFactorsAsync()
        {
            return Connection.GetAsync<IList<GuardianFactor>>("guardian/factors", null, null, null, null);
        }

        public Task<GuardianSmsEnrollmentTemplates> GetSmsTemplates()
        {
            return Connection.GetAsync<GuardianSmsEnrollmentTemplates>("guardian/factors/sms/templates", null, null, null, null);
        }

        public Task<GuardianSmsEnrollmentTemplates> UpdateSmsTemplates(GuardianSmsEnrollmentTemplates templates)
        {
            return Connection.PutAsync<GuardianSmsEnrollmentTemplates>("guardian/factors/sms/templates", templates, null,
                null, null, null, null);
        }
    }
}
