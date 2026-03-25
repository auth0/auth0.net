using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Jobs;

[Serializable]
public record CreateVerificationEmailRequestContent
{
    /// <summary>
    /// user_id of the user to send the verification email to.
    /// </summary>
    [JsonPropertyName("user_id")]
    public required string UserId { get; set; }

    /// <summary>
    /// client_id of the client (application). If no value provided, the global Client ID will be used.
    /// </summary>
    [Optional]
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    [Optional]
    [JsonPropertyName("identity")]
    public Identity? Identity { get; set; }

    /// <summary>
    /// (Optional) Organization ID – the ID of the Organization. If provided, organization parameters will be made available to the email template and organization branding will be applied to the prompt. In addition, the redirect link in the prompt will include organization_id and organization_name query string parameters.
    /// </summary>
    [Optional]
    [JsonPropertyName("organization_id")]
    public string? OrganizationId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
