using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core;
using PortableRest;
using Auth0.ManagementApi.Client.Models;

namespace Auth0.ManagementApi.Client.Clients
{
    public class EmailProviderClient : ClientBase, IEmailProviderClient
    {
        internal EmailProviderClient(IApiConnection connection)
            : base(connection)
        {
        }

        public Task<EmailProvider> Configure(EmailProviderConfigureRequest request)
        {
            return Connection.PostAsync<EmailProvider>("emails/provider", ContentTypes.Json, request, null, null, null, null, null);
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