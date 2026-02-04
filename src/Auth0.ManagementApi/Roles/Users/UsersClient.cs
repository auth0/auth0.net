using System.Text.Json;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Roles;

public partial class UsersClient : IUsersClient
{
    private RawClient _client;

    internal UsersClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Retrieve list of users associated with a specific role. For Dashboard instructions, review <a href="https://auth0.com/docs/manage-users/access-control/configure-core-rbac/roles/view-users-assigned-to-roles">View Users Assigned to Roles</a>.
    ///
    /// This endpoint supports two types of pagination:
    /// <ul>
    /// <li>Offset pagination</li>
    /// <li>Checkpoint pagination</li>
    /// </ul>
    ///
    /// Checkpoint pagination must be used if you need to retrieve more than 1000 organization members.
    ///
    /// &lt;h2&gt;Checkpoint Pagination&lt;/h2&gt;
    ///
    /// To search by checkpoint, use the following parameters:
    /// <ul>
    /// <li><code>from</code>: Optional id from which to start selection.</li>
    /// <li><code>take</code>: The total amount of entries to retrieve when using the from parameter. Defaults to 50.</li>
    /// </ul>
    ///
    /// <b>Note</b>: The first time you call this endpoint using checkpoint pagination, omit the <code>from</code> parameter. If there are more results, a <code>next</code> value is included in the response. You can use this for subsequent API calls. When <code>next</code> is no longer included in the response, no pages are remaining.
    /// </summary>
    private WithRawResponseTask<ListRoleUsersPaginatedResponseContent> ListInternalAsync(
        string id,
        ListRoleUsersRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ListRoleUsersPaginatedResponseContent>(
            ListInternalAsyncCore(id, request, options, cancellationToken)
        );
    }

    private async Task<
        WithRawResponse<ListRoleUsersPaginatedResponseContent>
    > ListInternalAsyncCore(
        string id,
        ListRoleUsersRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Auth0.ManagementApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("from", request.From.IsDefined ? request.From.Value : null)
            .Add("take", request.Take.IsDefined ? request.Take.Value : null)
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
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format("roles/{0}/users", ValueConvert.ToPathParameterString(id)),
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
                var responseData = JsonUtils.Deserialize<ListRoleUsersPaginatedResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<ListRoleUsersPaginatedResponseContent>()
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
    /// Retrieve list of users associated with a specific role. For Dashboard instructions, review <a href="https://auth0.com/docs/manage-users/access-control/configure-core-rbac/roles/view-users-assigned-to-roles">View Users Assigned to Roles</a>.
    ///
    /// This endpoint supports two types of pagination:
    /// <ul>
    /// <li>Offset pagination</li>
    /// <li>Checkpoint pagination</li>
    /// </ul>
    ///
    /// Checkpoint pagination must be used if you need to retrieve more than 1000 organization members.
    ///
    /// &lt;h2&gt;Checkpoint Pagination&lt;/h2&gt;
    ///
    /// To search by checkpoint, use the following parameters:
    /// <ul>
    /// <li><code>from</code>: Optional id from which to start selection.</li>
    /// <li><code>take</code>: The total amount of entries to retrieve when using the from parameter. Defaults to 50.</li>
    /// </ul>
    ///
    /// <b>Note</b>: The first time you call this endpoint using checkpoint pagination, omit the <code>from</code> parameter. If there are more results, a <code>next</code> value is included in the response. You can use this for subsequent API calls. When <code>next</code> is no longer included in the response, no pages are remaining.
    /// </summary>
    /// <example><code>
    /// await client.Roles.Users.ListAsync(
    ///     "id",
    ///     new ListRoleUsersRequestParameters { From = "from", Take = 1 }
    /// );
    /// </code></example>
    public async Task<Pager<RoleUser>> ListAsync(
        string id,
        ListRoleUsersRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListRoleUsersRequestParameters,
            RequestOptions?,
            ListRoleUsersPaginatedResponseContent,
            string?,
            RoleUser
        >
            .CreateInstanceAsync(
                request,
                options,
                async (request, options, cancellationToken) =>
                    await ListInternalAsync(id, request, options, cancellationToken)
                        .ConfigureAwait(false),
                (request, cursor) =>
                {
                    request.From = cursor;
                },
                response => response.Next,
                response => response.Users?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Assign one or more users to an existing user role. To learn more, review <a href="https://auth0.com/docs/manage-users/access-control/rbac">Role-Based Access Control</a>.
    ///
    /// <b>Note</b>: New roles cannot be created through this action.
    /// </summary>
    /// <example><code>
    /// await client.Roles.Users.AssignAsync(
    ///     "id",
    ///     new AssignRoleUsersRequestContent { Users = new List&lt;string&gt;() { "users" } }
    /// );
    /// </code></example>
    public async Task AssignAsync(
        string id,
        AssignRoleUsersRequestContent request,
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
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = string.Format("roles/{0}/users", ValueConvert.ToPathParameterString(id)),
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
}
