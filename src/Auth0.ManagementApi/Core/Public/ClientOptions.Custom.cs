using System.Text;
using System.Text.Json;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

public partial class ClientOptions
{
    private string? _customDomain;

    /// <summary>
    /// Sets the <c>Auth0-Custom-Domain</c> header value sent on Management API requests that
    /// generate user-facing links (email verification, password reset, invitations, etc.).
    ///
    /// <para>
    /// When set, the header is included in <em>every</em> outgoing request. To restrict the
    /// header to only the whitelisted endpoints and strip it from all others, also configure
    /// your <see cref="HttpClient"/> with a <see cref="CustomDomainInterceptor"/> handler:
    /// <code>
    /// new ClientOptions
    /// {
    ///     CustomDomain = "login.mycompany.com",
    ///     HttpClient   = new HttpClient(new CustomDomainInterceptor())
    /// }
    /// </code>
    /// </para>
    ///
    /// <para>
    /// If you are using <see cref="ManagementClient"/>, stripping is configured automatically
    /// when no custom <see cref="HttpClient"/> is provided - prefer that path.
    /// </para>
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when the value is non-null but empty or contains only whitespace.</exception>
    public string? CustomDomain
    {
        get => _customDomain;
#if NET5_0_OR_GREATER
        init
#else
        set
#endif
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                _customDomain = value;
                Headers[CustomDomainInterceptor.HeaderName] = value;
            }
            else if (value != null)
            {
                throw new ArgumentException(
                    "CustomDomain must not be empty or contain only whitespace.",
                    nameof(value));
            }
        }
    }

    public ClientOptions()
    {
        Headers["Auth0-Client"] = CreateAgentString();
    }

    private static string CreateAgentString()
    {
#if NET462
        var target = "NET462";
#elif NETSTANDARD2_0
        var target = "NETSTANDARD2.0";
#elif NET6_0
        var target = "NET6.0";
#elif NET7_0
        var target = "NET7.0";
#elif NET8_0
        var target = "NET8.0";
#elif NET9_0
        var target = "NET9.0";
#elif NET10_0
        var target = "NET10.0";
#else
        var target = "UNKNOWN";
#endif

        var agentJson = JsonSerializer.Serialize(new
        {
            name = "Auth0.Net",
            version = Version.Current,
            env = new { target }
        });
        return Base64UrlEncode(Encoding.UTF8.GetBytes(agentJson));
    }

    private static string Base64UrlEncode(byte[] input)
    {
        var output = Convert.ToBase64String(input);
        output = output.Replace('+', '-');  // 62nd char of encoding
        output = output.Replace('/', '_');  // 63rd char of encoding
        output = output.TrimEnd('=');       // Remove padding
        return output;
    }
}
