using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Models;

namespace Auth0.ManagementApi.Client.Clients
{
    public interface IRulesClient
    {
        /// <summary>
        ///     Creates a new rule according to the request.
        /// </summary>
        /// <param name="request">The <see cref="RuleCreateRequest" /> containing the details of the rule to create.</param>
        /// <returns>The newly created <see cref="Rule" />.</returns>
        Task<Rule> Create(RuleCreateRequest request);

        /// <summary>
        ///     Deletes a rule.
        /// </summary>
        /// <param name="id">The ID of the rule to delete.</param>
        Task Delete(string id);

        /// <summary>
        ///     Retrieves a rule by its ID.
        /// </summary>
        /// <param name="id">The ID of the rule to retrieve.</param>
        /// <param name="fields">
        ///     A comma separated list of fields to include or exclude (depending on
        ///     <paramref name="includeFields" />) from the result, empty to retrieve all fields.
        /// </param>
        /// <param name="includeFields">
        ///     True if the fields specified are to be included in the result, false otherwise (defaults to
        ///     true).
        /// </param>
        /// <returns>The <see cref="Rule" />.</returns>
        Task<Rule> Get(string id, string fields = null, bool includeFields = true);

        /// <summary>
        ///     Retrieves a list of all rules.
        /// </summary>
        /// <param name="enabled">If provided retrieves rules that match the value, otherwise all rules are retrieved.</param>
        /// <param name="fields">
        ///     A comma separated list of fields to include or exclude (depending on
        ///     <paramref name="includeFields" />) from the result, empty to retrieve all fields.
        /// </param>
        /// <param name="includeFields">
        ///     True if the fields specified are to be included in the result, false otherwise (defaults to
        ///     true).
        /// </param>
        /// <param name="stage">Retrieves rules that match the execution stage (defaults to login_success).</param>
        /// <returns>A list of <see cref="Rule" /> objects.</returns>
        Task<IList<Rule>> GetAll(bool? enabled = null, string fields = null, bool includeFields = true, string stage = null);

        /// <summary>
        ///     Updates a rule.
        /// </summary>
        /// <param name="id">The ID of the rule to update.</param>
        /// <param name="request">A <see cref="RuleUpdateRequest" /> containing the information to update.</param>
        /// <returns></returns>
        Task<Rule> Update(string id, RuleUpdateRequest request);
    }
}