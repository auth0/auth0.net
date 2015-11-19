using System.Threading.Tasks;
using Auth0.Core.Models;
using PortableRest;

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
            return Connection.PostAsync<Ticket>("tickets/email-verification", ContentTypes.Json, request, null, null, null, null);
        }

        public Task<Ticket> CreatePasswordChangeTicket(PasswordChangeTicketRequest request)
        {
            return Connection.PostAsync<Ticket>("tickets/password-change", ContentTypes.Json, request, null, null, null, null);
        }
    }
}