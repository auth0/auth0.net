using System.Threading.Tasks;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /email-templates endpoints.
    /// </summary>
    public interface IEmailTemplatesClient
    {
        /// <summary>
        /// Creates a new email template
        /// </summary>
        /// <param name="request">The <see cref="EmailTemplateCreateRequest"/> containing details of the template to create</param>
        /// <returns></returns>
        Task<EmailTemplate> CreateAsync(EmailTemplateCreateRequest request);

        /// <summary>
        /// Gets an email template.
        /// </summary>
        /// <param name="templateName">The name of template you wish to retrieve</param>
        /// <returns></returns>
        Task<EmailTemplate> GetAsync(EmailTemplateName templateName);

        /// <summary>
        /// Updates an email template
        /// </summary>
        /// <param name="templateName">The name of the template to update</param>
        /// <param name="request">The <see cref="EmailTemplatePatchRequest"/> containing details of the template to patch</param>
        /// <returns></returns>
        Task<EmailTemplate> PatchAsync(EmailTemplateName templateName, EmailTemplatePatchRequest request);

        /// <summary>
        /// Updates an email template
        /// </summary>
        /// <param name="templateName">The name of the template to patch</param>
        /// <param name="request">The <see cref="EmailTemplateUpdateRequest"/> containing details of the template to update</param>
        /// <returns></returns>
        Task<EmailTemplate> UpdateAsync(EmailTemplateName templateName, EmailTemplateUpdateRequest request);
    }
}