using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json;

namespace Auth0.ManagementApi.Guardian;

public partial class PoliciesClient : IPoliciesClient
{
    private readonly RawClient _client;

    internal PoliciesClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<IEnumerable<MfaPolicyEnum>>> ListAsyncCore(
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
                    Path = "guardian/policies",
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
                var responseData = JsonUtils.Deserialize<IEnumerable<MfaPolicyEnum>>(responseBody)!;
                return new WithRawResponse<IEnumerable<MfaPolicyEnum>>()
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

    private async Task<WithRawResponse<IEnumerable<MfaPolicyEnum>>> SetAsyncCore(
        IEnumerable<MfaPolicyEnum> request,
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
                    Path = "guardian/policies",
                    Body = request,
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
                var responseData = JsonUtils.Deserialize<IEnumerable<MfaPolicyEnum>>(responseBody)!;
                return new WithRawResponse<IEnumerable<MfaPolicyEnum>>()
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
    /// Retrieve the [multi-factor authentication (MFA) policies](https://auth0.com/docs/secure/multi-factor-authentication/enable-mfa) configured for your tenant.
    ///
    /// The following policies are supported:
    ///
    /// - `all-applications` policy prompts with MFA for all logins.
    /// - `confidence-score` policy prompts with MFA only for low confidence logins.
    ///
    /// **Note**: The `confidence-score` policy is part of the [Adaptive MFA feature](https://auth0.com/docs/secure/multi-factor-authentication/adaptive-mfa). Adaptive MFA requires an add-on for the Enterprise plan; review [Auth0 Pricing](https://auth0.com/pricing) for more details.
    /// </summary>
    /// <example><code>
    /// await client.Guardian.Policies.ListAsync();
    /// </code></example>
    public WithRawResponseTask<IEnumerable<MfaPolicyEnum>> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<MfaPolicyEnum>>(
            ListAsyncCore(options, cancellationToken)
        );
    }

    /// <summary>
    /// Set [multi-factor authentication (MFA) policies](https://auth0.com/docs/secure/multi-factor-authentication/enable-mfa) for your tenant.
    ///
    /// The following policies are supported:
    ///
    /// - `all-applications` policy prompts with MFA for all logins.
    /// - `confidence-score` policy prompts with MFA only for low confidence logins.
    ///
    /// **Note**: The `confidence-score` policy is part of the [Adaptive MFA feature](https://auth0.com/docs/secure/multi-factor-authentication/adaptive-mfa). Adaptive MFA requires an add-on for the Enterprise plan; review [Auth0 Pricing](https://auth0.com/pricing) for more details.
    /// </summary>
    /// <example><code>
    /// await client.Guardian.Policies.SetAsync(
    ///     new List&lt;MfaPolicyEnum&gt;() { MfaPolicyEnum.AllApplications }
    /// );
    /// </code></example>
    public WithRawResponseTask<IEnumerable<MfaPolicyEnum>> SetAsync(
        IEnumerable<MfaPolicyEnum> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<MfaPolicyEnum>>(
            SetAsyncCore(request, options, cancellationToken)
        );
    }
}
