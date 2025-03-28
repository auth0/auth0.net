using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models.Mfa
{
    public class AssociateMfaAuthenticatorResponse
    {
        /// <summary>
        /// The code used for out-of-band authentication. 
        /// </summary>
        [JsonProperty("oob_code")]
        public string OobCode { get; set; }

        /// <summary>
        /// Indicates the binding method used.
        /// </summary>
        [JsonProperty("binding_method")]
        public string BindingMethod { get; set; }

        /// <summary>
        /// Type of authenticator added.
        /// </summary>
        [JsonProperty("authenticator_type")]
        public string AuthenticatorType { get; set; }

        /// <summary>
        /// The OOB channels used.
        /// </summary>
        [JsonProperty("oob_channel")]
        public string OobChannel { get; set; }

        /// <summary>
        /// An array of recovery codes generated for the user.
        /// </summary>
        [JsonProperty("recovery_codes")]
        public List<string> RecoveryCodes { get; set; }
        
        /// <summary>
        /// The URI to generate a QR code for the authenticator.
        /// </summary>
        [JsonProperty("barcode_uri")]
        public string BarcodeUri { get; set; }
        
        /// <summary>
        /// The secret to use for the OTP.
        /// </summary>
        [JsonProperty("secret")]
        public string Secret { get; set; }
    }
}