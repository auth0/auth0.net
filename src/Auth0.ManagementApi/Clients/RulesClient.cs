using Auth0.Core.Collections;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /rules endpoints.
    /// </summary>
    public class RulesClient : ClientBase
    {
        /// <summary>
        /// Creates a new instance of <see cref="RulesClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public RulesClient(IApiConnection connection)
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
            return Connection.RunAsync<Rule>(HttpMethod.Post, "rules", request);
        }

        /// <summary>
        /// Deletes a rule.
        /// </summary>
        /// <param name="id">The ID of the rule to delete.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteAsync(string id)
        {
            return Connection.DeleteAsync<object>($"rules/{id}");
        }

        /// <summary>
        /// Retrieves a list of all rules.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying rules.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <returns>An <see cref="IPagedList{Rule}"/> containing the rules requested.</returns>
        public Task<IPagedList<Rule>> GetAllAsync(GetRulesRequest request, PaginationInfo pagination)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            return Connection.RunAsync<IPagedList<Rule>>(HttpMethod.Get, "rules", queryStrings:
                new Dictionary<string, string>
                {
                    {"enabled", request.Enabled?.ToString().ToLower()},
                    {"fields", request.Fields},
                    {"include_fields", request.IncludeFields?.ToString().ToLower()},
                    {"stage", request.Stage},
                    {"page", pagination.PageNo.ToString()},
                    {"per_page", pagination.PerPage.ToString()},
                    {"include_totals", pagination.IncludeTotals.ToString().ToLower()}
                }, converters: new PagedListConverter<Rule>("rules"));
        }

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
        /// <returns>The <see cref="Rule" /> that was requested.</returns>
        public Task<Rule> GetAsync(string id, string fields = null, bool includeFields = true)
        {
            return Connection.RunAsync<Rule>(HttpMethod.Get, $"rules/{id}", queryStrings:
                new Dictionary<string, string>
                {
                    {"fields", fields},
                    {"include_fields", includeFields.ToString().ToLower()}
                });
        }

        /// <summary>
        /// Updates a rule.
        /// </summary>
        /// <param name="id">The ID of the rule to update.</param>
        /// <param name="request">A <see cref="RuleUpdateRequest" /> containing the information to update.</param>
        /// <returns>The newly updated <see cref="Rule"/>.</returns>
        public Task<Rule> UpdateAsync(string id, RuleUpdateRequest request)
        {
            return Connection.RunAsync<Rule>(new HttpMethod("PATCH"), $"rules/{id}", request);
        }
    }
}