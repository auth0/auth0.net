using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Experimentation;

public partial interface ISegmentsClient
{
    /// <summary>
    /// Retrieve a paginated list of segments for the tenant.
    /// </summary>
    Task<Pager<Segment>> ListAsync(
        ListSegmentsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new segment with rule-based membership criteria for use in experiments.
    /// </summary>
    WithRawResponseTask<CreateSegmentResponseContent> CreateAsync(
        CreateSegmentRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a single segment by its ID.
    /// </summary>
    WithRawResponseTask<GetSegmentResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a segment by ID. Idempotent: returns 204 even if segment does not exist.
    /// </summary>
    WithRawResponseTask DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Partially update a segment by ID. Only provided fields are updated. Sending rules replaces the entire rules array.
    /// </summary>
    WithRawResponseTask<UpdateSegmentResponseContent> UpdateAsync(
        string id,
        UpdateSegmentRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
