using Auth0.ManagementApi.Prompts;

namespace Auth0.ManagementApi;

public partial interface IPromptsClient
{
    public IRenderingClient Rendering { get; }
    public Auth0.ManagementApi.Prompts.ICustomTextClient CustomText { get; }
    public IPartialsClient Partials { get; }

    /// <summary>
    /// Retrieve details of the Universal Login configuration of your tenant. This includes the <a href="https://auth0.com/docs/authenticate/login/auth0-universal-login/identifier-first">Identifier First Authentication</a> and <a href="https://auth0.com/docs/secure/multi-factor-authentication/fido-authentication-with-webauthn/configure-webauthn-device-biometrics-for-mfa">WebAuthn with Device Biometrics for MFA</a> features.
    /// </summary>
    WithRawResponseTask<GetSettingsResponseContent> GetSettingsAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the Universal Login configuration of your tenant. This includes the <a href="https://auth0.com/docs/authenticate/login/auth0-universal-login/identifier-first">Identifier First Authentication</a> and <a href="https://auth0.com/docs/secure/multi-factor-authentication/fido-authentication-with-webauthn/configure-webauthn-device-biometrics-for-mfa">WebAuthn with Device Biometrics for MFA</a> features.
    /// </summary>
    WithRawResponseTask<UpdateSettingsResponseContent> UpdateSettingsAsync(
        UpdateSettingsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
