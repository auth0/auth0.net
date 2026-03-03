using System.Text.Json;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.AttackProtection;

public partial class BreachedPasswordDetectionClient : IBreachedPasswordDetectionClient
{
    private RawClient _client;

    internal BreachedPasswordDetectionClient(RawClient client)
    {
        _client = client;
    }

    private async Task<
        WithRawResponse<GetBreachedPasswordDetectionSettingsResponseContent>
    > GetAsyncCore(RequestOptions? options = null, CancellationToken cancellationToken = default)
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
                    Method = HttpMethod.Get,
                    Path = "attack-protection/breached-password-detection",
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
                var responseData =
                    JsonUtils.Deserialize<GetBreachedPasswordDetectionSettingsResponseContent>(
                        responseBody
                    )!;
                return new WithRawResponse<GetBreachedPasswordDetectionSettingsResponseContent>()
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

    private async Task<
        WithRawResponse<UpdateBreachedPasswordDetectionSettingsResponseContent>
    > UpdateAsyncCore(
        UpdateBreachedPasswordDetectionSettingsRequestContent request,
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
                    Method = HttpMethodExtensions.Patch,
                    Path = "attack-protection/breached-password-detection",
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
                    JsonUtils.Deserialize<UpdateBreachedPasswordDetectionSettingsResponseContent>(
                        responseBody
                    )!;
                return new WithRawResponse<UpdateBreachedPasswordDetectionSettingsResponseContent>()
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
    /// Retrieve details of the Breached Password Detection configuration of your tenant.
    /// </summary>
    /// <example><code>
    /// await client.AttackProtection.BreachedPasswordDetection.GetAsync();
    /// </code></example>
    public WithRawResponseTask<GetBreachedPasswordDetectionSettingsResponseContent> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetBreachedPasswordDetectionSettingsResponseContent>(
            GetAsyncCore(options, cancellationToken)
        );
    }

    /// <summary>
    /// Update details of the Breached Password Detection configuration of your tenant.
    /// </summary>
    /// <example><code>
    /// await client.AttackProtection.BreachedPasswordDetection.UpdateAsync(
    ///     new UpdateBreachedPasswordDetectionSettingsRequestContent()
    /// );
    /// </code></example>
    public WithRawResponseTask<UpdateBreachedPasswordDetectionSettingsResponseContent> UpdateAsync(
        UpdateBreachedPasswordDetectionSettingsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<UpdateBreachedPasswordDetectionSettingsResponseContent>(
            UpdateAsyncCore(request, options, cancellationToken)
        );
    }
}
