using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods for the /user-blocks endpoints
    /// </summary>
    public class UserBlocksClient : ClientBase, IUserBlocksClient
    {
        /// <summary>
        /// Creates a new instance of <see cref="UserBlocksClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public UserBlocksClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <inheritdoc />
        public Task<UserBlocks> GetByIdentifierAsync(string identifier)
        {
            return Connection.GetAsync<UserBlocks>("user-blocks",
                null,
                new Dictionary<string, string>
                {
                    {"identifier", identifier}
                }, null, null);
        }

        /// <inheritdoc />
        public Task<UserBlocks> GetByUserIdAsync(string id)
        {
            return Connection.GetAsync<UserBlocks>("user-blocks/{id}",
                new Dictionary<string, string>
                {
                    {"id", id}
                },
                null, null, null);
        }

        /// <inheritdoc />
        public Task UnblockByIdentifierAsync(string identifier)
        {
            return Connection.DeleteAsync<object>("user-blocks",
                null,
                new Dictionary<string, string>
                {
                    {"identifier", identifier}
                });
        }

        /// <inheritdoc />
        public Task UnblockByUserIdAsync(string id)
        {
            return Connection.DeleteAsync<object>("user-blocks/{id}", 
                new Dictionary<string, string>
                {
                    {"id", id}
                }, null);
        }
    }
}