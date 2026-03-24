using System.Text.Json;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Branding;

public partial class ThemesClient : IThemesClient
{
    private RawClient _client;

    internal ThemesClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<CreateBrandingThemeResponseContent>> CreateAsyncCore(
        CreateBrandingThemeRequestContent request,
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
                    Path = "branding/themes",
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
                var responseData = JsonUtils.Deserialize<CreateBrandingThemeResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<CreateBrandingThemeResponseContent>()
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

    private async Task<WithRawResponse<GetBrandingDefaultThemeResponseContent>> GetDefaultAsyncCore(
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
                    Path = "branding/themes/default",
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
                var responseData = JsonUtils.Deserialize<GetBrandingDefaultThemeResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<GetBrandingDefaultThemeResponseContent>()
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

    private async Task<WithRawResponse<GetBrandingThemeResponseContent>> GetAsyncCore(
        string themeId,
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
                        "branding/themes/{0}",
                        ValueConvert.ToPathParameterString(themeId)
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
                var responseData = JsonUtils.Deserialize<GetBrandingThemeResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<GetBrandingThemeResponseContent>()
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

    private async Task<WithRawResponse<UpdateBrandingThemeResponseContent>> UpdateAsyncCore(
        string themeId,
        UpdateBrandingThemeRequestContent request,
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
                        "branding/themes/{0}",
                        ValueConvert.ToPathParameterString(themeId)
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
                var responseData = JsonUtils.Deserialize<UpdateBrandingThemeResponseContent>(
                    responseBody
                )!;
                return new WithRawResponse<UpdateBrandingThemeResponseContent>()
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
    /// Create branding theme.
    /// </summary>
    /// <example><code>
    /// await client.Branding.Themes.CreateAsync(
    ///     new CreateBrandingThemeRequestContent
    ///     {
    ///         Borders = new BrandingThemeBorders
    ///         {
    ///             ButtonBorderRadius = 1.1,
    ///             ButtonBorderWeight = 1.1,
    ///             ButtonsStyle = BrandingThemeBordersButtonsStyleEnum.Pill,
    ///             InputBorderRadius = 1.1,
    ///             InputBorderWeight = 1.1,
    ///             InputsStyle = BrandingThemeBordersInputsStyleEnum.Pill,
    ///             ShowWidgetShadow = true,
    ///             WidgetBorderWeight = 1.1,
    ///             WidgetCornerRadius = 1.1,
    ///         },
    ///         Colors = new BrandingThemeColors
    ///         {
    ///             BodyText = "body_text",
    ///             Error = "error",
    ///             Header = "header",
    ///             Icons = "icons",
    ///             InputBackground = "input_background",
    ///             InputBorder = "input_border",
    ///             InputFilledText = "input_filled_text",
    ///             InputLabelsPlaceholders = "input_labels_placeholders",
    ///             LinksFocusedComponents = "links_focused_components",
    ///             PrimaryButton = "primary_button",
    ///             PrimaryButtonLabel = "primary_button_label",
    ///             SecondaryButtonBorder = "secondary_button_border",
    ///             SecondaryButtonLabel = "secondary_button_label",
    ///             Success = "success",
    ///             WidgetBackground = "widget_background",
    ///             WidgetBorder = "widget_border",
    ///         },
    ///         Fonts = new BrandingThemeFonts
    ///         {
    ///             BodyText = new BrandingThemeFontBodyText { Bold = true, Size = 1.1 },
    ///             ButtonsText = new BrandingThemeFontButtonsText { Bold = true, Size = 1.1 },
    ///             FontUrl = "font_url",
    ///             InputLabels = new BrandingThemeFontInputLabels { Bold = true, Size = 1.1 },
    ///             Links = new BrandingThemeFontLinks { Bold = true, Size = 1.1 },
    ///             LinksStyle = BrandingThemeFontLinksStyleEnum.Normal,
    ///             ReferenceTextSize = 1.1,
    ///             Subtitle = new BrandingThemeFontSubtitle { Bold = true, Size = 1.1 },
    ///             Title = new BrandingThemeFontTitle { Bold = true, Size = 1.1 },
    ///         },
    ///         PageBackground = new BrandingThemePageBackground
    ///         {
    ///             BackgroundColor = "background_color",
    ///             BackgroundImageUrl = "background_image_url",
    ///             PageLayout = BrandingThemePageBackgroundPageLayoutEnum.Center,
    ///         },
    ///         Widget = new BrandingThemeWidget
    ///         {
    ///             HeaderTextAlignment = BrandingThemeWidgetHeaderTextAlignmentEnum.Center,
    ///             LogoHeight = 1.1,
    ///             LogoPosition = BrandingThemeWidgetLogoPositionEnum.Center,
    ///             LogoUrl = "logo_url",
    ///             SocialButtonsLayout = BrandingThemeWidgetSocialButtonsLayoutEnum.Bottom,
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CreateBrandingThemeResponseContent> CreateAsync(
        CreateBrandingThemeRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CreateBrandingThemeResponseContent>(
            CreateAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve default branding theme.
    /// </summary>
    /// <example><code>
    /// await client.Branding.Themes.GetDefaultAsync();
    /// </code></example>
    public WithRawResponseTask<GetBrandingDefaultThemeResponseContent> GetDefaultAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetBrandingDefaultThemeResponseContent>(
            GetDefaultAsyncCore(options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve branding theme.
    /// </summary>
    /// <example><code>
    /// await client.Branding.Themes.GetAsync("themeId");
    /// </code></example>
    public WithRawResponseTask<GetBrandingThemeResponseContent> GetAsync(
        string themeId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetBrandingThemeResponseContent>(
            GetAsyncCore(themeId, options, cancellationToken)
        );
    }

    /// <summary>
    /// Delete branding theme.
    /// </summary>
    /// <example><code>
    /// await client.Branding.Themes.DeleteAsync("themeId");
    /// </code></example>
    public async Task DeleteAsync(
        string themeId,
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
                        "branding/themes/{0}",
                        ValueConvert.ToPathParameterString(themeId)
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
    /// Update branding theme.
    /// </summary>
    /// <example><code>
    /// await client.Branding.Themes.UpdateAsync(
    ///     "themeId",
    ///     new UpdateBrandingThemeRequestContent
    ///     {
    ///         Borders = new BrandingThemeBorders
    ///         {
    ///             ButtonBorderRadius = 1.1,
    ///             ButtonBorderWeight = 1.1,
    ///             ButtonsStyle = BrandingThemeBordersButtonsStyleEnum.Pill,
    ///             InputBorderRadius = 1.1,
    ///             InputBorderWeight = 1.1,
    ///             InputsStyle = BrandingThemeBordersInputsStyleEnum.Pill,
    ///             ShowWidgetShadow = true,
    ///             WidgetBorderWeight = 1.1,
    ///             WidgetCornerRadius = 1.1,
    ///         },
    ///         Colors = new BrandingThemeColors
    ///         {
    ///             BodyText = "body_text",
    ///             Error = "error",
    ///             Header = "header",
    ///             Icons = "icons",
    ///             InputBackground = "input_background",
    ///             InputBorder = "input_border",
    ///             InputFilledText = "input_filled_text",
    ///             InputLabelsPlaceholders = "input_labels_placeholders",
    ///             LinksFocusedComponents = "links_focused_components",
    ///             PrimaryButton = "primary_button",
    ///             PrimaryButtonLabel = "primary_button_label",
    ///             SecondaryButtonBorder = "secondary_button_border",
    ///             SecondaryButtonLabel = "secondary_button_label",
    ///             Success = "success",
    ///             WidgetBackground = "widget_background",
    ///             WidgetBorder = "widget_border",
    ///         },
    ///         Fonts = new BrandingThemeFonts
    ///         {
    ///             BodyText = new BrandingThemeFontBodyText { Bold = true, Size = 1.1 },
    ///             ButtonsText = new BrandingThemeFontButtonsText { Bold = true, Size = 1.1 },
    ///             FontUrl = "font_url",
    ///             InputLabels = new BrandingThemeFontInputLabels { Bold = true, Size = 1.1 },
    ///             Links = new BrandingThemeFontLinks { Bold = true, Size = 1.1 },
    ///             LinksStyle = BrandingThemeFontLinksStyleEnum.Normal,
    ///             ReferenceTextSize = 1.1,
    ///             Subtitle = new BrandingThemeFontSubtitle { Bold = true, Size = 1.1 },
    ///             Title = new BrandingThemeFontTitle { Bold = true, Size = 1.1 },
    ///         },
    ///         PageBackground = new BrandingThemePageBackground
    ///         {
    ///             BackgroundColor = "background_color",
    ///             BackgroundImageUrl = "background_image_url",
    ///             PageLayout = BrandingThemePageBackgroundPageLayoutEnum.Center,
    ///         },
    ///         Widget = new BrandingThemeWidget
    ///         {
    ///             HeaderTextAlignment = BrandingThemeWidgetHeaderTextAlignmentEnum.Center,
    ///             LogoHeight = 1.1,
    ///             LogoPosition = BrandingThemeWidgetLogoPositionEnum.Center,
    ///             LogoUrl = "logo_url",
    ///             SocialButtonsLayout = BrandingThemeWidgetSocialButtonsLayoutEnum.Bottom,
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<UpdateBrandingThemeResponseContent> UpdateAsync(
        string themeId,
        UpdateBrandingThemeRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<UpdateBrandingThemeResponseContent>(
            UpdateAsyncCore(themeId, request, options, cancellationToken)
        );
    }
}
