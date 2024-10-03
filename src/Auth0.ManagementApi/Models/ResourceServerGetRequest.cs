using System.Collections.Generic;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Request structure for creating a new resource server
    /// </summary>
    public class ResourceServerGetRequest
    {
        /// <summary>
        /// List of Identifier IDs to retrieve
        /// </summary>
        public IList<string> Identifiers { get; set; }
    }
}