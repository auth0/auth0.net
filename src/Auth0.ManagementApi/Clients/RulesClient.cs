using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Collections;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Serialization;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /rules endpoints.
    /// </summary>
    public class RulesClient : ClientBase, IRulesClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RulesClient"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public RulesClient(ApiConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Creates a new rule according to the request.
        /// </summary>
        /// <param name="request">The <see cref="RuleCreateRequest" /> containing the details of the rule to create.</param>
        /// <returns>The newly created <see cref="Rule" />.</returns>
        public Task<Rule> CreateAsync(RuleCreateRequest request)
        {
            return Connection.PostAsync<Rule>("rules", request, null, null, null, null, null);
        }

        /// <summary>
        /// Deletes a rule.
        /// </summary>
        /// <param name="id">The ID of the rule to delete.</param>
        /// <returns>Task.</returns>
        public Task DeleteAsync(string id)
        {
            return Connection.DeleteAsync<object>("rules/{id}", new Dictionary<string, string>
            {
                {"id", id}
            }, null);
        }

        /// <inheritdoc />
        public Task<IList<Rule>> GetAllAsync(bool? enabled = null, string fields = null, bool includeFields = true, string stage = null)
        {
            return Connection.GetAsync<IList<Rule>>("rules", null,
                new Dictionary<string, string>
                {
                    {"enabled", enabled?.ToString().ToLower()},
                    {"fields", fields},
                    {"include_fields", includeFields.ToString().ToLower()},
                    {"stage", stage}
                }, null, null);
        }

        /// <inheritdoc />
        public Task<IPagedList<Rule>> GetAllAsync(int? page = null, int? perPage = null, bool? includeTotals = null, bool? enabled = null, string fields = null, bool includeFields = true, string stage = null)
        {
            return Connection.GetAsync<IPagedList<Rule>>("rules", null,
                new Dictionary<string, string>
                {
                    {"page", page?.ToString()},
                    {"per_page", perPage?.ToString()},
                    {"include_totals", includeTotals?.ToString().ToLower()},
                    {"enabled", enabled?.ToString().ToLower()},
                    {"fields", fields},
                    {"include_fields", includeFields.ToString().ToLower()},
                    {"stage", stage}
                }, null, new PagedListConverter<Rule>("rules"));
        }

        /// <summary>
        /// Retrieves a rule by its ID.
        /// </summary>
        /// <param name="id">The ID of the rule to retrieve.</param>
        /// <param name="fields">A comma separated list of fields to include or exclude (depending on
        /// <paramref name="includeFields" />) from the result, empty to retrieve all fields.</param>
        /// <param name="includeFields">True if the fields specified are to be included in the result, false otherwise (defaults to
        /// true).</param>
        /// <returns>The <see cref="Rule" />.</returns>
        public Task<Rule> GetAsync(string id, string fields = null, bool includeFields = true)
        {
            return Connection.GetAsync<Rule>("rules/{id}",
                new Dictionary<string, string>
                {
                    {"id", id}
                },
                new Dictionary<string, string>
                {
                    {"fields", fields},
                    {"include_fields", includeFields.ToString().ToLower()}
                }, null, null);
        }

        /// <summary>
        /// Updates a rule.
        /// </summary>
        /// <param name="id">The ID of the rule to update.</param>
        /// <param name="request">A <see cref="RuleUpdateRequest" /> containing the information to update.</param>
        /// <returns>Task&lt;Rule&gt;.</returns>
        public Task<Rule> UpdateAsync(string id, RuleUpdateRequest request)
        {
            return Connection.PatchAsync<Rule>("rules/{id}", request, new Dictionary<string, string>
            {
                {"id", id}
            });
        }
    }
}