using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /emails/provider endpoints.
    /// </summary
    public class EmailProviderClient : ClientBase
    {
        /// <summary>
        /// Creates a new instance of <see cref="EmailProviderClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        internal EmailProviderClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Configures the email provider.
        /// </summary>
        /// <param name="request">
        /// The <see cref="EmailProviderConfigureRequest" /> containing the configuration properties of the
        /// provider.
        /// </param>
        /// <returns>A <see cref="EmailProvider" /> instance containing the email provider details.</returns>
        public Task<EmailProvider> ConfigureAsync(EmailProviderConfigureRequest request)
        {
            return Connection.RequestAsync<EmailProvider>(HttpMethod.Post, "emails/provider", request);
        }

        /// <summary>
        /// Deletes the email provider.
        /// </summary>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteAsync()
        {
            return Connection.RequestAsync<object>(HttpMethod.Delete, "emails/provider");
        }

        /// <summary>
        /// Gets the email provider.
        /// </summary>
        /// <param name="fields">
        /// A comma separated list of fields to include or exclude (depending on
        /// <paramref name="includeFields" />) from the result, empty to retrieve: name, enabled, settings fields.
        /// </param>
        /// <param name="includeFields">
        /// True if the fields specified are to be excluded from the result, false otherwise (defaults
        /// to true).
        /// </param>
        /// <returns>A <see cref="EmailProvider" /> instance containing the email provider details.</returns>
        public Task<EmailProvider> GetAsync(string fields = null, bool includeFields = true)
        {
            return Connection.RequestAsync<EmailProvider>(HttpMethod.Get, "emails/provider", queryStrings:
                new Dictionary<string, string>
                {
                    {"fields", fields},
                    {"include_fields", includeFields.ToString().ToLower()}
                });
        }

        /// <summary>
        /// Updates the email provider.
        /// </summary>
        /// <param name="request">
        /// The <see cref="EmailProviderUpdateRequest" /> containing the configuration properties of the
        /// email provider.
        /// </param>
        /// <returns>A <see cref="EmailProvider" /> instance containing the email provider details.</returns>
        public Task<EmailProvider> UpdateAsync(EmailProviderUpdateRequest request)
        {
            return Connection.RequestAsync<EmailProvider>(new HttpMethod("PATCH"), "emails/provider", request, null);
        }
    }
}