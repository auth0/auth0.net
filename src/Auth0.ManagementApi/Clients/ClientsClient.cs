using Auth0.ManagementApi.Clients;
using Auth0.ManagementApi.Core;
using global::System.Text.Json;

namespace Auth0.ManagementApi;

public partial class ClientsClient : IClientsClient
{
    private readonly RawClient _client;

    internal ClientsClient(RawClient client)
    {
        _client = client;
        Credentials = new CredentialsClient(_client);
        Connections = new Auth0.ManagementApi.Clients.ConnectionsClient(_client);
    }

    public ICredentialsClient Credentials { get; }

    public Auth0.ManagementApi.Clients.IConnectionsClient Connections { get; }

    /// <summary>
    /// Retrieve clients (applications and SSO integrations) matching provided filters. A list of fields to include or exclude may also be specified.
    /// For more information, read <see href="https://www.auth0.com/docs/get-started/applications"> Applications in Auth0</see> and <see href="https://www.auth0.com/docs/authenticate/single-sign-on"> Single Sign-On</see>.
    ///
    /// <list type="bullet">
    ///   <item><description>
    ///     The following can be retrieved with any scope:
    ///     <c>client_id</c>, <c>app_type</c>, <c>name</c>, and <c>description</c>.
    ///   </description></item>
    ///   <item><description>
    ///     The following properties can only be retrieved with the <c>read:clients</c> or
    ///     <c>read:client_keys</c> scope:
    ///     <c>callbacks</c>, <c>oidc_logout</c>, <c>allowed_origins</c>,
    ///     <c>web_origins</c>, <c>tenant</c>, <c>global</c>, <c>config_route</c>,
    ///     <c>callback_url_template</c>, <c>jwt_configuration</c>,
    ///     <c>jwt_configuration.lifetime_in_seconds</c>, <c>jwt_configuration.secret_encoded</c>,
    ///     <c>jwt_configuration.scopes</c>, <c>jwt_configuration.alg</c>, <c>api_type</c>,
    ///     <c>logo_uri</c>, <c>allowed_clients</c>, <c>owners</c>, <c>custom_login_page</c>,
    ///     <c>custom_login_page_off</c>, <c>sso</c>, <c>addons</c>, <c>form_template</c>,
    ///     <c>custom_login_page_codeview</c>, <c>resource_servers</c>, <c>client_metadata</c>,
    ///     <c>mobile</c>, <c>mobile.android</c>, <c>mobile.ios</c>, <c>allowed_logout_urls</c>,
    ///     <c>token_endpoint_auth_method</c>, <c>is_first_party</c>, <c>oidc_conformant</c>,
    ///     <c>is_token_endpoint_ip_header_trusted</c>, <c>initiate_login_uri</c>, <c>grant_types</c>,
    ///     <c>refresh_token</c>, <c>refresh_token.rotation_type</c>, <c>refresh_token.expiration_type</c>,
    ///     <c>refresh_token.leeway</c>, <c>refresh_token.token_lifetime</c>, <c>refresh_token.policies</c>, <c>organization_usage</c>,
    ///     <c>organization_require_behavior</c>.
    ///   </description></item>
    ///   <item><description>
    ///     The following properties can only be retrieved with the
    ///     <c>read:client_keys</c> or <c>read:client_credentials</c> scope:
    ///     <c>encryption_key</c>, <c>encryption_key.pub</c>, <c>encryption_key.cert</c>,
    ///     <c>client_secret</c>, <c>client_authentication_methods</c> and <c>signing_key</c>.
    ///   </description></item>
    /// </list>
    /// </summary>
    private WithRawResponseTask<ListClientsOffsetPaginatedResponseContent> ListInternalAsync(
        ListClientsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ListClientsOffsetPaginatedResponseContent>(
            ListInternalAsyncCore(request, options, cancellationToken)
        );
    }

