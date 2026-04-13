using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json;

namespace Auth0.ManagementApi.ClientGrants;

public partial class OrganizationsClient : IOrganizationsClient
{
    private readonly RawClient _client;

    internal OrganizationsClient(RawClient client)
    {
        _client = client;
    }

    private WithRawResponseTask<ListClientGrantOrganizationsPaginatedResponseContent> ListInternalAsync(
        string id,
        ListClientGrantOrganizationsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ListClientGrantOrganizationsPaginatedResponseContent>(
            ListInternalAsyncCore(id, request, options, cancellationToken)
        );
    }

    private async Task<
        WithRawResponse<ListClientGrantOrganizationsPaginatedResponseContent>
    > ListInternalAsyncCore(
        string id,
        ListClientGrantOrganizationsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Auth0.ManagementApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("from", request.From.IsDefined ? request.From.Value : null)
            .Add("take", request.Take.IsDefined ? request.Take.Value : null)
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
                        "client-grants/{0}/organizations",
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
                var responseData =
                    JsonUtils.Deserialize<ListClientGrantOrganizationsPaginatedResponseContent>(
                        responseBody
                    )!;
                return new WithRawResponse<ListClientGrantOrganizationsPaginatedResponseContent>()
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

    /// <example><code>
    /// await client.ClientGrants.Organizations.ListAsync(
    ///     "id",
    ///     new ListClientGrantOrganizationsRequestParameters { From = "from", Take = 1 }
    /// );
    /// </code></example>
    public async Task<Pager<Organization>> ListAsync(
        string id,
        ListClientGrantOrganizationsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListClientGrantOrganizationsRequestParameters,
            RequestOptions?,
            ListClientGrantOrganizationsPaginatedResponseContent,
            string?,
            Organization
        >
            .CreateInstanceAsync(
                request,
                options,
                async (request, options, cancellationToken) =>
                    await ListInternalAsync(id, request, options, cancellationToken)
                        .WithRawResponse(),
                (request, cursor) =>
                {
                    request.From = cursor;
                },
                response => response.Next,
                response => response.Organizations?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }
}
