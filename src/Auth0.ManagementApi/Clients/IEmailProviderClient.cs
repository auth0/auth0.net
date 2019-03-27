using System.Threading.Tasks;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /emails/provider endpoints.
    /// </summary>
    public interface IEmailProviderClient
    {
        /// <summary>
        /// Configures the email provider.
        /// </summary>
        /// <param name="request">
        /// The <see cref="EmailProviderConfigureRequest" /> containing the configuration properties of the
        /// provider.
        /// </param>
        /// <returns>A <see cref="EmailProvider" /> instance containing the email provider details.</returns>
        Task<EmailProvider> ConfigureAsync(EmailProviderConfigureRequest request);

        /// <summary>
        /// Deletes the email provider.
        /// </summary>
        /// <returns></returns>
        Task DeleteAsync();

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
        Task<EmailProvider> GetAsync(string fields = null, bool includeFields = true);

        /// <summary>
        /// Updates the email provider.
        /// </summary>
        /// <param name="request">
        /// The <see cref="EmailProviderUpdateRequest" /> containing the configuration properties of the
        /// email provider.
        /// </param>
        /// <returns>A <see cref="EmailProvider" /> instance containing the email provider details.</returns>
        Task<EmailProvider> UpdateAsync(EmailProviderUpdateRequest request);
    }
}