using System.Text.Json;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

public partial class EmailTemplatesClient : IEmailTemplatesClient
{
    private RawClient _client;

    internal EmailTemplatesClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<CreateEmailTemplateResponseContent>> CreateAsyncCore(
        CreateEmailTemplateRequestContent request,
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
                    Path = "email-templates",
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
                var responseData = JsonUtils.Deserialize<CreateEmailTemplateResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<CreateEmailTemplateResponseContent>()
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

    private async Task<WithRawResponse<GetEmailTemplateResponseContent>> GetAsyncCore(
        EmailTemplateNameEnum templateName,
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
                        "email-templates/{0}",
                        ValueConvert.ToPathParameterString(templateName)
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
                var responseData = JsonUtils.Deserialize<GetEmailTemplateResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<GetEmailTemplateResponseContent>()
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

    private async Task<WithRawResponse<SetEmailTemplateResponseContent>> SetAsyncCore(
        EmailTemplateNameEnum templateName,
        SetEmailTemplateRequestContent request,
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
                        "email-templates/{0}",
                        ValueConvert.ToPathParameterString(templateName)
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
                var responseData = JsonUtils.Deserialize<SetEmailTemplateResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<SetEmailTemplateResponseContent>()
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

    private async Task<WithRawResponse<UpdateEmailTemplateResponseContent>> UpdateAsyncCore(
        EmailTemplateNameEnum templateName,
        UpdateEmailTemplateRequestContent request,
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
                        "email-templates/{0}",
                        ValueConvert.ToPathParameterString(templateName)
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
                var responseData = JsonUtils.Deserialize<UpdateEmailTemplateResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<UpdateEmailTemplateResponseContent>()
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
    /// Create an email template.
    /// </summary>
    /// <example><code>
    /// await client.EmailTemplates.CreateAsync(
    ///     new CreateEmailTemplateRequestContent { Template = EmailTemplateNameEnum.VerifyEmail }
    /// );
    /// </code></example>
    public WithRawResponseTask<CreateEmailTemplateResponseContent> CreateAsync(
        CreateEmailTemplateRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CreateEmailTemplateResponseContent>(
            CreateAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve an email template by pre-defined name. These names are `verify_email`, `verify_email_by_code`, `reset_email`, `reset_email_by_code`, `welcome_email`, `blocked_account`, `stolen_credentials`, `enrollment_email`, `mfa_oob_code`, `user_invitation`, and `async_approval`. The names `change_password`, and `password_reset` are also supported for legacy scenarios.
    /// </summary>
    /// <example><code>
    /// await client.EmailTemplates.GetAsync(EmailTemplateNameEnum.VerifyEmail);
    /// </code></example>
    public WithRawResponseTask<GetEmailTemplateResponseContent> GetAsync(
        EmailTemplateNameEnum templateName,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetEmailTemplateResponseContent>(
            GetAsyncCore(templateName, options, cancellationToken)
        );
    }

    /// <summary>
    /// Update an email template.
    /// </summary>
    /// <example><code>
    /// await client.EmailTemplates.SetAsync(
    ///     EmailTemplateNameEnum.VerifyEmail,
    ///     new SetEmailTemplateRequestContent { Template = EmailTemplateNameEnum.VerifyEmail }
    /// );
    /// </code></example>
    public WithRawResponseTask<SetEmailTemplateResponseContent> SetAsync(
        EmailTemplateNameEnum templateName,
        SetEmailTemplateRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<SetEmailTemplateResponseContent>(
            SetAsyncCore(templateName, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Modify an email template.
    /// </summary>
    /// <example><code>
    /// await client.EmailTemplates.UpdateAsync(
    ///     EmailTemplateNameEnum.VerifyEmail,
    ///     new UpdateEmailTemplateRequestContent()
    /// );
    /// </code></example>
    public WithRawResponseTask<UpdateEmailTemplateResponseContent> UpdateAsync(
        EmailTemplateNameEnum templateName,
        UpdateEmailTemplateRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<UpdateEmailTemplateResponseContent>(
            UpdateAsyncCore(templateName, request, options, cancellationToken)
        );
    }
}
