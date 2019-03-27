using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Collections;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /rules endpoints.
    /// </summary>
    public interface IRulesClient
    {
        /// <summary>
        /// Creates a new rule according to the request.
        /// </summary>
        /// <param name="request">The <see cref="RuleCreateRequest" /> containing the details of the rule to create.</param>
        /// <returns>The newly created <see cref="Rule" />.</returns>
        Task<Rule> CreateAsync(RuleCreateRequest request);

        /// <summary>
        /// Deletes a rule.
        /// </summary>
        /// <param name="id">The ID of the rule to delete.</param>
        Task DeleteAsync(string id);
        
        /// <summary>
        /// Retrieves a list of all rules.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying rules.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <returns>An <see cref="IPagedList{Rule}"/> containing the rules</returns>
        Task<IPagedList<Rule>> GetAllAsync(GetRulesRequest request, PaginationInfo pagination);

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
        /// <returns>The <see cref="Rule" />.</returns>
        Task<Rule> GetAsync(string id, string fields = null, bool includeFields = true);

        /// <summary>
        /// Updates a rule.
        /// </summary>
        /// <param name="id">The ID of the rule to update.</param>
        /// <param name="request">A <see cref="RuleUpdateRequest" /> containing the information to update.</param>
        /// <returns></returns>
        Task<Rule> UpdateAsync(string id, RuleUpdateRequest request);
    }
}