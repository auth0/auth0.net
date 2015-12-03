using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core;
using Auth0.Core.Http;
using Auth0.ManagementApi.Client.Models;

namespace Auth0.ManagementApi.Client.Clients
{
    public class TentantSettingsClient : ClientBase, ITentantSettingsClient
    {
        public TentantSettingsClient(IApiConnection connection)
            : base(connection)
        {
        }

        public Task<TenantSettings> Get(string fields = null, bool includeFields = true)
        {
            return Connection.GetAsync<TenantSettings>("tenants/settings",
                null,
                new Dictionary<string, string>
                {
                    {"fields", fields},
                    {"include_fields", includeFields.ToString().ToLower()}
                }, null);
        }

        public Task<TenantSettings> Update(TenantSettingsUpdateRequest request)
        {
            return Connection.PatchAsync<TenantSettings>("tenants/settings", request, null);
        }
    }
}