using System.Text.Json;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.SelfServiceProfiles;

public partial class CustomTextClient : ICustomTextClient
{
    private readonly RawClient _client;

    internal CustomTextClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<Dictionary<string, string>>> ListAsyncCore(
        string id,
        SelfServiceProfileCustomTextLanguageEnum language,
        SelfServiceProfileCustomTextPageEnum page,
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
                    Path = string.Format(
                        "self-service-profiles/{0}/custom-text/{1}/{2}",
                        ValueConvert.ToPathParameterString(id),
                        ValueConvert.ToPathParameterString(language),
                        ValueConvert.ToPathParameterString(page)
                    ),
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
                var responseData = JsonUtils.Deserialize<Dictionary<string, string>>(responseBody)!;
                return new WithRawResponse<Dictionary<string, string>>()
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

    private async Task<WithRawResponse<Dictionary<string, string>>> SetAsyncCore(
        string id,
        SelfServiceProfileCustomTextLanguageEnum language,
        SelfServiceProfileCustomTextPageEnum page,
        Dictionary<string, string> request,
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
                        "self-service-profiles/{0}/custom-text/{1}/{2}",
                        ValueConvert.ToPathParameterString(id),
                        ValueConvert.ToPathParameterString(language),
                        ValueConvert.ToPathParameterString(page)
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
                var responseData = JsonUtils.Deserialize<Dictionary<string, string>>(responseBody)!;
                return new WithRawResponse<Dictionary<string, string>>()
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
    /// Retrieves text customizations for a given self-service profile, language and Self Service SSO Flow page.
    /// </summary>
    /// <example><code>
    /// await client.SelfServiceProfiles.CustomText.ListAsync(
    ///     "id",
    ///     SelfServiceProfileCustomTextLanguageEnum.En,
    ///     SelfServiceProfileCustomTextPageEnum.GetStarted
    /// );
    /// </code></example>
    public WithRawResponseTask<Dictionary<string, string>> ListAsync(
        string id,
        SelfServiceProfileCustomTextLanguageEnum language,
        SelfServiceProfileCustomTextPageEnum page,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, string>>(
            ListAsyncCore(id, language, page, options, cancellationToken)
        );
    }

    /// <summary>
    /// Updates text customizations for a given self-service profile, language and Self Service SSO Flow page.
    /// </summary>
    /// <example><code>
    /// await client.SelfServiceProfiles.CustomText.SetAsync(
    ///     "id",
    ///     SelfServiceProfileCustomTextLanguageEnum.En,
    ///     SelfServiceProfileCustomTextPageEnum.GetStarted,
    ///     new Dictionary&lt;string, string&gt;() { { "key", "value" } }
    /// );
    /// </code></example>
    public WithRawResponseTask<Dictionary<string, string>> SetAsync(
        string id,
        SelfServiceProfileCustomTextLanguageEnum language,
        SelfServiceProfileCustomTextPageEnum page,
        Dictionary<string, string> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, string>>(
            SetAsyncCore(id, language, page, request, options, cancellationToken)
        );
    }
}
