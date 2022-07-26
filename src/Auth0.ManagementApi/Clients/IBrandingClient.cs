namespace Auth0.ManagementApi.Clients
{
  using System.Threading;
  using System.Threading.Tasks;
  using Models;

  public interface IBrandingClient
  {
    /// <summary>
    /// Retrieves branding settings for a tenant.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Branding"/> containing the branding for the tenant.</returns>
    Task<Branding> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>s
    /// Updates the branding for a tenant.
    /// </summary>
    /// <param name="request">A <see cref="BrandingUpdateRequest" /> containing the branding information to update.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The newly updated <see cref="Branding"/>.</returns>
    Task<Branding> UpdateAsync(BrandingUpdateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the template for the New Universal Login Experience.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="UniversalLoginTemplate"/> for the new universal login experience.</returns>
    Task<UniversalLoginTemplate> GetUniversalLoginTemplateAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete the template for the New Universal Login Experience
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
    Task DeleteUniversalLoginTemplateAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Sets the template for the New Universal Login Experience.
    /// </summary>
    /// <param name="request">The <see cref="UniversalLoginTemplateUpdateRequest"/> containing details of the template to set.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The newly updated <see cref="UniversalLoginTemplate"/>.</returns>
    Task<UniversalLoginTemplate> SetUniversalLoginTemplateAsync(UniversalLoginTemplateUpdateRequest request, CancellationToken cancellationToken = default);
  }
}
