using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <inheritdoc />
    public class CustomDomainsClient : ClientBase, ICustomDomainsClient
    {
        /// <summary>
        /// Creates a new instance of <see cref="CustomDomainsClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        internal CustomDomainsClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <inheritdoc />
        public Task<CustomDomain> CreateAsync(CustomDomainCreateRequest request)
        {
            return Connection.PostAsync<CustomDomain>("custom-domains", request, null, null, null, null, null);
        }

        /// <inheritdoc />
        public Task DeleteAsync(string id)
        {
            return Connection.DeleteAsync<object>("custom-domains/{id}", 
                new Dictionary<string, string>
                {
                    {"id", id}
                }, null);
        }

        /// <inheritdoc />
        public Task<IList<CustomDomain>> GetAllAsync()
        {
            return Connection.GetAsync<IList<CustomDomain>>("custom-domains", null, null, null, null);
        }

        /// <inheritdoc />
        public Task<CustomDomain> GetAsync(string id)
        {
            return Connection.GetAsync<CustomDomain>("custom-domains/{id}",
                new Dictionary<string, string>
                {
                    {"id", id}
                },
                null, null, null);
        }

        /// <inheritdoc />
        public Task<CustomDomainVerificationResponse> VerifyAsync(string id)
        {
            return Connection.PostAsync<CustomDomainVerificationResponse>("custom-domains/{id}/verify", null, null, null, 
                new Dictionary<string, string>
                {
                    {"id", id}
                }, null, null);
        }
    }
}