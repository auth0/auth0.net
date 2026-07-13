using Auth0.ManagementApi.Core;
using global::System.Runtime.CompilerServices;
using global::System.Text.Json;

namespace Auth0.ManagementApi;

public partial class EventsClient : IEventsClient
{
    private readonly RawClient _client;

    internal EventsClient(RawClient client)
    {
        _client = client;
    }

    private async Task<
        WithRawResponse<IAsyncEnumerable<EventStreamSubscribeEventsResponseContent>>
    > SubscribeAsyncCore(
        SubscribeEventsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Auth0.ManagementApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("from", request.From.IsDefined ? request.From.Value : null)
            .Add(
                "from_timestamp",
                request.FromTimestamp.IsDefined ? request.FromTimestamp.Value : null
            )
            .Add("event_type", request.EventType)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Auth0.ManagementApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var request_ = new JsonRequest
        {
            Method = HttpMethod.Get,
            Path = "events",
            QueryString = _queryString,
            Headers = _headers,
            Options = options,
        };
        var response = await _client
            .SendRequestAsync(request_, cancellationToken)
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            async global::System.Threading.Tasks.Task<Auth0.ManagementApi.Core.ApiResponse> ReconnectAsync(
                string lastEventId,
                CancellationToken ct
            )
            {
                var reconnectHeaders = new Dictionary<string, string>(
                    request_.Headers,
                    StringComparer.OrdinalIgnoreCase
                );
                reconnectHeaders["Last-Event-ID"] = lastEventId;
                return await _client
                    .SendRequestAsync(request_ with { Headers = reconnectHeaders }, ct)
                    .ConfigureAwait(false);
            }

            return new WithRawResponse<
                IAsyncEnumerable<EventStreamSubscribeEventsResponseContent>
            >()
            {
                Data = SubscribeAsyncBody(response, ReconnectAsync, options, cancellationToken),
                RawResponse = new Auth0.ManagementApi.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                },
            };
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
                    case 410:
                        throw new GoneError(
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

    private async IAsyncEnumerable<EventStreamSubscribeEventsResponseContent> SubscribeAsyncBody(
        ApiResponse response,
        Func<string, CancellationToken, Task<ApiResponse>> reconnectFn,
        RequestOptions? options,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        await foreach (
            var item in SseReconnectHelper
                .EnumerateWithReconnectAsync(
                    response,
                    reconnectFn,
                    options?.MaxStreamReconnectAttempts,
                    options?.DisableStreamReconnection ?? false,
                    null,
                    cancellationToken
                )
                .ConfigureAwait(false)
        )
        {
            if (!string.IsNullOrEmpty(item.Data))
            {
                EventStreamSubscribeEventsResponseContent? result;
                try
                {
                    result = JsonUtils.Deserialize<EventStreamSubscribeEventsResponseContent>(
                        item.Data
                    );
                }
                catch (JsonException e)
                {
                    throw new ManagementException("Failed to deserialize streaming response", e);
                }
                yield return result!;
            }
        }
    }

    /// <summary>
    /// Subscribe to events via Server-Sent Events (SSE)
    /// </summary>
    /// <example><code>
    /// client.Events.SubscribeAsync(
    ///     new SubscribeEventsRequestParameters
    ///     {
    ///         From = "from",
    ///         FromTimestamp = "from_timestamp",
    ///         EventType = new List&lt;EventStreamSubscribeEventsEventTypeEnum?&gt;()
    ///         {
    ///             EventStreamSubscribeEventsEventTypeEnum.ConnectionCreated,
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseStream<EventStreamSubscribeEventsResponseContent> SubscribeAsync(
        SubscribeEventsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseStream<EventStreamSubscribeEventsResponseContent>(
            SubscribeAsyncCore(request, options, cancellationToken),
            cancellationToken
        );
    }
}
