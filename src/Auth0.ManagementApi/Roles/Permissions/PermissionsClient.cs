using System.Text.Json;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Roles;

public partial class PermissionsClient : IPermissionsClient
{
    private RawClient _client;

    internal PermissionsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Retrieve detailed list (name, description, resource server) of permissions granted by a specified user role.
    /// </summary>
    private WithRawResponseTask<ListRolePermissionsOffsetPaginatedResponseContent> ListInternalAsync(
        string id,
        ListRolePermissionsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ListRolePermissionsOffsetPaginatedResponseContent>(
            ListInternalAsyncCore(id, request, options, cancellationToken)
        );
    }

    private async Task<
        WithRawResponse<ListRolePermissionsOffsetPaginatedResponseContent>
    > ListInternalAsyncCore(
        string id,
        ListRolePermissionsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Auth0.ManagementApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("per_page", request.PerPage.IsDefined ? request.PerPage.Value : null)
            .Add("page", request.Page.IsDefined ? request.Page.Value : null)
            .Add(
                "include_totals",
                request.IncludeTotals.IsDefined ? request.IncludeTotals.Value : null
            )
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Auth0.ManagementApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "roles/{0}/permissions",
                        ValueConvert.ToPathParameterString(id)
                    ),
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData =
                    JsonUtils.Deserialize<ListRolePermissionsOffsetPaginatedResponseContent>(
                        responseBody
                    )!;
                return new WithRawResponse<ListRolePermissionsOffsetPaginatedResponseContent>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ManagementApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ManagementApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Retrieve detailed list (name, description, resource server) of permissions granted by a specified user role.
    /// </summary>
    /// <example><code>
    /// await client.Roles.Permissions.ListAsync(
    ///     "id",
    ///     new ListRolePermissionsRequestParameters
    ///     {
    ///         PerPage = 1,
    ///         Page = 1,
    ///         IncludeTotals = true,
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<PermissionsResponsePayload>> ListAsync(
        string id,
        ListRolePermissionsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        request = request with { };
        var pager = await OffsetPager<
            ListRolePermissionsRequestParameters,
            RequestOptions?,
            ListRolePermissionsOffsetPaginatedResponseContent,
            int?,
            int?,
            PermissionsResponsePayload
        >
            .CreateInstanceAsync(
                request,
                options,
                async (request, options, cancellationToken) =>
                    await ListInternalAsync(id, request, options, cancellationToken)
                        .ConfigureAwait(false),
                request => request.Page.GetValueOrDefault(0),
                (request, offset) =>
                {
                    request.Page = offset;
                },
                request => request.PerPage.GetValueOrDefault(0),
                response => response.Permissions?.ToList(),
                null,
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Add one or more <see href="https://auth0.com/docs/manage-users/access-control/configure-core-rbac/manage-permissions">permissions</see> to a specified user role.
    /// </summary>
    /// <example><code>
    /// await client.Roles.Permissions.AddAsync(
    ///     "id",
    ///     new AddRolePermissionsRequestContent
    ///     {
    ///         Permissions = new List&lt;PermissionRequestPayload&gt;()
    ///         {
    ///             new PermissionRequestPayload
    ///             {
    ///                 ResourceServerIdentifier = "resource_server_identifier",
    ///                 PermissionName = "permission_name",
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task AddAsync(
        string id,
        AddRolePermissionsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _headers = await new Auth0.ManagementApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "roles/{0}/permissions",
                        ValueConvert.ToPathParameterString(id)
                    ),
                    Body = request,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            return;
        }
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ManagementApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Remove one or more <see href="https://auth0.com/docs/manage-users/access-control/configure-core-rbac/manage-permissions">permissions</see> from a specified user role.
    /// </summary>
    /// <example><code>
    /// await client.Roles.Permissions.DeleteAsync(
    ///     "id",
    ///     new DeleteRolePermissionsRequestContent
    ///     {
    ///         Permissions = new List&lt;PermissionRequestPayload&gt;()
    ///         {
    ///             new PermissionRequestPayload
    ///             {
    ///                 ResourceServerIdentifier = "resource_server_identifier",
    ///                 PermissionName = "permission_name",
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task DeleteAsync(
        string id,
        DeleteRolePermissionsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _headers = await new Auth0.ManagementApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "roles/{0}/permissions",
                        ValueConvert.ToPathParameterString(id)
                    ),
                    Body = request,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            return;
        }
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ManagementApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }
}
