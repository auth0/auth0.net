using Auth0.ManagementApi;

namespace Auth0.ManagementApi.AttackProtection;

public partial interface ICaptchaClient
{
    /// <summary>
    /// Get the CAPTCHA configuration for your client.
    /// </summary>
    WithRawResponseTask<GetAttackProtectionCaptchaResponseContent> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update existing CAPTCHA configuration for your client.
    /// </summary>
    WithRawResponseTask<UpdateAttackProtectionCaptchaResponseContent> UpdateAsync(
        UpdateAttackProtectionCaptchaRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
