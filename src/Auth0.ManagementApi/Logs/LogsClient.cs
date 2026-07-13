using Auth0.ManagementApi.Core;
using global::System.Text.Json;

namespace Auth0.ManagementApi;

public partial class LogsClient : ILogsClient
{
    private readonly RawClient _client;

    internal LogsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Retrieve log entries that match the specified search criteria (or all log entries if no criteria specified).
    ///
    /// Set custom search criteria using the `q` parameter, or search from a specific log ID (_"search from checkpoint"_).
    ///
    /// For more information on all possible event types, their respective acronyms, and descriptions, see [Log Event Type Codes](https://auth0.com/docs/logs/log-event-type-codes).
    ///
    /// **To set custom search criteria, use the following parameters:**
    ///
    /// - **q:** Search Criteria using [Query String Syntax](https://auth0.com/docs/logs/log-search-query-syntax)
    /// - **page:** Page index of the results to return. First page is 0.
    /// - **per_page:** Number of results per page.
    /// - **sort:** Field to use for sorting appended with `:1` for ascending and `:-1` for descending. e.g. `date:-1`
    /// - **fields:** Comma-separated list of fields to include or exclude (depending on include_fields) from the result, empty to retrieve all fields.
    /// - **include_fields:** Whether specified fields are to be included (true) or excluded (false).
    /// - **include_totals:** Return results inside an object that contains the total result count (true) or as a direct array of results (false, default). **Deprecated:** this field is deprecated and should be removed from use. See [Search Engine V3 Breaking Changes](https://auth0.com/docs/product-lifecycle/deprecations-and-migrations/migrate-to-tenant-log-search-v3#pagination)
    ///
    /// For more information on the list of fields that can be used in `fields` and `sort`, see [Searchable Fields](https://auth0.com/docs/logs/log-search-query-syntax#searchable-fields).
    ///
    /// Auth0 [limits the number of logs](https://auth0.com/docs/logs/retrieve-log-events-using-mgmt-api#limitations) you can return by search criteria to 100 logs per request. Furthermore, you may paginate only through 1,000 search results. If you exceed this threshold, please redefine your search or use the [get logs by checkpoint method](https://auth0.com/docs/logs/retrieve-log-events-using-mgmt-api#retrieve-logs-by-checkpoint).
    ///
    /// **To search from a checkpoint log ID, use the following parameters:**
    ///
    /// - **from:** Log Event ID from which to start retrieving logs. You can limit the number of logs returned using the `take` parameter. If you use `from` at the same time as `q`, `from` takes precedence and `q` is ignored.
    /// - **take:** Number of entries to retrieve when using the `from` parameter.
    ///
    /// **Important:** When fetching logs from a checkpoint log ID, any parameter other than `from` and `take` will be ignored, and date ordering is not guaranteed.
    /// </summary>
    private WithRawResponseTask<ListLogOffsetPaginatedResponseContent> ListInternalAsync(
        ListLogsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ListLogOffsetPaginatedResponseContent>(
            ListInternalAsyncCore(request, options, cancellationToken)
        );
    }

