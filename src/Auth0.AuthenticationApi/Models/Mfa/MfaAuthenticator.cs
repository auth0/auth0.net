using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models.Mfa;

public class Authenticator
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("authenticator_type")]
    public string AuthenticatorType { get; set; }

    [JsonProperty("oob_channel")]
    public string OobChannel { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("active")]
    public bool Active { get; set; }
}