using System.Reflection;
using Newtonsoft.Json;

#if MANAGEMENT_API
namespace Auth0.ManagementApi.Client.Diagnostics
#elif AUTHENTICATION_API
namespace Auth0.AuthenticationApi.Client.Diagnostics
#endif
{
    /// <summary>
    /// Represents information about a software component that's used for diagnostic purposes.
    /// </summary>
    public class DiagnosticsComponent
    {
        internal DiagnosticsComponent() { }

        /// <summary>
        /// Creates a new instance with the specified name and version.
        /// </summary>
        public DiagnosticsComponent(string name, object version)
        {
            this.Name = name;
            this.Version = version.ToString();
        }

        /// <summary>
        /// Creates a new instance by examining the specified <see cref="AssemblyName"/>.
        /// </summary>
        public DiagnosticsComponent(AssemblyName assemblyName)
        {
            this.Name = assemblyName.Name;
            this.Version = assemblyName.Version.ToString();
        }

        /// <summary>
        /// Gets the name of the component.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; internal set; }

        /// <summary>
        /// Gets the version of the component.
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; internal set; }
    }
}