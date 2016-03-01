using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Auth0.Core;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /emails/provider endpoints.
    /// </summary>
    public class EmailProviderClient : ClientBase, IEmailProviderClient
    {
        /// <summary>
        /// Creates a new instance of the ClientBase class.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        internal EmailProviderClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Configures the email provider.
        /// </summary>
        /// <param name="request">The <see cref="EmailProviderConfigureRequest" /> containing the configuration properties of the
        /// provider.</param>
        /// <returns>A <see cref="EmailProvider" /> instance containing the email provider details.</returns>
        public Task<EmailProvider> ConfigureAsync(EmailProviderConfigureRequest request)
        {
            return Connection.PostAsync<EmailProvider>("emails/provider", request, null, null, null, null, null);
        }

        /// <summary>
        /// Deletes the email provider.
        /// </summary>
        /// <returns>Task.</returns>
        public Task DeleteAsync()
        {
            return Connection.DeleteAsync<object>("emails/provider", null);
        }

        /// <summary>
        /// Gets the email provider.
        /// </summary>
        /// <param name="fields">A comma separated list of fields to include or exclude (depending on
        /// <paramref name="includeFields" />) from the result, empty to retrieve: name, enabled, settings fields.</param>
        /// <param name="includeFields">True if the fields specified are to be excluded from the result, false otherwise (defaults
        /// to true).</param>
        /// <returns>A <see cref="EmailProvider" /> instance containing the email provider details.</returns>
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

        /// <summary>
        /// Updates the email provider.
        /// </summary>
        /// <param name="request">The <see cref="EmailProviderUpdateRequest" /> containing the configuration properties of the
        /// email provider.</param>
        /// <returns>A <see cref="EmailProvider" /> instance containing the email provider details.</returns>
        public Task<EmailProvider> UpdateAsync(EmailProviderUpdateRequest request)
        {
            return Connection.PatchAsync<EmailProvider>("emails/provider", request, null);
        }

        #region Obsolete Methods
#pragma warning disable 1591

        [Obsolete("Use ConfigureAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Task<EmailProvider> Configure(EmailProviderConfigureRequest request)
        {
            return ConfigureAsync(request);
        }

        [Obsolete("Use DeleteAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Task Delete()
        {
            return DeleteAsync();
        }

        [Obsolete("Use GetAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Task<EmailProvider> Get(string fields = null, bool includeFields = true)
        {
            return GetAsync(fields, includeFields);
        }

        [Obsolete("Use UpdateAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Task<EmailProvider> Update(EmailProviderUpdateRequest request)
        {
            return UpdateAsync(request);
        }

#pragma warning restore 1591
        #endregion
    }
}