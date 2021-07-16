using Newtonsoft.Json;

namespace Auth0.ManagementApi.Paging
{
    /// <summary>
    /// Contains paging information that details what page a list of items
    /// relates to, how many more there are etc.
    /// </summary>
    public class PagingInformation
    {
        /// <summary>
        /// Number of items actually returned.
        /// </summary>
        /// <remarks>
        /// This is either the `per_page` you requested if there
        /// are more results or a number smaller than that if this
        /// is the last page of results and there are no more to
        /// page through.
        /// </remarks>
        [JsonProperty("length")]
        public int? Length { get; set; } = null;

        /// <summary>
        /// Maximum number of items requested.
        /// </summary>
        /// <remarks>
        /// This is the `per_page` you requested.
        /// </remarks>
        [JsonProperty("limit")]
        public int? Limit { get; set; } = null;

        /// <summary>
        /// Start index into the number of items.
        /// </summary>
        /// <remarks>
        /// This is the `page` you requested multiplied by the `per_page`.
        /// </remarks>
        [JsonProperty("start")]
        public int? Start { get; set; } = null;

        /// <summary>
        /// Total number of items available on the server.
        /// </summary>
        [JsonProperty("total")]
        public int? Total { get; set; } = null;

        /// <summary>
        /// When using checkpoint pagination, the Id to use for supplemental paged requests.
        /// </summary>
        [JsonProperty("next")]
        public string Next { get; set; } = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="PagingInformation"/> class
        /// with the desired arguments.
        /// </summary>
        /// <param name="start">Start index into the number of items.</param>
        /// <param name="limit">Maximum number of items requested.</param>
        /// <param name="length">Number of items actually returned.</param>
        /// <param name="total">Total number of items available on the server.</param>
        /// <param name="next">When using checkpoint pagination, the Id one should use for supplemental requests to receive more results.</param>
        public PagingInformation(int? start = null, int? limit = null, int? length = null, int? total = null, string next = null)
        {
            Start = start;
            Limit = limit;
            Length = length;
            Total = total;
            Next = next;
        }
    }
}
