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
    /// Overwrite all configuration details of the multi-factor authentication APNS provider associated with your tenant.
    /// </summary>
    WithRawResponseTask<SetGuardianFactorsProviderPushNotificationApnsResponseContent> SetApnsProviderAsync(
        SetGuardianFactorsProviderPushNotificationApnsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Modify configuration details of the multi-factor authentication APNS provider associated with your tenant.
    /// </summary>
    WithRawResponseTask<UpdateGuardianFactorsProviderPushNotificationApnsResponseContent> UpdateApnsProviderAsync(
        UpdateGuardianFactorsProviderPushNotificationApnsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Overwrite all configuration details of the multi-factor authentication FCM provider associated with your tenant.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> SetFcmProviderAsync(
        SetGuardianFactorsProviderPushNotificationFcmRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Modify configuration details of the multi-factor authentication FCM provider associated with your tenant.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> UpdateFcmProviderAsync(
        UpdateGuardianFactorsProviderPushNotificationFcmRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Overwrite all configuration details of the multi-factor authentication FCMV1 provider associated with your tenant.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> SetFcmv1ProviderAsync(
        SetGuardianFactorsProviderPushNotificationFcmv1RequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Modify configuration details of the multi-factor authentication FCMV1 provider associated with your tenant.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> UpdateFcmv1ProviderAsync(
        UpdateGuardianFactorsProviderPushNotificationFcmv1RequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve configuration details for an AWS SNS push notification provider that has been enabled for MFA. To learn more, review <see href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors/configure-push-notifications-for-mfa">Configure Push Notifications for MFA</see>.
    /// </summary>
    WithRawResponseTask<GetGuardianFactorsProviderSnsResponseContent> GetSnsProviderAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Configure the <see href="https://auth0.com/docs/multifactor-authentication/developer/sns-configuration">AWS SNS push notification provider configuration</see> (subscription required).
    /// </summary>
    WithRawResponseTask<SetGuardianFactorsProviderPushNotificationSnsResponseContent> SetSnsProviderAsync(
        SetGuardianFactorsProviderPushNotificationSnsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Configure the <see href="https://auth0.com/docs/multifactor-authentication/developer/sns-configuration">AWS SNS push notification provider configuration</see> (subscription required).
    /// </summary>
    WithRawResponseTask<UpdateGuardianFactorsProviderPushNotificationSnsResponseContent> UpdateSnsProviderAsync(
        UpdateGuardianFactorsProviderPushNotificationSnsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Modify the push notification provider configured for your tenant. For more information, review <see href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors/configure-push-notifications-for-mfa">Configure Push Notifications for MFA</see>.
    /// </summary>
    WithRawResponseTask<GetGuardianFactorsProviderPushNotificationResponseContent> GetSelectedProviderAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Modify the push notification provider configured for your tenant. For more information, review <see href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors/configure-push-notifications-for-mfa">Configure Push Notifications for MFA</see>.
    /// </summary>
    WithRawResponseTask<SetGuardianFactorsProviderPushNotificationResponseContent> SetProviderAsync(
        SetGuardianFactorsProviderPushNotificationRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
