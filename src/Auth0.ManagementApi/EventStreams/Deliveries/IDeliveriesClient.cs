using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.EventStreams;

public partial interface IDeliveriesClient
{
    Task<Pager<EventStreamDelivery>> ListAsync(
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
