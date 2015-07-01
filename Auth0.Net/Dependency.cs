using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Auth0
{
    /// <summary>
    /// Represents a software dependency or environment feature.
    /// </summary>
    public class Dependency
    {
        /// <summary>
        /// Gets the name of the dependency.
        /// </summary>
        public string name { get; private set; }

        /// <summary>
        /// Gets the version of the dependency.
        /// </summary>
        public string version { get; private set; }

        /// <summary>
        /// Creates a new instance of a dependency with the specified name and version.
        /// </summary>
        public Dependency(string name, object version)
        {
            this.name = name;
            this.version = version.ToString();
        }

        /// <summary>
        /// Creates a new instance of a dependency by examining the specified <see cref="AssemblyName"/>.
        /// </summary>
        public Dependency(AssemblyName assemblyName)
        {
            this.name = assemblyName.Name;
            this.version = assemblyName.Version.ToString();
        }
    }
}
