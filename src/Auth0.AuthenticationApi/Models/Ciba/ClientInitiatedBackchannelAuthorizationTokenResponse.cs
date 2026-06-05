using System;
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
    private bool _authorizationDetailsParsed;
    private IReadOnlyList<AuthorizationDetail> _authorizationDetails;

    [Newtonsoft.Json.JsonIgnore]
    public IReadOnlyList<AuthorizationDetail> AuthorizationDetails
    {
        get
        {
            if (_authorizationDetailsParsed)
                return _authorizationDetails;

            if (string.IsNullOrEmpty(AuthorizationDetailsRaw))
                return null;

            try
            {
                _authorizationDetails = System.Text.Json.JsonSerializer.Deserialize<IReadOnlyList<AuthorizationDetail>>(AuthorizationDetailsRaw);
                _authorizationDetailsParsed = true;
                return _authorizationDetails;
            }
            catch (System.Text.Json.JsonException ex)
            {
                throw new InvalidOperationException(
                    "Failed to deserialize the 'authorization_details' returned by the token endpoint.", ex);
            }
        }
    }
}
