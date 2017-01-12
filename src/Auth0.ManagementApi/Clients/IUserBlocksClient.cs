using System.Threading.Tasks;
using Auth0.Core;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods for the /user-blocks endpoints
    /// </summary>
    public interface IUserBlocksClient
    {
        /// <summary>
        /// Get a user's blocks by identifier.
        /// </summary>
        /// <param name="identifier">The identifier of the user. Can be a user's email address, username or phone number</param>
        /// <returns></returns>
        Task<UserBlocks> GetByIdentifierAsync(string identifier);

        /// <summary>
        /// Get a user's blocks by user id.
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <returns></returns>
        Task<UserBlocks> GetByUserIdAsync(string id);

        /// <summary>
        /// Unblock a user by their identifier.
        /// </summary>
        /// <param name="identifier">The identifier of the user. Can be a user's email address, username or phone number</param>
        /// <returns></returns>
        Task UnblockByIdentifierAsync(string identifier);

        /// <summary>
        /// Unblock a user by their id.
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <returns></returns>
        Task UnblockByUserIdAsync(string id);
    }
}