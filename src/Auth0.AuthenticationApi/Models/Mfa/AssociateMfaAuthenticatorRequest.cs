using System.Collections.Generic;

using System.Text.Json.Serialization;

namespace Auth0.AuthenticationApi.Models.Mfa;

public class AssociateMfaAuthenticatorRequest
{
    /// <summary>
    /// If the user has active authenticators, an Access Token with the enroll scope and the audience OR
    /// If the user has no active authenticators, you can use the mfa_token from the mfa_required error in place
    /// of an Access Token for this request.
    /// </summary>
    [JsonIgnore]
    public string Token { get; set; }

    /// <summary>
    /// Your application's Client ID.
    /// </summary>
    [JsonPropertyName("client_id")]
    public string ClientId { get; set; }

    /// <summary>
    /// A JWT containing a signed assertion with your application credentials.
    /// Required when Private Key JWT is your application authentication method.
    /// </summary>
    [JsonPropertyName("client_assertion")]
    public string ClientAssertion { get; set; }

    /// <summary>
    /// The value is urn:ietf:params:oauth:client-assertion-type:jwt-bearer.
    /// Required when Private Key JWT is the application authentication method.
    /// </summary>
    [JsonPropertyName("client_assertion_type")]
    public string ClientAssertionType { get; set; }

    /// <summary>
    /// Your application's Client Secret.
    /// Required when the Token Endpoint Authentication Method field in your Application Settings is Post or Basic.
    /// </summary>
    [JsonPropertyName("client_secret")]
    public string ClientSecret { get; set; }

    /// <summary>
    /// The type of authenticators supported by the client.
    /// Value is an array with values "otp" or "oob".
    /// </summary>
    [JsonPropertyName("authenticator_types")]
    public string[] AuthenticatorTypes { get; set; }

    /// <summary>
    /// The type of OOB channels supported by the client.
    /// Required if authenticator_types include oob.
    /// </summary>
    [JsonPropertyName("oob_channels")]
    public List<string> OobChannels { get; set; }

    /// <summary>
    /// The phone number to use for SMS or Voice.
    /// Required if oob_channels includes sms or voice.
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }
}