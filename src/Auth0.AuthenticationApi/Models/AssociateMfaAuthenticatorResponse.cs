using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    public class AssociateMfaAuthenticatorResponse
    {
        [JsonProperty("oob_code")]
        public string OobCode { get; set; }

        [JsonProperty("binding_method")]
        public string BindingMethod { get; set; }

        [JsonProperty("secret")]
        public string Secret { get; set; }

        [JsonProperty("barcode_uri")]
        public string BarcodeUri { get; set; }

        [JsonProperty("authenticator_type")]
        public string AuthenticatorType { get; set; }

        [JsonProperty("oob_channel")]
        public string OobChannel { get; set; }

        [JsonProperty("recovery_codes")]
        public List<string> RecoveryCodes { get; set; }
    }
}
