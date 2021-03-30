using Newtonsoft.Json;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Represents information about a failed job.
    /// </summary>
    public class JobError
    {
        /// <summary>
        /// User, as provided in the import file.
        /// </summary>
        [JsonProperty("user")]
        public object User { get; set; }

        /// <summary>
        /// User, as provided in the import file.
        /// </summary>
        [JsonProperty("errors")]
        public IList<object> Errors { get; set; }

    }
}