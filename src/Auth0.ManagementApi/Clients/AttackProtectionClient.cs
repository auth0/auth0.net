using Auth0.ManagementApi.Models.AttackProtection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    public class AttackProtectionClient : BaseClient, IAttackProtectionClient
    {
        private const string AttackProtectionBasePath = "attack-protection";
        private const string SuspiciousIpThrottlingPath = "suspicious-ip-throttling";
        private const string BreachedPasswordDetection = "breached-password-detection";
        private const string BruteForceProtection = "brute-force-protection";

        public AttackProtectionClient(IManagementConnection connection, Uri baseUri,
            IDictionary<string, string> defaultHeaders) : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <summary>
        /// Get the suspicious IP throttling configuration.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="SuspiciousIpThrottling"/> containing the configuration.</returns>
        public Task<SuspiciousIpThrottling> GetSuspiciousIpThrottlingAsync(
            CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<SuspiciousIpThrottling>(
                BuildUri($"{AttackProtectionBasePath}/{SuspiciousIpThrottlingPath}"), DefaultHeaders,
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Update the suspicious IP throttling configuration.
        /// </summary>
        /// <param name="request">Specifies criteria to use when updating the configuration.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The <see cref="SuspiciousIpThrottling"/> that was updated.</returns>
        public Task<SuspiciousIpThrottling> UpdateSuspiciousIpThrottlingAsync(SuspiciousIpThrottling request,
            CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<SuspiciousIpThrottling>(new HttpMethod("PATCH"),
                BuildUri($"{AttackProtectionBasePath}/{SuspiciousIpThrottlingPath}"), request, DefaultHeaders,
                cancellationToken: cancellationToken);
        }


        /// <summary>
        /// Get breached password detection settings.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="BreachedPasswordDetection"/> containing the configuration.</returns>
        public Task<BreachedPasswordDetection> GetBreachedPasswordDetectionAsync(
            CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<BreachedPasswordDetection>(
                BuildUri($"{AttackProtectionBasePath}/{BreachedPasswordDetection}"), DefaultHeaders,
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Update breached password detection settings.
        /// </summary>
        /// <param name="request">Specifies criteria to use when updating the configuration.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The <see cref="BreachedPasswordDetection"/> that was updated.</returns>
        public Task<BreachedPasswordDetection> UpdateBreachedPasswordDetectionAsync(BreachedPasswordDetection request,
            CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<BreachedPasswordDetection>(new HttpMethod("PATCH"),
                BuildUri($"{AttackProtectionBasePath}/{BreachedPasswordDetection}"), request, DefaultHeaders,
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Get the brute force configuration.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="BruteForceProtection"/> containing the configuration.</returns>
        public Task<BruteForceProtection> GetBruteForceProtectionAsync(CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<BruteForceProtection>(
                BuildUri($"{AttackProtectionBasePath}/{BruteForceProtection}"), DefaultHeaders,
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Update the brute force configuration.
        /// </summary>
        /// <param name="request">Specifies criteria to use when updating the configuration.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The <see cref="BruteForceProtection"/> that was updated.</returns>
        public Task<BruteForceProtection> UpdateBruteForceProtectionAsync(BruteForceProtection request,
            CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<BruteForceProtection>(new HttpMethod("PATCH"),
                BuildUri($"{AttackProtectionBasePath}/{BruteForceProtection}"), request, DefaultHeaders,
                cancellationToken: cancellationToken);
        }
    }
}
