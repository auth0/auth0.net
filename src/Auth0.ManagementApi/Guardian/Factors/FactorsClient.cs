using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using Auth0.ManagementApi.Guardian.Factors;
using Auth0.ManagementApi.Guardian.Factors.Duo;
using global::System.Text.Json;

namespace Auth0.ManagementApi.Guardian;

public partial class FactorsClient : IFactorsClient
{
    private readonly RawClient _client;

    internal FactorsClient(RawClient client)
    {
        _client = client;
        Phone = new Auth0.ManagementApi.Guardian.Factors.PhoneClient(_client);
        PushNotification = new PushNotificationClient(_client);
        Sms = new SmsClient(_client);
        Duo = new DuoClient(_client);
    }

    public Auth0.ManagementApi.Guardian.Factors.IPhoneClient Phone { get; }

    public IPushNotificationClient PushNotification { get; }

    public ISmsClient Sms { get; }

    public IDuoClient Duo { get; }

    private async Task<WithRawResponse<IEnumerable<GuardianFactor>>> ListAsyncCore(
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
                    Method = HttpMethod.Get,
                    Path = "guardian/factors",
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
                var responseData = JsonUtils.Deserialize<IEnumerable<GuardianFactor>>(
                    responseBody
                )!;
                return new WithRawResponse<IEnumerable<GuardianFactor>>()
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

    private async Task<WithRawResponse<SetGuardianFactorResponseContent>> SetAsyncCore(
        GuardianFactorNameEnum name,
        SetGuardianFactorRequestContent request,
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
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "guardian/factors/{0}",
                        ValueConvert.ToPathParameterString(name)
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
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<SetGuardianFactorResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<SetGuardianFactorResponseContent>()
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
    /// Retrieve details of all <see href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors">multi-factor authentication factors</see> associated with your tenant.
    /// </summary>
    /// <example><code>
    /// await client.Guardian.Factors.ListAsync();
    /// </code></example>
    public WithRawResponseTask<IEnumerable<GuardianFactor>> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<GuardianFactor>>(
            ListAsyncCore(options, cancellationToken)
        );
    }

    /// <summary>
    /// Update the status (i.e., enabled or disabled) of a specific multi-factor authentication factor.
    /// </summary>
    /// <example><code>
    /// await client.Guardian.Factors.SetAsync(
    ///     GuardianFactorNameEnum.PushNotification,
    ///     new SetGuardianFactorRequestContent { Enabled = true }
    /// );
    /// </code></example>
    public WithRawResponseTask<SetGuardianFactorResponseContent> SetAsync(
        GuardianFactorNameEnum name,
        SetGuardianFactorRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<SetGuardianFactorResponseContent>(
            SetAsyncCore(name, request, options, cancellationToken)
        );
    }
}
