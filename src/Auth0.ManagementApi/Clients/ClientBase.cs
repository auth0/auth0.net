using Auth0.Core.Http;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// The base class from which all clients inherit. Give clients access to the underlying <see cref="IApiConnection"/>.
    /// </summary>
    public class ClientBase
    {
        /// <summary>
        /// The <see cref="IApiConnection"/> which is used to make all API calls.
        /// </summary>
        internal IApiConnection Connection { get; }

        /// <summary>
        /// Creates a new instance of the ClientBase class.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection"/> which is used to communicate with the API.</param>
        internal ClientBase(IApiConnection connection)
        {
            Connection = connection;
        }
    }
}