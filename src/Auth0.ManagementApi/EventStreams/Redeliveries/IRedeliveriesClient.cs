using Auth0.ManagementApi;

namespace Auth0.ManagementApi.EventStreams;

public partial interface IRedeliveriesClient
{
    WithRawResponseTask<CreateEventStreamRedeliveryResponseContent> CreateAsync(
        string id,
        CreateEventStreamRedeliveryRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task CreateByIdAsync(
        string id,
        string eventId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
