using System;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Specifies pagination info to use when requesting paged results.
    /// </summary>
    public class PaginationInfo
    {
        public PaginationInfo()
        {
            PageNo = 0;
            PerPage = 50;
            IncludeTotals = false;
        }

        public PaginationInfo(int pageNo, int perPage, bool includeTotals)
        {
            IncludeTotals = includeTotals;
            PerPage = perPage;
            PageNo = pageNo;
        }

        /// <summary>
        /// True if a query summary must be included in the result, False otherwise.
        /// </summary>
        public bool IncludeTotals { get; }
        
        /// <summary>
        /// The amount of entries per page. 
        /// </summary>
        public int PerPage { get; }

        /// <summary>
        /// The page number to request. Zero based. 
        /// </summary>
        public int PageNo { get; }
    }
}