using Auth0.Core.Collections;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <inheritdoc />
    public class ClientsClient : ClientBase, IClientsClient
    {
        /// <summary>
        /// Creates a new instance of <see cref="ClientsClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public ClientsClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <inheritdoc />
        public Task<Client> CreateAsync(ClientCreateRequest request)
        {
            return Connection.PostAsync<Client>("clients", request, null, null, null, null, null);
        }

        /// <inheritdoc />
        public Task DeleteAsync(string id)
        {
            return Connection.DeleteAsync<object>("clients/{id}", 
                new Dictionary<string, string>
                {
                    {"id", id}
                }, null);
        }

        /// <inheritdoc />
        public Task<IPagedList<Client>> GetAllAsync(GetClientsRequest request, PaginationInfo pagination)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            var queryStrings = new Dictionary<string, string>
            {
                {"fields", request.Fields},
                {"include_fields", request.IncludeFields?.ToString().ToLower()},
                {"is_global", request.IsGlobal?.ToString().ToLower()},
                {"is_first_party", request.IsFirstParty?.ToString().ToLower()},
                {"page", pagination.PageNo.ToString()},
                {"per_page", pagination.PerPage.ToString()},
                {"include_totals", pagination.IncludeTotals.ToString().ToLower()},
            };

            if (request.AppType != null)
            {
                queryStrings.Add("app_type", string.Join(",", request.AppType.Select(ToEnumString)));
            }

            return Connection.GetAsync<IPagedList<Client>>("clients", null, queryStrings, null, new PagedListConverter<Client>("clients"));
        }

        /// <inheritdoc />
        public Task<Client> GetAsync(string id, string fields = null, bool includeFields = true)
        {
            return Connection.GetAsync<Client>("clients/{id}",
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
        public Task<Client> RotateClientSecret(string id)
        {
            return Connection.PostAsync<Client>("clients/{id}/rotate-secret", null, null, null, 
                new Dictionary<string, string>
                {
                    {"id", id}
                }, null, null);
        }

        /// <inheritdoc />
        public Task<Client> UpdateAsync(string id, ClientUpdateRequest request)
        {
            return Connection.PatchAsync<Client>("clients/{id}", request, 
                new Dictionary<string, string>
                {
                    {"id", id}
                });
        }

        private string ToEnumString<T>(T type)
        {
            var enumType = typeof(T);
            var name = Enum.GetName(enumType, type);
            var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetTypeInfo().GetDeclaredField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
            return enumMemberAttribute.Value;
        }
    }
}