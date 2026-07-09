using System.Collections.Generic;

using System.Text.Json.Serialization;

namespace Auth0.AuthenticationApi.Models.Mfa;

public class AssociateMfaAuthenticatorResponse
{
    /// <summary>
    /// The code used for out-of-band authentication. 
    /// </summary>
    [JsonPropertyName("oob_code")]
    public string OobCode { get; set; }

    /// <summary>
    /// Indicates the binding method used.
    /// </summary>
    [JsonPropertyName("binding_method")]
    public string BindingMethod { get; set; }

    /// <summary>
    /// Type of authenticator added.
    /// </summary>
    [JsonPropertyName("authenticator_type")]
    public string AuthenticatorType { get; set; }

    /// <summary>
    /// The OOB channels used.
    /// </summary>
    [JsonPropertyName("oob_channel")]
    public string OobChannel { get; set; }

    /// <summary>
    /// An array of recovery codes generated for the user.
    /// </summary>
    [JsonPropertyName("recovery_codes")]
    public List<string> RecoveryCodes { get; set; }
        
    /// <summary>
    /// The URI to generate a QR code for the authenticator.
    /// </summary>
    [JsonPropertyName("barcode_uri")]
    public string BarcodeUri { get; set; }
        
    /// <summary>
    /// The secret to use for the OTP.
    /// </summary>
    [JsonPropertyName("secret")]
    public string Secret { get; set; }
}