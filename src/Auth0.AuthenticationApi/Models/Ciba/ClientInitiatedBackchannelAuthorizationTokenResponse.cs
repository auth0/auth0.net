using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

using Auth0.AuthenticationApi.Models;
using Auth0.Core.Serialization;

namespace Auth0.AuthenticationApi.Models.Ciba;

public class ClientInitiatedBackchannelAuthorizationTokenResponse : AccessTokenResponse
{
    /// <summary>
    /// Raw <c>authorization_details</c> JSON returned by the token endpoint as part of a
    /// Rich Authorization Requests (RAR) flow. Use <see cref="AuthorizationDetails"/> for a strongly-typed view.
    /// </summary>
    [JsonPropertyName("authorization_details")]
    [JsonConverter(typeof(StringOrObjectAsStringConverter))]
    public string AuthorizationDetailsRaw { get; set; }

    private bool _authorizationDetailsParsed;
    private IReadOnlyList<AuthorizationDetail> _authorizationDetails;

    /// <summary>
    /// Strongly-typed view of the <c>authorization_details</c> returned by the token endpoint.
    /// Returns <see langword="null"/> when no authorization details were returned.
    /// </summary>
    [JsonIgnore]
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
                _authorizationDetails = JsonSerializer.Deserialize<IReadOnlyList<AuthorizationDetail>>(AuthorizationDetailsRaw);
                _authorizationDetailsParsed = true;
                return _authorizationDetails;
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException(
                    "Failed to deserialize the 'authorization_details' returned by the token endpoint.", ex);
            }
        }
    }
}
