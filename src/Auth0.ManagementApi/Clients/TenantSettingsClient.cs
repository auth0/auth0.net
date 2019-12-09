using Auth0.ManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /tenants/settings endpoints.
    /// </summary>
    public class TenantSettingsClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of <see cref="TenantSettingsClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
        public TenantSettingsClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
            : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <summary>
        /// Gets the settings for the tenant.
        /// </summary>
        /// <param name="fields">
        /// A comma-separated list of fields to include or exclude (depending on includeFields) from the
        /// result, empty to retrieve all fields.
        /// </param>
        /// <param name="includeFields">
        /// <see langword="true"/> if the fields specified are to be included in the result, <see langword="false"/> otherwise (defaults to
        /// <see langword="true"/>).
        /// </param>
        /// <returns>A <see cref="TenantSettings" /> containing the settings for the tenant.</returns>
        public Task<TenantSettings> GetAsync(string fields = null, bool includeFields = true)
        {
            return Connection.GetAsync<TenantSettings>(BuildUri("tenants/settings",
                new Dictionary<string, string>
                {
                    {"fields", fields},
                    {"include_fields", includeFields.ToString().ToLower()}
                }), DefaultHeaders);
        }

        /// <summary>
        /// Updates the settings for the tenant.
        /// </summary>
        /// <param name="request">
        /// <see cref="TenantSettingsUpdateRequest" /> containing the settings for the tenant which are to be updated.
        /// </param>
        /// <returns>A <see cref="TenantSettings" /> containing the updated settings for the tenant.</returns>
        public Task<TenantSettings> UpdateAsync(TenantSettingsUpdateRequest request)
        {
            return Connection.SendAsync<TenantSettings>(new HttpMethod("PATCH"), BuildUri("tenants/settings"), request, DefaultHeaders);
        }
    }
}
