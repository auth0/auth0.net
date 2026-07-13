using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json;

namespace Auth0.ManagementApi.Organizations.Roles;

public partial class MembersClient : IMembersClient
{
    private readonly RawClient _client;

    internal MembersClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// List the organization members assigned a specific role within the context of an organization.
    /// </summary>
    private WithRawResponseTask<ListOrganizationRoleMembersResponseContent> ListInternalAsync(
        string id,
        string roleId,
        ListOrganizationRoleMembersRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ListOrganizationRoleMembersResponseContent>(
            ListInternalAsyncCore(id, roleId, request, options, cancellationToken)
        );
    }

    private async Task<
        WithRawResponse<ListOrganizationRoleMembersResponseContent>
    > ListInternalAsyncCore(
        string id,
        string roleId,
        ListOrganizationRoleMembersRequestParameters request,
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
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "organizations/{0}/roles/{1}/members",
                        ValueConvert.ToPathParameterString(id),
                        ValueConvert.ToPathParameterString(roleId)
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
                    JsonUtils.Deserialize<ListOrganizationRoleMembersResponseContent>(
                        responseBody
                    )!;
                return new WithRawResponse<ListOrganizationRoleMembersResponseContent>()
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
    /// List the organization members assigned a specific role within the context of an organization.
    /// </summary>
    /// <example><code>
    /// await client.Organizations.Roles.Members.ListAsync(
    ///     "id",
    ///     "role_id",
    ///     new ListOrganizationRoleMembersRequestParameters
    ///     {
    ///         From = "from",
    ///         Take = 1,
    ///         Fields = "fields",
    ///         IncludeFields = true,
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<RoleMember>> ListAsync(
        string id,
        string roleId,
        ListOrganizationRoleMembersRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListOrganizationRoleMembersRequestParameters,
            RequestOptions?,
            ListOrganizationRoleMembersResponseContent,
            string?,
            RoleMember
        >
            .CreateInstanceAsync(
                request,
                options,
                async (request, options, cancellationToken) =>
                    await ListInternalAsync(id, roleId, request, options, cancellationToken)
                        .WithRawResponse(),
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
}
