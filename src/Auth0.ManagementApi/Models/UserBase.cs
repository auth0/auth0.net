using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Contains common elements used for both constructing <see cref="User"/>-related requests, and comprising <see cref="User"/>-related responses.
    /// </summary>
    public abstract class UserBase
    {
        /// <summary>
        /// Contains user meta data. The user has read-only access to this.
        /// </summary>
        [JsonProperty("app_metadata")]
        public dynamic AppMetadata { get; set; }

        /// <summary>
        /// Gets or sets the user's email address.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets whether the user's email address is verified.
        /// </summary>
        /// <remarks>
        /// True if the email address is verified, otherwise false.
        /// </remarks>
        [JsonProperty("email_verified")]
        public bool? EmailVerified { get; set; }

        /// <summary>
        /// Gets or sets the user's phone number.
        /// </summary>
        /// <remarks>
        /// This is only valid for users from SMS connections.
        /// </remarks>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets whether the user's phone is verified.
        /// </summary>
        /// <remarks>
        /// True if the phone is verified, otherwise false.
        /// </remarks>
        [JsonProperty("phone_verified")]
        public bool? PhoneVerified { get; set; }

        /// <summary>
        /// Contains user meta data. The user has read/write access to this.
        /// </summary>
        [JsonProperty("user_metadata")]
        public dynamic UserMetadata { get; set; }

        /// <summary>
        /// Gets or sets the user' username.
        /// </summary>
        [JsonProperty("username")]
        public string UserName { get; set; }

        /// <summary>
        /// The Nickname of the user.
        /// </summary>
        [JsonProperty("nickname")]
        public string NickName { get; set; }

        /// <summary>
        /// The first name of the user (if available).
        /// </summary>
        /// <remarks>
        /// This is the given_name attribute supplied by the underlying API.
        /// </remarks>
        [JsonProperty("given_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// The full name of the user (e.g.: John Foo). ALWAYS GENERATED.
        /// </summary>
        /// <remarks>
        /// This is the name attribute supplied by the underlying API.
        /// </remarks>
        [JsonProperty("name")]
        public string FullName { get; set; }

        /// <summary>
        /// The last name of the user (if available).
        /// </summary>
        /// <remarks>
        /// This is the family_name attribute supplied by the underlying API.
        /// </remarks>
        [JsonProperty("family_name")]
        public string LastName { get; set; }

        /// <summary>
        /// URL pointing to the user picture (if not available, will use gravatar.com with the email). ALWAYS GENERATED
        /// </summary>
        [JsonProperty("picture")]
        public string Picture { get; set; }

        /// <summary>
        /// Gets or sets whether the user is blocked. True if the user is blocked, otherwise false.
        /// </summary>
        [JsonProperty("blocked")]
        public bool? Blocked { get; set; }

        /// <summary>
        /// Returns <see cref="AppMetadata"/> as specific type.
        /// </summary>
        /// <typeparam name="T">Type to be returned.</typeparam>
        /// <returns>An instance of T.</returns>
        public T GetAppMetadata<T>() where T : class
        {
            if (AppMetadata is JObject jObject)
            {
                return jObject.ToObject<T>();
            }

            return null;
        }

        /// <summary>
        /// Returns <see cref="UserMetadata"/> as specific type.
        /// </summary>
        /// <typeparam name="T">Type to be returned.</typeparam>
        /// <returns>An instance of T.</returns>
        public T GetUserMetadata<T>() where T : class
        {
            if (UserMetadata is JObject jObject)
            {
                return jObject.ToObject<T>();
            }

            return null;
        }

        /// <summary>
        /// Set given appMetadata as <see cref="AppMetadata"/>.
        /// </summary>
        /// <typeparam name="T">Metadata type.</typeparam>
        /// <param name="appMetadata">Metadata to set.</param>
        public void SetAppMetadata<T>(T appMetadata) where T : class
        {
            AppMetadata = JObject.FromObject(appMetadata);
        }

        /// <summary>
        /// Set given userMetadata as <see cref="UserMetadata"/>.
        /// </summary>
        /// <typeparam name="T">Metadata type.</typeparam>
        /// <param name="userMetadata">Metadata to set.</param>
        public void SetUserMetadata<T>(T userMetadata) where T : class
        {
            UserMetadata = JObject.FromObject(userMetadata);
        }
    }
}