using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Models.RefreshTokens;
using Auth0.ManagementApi.Models.Sessions;
using Auth0.ManagementApi.Models.Users;
using Auth0.ManagementApi.Paging;

namespace Auth0.ManagementApi.Clients;

/// <summary>
/// Contains methods to access the /users endpoints.
/// </summary>
public class UsersClient : BaseClient, IUsersClient
{
    private readonly JsonConverter[] usersConverters = [new PagedListConverter<User>("users")];
    private readonly JsonConverter[] logsConverters = [new PagedListConverter<LogEntry>("logs", true)];
    private readonly JsonConverter[] rolesConverters = [new PagedListConverter<Role>("roles")];
    private readonly JsonConverter[] permissionsConverters = [new PagedListConverter<UserPermission>("permissions")];
    private readonly JsonConverter[] organizationsConverters = [new PagedListConverter<Organization>("organizations")];

    private readonly JsonConverter[] authenticationMethodConverters = [new PagedListConverter<AuthenticationMethod>("authenticators")
    ];

    private readonly JsonConverter[] refreshTokensConverter = [new CheckpointPagedListConverter<RefreshTokenInformation>("tokens")
    ];

    private readonly JsonConverter[] sessionsConverter = [new CheckpointPagedListConverter<Sessions>("sessions")];

    /// <summary>
    /// Initializes a new instance of <see cref="UsersClient"/>.
    /// </summary>
    /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
    /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
    /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
    public UsersClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
        : base(connection, baseUri, defaultHeaders)
    {
    }

