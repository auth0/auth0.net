namespace Auth0.ManagementApi.Clients
{
  using System.Threading;
  using System.Threading.Tasks;
  using Models;

  public interface IEmailTemplatesClient
  {
    /// <summary>
    /// Creates a new email template.
    /// </summary>
    /// <param name="request">The <see cref="EmailTemplateCreateRequest"/> containing details of the template to create.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The newly created <see cref="EmailTemplate"/>.</returns>
    Task<EmailTemplate> CreateAsync(EmailTemplateCreateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets an email template.
    /// </summary>
    /// <param name="templateName">The name of email template you wish to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="EmailTemplate"/> that was requested.</returns>
    Task<EmailTemplate> GetAsync(EmailTemplateName templateName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an email template.
    /// </summary>
    /// <param name="templateName">The name of the email template to update.</param>
    /// <param name="request">The <see cref="EmailTemplatePatchRequest"/> containing details of the template to patch.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The newly updated <see cref="EmailTemplate"/>.</returns>
    Task<EmailTemplate> PatchAsync(EmailTemplateName templateName, EmailTemplatePatchRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an email template.
    /// </summary>
    /// <param name="templateName">The name of the email template to patch.</param>
    /// <param name="request">The <see cref="EmailTemplateUpdateRequest"/> containing details of the template to update.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The newly updated <see cref="EmailTemplate"/>.</returns>
    Task<EmailTemplate> UpdateAsync(EmailTemplateName templateName, EmailTemplateUpdateRequest request, CancellationToken cancellationToken = default);
  }
}
