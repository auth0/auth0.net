using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Auth0.Core;
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
        ///     Query in Lucene query string syntax. Only fields in app_metadata, user_metadata or the normalized user
        ///     profile are searchable.
        /// </param>
        /// <param name="searchEngine">Use 'v2' if you want to try the new search engine, or 'v1' for the old search engine.</param>
        /// <returns></returns>
        Task<IPagedList<User>> GetAllAsync(int? page = null, int? perPage = null, bool? includeTotals = null, string sort = null, string connection = null, string fields = null,
            bool? includeFields = null, string q = null, string searchEngine = null);

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

        #region Obsolete Methods
        #pragma warning disable 1591

        [Obsolete("Use CreateAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task<User> Create(UserCreateRequest request);

        [Obsolete("Use DeleteAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task Delete(string id);

        [Obsolete("Use DeleteAllAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task DeleteAll();

        [Obsolete("Use GetAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task<User> Get(string id, string fields = null, bool includeFields = true);

        [Obsolete("Use GetAllAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task<IPagedList<User>> GetAll(int? page = null, int? perPage = null, bool? includeTotals = null,
            string sort = null, string connection = null, string fields = null,
            bool? includeFields = null, string q = null, string searchEngine = null);

        [Obsolete("Use LinkAccountAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task<IList<AccountLinkResponse>> LinkAccount(string id, UserAccountLinkRequest request);

        [Obsolete("Use LinkAccountAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task<IList<AccountLinkResponse>> LinkAccount(string id, string primaryJwtToken, string secondaryJwtToken);

        [Obsolete("Use UnlinkAccountAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task<IList<AccountLinkResponse>> UnlinkAccount(string primaryUserId, string provider, string secondaryUserId);

        [Obsolete("Use UpdateAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task<User> Update(string id, UserUpdateRequest request);

        #pragma warning restore 1591
        #endregion
    }
}