    private async Task<
        WithRawResponse<ListLogOffsetPaginatedResponseContent>
    > ListInternalAsyncCore(
        ListLogsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Auth0.ManagementApi.Core.QueryStringBuilder.Builder(capacity: 7)
            .Add("page", request.Page.IsDefined ? request.Page.Value : null)
            .Add("per_page", request.PerPage.IsDefined ? request.PerPage.Value : null)
            .Add("sort", request.Sort.IsDefined ? request.Sort.Value : null)
            .Add("fields", request.Fields.IsDefined ? request.Fields.Value : null)
            .Add(
                "include_fields",
                request.IncludeFields.IsDefined ? request.IncludeFields.Value : null
            )
            .Add(
                "include_totals",
                request.IncludeTotals.IsDefined ? request.IncludeTotals.Value : null
            )
            .Add("search", request.Search.IsDefined ? request.Search.Value : null)
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
                    Path = "logs",
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
                var responseData = JsonUtils.Deserialize<ListLogOffsetPaginatedResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<ListLogOffsetPaginatedResponseContent>()
                {
                    Data = responseData,
                    RawResponse = new Auth0.ManagementApi.RawResponse()
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
                    e,
                    rawResponse: new Auth0.ManagementApi.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
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

    private async Task<WithRawResponse<GetLogResponseContent>> GetAsyncCore(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Auth0.ManagementApi.Core.QueryStringBuilder.Builder(capacity: 0)
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
                    Path = string.Format("logs/{0}", ValueConvert.ToPathParameterString(id)),
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
                var responseData = JsonUtils.Deserialize<GetLogResponseContent>(responseBody)!;
                return new WithRawResponse<GetLogResponseContent>()
                {
                    Data = responseData,
                    RawResponse = new Auth0.ManagementApi.RawResponse()
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
                    e,
                    rawResponse: new Auth0.ManagementApi.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
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

    /// <summary>
    /// Retrieve log entries that match the specified search criteria (or all log entries if no criteria specified).
    ///
    /// Set custom search criteria using the `q` parameter, or search from a specific log ID (_"search from checkpoint"_).
    ///
    /// For more information on all possible event types, their respective acronyms, and descriptions, see [Log Event Type Codes](https://auth0.com/docs/logs/log-event-type-codes).
    ///
    /// **To set custom search criteria, use the following parameters:**
    ///
    /// - **q:** Search Criteria using [Query String Syntax](https://auth0.com/docs/logs/log-search-query-syntax)
    /// - **page:** Page index of the results to return. First page is 0.
    /// - **per_page:** Number of results per page.
    /// - **sort:** Field to use for sorting appended with `:1` for ascending and `:-1` for descending. e.g. `date:-1`
    /// - **fields:** Comma-separated list of fields to include or exclude (depending on include_fields) from the result, empty to retrieve all fields.
    /// - **include_fields:** Whether specified fields are to be included (true) or excluded (false).
    /// - **include_totals:** Return results inside an object that contains the total result count (true) or as a direct array of results (false, default). **Deprecated:** this field is deprecated and should be removed from use. See [Search Engine V3 Breaking Changes](https://auth0.com/docs/product-lifecycle/deprecations-and-migrations/migrate-to-tenant-log-search-v3#pagination)
    ///
    /// For more information on the list of fields that can be used in `fields` and `sort`, see [Searchable Fields](https://auth0.com/docs/logs/log-search-query-syntax#searchable-fields).
    ///
    /// Auth0 [limits the number of logs](https://auth0.com/docs/logs/retrieve-log-events-using-mgmt-api#limitations) you can return by search criteria to 100 logs per request. Furthermore, you may paginate only through 1,000 search results. If you exceed this threshold, please redefine your search or use the [get logs by checkpoint method](https://auth0.com/docs/logs/retrieve-log-events-using-mgmt-api#retrieve-logs-by-checkpoint).
    ///
    /// **To search from a checkpoint log ID, use the following parameters:**
    ///
    /// - **from:** Log Event ID from which to start retrieving logs. You can limit the number of logs returned using the `take` parameter. If you use `from` at the same time as `q`, `from` takes precedence and `q` is ignored.
    /// - **take:** Number of entries to retrieve when using the `from` parameter.
    ///
    /// **Important:** When fetching logs from a checkpoint log ID, any parameter other than `from` and `take` will be ignored, and date ordering is not guaranteed.
    /// </summary>
    /// <example><code>
    /// await client.Logs.ListAsync(
    ///     new ListLogsRequestParameters
    ///     {
    ///         Page = 1,
    ///         PerPage = 1,
    ///         Sort = "sort",
    ///         Fields = "fields",
    ///         IncludeFields = true,
    ///         IncludeTotals = true,
    ///         Search = "search",
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<Log>> ListAsync(
        ListLogsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        request = request with { };
        var pager = await OffsetPager<
            ListLogsRequestParameters,
            RequestOptions?,
            ListLogOffsetPaginatedResponseContent,
            int?,
            int?,
            Log
        >
            .CreateInstanceAsync(
                request,
                options,
                async (request, options, cancellationToken) =>
                    await ListInternalAsync(request, options, cancellationToken).WithRawResponse(),
                request => request.Page.GetValueOrDefault(0),
                (request, offset) =>
                {
                    request.Page = offset;
                },
                null,
                response => response.Logs?.ToList(),
                null,
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Retrieve an individual log event.
    /// </summary>
    /// <example><code>
    /// await client.Logs.GetAsync("id");
    /// </code></example>
    public WithRawResponseTask<GetLogResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetLogResponseContent>(
            GetAsyncCore(id, options, cancellationToken)
        );
    }
}
