using System.Threading.Tasks;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /tenants/settings endpoints.
    /// </summary>
    public interface ITenantSettingsClient
    {
        /// <summary>
        ///     Gets the settings for the tenant.
        /// </summary>
        /// <param name="fields">
        ///     A comma separated list of fields to include or exclude (depending on includeFields) from the
        ///     result, empty to retrieve all fields
        /// </param>
        /// <param name="includeFields">
        ///     true if the fields specified are to be included in the result, false otherwise (defaults to
        ///     true)
        /// </param>
        /// <returns>A <see cref="TenantSettings" /> containing the settings for the tenant.</returns>
        Task<TenantSettings> GetAsync(string fields = null, bool includeFields = true);

        /// <summary>
        ///     Updates the settings for the tenant.
        /// </summary>
        /// <param name="request">
        ///     A <see cref="TenantSettingsUpdateRequest" /> containing the settings for the tenant which are to
        ///     be updated.
        /// </param>
        /// <returns>A <see cref="TenantSettings" /> containing the updated settings for the tenant.</returns>
        Task<TenantSettings> UpdateAsync(TenantSettingsUpdateRequest request);
    }
}