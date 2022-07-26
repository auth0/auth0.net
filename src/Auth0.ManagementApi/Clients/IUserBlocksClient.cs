namespace Auth0.ManagementApi.Clients
{
  using System.Threading;
  using System.Threading.Tasks;
  using Models;

  public interface IUserBlocksClient
  {
    /// <summary>
    /// Get a user's blocks by identifier.
    /// </summary>
    /// <param name="identifier">The identifier of the user. Can be a user's email address, username or phone number.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="UserBlocks"/> relating to the user requested.</returns>
    Task<UserBlocks> GetByIdentifierAsync(string identifier, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a user's blocks by user id.
    /// </summary>
    /// <param name="id">The id of the user.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="UserBlocks"/> relating to the user requested.</returns>
    Task<UserBlocks> GetByUserIdAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Unblock a user by their identifier.
    /// </summary>
    /// <param name="identifier">The identifier of the user to unblock. Can be a user's email address, username or phone number.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous unblock operation.</returns>
    Task UnblockByIdentifierAsync(string identifier, CancellationToken cancellationToken = default);

    /// <summary>
    /// Unblock a user by their id.
    /// </summary>
    /// <param name="id">The id of the user to unblock.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous unblock operation.</returns>
    Task UnblockByUserIdAsync(string id, CancellationToken cancellationToken = default);
  }
}
