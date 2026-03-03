using System.Text.Json;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Actions;

public partial class VersionsClient : IVersionsClient
{
    private RawClient _client;

    internal VersionsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Retrieve all of an action's versions. An action version is created whenever an action is deployed. An action version is immutable, once created.
    /// </summary>
    private WithRawResponseTask<ListActionVersionsPaginatedResponseContent> ListInternalAsync(
        string actionId,
        ListActionVersionsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ListActionVersionsPaginatedResponseContent>(
            ListInternalAsyncCore(actionId, request, options, cancellationToken)
        );
    }

    private async Task<
        WithRawResponse<ListActionVersionsPaginatedResponseContent>
    > ListInternalAsyncCore(
        string actionId,
        ListActionVersionsRequestParameters request,
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
                        "actions/actions/{0}/versions",
                        ValueConvert.ToPathParameterString(actionId)
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
                    JsonUtils.Deserialize<ListActionVersionsPaginatedResponseContent>(
                        responseBody
                    )!;
                return new WithRawResponse<ListActionVersionsPaginatedResponseContent>()
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

    private async Task<WithRawResponse<GetActionVersionResponseContent>> GetAsyncCore(
        string actionId,
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
                        "actions/actions/{0}/versions/{1}",
                        ValueConvert.ToPathParameterString(actionId),
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
                var responseData = JsonUtils.Deserialize<GetActionVersionResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<GetActionVersionResponseContent>()
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

    private async Task<WithRawResponse<DeployActionVersionResponseContent>> DeployAsyncCore(
        string actionId,
        string id,
        Optional<DeployActionVersionRequestContent?> request,
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
                        "actions/actions/{0}/versions/{1}/deploy",
                        ValueConvert.ToPathParameterString(actionId),
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
                var responseData = JsonUtils.Deserialize<DeployActionVersionResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<DeployActionVersionResponseContent>()
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
    /// Retrieve all of an action's versions. An action version is created whenever an action is deployed. An action version is immutable, once created.
    /// </summary>
    /// <example><code>
    /// await client.Actions.Versions.ListAsync(
    ///     "actionId",
    ///     new ListActionVersionsRequestParameters { Page = 1, PerPage = 1 }
    /// );
    /// </code></example>
    public async Task<Pager<ActionVersion>> ListAsync(
        string actionId,
        ListActionVersionsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        request = request with { };
        var pager = await OffsetPager<
            ListActionVersionsRequestParameters,
            RequestOptions?,
            ListActionVersionsPaginatedResponseContent,
            int?,
            int?,
            ActionVersion
        >
            .CreateInstanceAsync(
                request,
                options,
                async (request, options, cancellationToken) =>
                    await ListInternalAsync(actionId, request, options, cancellationToken)
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
    /// Retrieve a specific version of an action. An action version is created whenever an action is deployed. An action version is immutable, once created.
    /// </summary>
    /// <example><code>
    /// await client.Actions.Versions.GetAsync("actionId", "id");
    /// </code></example>
    public WithRawResponseTask<GetActionVersionResponseContent> GetAsync(
        string actionId,
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetActionVersionResponseContent>(
            GetAsyncCore(actionId, id, options, cancellationToken)
        );
    }

    /// <summary>
    /// Performs the equivalent of a roll-back of an action to an earlier, specified version. Creates a new, deployed action version that is identical to the specified version. If this action is currently bound to a trigger, the system will begin executing the newly-created version immediately.
    /// </summary>
    /// <example><code>
    /// await client.Actions.Versions.DeployAsync(
    ///     "actionId",
    ///     "id",
    ///     new DeployActionVersionRequestContent()
    /// );
    /// </code></example>
    public WithRawResponseTask<DeployActionVersionResponseContent> DeployAsync(
        string actionId,
        string id,
        Optional<DeployActionVersionRequestContent?> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<DeployActionVersionResponseContent>(
            DeployAsyncCore(actionId, id, request, options, cancellationToken)
        );
    }
}
