using Auth0.ManagementApi;

namespace Auth0.ManagementApi.EventStreams;

public partial interface IDeliveriesClient
{
    WithRawResponseTask<IEnumerable<EventStreamDelivery>> ListAsync(
        string id,
        ListEventStreamDeliveriesRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<GetEventStreamDeliveryHistoryResponseContent> GetHistoryAsync(
        string id,
        string eventId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
