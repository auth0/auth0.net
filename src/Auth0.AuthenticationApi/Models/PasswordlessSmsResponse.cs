using System.Text.Json.Serialization;

namespace Auth0.AuthenticationApi.Models;

/// <summary>
/// Represents the response from a Passwordless SMS request.
/// </summary>
public class PasswordlessSmsResponse
{
    /// <summary>
    /// Unique identifier of the request.
    /// </summary>
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    /// <summary>
    /// Phone number to which the code was sent.
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Language the message sent was written in.
    /// </summary>
    /// <remarks>
    /// On deserialization this is a <see cref="System.Text.Json.JsonElement"/> (previously a
    /// Newtonsoft <c>JToken</c>). Read the value via the <c>JsonElement</c> API, e.g.
    /// <c>((JsonElement)response.RequestLanguage).GetString()</c>.
    /// </remarks>
    [JsonPropertyName("request_language")]
    public object RequestLanguage { get; set; }
}