using System.Text.Json;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Organizations;

public partial class InvitationsClient : IInvitationsClient
{
    private RawClient _client;

    internal InvitationsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Retrieve a detailed list of invitations sent to users for a specific Organization. The list includes details such as inviter and invitee information, invitation URLs, and dates of creation and expiration. To learn more about Organization invitations, review <see href="https://auth0.com/docs/manage-users/organizations/configure-organizations/invite-members">Invite Organization Members</see>.
    /// </summary>
    private WithRawResponseTask<ListOrganizationInvitationsOffsetPaginatedResponseContent> ListInternalAsync(
        string id,
        ListOrganizationInvitationsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ListOrganizationInvitationsOffsetPaginatedResponseContent>(
            ListInternalAsyncCore(id, request, options, cancellationToken)
        );
    }

    private async Task<
        WithRawResponse<ListOrganizationInvitationsOffsetPaginatedResponseContent>
    > ListInternalAsyncCore(
        string id,
        ListOrganizationInvitationsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Auth0.ManagementApi.Core.QueryStringBuilder.Builder(capacity: 6)
            .Add("page", request.Page.IsDefined ? request.Page.Value : null)
            .Add("per_page", request.PerPage.IsDefined ? request.PerPage.Value : null)
            .Add(
                "include_totals",
                request.IncludeTotals.IsDefined ? request.IncludeTotals.Value : null
            )
            .Add("fields", request.Fields.IsDefined ? request.Fields.Value : null)
            .Add(
                "include_fields",
                request.IncludeFields.IsDefined ? request.IncludeFields.Value : null
            )
            .Add("sort", request.Sort.IsDefined ? request.Sort.Value : null)
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
                        "organizations/{0}/invitations",
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
                    JsonUtils.Deserialize<ListOrganizationInvitationsOffsetPaginatedResponseContent>(
                        responseBody
                    )!;
                return new WithRawResponse<ListOrganizationInvitationsOffsetPaginatedResponseContent>()
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
                    null,
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

    private async Task<
        WithRawResponse<CreateOrganizationInvitationResponseContent>
    > CreateAsyncCore(
        string id,
        CreateOrganizationInvitationRequestContent request,
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
                        "organizations/{0}/invitations",
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
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData =
                    JsonUtils.Deserialize<CreateOrganizationInvitationResponseContent>(
                        responseBody
                    )!;
                return new WithRawResponse<CreateOrganizationInvitationResponseContent>()
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
                    null,
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

    private async Task<WithRawResponse<GetOrganizationInvitationResponseContent>> GetAsyncCore(
        string id,
        string invitationId,
        GetOrganizationInvitationRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Auth0.ManagementApi.Core.QueryStringBuilder.Builder(capacity: 2)
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
                        "organizations/{0}/invitations/{1}",
                        ValueConvert.ToPathParameterString(id),
                        ValueConvert.ToPathParameterString(invitationId)
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
                var responseData = JsonUtils.Deserialize<GetOrganizationInvitationResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<GetOrganizationInvitationResponseContent>()
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
                    null,
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
    /// Retrieve a detailed list of invitations sent to users for a specific Organization. The list includes details such as inviter and invitee information, invitation URLs, and dates of creation and expiration. To learn more about Organization invitations, review <see href="https://auth0.com/docs/manage-users/organizations/configure-organizations/invite-members">Invite Organization Members</see>.
    /// </summary>
    /// <example><code>
    /// await client.Organizations.Invitations.ListAsync(
    ///     "id",
    ///     new ListOrganizationInvitationsRequestParameters
    ///     {
    ///         Page = 1,
    ///         PerPage = 1,
    ///         IncludeTotals = true,
    ///         Fields = "fields",
    ///         IncludeFields = true,
    ///         Sort = "sort",
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<OrganizationInvitation>> ListAsync(
        string id,
        ListOrganizationInvitationsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        request = request with { };
        var pager = await OffsetPager<
            ListOrganizationInvitationsRequestParameters,
            RequestOptions?,
            ListOrganizationInvitationsOffsetPaginatedResponseContent,
            int?,
            int?,
            OrganizationInvitation
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
                response => response.Invitations?.ToList(),
                null,
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Create a user invitation for a specific Organization. Upon creation, the listed user receives an email inviting them to join the Organization. To learn more about Organization invitations, review <see href="https://auth0.com/docs/manage-users/organizations/configure-organizations/invite-members">Invite Organization Members</see>.
    /// </summary>
    /// <example><code>
    /// await client.Organizations.Invitations.CreateAsync(
    ///     "id",
    ///     new CreateOrganizationInvitationRequestContent
    ///     {
    ///         Inviter = new OrganizationInvitationInviter { Name = "name" },
    ///         Invitee = new OrganizationInvitationInvitee { Email = "email" },
    ///         ClientId = "client_id",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CreateOrganizationInvitationResponseContent> CreateAsync(
        string id,
        CreateOrganizationInvitationRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CreateOrganizationInvitationResponseContent>(
            CreateAsyncCore(id, request, options, cancellationToken)
        );
    }

    /// <example><code>
    /// await client.Organizations.Invitations.GetAsync(
    ///     "id",
    ///     "invitation_id",
    ///     new GetOrganizationInvitationRequestParameters { Fields = "fields", IncludeFields = true }
    /// );
    /// </code></example>
    public WithRawResponseTask<GetOrganizationInvitationResponseContent> GetAsync(
        string id,
        string invitationId,
        GetOrganizationInvitationRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetOrganizationInvitationResponseContent>(
            GetAsyncCore(id, invitationId, request, options, cancellationToken)
        );
    }

    /// <example><code>
    /// await client.Organizations.Invitations.DeleteAsync("id", "invitation_id");
    /// </code></example>
    public async Task DeleteAsync(
        string id,
        string invitationId,
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
                        "organizations/{0}/invitations/{1}",
                        ValueConvert.ToPathParameterString(id),
                        ValueConvert.ToPathParameterString(invitationId)
                    ),
                    Headers = _headers,
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
