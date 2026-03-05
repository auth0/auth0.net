using System.Text.Json;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Clients;

public partial class CredentialsClient : ICredentialsClient
{
    private readonly RawClient _client;

    internal CredentialsClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<IEnumerable<ClientCredential>>> ListAsyncCore(
        string clientId,
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
                        "clients/{0}/credentials",
                        ValueConvert.ToPathParameterString(clientId)
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
                var responseData = JsonUtils.Deserialize<IEnumerable<ClientCredential>>(
                    responseBody
                )!;
                return new WithRawResponse<IEnumerable<ClientCredential>>()
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

    private async Task<WithRawResponse<PostClientCredentialResponseContent>> CreateAsyncCore(
        string clientId,
        PostClientCredentialRequestContent request,
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
                        "clients/{0}/credentials",
                        ValueConvert.ToPathParameterString(clientId)
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
                var responseData = JsonUtils.Deserialize<PostClientCredentialResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<PostClientCredentialResponseContent>()
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

    private async Task<WithRawResponse<GetClientCredentialResponseContent>> GetAsyncCore(
        string clientId,
        string credentialId,
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
                        "clients/{0}/credentials/{1}",
                        ValueConvert.ToPathParameterString(clientId),
                        ValueConvert.ToPathParameterString(credentialId)
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
                var responseData = JsonUtils.Deserialize<GetClientCredentialResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<GetClientCredentialResponseContent>()
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

    private async Task<WithRawResponse<PatchClientCredentialResponseContent>> UpdateAsyncCore(
        string clientId,
        string credentialId,
        PatchClientCredentialRequestContent request,
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
                        "clients/{0}/credentials/{1}",
                        ValueConvert.ToPathParameterString(clientId),
                        ValueConvert.ToPathParameterString(credentialId)
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
                var responseData = JsonUtils.Deserialize<PatchClientCredentialResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<PatchClientCredentialResponseContent>()
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
    /// Get the details of a client credential.
    ///
    /// <b>Important</b>: To enable credentials to be used for a client authentication method, set the <c>client_authentication_methods</c> property on the client. To enable credentials to be used for JWT-Secured Authorization requests set the <c>signed_request_object</c> property on the client.
    /// </summary>
    /// <example><code>
    /// await client.Clients.Credentials.ListAsync("client_id");
    /// </code></example>
    public WithRawResponseTask<IEnumerable<ClientCredential>> ListAsync(
        string clientId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<ClientCredential>>(
            ListAsyncCore(clientId, options, cancellationToken)
        );
    }

    /// <summary>
    /// Create a client credential associated to your application. Credentials can be used to configure Private Key JWT and mTLS authentication methods, as well as for JWT-secured Authorization requests.
    ///
    /// <para>Public Key</para>Public Key credentials can be used to set up Private Key JWT client authentication and JWT-secured Authorization requests.
    ///
    /// Sample: <code>{
    ///   "credential_type": "public_key",
    ///   "name": "string",
    ///   "pem": "string",
    ///   "alg": "RS256",
    ///   "parse_expiry_from_cert": false,
    ///   "expires_at": "2022-12-31T23:59:59Z"
    /// }</code>
    /// <para>Certificate (CA-signed & self-signed)</para>Certificate credentials can be used to set up mTLS client authentication. CA-signed certificates can be configured either with a signed certificate or with just the certificate Subject DN.
    ///
    /// CA-signed Certificate Sample (pem): <code>{
    ///   "credential_type": "x509_cert",
    ///   "name": "string",
    ///   "pem": "string"
    /// }</code>CA-signed Certificate Sample (subject_dn): <code>{
    ///   "credential_type": "cert_subject_dn",
    ///   "name": "string",
    ///   "subject_dn": "string"
    /// }</code>Self-signed Certificate Sample: <code>{
    ///   "credential_type": "cert_subject_dn",
    ///   "name": "string",
    ///   "pem": "string"
    /// }</code>
    ///
    /// The credential will be created but not yet enabled for use until you set the corresponding properties in the client:
    /// <list type="bullet">
    ///   <item><description>To enable the credential for Private Key JWT or mTLS authentication methods, set the <c>client_authentication_methods</c> property on the client. For more information, read <see href="https://auth0.com/docs/get-started/applications/configure-private-key-jwt">Configure Private Key JWT Authentication</see> and <see href="https://auth0.com/docs/get-started/applications/configure-mtls">Configure mTLS Authentication</see></description></item>
    ///   <item><description>To enable the credential for JWT-secured Authorization requests, set the <c>signed_request_object</c>property on the client. For more information, read <see href="https://auth0.com/docs/get-started/applications/configure-jar">Configure JWT-secured Authorization Requests (JAR)</see></description></item>
    /// </list>
    /// </summary>
    /// <example><code>
    /// await client.Clients.Credentials.CreateAsync(
    ///     "client_id",
    ///     new PostClientCredentialRequestContent { CredentialType = ClientCredentialTypeEnum.PublicKey }
    /// );
    /// </code></example>
    public WithRawResponseTask<PostClientCredentialResponseContent> CreateAsync(
        string clientId,
        PostClientCredentialRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PostClientCredentialResponseContent>(
            CreateAsyncCore(clientId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Get the details of a client credential.
    ///
    /// <b>Important</b>: To enable credentials to be used for a client authentication method, set the <c>client_authentication_methods</c> property on the client. To enable credentials to be used for JWT-Secured Authorization requests set the <c>signed_request_object</c> property on the client.
    /// </summary>
    /// <example><code>
    /// await client.Clients.Credentials.GetAsync("client_id", "credential_id");
    /// </code></example>
    public WithRawResponseTask<GetClientCredentialResponseContent> GetAsync(
        string clientId,
        string credentialId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetClientCredentialResponseContent>(
            GetAsyncCore(clientId, credentialId, options, cancellationToken)
        );
    }

    /// <summary>
    /// Delete a client credential you previously created. May be enabled or disabled. For more information, read <see href="https://www.auth0.com/docs/get-started/authentication-and-authorization-flow/client-credentials-flow">Client Credential Flow</see>.
    /// </summary>
    /// <example><code>
    /// await client.Clients.Credentials.DeleteAsync("client_id", "credential_id");
    /// </code></example>
    public async Task DeleteAsync(
        string clientId,
        string credentialId,
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
                        "clients/{0}/credentials/{1}",
                        ValueConvert.ToPathParameterString(clientId),
                        ValueConvert.ToPathParameterString(credentialId)
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
    /// Change a client credential you previously created. May be enabled or disabled. For more information, read <see href="https://www.auth0.com/docs/get-started/authentication-and-authorization-flow/client-credentials-flow">Client Credential Flow</see>.
    /// </summary>
    /// <example><code>
    /// await client.Clients.Credentials.UpdateAsync(
    ///     "client_id",
    ///     "credential_id",
    ///     new PatchClientCredentialRequestContent()
    /// );
    /// </code></example>
    public WithRawResponseTask<PatchClientCredentialResponseContent> UpdateAsync(
        string clientId,
        string credentialId,
        PatchClientCredentialRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PatchClientCredentialResponseContent>(
            UpdateAsyncCore(clientId, credentialId, request, options, cancellationToken)
        );
    }
}
