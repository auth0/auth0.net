using System;
using Auth0.Core.Collections;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /logs endpoints
    /// </summary>
    public interface ILogsClient
    {
        /// <summary>
        /// Retrieves log entries that match the specified search criteria
        /// </summary>
        /// <remarks>
        /// Will list all entries if no criteria is used. You can search with a criteria using the q parameter or you can search by a specific log ID (search by checkpoint)
        /// </remarks>
        /// <param name="page">The page number. Zero based</param>
        /// <param name="perPage">The amount of entries per page. Default: 50. Max value: 100</param>
        /// <param name="sort">The field to use for sorting. Use field:order where order is 1 for ascending and -1 for descending. For example date:-1</param>
        /// <param name="fields">A comma separated list of fields to include or exclude (depending on include_fields) from the result, empty to retrieve all fields</param>
        /// <param name="includeFields">True if the fields specified are to be included in the result, false otherwise. Defaults to true</param>
        /// <param name="includeTotals">True if a query summary must be included in the result, false otherwise. Default false.</param>
        /// <param name="from">Log Event Id to start retrieving logs. You can limit the amount of logs using the take parameter.</param>
        /// <param name="take">The total amount of entries to retrieve when using the from parameter. Default: 50. Max value: 100</param>
        /// <param name="q">Query in Lucene query string syntax.</param>
        /// <returns></returns>
        [Obsolete("Use GetAllAsync(GetLogsRequest) or GetAllAsync(GetLogsRequest,PaginationInfo) instead")]
        Task<IPagedList<LogEntry>> GetAllAsync(int? page = null, int? perPage = null, string sort = null, string fields = null, bool? includeFields = null, 
            bool? includeTotals = null, string from = null, int? take = null, string q = null);

        /// <summary>
        /// Retrieves log entries that match the specified search criteria
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying logs.</param>
        /// <returns>An <see cref="IPagedList{LogEntry}"/> containing the list of log entries.</returns>
        Task<IPagedList<LogEntry>> GetAllAsync(GetLogsRequest request);

        /// <summary>
        /// Retrieves log entries that match the specified search criteria
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying logs.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <returns>An <see cref="IPagedList{LogEntry}"/> containing the list of log entries.</returns>
        Task<IPagedList<LogEntry>> GetAllAsync(GetLogsRequest request, PaginationInfo pagination);

        /// <summary>
        /// Retrieves the data related to the log entry identified by id. This returns a single log entry representation as specified in the schema.
        /// </summary>
        /// <param name="id">The identifier of the log entry to retrieve</param>
        /// <returns></returns>
        Task<LogEntry> GetAsync(string id);
    }
}