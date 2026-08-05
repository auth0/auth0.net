using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Organizations;

[Serializable]
public record DeleteOrganizationClientsRequestContent
{
    /// <summary>
    /// List of client IDs to disassociate from the organization.
    /// </summary>
    [JsonPropertyName("clients")]
    public IEnumerable<string> Clients { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
