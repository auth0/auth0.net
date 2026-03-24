using System.Text.Json;
using Auth0.ManagementApi.Core;
using Auth0.ManagementApi.Organizations;

namespace Auth0.ManagementApi;

public partial class OrganizationsClient : IOrganizationsClient
{
    private RawClient _client;

    internal OrganizationsClient(RawClient client)
    {
        _client = client;
        ClientGrants = new Auth0.ManagementApi.Organizations.ClientGrantsClient(_client);
        DiscoveryDomains = new DiscoveryDomainsClient(_client);
        EnabledConnections = new EnabledConnectionsClient(_client);
        Invitations = new InvitationsClient(_client);
        Members = new Auth0.ManagementApi.Organizations.MembersClient(_client);
    }

    public Auth0.ManagementApi.Organizations.IClientGrantsClient ClientGrants { get; }

    public IDiscoveryDomainsClient DiscoveryDomains { get; }

    public IEnabledConnectionsClient EnabledConnections { get; }

    public IInvitationsClient Invitations { get; }

    public Auth0.ManagementApi.Organizations.IMembersClient Members { get; }

    /// <summary>
    /// Retrieve detailed list of all Organizations available in your tenant. For more information, see Auth0 Organizations.
    ///
    /// This endpoint supports two types of pagination:
    /// <list type="bullet">
    /// <item><description>Offset pagination</description></item>
    /// <item><description>Checkpoint pagination</description></item>
    /// </list>
    ///
    /// Checkpoint pagination must be used if you need to retrieve more than 1000 organizations.
    ///
    /// <para>Checkpoint Pagination</para>
    ///
    /// To search by checkpoint, use the following parameters:
    /// <list type="bullet">
    /// <item><description><c>from</c>: Optional id from which to start selection.</description></item>
    /// <item><description><c>take</c>: The total number of entries to retrieve when using the <c>from</c> parameter. Defaults to 50.</description></item>
    /// </list>
    ///
    /// <b>Note</b>: The first time you call this endpoint using checkpoint pagination, omit the <c>from</c> parameter. If there are more results, a <c>next</c> value is included in the response. You can use this for subsequent API calls. When <c>next</c> is no longer included in the response, no pages are remaining.
    /// </summary>
    private WithRawResponseTask<ListOrganizationsPaginatedResponseContent> ListInternalAsync(
        ListOrganizationsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ListOrganizationsPaginatedResponseContent>(
            ListInternalAsyncCore(request, options, cancellationToken)
        );
    }

