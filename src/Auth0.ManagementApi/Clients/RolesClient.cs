using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Collections;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Serialization;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /roles endpoints.
    /// </summary>
    public class RolesClient : ClientBase, IRolesClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RolesClient"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public RolesClient(ApiConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Creates a new role according to the request.
        /// </summary>
        /// <param name="request">The <see cref="RoleCreateRequest" /> containing the details of the role to create.</param>
        /// <returns>The newly created <see cref="Role" />.</returns>
        public Task<Role> CreateAsync(RoleCreateRequest request)
        {
            return Connection.PostAsync<Role>("roles", request, null, null, null, null, null);
        }

        /// <summary>
        /// Deletes a role.
        /// </summary>
        /// <param name="id">The ID of the role to delete.</param>
        /// <returns>Task.</returns>
        public Task DeleteAsync(string id)
        {
            return Connection.DeleteAsync<object>("roles/{id}", new Dictionary<string, string>
            {
                {"id", id}
            }, null);
        }

        /// <inheritdoc />
        public Task<IPagedList<Role>> GetAllAsync(GetRolesRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return Connection.GetAsync<IPagedList<Role>>("roles", null,
                new Dictionary<string, string>
                {
                    {"name_filter", request.NameFilter},
                }, null, new PagedListConverter<Role>("roles"));
        }

        /// <inheritdoc />
        public Task<IPagedList<Role>> GetAllAsync(GetRolesRequest request, PaginationInfo pagination)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            return Connection.GetAsync<IPagedList<Role>>("roles", null,
                new Dictionary<string, string>
                {
                    {"name_filter", request.NameFilter},
                    {"page", pagination.PageNo.ToString()},
                    {"per_page", pagination.PerPage.ToString()},
                    {"include_totals", pagination.IncludeTotals.ToString().ToLower()}
                }, null, new PagedListConverter<Role>("roles"));
        }

        /// <summary>
        /// Retrieves a role by its ID.
        /// </summary>
        /// <param name="id">The ID of the role to retrieve.</param>
        /// <returns>The <see cref="Role" />.</returns>
        public Task<Role> GetAsync(string id)
        {
            return Connection.GetAsync<Role>("roles/{id}",
                new Dictionary<string, string>
                {
                    {"id", id}
                }, null, null, null);
        }

        /// <summary>
        /// Updates a role.
        /// </summary>
        /// <param name="id">The ID of the role to update.</param>
        /// <param name="request">A <see cref="RoleUpdateRequest" /> containing the information to update.</param>
        /// <returns>Task&lt;Role&gt;.</returns>
        public Task<Role> UpdateAsync(string id, RoleUpdateRequest request)
        {
            return Connection.PatchAsync<Role>("roles/{id}", request, new Dictionary<string, string>
            {
                {"id", id}
            });
        }
    }
}
