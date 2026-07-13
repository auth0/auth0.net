using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json;

namespace Auth0.ManagementApi.Organizations.Members;

public partial class EffectiveRolesClient : IEffectiveRolesClient
{
    private readonly RawClient _client;

    internal EffectiveRolesClient(RawClient client)
    {
        _client = client;
        Sources =
            new Auth0.ManagementApi.Organizations.Members.EffectiveRoles.Sources.SourcesClient(
                _client
            );
    }

    public Auth0.ManagementApi.Organizations.Members.EffectiveRoles.Sources.ISourcesClient Sources { get; }

    /// <summary>
    /// Lists the roles assigned to an organization member directly or through group membership.
    /// </summary>
    private WithRawResponseTask<ListOrganizationMemberEffectiveRolesResponseContent> ListInternalAsync(
        string id,
        string userId,
        ListOrganizationMemberEffectiveRolesRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ListOrganizationMemberEffectiveRolesResponseContent>(
            ListInternalAsyncCore(id, userId, request, options, cancellationToken)
        );
    }

    private async Task<
        WithRawResponse<ListOrganizationMemberEffectiveRolesResponseContent>
    > ListInternalAsyncCore(
        string id,
        string userId,
        ListOrganizationMemberEffectiveRolesRequestParameters request,
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
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "organizations/{0}/members/{1}/effective-roles",
                        ValueConvert.ToPathParameterString(id),
                        ValueConvert.ToPathParameterString(userId)
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
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData =
                    JsonUtils.Deserialize<ListOrganizationMemberEffectiveRolesResponseContent>(
                        responseBody
                    )!;
                return new WithRawResponse<ListOrganizationMemberEffectiveRolesResponseContent>()
                {
                    Data = responseData,
                    RawResponse = new Auth0.ManagementApi.RawResponse()
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
                    null,
                    e,
                    rawResponse: new Auth0.ManagementApi.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(
                            JsonUtils.Deserialize<object>(responseBody),
                            rawResponse: new Auth0.ManagementApi.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 401:
                        throw new UnauthorizedError(
                            JsonUtils.Deserialize<object>(responseBody),
                            rawResponse: new Auth0.ManagementApi.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 403:
                        throw new ForbiddenError(
                            JsonUtils.Deserialize<object>(responseBody),
                            rawResponse: new Auth0.ManagementApi.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 404:
                        throw new NotFoundError(
                            JsonUtils.Deserialize<object>(responseBody),
                            rawResponse: new Auth0.ManagementApi.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 429:
                        throw new TooManyRequestsError(
                            JsonUtils.Deserialize<object>(responseBody),
                            rawResponse: new Auth0.ManagementApi.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ManagementApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Auth0.ManagementApi.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    /// <summary>
    /// Lists the roles assigned to an organization member directly or through group membership.
    /// </summary>
    /// <example><code>
    /// await client.Organizations.Members.EffectiveRoles.ListAsync(
    ///     "id",
    ///     "user_id",
    ///     new ListOrganizationMemberEffectiveRolesRequestParameters { From = "from", Take = 1 }
    /// );
    /// </code></example>
    public async Task<Pager<OrganizationMemberEffectiveRole>> ListAsync(
        string id,
        string userId,
        ListOrganizationMemberEffectiveRolesRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListOrganizationMemberEffectiveRolesRequestParameters,
            RequestOptions?,
            ListOrganizationMemberEffectiveRolesResponseContent,
            string?,
            OrganizationMemberEffectiveRole
        >
            .CreateInstanceAsync(
                request,
                options,
                async (request, options, cancellationToken) =>
                    await ListInternalAsync(id, userId, request, options, cancellationToken)
                        .WithRawResponse(),
                (request, cursor) =>
                {
                    request.From = cursor;
                },
                response => response.Next,
                response => response.Roles?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }
}
