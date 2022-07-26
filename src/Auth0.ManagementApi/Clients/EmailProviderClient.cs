using Auth0.ManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /emails/provider endpoints.
    /// </summary>
    public class EmailProviderClient : BaseClient, IEmailProviderClient
    {
        /// <summary>
        /// Initializes a new instance of <see cref="EmailProviderClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
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
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="EmailProvider" /> instance containing the email provider details.</returns>
        public Task<EmailProvider> ConfigureAsync(EmailProviderConfigureRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<EmailProvider>(HttpMethod.Post, BuildUri("emails/provider"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Deletes the email provider.
        /// </summary>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteAsync(CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri("emails/provider"), null, DefaultHeaders, cancellationToken: cancellationToken);
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
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="EmailProvider" /> instance containing the email provider details.</returns>
        public Task<EmailProvider> GetAsync(string fields = null, bool includeFields = true, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<EmailProvider>(BuildUri("emails/provider",
                new Dictionary<string, string>
                {
                    {"fields", fields},
                    {"include_fields", includeFields.ToString().ToLower()}
                }), DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Updates the email provider.
        /// </summary>
        /// <param name="request">
        /// The <see cref="EmailProviderUpdateRequest" /> containing the configuration properties of the
        /// email provider.
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="EmailProvider" /> instance containing the email provider details.</returns>
        public Task<EmailProvider> UpdateAsync(EmailProviderUpdateRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<EmailProvider>(new HttpMethod("PATCH"), BuildUri("emails/provider"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }
    }
}
