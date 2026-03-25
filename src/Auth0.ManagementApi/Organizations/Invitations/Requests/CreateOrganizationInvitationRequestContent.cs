using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Organizations;

[Serializable]
public record CreateOrganizationInvitationRequestContent
{
    [JsonPropertyName("inviter")]
    public required OrganizationInvitationInviter Inviter { get; set; }

    [JsonPropertyName("invitee")]
    public required OrganizationInvitationInvitee Invitee { get; set; }

    /// <summary>
    /// Auth0 client ID. Used to resolve the application's login initiation endpoint.
    /// </summary>
    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    /// <summary>
    /// The id of the connection to force invitee to authenticate with.
    /// </summary>
    [Optional]
    [JsonPropertyName("connection_id")]
    public string? ConnectionId { get; set; }

    [Optional]
    [JsonPropertyName("app_metadata")]
    public Dictionary<string, object?>? AppMetadata { get; set; }

    [Optional]
    [JsonPropertyName("user_metadata")]
    public Dictionary<string, object?>? UserMetadata { get; set; }

    /// <summary>
    /// Number of seconds for which the invitation is valid before expiration. If unspecified or set to 0, this value defaults to 604800 seconds (7 days). Max value: 2592000 seconds (30 days).
    /// </summary>
    [Optional]
    [JsonPropertyName("ttl_sec")]
    public int? TtlSec { get; set; }

    /// <summary>
    /// List of roles IDs to associated with the user.
    /// </summary>
    [Optional]
    [JsonPropertyName("roles")]
    public IEnumerable<string>? Roles { get; set; }

    /// <summary>
    /// Whether the user will receive an invitation email (true) or no email (false), true by default
    /// </summary>
    [Optional]
    [JsonPropertyName("send_invitation_email")]
    public bool? SendInvitationEmail { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
