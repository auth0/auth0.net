using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /tenants/settings endpoints.
    /// </summary>
    public class TenantSettingsClient : ClientBase
    {
        /// <summary>
        /// Creates a new instance of <see cref="TenantSettingsClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public TenantSettingsClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Gets the settings for the tenant.
        /// </summary>
        /// <param name="fields">
        /// A comma separated list of fields to include or exclude (depending on includeFields) from the
        /// result, empty to retrieve all fields
        /// </param>
        /// <param name="includeFields">
        /// <see cref="true"/> if the fields specified are to be included in the result, <see cref="false"/> otherwise (defaults to
        /// <see cref="true"/>)
        /// </param>
        /// <returns>A <see cref="TenantSettings" /> containing the settings for the tenant.</returns>
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

        /// <summary>
        /// Updates the settings for the tenant.
        /// </summary>
        /// <param name="request">
        /// A <see cref="TenantSettingsUpdateRequest" /> containing the settings for the tenant which are to be updated.
        /// </param>
        /// <returns>A <see cref="TenantSettings" /> containing the updated settings for the tenant.</returns>
        public Task<TenantSettings> UpdateAsync(TenantSettingsUpdateRequest request)
        {
            return Connection.PatchAsync<TenantSettings>("tenants/settings", request, null);
        }
    }
}