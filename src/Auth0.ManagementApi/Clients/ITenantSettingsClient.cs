namespace Auth0.ManagementApi.Clients
{
  using System.Threading;
  using System.Threading.Tasks;
  using Models;

  public interface ITenantSettingsClient
  {
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
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="TenantSettings" /> containing the settings for the tenant.</returns>
    Task<TenantSettings> GetAsync(string fields = null, bool includeFields = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the settings for the tenant.
    /// </summary>
    /// <param name="request">
    /// <see cref="TenantSettingsUpdateRequest" /> containing the settings for the tenant which are to be updated.
    /// </param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="TenantSettings" /> containing the updated settings for the tenant.</returns>
    Task<TenantSettings> UpdateAsync(TenantSettingsUpdateRequest request, CancellationToken cancellationToken = default);
  }
}
