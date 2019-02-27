using System;
using System.Reflection;
using Newtonsoft.Json;

namespace Auth0.Core.Http
{
    /// <summary>
    /// Represents information about a software component that's used for diagnostic purposes.
    /// </summary>
    [Obsolete("Diagnostics are now automatic and not configurable. This class will be removed in a future update.")]
    public class DiagnosticsComponent
    {
        internal DiagnosticsComponent() { }

        /// <summary>
        /// Creates a new instance with the specified name and version.
        /// </summary>
        public DiagnosticsComponent(string name, object version)
        {
            Name = name;
            Version = version.ToString();
        }

        /// <summary>
        /// Creates a new instance by examining the specified <see cref="AssemblyName"/>.
        /// </summary>
        public DiagnosticsComponent(AssemblyName assemblyName)
        {
            Name = assemblyName.Name;
            Version = assemblyName.Version.ToString();
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