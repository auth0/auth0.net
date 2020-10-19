using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Contains details for creating a users exports job.
    /// </summary>
    public class UsersExportsJobRequest
    {
        /// <summary>
        /// The connection identifier.
        /// </summary>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        /// <summary>
        /// Format of the exported file.
        /// </summary>
        [JsonProperty("format")]
        [JsonConverter(typeof(StringEnumConverter))]
        public UsersExportsJobFormat Format { get; set; }

        /// <summary>
        /// Limit the number of records.
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; set; }

        /// <summary>
        /// List of fields to be included in the export. Defaults to a predefined set of fields.
        /// </summary>
        [JsonProperty("fields")]
        public IList<UsersExportsJobField> Fields { get; set; }

    }
}
