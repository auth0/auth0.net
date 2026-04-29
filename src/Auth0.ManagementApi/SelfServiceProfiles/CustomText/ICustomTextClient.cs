using Auth0.ManagementApi;

namespace Auth0.ManagementApi.SelfServiceProfiles;

public partial interface ICustomTextClient
{
    /// <summary>
    /// Retrieves text customizations for a given self-service profile, language and Self-Service Enterprise Configuration flow page.
    /// </summary>
    WithRawResponseTask<Dictionary<string, string>> ListAsync(
        string id,
        SelfServiceProfileCustomTextLanguageEnum language,
        SelfServiceProfileCustomTextPageEnum page,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates text customizations for a given self-service profile, language and Self-Service Enterprise Configuration flow page.
    /// </summary>
    WithRawResponseTask<Dictionary<string, string>> SetAsync(
        string id,
        SelfServiceProfileCustomTextLanguageEnum language,
        SelfServiceProfileCustomTextPageEnum page,
        Dictionary<string, string> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
