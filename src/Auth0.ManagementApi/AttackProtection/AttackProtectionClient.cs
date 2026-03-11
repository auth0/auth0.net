using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.AttackProtection;

public partial class AttackProtectionClient : IAttackProtectionClient
{
    private readonly RawClient _client;

    internal AttackProtectionClient(RawClient client)
    {
        _client = client;
        BotDetection = new BotDetectionClient(_client);
        BreachedPasswordDetection = new BreachedPasswordDetectionClient(_client);
        BruteForceProtection = new BruteForceProtectionClient(_client);
        Captcha = new CaptchaClient(_client);
        SuspiciousIpThrottling = new SuspiciousIpThrottlingClient(_client);
    }

    public IBotDetectionClient BotDetection { get; }

    public IBreachedPasswordDetectionClient BreachedPasswordDetection { get; }

    public IBruteForceProtectionClient BruteForceProtection { get; }

    public ICaptchaClient Captcha { get; }

    public ISuspiciousIpThrottlingClient SuspiciousIpThrottling { get; }
}
