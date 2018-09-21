using Auth0.Core.Http;

namespace Auth0.AuthorizationApi.Clients
{
    public abstract class ClientBase
    {
        protected IApiConnection Connection { get; }
        
        internal ClientBase(IApiConnection apiConnection)
        {
            Connection = apiConnection;
        }
    }
}