    private async Task<
        WithRawResponse<ListOrganizationsPaginatedResponseContent>
    > ListInternalAsyncCore(
        ListOrganizationsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Auth0.ManagementApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("from", request.From.IsDefined ? request.From.Value : null)
            .Add("take", request.Take.IsDefined ? request.Take.Value : null)
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
                    Method = HttpMethod.Get,
                    Path = "organizations",
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
                var responseData = JsonUtils.Deserialize<ListOrganizationsPaginatedResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<ListOrganizationsPaginatedResponseContent>()
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

    private async Task<WithRawResponse<CreateOrganizationResponseContent>> CreateAsyncCore(
        CreateOrganizationRequestContent request,
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
                    Path = "organizations",
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
                var responseData = JsonUtils.Deserialize<CreateOrganizationResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<CreateOrganizationResponseContent>()
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
                    case 409:
                        throw new ConflictError(JsonUtils.Deserialize<object>(responseBody));
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

    private async Task<WithRawResponse<GetOrganizationByNameResponseContent>> GetByNameAsyncCore(
        string name,
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
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "organizations/name/{0}",
                        ValueConvert.ToPathParameterString(name)
                    ),
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
                var responseData = JsonUtils.Deserialize<GetOrganizationByNameResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<GetOrganizationByNameResponseContent>()
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

    private async Task<WithRawResponse<GetOrganizationResponseContent>> GetAsyncCore(
        string id,
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
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "organizations/{0}",
                        ValueConvert.ToPathParameterString(id)
                    ),
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
                var responseData = JsonUtils.Deserialize<GetOrganizationResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<GetOrganizationResponseContent>()
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

    private async Task<WithRawResponse<UpdateOrganizationResponseContent>> UpdateAsyncCore(
        string id,
        UpdateOrganizationRequestContent request,
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
                    Method = HttpMethodExtensions.Patch,
                    Path = string.Format(
                        "organizations/{0}",
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
                var responseData = JsonUtils.Deserialize<UpdateOrganizationResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<UpdateOrganizationResponseContent>()
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
    /// Retrieve detailed list of all Organizations available in your tenant. For more information, see Auth0 Organizations.
    ///
    /// This endpoint supports two types of pagination:
    /// <list type="bullet">
    /// <item><description>Offset pagination</description></item>
    /// <item><description>Checkpoint pagination</description></item>
    /// </list>
    ///
    /// Checkpoint pagination must be used if you need to retrieve more than 1000 organizations.
    ///
    /// <para>Checkpoint Pagination</para>
    ///
    /// To search by checkpoint, use the following parameters:
    /// <list type="bullet">
    /// <item><description><c>from</c>: Optional id from which to start selection.</description></item>
    /// <item><description><c>take</c>: The total number of entries to retrieve when using the <c>from</c> parameter. Defaults to 50.</description></item>
    /// </list>
    ///
    /// <b>Note</b>: The first time you call this endpoint using checkpoint pagination, omit the <c>from</c> parameter. If there are more results, a <c>next</c> value is included in the response. You can use this for subsequent API calls. When <c>next</c> is no longer included in the response, no pages are remaining.
    /// </summary>
    /// <example><code>
    /// await client.Organizations.ListAsync(
    ///     new ListOrganizationsRequestParameters
    ///     {
    ///         From = "from",
    ///         Take = 1,
    ///         Sort = "sort",
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<Organization>> ListAsync(
        ListOrganizationsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListOrganizationsRequestParameters,
            RequestOptions?,
            ListOrganizationsPaginatedResponseContent,
            string?,
            Organization
        >
            .CreateInstanceAsync(
                request,
                options,
                async (request, options, cancellationToken) =>
                    await ListInternalAsync(request, options, cancellationToken),
                (request, cursor) =>
                {
                    request.From = cursor;
                },
                response => response.Next,
                response => response.Organizations?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Create a new Organization within your tenant.  To learn more about Organization settings, behavior, and configuration options, review <see href="https://auth0.com/docs/manage-users/organizations/create-first-organization">Create Your First Organization</see>.
    /// </summary>
    /// <example><code>
    /// await client.Organizations.CreateAsync(new CreateOrganizationRequestContent { Name = "name" });
    /// </code></example>
    public WithRawResponseTask<CreateOrganizationResponseContent> CreateAsync(
        CreateOrganizationRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CreateOrganizationResponseContent>(
            CreateAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve details about a single Organization specified by name.
    /// </summary>
    /// <example><code>
    /// await client.Organizations.GetByNameAsync("name");
    /// </code></example>
    public WithRawResponseTask<GetOrganizationByNameResponseContent> GetByNameAsync(
        string name,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetOrganizationByNameResponseContent>(
            GetByNameAsyncCore(name, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve details about a single Organization specified by ID.
    /// </summary>
    /// <example><code>
    /// await client.Organizations.GetAsync("id");
    /// </code></example>
    public WithRawResponseTask<GetOrganizationResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetOrganizationResponseContent>(
            GetAsyncCore(id, options, cancellationToken)
        );
    }

    /// <summary>
    /// Remove an Organization from your tenant.  This action cannot be undone.
    ///
    /// <b>Note</b>: Members are automatically disassociated from an Organization when it is deleted. However, this action does <b>not</b> delete these users from your tenant.
    /// </summary>
    /// <example><code>
    /// await client.Organizations.DeleteAsync("id");
    /// </code></example>
    public async Task DeleteAsync(
        string id,
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
                        "organizations/{0}",
                        ValueConvert.ToPathParameterString(id)
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
    /// Update the details of a specific <see href="https://auth0.com/docs/manage-users/organizations/configure-organizations/create-organizations">Organization</see>, such as name and display name, branding options, and metadata.
    /// </summary>
    /// <example><code>
    /// await client.Organizations.UpdateAsync("id", new UpdateOrganizationRequestContent());
    /// </code></example>
    public WithRawResponseTask<UpdateOrganizationResponseContent> UpdateAsync(
        string id,
        UpdateOrganizationRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<UpdateOrganizationResponseContent>(
            UpdateAsyncCore(id, request, options, cancellationToken)
        );
    }
}
