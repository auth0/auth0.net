using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models.Grants;
using Auth0.ManagementApi.Paging;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Clients
{

    public class GrantsClient : BaseClient, IGrantsClient
    {

        readonly JsonConverter[] converters = new JsonConverter[] { new PagedListConverter<Grant>("grants") };

        public GrantsClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders) : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <inheritdoc/>
        public Task DeleteAllAsync(string userId, CancellationToken cancellationToken = default)
        {
            var queryStrings = new Dictionary<string, string>
        {
            {"user_id", userId}
        };

            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"grants", queryStrings), null, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        public Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {

            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"grants/{EncodePath(id)}"), null, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        public Task<IPagedList<Grant>> GetAllAsync(GetGrantsRequest request, PaginationInfo pagination = null, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var queryStrings = new Dictionary<string, string>
        {
            {"user_id", request.UserId},
            {"client_id", request.ClientId},
            {"audience", request.Audience},
        };

            if (pagination != null)
            {
                queryStrings.Add("page", pagination.PageNo.ToString());
                queryStrings.Add("per_page", pagination.PerPage.ToString());
                queryStrings.Add("include_totals", pagination.IncludeTotals.ToString().ToLower());
            }

            return Connection.GetAsync<IPagedList<Grant>>(BuildUri("grants", queryStrings), DefaultHeaders, converters, cancellationToken);
        }
    }
}
