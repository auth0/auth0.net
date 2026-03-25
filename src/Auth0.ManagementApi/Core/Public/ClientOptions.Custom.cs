using System.Text;
using System.Text.Json;

namespace Auth0.ManagementApi;

public partial class ClientOptions
{
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
