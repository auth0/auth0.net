using System.Collections.Generic;

using Newtonsoft.Json;

using Auth0.AuthenticationApi.Models;
using Auth0.Core.Serialization;

namespace Auth0.AuthenticationApi.Models.Ciba;

public class ClientInitiatedBackchannelAuthorizationTokenResponse : AccessTokenResponse
{
    [JsonProperty("scope")]
    public string Scope { get; set; }

    /// <summary>
    /// Raw <c>authorization_details</c> JSON returned by the token endpoint as part of a
    /// Rich Authorization Requests (RAR) flow. Use <see cref="AuthorizationDetails"/> for a strongly-typed view.
    /// </summary>
    [JsonProperty("authorization_details")]
    [JsonConverter(typeof(StringOrObjectAsStringConverter))]
    public string AuthorizationDetailsRaw { get; set; }

    /// <summary>
    /// Strongly-typed view of the <c>authorization_details</c> returned by the token endpoint.
    /// Returns <see langword="null"/> when no authorization details were returned.
    /// </summary>
    [Newtonsoft.Json.JsonIgnore]
    public IReadOnlyList<AuthorizationDetail> AuthorizationDetails =>
        string.IsNullOrEmpty(AuthorizationDetailsRaw)
            ? null
            : System.Text.Json.JsonSerializer.Deserialize<IReadOnlyList<AuthorizationDetail>>(AuthorizationDetailsRaw);
}
