namespace Auth0.ManagementApi.AttackProtection;

public partial interface IAttackProtectionClient
{
    public IBotDetectionClient BotDetection { get; }
    public IBreachedPasswordDetectionClient BreachedPasswordDetection { get; }
    public IBruteForceProtectionClient BruteForceProtection { get; }
    public ICaptchaClient Captcha { get; }
    public ISuspiciousIpThrottlingClient SuspiciousIpThrottling { get; }
}
