using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Auth0.AuthenticationApi.Models;

/// <summary>
/// Represents a single entry in an OAuth 2.0 Rich Authorization Requests (RAR) <c>authorization_details</c> array.
/// </summary>
/// <remarks>
/// Each entry is identified by its <see cref="Type"/>. All other, type-specific fields are captured in
/// <see cref="AdditionalData"/> so that any RAR schema can be expressed without a fixed model.
/// See <see href="https://auth0.com/docs/get-started/authentication-and-authorization-flow/authorization-code-flow/authorization-code-flow-with-rar">Rich Authorization Requests</see>.
/// </remarks>
public class AuthorizationDetail
{
    /// <summary>
    /// The authorization details type identifier. This is the only field required by RFC 9396.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary>
    /// Any additional, type-specific fields carried by this authorization detail.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalData { get; set; }
}
