using System.Text.Json;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Jobs;

public partial class VerificationEmailClient : IVerificationEmailClient
{
    private RawClient _client;

    internal VerificationEmailClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<CreateVerificationEmailResponseContent>> CreateAsyncCore(
        CreateVerificationEmailRequestContent request,
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
                    Method = HttpMethod.Post,
                    Path = "jobs/verification-email",
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
                var responseData = JsonUtils.Deserialize<CreateVerificationEmailResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<CreateVerificationEmailResponseContent>()
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
    /// Send an email to the specified user that asks them to click a link to <see href="https://auth0.com/docs/email/custom#verification-email">verify their email address</see>.
    ///
    /// Note: You must have the `Status` toggle enabled for the verification email template for the email to be sent.
    /// </summary>
    /// <example><code>
    /// await client.Jobs.VerificationEmail.CreateAsync(
    ///     new CreateVerificationEmailRequestContent { UserId = "user_id" }
    /// );
    /// </code></example>
    public WithRawResponseTask<CreateVerificationEmailResponseContent> CreateAsync(
        CreateVerificationEmailRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CreateVerificationEmailResponseContent>(
            CreateAsyncCore(request, options, cancellationToken)
        );
    }
}
