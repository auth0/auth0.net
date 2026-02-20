using Auth0.ManagementApi.Core;
using Auth0.ManagementApi.EventStreams;

namespace Auth0.ManagementApi;

public partial interface IEventStreamsClient
{
    public IDeliveriesClient Deliveries { get; }
    public IRedeliveriesClient Redeliveries { get; }
    Task<Pager<EventStreamResponseContent>> ListAsync(
        ListEventStreamsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<CreateEventStreamResponseContent> CreateAsync(
        EventStreamsCreateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<GetEventStreamResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<UpdateEventStreamResponseContent> UpdateAsync(
        string id,
        UpdateEventStreamRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<CreateEventStreamTestEventResponseContent> TestAsync(
        string id,
        CreateEventStreamTestEventRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
