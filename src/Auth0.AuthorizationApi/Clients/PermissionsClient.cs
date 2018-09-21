using Auth0.Core.Http;

namespace Auth0.AuthorizationApi.Clients
{
    public interface IPermissionsClient
    {
        
    }
    
    public class PermissionsClient : ClientBase, IPermissionsClient
    {
        public PermissionsClient(IApiConnection apiConnection) : base(apiConnection)
        {
            
        }
    }
}