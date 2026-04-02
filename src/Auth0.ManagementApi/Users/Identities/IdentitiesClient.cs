using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json;

namespace Auth0.ManagementApi.Users;

public partial class IdentitiesClient : IIdentitiesClient
{
    private readonly RawClient _client;

    internal IdentitiesClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<IEnumerable<UserIdentity>>> LinkAsyncCore(
        string id,
        LinkUserIdentityRequestContent request,
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
                        "users/{0}/identities",
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
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<IEnumerable<UserIdentity>>(responseBody)!;
                return new WithRawResponse<IEnumerable<UserIdentity>>()
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
        WithRawResponse<IEnumerable<DeleteUserIdentityResponseContentItem>>
    > DeleteAsyncCore(
        string id,
        UserIdentityProviderEnum provider,
        string userId,
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
                        "users/{0}/identities/{1}/{2}",
                        ValueConvert.ToPathParameterString(id),
                        ValueConvert.ToPathParameterString(provider),
                        ValueConvert.ToPathParameterString(userId)
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
                var responseData = JsonUtils.Deserialize<
                    IEnumerable<DeleteUserIdentityResponseContentItem>
                >(responseBody)!;
                return new WithRawResponse<IEnumerable<DeleteUserIdentityResponseContentItem>>()
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

    /// <summary>
    /// Link two user accounts together forming a primary and secondary relationship. On successful linking, the endpoint returns the new array of the primary account identities.
    ///
    /// Note: There are two ways of invoking the endpoint:
    ///
    /// <list type="bullet">
    ///   <item><description>With the authenticated primary account's JWT in the Authorization header, which has the <c>update:current_user_identities</c> scope:
    ///     <code>
    ///       POST /api/v2/users/PRIMARY_ACCOUNT_USER_ID/identities
    ///       Authorization: "Bearer PRIMARY_ACCOUNT_JWT"
    ///       {
    ///         "link_with": "SECONDARY_ACCOUNT_JWT"
    ///       }
    ///     </code>
    ///     In this case, only the <c>link_with</c> param is required in the body, which also contains the JWT obtained upon the secondary account's authentication.
    ///   </description></item>
    ///   <item><description>With a token generated by the API V2 containing the <c>update:users</c> scope:
    ///     <code>
    ///     POST /api/v2/users/PRIMARY_ACCOUNT_USER_ID/identities
    ///     Authorization: "Bearer YOUR_API_V2_TOKEN"
    ///     {
    ///       "provider": "SECONDARY_ACCOUNT_PROVIDER",
    ///       "connection_id": "SECONDARY_ACCOUNT_CONNECTION_ID(OPTIONAL)",
    ///       "user_id": "SECONDARY_ACCOUNT_USER_ID"
    ///     }
    ///     </code>
    ///     In this case you need to send <c>provider</c> and <c>user_id</c> in the body. Optionally you can also send the <c>connection_id</c> param which is suitable for identifying a particular database connection for the 'auth0' provider.
    ///   </description></item>
    /// </list>
    /// </summary>
    /// <example><code>
    /// await client.Users.Identities.LinkAsync("id", new LinkUserIdentityRequestContent());
    /// </code></example>
    public WithRawResponseTask<IEnumerable<UserIdentity>> LinkAsync(
        string id,
        LinkUserIdentityRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<UserIdentity>>(
            LinkAsyncCore(id, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Unlink a specific secondary account from a target user. This action requires the ID of both the target user and the secondary account.
    ///
    /// Unlinking the secondary account removes it from the identities array of the target user and creates a new standalone profile for the secondary account. To learn more, review <see href="https://auth0.com/docs/manage-users/user-accounts/user-account-linking/unlink-user-accounts">Unlink User Accounts</see>.
    /// </summary>
    /// <example><code>
    /// await client.Users.Identities.DeleteAsync("id", UserIdentityProviderEnum.Ad, "user_id");
    /// </code></example>
    public WithRawResponseTask<IEnumerable<DeleteUserIdentityResponseContentItem>> DeleteAsync(
        string id,
        UserIdentityProviderEnum provider,
        string userId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<DeleteUserIdentityResponseContentItem>>(
            DeleteAsyncCore(id, provider, userId, options, cancellationToken)
        );
    }
}
