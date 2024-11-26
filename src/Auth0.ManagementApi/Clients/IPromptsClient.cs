namespace Auth0.ManagementApi.Clients
{
  using System.Threading;
  using System.Threading.Tasks;
  using Models.Prompts;

  public interface IPromptsClient
  {
    /// <summary>
    /// Get prompts settings
    /// </summary>
    /// <remarks>
    /// Get prompts settings
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Prompt"/> instance containing the information about the prompt settings.</returns>
    Task<Prompt> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Update prompts settings.
    /// </summary>
    /// <remarks>
    /// Update prompts settings.
    /// </remarks>
    /// <param name="request">Specifies prompt setting values that are to be updated.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="Prompt"/> that was updated.</returns>
    Task<Prompt> UpdateAsync(PromptUpdateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve custom text for a specific prompt and language.
    /// </summary>
    /// <param name="promptName">Name of the prompt.</param>
    /// <param name="language">Language to update.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>An object containing custom dictionaries for a group of screens.</returns>
    Task<object> GetCustomTextForPromptAsync(string promptName, string language, CancellationToken cancellationToken = default);

    /// <summary>
    /// Set custom text for a specific prompt. Existing texts will be overwritten.
    /// </summary>
    /// <param name="promptName">Name of the prompt.</param>
    /// <param name="language">Language to update.</param>
    /// <param name="customText">An object containing custom dictionaries for a group of screens.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    Task SetCustomTextForPromptAsync(string promptName, string language, object customText, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get template partials for a prompt
    /// </summary>
    /// <param name="promptName">Name of the prompt.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>An object containing template partials for a group of screens.</returns>
    Task<object> GetPartialsAsync(string promptName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Set template partials for a prompt
    /// </summary>
    /// <param name="promptName">Name of the prompt.</param>
    /// <param name="partials">An object containing template partials for a group of screens.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    Task SetPartialsAsync(string promptName, object partials, CancellationToken cancellationToken = default);
  }
}
