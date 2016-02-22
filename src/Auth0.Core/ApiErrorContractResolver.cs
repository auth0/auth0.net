using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace Auth0.Core
{
    /// <summary>
    /// A contract resolver to unify different error messages to a single class.
    /// </summary>
    public class ApiErrorContractResolver : DefaultContractResolver
    {
        private Dictionary<string, string> PropertyMappings { get; set; }

        public ApiErrorContractResolver()
        {
            PropertyMappings = new Dictionary<string, string>
            {
                {"errorCode", "code"},
                {"error", "name"},
                {"message", "description"}
            };
        }

        /// <summary>
        /// Resolve a mapped attribute to an expected attribute.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected override string ResolvePropertyName(string propertyName)
        {
            string resolvedName = null;
            var resolved = this.PropertyMappings.TryGetValue(propertyName, out resolvedName);
            return (resolved) ? resolvedName : base.ResolvePropertyName(propertyName);
        }
    }

}
