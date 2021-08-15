using Auth0.ManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /branding endpoints.
    /// </summary>
    public class BrandingClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of <see cref="BrandingClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
        public BrandingClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
            : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <summary>
        /// Retrieves branding settings for a tenant.
        /// </summary>
        /// <returns>A <see cref="Branding"/> containing the branding for the tenant.</returns>
        public Task<Branding> GetAsync(CancellationToken token = default)
        {
            return Connection.GetAsync<Branding>(BuildUri("branding"), DefaultHeaders, token: token);
        }

        /// <summary>s
        /// Updates the branding for a tenant.
        /// </summary>
        /// <param name="request">A <see cref="BrandingUpdateRequest" /> containing the branding information to update.</param>
        /// <returns>The newly updated <see cref="Branding"/>.</returns>
        public Task<Branding> UpdateAsync(BrandingUpdateRequest request, CancellationToken token = default)
        {
            return Connection.SendAsync<Branding>(new HttpMethod("PATCH"), BuildUri("branding"), request, DefaultHeaders, token: token);
        }

        /// <summary>
        /// Retrieves the template for the New Universal Login Experience.
        /// </summary>
        /// <returns>The <see cref="UniversalLoginTemplate"/> for the new universal login experience.</returns>
        public Task<UniversalLoginTemplate> GetUniversalLoginTemplateAsync(CancellationToken token = default)
        {
            return Connection.GetAsync<UniversalLoginTemplate>(BuildUri("branding/templates/universal-login"), DefaultHeaders, token: token);
        }

        /// <summary>
        /// Delete the template for the New Universal Login Experience
        /// </summary>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteUniversalLoginTemplateAsync(CancellationToken token = default)
        {
            return Connection
                    .SendAsync<object>(
                            HttpMethod.Delete,
                            BuildUri("branding/templates/universal-login"),
                            null,
                            DefaultHeaders, token: token);
        }

        /// <summary>
        /// Sets the template for the New Universal Login Experience.
        /// </summary>
        /// <param name="request">The <see cref="UniversalLoginTemplateUpdateRequest"/> containing details of the template to set.</param>
        /// <returns>The newly updated <see cref="UniversalLoginTemplate"/>.</returns>
        public Task<UniversalLoginTemplate> SetUniversalLoginTemplateAsync(UniversalLoginTemplateUpdateRequest request, CancellationToken token = default)
        {
            return Connection.SendAsync<UniversalLoginTemplate>(HttpMethod.Put, BuildUri("branding/templates/universal-login"), request, DefaultHeaders, token: token);
        }
    }
}