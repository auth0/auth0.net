using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /email-templates endpoints.
    /// </summary>
    public class EmailTemplatesClient : ClientBase
    {
        /// <summary>
        /// Creates a new instance of <see cref="EmailTemplatesClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="ILegacyApiConnection" /> which is used to communicate with the API.</param>
        public EmailTemplatesClient(ILegacyApiConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Creates a new email template.
        /// </summary>
        /// <param name="request">The <see cref="EmailTemplateCreateRequest"/> containing details of the template to create.</param>
        /// <returns>The newly created <see cref="EmailTemplate"/>.</returns>
        public Task<EmailTemplate> CreateAsync(EmailTemplateCreateRequest request)
        {
            return Connection.PostAsync<EmailTemplate>("email-templates", request, null, null, null, null, null);
        }

        /// <summary>
        /// Gets an email template.
        /// </summary>
        /// <param name="templateName">The name of email template you wish to retrieve.</param>
        /// <returns>The <see cref="EmailTemplate"/> that was requested.</returns>
        public Task<EmailTemplate> GetAsync(EmailTemplateName templateName)
        {
            return Connection.GetAsync<EmailTemplate>("email-templates/{templateName}",
                new Dictionary<string, string>
                {
                    {"templateName", ToEnumString(templateName)}
                }, null, null, null);
        }

        /// <summary>
        /// Updates an email template.
        /// </summary>
        /// <param name="templateName">The name of the email template to update.</param>
        /// <param name="request">The <see cref="EmailTemplatePatchRequest"/> containing details of the template to patch.</param>
        /// <returns>The newly updated <see cref="EmailTemplate"/>.</returns>
        public Task<EmailTemplate> PatchAsync(EmailTemplateName templateName, EmailTemplatePatchRequest request)
        {
            return Connection.PatchAsync<EmailTemplate>("email-templates/{templateName}", request, new Dictionary<string, string>
            {
                {"templateName", ToEnumString(templateName)}
            });
        }

        /// <summary>
        /// Updates an email template.
        /// </summary>
        /// <param name="templateName">The name of the email template to patch.</param>
        /// <param name="request">The <see cref="EmailTemplateUpdateRequest"/> containing details of the template to update.</param>
        /// <returns>The newly updated <see cref="EmailTemplate"/>.</returns>
        public Task<EmailTemplate> UpdateAsync(EmailTemplateName templateName, EmailTemplateUpdateRequest request)
        {
            return Connection.PutAsync<EmailTemplate>("email-templates/{templateName}", request, null, null, new Dictionary<string, string>
            {
                {"templateName", ToEnumString(templateName)}
            }, null, null);
        }

        private string ToEnumString<T>(T type)
        {
            var enumType = typeof(T);
            var name = Enum.GetName(enumType, type);
            var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetTypeInfo().GetDeclaredField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
            return enumMemberAttribute.Value;
        }
    }
}