using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Collections;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Serialization;

namespace Auth0.ManagementApi.Clients
{
    /// <inheritdoc />
    public class RulesClient : ClientBase, IRulesClient
    {
        /// <summary>
        /// Creates a new instance of <see cref="RulesClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public RulesClient(ApiConnection connection)
            : base(connection)
        {
        }

        /// <inheritdoc />
        public Task<Rule> CreateAsync(RuleCreateRequest request)
        {
            return Connection.PostAsync<Rule>("rules", request, null, null, null, null, null);
        }

        /// <inheritdoc />
        public Task DeleteAsync(string id)
        {
            return Connection.DeleteAsync<object>("rules/{id}",
                new Dictionary<string, string>
                {
                    {"id", id}
                }, null);
        }

        /// <inheritdoc />
        public Task<IPagedList<Rule>> GetAllAsync(GetRulesRequest request, PaginationInfo pagination)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            return Connection.GetAsync<IPagedList<Rule>>("rules", null,
                new Dictionary<string, string>
                {
                    {"enabled", request.Enabled?.ToString().ToLower()},
                    {"fields", request.Fields},
                    {"include_fields", request.IncludeFields?.ToString().ToLower()},
                    {"stage", request.Stage},
                    {"page", pagination.PageNo.ToString()},
                    {"per_page", pagination.PerPage.ToString()},
                    {"include_totals", pagination.IncludeTotals.ToString().ToLower()}
                }, null, new PagedListConverter<Rule>("rules"));
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public Task<Rule> UpdateAsync(string id, RuleUpdateRequest request)
        {
            return Connection.PatchAsync<Rule>("rules/{id}", request, new Dictionary<string, string>
            {
                {"id", id}
            });
        }
    }
}