using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /tenants/settings endpoints.
    /// </summary>
    public class TenantSettingsClient : ClientBase, ITenantSettingsClient
    {
        /// <summary>
        /// Creates a new instance of <see cref="TenantSettingsClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public TenantSettingsClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <inheritdoc />
        public Task<TenantSettings> GetAsync(string fields = null, bool includeFields = true)
        {
            return Connection.GetAsync<TenantSettings>("tenants/settings",
                null,
                new Dictionary<string, string>
                {
                    {"fields", fields},
                    {"include_fields", includeFields.ToString().ToLower()}
                }, null, null);
        }

        /// <inheritdoc />
        public Task<TenantSettings> UpdateAsync(TenantSettingsUpdateRequest request)
        {
            return Connection.PatchAsync<TenantSettings>("tenants/settings", request, null);
        }
    }
}