using System.Threading;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models.Grants;
using Auth0.ManagementApi.Paging;

namespace Auth0.ManagementApi.Clients
{
    public interface IGrantsClient
    {
        /// <summary>
        /// Retrieve all Grants.
        /// </summary>
        /// <remarks>
        /// A token with scope read:grants is needed
        /// </remarks>
        /// <param name="request">Specifies criteria to use when querying grants.</param>
        /// <param name="pagination">Specifies pagination info to use.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>An <see cref="IPagedList{Grant}"/> containing the grants.</returns>
        Task<IPagedList<Grant>> GetAllAsync(GetGrantsRequest request, PaginationInfo pagination = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete an existing Grant
        /// </summary>
        /// <remarks>
        /// A token with scope delete:grants is needed.
        /// </remarks>
        /// <param name="id">The ID of the grant to delete.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        Task DeleteAsync(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes all Grants of a given user. 
        /// </summary>
        /// <remarks>
        /// A token with scope delete:grants is needed.
        /// </remarks>
        /// <param name="id">The ID of the user.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        Task DeleteAllAsync(string userId, CancellationToken cancellationToken = default);
    }
}
