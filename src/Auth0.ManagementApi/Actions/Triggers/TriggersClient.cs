using System.Text.Json;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Actions.Triggers;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Actions;

public partial class TriggersClient : ITriggersClient
{
    private RawClient _client;

    internal TriggersClient(RawClient client)
    {
        _client = client;
        Bindings = new BindingsClient(_client);
    }

    public IBindingsClient Bindings { get; }

    private async Task<WithRawResponse<ListActionTriggersResponseContent>> ListAsyncCore(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
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
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "actions/triggers",
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData = JsonUtils.Deserialize<ListActionTriggersResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<ListActionTriggersResponseContent>()
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
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
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

    /// <summary>
    /// Retrieve the set of triggers currently available within actions. A trigger is an extensibility point to which actions can be bound.
    /// </summary>
    /// <example><code>
    /// await client.Actions.Triggers.ListAsync();
    /// </code></example>
    public WithRawResponseTask<ListActionTriggersResponseContent> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ListActionTriggersResponseContent>(
            ListAsyncCore(options, cancellationToken)
        );
    }
}
