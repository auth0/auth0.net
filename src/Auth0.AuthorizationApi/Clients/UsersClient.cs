using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0.Core.Http;

namespace Auth0.AuthorizationApi.Clients
{
    public interface IUsersClient
    {
        Task AddToGroupsAsync(AddUserToGroupsRequest request);

        Task<IEnumerable<GroupBase>> GetGroupsAsync(string userId);
    }
    
    public class UsersClient : ClientBase, IUsersClient
    {
        public UsersClient(IApiConnection apiConnection) : base(apiConnection)
        {
            
        }

        public async Task AddToGroupsAsync(AddUserToGroupsRequest request)
        {
            var groups = request.Groups.Select(group => group.Id).ToArray();
            
            await Connection.PatchAsync<Task>("users/{id}/groups", groups, new Dictionary<string, string> { {"id", request.UserId} });
        }

        public async Task<IEnumerable<GroupBase>> GetGroupsAsync(string userId)
        {
            return await Connection.GetAsync<IEnumerable<GroupBase>>("users/{id}/groups", new Dictionary<string, string> {{"id", userId}}, null, null, null, null);
        }
    }

    public class AddUserToGroupsRequest
    {
        public string UserId { get; set; }
        
        public IEnumerable<Group> Groups { get; set; }
    }
}