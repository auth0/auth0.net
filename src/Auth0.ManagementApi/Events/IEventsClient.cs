namespace Auth0.ManagementApi;

public partial interface IEventsClient
{
    /// <summary>
    /// Subscribe to events via Server-Sent Events (SSE)
    /// </summary>
    WithRawResponseStream<EventStreamSubscribeEventsResponseContent> SubscribeAsync(
        SubscribeEventsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
