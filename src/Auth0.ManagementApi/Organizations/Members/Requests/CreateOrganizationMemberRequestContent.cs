using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Organizations;

[Serializable]
public record CreateOrganizationMemberRequestContent
{
    /// <summary>
    /// List of user IDs to add to the organization as members.
    /// </summary>
    [JsonPropertyName("members")]
    public IEnumerable<string> Members { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
