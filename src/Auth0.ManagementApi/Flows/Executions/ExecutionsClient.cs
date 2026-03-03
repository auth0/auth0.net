using System.Text.Json;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Flows;

public partial class ExecutionsClient : IExecutionsClient
{
    private RawClient _client;

    internal ExecutionsClient(RawClient client)
    {
        _client = client;
    }

    private WithRawResponseTask<ListFlowExecutionsPaginatedResponseContent> ListInternalAsync(
        string flowId,
        ListFlowExecutionsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ListFlowExecutionsPaginatedResponseContent>(
            ListInternalAsyncCore(flowId, request, options, cancellationToken)
        );
    }

    private async Task<
        WithRawResponse<ListFlowExecutionsPaginatedResponseContent>
    > ListInternalAsyncCore(
        string flowId,
        ListFlowExecutionsRequestParameters request,
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
                        "flows/{0}/executions",
                        ValueConvert.ToPathParameterString(flowId)
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
                    JsonUtils.Deserialize<ListFlowExecutionsPaginatedResponseContent>(
                        responseBody
                    )!;
                return new WithRawResponse<ListFlowExecutionsPaginatedResponseContent>()
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

    private async Task<WithRawResponse<GetFlowExecutionResponseContent>> GetAsyncCore(
        string flowId,
        string executionId,
        GetFlowExecutionRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Auth0.ManagementApi.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("hydrate", request.Hydrate)
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
                        "flows/{0}/executions/{1}",
                        ValueConvert.ToPathParameterString(flowId),
                        ValueConvert.ToPathParameterString(executionId)
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
                var responseData = JsonUtils.Deserialize<GetFlowExecutionResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<GetFlowExecutionResponseContent>()
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

    /// <example><code>
    /// await client.Flows.Executions.ListAsync(
    ///     "flow_id",
    ///     new ListFlowExecutionsRequestParameters { From = "from", Take = 1 }
    /// );
    /// </code></example>
    public async Task<Pager<FlowExecutionSummary>> ListAsync(
        string flowId,
        ListFlowExecutionsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListFlowExecutionsRequestParameters,
            RequestOptions?,
            ListFlowExecutionsPaginatedResponseContent,
            string?,
            FlowExecutionSummary
        >
            .CreateInstanceAsync(
                request,
                options,
                async (request, options, cancellationToken) =>
                    await ListInternalAsync(flowId, request, options, cancellationToken)
                        .ConfigureAwait(false),
                (request, cursor) =>
                {
                    request.From = cursor;
                },
                response => response.Next,
                response => response.Executions?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <example><code>
    /// await client.Flows.Executions.GetAsync(
    ///     "flow_id",
    ///     "execution_id",
    ///     new GetFlowExecutionRequestParameters()
    /// );
    /// </code></example>
    public WithRawResponseTask<GetFlowExecutionResponseContent> GetAsync(
        string flowId,
        string executionId,
        GetFlowExecutionRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetFlowExecutionResponseContent>(
            GetAsyncCore(flowId, executionId, request, options, cancellationToken)
        );
    }

    /// <example><code>
    /// await client.Flows.Executions.DeleteAsync("flow_id", "execution_id");
    /// </code></example>
    public async Task DeleteAsync(
        string flowId,
        string executionId,
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
                        "flows/{0}/executions/{1}",
                        ValueConvert.ToPathParameterString(flowId),
                        ValueConvert.ToPathParameterString(executionId)
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
