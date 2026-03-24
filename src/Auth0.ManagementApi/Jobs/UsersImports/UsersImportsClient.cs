using System.Text.Json;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Jobs;

public partial class UsersImportsClient : IUsersImportsClient
{
    private RawClient _client;

    internal UsersImportsClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<CreateImportUsersResponseContent>> CreateAsyncCore(
        CreateImportUsersRequestContent request,
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
        var multipartFormRequest_ = new MultipartFormRequest
        {
            Method = HttpMethod.Post,
            Path = "jobs/users-imports",
            Headers = _headers,
            Options = options,
        };
        multipartFormRequest_.AddFileParameterPart("users", request.Users);
        multipartFormRequest_.AddStringPart("connection_id", request.ConnectionId);
        multipartFormRequest_.AddStringPart("upsert", request.Upsert);
        multipartFormRequest_.AddStringPart("external_id", request.ExternalId);
        multipartFormRequest_.AddStringPart("send_completion_email", request.SendCompletionEmail);
        var response = await _client
            .SendRequestAsync(multipartFormRequest_, cancellationToken)
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData = JsonUtils.Deserialize<CreateImportUsersResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<CreateImportUsersResponseContent>()
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
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
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

    /// <summary>
    /// Import users from a <see href="https://auth0.com/docs/users/references/bulk-import-database-schema-examples">formatted file</see> into a connection via a long-running job. When importing users, with or without upsert, the `email_verified` is set to `false` when the email address is added or updated. Users must verify their email address. To avoid this behavior, set `email_verified` to `true` in the imported data.
    /// </summary>
    /// <example><code>
    /// await client.Jobs.UsersImports.CreateAsync(
    ///     new CreateImportUsersRequestContent { ConnectionId = "connection_id" }
    /// );
    /// </code></example>
    public WithRawResponseTask<CreateImportUsersResponseContent> CreateAsync(
        CreateImportUsersRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CreateImportUsersResponseContent>(
            CreateAsyncCore(request, options, cancellationToken)
        );
    }
}
