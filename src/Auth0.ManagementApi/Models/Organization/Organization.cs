using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models;

public class Organization : OrganizationBase
{
    [JsonProperty("id")]
    public string Id { get; set; }
}