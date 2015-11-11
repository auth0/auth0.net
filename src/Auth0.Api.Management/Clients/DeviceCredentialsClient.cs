using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Models;

namespace Auth0.Api.Management.Clients
{
    public class DeviceCredentialsClient : IDeviceCredentialsClient
    {
        private ApiConnection apiConnection;

        public DeviceCredentialsClient(ApiConnection apiConnection)
        {
            this.apiConnection = apiConnection;
        }

        public Task<IList<DeviceCredential>> GetAll(string fields = null, bool includeFields = true, string userId = null, string clientId = null, string type = null)
        {
            return apiConnection.GetAsync<IList<DeviceCredential>>("device-credentials", null,
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
            return apiConnection.PostAsync<DeviceCredential>("device-credentials", request);
        }

        public Task Delete(string id)
        {
            return apiConnection.DeleteAsync<object>("device-credentials/{id}", new Dictionary<string, string>
            {
                {"id", id}
            });
        }
    }
}