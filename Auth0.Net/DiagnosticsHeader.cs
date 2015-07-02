using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Auth0
{
    /// <summary>
    /// Represents important information pertaining to the SDK that is sent to Auth0 for diagnostic purposes.
    /// </summary>
    public class DiagnosticsHeader
        : DiagnosticsComponent
    {
        private static object syncRoot = new Object();

        // object creation is done via one of the static fields
        private DiagnosticsHeader() { }
        private DiagnosticsHeader(AssemblyName sdkAssemblyName)
            : base(sdkAssemblyName)
        {
        }

        private static volatile DiagnosticsHeader _default;
        /// <summary>
        /// Gets the <see cref="DiagnosticsHeader"/> instance that contains the default set of SDK information.
        /// </summary>
        public static DiagnosticsHeader Default
        {
            get
            {
                if (_default == null)
                {
                    lock (syncRoot)
                    {
                        if (_default == null)
                        {
                            _default = CreateDefault();
                        }
                    }
                }
                return _default;
            }
        }

        private static volatile DiagnosticsHeader _suppress;
        /// <summary>
        /// Gets the <see cref="DiagnosticsHeader"/> instance that tells the SDK to not send the diagnostic header.
        /// </summary>
        public static DiagnosticsHeader Suppress
        {
            get
            {
                if (_suppress == null)
                {
                    lock (syncRoot)
                    {
                        if (_suppress == null)
                        {
                            _suppress = new DiagnosticsHeader();
                        }
                    }
                }
                return _suppress;
            }
        }

        private static DiagnosticsHeader CreateDefault()
        {
            var sdkAssembly = Assembly.GetExecutingAssembly();
            var sdkAssemblyName = sdkAssembly.GetName();

            var header = new DiagnosticsHeader(sdkAssemblyName);

            header.Dependencies = sdkAssembly.GetReferencedAssemblies()
                    .Where(a => a.Name != "mscorlib" && a.Name != "System" && !a.Name.StartsWith("System."))
                    .Select(a => new DiagnosticsComponent(a));

            header.Environments = new[] 
                {
                    new DiagnosticsComponent(".NET CLR", System.Environment.Version),
                    new DiagnosticsComponent("OS", System.Environment.OSVersion)
                };

            return header;
        }

        /// <summary>
        /// Gets the set of components that represent the SDK's 3rd party dependencies.
        /// </summary>
        [JsonProperty("dependencies")]
        public IEnumerable<DiagnosticsComponent> Dependencies { get; internal set; }

        /// <summary>
        /// Gets a set of components that represent the SDK's execution environment.
        /// </summary>
        [JsonProperty("environment")]
        public IEnumerable<DiagnosticsComponent> Environments { get; internal set; }

        /// <summary>
        /// Adds a new dependency instance to the SDK's <see cref="Dependencies"/>.
        /// </summary>
        public DiagnosticsHeader AddDependency(DiagnosticsComponent dependency)
        {
            Dependencies = Dependencies.Concat(new[] { dependency });

            return this;
        }

        /// <summary>
        /// Adds a new dependency to the SDK's <see cref="Dependencies"/>.
        /// </summary>
        public DiagnosticsHeader AddDependency(string name, object version)
        {
            return this.AddDependency(new DiagnosticsComponent(name, version));
        }

        /// <summary>
        /// Adds a new environment entry instance to the SDK's <see cref="Environment"/>.
        /// </summary>
        public DiagnosticsHeader AddEnvironment(DiagnosticsComponent environment)
        {
            Environments = Environments.Concat(new[] { environment });

            return this;
        }

        /// <summary>
        /// Adds a new environment to the SDK's <see cref="Environment"/>.
        /// </summary>
        public DiagnosticsHeader AddEnvironment(string name, object version)
        {
            return this.AddEnvironment(new DiagnosticsComponent(name, version));
        }

        /// <summary>
        /// Returns a string representation of the <see cref="DiagnosticsHeader"/> that is safe for HTTP transport.
        /// </summary>
        public override string ToString()
        {
            var json = JsonConvert.SerializeObject(this);
            var base64 = Utils.Base64UrlEncode(Encoding.UTF8.GetBytes(json));

            return base64;
        }

        /// <summary>
        /// Resets the <see cref="Default"/> and <see cref="Suppress"/> instances.
        /// </summary>
        public static void Reset()
        {
            _default = null;
            _suppress = null;
        }
    }
}
