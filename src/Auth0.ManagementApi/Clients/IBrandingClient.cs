using System.Collections.Generic;

namespace Auth0.ManagementApi.Clients
{
  using System.Threading;
  using System.Threading.Tasks;
  using Models;

  public interface IBrandingClient
  {
    /// <summary>
    /// Retrieve branding settings.
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
    
    /// <summary>
    /// Retrieve a list of
    /// <a href="https://auth0.com/docs/phone/providers"> phone providers </a>
    /// details set for a Tenant. A list of fields to include or exclude may also be specified.
    /// </summary>
    /// <param name="request"><see cref="BrandingPhoneProviderGetRequest"/></param>
    /// <param name="cancellationToken"></param>
    /// <returns>List of <see cref="BrandingPhoneProvider"/>s</returns>
    Task<IList<BrandingPhoneProvider> > GetAllPhoneProvidersAsync(BrandingPhoneProviderGetRequest request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Create a
    /// <a href="https://auth0.com/docs/phone/providers"> phone provider </a>.
    /// The credentials object requires different properties depending on the phone provider
    /// (which is specified using the name property).
    /// </summary>
    /// <param name="request"><see cref="BrandingPhoneProviderCreateRequest"/> containing information required to create a <see cref="BrandingPhoneProvider"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>The newly created <see cref="BrandingPhoneProvider"/></returns>
    Task<BrandingPhoneProvider> CreatePhoneProviderAsync(BrandingPhoneProviderCreateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve <a href="https://auth0.com/docs/phone/providers"> phone provider </a>details.
    /// A list of fields to include or exclude may also be specified.
    /// </summary>
    /// <param name="id">ID of the <see cref="BrandingPhoneProvider"/> to be retrieved.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="BrandingPhoneProvider"/></returns>
    Task<BrandingPhoneProvider> GetPhoneProviderAsync(string id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Delete the configured phone provider.
    /// </summary>
    /// <param name="id">ID of the <see cref="BrandingPhoneProvider"/> to delete</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task DeletePhoneProviderAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update a
    /// <a href="https://auth0.com/docs/phone/providers"> phone provider </a>.
    /// The credentials object requires different properties depending on the email provider
    /// (which is specified using the name property).
    /// </summary>
    /// <param name="id">ID of the <see cref="BrandingPhoneProvider"/> to update</param>
    /// <param name="request">A <see cref="BrandingPhoneProviderUpdateRequest"/> containing the information to update</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Updated <see cref="BrandingPhoneProvider"/></returns>
    Task<BrandingPhoneProvider> UpdatePhoneProviderAsync(string id, BrandingPhoneProviderUpdateRequest request, CancellationToken cancellationToken = default);
  }
}
