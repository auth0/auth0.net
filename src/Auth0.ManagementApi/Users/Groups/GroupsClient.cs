using System.Text.Json;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Users;

public partial class GroupsClient : IGroupsClient
{
    private RawClient _client;

    internal GroupsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// List all groups to which this user belongs.
    /// </summary>
    private WithRawResponseTask<GetUserGroupsPaginatedResponseContent> GetInternalAsync(
        string id,
        GetUserGroupsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetUserGroupsPaginatedResponseContent>(
            GetInternalAsyncCore(id, request, options, cancellationToken)
        );
    }

    private async Task<WithRawResponse<GetUserGroupsPaginatedResponseContent>> GetInternalAsyncCore(
        string id,
        GetUserGroupsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Auth0.ManagementApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("fields", request.Fields.IsDefined ? request.Fields.Value : null)
            .Add(
                "include_fields",
                request.IncludeFields.IsDefined ? request.IncludeFields.Value : null
            )
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
                    Path = string.Format(
                        "users/{0}/groups",
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
                var responseData = JsonUtils.Deserialize<GetUserGroupsPaginatedResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<GetUserGroupsPaginatedResponseContent>()
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
    /// List all groups to which this user belongs.
    /// </summary>
    /// <example><code>
    /// await client.Users.Groups.GetAsync(
    ///     "id",
    ///     new GetUserGroupsRequestParameters
    ///     {
    ///         Fields = "fields",
    ///         IncludeFields = true,
    ///         From = "from",
    ///         Take = 1,
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<UserGroupsResponseSchema>> GetAsync(
        string id,
        GetUserGroupsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            GetUserGroupsRequestParameters,
            RequestOptions?,
            GetUserGroupsPaginatedResponseContent,
            string?,
            UserGroupsResponseSchema
        >
            .CreateInstanceAsync(
                request,
                options,
                async (request, options, cancellationToken) =>
                    await GetInternalAsync(id, request, options, cancellationToken)
                        .ConfigureAwait(false),
                (request, cursor) =>
                {
                    request.From = cursor;
                },
                response => response.Next,
                response => response.Groups?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }
}
