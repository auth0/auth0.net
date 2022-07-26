using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /rules endpoints.
    /// </summary>
    public class RulesClient : BaseClient, IRulesClient
    {
        readonly JsonConverter[] rulesConverters = new JsonConverter[] { new PagedListConverter<Rule>("rules") };

        /// <summary>
        /// Initializes a new instance of <see cref="RulesClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
        public RulesClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
            : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <summary>
        /// Creates a new rule according to the request.
        /// </summary>
        /// <param name="request">The <see cref="RuleCreateRequest" /> containing the details of the rule to create.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The newly created <see cref="Rule" />.</returns>
        public Task<Rule> CreateAsync(RuleCreateRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<Rule>(HttpMethod.Post, BuildUri("rules"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Deletes a rule.
        /// </summary>
        /// <param name="id">The ID of the rule to delete.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"rules/{EncodePath(id)}"), null, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Retrieves a list of all rules.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying rules.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>An <see cref="IPagedList{Rule}"/> containing the rules requested.</returns>
        public Task<IPagedList<Rule>> GetAllAsync(GetRulesRequest request, PaginationInfo pagination = null, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var queryStrings = new Dictionary<string, string>
            {
                {"enabled", request.Enabled?.ToString().ToLower()},
                {"fields", request.Fields},
                {"include_fields", request.IncludeFields?.ToString().ToLower()},
                {"stage", request.Stage}
            };

            if (pagination != null)
            {
                queryStrings["page"] = pagination.PageNo.ToString();
                queryStrings["per_page"] = pagination.PerPage.ToString();
                queryStrings["include_totals"] = pagination.IncludeTotals.ToString().ToLower();
            }

            return Connection.GetAsync<IPagedList<Rule>>(BuildUri("rules", queryStrings), DefaultHeaders, rulesConverters, cancellationToken);
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
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The <see cref="Rule" /> that was requested.</returns>
        public Task<Rule> GetAsync(string id, string fields = null, bool includeFields = true, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<Rule>(BuildUri($"rules/{EncodePath(id)}",
                new Dictionary<string, string>
                {
                    {"fields", fields},
                    {"include_fields", includeFields.ToString().ToLower()}
                }), DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Updates a rule.
        /// </summary>
        /// <param name="id">The ID of the rule to update.</param>
        /// <param name="request">A <see cref="RuleUpdateRequest" /> containing the information to update.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The newly updated <see cref="Rule"/>.</returns>
        public Task<Rule> UpdateAsync(string id, RuleUpdateRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<Rule>(new HttpMethod("PATCH"), BuildUri($"rules/{EncodePath(id)}"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }
    }
}
