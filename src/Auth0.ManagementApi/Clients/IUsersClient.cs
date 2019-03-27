using Auth0.Core.Collections;
using Auth0.ManagementApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        /// Creates a new user.
        /// </summary>
        /// <param name="request">The <see cref="UserCreateRequest" /> containing the properties of the user to create.</param>
        /// <returns></returns>
        Task<User> CreateAsync(UserCreateRequest request);

        /// <summary>
        /// Deletes a user.
        /// </summary>
        /// <param name="id">The id of the user to delete.</param>
        Task DeleteAsync(string id);

        /// <summary>
        /// Deletes a user's multifactor provider.
        /// </summary>
        /// <param name="id">The id of the user who multi factor provider to delete.</param>
        /// <param name="provider">The type of the multifactor provider. Supported values 'duo' or 'google-authenticator'</param>
        /// <returns></returns>
        Task DeleteMultifactorProviderAsync(string id, string provider);

        /// Lists or search for users based on criteria.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying users.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <returns>An <see cref="IPagedList{GetUsersRequest}"/> containing the list of users.</returns>
        Task<IPagedList<User>> GetAllAsync(GetUsersRequest request, PaginationInfo pagination);

        /// <summary>
        /// Gets a user.
        /// </summary>
        /// <param name="id">The id of the user to retrieve.</param>
        /// <param name="fields">
        /// A comma separated list of fields to include or exclude (depending on includeFields) from the
        /// result, empty to retrieve all fields
        /// </param>
        /// <param name="includeFields">
        /// true if the fields specified are to be included in the result, false otherwise (defaults to
        /// true)
        /// </param>
        /// <returns>The <see cref="User" />.</returns>
        Task<User> GetAsync(string id, string fields = null, bool includeFields = true);

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
        Task<IList<User>> GetUsersByEmailAsync(string email, string fields = null, bool? includeFields = null);

        /// <summary>
        /// Links a secondary account to a primary account.
        /// </summary>
        /// <param name="id">The ID of the primary account.</param>
        /// <param name="request">The <see cref="UserAccountLinkRequest" /> containing details of the secondary account to link.</param>
        /// <returns></returns>
        Task<IList<AccountLinkResponse>> LinkAccountAsync(string id, UserAccountLinkRequest request);

        /// <summary>
        /// Links a secondary account to a primary account.
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
        /// Unlinks user accounts
        /// </summary>
        /// <param name="primaryUserId">The ID of the primary account.</param>
        /// <param name="provider">The type of the identity provider.</param>
        /// <param name="secondaryUserId">The ID for the secondary account</param>
        /// <returns></returns>
        Task<IList<AccountLinkResponse>> UnlinkAccountAsync(string primaryUserId, string provider, string secondaryUserId);

        /// <summary>
        /// Updates a user.
        /// </summary>
        /// <param name="id">The id of the user to update.</param>
        /// <param name="request">The <see cref="UserUpdateRequest" /> containing the information you wish to update.</param>
        /// <returns></returns>
        Task<User> UpdateAsync(string id, UserUpdateRequest request);
    }
}
