using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /tickets endpoints.
    /// </summary>
    public class TicketsClient : ClientBase
    {
        /// <summary>
        /// Creates a new instance of <see cref="TicketsClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public TicketsClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Creates an email verification ticket.
        /// </summary>
        /// <param name="request">The <see cref="EmailVerificationTicketRequest"/> containing the details of the ticket to create.</param>
        /// <returns>The <see cref="Ticket"/>.</returns>
        public Task<Ticket> CreateEmailVerificationTicketAsync(EmailVerificationTicketRequest request)
        {
            return Connection.PostAsync<Ticket>("tickets/email-verification", request, null, null, null, null, null);
        }

        /// <summary>
        /// Creates a password change ticket.
        /// </summary>
        /// <param name="request">The <see cref="PasswordChangeTicketRequest"/> containing the details of the ticket to create.</param>
        /// <returns>The <see cref="Ticket"/>.</returns>
        public Task<Ticket> CreatePasswordChangeTicketAsync(PasswordChangeTicketRequest request)
        {
            return Connection.PostAsync<Ticket>("tickets/password-change", request, null, null, null, null, null);
        }
    }
}