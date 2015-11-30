using Newtonsoft.Json;

namespace Auth0.Core
{
    public class Mobile
    {
        /// <summary>
        /// Configuration related to Android native apps.
        /// </summary>
        [JsonProperty("android")]
        public MobileAndroid Android { get; set; }

        /// <summary>
        /// Configuration related to iOS native apps
        /// </summary>
        [JsonProperty("ios")]
        public MobileIos Ios { get; set; }

        public class MobileAndroid
        {
            /// <summary>
            /// The package name uniquely identifies the app.
            /// </summary>
            [JsonProperty("app_package_name")]
            public string AppPackageName { get; set; }

            [JsonProperty("keystore_hash")]
            public string KeystoreHash { get; set; }
        }


        public class MobileIos
        {
            /// <summary>
            /// The Bundle identifier for the iOS app.
            /// </summary>
            [JsonProperty("app_bundle_identifier")]
            public string AppBundleIdentifier { get; set; }

            /// <summary>
            /// The iOS Developer Account Team identifier.
            /// </summary>
            [JsonProperty("team_id")]
            public string TeamId { get; set; }
        }
    }
}