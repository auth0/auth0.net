using System.Text.Json;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Guardian;

public partial class PoliciesClient : IPoliciesClient
{
    private RawClient _client;

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
                    BaseUrl = _client.Options.BaseUrl,
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
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
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
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Put,
                    Path = "guardian/policies",
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
    /// Retrieve the <see href="https://auth0.com/docs/secure/multi-factor-authentication/enable-mfa">multi-factor authentication (MFA) policies</see> configured for your tenant.
    ///
    /// The following policies are supported:
    /// <list type="bullet">
    /// <item><description><c>all-applications</c> policy prompts with MFA for all logins.</description></item>
    /// <item><description><c>confidence-score</c> policy prompts with MFA only for low confidence logins.</description></item>
    /// </list>
    ///
    /// <b>Note</b>: The <c>confidence-score</c> policy is part of the <see href="https://auth0.com/docs/secure/multi-factor-authentication/adaptive-mfa">Adaptive MFA feature</see>. Adaptive MFA requires an add-on for the Enterprise plan; review <see href="https://auth0.com/pricing">Auth0 Pricing</see> for more details.
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
    /// Set <see href="https://auth0.com/docs/secure/multi-factor-authentication/enable-mfa">multi-factor authentication (MFA) policies</see> for your tenant.
    ///
    /// The following policies are supported:
    /// <list type="bullet">
    /// <item><description><c>all-applications</c> policy prompts with MFA for all logins.</description></item>
    /// <item><description><c>confidence-score</c> policy prompts with MFA only for low confidence logins.</description></item>
    /// </list>
    ///
    /// <b>Note</b>: The <c>confidence-score</c> policy is part of the <see href="https://auth0.com/docs/secure/multi-factor-authentication/adaptive-mfa">Adaptive MFA feature</see>. Adaptive MFA requires an add-on for the Enterprise plan; review <see href="https://auth0.com/pricing">Auth0 Pricing</see> for more details.
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
