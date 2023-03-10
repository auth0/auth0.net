namespace Auth0.ManagementApi.Clients
{
  using System.Collections.Generic;
  using System.Threading;
  using System.Threading.Tasks;
  using Auth0.ManagementApi.Models.Users;
  using Models;
  using Paging;

  public interface IUsersClient
  {
    /// <summary>
    /// Assigns Roles to a user.
    /// </summary>
    /// <param name="id">The ID of the user to assign roles to.</param>
    /// <param name="request">A <see cref="AssignRolesRequest" /> containing the role IDs to assign to the user.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous assign operation.</returns>
    Task AssignRolesAsync(string id, AssignRolesRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="request">The <see cref="UserCreateRequest" /> containing the properties of the user to create.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The newly created <see cref="User"/>.</returns>
    Task<User> CreateAsync(UserCreateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a user.
    /// </summary>
    /// <param name="id">The id of the user to delete.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
    Task DeleteAsync(string id);

    /// <summary>
    /// Deletes a user's multifactor provider.
    /// </summary>
    /// <param name="id">The id of the user who multi factor provider to delete.</param>
    /// <param name="provider">The type of the multifactor provider. Supported values 'duo' or 'google-authenticator'.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
    Task DeleteMultifactorProviderAsync(string id, string provider, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists or search for users based on criteria.
    /// </summary>
    /// <param name="request">Specifies criteria to use when querying users.</param>
    /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="IPagedList{GetUsersRequest}"/> containing the list of users.</returns>
    Task<IPagedList<User>> GetAllAsync(GetUsersRequest request, PaginationInfo pagination = null, CancellationToken cancellationToken = default);

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
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="User"/> that was requested.</returns>
    Task<User> GetAsync(string id, string fields = null, bool includeFields = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve every log event for a specific user.
    /// </summary>
    /// <param name="request">Specifies criteria to use when querying logs for a user.</param>
    /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="IPagedList{LogEntry}"/> containing the log entries for the user.</returns>
    Task<IPagedList<LogEntry>> GetLogsAsync(GetUserLogsRequest request, PaginationInfo pagination = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve assigned roles for a specific user.
    /// </summary>
    /// <param name="userId">The user id of the roles to retrieve.</param>
    /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="IPagedList{Role}"/> containing the roles for the user.</returns>
    Task<IPagedList<Role>> GetRolesAsync(string userId, PaginationInfo pagination = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets all users by email address.
    /// </summary>
    /// <param name="email">The email address to search for.</param>
    /// <param name="fields"> A comma separated list of fields to include or exclude (depending on <paramref name="includeFields"/>) from the result, null to retrieve all fields.</param>
    /// <param name="includeFields">true if the fields specified are to be included in the result, false otherwise. Defaults to true.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="IList{User}"/> containing all users for this email address.</returns>
    Task<IList<User>> GetUsersByEmailAsync(string email, string fields = null, bool? includeFields = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a list of Guardian enrollments.
    /// </summary>
    /// <param name="id">The user_id of the user to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A Task representing the operation and potential return value.</returns>
    Task<IList<EnrollmentsResponse>> GetEnrollmentsAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Invalidate all remembered browsers for MFA.
    /// </summary>
    /// <param name="id">The user_id of the user which will have its remembered browsers for MFA invalidated.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A Task representing the operation and potential return value.</returns>
    Task InvalidateRememberBrowserAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Generate new Guardian recovery code.
    /// </summary>
    /// <param name="id">The user_id of the user which guardian code will be regenerated.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A Task representing the operation and potential return value.</returns>
    Task<GenerateRecoveryCodeResponse> GenerateRecoveryCodeAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Links a secondary account to a primary account.
    /// </summary>
    /// <param name="id">The ID of the primary account.</param>
    /// <param name="request">The <see cref="UserAccountLinkRequest" /> containing details of the secondary account to link.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="IList{AccountLinkResponse}"/> containing details about this account link.</returns>
    Task<IList<AccountLinkResponse>> LinkAccountAsync(string id, UserAccountLinkRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Links a secondary account to a primary account.
    /// </summary>
    /// <param name="id">The ID of the primary account.</param>
    /// <param name="primaryJwtToken">The JWT of the primary account.</param>
    /// <param name="secondaryJwtToken">The JWT for the secondary account you wish to link.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="IList{AccountLinkResponse}"/> containing details about this account link.</returns>
    Task<IList<AccountLinkResponse>> LinkAccountAsync(string id, string primaryJwtToken, string secondaryJwtToken, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes Roles from a user.
    /// </summary>
    /// <param name="id">The ID of the user to remove roles from.</param>
    /// <param name="request">A <see cref="AssignRolesRequest" /> containing the role IDs to remove to the user.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous remove operation.</returns>
    Task RemoveRolesAsync(string id, AssignRolesRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Unlinks user accounts
    /// </summary>
    /// <param name="primaryUserId">The ID of the primary account.</param>
    /// <param name="provider">The type of the identity provider.</param>
    /// <param name="secondaryUserId">The ID for the secondary account.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="IList{AccountLinkResponse}"/> containing details about this account link.</returns>
    Task<IList<AccountLinkResponse>> UnlinkAccountAsync(string primaryUserId, string provider, string secondaryUserId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a user.
    /// </summary>
    /// <param name="id">The id of the user to update.</param>
    /// <param name="request">The <see cref="UserUpdateRequest" /> containing the information you wish to update.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The newly updated <see cref="User"/>.</returns>
    Task<User> UpdateAsync(string id, UserUpdateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the permissions assigned to the user.
    /// </summary>
    /// <param name="id">The id of the user to obtain the permissions for.</param>
    /// <param name="pagination">Specifies <see cref="PaginationInfo"/> to use in requesting paged results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="IPagedList{Permission}"/> containing the assigned permissions for this user.</returns>
    Task<IPagedList<UserPermission>> GetPermissionsAsync(string id, PaginationInfo pagination = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Assign permissions to a user.
    /// </summary>
    /// <param name="id">The ID of the user to assign permissions to.</param>
    /// <param name="request">A <see cref="AssignPermissionsRequest" /> containing the permission identifiers to assign to the user.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous assignment operation.</returns>
    Task AssignPermissionsAsync(string id, AssignPermissionsRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes permissions assigned to a user.
    /// </summary>
    /// <param name="id">The ID of the user to remove permissions from.</param>
    /// <param name="request">A <see cref="AssignPermissionsRequest" /> containing the permission identifiers to remove from the user.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous remove operation.</returns>
    Task RemovePermissionsAsync(string id, AssignPermissionsRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists organizations for a user.
    /// </summary>
    /// <param name="userId">The ID of the user for which you want to retrieve the organizations.</param>
    /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="IPagedList{Organization}"/> containing the list of organizations.</returns>
    Task<IPagedList<Organization>> GetAllOrganizationsAsync(string userId, PaginationInfo pagination, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a list of authentication methods.
    /// </summary>
    /// <param name="userId">The ID of the user for which you want to retrieve the authentication methods.</param>
    /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="IPagedList{AuthenticationMethod}"/> containing the list of authentication methods.</returns>
    Task<IPagedList<AuthenticationMethod>> GetAuthenticationMethodsAsync(string userId, PaginationInfo pagination = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets an authentication method for a given user.
    /// </summary>
    /// <param name="userId">The ID of the user for which you want to retrieve the authentication method.</param>
    /// <param name="authenticationMethodId">The ID of the authentication method you want to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="AuthenticationMethod"/> that was requested.</returns>
    Task<AuthenticationMethod> GetAuthenticationMethodAsync(string userId, string authenticationMethodId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates an authentication method for a given user.
    /// </summary>
    /// <remarks>
    /// Authentication methods created via this endpoint will be auto confirmed and should already have verification completed.
    /// </remarks>
    /// <param name="userId">The ID of the user for which you want to create the authentication method.</param>
    /// <param name="request">The <see cref="AuthenticationMethodCreateRequest" /> containing the properties of the authentication method to create.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The newly created <see cref="AuthenticationMethod"/>.</returns>
    Task<AuthenticationMethod> CreateAuthenticationMethodAsync(string userId, AuthenticationMethodCreateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates all authentication methods by replacing them with the given ones.
    /// </summary>
    /// <param name="userId">The ID of the user for which you want to update the authentication methods.</param>
    /// <param name="request">The <see cref="AuthenticationMethodsUpdateRequest" /> containing the properties of the authentication methods to update.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The updated list of <see cref="AuthenticationMethod"/>.</returns>
    Task<IList<AuthenticationMethod>> UpdateAuthenticationMethodsAsync(string userId, IList<AuthenticationMethodsUpdateRequest> request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update an authentication methods.
    /// </summary>
    /// <param name="userId">The ID of the user for which you want to update the authentication methods</param>
    /// <param name="authenticationMethodId">The ID of the authentication method you want to update.</param>
    /// <param name="request">The <see cref="AuthenticationMethodUpdateRequest" /> containing the properties of the authentication methods to update.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The updated <see cref="AuthenticationMethod"/>.</returns>
    Task<AuthenticationMethod> UpdateAuthenticationMethodAsync(string userId, string authenticationMethodId, AuthenticationMethodUpdateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes all authentication methods for the given user.
    /// </summary>
    /// <param name="userId">The ID of the user for which you want to update the authentication methods.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
    Task DeleteAuthenticationMethodsAsync(string userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an authentication method by id,.
    /// </summary>
    /// <param name="userId">The ID of the user for which you want to delete the authentication methods.</param>
    /// <param name="authenticationMethodId">The ID of the authentication method you want to delete.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
    Task DeleteAuthenticationMethodAsync(string userId, string authenticationMethodId, CancellationToken cancellationToken = default);
  }
}
