using Newtonsoft.Json;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// A request for creating log streams
    /// </summary>
    public class LogStreamCreateRequest : LogStreamBase
    {
        /// <summary>
        /// Information about log stream filters
        /// </summary>
        [JsonProperty("filters")]
        public new IList<LogStreamFilterRequest> Filters { get; set; }
    }
}
