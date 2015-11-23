using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Models;
using PortableRest;

namespace Auth0.ManagementApi.Client.Clients
{
    public class BlacklistedTokensClient : ClientBase, IBlacklistedTokensClient
    {
        public BlacklistedTokensClient(IApiConnection connection)
            : base(connection)
        {
        }

        public Task<IList<BlacklistedToken>> GetAll(string aud)
        {
            return Connection.GetAsync<IList<BlacklistedToken>>("blacklists/tokens", null,
                new Dictionary<string, string>
                {
                    {"aud", aud}
                });
        }

        public Task Create(BlacklistedTokenCreateRequest request)
        {
            return Connection.PostAsync<Core.Models.Client>("blacklists/tokens", ContentTypes.Json, request, null, null, null, null);
        }
    }
}