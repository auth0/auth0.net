using Auth0.Core.Http;

namespace Auth0.AuthorizationApi.Clients
{
    public interface IUsersClient
    {
        
    }
    
    public class UsersClient : ClientBase, IUsersClient
    {
        public UsersClient(IApiConnection apiConnection) : base(apiConnection)
        {
            
        }
    }
}