    private async Task<
        WithRawResponse<ListClientsOffsetPaginatedResponseContent>
    > ListInternalAsyncCore(
        ListClientsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Auth0.ManagementApi.Core.QueryStringBuilder.Builder(capacity: 10)
            .Add("fields", request.Fields.IsDefined ? request.Fields.Value : null)
            .Add(
                "include_fields",
                request.IncludeFields.IsDefined ? request.IncludeFields.Value : null
            )
            .Add("page", request.Page.IsDefined ? request.Page.Value : null)
            .Add("per_page", request.PerPage.IsDefined ? request.PerPage.Value : null)
            .Add(
                "include_totals",
                request.IncludeTotals.IsDefined ? request.IncludeTotals.Value : null
            )
            .Add("is_global", request.IsGlobal.IsDefined ? request.IsGlobal.Value : null)
            .Add(
                "is_first_party",
                request.IsFirstParty.IsDefined ? request.IsFirstParty.Value : null
            )
            .Add("app_type", request.AppType.IsDefined ? request.AppType.Value : null)
            .Add(
                "external_client_id",
                request.ExternalClientId.IsDefined ? request.ExternalClientId.Value : null
            )
            .Add("q", request.Q.IsDefined ? request.Q.Value : null)
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
                    Path = "clients",
                    QueryString = _queryString,
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
                var responseData = JsonUtils.Deserialize<ListClientsOffsetPaginatedResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<ListClientsOffsetPaginatedResponseContent>()
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

    private async Task<WithRawResponse<CreateClientResponseContent>> CreateAsyncCore(
        CreateClientRequestContent request,
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
                    Path = "clients",
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
                var responseData = JsonUtils.Deserialize<CreateClientResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<CreateClientResponseContent>()
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
        WithRawResponse<PreviewCimdMetadataResponseContent>
    > PreviewCimdMetadataAsyncCore(
        PreviewCimdMetadataRequestContent request,
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
                    Path = "clients/cimd/preview",
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
                var responseData = JsonUtils.Deserialize<PreviewCimdMetadataResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<PreviewCimdMetadataResponseContent>()
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
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
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
        WithRawResponse<RegisterCimdClientResponseContent>
    > RegisterCimdClientAsyncCore(
        RegisterCimdClientRequestContent request,
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
                    Path = "clients/cimd/register",
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
                var responseData = JsonUtils.Deserialize<RegisterCimdClientResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<RegisterCimdClientResponseContent>()
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
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
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

    private async Task<WithRawResponse<GetClientResponseContent>> GetAsyncCore(
        string id,
        GetClientRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Auth0.ManagementApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("fields", request.Fields.IsDefined ? request.Fields.Value : null)
            .Add(
                "include_fields",
                request.IncludeFields.IsDefined ? request.IncludeFields.Value : null
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
                    Path = string.Format("clients/{0}", ValueConvert.ToPathParameterString(id)),
                    QueryString = _queryString,
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
                var responseData = JsonUtils.Deserialize<GetClientResponseContent>(responseBody)!;
                return new WithRawResponse<GetClientResponseContent>()
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

    private async Task<WithRawResponse<UpdateClientResponseContent>> UpdateAsyncCore(
        string id,
        UpdateClientRequestContent request,
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
                    Path = string.Format("clients/{0}", ValueConvert.ToPathParameterString(id)),
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
                var responseData = JsonUtils.Deserialize<UpdateClientResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<UpdateClientResponseContent>()
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

    private async Task<WithRawResponse<RotateClientSecretResponseContent>> RotateSecretAsyncCore(
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
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "clients/{0}/rotate-secret",
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
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<RotateClientSecretResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<RotateClientSecretResponseContent>()
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
    /// Retrieve clients (applications and SSO integrations) matching provided filters. A list of fields to include or exclude may also be specified.
    /// For more information, read <see href="https://www.auth0.com/docs/get-started/applications"> Applications in Auth0</see> and <see href="https://www.auth0.com/docs/authenticate/single-sign-on"> Single Sign-On</see>.
    ///
    /// <list type="bullet">
    ///   <item><description>
    ///     The following can be retrieved with any scope:
    ///     <c>client_id</c>, <c>app_type</c>, <c>name</c>, and <c>description</c>.
    ///   </description></item>
    ///   <item><description>
    ///     The following properties can only be retrieved with the <c>read:clients</c> or
    ///     <c>read:client_keys</c> scope:
    ///     <c>callbacks</c>, <c>oidc_logout</c>, <c>allowed_origins</c>,
    ///     <c>web_origins</c>, <c>tenant</c>, <c>global</c>, <c>config_route</c>,
    ///     <c>callback_url_template</c>, <c>jwt_configuration</c>,
    ///     <c>jwt_configuration.lifetime_in_seconds</c>, <c>jwt_configuration.secret_encoded</c>,
    ///     <c>jwt_configuration.scopes</c>, <c>jwt_configuration.alg</c>, <c>api_type</c>,
    ///     <c>logo_uri</c>, <c>allowed_clients</c>, <c>owners</c>, <c>custom_login_page</c>,
    ///     <c>custom_login_page_off</c>, <c>sso</c>, <c>addons</c>, <c>form_template</c>,
    ///     <c>custom_login_page_codeview</c>, <c>resource_servers</c>, <c>client_metadata</c>,
    ///     <c>mobile</c>, <c>mobile.android</c>, <c>mobile.ios</c>, <c>allowed_logout_urls</c>,
    ///     <c>token_endpoint_auth_method</c>, <c>is_first_party</c>, <c>oidc_conformant</c>,
    ///     <c>is_token_endpoint_ip_header_trusted</c>, <c>initiate_login_uri</c>, <c>grant_types</c>,
    ///     <c>refresh_token</c>, <c>refresh_token.rotation_type</c>, <c>refresh_token.expiration_type</c>,
    ///     <c>refresh_token.leeway</c>, <c>refresh_token.token_lifetime</c>, <c>refresh_token.policies</c>, <c>organization_usage</c>,
    ///     <c>organization_require_behavior</c>.
    ///   </description></item>
    ///   <item><description>
    ///     The following properties can only be retrieved with the
    ///     <c>read:client_keys</c> or <c>read:client_credentials</c> scope:
    ///     <c>encryption_key</c>, <c>encryption_key.pub</c>, <c>encryption_key.cert</c>,
    ///     <c>client_secret</c>, <c>client_authentication_methods</c> and <c>signing_key</c>.
    ///   </description></item>
    /// </list>
    /// </summary>
    /// <example><code>
    /// await client.Clients.ListAsync(
    ///     new ListClientsRequestParameters
    ///     {
    ///         Fields = "fields",
    ///         IncludeFields = true,
    ///         Page = 1,
    ///         PerPage = 1,
    ///         IncludeTotals = true,
    ///         IsGlobal = true,
    ///         IsFirstParty = true,
    ///         AppType = "app_type",
    ///         ExternalClientId = "external_client_id",
    ///         Q = "q",
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<Client>> ListAsync(
        ListClientsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        request = request with { };
        var pager = await OffsetPager<
            ListClientsRequestParameters,
            RequestOptions?,
            ListClientsOffsetPaginatedResponseContent,
            int?,
            int?,
            Client
        >
            .CreateInstanceAsync(
                request,
                options,
                async (request, options, cancellationToken) =>
                    await ListInternalAsync(request, options, cancellationToken).WithRawResponse(),
                request => request.Page.GetValueOrDefault(0),
                (request, offset) =>
                {
                    request.Page = offset;
                },
                null,
                response => response.Clients?.ToList(),
                null,
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Create a new client (application or SSO integration). For more information, read <see href="https://www.auth0.com/docs/get-started/auth0-overview/create-applications">Create Applications</see>
    /// <see href="https://www.auth0.com/docs/authenticate/single-sign-on/api-endpoints-for-single-sign-on>"&gt;API Endpoints for Single Sign-On</see>.
    ///
    /// Notes:
    /// - We recommend leaving the `client_secret` parameter unspecified to allow the generation of a safe secret.
    /// - The <c>client_authentication_methods</c> and <c>token_endpoint_auth_method</c> properties are mutually exclusive. Use
    /// <c>client_authentication_methods</c> to configure the client with Private Key JWT authentication method. Otherwise, use <c>token_endpoint_auth_method</c>
    /// to configure the client with client secret (basic or post) or with no authentication method (none).
    /// - When using <c>client_authentication_methods</c> to configure the client with Private Key JWT authentication method, specify fully defined credentials.
    /// These credentials will be automatically enabled for Private Key JWT authentication on the client.
    /// - To configure <c>client_authentication_methods</c>, the <c>create:client_credentials</c> scope is required.
    /// - To configure <c>client_authentication_methods</c>, the property <c>jwt_configuration.alg</c> must be set to RS256.
    ///
    /// SSO Integrations created via this endpoint will accept login requests and share user profile information.
    /// </summary>
    /// <example><code>
    /// await client.Clients.CreateAsync(new CreateClientRequestContent { Name = "name" });
    /// </code></example>
    public WithRawResponseTask<CreateClientResponseContent> CreateAsync(
        CreateClientRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CreateClientResponseContent>(
            CreateAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Fetches and validates a Client ID Metadata Document without creating a client.
    ///       Returns the raw metadata and how it would be mapped to Auth0 client fields.
    ///       This endpoint is useful for testing metadata URIs before creating CIMD clients.
    /// </summary>
    /// <example><code>
    /// await client.Clients.PreviewCimdMetadataAsync(
    ///     new PreviewCimdMetadataRequestContent { ExternalClientId = "external_client_id" }
    /// );
    /// </code></example>
    public WithRawResponseTask<PreviewCimdMetadataResponseContent> PreviewCimdMetadataAsync(
        PreviewCimdMetadataRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PreviewCimdMetadataResponseContent>(
            PreviewCimdMetadataAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Idempotent registration for Client ID Metadata Document (CIMD) clients.
    ///       Uses external_client_id as the unique identifier for upsert operations.
    ///       **Create:** Returns 201 when a new client is created (requires \
    /// </summary>
    /// <example><code>
    /// await client.Clients.RegisterCimdClientAsync(
    ///     new RegisterCimdClientRequestContent { ExternalClientId = "external_client_id" }
    /// );
    /// </code></example>
    public WithRawResponseTask<RegisterCimdClientResponseContent> RegisterCimdClientAsync(
        RegisterCimdClientRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<RegisterCimdClientResponseContent>(
            RegisterCimdClientAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve client details by ID. Clients are SSO connections or Applications linked with your Auth0 tenant. A list of fields to include or exclude may also be specified.
    /// For more information, read <see href="https://www.auth0.com/docs/get-started/applications"> Applications in Auth0</see> and <see href="https://www.auth0.com/docs/authenticate/single-sign-on"> Single Sign-On</see>.
    /// <list type="bullet">
    ///   <item><description>
    ///     The following properties can be retrieved with any of the scopes:
    ///     <c>client_id</c>, <c>app_type</c>, <c>name</c>, and <c>description</c>.
    ///   </description></item>
    ///   <item><description>
    ///     The following properties can only be retrieved with the <c>read:clients</c> or
    ///     <c>read:client_keys</c> scopes:
    ///     <c>callbacks</c>, <c>oidc_logout</c>, <c>allowed_origins</c>,
    ///     <c>web_origins</c>, <c>tenant</c>, <c>global</c>, <c>config_route</c>,
    ///     <c>callback_url_template</c>, <c>jwt_configuration</c>,
    ///     <c>jwt_configuration.lifetime_in_seconds</c>, <c>jwt_configuration.secret_encoded</c>,
    ///     <c>jwt_configuration.scopes</c>, <c>jwt_configuration.alg</c>, <c>api_type</c>,
    ///     <c>logo_uri</c>, <c>allowed_clients</c>, <c>owners</c>, <c>custom_login_page</c>,
    ///     <c>custom_login_page_off</c>, <c>sso</c>, <c>addons</c>, <c>form_template</c>,
    ///     <c>custom_login_page_codeview</c>, <c>resource_servers</c>, <c>client_metadata</c>,
    ///     <c>mobile</c>, <c>mobile.android</c>, <c>mobile.ios</c>, <c>allowed_logout_urls</c>,
    ///     <c>token_endpoint_auth_method</c>, <c>is_first_party</c>, <c>oidc_conformant</c>,
    ///     <c>is_token_endpoint_ip_header_trusted</c>, <c>initiate_login_uri</c>, <c>grant_types</c>,
    ///     <c>refresh_token</c>, <c>refresh_token.rotation_type</c>, <c>refresh_token.expiration_type</c>,
    ///     <c>refresh_token.leeway</c>, <c>refresh_token.token_lifetime</c>, <c>refresh_token.policies</c>, <c>organization_usage</c>,
    ///     <c>organization_require_behavior</c>.
    ///   </description></item>
    ///   <item><description>
    ///     The following properties can only be retrieved with the <c>read:client_keys</c> or <c>read:client_credentials</c> scopes:
    ///     <c>encryption_key</c>, <c>encryption_key.pub</c>, <c>encryption_key.cert</c>,
    ///     <c>client_secret</c>, <c>client_authentication_methods</c> and <c>signing_key</c>.
    ///   </description></item>
    /// </list>
    /// </summary>
    /// <example><code>
    /// await client.Clients.GetAsync(
    ///     "id",
    ///     new GetClientRequestParameters { Fields = "fields", IncludeFields = true }
    /// );
    /// </code></example>
    public WithRawResponseTask<GetClientResponseContent> GetAsync(
        string id,
        GetClientRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetClientResponseContent>(
            GetAsyncCore(id, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Delete a client and related configuration (rules, connections, etc).
    /// </summary>
    /// <example><code>
    /// await client.Clients.DeleteAsync("id");
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
                    Path = string.Format("clients/{0}", ValueConvert.ToPathParameterString(id)),
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
    /// Updates a client's settings. For more information, read <see href="https://www.auth0.com/docs/get-started/applications"> Applications in Auth0</see> and <see href="https://www.auth0.com/docs/authenticate/single-sign-on"> Single Sign-On</see>.
    ///
    /// Notes:
    /// - The `client_secret` and `signing_key` attributes can only be updated with the `update:client_keys` scope.
    /// - The <c>client_authentication_methods</c> and <c>token_endpoint_auth_method</c> properties are mutually exclusive. Use <c>client_authentication_methods</c> to configure the client with Private Key JWT authentication method. Otherwise, use <c>token_endpoint_auth_method</c> to configure the client with client secret (basic or post) or with no authentication method (none).
    /// - When using <c>client_authentication_methods</c> to configure the client with Private Key JWT authentication method, only specify the credential IDs that were generated when creating the credentials on the client.
    /// - To configure <c>client_authentication_methods</c>, the <c>update:client_credentials</c> scope is required.
    /// - To configure <c>client_authentication_methods</c>, the property <c>jwt_configuration.alg</c> must be set to RS256.
    /// - To change a client's <c>is_first_party</c> property to <c>false</c>, the <c>organization_usage</c> and <c>organization_require_behavior</c> properties must be unset.
    /// </summary>
    /// <example><code>
    /// await client.Clients.UpdateAsync("id", new UpdateClientRequestContent());
    /// </code></example>
    public WithRawResponseTask<UpdateClientResponseContent> UpdateAsync(
        string id,
        UpdateClientRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<UpdateClientResponseContent>(
            UpdateAsyncCore(id, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Rotate a client secret.
    ///
    /// This endpoint cannot be used with clients configured with Private Key JWT authentication method (client_authentication_methods configured with private_key_jwt). The generated secret is NOT base64 encoded.
    ///
    /// For more information, read <see href="https://www.auth0.com/docs/get-started/applications/rotate-client-secret">Rotate Client Secrets</see>.
    /// </summary>
    /// <example><code>
    /// await client.Clients.RotateSecretAsync("id");
    /// </code></example>
    public WithRawResponseTask<RotateClientSecretResponseContent> RotateSecretAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<RotateClientSecretResponseContent>(
            RotateSecretAsyncCore(id, options, cancellationToken)
        );
    }
}
