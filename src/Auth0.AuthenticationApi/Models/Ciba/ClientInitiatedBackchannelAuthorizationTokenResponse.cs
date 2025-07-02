using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models.Ciba;

public class ClientInitiatedBackchannelAuthorizationTokenResponse : AccessTokenResponse
{
    [JsonProperty("scope")]
    public string Scope { get; set; }
}