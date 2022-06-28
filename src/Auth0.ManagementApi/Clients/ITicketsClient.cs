namespace Auth0.ManagementApi.Clients
{
  using System.Threading;
  using System.Threading.Tasks;
  using Models;

  public interface ITicketsClient
  {
    /// <summary>
    /// Creates an email verification ticket.
    /// </summary>
    /// <param name="request">The <see cref="EmailVerificationTicketRequest"/> containing the details of the ticket to create.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The newly created <see cref="Ticket"/>.</returns>
    Task<Ticket> CreateEmailVerificationTicketAsync(EmailVerificationTicketRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a password change ticket.
    /// </summary>
    /// <param name="request">The <see cref="PasswordChangeTicketRequest"/> containing the details of the ticket to create.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The newly created <see cref="Ticket"/>.</returns>
    Task<Ticket> CreatePasswordChangeTicketAsync(PasswordChangeTicketRequest request, CancellationToken cancellationToken = default);
  }
}
