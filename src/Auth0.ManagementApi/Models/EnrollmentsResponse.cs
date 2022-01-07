using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Represents a Guardian Enrollment.
    /// </summary>
    public class EnrollmentsResponse
    {
        /// <summary>
        /// Enrollment generated id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Enrollment status.
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EnrollmentStatus Status { get; set; }

        /// <summary>
        /// Enrollment type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Enrollment name (usually phone number).
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Device identifier (usually phone identifier) of this enrollment.
        /// </summary>
        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        /// <summary>
        /// Phone number for this enrollment. 
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Authentication method for this enrollment. Can be `authenticator`, `guardian`, `sms`, `webauthn-roaming` or `webauthn-platform`.
        /// </summary>
        [JsonProperty("auth_method")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EnrollmentAuthMethod AuthMethod { get; set; }

        /// <summary>
        /// Start date and time of this enrollment.
        /// </summary>
        [JsonProperty("enrolled_at")]
        public DateTime EnrolledAt { get; set; }

        /// <summary>
        /// Last authentication date and time of this enrollment.
        /// </summary>
        [JsonProperty("last_auth")]
        public DateTime LastAuth { get; set; }
    }
}