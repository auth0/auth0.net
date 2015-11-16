using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Models;

namespace Auth0.Api.Management.Clients
{
    public class DeviceCredentialsClient : ClientBase, IDeviceCredentialsClient
    {
        public DeviceCredentialsClient(ApiConnection connection)
            : base(connection)
        {
        }

        public Task<IList<DeviceCredential>> GetAll(string fields = null, bool includeFields = true, string userId = null, string clientId = null, string type = null)
        {
            return Connection.GetAsync<IList<DeviceCredential>>("device-credentials", null,
                new Dictionary<string, string>
                {
                    {"fields", fields},
                    {"include_fields", includeFields.ToString().ToLower()},
                    {"user_id", userId},
                    {"client_id", clientId},
                    {"type", type}
                });
        }

        public Task<DeviceCredential> Create(DeviceCredentialCreateRequest request)
        {
            return Connection.PostAsync<DeviceCredential>("device-credentials", request, null, null);
        }

        public Task Delete(string id)
        {
            return Connection.DeleteAsync<object>("device-credentials/{id}", new Dictionary<string, string>
            {
                {"id", id}
            });
        }
    }
}