using Auth0.ManagementApi.Core;
using global::System.Net.ServerSentEvents;
using global::System.Text.Json;

namespace Auth0.ManagementApi;

public partial class EventsClient : IEventsClient
{
    private readonly RawClient _client;

    internal EventsClient(RawClient client)
    {
        _client = client;
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
    ///             EventStreamSubscribeEventsEventTypeEnum.GroupCreated,
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async IAsyncEnumerable<EventStreamSubscribeEventsResponseContent> SubscribeAsync(
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "events",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            await foreach (
                var item in SseParser
                    .Create(await response.Raw.Content.ReadAsStreamAsync())
                    .EnumerateAsync(cancellationToken)
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
                        throw new ManagementException(
                            "Failed to deserialize streaming response",
                            e
                        );
                    }
                }
            }
            yield break;
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
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 410:
                        throw new GoneError(JsonUtils.Deserialize<object>(responseBody));
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
