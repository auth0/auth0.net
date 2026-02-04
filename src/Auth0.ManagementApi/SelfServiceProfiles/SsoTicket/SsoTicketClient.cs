using System.Text.Json;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.SelfServiceProfiles;

public partial class SsoTicketClient : ISsoTicketClient
{
    private RawClient _client;

    internal SsoTicketClient(RawClient client)
    {
        _client = client;
    }

    private async Task<
        WithRawResponse<CreateSelfServiceProfileSsoTicketResponseContent>
    > CreateAsyncCore(
        string id,
        CreateSelfServiceProfileSsoTicketRequestContent request,
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
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "self-service-profiles/{0}/sso-ticket",
                        ValueConvert.ToPathParameterString(id)
                    ),
                    Body = request,
                    Headers = _headers,
                    ContentType = "application/json",
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
                var responseData =
                    JsonUtils.Deserialize<CreateSelfServiceProfileSsoTicketResponseContent>(
                        responseBody
                    )!;
                return new WithRawResponse<CreateSelfServiceProfileSsoTicketResponseContent>()
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
                    responseBody,
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
    /// Creates an SSO access ticket to initiate the Self Service SSO Flow using a self-service profile.
    /// </summary>
    /// <example><code>
    /// await client.SelfServiceProfiles.SsoTicket.CreateAsync(
    ///     "id",
    ///     new CreateSelfServiceProfileSsoTicketRequestContent()
    /// );
    /// </code></example>
    public WithRawResponseTask<CreateSelfServiceProfileSsoTicketResponseContent> CreateAsync(
        string id,
        CreateSelfServiceProfileSsoTicketRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CreateSelfServiceProfileSsoTicketResponseContent>(
            CreateAsyncCore(id, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Revokes an SSO access ticket and invalidates associated sessions. The ticket will no longer be accepted to initiate a Self-Service SSO session. If any users have already started a session through this ticket, their session will be terminated. Clients should expect a `202 Accepted` response upon successful processing, indicating that the request has been acknowledged and that the revocation is underway but may not be fully completed at the time of response. If the specified ticket does not exist, a `202 Accepted` response is also returned, signaling that no further action is required.
    /// Clients should treat these `202` responses as an acknowledgment that the request has been accepted and is in progress, even if the ticket was not found.
    /// </summary>
    /// <example><code>
    /// await client.SelfServiceProfiles.SsoTicket.RevokeAsync("profileId", "id");
    /// </code></example>
    public async Task RevokeAsync(
        string profileId,
        string id,
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
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "self-service-profiles/{0}/sso-ticket/{1}/revoke",
                        ValueConvert.ToPathParameterString(profileId),
                        ValueConvert.ToPathParameterString(id)
                    ),
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            return;
        }
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
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
}
