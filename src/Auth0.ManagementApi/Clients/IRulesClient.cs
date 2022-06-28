namespace Auth0.ManagementApi.Clients
{
  using System.Threading;
  using System.Threading.Tasks;
  using Models;
  using Paging;

  public interface IRulesClient
  {
    /// <summary>
    /// Creates a new rule according to the request.
    /// </summary>
    /// <param name="request">The <see cref="RuleCreateRequest" /> containing the details of the rule to create.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The newly created <see cref="Rule" />.</returns>
    Task<Rule> CreateAsync(RuleCreateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a rule.
    /// </summary>
    /// <param name="id">The ID of the rule to delete.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of all rules.
    /// </summary>
    /// <param name="request">Specifies criteria to use when querying rules.</param>
    /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="IPagedList{Rule}"/> containing the rules requested.</returns>
    Task<IPagedList<Rule>> GetAllAsync(GetRulesRequest request, PaginationInfo pagination = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a rule by its ID.
    /// </summary>
    /// <param name="id">The ID of the rule to retrieve.</param>
    /// <param name="fields">
    /// A comma separated list of fields to include or exclude (depending on
    /// <paramref name="includeFields" />) from the result, empty to retrieve all fields.
    /// </param>
    /// <param name="includeFields">
    /// True if the fields specified are to be included in the result, false otherwise (defaults to
    /// true).
    /// </param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="Rule" /> that was requested.</returns>
    Task<Rule> GetAsync(string id, string fields = null, bool includeFields = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a rule.
    /// </summary>
    /// <param name="id">The ID of the rule to update.</param>
    /// <param name="request">A <see cref="RuleUpdateRequest" /> containing the information to update.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The newly updated <see cref="Rule"/>.</returns>
    Task<Rule> UpdateAsync(string id, RuleUpdateRequest request, CancellationToken cancellationToken = default);
  }
}
