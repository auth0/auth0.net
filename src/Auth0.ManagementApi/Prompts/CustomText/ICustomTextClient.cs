using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Prompts;

public partial interface ICustomTextClient
{
    /// <summary>
    /// Retrieve custom text for a specific prompt and language.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> GetAsync(
        PromptGroupNameEnum prompt,
        PromptLanguageEnum language,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Set custom text for a specific prompt. Existing texts will be overwritten.
    /// </summary>
    Task SetAsync(
        PromptGroupNameEnum prompt,
        PromptLanguageEnum language,
        Dictionary<string, object?> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
