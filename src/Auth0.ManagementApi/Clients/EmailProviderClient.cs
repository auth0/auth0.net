using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <inheritdoc />
    public class EmailProviderClient : ClientBase, IEmailProviderClient
    {
        /// <summary>
        /// Creates a new instance of <see cref="EmailProviderClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        internal EmailProviderClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <inheritdoc />
        public Task<EmailProvider> ConfigureAsync(EmailProviderConfigureRequest request)
        {
            return Connection.PostAsync<EmailProvider>("emails/provider", request, null, null, null, null, null);
        }

        /// <inheritdoc />
        public Task DeleteAsync()
        {
            return Connection.DeleteAsync<object>("emails/provider", null, null);
        }

        /// <inheritdoc />
        public Task<EmailProvider> GetAsync(string fields = null, bool includeFields = true)
        {
            return Connection.GetAsync<EmailProvider>("emails/provider",
                null,
                new Dictionary<string, string>
                {
                    {"fields", fields},
                    {"include_fields", includeFields.ToString().ToLower()}
                }, null, null);
        }

        /// <inheritdoc />
        public Task<EmailProvider> UpdateAsync(EmailProviderUpdateRequest request)
        {
            return Connection.PatchAsync<EmailProvider>("emails/provider", request, null);
        }
    }
}