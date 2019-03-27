using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <inheritdoc />
    public class EmailTemplatesClient : ClientBase, IEmailTemplatesClient
    {
        /// <summary>
        /// Creates a new instance of <see cref="EmailTemplatesClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public EmailTemplatesClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <inheritdoc />
        public Task<EmailTemplate> CreateAsync(EmailTemplateCreateRequest request)
        {
            return Connection.PostAsync<EmailTemplate>("email-templates", request, null, null, null, null, null);
        }

        /// <inheritdoc />
        public Task<EmailTemplate> GetAsync(EmailTemplateName templateName)
        {
            return Connection.GetAsync<EmailTemplate>("email-templates/{templateName}",
                new Dictionary<string, string>
                {
                    {"templateName", ToEnumString<EmailTemplateName>(templateName)}
                }, null, null, null);
        }

        /// <inheritdoc />
        public Task<EmailTemplate> PatchAsync(EmailTemplateName templateName, EmailTemplatePatchRequest request)
        {
            return Connection.PatchAsync<EmailTemplate>("email-templates/{templateName}", request, new Dictionary<string, string>
            {
                {"templateName", ToEnumString<EmailTemplateName>(templateName)}
            });
        }

        /// <inheritdoc />
        public Task<EmailTemplate> UpdateAsync(EmailTemplateName templateName, EmailTemplateUpdateRequest request)
        {
            return Connection.PutAsync<EmailTemplate>("email-templates/{templateName}", request, null, null, new Dictionary<string, string>
            {
                {"templateName", ToEnumString<EmailTemplateName>(templateName)}
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