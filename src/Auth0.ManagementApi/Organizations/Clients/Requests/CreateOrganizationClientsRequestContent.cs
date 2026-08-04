using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Organizations;

[Serializable]
public record CreateOrganizationClientsRequestContent
{
    /// <summary>
    /// List of clients to associate with the organization.
    /// </summary>
    [JsonPropertyName("clients")]
    public IEnumerable<CreateOrganizationClientRequestItem> Clients { get; set; } =
        new List<CreateOrganizationClientRequestItem>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
