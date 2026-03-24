using System.Text.Json;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

public partial class TokenExchangeProfilesClient : ITokenExchangeProfilesClient
{
    private RawClient _client;

    internal TokenExchangeProfilesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Retrieve a list of all Token Exchange Profiles available in your tenant.
    ///
    /// By using this feature, you agree to the applicable Free Trial terms in <see href="https://www.okta.com/legal/">Okta’s Master Subscription Agreement</see>. It is your responsibility to securely validate the user’s subject_token. See <see href="https://auth0.com/docs/authenticate/custom-token-exchange">User Guide</see> for more details.
    ///
    /// This endpoint supports Checkpoint pagination. To search by checkpoint, use the following parameters:
    /// <list type="bullet">
    /// <item><description><c>from</c>: Optional id from which to start selection.</description></item>
    /// <item><description><c>take</c>: The total amount of entries to retrieve when using the from parameter. Defaults to 50.</description></item>
    /// </list>
    ///
    /// <b>Note</b>: The first time you call this endpoint using checkpoint pagination, omit the <c>from</c> parameter. If there are more results, a <c>next</c> value is included in the response. You can use this for subsequent API calls. When <c>next</c> is no longer included in the response, no pages are remaining.
    /// </summary>
    private WithRawResponseTask<ListTokenExchangeProfileResponseContent> ListInternalAsync(
        TokenExchangeProfilesListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ListTokenExchangeProfileResponseContent>(
            ListInternalAsyncCore(request, options, cancellationToken)
        );
    }

    private async Task<
        WithRawResponse<ListTokenExchangeProfileResponseContent>
    > ListInternalAsyncCore(
        TokenExchangeProfilesListRequest request,
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
                    Path = "token-exchange-profiles",
                    QueryString = _queryString,
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
                var responseData = JsonUtils.Deserialize<ListTokenExchangeProfileResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<ListTokenExchangeProfileResponseContent>()
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

    private async Task<WithRawResponse<CreateTokenExchangeProfileResponseContent>> CreateAsyncCore(
        CreateTokenExchangeProfileRequestContent request,
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
                    Method = HttpMethod.Post,
                    Path = "token-exchange-profiles",
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
                var responseData = JsonUtils.Deserialize<CreateTokenExchangeProfileResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<CreateTokenExchangeProfileResponseContent>()
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
                    case 409:
                        throw new ConflictError(JsonUtils.Deserialize<object>(responseBody));
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

    private async Task<WithRawResponse<GetTokenExchangeProfileResponseContent>> GetAsyncCore(
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
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "token-exchange-profiles/{0}",
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
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData = JsonUtils.Deserialize<GetTokenExchangeProfileResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<GetTokenExchangeProfileResponseContent>()
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
    /// Retrieve a list of all Token Exchange Profiles available in your tenant.
    ///
    /// By using this feature, you agree to the applicable Free Trial terms in <see href="https://www.okta.com/legal/">Okta’s Master Subscription Agreement</see>. It is your responsibility to securely validate the user’s subject_token. See <see href="https://auth0.com/docs/authenticate/custom-token-exchange">User Guide</see> for more details.
    ///
    /// This endpoint supports Checkpoint pagination. To search by checkpoint, use the following parameters:
    /// <list type="bullet">
    /// <item><description><c>from</c>: Optional id from which to start selection.</description></item>
    /// <item><description><c>take</c>: The total amount of entries to retrieve when using the from parameter. Defaults to 50.</description></item>
    /// </list>
    ///
    /// <b>Note</b>: The first time you call this endpoint using checkpoint pagination, omit the <c>from</c> parameter. If there are more results, a <c>next</c> value is included in the response. You can use this for subsequent API calls. When <c>next</c> is no longer included in the response, no pages are remaining.
    /// </summary>
    /// <example><code>
    /// await client.TokenExchangeProfiles.ListAsync(
    ///     new TokenExchangeProfilesListRequest { From = "from", Take = 1 }
    /// );
    /// </code></example>
    public async Task<Pager<TokenExchangeProfileResponseContent>> ListAsync(
        TokenExchangeProfilesListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            TokenExchangeProfilesListRequest,
            RequestOptions?,
            ListTokenExchangeProfileResponseContent,
            string?,
            TokenExchangeProfileResponseContent
        >
            .CreateInstanceAsync(
                request,
                options,
                async (request, options, cancellationToken) =>
                    await ListInternalAsync(request, options, cancellationToken),
                (request, cursor) =>
                {
                    request.From = cursor;
                },
                response => response.Next,
                response => response.TokenExchangeProfiles?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Create a new Token Exchange Profile within your tenant.
    ///
    /// By using this feature, you agree to the applicable Free Trial terms in <see href="https://www.okta.com/legal/">Okta’s Master Subscription Agreement</see>. It is your responsibility to securely validate the user’s subject_token. See <see href="https://auth0.com/docs/authenticate/custom-token-exchange">User Guide</see> for more details.
    /// </summary>
    /// <example><code>
    /// await client.TokenExchangeProfiles.CreateAsync(
    ///     new CreateTokenExchangeProfileRequestContent
    ///     {
    ///         Name = "name",
    ///         SubjectTokenType = "subject_token_type",
    ///         ActionId = "action_id",
    ///         Type = TokenExchangeProfileTypeEnum.CustomAuthentication,
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CreateTokenExchangeProfileResponseContent> CreateAsync(
        CreateTokenExchangeProfileRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CreateTokenExchangeProfileResponseContent>(
            CreateAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve details about a single Token Exchange Profile specified by ID.
    ///
    /// By using this feature, you agree to the applicable Free Trial terms in <see href="https://www.okta.com/legal/">Okta’s Master Subscription Agreement</see>. It is your responsibility to securely validate the user’s subject_token. See <see href="https://auth0.com/docs/authenticate/custom-token-exchange">User Guide</see> for more details.
    /// </summary>
    /// <example><code>
    /// await client.TokenExchangeProfiles.GetAsync("id");
    /// </code></example>
    public WithRawResponseTask<GetTokenExchangeProfileResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetTokenExchangeProfileResponseContent>(
            GetAsyncCore(id, options, cancellationToken)
        );
    }

    /// <summary>
    /// Delete a Token Exchange Profile within your tenant.
    ///
    /// By using this feature, you agree to the applicable Free Trial terms in <see href="https://www.okta.com/legal/">Okta's Master Subscription Agreement</see>. It is your responsibility to securely validate the user's subject_token. See <see href="https://auth0.com/docs/authenticate/custom-token-exchange">User Guide</see> for more details.
    /// </summary>
    /// <example><code>
    /// await client.TokenExchangeProfiles.DeleteAsync("id");
    /// </code></example>
    public async Task DeleteAsync(
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
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "token-exchange-profiles/{0}",
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

    /// <summary>
    /// Update a Token Exchange Profile within your tenant.
    ///
    /// By using this feature, you agree to the applicable Free Trial terms in <see href="https://www.okta.com/legal/">Okta's Master Subscription Agreement</see>. It is your responsibility to securely validate the user's subject_token. See <see href="https://auth0.com/docs/authenticate/custom-token-exchange">User Guide</see> for more details.
    /// </summary>
    /// <example><code>
    /// await client.TokenExchangeProfiles.UpdateAsync(
    ///     "id",
    ///     new UpdateTokenExchangeProfileRequestContent()
    /// );
    /// </code></example>
    public async Task UpdateAsync(
        string id,
        UpdateTokenExchangeProfileRequestContent request,
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
                    Path = string.Format(
                        "token-exchange-profiles/{0}",
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
            return;
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
}
