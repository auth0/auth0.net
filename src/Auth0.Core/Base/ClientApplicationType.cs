using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Auth0.Core
{
    /// <summary>
    /// The type of application for a <see cref="Client"/>
    /// </summary>
    public enum ClientApplicationType
    {
        /// <summary>
        /// Mobile or Desktop, apps that run natively in a device.
        /// </summary>
        [EnumMember(Value = "native")]
        Native,

        /// <summary>
        /// A JavaScript front-end app that uses an API.
        /// </summary>
        [EnumMember(Value = "spa")]
        Spa,

        /// <summary>
        /// Traditional web app (with refresh).
        /// </summary>
        [EnumMember(Value = "regular_web")]
        RegularWeb,

        /// <summary>
        /// CLI, Daemons or Services running on your backend.
        /// </summary>
        [EnumMember(Value = "non_interactive")]
        NonInteractive
    }
}