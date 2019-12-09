using Auth0.ManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /emails/provider endpoints.
    /// </summary
    public class EmailProviderClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of <see cref="EmailProviderClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders"><see cref="IDictionary{string, string}"/> containing default headers included with every request this client makes.</param>
        public EmailProviderClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
            : base(connection, baseUri, defaultHeaders)
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
            return Connection.SendAsync<EmailProvider>(HttpMethod.Post, BuildUri("emails/provider"), request, DefaultHeaders);
        }

        /// <summary>
        /// Deletes the email provider.
        /// </summary>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteAsync()
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri("emails/provider"), null, DefaultHeaders);
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
            return Connection.GetAsync<EmailProvider>(BuildUri("emails/provider",
                new Dictionary<string, string>
                {
                    {"fields", fields},
                    {"include_fields", includeFields.ToString().ToLower()}
                }), DefaultHeaders);
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
            return Connection.SendAsync<EmailProvider>(new HttpMethod("PATCH"), BuildUri("emails/provider"), request, DefaultHeaders);
        }
    }
}