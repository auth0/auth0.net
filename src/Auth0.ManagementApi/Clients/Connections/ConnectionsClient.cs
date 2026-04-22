using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json;

namespace Auth0.ManagementApi.Clients;

public partial class ConnectionsClient : IConnectionsClient
{
    private readonly RawClient _client;

    internal ConnectionsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Retrieve all connections that are enabled for the specified <see href="https://www.auth0.com/docs/get-started/applications"> Application</see>, using checkpoint pagination. A list of fields to include or exclude for each connection may also be specified.
    /// <list type="bullet">
    ///   <item><description>
    ///     This endpoint requires the <c>read:connections</c> scope and any one of <c>read:clients</c> or <c>read:client_summary</c>.
    ///   </description></item>
    ///   <item><description>
    ///     <b>Note</b>: The first time you call this endpoint, omit the <c>from</c> parameter. If there are more results, a <c>next</c> value is included in the response. You can use this for subsequent API calls. When <c>next</c> is no longer included in the response, no further results are remaining.
    ///   </description></item>
    /// </list>
    /// </summary>
    private WithRawResponseTask<ListClientConnectionsResponseContent> GetInternalAsync(
        string id,
        ConnectionsGetRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ListClientConnectionsResponseContent>(
            GetInternalAsyncCore(id, request, options, cancellationToken)
        );
    }

    private async Task<WithRawResponse<ListClientConnectionsResponseContent>> GetInternalAsyncCore(
        string id,
        ConnectionsGetRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Auth0.ManagementApi.Core.QueryStringBuilder.Builder(capacity: 5)
            .Add("strategy", request.Strategy)
            .Add("from", request.From.IsDefined ? request.From.Value : null)
            .Add("take", request.Take.IsDefined ? request.Take.Value : null)
            .Add("fields", request.Fields.IsDefined ? request.Fields.Value : null)
            .Add(
                "include_fields",
                request.IncludeFields.IsDefined ? request.IncludeFields.Value : null
            )
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
                        "clients/{0}/connections",
                        ValueConvert.ToPathParameterString(id)
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
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<ListClientConnectionsResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<ListClientConnectionsResponseContent>()
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
                    null,
                    e
                );
            }
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
    /// Retrieve all connections that are enabled for the specified <see href="https://www.auth0.com/docs/get-started/applications"> Application</see>, using checkpoint pagination. A list of fields to include or exclude for each connection may also be specified.
    /// <list type="bullet">
    ///   <item><description>
    ///     This endpoint requires the <c>read:connections</c> scope and any one of <c>read:clients</c> or <c>read:client_summary</c>.
    ///   </description></item>
    ///   <item><description>
    ///     <b>Note</b>: The first time you call this endpoint, omit the <c>from</c> parameter. If there are more results, a <c>next</c> value is included in the response. You can use this for subsequent API calls. When <c>next</c> is no longer included in the response, no further results are remaining.
    ///   </description></item>
    /// </list>
    /// </summary>
    /// <example><code>
    /// await client.Clients.Connections.GetAsync(
    ///     "id",
    ///     new ConnectionsGetRequest
    ///     {
    ///         Strategy = [new List&lt;ConnectionStrategyEnum?&gt;() { ConnectionStrategyEnum.Ad }],
    ///         From = "from",
    ///         Take = 1,
    ///         Fields = "fields",
    ///         IncludeFields = true,
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<ConnectionForList>> GetAsync(
        string id,
        ConnectionsGetRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ConnectionsGetRequest,
            RequestOptions?,
            ListClientConnectionsResponseContent,
            string?,
            ConnectionForList
        >
            .CreateInstanceAsync(
                request,
                options,
                async (request, options, cancellationToken) =>
                    await GetInternalAsync(id, request, options, cancellationToken)
                        .ConfigureAwait(false),
                (request, cursor) =>
                {
                    request.From = cursor;
                },
                response => response.Next,
                response => response.Connections?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }
}