    /// <inheritdoc />
    public Task AssignRolesAsync(string id, AssignRolesRequest request, CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<AssignRolesRequest>(HttpMethod.Post, BuildUri($"users/{EncodePath(id)}/roles"), request, DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<User> CreateAsync(UserCreateRequest request, CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<User>(HttpMethod.Post, BuildUri("users"), request, DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(id));

        return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"users/{EncodePath(id)}"), null, DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task DeleteMultifactorProviderAsync(string id, string provider, CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"users/{EncodePath(id)}/multifactor/{EncodePath(provider)}"), null, DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<IPagedList<User>> GetAllAsync(GetUsersRequest request, PaginationInfo pagination = null, CancellationToken cancellationToken = default)
    {
        request.ThrowIfNull();

        var queryStrings = new Dictionary<string, string>
        {
            {"sort", request.Sort},
            {"connection", request.Connection},
            {"fields", request.Fields},
            {"include_fields", request.IncludeFields?.ToString().ToLower()},
            {"q", request.Query},
            {"search_engine", request.SearchEngine},
        };

        if (pagination != null)
        {
            queryStrings["page"] = pagination.PageNo.ToString();
            queryStrings["per_page"] = pagination.PerPage.ToString();
            queryStrings["include_totals"] = pagination.IncludeTotals.ToString().ToLower();
        }

        return Connection.GetAsync<IPagedList<User>>(BuildUri($"users", queryStrings), DefaultHeaders, usersConverters, cancellationToken);
    }

    /// <inheritdoc />
    public Task<User> GetAsync(string id, string fields = null, bool includeFields = true, CancellationToken cancellationToken = default)
    {
        return Connection.GetAsync<User>(BuildUri($"users/{EncodePath(id)}",
            new Dictionary<string, string>
            {
                {"fields", fields},
                {"include_fields", includeFields.ToString().ToLower()}
            }), DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<IPagedList<LogEntry>> GetLogsAsync(GetUserLogsRequest request, PaginationInfo pagination = null, CancellationToken cancellationToken = default)
    {
        request.ThrowIfNull();

        var queryStrings = new Dictionary<string, string>
        {
            {"sort", request.Sort}
        };

        if (pagination != null)
        {
            queryStrings["page"] = pagination.PageNo.ToString();
            queryStrings["per_page"] = pagination.PerPage.ToString();
            queryStrings["include_totals"] = pagination.IncludeTotals.ToString().ToLower();
        }

        return Connection.GetAsync<IPagedList<LogEntry>>(BuildUri($"users/{EncodePath(request.UserId)}/logs", queryStrings), DefaultHeaders, logsConverters, cancellationToken);
    }

    /// <inheritdoc />
    public Task<IPagedList<Role>> GetRolesAsync(string userId, PaginationInfo pagination = null, CancellationToken cancellationToken = default)
    {
        var queryStrings = new Dictionary<string, string>();

        if (pagination != null)
        {
            queryStrings["page"] = pagination.PageNo.ToString();
            queryStrings["per_page"] = pagination.PerPage.ToString();
            queryStrings["include_totals"] = pagination.IncludeTotals.ToString().ToLower();
        }

        return Connection.GetAsync<IPagedList<Role>>(BuildUri($"users/{EncodePath(userId)}/roles", queryStrings), DefaultHeaders, rolesConverters, cancellationToken);
    }

    /// <inheritdoc />
    public Task<IList<User>> GetUsersByEmailAsync(string email, string fields = null, bool? includeFields = null, CancellationToken cancellationToken = default)
    {
        return Connection.GetAsync<IList<User>>(BuildUri($"users-by-email",
            new Dictionary<string, string>
            {
                {"email", email},
                {"fields", fields},
                {"include_fields", includeFields?.ToString().ToLower()}
            }), DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<IList<EnrollmentsResponse>> GetEnrollmentsAsync(string id, CancellationToken cancellationToken = default)
    {
        return Connection.GetAsync<IList<EnrollmentsResponse>>(BuildUri($"users/{EncodePath(id)}/enrollments"), DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task InvalidateRememberBrowserAsync(string id, CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<object>(HttpMethod.Post, BuildUri($"users/{EncodePath(id)}/multifactor/actions/invalidate-remember-browser"), null, DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<GenerateRecoveryCodeResponse> GenerateRecoveryCodeAsync(string id, CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<GenerateRecoveryCodeResponse>(HttpMethod.Post, BuildUri($"users/{EncodePath(id)}/recovery-code-regeneration"), null, DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<IList<AccountLinkResponse>> LinkAccountAsync(string id, UserAccountLinkRequest request, CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<IList<AccountLinkResponse>>(HttpMethod.Post, BuildUri($"users/{EncodePath(id)}/identities"), request, DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<IList<AccountLinkResponse>> LinkAccountAsync(string id, string primaryJwtToken, string secondaryJwtToken, CancellationToken cancellationToken = default)
    {
        var request = new UserAccountJwtLinkRequest
        {
            LinkWith = secondaryJwtToken
        };

        return Connection.SendAsync<IList<AccountLinkResponse>>(HttpMethod.Post,
            BuildUri($"users/{EncodePath(id)}/identities"), request,
            new Dictionary<string, string>(DefaultHeaders)
            {
                ["Authorization"] = $"Bearer {primaryJwtToken}"
            }, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task RemoveRolesAsync(string id, AssignRolesRequest request, CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"users/{EncodePath(id)}/roles"), request, DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<IList<AccountLinkResponse>> UnlinkAccountAsync(string primaryUserId, string provider, string secondaryUserId, CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<IList<AccountLinkResponse>>(HttpMethod.Delete,
            BuildUri($"users/{EncodePath(primaryUserId)}/identities/{EncodePath(provider)}/{EncodePath(secondaryUserId)}"), null, DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<User> UpdateAsync(string id, UserUpdateRequest request, CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<User>(new HttpMethod("PATCH"), BuildUri($"users/{EncodePath(id)}"), request, DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<IPagedList<UserPermission>> GetPermissionsAsync(string id, PaginationInfo pagination = null, CancellationToken cancellationToken = default)
    {
        var queryStrings = new Dictionary<string, string>();

        if (pagination != null)
        {
            queryStrings["page"] = pagination.PageNo.ToString();
            queryStrings["per_page"] = pagination.PerPage.ToString();
            queryStrings["include_totals"] = pagination.IncludeTotals.ToString().ToLower();
        }

        return Connection.GetAsync<IPagedList<UserPermission>>(BuildUri($"users/{EncodePath(id)}/permissions", queryStrings), DefaultHeaders, permissionsConverters, cancellationToken);
    }

    /// <inheritdoc />
    public Task AssignPermissionsAsync(string id, AssignPermissionsRequest request, CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<object>(HttpMethod.Post, BuildUri($"users/{EncodePath(id)}/permissions"), request, DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task RemovePermissionsAsync(string id, AssignPermissionsRequest request, CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"users/{EncodePath(id)}/permissions"), request, DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<IPagedList<Organization>> GetAllOrganizationsAsync(string userId, PaginationInfo pagination, CancellationToken cancellationToken = default)
    {
        pagination.ThrowIfNull();

        return Connection.GetAsync<IPagedList<Organization>>(BuildUri($"users/{EncodePath(userId)}/organizations",
            new Dictionary<string, string>
            {
                {"page", pagination.PageNo.ToString()},
                {"per_page", pagination.PerPage.ToString()},
                {"include_totals", pagination.IncludeTotals.ToString().ToLower()},
            }), DefaultHeaders, organizationsConverters, cancellationToken);
    }

    /// <inheritdoc />
    public Task<IPagedList<AuthenticationMethod>> GetAuthenticationMethodsAsync(string userId, PaginationInfo pagination = null, CancellationToken cancellationToken = default)
    {
        pagination = pagination ?? new PaginationInfo();

        return Connection.GetAsync<IPagedList<AuthenticationMethod>>(BuildUri($"users/{EncodePath(userId)}/authentication-methods",
            new Dictionary<string, string>
            {
                {"page", pagination.PageNo.ToString()},
                {"per_page", pagination.PerPage.ToString()},
                {"include_totals", pagination.IncludeTotals.ToString().ToLower()},
            }), DefaultHeaders, authenticationMethodConverters, cancellationToken);
    }

    /// <inheritdoc />
    public Task<AuthenticationMethod> GetAuthenticationMethodAsync(string userId, string authenticationMethodId, CancellationToken cancellationToken = default)
    {
        return Connection.GetAsync<AuthenticationMethod>(BuildUri($"users/{EncodePath(userId)}/authentication-methods/{EncodePath(authenticationMethodId)}"), DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<AuthenticationMethod> CreateAuthenticationMethodAsync(string userId, AuthenticationMethodCreateRequest request, CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<AuthenticationMethod>(HttpMethod.Post, BuildUri($"users/{EncodePath(userId)}/authentication-methods"), request, DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<IList<AuthenticationMethod>> UpdateAuthenticationMethodsAsync(string userId, IList<AuthenticationMethodsUpdateRequest> request, CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<IList<AuthenticationMethod>>(HttpMethod.Put, BuildUri($"users/{EncodePath(userId)}/authentication-methods"), request, DefaultHeaders, cancellationToken: cancellationToken);
    }
    
    /// <inheritdoc />
    public Task<AuthenticationMethod> UpdateAuthenticationMethodAsync(string userId, string authenticationMethodId, AuthenticationMethodUpdateRequest request, CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<AuthenticationMethod>(new HttpMethod("PATCH"), BuildUri($"users/{EncodePath(userId)}/authentication-methods/{EncodePath(authenticationMethodId)}"), request, DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task DeleteAuthenticationMethodsAsync(string userId, CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"users/{EncodePath(userId)}/authentication-methods"), null, DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task DeleteAuthenticationMethodAsync(string userId, string authenticationMethodId, CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"users/{EncodePath(userId)}/authentication-methods/{EncodePath(authenticationMethodId)}"), null, DefaultHeaders, cancellationToken: cancellationToken);
    }
        
    /// <inheritdoc cref="IUsersClient.GetRefreshTokensAsync"/>
    public Task<ICheckpointPagedList<RefreshTokenInformation>> GetRefreshTokensAsync(UserRefreshTokensGetRequest request, CheckpointPaginationInfo pagination, CancellationToken cancellationToken = default)
    {
        request.ThrowIfNull();
        request.UserId.ThrowIfNull();
            
        var queryStrings = new Dictionary<string, string>
        {
            {"from", pagination.From},
            {"take", pagination.Take.ToString()},
        };
            
        return Connection.GetAsync<ICheckpointPagedList<RefreshTokenInformation>>(
            BuildUri($"users/{EncodePath(request.UserId)}/refresh-tokens", queryStrings),
            DefaultHeaders, 
            refreshTokensConverter, cancellationToken: cancellationToken);
    }
        
    /// <inheritdoc cref="IUsersClient.DeleteRefreshTokensAsync"/>
    public Task DeleteRefreshTokensAsync(string userId, CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<object>(
            HttpMethod.Delete,
            BuildUri($"users/{EncodePath(userId)}/refresh-tokens"),
            null, 
            DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <inheritdoc cref="IUsersClient.GetUserSessionsAsync"/>
    public Task<ICheckpointPagedList<Sessions>> GetUserSessionsAsync(
        UserSessionsGetRequest request, CheckpointPaginationInfo pagination,
        CancellationToken cancellationToken = default)
    {
        request.ThrowIfNull();
        request.UserId.ThrowIfNull();
            
        var queryStrings = new Dictionary<string, string>
        {
            {"from", pagination.From},
            {"take", pagination.Take.ToString()},
        };
            
        return Connection.GetAsync<ICheckpointPagedList<Sessions>>(
            BuildUri($"users/{EncodePath(request.UserId)}/sessions", queryStrings),
            DefaultHeaders, 
            sessionsConverter, cancellationToken: cancellationToken);
    }
        
    /// <inheritdoc cref="IUsersClient.DeleteSessionsAsync"/>
    public Task DeleteSessionsAsync(string userId, CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<object>(
            HttpMethod.Delete,
            BuildUri($"users/{EncodePath(userId)}/sessions"),
            null, 
            DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <inheritdoc cref="IUsersClient.DeleteAuthenticatorsAsync"/>
    public Task DeleteAuthenticatorsAsync(string userId, CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<object>(
            HttpMethod.Delete,
            BuildUri($"users/{EncodePath(userId)}/authenticators"),
            null, 
            DefaultHeaders, cancellationToken: cancellationToken);
    }
}