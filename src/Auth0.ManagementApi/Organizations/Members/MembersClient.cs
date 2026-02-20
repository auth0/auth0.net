using System.Text.Json;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Organizations;

public partial class MembersClient : IMembersClient
{
    private RawClient _client;

    internal MembersClient(RawClient client)
    {
        _client = client;
        Roles = new Auth0.ManagementApi.Organizations.Members.RolesClient(_client);
    }

    public Auth0.ManagementApi.Organizations.Members.IRolesClient Roles { get; }

    /// <summary>
    /// List organization members.
    /// This endpoint is subject to eventual consistency. New users may not be immediately included in the response and deleted users may not be immediately removed from it.
    ///
    /// <list type="bullet">
    ///   <item><description>
    ///     Use the <c>fields</c> parameter to optionally define the specific member details retrieved. If <c>fields</c> is left blank, all fields (except roles) are returned.
    ///   </description></item>
    ///   <item><description>
    ///     Member roles are not sent by default. Use <c>fields=roles</c> to retrieve the roles assigned to each listed member. To use this parameter, you must include the <c>read:organization_member_roles</c> scope in the token.
    ///   </description></item>
    /// </list>
    ///
    /// This endpoint supports two types of pagination:
    ///
    /// - Offset pagination
    /// - Checkpoint pagination
    ///
    /// Checkpoint pagination must be used if you need to retrieve more than 1000 organization members.
    ///
    /// <para>Checkpoint Pagination</para>
    ///
    /// To search by checkpoint, use the following parameters: - from: Optional id from which to start selection. - take: The total amount of entries to retrieve when using the from parameter. Defaults to 50. Note: The first time you call this endpoint using Checkpoint Pagination, you should omit the <c>from</c> parameter. If there are more results, a <c>next</c> value will be included in the response. You can use this for subsequent API calls. When <c>next</c> is no longer included in the response, this indicates there are no more pages remaining.
    /// </summary>
    private WithRawResponseTask<ListOrganizationMembersPaginatedResponseContent> ListInternalAsync(
        string id,
        ListOrganizationMembersRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ListOrganizationMembersPaginatedResponseContent>(
            ListInternalAsyncCore(id, request, options, cancellationToken)
        );
    }

    private async Task<
        WithRawResponse<ListOrganizationMembersPaginatedResponseContent>
    > ListInternalAsyncCore(
        string id,
        ListOrganizationMembersRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Auth0.ManagementApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("from", request.From.IsDefined ? request.From.Value : null)
            .Add("take", request.Take.IsDefined ? request.Take.Value : null)
            .Add("fields", request.Fields.IsDefined ? request.Fields.Value : null)
            .Add(
                "include_fields",
                request.IncludeFields.IsDefined ? request.IncludeFields.Value : null
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
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "organizations/{0}/members",
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
                    JsonUtils.Deserialize<ListOrganizationMembersPaginatedResponseContent>(
                        responseBody
                    )!;
                return new WithRawResponse<ListOrganizationMembersPaginatedResponseContent>()
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
    /// List organization members.
    /// This endpoint is subject to eventual consistency. New users may not be immediately included in the response and deleted users may not be immediately removed from it.
    ///
    /// <list type="bullet">
    ///   <item><description>
    ///     Use the <c>fields</c> parameter to optionally define the specific member details retrieved. If <c>fields</c> is left blank, all fields (except roles) are returned.
    ///   </description></item>
    ///   <item><description>
    ///     Member roles are not sent by default. Use <c>fields=roles</c> to retrieve the roles assigned to each listed member. To use this parameter, you must include the <c>read:organization_member_roles</c> scope in the token.
    ///   </description></item>
    /// </list>
    ///
    /// This endpoint supports two types of pagination:
    ///
    /// - Offset pagination
    /// - Checkpoint pagination
    ///
    /// Checkpoint pagination must be used if you need to retrieve more than 1000 organization members.
    ///
    /// <para>Checkpoint Pagination</para>
    ///
    /// To search by checkpoint, use the following parameters: - from: Optional id from which to start selection. - take: The total amount of entries to retrieve when using the from parameter. Defaults to 50. Note: The first time you call this endpoint using Checkpoint Pagination, you should omit the <c>from</c> parameter. If there are more results, a <c>next</c> value will be included in the response. You can use this for subsequent API calls. When <c>next</c> is no longer included in the response, this indicates there are no more pages remaining.
    /// </summary>
    /// <example><code>
    /// await client.Organizations.Members.ListAsync(
    ///     "id",
    ///     new ListOrganizationMembersRequestParameters
    ///     {
    ///         From = "from",
    ///         Take = 1,
    ///         Fields = "fields",
    ///         IncludeFields = true,
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<OrganizationMember>> ListAsync(
        string id,
        ListOrganizationMembersRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListOrganizationMembersRequestParameters,
            RequestOptions?,
            ListOrganizationMembersPaginatedResponseContent,
            string?,
            OrganizationMember
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
                response => response.Members?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Set one or more existing users as members of a specific <see href="https://auth0.com/docs/manage-users/organizations">Organization</see>.
    ///
    /// To add a user to an Organization through this action, the user must already exist in your tenant. If a user does not yet exist, you can <see href="https://auth0.com/docs/manage-users/organizations/configure-organizations/invite-members">invite them to create an account</see>, manually create them through the Auth0 Dashboard, or use the Management API.
    /// </summary>
    /// <example><code>
    /// await client.Organizations.Members.CreateAsync(
    ///     "id",
    ///     new CreateOrganizationMemberRequestContent { Members = new List&lt;string&gt;() { "members" } }
    /// );
    /// </code></example>
    public async Task CreateAsync(
        string id,
        CreateOrganizationMemberRequestContent request,
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
                    Path = string.Format(
                        "organizations/{0}/members",
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

    /// <example><code>
    /// await client.Organizations.Members.DeleteAsync(
    ///     "id",
    ///     new DeleteOrganizationMembersRequestContent { Members = new List&lt;string&gt;() { "members" } }
    /// );
    /// </code></example>
    public async Task DeleteAsync(
        string id,
        DeleteOrganizationMembersRequestContent request,
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
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "organizations/{0}/members",
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
