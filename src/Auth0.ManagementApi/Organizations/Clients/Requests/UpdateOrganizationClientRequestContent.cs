using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Organizations;

[Serializable]
public record UpdateOrganizationClientRequestContent
{
    /// <summary>
    /// Whether this client is used for member access to the organization.
    /// </summary>
    [Optional]
    [JsonPropertyName("use_for_member_access")]
    public bool? UseForMemberAccess { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
