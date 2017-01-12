using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Represents configuration of mobile apps for a client.
    /// </summary>
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

        /// <summary>
        /// Represents Android configuration for a client.
        /// </summary>
        public class MobileAndroid
        {
            /// <summary>
            /// The package name which uniquely identifies the Android app.
            /// </summary>
            [JsonProperty("app_package_name")]
            public string AppPackageName { get; set; }

            /// <summary>
            /// Gets or sets the keystore hash for an Android app.
            /// </summary>
            /// <value>The keystore hash.</value>
            [JsonProperty("keystore_hash")]
            public string KeystoreHash { get; set; }
        }

        /// <summary>
        /// Represents iOS configuration for a client.
        /// </summary>
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