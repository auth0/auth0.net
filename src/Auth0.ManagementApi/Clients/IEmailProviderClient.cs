namespace Auth0.ManagementApi.Clients
{
  using System.Threading;
  using System.Threading.Tasks;
  using Models;

  public interface IEmailProviderClient
  {
    /// <summary>
    /// Configures the email provider.
    /// </summary>
    /// <param name="request">
    /// The <see cref="EmailProviderConfigureRequest" /> containing the configuration properties of the
    /// provider.
    /// </param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="EmailProvider" /> instance containing the email provider details.</returns>
    Task<EmailProvider> ConfigureAsync(EmailProviderConfigureRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes the email provider.
    /// </summary>
    /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
    Task DeleteAsync(CancellationToken cancellationToken = default);

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
    Task<EmailProvider> GetAsync(string fields = null, bool includeFields = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the email provider.
    /// </summary>
    /// <param name="request">
    /// The <see cref="EmailProviderUpdateRequest" /> containing the configuration properties of the
    /// email provider.
    /// </param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="EmailProvider" /> instance containing the email provider details.</returns>
    Task<EmailProvider> UpdateAsync(EmailProviderUpdateRequest request, CancellationToken cancellationToken = default);
  }
}
