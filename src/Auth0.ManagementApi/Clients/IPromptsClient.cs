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
  }
}
