using Auth0.ManagementApi;
using Auth0.ManagementApi.Guardian.Factors;
using Auth0.ManagementApi.Guardian.Factors.Duo;

namespace Auth0.ManagementApi.Guardian;

public partial interface IFactorsClient
{
    public Auth0.ManagementApi.Guardian.Factors.IPhoneClient Phone { get; }
    public IPushNotificationClient PushNotification { get; }
    public ISmsClient Sms { get; }
    public IDuoClient Duo { get; }

    /// <summary>
    /// Retrieve details of all <see href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors">multi-factor authentication factors</see> associated with your tenant.
    /// </summary>
    WithRawResponseTask<IEnumerable<GuardianFactor>> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the status (i.e., enabled or disabled) of a specific multi-factor authentication factor.
    /// </summary>
    WithRawResponseTask<SetGuardianFactorResponseContent> SetAsync(
        GuardianFactorNameEnum name,
        SetGuardianFactorRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
