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
    /// Retrieve details of the <a href="https://auth0.com/docs/customize/email/smtp-email-providers">email provider configuration</a> in your tenant. A list of fields to include or exclude may also be specified.
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
    /// Create an <a href="https://auth0.com/docs/email/providers">email provider</a>. The <code>credentials</code> object
    /// requires different properties depending on the email provider (which is specified using the <code>name</code> property):
    /// <ul>
    ///   <li><code>mandrill</code> requires <code>api_key</code></li>
    ///   <li><code>sendgrid</code> requires <code>api_key</code></li>
    ///   <li>
    ///     <code>sparkpost</code> requires <code>api_key</code>. Optionally, set <code>region</code> to <code>eu</code> to use
    ///     the SparkPost service hosted in Western Europe; set to <code>null</code> to use the SparkPost service hosted in
    ///     North America. <code>eu</code> or <code>null</code> are the only valid values for <code>region</code>.
    ///   </li>
    ///   <li>
    ///     <code>mailgun</code> requires <code>api_key</code> and <code>domain</code>. Optionally, set <code>region</code> to
    ///     <code>eu</code> to use the Mailgun service hosted in Europe; set to <code>null</code> otherwise. <code>eu</code> or
    ///     <code>null</code> are the only valid values for <code>region</code>.
    ///   </li>
    ///   <li><code>ses</code> requires <code>accessKeyId</code>, <code>secretAccessKey</code>, and <code>region</code></li>
    ///   <li>
    ///     <code>smtp</code> requires <code>smtp_host</code>, <code>smtp_port</code>, <code>smtp_user</code>, and
    ///     <code>smtp_pass</code>
    ///   </li>
    /// </ul>
    /// Depending on the type of provider it is possible to specify <code>settings</code> object with different configuration
    /// options, which will be used when sending an email:
    /// <ul>
    ///   <li>
    ///     <code>smtp</code> provider, <code>settings</code> may contain <code>headers</code> object.
    ///     <ul>
    ///       <li>
    ///         When using AWS SES SMTP host, you may provide a name of configuration set in
    ///         <code>X-SES-Configuration-Set</code> header. Value must be a string.
    ///       </li>
    ///       <li>
    ///         When using Sparkpost host, you may provide value for
    ///         <code>X-MSYS_API</code> header. Value must be an object.
    ///       </li>
    ///     </ul>
    ///   </li>
    ///   <li>
    ///     for <code>ses</code> provider, <code>settings</code> may contain <code>message</code> object, where you can provide
    ///     a name of configuration set in <code>configuration_set_name</code> property. Value must be a string.
    ///   </li>
    /// </ul>
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
    /// Update an <a href="https://auth0.com/docs/email/providers">email provider</a>. The <code>credentials</code> object
    /// requires different properties depending on the email provider (which is specified using the <code>name</code> property):
    /// <ul>
    ///   <li><code>mandrill</code> requires <code>api_key</code></li>
    ///   <li><code>sendgrid</code> requires <code>api_key</code></li>
    ///   <li>
    ///     <code>sparkpost</code> requires <code>api_key</code>. Optionally, set <code>region</code> to <code>eu</code> to use
    ///     the SparkPost service hosted in Western Europe; set to <code>null</code> to use the SparkPost service hosted in
    ///     North America. <code>eu</code> or <code>null</code> are the only valid values for <code>region</code>.
    ///   </li>
    ///   <li>
    ///     <code>mailgun</code> requires <code>api_key</code> and <code>domain</code>. Optionally, set <code>region</code> to
    ///     <code>eu</code> to use the Mailgun service hosted in Europe; set to <code>null</code> otherwise. <code>eu</code> or
    ///     <code>null</code> are the only valid values for <code>region</code>.
    ///   </li>
    ///   <li><code>ses</code> requires <code>accessKeyId</code>, <code>secretAccessKey</code>, and <code>region</code></li>
    ///   <li>
    ///     <code>smtp</code> requires <code>smtp_host</code>, <code>smtp_port</code>, <code>smtp_user</code>, and
    ///     <code>smtp_pass</code>
    ///   </li>
    /// </ul>
    /// Depending on the type of provider it is possible to specify <code>settings</code> object with different configuration
    /// options, which will be used when sending an email:
    /// <ul>
    ///   <li>
    ///     <code>smtp</code> provider, <code>settings</code> may contain <code>headers</code> object.
    ///     <ul>
    ///       <li>
    ///         When using AWS SES SMTP host, you may provide a name of configuration set in
    ///         <code>X-SES-Configuration-Set</code> header. Value must be a string.
    ///       </li>
    ///       <li>
    ///         When using Sparkpost host, you may provide value for
    ///         <code>X-MSYS_API</code> header. Value must be an object.
    ///       </li>
    ///     </ul>
    ///     for <code>ses</code> provider, <code>settings</code> may contain <code>message</code> object, where you can provide
    ///     a name of configuration set in <code>configuration_set_name</code> property. Value must be a string.
    ///   </li>
    /// </ul>
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
