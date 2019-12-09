using Auth0.ManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /tickets endpoints.
    /// </summary>
    public class TicketsClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of <see cref="TicketsClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders"><see cref="IDictionary{string, string}"/> containing default headers included with every request this client makes.</param>
        public TicketsClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
            : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <summary>
        /// Creates an email verification ticket.
        /// </summary>
        /// <param name="request">The <see cref="EmailVerificationTicketRequest"/> containing the details of the ticket to create.</param>
        /// <returns>The newly created <see cref="Ticket"/>.</returns>
        public Task<Ticket> CreateEmailVerificationTicketAsync(EmailVerificationTicketRequest request)
        {
            return Connection.SendAsync<Ticket>(HttpMethod.Post, BuildUri("tickets/email-verification"), request, DefaultHeaders);
        }

        /// <summary>
        /// Creates a password change ticket.
        /// </summary>
        /// <param name="request">The <see cref="PasswordChangeTicketRequest"/> containing the details of the ticket to create.</param>
        /// <returns>The newly created <see cref="Ticket"/>.</returns>
        public Task<Ticket> CreatePasswordChangeTicketAsync(PasswordChangeTicketRequest request)
        {
            return Connection.SendAsync<Ticket>(HttpMethod.Post, BuildUri("tickets/password-change"), request, DefaultHeaders);
        }
    }
}