using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Collections;
using Auth0.Core.Http;
using Newtonsoft.Json;

namespace Auth0.AuthorizationApi.Clients
{
    public interface IGroupsClient
    {
        Task<GroupList> GetGroupsAsync();

        Task DeleteGroupMembersAsync(DeleteGroupMembersRequest request);
    }
    
    public class GroupsClient : ClientBase, IGroupsClient
    {
        public GroupsClient(IApiConnection apiConnection) : base(apiConnection)
        {
            
        }

        public async Task<GroupList> GetGroupsAsync()
        {
            return await Connection.GetAsync<GroupList>("groups", null, null, null, null);
        }

        public async Task DeleteGroupMembersAsync(DeleteGroupMembersRequest request)
        {
            await Connection.DeleteAsync<Task>("groups/{groupId}/members", request.Users, new Dictionary<string, string> {{"groupId", request.Group.Id}}, null);
        }
    }

    public class DeleteGroupMembersRequest
    {
        public Group Group { get; set; }
        
        public IEnumerable<string> Users { get; set; }
    }

    public class GroupList
    {
        [JsonProperty("groups")]
        public IEnumerable<Group> Groups { get; set; }
        
        [JsonProperty("total")]
        public int Total { get; set; }
    }
    
    public class Group
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("members")]
        public IEnumerable<string> Members { get; set; }
        
        [JsonProperty("mappings")]
        public IEnumerable<GroupMapping> Mappings { get; set; }
        
        [JsonProperty("nested")]
        public IEnumerable<string> NestedGroups { get; set; }
        
        [JsonProperty("roles")]
        public IEnumerable<string> Roles { get; set; }
    }

    public class GroupMapping
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        
        [JsonProperty("groupName")]
        public string Name { get; set; }
        
        [JsonProperty("connectionName")]
        public string ConnectionName { get; set; }
    }
}