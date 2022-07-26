namespace Auth0.ManagementApi.Clients
{
  using System.Threading;
  using System.Threading.Tasks;
  using Models.AttackProtection;

  public interface IAttackProtectionClient
  {
    /// <summary>
    /// Get the suspicious IP throttling configuration.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="SuspiciousIpThrottling"/> containing the configuration.</returns>
    Task<SuspiciousIpThrottling> GetSuspiciousIpThrottlingAsync(
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Update the suspicious IP throttling configuration.
    /// </summary>
    /// <param name="request">Specifies criteria to use when updating the configuration.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="SuspiciousIpThrottling"/> that was updated.</returns>
    Task<SuspiciousIpThrottling> UpdateSuspiciousIpThrottlingAsync(SuspiciousIpThrottling request,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Get breached password detection settings.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="BreachedPasswordDetection"/> containing the configuration.</returns>
    Task<BreachedPasswordDetection> GetBreachedPasswordDetectionAsync(
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Update breached password detection settings.
    /// </summary>
    /// <param name="request">Specifies criteria to use when updating the configuration.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="BreachedPasswordDetection"/> that was updated.</returns>
    Task<BreachedPasswordDetection> UpdateBreachedPasswordDetectionAsync(BreachedPasswordDetection request,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the brute force configuration.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="BruteForceProtection"/> containing the configuration.</returns>
    Task<BruteForceProtection> GetBruteForceProtectionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Update the brute force configuration.
    /// </summary>
    /// <param name="request">Specifies criteria to use when updating the configuration.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="BruteForceProtection"/> that was updated.</returns>
    Task<BruteForceProtection> UpdateBruteForceProtectionAsync(BruteForceProtection request,
      CancellationToken cancellationToken = default);
  }
}
