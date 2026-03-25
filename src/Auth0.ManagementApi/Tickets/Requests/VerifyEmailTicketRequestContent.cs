using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record VerifyEmailTicketRequestContent
{
    /// <summary>
    /// URL the user will be redirected to in the classic Universal Login experience once the ticket is used. Cannot be specified when using client_id or organization_id.
    /// </summary>
    [Optional]
    [JsonPropertyName("result_url")]
    public string? ResultUrl { get; set; }

    /// <summary>
    /// user_id of for whom the ticket should be created.
    /// </summary>
    [JsonPropertyName("user_id")]
    public required string UserId { get; set; }

    /// <summary>
    /// ID of the client (application). If provided for tenants using the New Universal Login experience, the email template and UI displays application details, and the user is prompted to redirect to the application's <see href="https://auth0.com/docs/authenticate/login/auth0-universal-login/configure-default-login-routes#completing-the-password-reset-flow">default login route</see> after the ticket is used. client_id is required to use the <see href="https://auth0.com/docs/customize/actions/flows-and-triggers/post-change-password-flow">Password Reset Post Challenge</see> trigger.
    /// </summary>
    [Optional]
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    /// <summary>
    /// (Optional) Organization ID – the ID of the Organization. If provided, organization parameters will be made available to the email template and organization branding will be applied to the prompt. In addition, the redirect link in the prompt will include organization_id and organization_name query string parameters.
    /// </summary>
    [Optional]
    [JsonPropertyName("organization_id")]
    public string? OrganizationId { get; set; }

    /// <summary>
    /// Number of seconds for which the ticket is valid before expiration. If unspecified or set to 0, this value defaults to 432000 seconds (5 days).
    /// </summary>
    [Optional]
    [JsonPropertyName("ttl_sec")]
    public int? TtlSec { get; set; }

    /// <summary>
    /// Whether to include the email address as part of the returnUrl in the reset_email (true), or not (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("includeEmailInRedirect")]
    public bool? IncludeEmailInRedirect { get; set; }

    [Optional]
    [JsonPropertyName("identity")]
    public Identity? Identity { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
