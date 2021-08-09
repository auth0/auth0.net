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
        public PaginationInfo(int pageNo = 0, int perPage = 50, bool includeTotals = false)
        {
            IncludeTotals = includeTotals;
            PerPage = perPage;
            PageNo = pageNo;
        }

        /// <summary>
        /// Return results with a total result count (true) or with no totals (false, default).
        /// </summary>
        public bool IncludeTotals { get; }

        /// <summary>
        /// Number of results per page.
        /// </summary>
        public int PerPage { get; }

        /// <summary>
        /// Page index of the results to return. First page is 0.
        /// </summary>
        public int PageNo { get; }
    }
}