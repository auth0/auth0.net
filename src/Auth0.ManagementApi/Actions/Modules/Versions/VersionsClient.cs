using System.Text.Json;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Actions.Modules;

public partial class VersionsClient : IVersionsClient
{
    private RawClient _client;

    internal VersionsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// List all published versions of a specific Actions Module.
    /// </summary>
    private WithRawResponseTask<GetActionModuleVersionsResponseContent> ListInternalAsync(
        string id,
        GetActionModuleVersionsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetActionModuleVersionsResponseContent>(
            ListInternalAsyncCore(id, request, options, cancellationToken)
        );
    }

    private async Task<
        WithRawResponse<GetActionModuleVersionsResponseContent>
    > ListInternalAsyncCore(
        string id,
        GetActionModuleVersionsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Auth0.ManagementApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("page", request.Page.IsDefined ? request.Page.Value : null)
            .Add("per_page", request.PerPage.IsDefined ? request.PerPage.Value : null)
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
                        "actions/modules/{0}/versions",
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
                var responseData = JsonUtils.Deserialize<GetActionModuleVersionsResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<GetActionModuleVersionsResponseContent>()
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

    private async Task<WithRawResponse<CreateActionModuleVersionResponseContent>> CreateAsyncCore(
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
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "actions/modules/{0}/versions",
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
                var responseData = JsonUtils.Deserialize<CreateActionModuleVersionResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<CreateActionModuleVersionResponseContent>()
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
                    case 409:
                        throw new ConflictError(JsonUtils.Deserialize<object>(responseBody));
                    case 412:
                        throw new PreconditionFailedError(
                            JsonUtils.Deserialize<object>(responseBody)
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
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<GetActionModuleVersionResponseContent>> GetAsyncCore(
        string id,
        string versionId,
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
                        "actions/modules/{0}/versions/{1}",
                        ValueConvert.ToPathParameterString(id),
                        ValueConvert.ToPathParameterString(versionId)
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
                var responseData = JsonUtils.Deserialize<GetActionModuleVersionResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<GetActionModuleVersionResponseContent>()
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
    /// List all published versions of a specific Actions Module.
    /// </summary>
    /// <example><code>
    /// await client.Actions.Modules.Versions.ListAsync(
    ///     "id",
    ///     new GetActionModuleVersionsRequestParameters { Page = 1, PerPage = 1 }
    /// );
    /// </code></example>
    public async Task<Pager<ActionModuleVersion>> ListAsync(
        string id,
        GetActionModuleVersionsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        request = request with { };
        var pager = await OffsetPager<
            GetActionModuleVersionsRequestParameters,
            RequestOptions?,
            GetActionModuleVersionsResponseContent,
            int?,
            int?,
            ActionModuleVersion
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
                response => response.Versions?.ToList(),
                null,
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Creates a new immutable version of an Actions Module from the current draft version. This publishes the draft as a new version that can be referenced by actions, while maintaining the existing draft for continued development.
    /// </summary>
    /// <example><code>
    /// await client.Actions.Modules.Versions.CreateAsync("id");
    /// </code></example>
    public WithRawResponseTask<CreateActionModuleVersionResponseContent> CreateAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CreateActionModuleVersionResponseContent>(
            CreateAsyncCore(id, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve the details of a specific, immutable version of an Actions Module.
    /// </summary>
    /// <example><code>
    /// await client.Actions.Modules.Versions.GetAsync("id", "versionId");
    /// </code></example>
    public WithRawResponseTask<GetActionModuleVersionResponseContent> GetAsync(
        string id,
        string versionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetActionModuleVersionResponseContent>(
            GetAsyncCore(id, versionId, options, cancellationToken)
        );
    }
}
