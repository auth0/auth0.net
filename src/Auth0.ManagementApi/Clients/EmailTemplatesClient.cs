using Auth0.ManagementApi.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains allmethods to access the /email-templates endpoints.
    /// </summary>
    public class EmailTemplatesClient : BaseClient
    {
        /// <summary>
        /// Creates a new instance of <see cref="EmailTemplatesClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        public EmailTemplatesClient(IManagementConnection connection, Uri baseUri)
            : base(connection, baseUri)
        {
        }

        /// <summary>
        /// Creates a new email template.
        /// </summary>
        /// <param name="request">The <see cref="EmailTemplateCreateRequest"/> containing details of the template to create.</param>
        /// <returns>The newly created <see cref="EmailTemplate"/>.</returns>
        public Task<EmailTemplate> CreateAsync(EmailTemplateCreateRequest request)
        {
            return Connection.SendAsync<EmailTemplate>(HttpMethod.Post, BuildUri("email-templates"), request, null);
        }

        /// <summary>
        /// Gets an email template.
        /// </summary>
        /// <param name="templateName">The name of email template you wish to retrieve.</param>
        /// <returns>The <see cref="EmailTemplate"/> that was requested.</returns>
        public Task<EmailTemplate> GetAsync(EmailTemplateName templateName)
        {
            return Connection.GetAsync<EmailTemplate>(BuildUri($"email-templates/{templateName.ToEnumString()}"));
        }

        /// <summary>
        /// Updates an email template.
        /// </summary>
        /// <param name="templateName">The name of the email template to update.</param>
        /// <param name="request">The <see cref="EmailTemplatePatchRequest"/> containing details of the template to patch.</param>
        /// <returns>The newly updated <see cref="EmailTemplate"/>.</returns>
        public Task<EmailTemplate> PatchAsync(EmailTemplateName templateName, EmailTemplatePatchRequest request)
        {
            return Connection.SendAsync<EmailTemplate>(new HttpMethod("PATCH"), BuildUri($"email-templates/{templateName.ToEnumString()}"), request);
        }

        /// <summary>
        /// Updates an email template.
        /// </summary>
        /// <param name="templateName">The name of the email template to patch.</param>
        /// <param name="request">The <see cref="EmailTemplateUpdateRequest"/> containing details of the template to update.</param>
        /// <returns>The newly updated <see cref="EmailTemplate"/>.</returns>
        public Task<EmailTemplate> UpdateAsync(EmailTemplateName templateName, EmailTemplateUpdateRequest request)
        {
            return Connection.SendAsync<EmailTemplate>(HttpMethod.Put, BuildUri($"email-templates/{templateName.ToEnumString()}"), request);
        }
    }
}