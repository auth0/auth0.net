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
        public int Length { get; set; }

        /// <summary>
        /// Maximum number of items requested.
        /// </summary>
        /// <remarks>
        /// This is the `per_page` you requested.
        /// </remarks>
        [JsonProperty("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// Start index into the number of items.
        /// </summary>
        /// <remarks>
        /// This is the `page` you requested multiplied by the `per_page`.
        /// </remarks>
        [JsonProperty("start")]
        public int Start { get; set; }

        /// <summary>
        /// Total number of items available on the server.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagingInformation"/> class
        /// with the desired arguments.
        /// </summary>
        /// <param name="start">Start index into the number of items.</param>
        /// <param name="limit">Maximum number of items requested.</param>
        /// <param name="length">Number of items actually returned.</param>
        /// <param name="total">Total number of items available on the server.</param>
        public PagingInformation(int start, int limit, int length, int total)
        {
            Start = start;
            Limit = limit;
            Length = length;
            Total = total;
        }
    }
}