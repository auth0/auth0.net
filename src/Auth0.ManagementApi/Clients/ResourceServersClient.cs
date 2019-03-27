using Auth0.Core.Collections;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Serialization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <inheritdoc />
    public class ResourceServersClient : ClientBase, IResourceServersClient
    {
        /// <summary>
        /// Creates a new instance of <see cref="ResourceServersClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public ResourceServersClient(IApiConnection connection) : base(connection)
        {
        }

        /// <inheritdoc />
        public Task<ResourceServer> CreateAsync(ResourceServerCreateRequest request)
        {
            return Connection.PostAsync<ResourceServer>("resource-servers", request, null, null, null, null, null);
        }

        /// <inheritdoc />
        public Task DeleteAsync(string id)
        {
            return Connection.DeleteAsync<object>("resource-servers/{id}", new Dictionary<string, string>
            {
                {"id", id}
            }, null);
        }

        /// <inheritdoc />
        public Task<ResourceServer> GetAsync(string id)
        {
            return Connection.GetAsync<ResourceServer>("resource-servers/{id}",
                new Dictionary<string, string>
                {
                    {"id", id}
                },
                null, null, null);
        }

        /// <inheritdoc />
        public Task<IPagedList<ResourceServer>> GetAllAsync(PaginationInfo pagination)
        {
            return Connection.GetAsync<IPagedList<ResourceServer>>("resource-servers", null,
                new Dictionary<string, string>
                {
                    {"page", pagination.PageNo.ToString()},
                    {"per_page", pagination.PerPage.ToString()},
                    {"include_totals", pagination.IncludeTotals.ToString().ToLower()}
                }, null, new PagedListConverter<ResourceServer>("resource_servers"));
        }

        /// <inheritdoc />
        public Task<ResourceServer> UpdateAsync(string id, ResourceServerUpdateRequest request)
        {
            return Connection.PatchAsync<ResourceServer>("resource-servers/{id}", request, new Dictionary<string, string>
            {
                {"id", id}
            });
        }
    }
}