using System.Text.Json;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Branding;

public partial class TemplatesClient : ITemplatesClient
{
    private RawClient _client;

    internal TemplatesClient(RawClient client)
    {
        _client = client;
    }

    private async Task<
        WithRawResponse<GetUniversalLoginTemplateResponseContent>
    > GetUniversalLoginAsyncCore(
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
                    Path = "branding/templates/universal-login",
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
                var responseData = JsonUtils.Deserialize<GetUniversalLoginTemplateResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<GetUniversalLoginTemplateResponseContent>()
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
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
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

    /// <example><code>
    /// await client.Branding.Templates.GetUniversalLoginAsync();
    /// </code></example>
    public WithRawResponseTask<GetUniversalLoginTemplateResponseContent> GetUniversalLoginAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetUniversalLoginTemplateResponseContent>(
            GetUniversalLoginAsyncCore(options, cancellationToken)
        );
    }

    /// <summary>
    /// Update the Universal Login branding template.
    ///
    /// <para>When <c>content-type</c> header is set to <c>application/json</c>:</para>
    /// <code>
    /// {
    ///   "template": "&lt;!DOCTYPE html&gt;{% assign resolved_dir = dir | default: "auto" %}&lt;html lang="{{locale}}" dir="{{resolved_dir}}"&gt;&lt;head&gt;{%- auth0:head -%}&lt;/head&gt;&lt;body class="_widget-auto-layout"&gt;{%- auth0:widget -%}&lt;/body&gt;&lt;/html&gt;"
    /// }
    /// </code>
    ///
    /// <para>
    ///   When <c>content-type</c> header is set to <c>text/html</c>:
    /// </para>
    /// <code>
    /// &lt!DOCTYPE html&gt;
    /// {% assign resolved_dir = dir | default: "auto" %}
    /// &lt;html lang="{{locale}}" dir="{{resolved_dir}}"&gt;
    ///   &lt;head&gt;
    ///     {%- auth0:head -%}
    ///   &lt;/head&gt;
    ///   &lt;body class="_widget-auto-layout"&gt;
    ///     {%- auth0:widget -%}
    ///   &lt;/body&gt;
    /// &lt;/html&gt;
    /// </code>
    /// </summary>
    /// <example><code>
    /// await client.Branding.Templates.UpdateUniversalLoginAsync("string");
    /// </code></example>
    public async Task UpdateUniversalLoginAsync(
        UpdateUniversalLoginTemplateRequestContent request,
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
                    Path = "branding/templates/universal-login",
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
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
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

    /// <example><code>
    /// await client.Branding.Templates.DeleteUniversalLoginAsync();
    /// </code></example>
    public async Task DeleteUniversalLoginAsync(
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
                    Path = "branding/templates/universal-login",
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
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
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
}
