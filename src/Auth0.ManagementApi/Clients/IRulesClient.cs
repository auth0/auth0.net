using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Auth0.Core;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /rules endpoints.
    /// </summary>
    public interface IRulesClient
    {
        /// <summary>
        ///     Creates a new rule according to the request.
        /// </summary>
        /// <param name="request">The <see cref="RuleCreateRequest" /> containing the details of the rule to create.</param>
        /// <returns>The newly created <see cref="Rule" />.</returns>
        Task<Rule> CreateAsync(RuleCreateRequest request);

        /// <summary>
        ///     Deletes a rule.
        /// </summary>
        /// <param name="id">The ID of the rule to delete.</param>
        Task DeleteAsync(string id);

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
        Task<IList<Rule>> GetAllAsync(bool? enabled = null, string fields = null, bool includeFields = true, string stage = null);

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
        Task<Rule> GetAsync(string id, string fields = null, bool includeFields = true);

        /// <summary>
        ///     Updates a rule.
        /// </summary>
        /// <param name="id">The ID of the rule to update.</param>
        /// <param name="request">A <see cref="RuleUpdateRequest" /> containing the information to update.</param>
        /// <returns></returns>
        Task<Rule> UpdateAsync(string id, RuleUpdateRequest request);

        #region Obsolete Methods
#pragma warning disable 1591

        [Obsolete("Use CreateAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task<Rule> Create(RuleCreateRequest request);

        [Obsolete("Use DeleteAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task Delete(string id);

        [Obsolete("Use GetAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task<Rule> Get(string id, string fields = null, bool includeFields = true);

        [Obsolete("Use GetAllAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task<IList<Rule>> GetAll(bool? enabled = null, string fields = null, bool includeFields = true, string stage = null);

        [Obsolete("Use UpdateAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task<Rule> Update(string id, RuleUpdateRequest request);

#pragma warning restore 1591
        #endregion
    }
}