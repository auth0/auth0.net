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
    
    /// <summary>
    /// Send a test phone notification for the configured provider
    /// </summary>
    /// <param name="id">ID of the <see cref="BrandingPhoneProvider"/></param>
    /// <param name="request">
    /// <see cref="BrandingPhoneTestNotificationRequest"/> containing information on whom to send the notification to.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="BrandingPhoneTestNotificationResponse"/></returns>
    Task<BrandingPhoneTestNotificationResponse> SendBrandingPhoneTestNotificationAsync(string id, BrandingPhoneTestNotificationRequest request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Get a list of phone notification templates
    /// </summary>
    /// <param name="request"><see cref="BrandingPhoneNotificationTemplatesGetRequest"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="IList{T}"/> of <see cref="BrandingPhoneNotificationTemplate"/></returns>
    Task<IList<BrandingPhoneNotificationTemplate>> GetAllBrandingPhoneNotificationTemplatesAsync(BrandingPhoneNotificationTemplatesGetRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a phone notification template
    /// </summary>
    /// <param name="request"><see cref="BrandingPhoneNotificationTemplateCreateRequest"/> containing information on the template to be created</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Newly created <see cref="BrandingPhoneNotificationTemplate"/></returns>
    Task<BrandingPhoneNotificationTemplate> CreateBrandingPhoneNotificationTemplateAsync(BrandingPhoneNotificationTemplateCreateRequest request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Get a phone notification template
    /// </summary>
    /// <param name="id">ID of the <see cref="BrandingPhoneNotificationTemplate"/></param>
    /// <param name="cancellationToken"></param>
    /// <returns><see cref="BrandingPhoneNotificationTemplate"/></returns>
    Task<BrandingPhoneNotificationTemplate> GetBrandingPhoneNotificationTemplateAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete a phone notification template
    /// </summary>
    /// <param name="id">ID of the <see cref="BrandingPhoneNotificationTemplate"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task DeleteBrandingPhoneNotificationTemplateAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update a phone notification template
    /// </summary>
    /// <param name="id">ID of the Notification Template to be updated</param>
    /// <param name="request"><see cref="BrandingPhoneNotificationTemplateUpdateRequest"/> containing information to be updated</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Updated <see cref="BrandingPhoneNotificationTemplate"/></returns>
    Task<BrandingPhoneNotificationTemplate> UpdateBrandingPhoneNotificationTemplate(string id, BrandingPhoneNotificationTemplateUpdateRequest request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Resets a phone notification template values
    /// </summary>
    /// <param name="id">ID of the Notification Template to be reset</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Updated <see cref="BrandingPhoneNotificationTemplate"/></returns>
    Task<BrandingPhoneNotificationTemplate> ResetBrandingPhoneNotificationTemplate(string id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Send a test phone notification for the configured template
    /// </summary>
    /// <param name="id">Id of the Branding Phone Notification Template</param>
    /// <param name="request"><see cref="BrandingPhoneTestNotificationRequest"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="BrandingPhoneTestNotificationResponse"/></returns>
    Task<BrandingPhoneTestNotificationResponse> SendBrandingPhoneTemplateTestNotificationAsync(string id, BrandingPhoneTestNotificationRequest request, CancellationToken cancellationToken = default);
  }
}
