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
    public class ConnectionsClient : ClientBase, IConnectionsClient
    {
        /// <summary>
        /// Creates a new instance of the <see cref="ConnectionsClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public ConnectionsClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <inheritdoc />
        public Task<Connection> CreateAsync(ConnectionCreateRequest request)
        {
            return Connection.PostAsync<Connection>("connections", request, null, null, null, null, null);
        }

        /// <inheritdoc />
        public Task DeleteAsync(string id)
        {
            return Connection.DeleteAsync<object>("connections/{id}", new Dictionary<string, string>
            {
                {"id", id}
            }, null);
        }

        /// <inheritdoc />
        public Task DeleteUserAsync(string id, string email)
        {
            return Connection.DeleteAsync<object>("connections/{id}/users",
                new Dictionary<string, string>
                {
                    {"id", id}
                },
                new Dictionary<string, string>
                {
                    {"email", email},
                });
        }

        /// <inheritdoc />
        public Task<Connection> GetAsync(string id, string fields = null, bool includeFields = true)
        {
            return Connection.GetAsync<Connection>("connections/{id}",
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
        public Task<IPagedList<Connection>> GetAllAsync(GetConnectionsRequest request, PaginationInfo pagination)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            var queryStrings = new Dictionary<string, string>
            {
                {"fields", request.Fields},
                {"include_fields", request.IncludeFields?.ToString().ToLower()},
                {"name", request.Name},
                {"page", pagination.PageNo.ToString()},
                {"per_page", pagination.PerPage.ToString()},
                {"include_totals", pagination.IncludeTotals.ToString().ToLower()}
            };

            // Add each strategy as a separate querystring
            if (request.Strategy != null)
            {
                foreach (var s in request.Strategy)
                {
                    queryStrings.Add("strategy", s);
                }
            }

            return Connection.GetAsync<IPagedList<Connection>>("connections", null, queryStrings, null, new PagedListConverter<Connection>("connections"));
        }

        /// <inheritdoc />
        public Task<Connection> UpdateAsync(string id, ConnectionUpdateRequest request)
        {
            return Connection.PatchAsync<Connection>("connections/{id}", request, 
                new Dictionary<string, string>
                {
                    {"id", id}
                });
        }
    }
}