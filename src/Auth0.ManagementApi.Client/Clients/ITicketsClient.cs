using System.Threading.Tasks;
using Auth0.Core.Models;

namespace Auth0.ManagementApi.Client.Clients
{
    public interface ITicketsClient
    {
        /// <summary>
        /// Creates an email verification ticket.
        /// </summary>
        /// <param name="request">The <see cref="EmailVerificationTicketRequest"/> containing the details of the ticket to create.</param>
        /// <returns>The <see cref="Ticket"/>.</returns>
        Task<Ticket> CreateEmailVerificationTicket(EmailVerificationTicketRequest request);

        /// <summary>
        /// Creates a password change ticket.
        /// </summary>
        /// <param name="request">The <see cref="PasswordChangeTicketRequest"/> containing the details of the ticket to create.</param>
        /// <returns>The <see cref="Ticket"/>.</returns>
        Task<Ticket> CreatePasswordChangeTicket(PasswordChangeTicketRequest request);
    }
}