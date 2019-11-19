using Auth0.Core.Http;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// The base class from which all clients inherit. Give clients access to the underlying <see cref="ILegacyApiConnection"/>.
    /// </summary>
    public class ClientBase
    {
        /// <summary>
        /// The <see cref="ILegacyApiConnection"/> which is used to make all HTTP API calls.
        /// </summary>
        internal ILegacyApiConnection Connection { get; }

        /// <summary>
        /// Creates a new instance of <see cref="ClientBase"/>.
        /// </summary>
        /// <param name="connection">The <see cref="ILegacyApiConnection"/> which is used to communicate with the API.</param>
        internal ClientBase(ILegacyApiConnection connection)
        {
            Connection = connection;
        }
    }
}