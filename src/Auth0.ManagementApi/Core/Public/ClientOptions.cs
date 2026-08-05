using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public partial class ClientOptions
{
    private string _baseUrl = ManagementApiClientEnvironment.Default;

    internal ClientOptions(ClientOptions other)
    {
        BaseUrl = other.BaseUrl;
        IsBaseUrlExplicitlySet = other.IsBaseUrlExplicitlySet;
        TenantDomain = other.TenantDomain;
        HttpClient = other.HttpClient;
        MaxRetries = other.MaxRetries;
        Timeout = other.Timeout;
        Headers = new Headers(new Dictionary<string, HeaderValue>(other.Headers));
        AdditionalHeaders = other.AdditionalHeaders;
    }

    internal bool IsBaseUrlExplicitlySet { get; private set; } = false;

    /// <summary>
    /// The http headers sent with the request.
    /// </summary>
    internal Headers Headers { get; init; } = new();

    /// <summary>
    /// The Base URL for the API.
    /// </summary>
    public string BaseUrl
    {
        get => _baseUrl;
        set => SetBaseUrl(value);
    }

    /// <summary>
    /// Defaults to "{TENANT}.auth0.com".
    /// </summary>
    public string? TenantDomain { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    }

    /// <summary>
    /// The http client used to make requests.
    /// </summary>
    public HttpClient HttpClient { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    } = DefaultHttpClientFactory.Create();

    /// <summary>
    /// Additional headers to be sent with HTTP requests.
    /// Headers with matching keys will be overwritten by headers set on the request.
    /// </summary>
    public IEnumerable<KeyValuePair<string, string?>> AdditionalHeaders { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    } = [];

    /// <summary>
    /// The max number of retries to attempt.
    /// </summary>
    public int MaxRetries { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    } = 2;

    /// <summary>
    /// The timeout for the request.
    /// </summary>
    public TimeSpan Timeout { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    } = TimeSpan.FromMilliseconds(30000);

    private void SetBaseUrl(string value)
    {
        _baseUrl = value;
        IsBaseUrlExplicitlySet = true;
    }

    /// <summary>
    /// Clones this and returns a new instance
    /// </summary>
    internal ClientOptions Clone()
    {
        return new ClientOptions(this);
    }
}
