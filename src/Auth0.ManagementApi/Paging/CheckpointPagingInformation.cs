using Newtonsoft.Json;

namespace Auth0.ManagementApi.Paging
{
    /// <summary>
    /// Contains paging information that details what page a list of items
    /// relates to, how many more there are etc.
    /// </summary>
    public class CheckpointPagingInformation
    {
        /// <summary>
        /// When using checkpoint pagination, the Id to use for supplemental paged requests.
        /// </summary>
        [JsonProperty("next")]
        public string Next { get; set; } = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckpointPagingInformation"/> class
        /// with the desired arguments.
        /// </summary>
        /// <param name="next">When using checkpoint pagination, the Id one should use for supplemental requests to receive more results.</param>
        public CheckpointPagingInformation(string next = null)
        {
            Next = next;
        }
    }
}
