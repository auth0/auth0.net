using Newtonsoft.Json;

namespace Auth0.Core.Models
{
    public class Mobile
    {
        [JsonProperty("android")]
        public MobileAndroid Android { get; set; }

        [JsonProperty("ios")]
        public MobileIos Ios { get; set; }

        public class MobileAndroid
        {
            [JsonProperty("app_package_name")]
            public string AppPackageName { get; set; }

            [JsonProperty("keystore_hash")]
            public string KeystoreHash { get; set; }
        }


        public class MobileIos
        {
            [JsonProperty("app_bundle_identifier")]
            public string AppBundleIdentifier { get; set; }

            [JsonProperty("team_id")]
            public string TeamId { get; set; }
        }
    }
}