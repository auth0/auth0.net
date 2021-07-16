namespace Auth0.ManagementApi.Paging
{
    /// <summary>
    /// Specifies pagination info to use when requesting paged results.
    /// </summary>
    public class PaginationInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaginationInfo"/> class.
        /// </summary>
        /// <param name="pageNo">Page index of the results to return. First page is 0.</param>
        /// <param name="perPage">Number of results per page.</param>
        /// <param name="includeTotals">Whether to return the complete total result count (true) or not (false).</param>
        /// <param name="from">When using checkpoint pagination, an Id from which to begin the next page of results.</param>
        /// <param name="take">When using checkpoint pagination, the number of results per page.</param>
        public PaginationInfo(int? pageNo = 0, int? perPage = 50, bool? includeTotals = false, string from = null, int? take = null)
        {
            IncludeTotals = includeTotals;
            PerPage = perPage;
            PageNo = pageNo;
            From = from;
            Take = take;
        }

        /// <summary>
        /// Return results with a total result count (true) or with no totals (false, default).
        /// </summary>
        public bool? IncludeTotals { get; } = null;

        /// <summary>
        /// Number of results per page.
        /// </summary>
        public int? PerPage { get; } = null;

        /// <summary>
        /// Page index of the results to return. First page is 0.
        /// </summary>
        public int? PageNo { get; } = null;

        /// <summary>
        /// When using checkpoint pagination, an Id from which to begin the next page of results.
        /// </summary>
        public string From { get; } = null;

        /// <summary>
        /// When using checkpoint pagination, the number of results per page. Required to use checkpoint pagination.
        /// </summary>
        public int? Take { get; } = null;
    }
}
