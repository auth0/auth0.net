using System.Threading.Tasks;
using Auth0.Core.Models;

namespace Auth0.Api.Management.Clients
{
    public class TicketsClient : ClientBase, ITicketsClient
    {
        public TicketsClient(IApiConnection connection)
            : base(connection)
        {
        }

        public Task<Ticket> CreateEmailVerificationTicket(EmailVerificationTicketRequest request)
        {
            return Connection.PostAsync<Ticket>("tickets/email-verification", request, null, null, null);
        }

        public Task<Ticket> CreatePasswordChangeTicket(PasswordChangeTicketRequest request)
        {
            return Connection.PostAsync<Ticket>("tickets/password-change", request, null, null, null);
        }
    }
}