using System.Text.Json;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Users;

public partial class AuthenticationMethodsClient : IAuthenticationMethodsClient
{
    private RawClient _client;

    internal AuthenticationMethodsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Retrieve detailed list of authentication methods associated with a specified user.
    /// </summary>
    private WithRawResponseTask<ListUserAuthenticationMethodsOffsetPaginatedResponseContent> ListInternalAsync(
        string id,
        ListUserAuthenticationMethodsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ListUserAuthenticationMethodsOffsetPaginatedResponseContent>(
            ListInternalAsyncCore(id, request, options, cancellationToken)
        );
    }

    private async Task<
        WithRawResponse<ListUserAuthenticationMethodsOffsetPaginatedResponseContent>
    > ListInternalAsyncCore(
        string id,
        ListUserAuthenticationMethodsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Auth0.ManagementApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("page", request.Page.IsDefined ? request.Page.Value : null)
            .Add("per_page", request.PerPage.IsDefined ? request.PerPage.Value : null)
            .Add(
                "include_totals",
                request.IncludeTotals.IsDefined ? request.IncludeTotals.Value : null
            )
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
                        "users/{0}/authentication-methods",
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
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData =
                    JsonUtils.Deserialize<ListUserAuthenticationMethodsOffsetPaginatedResponseContent>(
                        responseBody
                    )!;
                return new WithRawResponse<ListUserAuthenticationMethodsOffsetPaginatedResponseContent>()
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

    private async Task<
        WithRawResponse<CreateUserAuthenticationMethodResponseContent>
    > CreateAsyncCore(
        string id,
        CreateUserAuthenticationMethodRequestContent request,
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
                    Path = string.Format(
                        "users/{0}/authentication-methods",
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
                    JsonUtils.Deserialize<CreateUserAuthenticationMethodResponseContent>(
                        responseBody
                    )!;
                return new WithRawResponse<CreateUserAuthenticationMethodResponseContent>()
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
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
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

    private async Task<
        WithRawResponse<IEnumerable<SetUserAuthenticationMethodResponseContent>>
    > SetAsyncCore(
        string id,
        IEnumerable<SetUserAuthenticationMethods> request,
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
                        "users/{0}/authentication-methods",
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
                var responseData = JsonUtils.Deserialize<
                    IEnumerable<SetUserAuthenticationMethodResponseContent>
                >(responseBody)!;
                return new WithRawResponse<
                    IEnumerable<SetUserAuthenticationMethodResponseContent>
                >()
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

    private async Task<WithRawResponse<GetUserAuthenticationMethodResponseContent>> GetAsyncCore(
        string id,
        string authenticationMethodId,
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
                        "users/{0}/authentication-methods/{1}",
                        ValueConvert.ToPathParameterString(id),
                        ValueConvert.ToPathParameterString(authenticationMethodId)
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
                var responseData =
                    JsonUtils.Deserialize<GetUserAuthenticationMethodResponseContent>(
                        responseBody
                    )!;
                return new WithRawResponse<GetUserAuthenticationMethodResponseContent>()
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

    private async Task<
        WithRawResponse<UpdateUserAuthenticationMethodResponseContent>
    > UpdateAsyncCore(
        string id,
        string authenticationMethodId,
        UpdateUserAuthenticationMethodRequestContent request,
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
                        "users/{0}/authentication-methods/{1}",
                        ValueConvert.ToPathParameterString(id),
                        ValueConvert.ToPathParameterString(authenticationMethodId)
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
                    JsonUtils.Deserialize<UpdateUserAuthenticationMethodResponseContent>(
                        responseBody
                    )!;
                return new WithRawResponse<UpdateUserAuthenticationMethodResponseContent>()
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
    /// Retrieve detailed list of authentication methods associated with a specified user.
    /// </summary>
    /// <example><code>
    /// await client.Users.AuthenticationMethods.ListAsync(
    ///     "id",
    ///     new ListUserAuthenticationMethodsRequestParameters
    ///     {
    ///         Page = 1,
    ///         PerPage = 1,
    ///         IncludeTotals = true,
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<UserAuthenticationMethod>> ListAsync(
        string id,
        ListUserAuthenticationMethodsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        request = request with { };
        var pager = await OffsetPager<
            ListUserAuthenticationMethodsRequestParameters,
            RequestOptions?,
            ListUserAuthenticationMethodsOffsetPaginatedResponseContent,
            int?,
            int?,
            UserAuthenticationMethod
        >
            .CreateInstanceAsync(
                request,
                options,
                async (request, options, cancellationToken) =>
                    await ListInternalAsync(id, request, options, cancellationToken)
                        .ConfigureAwait(false),
                request => request.Page.GetValueOrDefault(0),
                (request, offset) =>
                {
                    request.Page = offset;
                },
                request => request.PerPage.GetValueOrDefault(0),
                response => response.Authenticators?.ToList(),
                null,
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Create an authentication method. Authentication methods created via this endpoint will be auto confirmed and should already have verification completed.
    /// </summary>
    /// <example><code>
    /// await client.Users.AuthenticationMethods.CreateAsync(
    ///     "id",
    ///     new CreateUserAuthenticationMethodRequestContent
    ///     {
    ///         Type = CreatedUserAuthenticationMethodTypeEnum.Phone,
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CreateUserAuthenticationMethodResponseContent> CreateAsync(
        string id,
        CreateUserAuthenticationMethodRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CreateUserAuthenticationMethodResponseContent>(
            CreateAsyncCore(id, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Replace the specified user <see href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors"> authentication methods</see> with supplied values.
    ///
    ///     <b>Note</b>: Authentication methods supplied through this action do not iterate on existing methods. Instead, any methods passed will overwrite the user&#8217s existing settings.
    /// </summary>
    /// <example><code>
    /// await client.Users.AuthenticationMethods.SetAsync(
    ///     "id",
    ///     new List&lt;SetUserAuthenticationMethods&gt;()
    ///     {
    ///         new SetUserAuthenticationMethods { Type = AuthenticationTypeEnum.Phone },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<IEnumerable<SetUserAuthenticationMethodResponseContent>> SetAsync(
        string id,
        IEnumerable<SetUserAuthenticationMethods> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<SetUserAuthenticationMethodResponseContent>>(
            SetAsyncCore(id, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Remove all authentication methods (i.e., enrolled MFA factors) from the specified user account. This action cannot be undone.
    /// </summary>
    /// <example><code>
    /// await client.Users.AuthenticationMethods.DeleteAllAsync("id");
    /// </code></example>
    public async Task DeleteAllAsync(
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
                        "users/{0}/authentication-methods",
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
    /// await client.Users.AuthenticationMethods.GetAsync("id", "authentication_method_id");
    /// </code></example>
    public WithRawResponseTask<GetUserAuthenticationMethodResponseContent> GetAsync(
        string id,
        string authenticationMethodId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetUserAuthenticationMethodResponseContent>(
            GetAsyncCore(id, authenticationMethodId, options, cancellationToken)
        );
    }

    /// <summary>
    /// Remove the authentication method with the given ID from the specified user. For more information, review <see href="https://auth0.com/docs/secure/multi-factor-authentication/manage-mfa-auth0-apis/manage-authentication-methods-with-management-api">Manage Authentication Methods with Management API</see>.
    /// </summary>
    /// <example><code>
    /// await client.Users.AuthenticationMethods.DeleteAsync("id", "authentication_method_id");
    /// </code></example>
    public async Task DeleteAsync(
        string id,
        string authenticationMethodId,
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
                        "users/{0}/authentication-methods/{1}",
                        ValueConvert.ToPathParameterString(id),
                        ValueConvert.ToPathParameterString(authenticationMethodId)
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
    /// Modify the authentication method with the given ID from the specified user. For more information, review <see href="https://auth0.com/docs/secure/multi-factor-authentication/manage-mfa-auth0-apis/manage-authentication-methods-with-management-api">Manage Authentication Methods with Management API</see>.
    /// </summary>
    /// <example><code>
    /// await client.Users.AuthenticationMethods.UpdateAsync(
    ///     "id",
    ///     "authentication_method_id",
    ///     new UpdateUserAuthenticationMethodRequestContent()
    /// );
    /// </code></example>
    public WithRawResponseTask<UpdateUserAuthenticationMethodResponseContent> UpdateAsync(
        string id,
        string authenticationMethodId,
        UpdateUserAuthenticationMethodRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<UpdateUserAuthenticationMethodResponseContent>(
            UpdateAsyncCore(id, authenticationMethodId, request, options, cancellationToken)
        );
    }
}
