using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Collections;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /users endpoints.
    /// </summary>
    public interface IUsersClient
    {
        /// <summary>
        /// Assigns Roles to a user.
        /// </summary>
        /// <param name="id">The ID of the user to assign roles to.</param>
        /// <param name="request">A <see cref="AssignRolesRequest" /> containing the role IDs to assign to the user.</param>
        /// <returns></returns>
        Task AssignRolesAsync(string id, AssignRolesRequest request);

        /// <summary>
        ///     Creates a new user.
        /// </summary>
        /// <param name="request">The <see cref="UserCreateRequest" /> containing the properties of the user to create.</param>
        /// <returns></returns>
        Task<User> CreateAsync(UserCreateRequest request);

        /// <summary>
        ///     Deletes all users. Use with caution!
        /// </summary>
        /// <returns></returns>
        Task DeleteAllAsync();

        /// <summary>
        ///     Deletes a user.
        /// </summary>
        /// <param name="id">The id of the user to delete.</param>
        Task DeleteAsync(string id);

        /// <summary>
        ///     Deletes a user's multifactor provider.
        /// </summary>
        /// <param name="id">The id of the user who multi factor provider to delete.</param>
        /// <param name="provider">The type of the multifactor provider. Supported values 'duo' or 'google-authenticator'</param>
        /// <returns></returns>
        Task DeleteMultifactorProviderAsync(string id, string provider);

        /// <summary>
        ///     Lists or search for users based on criteria.
        /// </summary>
        /// <param name="page">The page number. Zero based.</param>
        /// <param name="perPage">The amount of entries per page.</param>
        /// <param name="includeTotals">True if a query summary must be included in the result.</param>
        /// <param name="sort">The field to use for sorting. 1 == ascending and -1 == descending</param>
        /// <param name="connection">Connection filter.</param>
        /// <param name="fields">
        ///     A comma separated list of fields to include or exclude (depending on
        ///     <paramref name="includeFields" />) from the result, empty to retrieve all fields.
        /// </param>
        /// <param name="includeFields">
        ///     True if the fields specified are to be included in the result, false otherwise. Defaults to
        ///     true.
        /// </param>
        /// <param name="q">
        ///     Query in Lucene query string syntax.
        /// </param>
        /// <param name="searchEngine">
        /// The version of the search engine to use.
        /// Will default to v2 if no value is passed. Default will change to v3 on 2018/11/13.
        /// For more info <a href="https://auth0.com/docs/users/search/v3#migrate-from-search-engine-v2-to-v3">see the online documentation</a>.
        /// </param>
        /// <returns></returns>
        [Obsolete("Use GetAllAsync(GetUsersRequest) or GetAllAsync(GetUsersRequest, PaginationInfo) instead")]
        Task<IPagedList<User>> GetAllAsync(int? page = null,
            int? perPage = null,
            bool? includeTotals = null,
            string sort = null,
            string connection = null,
            string fields = null,
            bool? includeFields = null,
            string q = null,
            string searchEngine = null);

        /// <summary>
        /// Lists or search for users based on criteria.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying users.</param>
        /// <returns>An <see cref="IPagedList{GetUsersRequest}"/> containing the list of users.</returns>
        Task<IPagedList<User>> GetAllAsync(GetUsersRequest request);

        /// <summary>
        /// Lists or search for users based on criteria.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying users.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <returns>An <see cref="IPagedList{GetUsersRequest}"/> containing the list of users.</returns>
        Task<IPagedList<User>> GetAllAsync(GetUsersRequest request, PaginationInfo pagination);

        /// <summary>
        ///     Gets a user.
        /// </summary>
        /// <param name="id">The id of the user to retrieve.</param>
        /// <param name="fields">
        ///     A comma separated list of fields to include or exclude (depending on includeFields) from the
        ///     result, empty to retrieve all fields
        /// </param>
        /// <param name="includeFields">
        ///     true if the fields specified are to be included in the result, false otherwise (defaults to
        ///     true)
        /// </param>
        /// <returns>The <see cref="User" />.</returns>
        Task<User> GetAsync(string id, string fields = null, bool includeFields = true);

        /// <summary>
        /// Retrieve every log event for a specific user id
        /// </summary>
        /// <param name="userId">The user id of the logs to retrieve</param>
        /// <param name="page">The zero-based page number</param>
        /// <param name="perPage">The amount of entries per page. Default: 50. Max value: 100</param>
        /// <param name="sort">The field to use for sorting. Use field:order where order is 1 for ascending and -1 for descending. For example date:-1</param>
        /// <param name="includeTotals">True if a query summary must be included in the result, false otherwise. Default false.</param>
        /// <returns></returns>
        [Obsolete("Use GetLogsAsync(GetUserLogsRequest) or GetLogsAsync(GetUserLogsRequest, PaginationInfo) instead")]
        Task<IPagedList<LogEntry>> GetLogsAsync(string userId,
            int? page = null,
            int? perPage = null,
            string sort = null,
            bool? includeTotals = null);

        /// <summary>
        /// Retrieve every log event for a specific user.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying logs for a user.</param>
        /// <returns>An <see cref="IPagedList{LogEntry}"/> containing the log entries for the user.</returns>
        Task<IPagedList<LogEntry>> GetLogsAsync(GetUserLogsRequest request);

        /// <summary>
        /// Retrieve every log event for a specific user.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying logs for a user.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <returns>An <see cref="IPagedList{LogEntry}"/> containing the log entries for the user.</returns>
        Task<IPagedList<LogEntry>> GetLogsAsync(GetUserLogsRequest request, PaginationInfo pagination);

        /// <summary>
        /// Retrieve assigned roles for a specific user.
        /// </summary>
        /// <param name="userId">The user id of the roles to retrieve</param>
        /// <returns>An <see cref="IPagedList{Role}"/> containing the roles for the user.</returns>
        Task<IPagedList<Role>> GetRolesAsync(string userId);

        /// <summary>
        /// Retrieve assigned roles for a specific user.
        /// </summary>
        /// <param name="userId">The user id of the roles to retrieve</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <returns>An <see cref="IPagedList{Role}"/> containing the roles for the user.</returns>
        Task<IPagedList<Role>> GetRolesAsync(string userId, PaginationInfo pagination);

        /// <summary>
        /// Gets all users by email address.
        /// </summary>
        /// <param name="email">The email address to search for</param>
        /// <param name="fields"> A comma separated list of fields to include or exclude (depending on <see cref="includeFields"/>) from the result, null to retrieve all fields</param>
        /// <param name="includeFields">true if the fields specified are to be included in the result, false otherwise. Defaults to true</param>
        /// <returns></returns>
        Task<IList<User>> GetUsersByEmailAsync(string email,
            string fields = null,
            bool? includeFields = null);

        /// <summary>
        ///     Links a secondary account to a primary account.
        /// </summary>
        /// <param name="id">The ID of the primary account.</param>
        /// <param name="request">The <see cref="UserAccountLinkRequest" /> containing details of the secondary account to link.</param>
        /// <returns></returns>
        Task<IList<AccountLinkResponse>> LinkAccountAsync(string id, UserAccountLinkRequest request);

        /// <summary>
        ///     Links a secondary account to a primary account.
        /// </summary>
        /// <param name="id">The ID of the primary account.</param>
        /// <param name="primaryJwtToken">The JWT of the primary account.</param>
        /// <param name="secondaryJwtToken">The JWT for the secondary account you wish to link.</param>
        /// <returns></returns>
        Task<IList<AccountLinkResponse>> LinkAccountAsync(string id, string primaryJwtToken, string secondaryJwtToken);

        /// <summary>
        /// Removes Roles from a user.
        /// </summary>
        /// <param name="id">The ID of the user to remove roles from.</param>
        /// <param name="request">A <see cref="AssignRolesRequest" /> containing the role IDs to remove to the user.</param>
        /// <returns></returns>
        Task RemoveRolesAsync(string id, AssignRolesRequest request);

        /// <summary>
        ///     Unlinks user accounts
        /// </summary>
        /// <param name="primaryUserId">The ID of the primary account.</param>
        /// <param name="provider">The type of the identity provider.</param>
        /// <param name="secondaryUserId">The ID for the secondary account</param>
        /// <returns></returns>
        Task<IList<AccountLinkResponse>> UnlinkAccountAsync(string primaryUserId, string provider, string secondaryUserId);

        /// <summary>
        ///     Updates a user.
        /// </summary>
        /// <param name="id">The id of the user to update.</param>
        /// <param name="request">The <see cref="UserUpdateRequest" /> containing the information you wish to update.</param>
        /// <returns></returns>
        Task<User> UpdateAsync(string id, UserUpdateRequest request);
    }
}
