using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class PasswordChangeTicketRequest
    {
        /// <summary>
        /// The user will be redirected to this endpoint once the ticket is used.
        /// </summary>
        [JsonProperty("result_url")]
        public string ResultUrl { get; set; }

        /// <summary>
        /// The user ID for which the ticket is to be created.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// The connection that provides the identity for which the password is to be changed. If sending this parameter, the <see cref="Email"/> is also required and the <see cref="UserId"/> is invalid.
        /// </summary>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        /// <summary>
        /// The user's email.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// The ticket's lifetime in seconds starting from the moment of creation. 
        /// After expiration the ticket can not be used to change the users's password. 
        /// If not specified or if you send 0 the Auth0 default lifetime will be applied
        /// </summary>
        [JsonProperty("ttl_sec")]
        public int? Ttl { get; set; }

        /// <summary>
        /// Whether the email_verified attribute will be set once the password is changed.
        /// </summary>
        [JsonProperty("mark_email_as_verified")]
        public bool? MarkEmailAsVerified { get; set; }

        /// <summary>
        /// Whether the reset_email will include the email as part of the returnUrl.
        /// </summary>
        [JsonProperty("includeEmailInRedirect")]
        public bool? IncludeEmailInRedirect { get; set; }

        /// <summary>
        /// ID of the client.
        /// If provided for tenants using the New Universal Login experience, 
        /// the user will be prompted to redirect to the default login route of the corresponding application once the ticket is used.
        /// See <see href="https://auth0.com/docs/universal-login/configure-default-login-routes">Configuring Default Login Routes</see> for more details.
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// The organization ID.
        /// </summary>
        /// <summary>
        /// If provided the organization_id and organization_name will be included in the redirection URL querystring
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
    }
}