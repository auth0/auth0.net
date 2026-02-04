using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Guardian.Factors;

public partial interface IPushNotificationClient
{
    /// <summary>
    /// Retrieve configuration details for the multi-factor authentication APNS provider associated with your tenant.
    /// </summary>
    WithRawResponseTask<GetGuardianFactorsProviderApnsResponseContent> GetApnsProviderAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Modify configuration details of the multi-factor authentication APNS provider associated with your tenant.
    /// </summary>
    WithRawResponseTask<SetGuardianFactorsProviderPushNotificationApnsResponseContent> SetApnsProviderAsync(
        SetGuardianFactorsProviderPushNotificationApnsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Modify configuration details of the multi-factor authentication FCM provider associated with your tenant.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> SetFcmProviderAsync(
        SetGuardianFactorsProviderPushNotificationFcmRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Modify configuration details of the multi-factor authentication FCMV1 provider associated with your tenant.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> SetFcmv1ProviderAsync(
        SetGuardianFactorsProviderPushNotificationFcmv1RequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve configuration details for an AWS SNS push notification provider that has been enabled for MFA. To learn more, review <a href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors/configure-push-notifications-for-mfa">Configure Push Notifications for MFA</a>.
    /// </summary>
    WithRawResponseTask<GetGuardianFactorsProviderSnsResponseContent> GetSnsProviderAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Configure the <a href="https://auth0.com/docs/multifactor-authentication/developer/sns-configuration">AWS SNS push notification provider configuration</a> (subscription required).
    /// </summary>
    WithRawResponseTask<SetGuardianFactorsProviderPushNotificationSnsResponseContent> SetSnsProviderAsync(
        SetGuardianFactorsProviderPushNotificationSnsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Configure the <a href="https://auth0.com/docs/multifactor-authentication/developer/sns-configuration">AWS SNS push notification provider configuration</a> (subscription required).
    /// </summary>
    WithRawResponseTask<UpdateGuardianFactorsProviderPushNotificationSnsResponseContent> UpdateSnsProviderAsync(
        UpdateGuardianFactorsProviderPushNotificationSnsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Modify the push notification provider configured for your tenant. For more information, review <a href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors/configure-push-notifications-for-mfa">Configure Push Notifications for MFA</a>.
    /// </summary>
    WithRawResponseTask<GetGuardianFactorsProviderPushNotificationResponseContent> GetSelectedProviderAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Modify the push notification provider configured for your tenant. For more information, review <a href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors/configure-push-notifications-for-mfa">Configure Push Notifications for MFA</a>.
    /// </summary>
    WithRawResponseTask<SetGuardianFactorsProviderPushNotificationResponseContent> SetProviderAsync(
        SetGuardianFactorsProviderPushNotificationRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
