using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Models;

namespace Auth0.Api.Management.Clients
{
    public class EmailsClient : ClientBase, IEmailsClient
    {
        public EmailsClient(IApiConnection connection)
            : base(connection)
        {
        }

        public Task<EmailProvider> Configure(EmailProviderConfigureRequest request)
        {
            return Connection.PostAsync<EmailProvider>("emails/provider", request, null);
        }

        public Task<EmailProvider> Get(string fields = null, bool includeFields = true)
        {
            return Connection.GetAsync<EmailProvider>("emails/provider",
                null,
                new Dictionary<string, string>
                {
                    {"fields", fields},
                    {"include_fields", includeFields.ToString().ToLower()}
                });
        }

        public Task<EmailProvider> Update(EmailProviderUpdateRequest request)
        {
            return Connection.PatchAsync<EmailProvider>("emails/provider", request, null);
        }

        public Task Delete()
        {
            return Connection.DeleteAsync<object>("emails/provider", null);
        }
    }
}