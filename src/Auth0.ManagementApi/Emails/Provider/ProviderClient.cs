using System.Text.Json;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Emails;

public partial class ProviderClient : IProviderClient
{
    private RawClient _client;

    internal ProviderClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<GetEmailProviderResponseContent>> GetAsyncCore(
        GetEmailProviderRequestParameters request,
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
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "emails/provider",
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
                var responseData = JsonUtils.Deserialize<GetEmailProviderResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<GetEmailProviderResponseContent>()
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

    private async Task<WithRawResponse<CreateEmailProviderResponseContent>> CreateAsyncCore(
        CreateEmailProviderRequestContent request,
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
                    Path = "emails/provider",
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
                var responseData = JsonUtils.Deserialize<CreateEmailProviderResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<CreateEmailProviderResponseContent>()
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

    private async Task<WithRawResponse<UpdateEmailProviderResponseContent>> UpdateAsyncCore(
        UpdateEmailProviderRequestContent request,
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
                    Method = HttpMethodExtensions.Patch,
                    Path = "emails/provider",
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
                var responseData = JsonUtils.Deserialize<UpdateEmailProviderResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<UpdateEmailProviderResponseContent>()
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

    /// <summary>
    /// Retrieve details of the <see href="https://auth0.com/docs/customize/email/smtp-email-providers">email provider configuration</see> in your tenant. A list of fields to include or exclude may also be specified.
    /// </summary>
    /// <example><code>
    /// await client.Emails.Provider.GetAsync(
    ///     new GetEmailProviderRequestParameters { Fields = "fields", IncludeFields = true }
    /// );
    /// </code></example>
    public WithRawResponseTask<GetEmailProviderResponseContent> GetAsync(
        GetEmailProviderRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetEmailProviderResponseContent>(
            GetAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Create an <see href="https://auth0.com/docs/email/providers">email provider</see>. The <c>credentials</c> object
    /// requires different properties depending on the email provider (which is specified using the <c>name</c> property):
    /// <list type="bullet">
    ///   <item><description><c>mandrill</c> requires <c>api_key</c></description></item>
    ///   <item><description><c>sendgrid</c> requires <c>api_key</c></description></item>
    ///   <item><description>
    ///     <c>sparkpost</c> requires <c>api_key</c>. Optionally, set <c>region</c> to <c>eu</c> to use
    ///     the SparkPost service hosted in Western Europe; set to <c>null</c> to use the SparkPost service hosted in
    ///     North America. <c>eu</c> or <c>null</c> are the only valid values for <c>region</c>.
    ///   </description></item>
    ///   <item><description>
    ///     <c>mailgun</c> requires <c>api_key</c> and <c>domain</c>. Optionally, set <c>region</c> to
    ///     <c>eu</c> to use the Mailgun service hosted in Europe; set to <c>null</c> otherwise. <c>eu</c> or
    ///     <c>null</c> are the only valid values for <c>region</c>.
    ///   </description></item>
    ///   <item><description><c>ses</c> requires <c>accessKeyId</c>, <c>secretAccessKey</c>, and <c>region</c></description></item>
    ///   <item><description>
    ///     <c>smtp</c> requires <c>smtp_host</c>, <c>smtp_port</c>, <c>smtp_user</c>, and
    ///     <c>smtp_pass</c>
    ///   </description></item>
    /// </list>
    /// Depending on the type of provider it is possible to specify <c>settings</c> object with different configuration
    /// options, which will be used when sending an email:
    /// <list type="bullet">
    ///   <item><description>
    ///     <c>smtp</c> provider, <c>settings</c> may contain <c>headers</c> object.
    ///     <list type="bullet">
    ///       <item><description>
    ///         When using AWS SES SMTP host, you may provide a name of configuration set in
    ///         <c>X-SES-Configuration-Set</c> header. Value must be a string.
    ///       </description></item>
    ///       <item><description>
    ///         When using Sparkpost host, you may provide value for
    ///         <c>X-MSYS_API</c> header. Value must be an object.
    ///       </description></item>
    ///     </list>
    ///   </description></item>
    ///   <item><description>
    ///     for <c>ses</c> provider, <c>settings</c> may contain <c>message</c> object, where you can provide
    ///     a name of configuration set in <c>configuration_set_name</c> property. Value must be a string.
    ///   </description></item>
    /// </list>
    /// </summary>
    /// <example><code>
    /// await client.Emails.Provider.CreateAsync(
    ///     new CreateEmailProviderRequestContent
    ///     {
    ///         Name = EmailProviderNameEnum.Mailgun,
    ///         Credentials = new EmailProviderCredentialsSchemaZero { ApiKey = "api_key" },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CreateEmailProviderResponseContent> CreateAsync(
        CreateEmailProviderRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CreateEmailProviderResponseContent>(
            CreateAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Delete the email provider.
    /// </summary>
    /// <example><code>
    /// await client.Emails.Provider.DeleteAsync();
    /// </code></example>
    public async Task DeleteAsync(
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
                    Method = HttpMethod.Delete,
                    Path = "emails/provider",
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
    /// Update an <see href="https://auth0.com/docs/email/providers">email provider</see>. The <c>credentials</c> object
    /// requires different properties depending on the email provider (which is specified using the <c>name</c> property):
    /// <list type="bullet">
    ///   <item><description><c>mandrill</c> requires <c>api_key</c></description></item>
    ///   <item><description><c>sendgrid</c> requires <c>api_key</c></description></item>
    ///   <item><description>
    ///     <c>sparkpost</c> requires <c>api_key</c>. Optionally, set <c>region</c> to <c>eu</c> to use
    ///     the SparkPost service hosted in Western Europe; set to <c>null</c> to use the SparkPost service hosted in
    ///     North America. <c>eu</c> or <c>null</c> are the only valid values for <c>region</c>.
    ///   </description></item>
    ///   <item><description>
    ///     <c>mailgun</c> requires <c>api_key</c> and <c>domain</c>. Optionally, set <c>region</c> to
    ///     <c>eu</c> to use the Mailgun service hosted in Europe; set to <c>null</c> otherwise. <c>eu</c> or
    ///     <c>null</c> are the only valid values for <c>region</c>.
    ///   </description></item>
    ///   <item><description><c>ses</c> requires <c>accessKeyId</c>, <c>secretAccessKey</c>, and <c>region</c></description></item>
    ///   <item><description>
    ///     <c>smtp</c> requires <c>smtp_host</c>, <c>smtp_port</c>, <c>smtp_user</c>, and
    ///     <c>smtp_pass</c>
    ///   </description></item>
    /// </list>
    /// Depending on the type of provider it is possible to specify <c>settings</c> object with different configuration
    /// options, which will be used when sending an email:
    /// <list type="bullet">
    ///   <item><description>
    ///     <c>smtp</c> provider, <c>settings</c> may contain <c>headers</c> object.
    ///     <list type="bullet">
    ///       <item><description>
    ///         When using AWS SES SMTP host, you may provide a name of configuration set in
    ///         <c>X-SES-Configuration-Set</c> header. Value must be a string.
    ///       </description></item>
    ///       <item><description>
    ///         When using Sparkpost host, you may provide value for
    ///         <c>X-MSYS_API</c> header. Value must be an object.
    ///       </description></item>
    ///     </list>
    ///     for <c>ses</c> provider, <c>settings</c> may contain <c>message</c> object, where you can provide
    ///     a name of configuration set in <c>configuration_set_name</c> property. Value must be a string.
    ///   </description></item>
    /// </list>
    /// </summary>
    /// <example><code>
    /// await client.Emails.Provider.UpdateAsync(new UpdateEmailProviderRequestContent());
    /// </code></example>
    public WithRawResponseTask<UpdateEmailProviderResponseContent> UpdateAsync(
        UpdateEmailProviderRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<UpdateEmailProviderResponseContent>(
            UpdateAsyncCore(request, options, cancellationToken)
        );
    }
}
