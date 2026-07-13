namespace Auth0.ManagementApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
public class ManagementApiException(
    string message,
    int statusCode,
    object body,
    Exception? innerException = null,
    Auth0.ManagementApi.RawResponse? rawResponse = null
) : ManagementException(message, innerException)
{
    private bool _apiErrorParsed;
    private ApiError? _apiError;
    private bool _rateLimitParsed;
    private RateLimit? _rateLimit;

    /// <summary>
    /// The error code of the response that triggered the exception.
    /// </summary>
    public int StatusCode => statusCode;

    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public object Body => body;

    /// <summary>
    /// The raw HTTP response (status code, URL, headers) that triggered the exception, if available.
    /// </summary>
    public Auth0.ManagementApi.RawResponse? RawResponse => rawResponse;

    /// <summary>
    /// Structured error information extracted from the response <see cref="Body"/>, if the API returned a
    /// recognizable error payload. Returns <c>null</c> when no error information could be parsed.
    /// </summary>
    public ApiError? ApiError
    {
        get
        {
            if (!_apiErrorParsed)
            {
                _apiError = Auth0.ManagementApi.ApiError.TryParse(body);
                _apiErrorParsed = true;
            }

            return _apiError;
        }
    }

    /// <summary>
    /// The human-readable error description returned by the API, if available.
    /// </summary>
    public string? Description => ApiError?.Message;

    /// <summary>
    /// The machine-readable error code returned by the API, if available.
    /// </summary>
    public string? ErrorCode => ApiError?.ErrorCode;

    /// <summary>
    /// Rate limit information parsed from the response headers (<c>x-ratelimit-limit</c>,
    /// <c>x-ratelimit-remaining</c>, <c>x-ratelimit-reset</c>, <c>retry-after</c>), along with any
    /// client and organization quota headers. Returns <c>null</c> when no raw response is available.
    /// </summary>
    public RateLimit? RateLimit
    {
        get
        {
            if (!_rateLimitParsed)
            {
                _rateLimit =
                    rawResponse is null
                        ? null
                        : Auth0.ManagementApi.RateLimit.Parse(rawResponse.Headers);
                _rateLimitParsed = true;
            }

            return _rateLimit;
        }
    }

    /// <summary>
    /// The error message. When the API returned a recognizable error description it is surfaced here;
    /// otherwise falls back to the default message supplied by the SDK.
    /// </summary>
    public override string Message => ApiError?.Message ?? base.Message;

    public override string ToString()
    {
        var sb = new System.Text.StringBuilder();
        sb.Append(GetType().FullName);
        sb.Append($": {Message}");
        sb.Append($" (Status Code: {StatusCode})");
        if (InnerException != null)
        {
            sb.Append($"\n ---> {InnerException}");
            sb.Append("\n --- End of inner exception stack trace ---");
        }
        if (StackTrace != null)
        {
            sb.Append($"\n{StackTrace}");
        }
        return sb.ToString();
    }
}
