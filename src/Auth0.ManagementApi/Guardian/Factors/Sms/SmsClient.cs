using System.Text.Json;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Guardian.Factors;

public partial class SmsClient : ISmsClient
{
    private RawClient _client;

    internal SmsClient(RawClient client)
    {
        _client = client;
    }

    private async Task<
        WithRawResponse<GetGuardianFactorsProviderSmsTwilioResponseContent>
    > GetTwilioProviderAsyncCore(
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
                    Path = "guardian/factors/sms/providers/twilio",
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
                    JsonUtils.Deserialize<GetGuardianFactorsProviderSmsTwilioResponseContent>(
                        responseBody
                    )!;
                return new WithRawResponse<GetGuardianFactorsProviderSmsTwilioResponseContent>()
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
        WithRawResponse<SetGuardianFactorsProviderSmsTwilioResponseContent>
    > SetTwilioProviderAsyncCore(
        SetGuardianFactorsProviderSmsTwilioRequestContent request,
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
                    Method = HttpMethod.Put,
                    Path = "guardian/factors/sms/providers/twilio",
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
                    JsonUtils.Deserialize<SetGuardianFactorsProviderSmsTwilioResponseContent>(
                        responseBody
                    )!;
                return new WithRawResponse<SetGuardianFactorsProviderSmsTwilioResponseContent>()
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
        WithRawResponse<GetGuardianFactorsProviderSmsResponseContent>
    > GetSelectedProviderAsyncCore(
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
                    Path = "guardian/factors/sms/selected-provider",
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
                    JsonUtils.Deserialize<GetGuardianFactorsProviderSmsResponseContent>(
                        responseBody
                    )!;
                return new WithRawResponse<GetGuardianFactorsProviderSmsResponseContent>()
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
        WithRawResponse<SetGuardianFactorsProviderSmsResponseContent>
    > SetProviderAsyncCore(
        SetGuardianFactorsProviderSmsRequestContent request,
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
                    Method = HttpMethod.Put,
                    Path = "guardian/factors/sms/selected-provider",
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
                    JsonUtils.Deserialize<SetGuardianFactorsProviderSmsResponseContent>(
                        responseBody
                    )!;
                return new WithRawResponse<SetGuardianFactorsProviderSmsResponseContent>()
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
        WithRawResponse<GetGuardianFactorSmsTemplatesResponseContent>
    > GetTemplatesAsyncCore(
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
                    Path = "guardian/factors/sms/templates",
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
                    JsonUtils.Deserialize<GetGuardianFactorSmsTemplatesResponseContent>(
                        responseBody
                    )!;
                return new WithRawResponse<GetGuardianFactorSmsTemplatesResponseContent>()
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
        WithRawResponse<SetGuardianFactorSmsTemplatesResponseContent>
    > SetTemplatesAsyncCore(
        SetGuardianFactorSmsTemplatesRequestContent request,
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
                    Method = HttpMethod.Put,
                    Path = "guardian/factors/sms/templates",
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
                    JsonUtils.Deserialize<SetGuardianFactorSmsTemplatesResponseContent>(
                        responseBody
                    )!;
                return new WithRawResponse<SetGuardianFactorSmsTemplatesResponseContent>()
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
    /// Retrieve the <see href="https://auth0.com/docs/multifactor-authentication/twilio-configuration">Twilio SMS provider configuration</see> (subscription required).
    ///
    ///     A new endpoint is available to retrieve the Twilio configuration related to phone factors (<see href="https://auth0.com/docs/api/management/v2/#!/Guardian/get_twilio">phone Twilio configuration</see>). It has the same payload as this one. Please use it instead.
    /// </summary>
    /// <example><code>
    /// await client.Guardian.Factors.Sms.GetTwilioProviderAsync();
    /// </code></example>
    public WithRawResponseTask<GetGuardianFactorsProviderSmsTwilioResponseContent> GetTwilioProviderAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetGuardianFactorsProviderSmsTwilioResponseContent>(
            GetTwilioProviderAsyncCore(options, cancellationToken)
        );
    }

    /// <summary>
    /// This endpoint has been deprecated. To complete this action, use the <see href="https://auth0.com/docs/api/management/v2/guardian/put-twilio">Update Twilio phone configuration</see> endpoint.
    ///
    ///     <b>Previous functionality</b>: Update the Twilio SMS provider configuration.
    /// </summary>
    /// <example><code>
    /// await client.Guardian.Factors.Sms.SetTwilioProviderAsync(
    ///     new SetGuardianFactorsProviderSmsTwilioRequestContent()
    /// );
    /// </code></example>
    public WithRawResponseTask<SetGuardianFactorsProviderSmsTwilioResponseContent> SetTwilioProviderAsync(
        SetGuardianFactorsProviderSmsTwilioRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<SetGuardianFactorsProviderSmsTwilioResponseContent>(
            SetTwilioProviderAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This endpoint has been deprecated. To complete this action, use the <see href="https://auth0.com/docs/api/management/v2/guardian/get-phone-providers">Retrieve phone configuration</see> endpoint instead.
    ///
    ///     <b>Previous functionality</b>: Retrieve details for the multi-factor authentication SMS provider configured for your tenant.
    /// </summary>
    /// <example><code>
    /// await client.Guardian.Factors.Sms.GetSelectedProviderAsync();
    /// </code></example>
    public WithRawResponseTask<GetGuardianFactorsProviderSmsResponseContent> GetSelectedProviderAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetGuardianFactorsProviderSmsResponseContent>(
            GetSelectedProviderAsyncCore(options, cancellationToken)
        );
    }

    /// <summary>
    /// This endpoint has been deprecated. To complete this action, use the <see href="https://auth0.com/docs/api/management/v2/guardian/put-phone-providers">Update phone configuration</see> endpoint instead.
    ///
    ///     <b>Previous functionality</b>: Update the multi-factor authentication SMS provider configuration in your tenant.
    /// </summary>
    /// <example><code>
    /// await client.Guardian.Factors.Sms.SetProviderAsync(
    ///     new SetGuardianFactorsProviderSmsRequestContent
    ///     {
    ///         Provider = GuardianFactorsProviderSmsProviderEnum.Auth0,
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<SetGuardianFactorsProviderSmsResponseContent> SetProviderAsync(
        SetGuardianFactorsProviderSmsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<SetGuardianFactorsProviderSmsResponseContent>(
            SetProviderAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This endpoint has been deprecated. To complete this action, use the <see href="https://auth0.com/docs/api/management/v2/guardian/get-factor-phone-templates">Retrieve enrollment and verification phone templates</see> endpoint instead.
    ///
    ///     <b>Previous function</b>: Retrieve details of SMS enrollment and verification templates configured for your tenant.
    /// </summary>
    /// <example><code>
    /// await client.Guardian.Factors.Sms.GetTemplatesAsync();
    /// </code></example>
    public WithRawResponseTask<GetGuardianFactorSmsTemplatesResponseContent> GetTemplatesAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetGuardianFactorSmsTemplatesResponseContent>(
            GetTemplatesAsyncCore(options, cancellationToken)
        );
    }

    /// <summary>
    /// This endpoint has been deprecated. To complete this action, use the <see href="https://auth0.com/docs/api/management/v2/guardian/put-factor-phone-templates">Update enrollment and verification phone templates</see> endpoint instead.
    ///
    ///     <b>Previous functionality</b>: Customize the messages sent to complete SMS enrollment and verification.
    /// </summary>
    /// <example><code>
    /// await client.Guardian.Factors.Sms.SetTemplatesAsync(
    ///     new SetGuardianFactorSmsTemplatesRequestContent
    ///     {
    ///         EnrollmentMessage = "enrollment_message",
    ///         VerificationMessage = "verification_message",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<SetGuardianFactorSmsTemplatesResponseContent> SetTemplatesAsync(
        SetGuardianFactorSmsTemplatesRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<SetGuardianFactorSmsTemplatesResponseContent>(
            SetTemplatesAsyncCore(request, options, cancellationToken)
        );
    }
}
