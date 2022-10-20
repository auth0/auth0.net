using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols;

namespace Auth0.AuthenticationApi.Tokens
{
    internal class OpenIdConnectDocumentRetriever : IDocumentRetriever
    {
        private readonly IAuthenticationConnection connection;

        public OpenIdConnectDocumentRetriever(IAuthenticationConnection connection)
        {
            this.connection = connection;
        }

        public Task<string> GetDocumentAsync(string address, CancellationToken cancel)
        {
            return connection.GetAsync<string>(new Uri(address), cancellationToken: cancel);
        }
    }
}
