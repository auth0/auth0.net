using Auth0.Core.Http;

namespace Auth0.AuthorizationApi.Clients
{
    public interface IRolesClient
    {
        
    }
    
    public class RolesClient : ClientBase, IRolesClient
    {
        public RolesClient(IApiConnection apiConnection) : base(apiConnection)
        {
            
        }
    }
}