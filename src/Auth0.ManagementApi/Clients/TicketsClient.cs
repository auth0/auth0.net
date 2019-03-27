using System.Threading.Tasks;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /tickets endpoints.
    /// </summary>
    public class TicketsClient : ClientBase, ITicketsClient
    {
        /// <summary>
        /// Creates a new instance of <see cref="TicketsClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public TicketsClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <inheritdoc />
        public Task<Ticket> CreateEmailVerificationTicketAsync(EmailVerificationTicketRequest request)
        {
            return Connection.PostAsync<Ticket>("tickets/email-verification", request, null, null, null, null, null);
        }

        /// <inheritdoc />
        public Task<Ticket> CreatePasswordChangeTicketAsync(PasswordChangeTicketRequest request)
        {
            return Connection.PostAsync<Ticket>("tickets/password-change", request, null, null, null, null, null);
        }
    }
}