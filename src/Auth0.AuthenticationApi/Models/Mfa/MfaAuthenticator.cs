using System.Text.Json.Serialization;

namespace Auth0.AuthenticationApi.Models.Mfa;

public class Authenticator
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("authenticator_type")]
    public string AuthenticatorType { get; set; }

    [JsonPropertyName("oob_channel")]
    public string OobChannel { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("active")]
    public bool Active { get; set; }
}