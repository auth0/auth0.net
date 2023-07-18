using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Auth0.AuthenticationApi.Tokens
{
    /// <summary>
    /// Perform validation of an ID token in compliance with specified <see cref="IdTokenRequirements"/>.
    /// </summary>
    internal static class IdTokenClaimValidator
    {
        /// <summary>
        /// Assert that all the claims within a <see cref="JwtSecurityToken"/> meet the specified <see cref="IdTokenRequirements"/> for a given point in time.
        /// </summary>
        /// <param name="required"><see cref="IdTokenRequirements"/> that should be asserted.</param>
        /// <param name="token"><see cref="JwtSecurityToken"/> to assert requirements against.</param>
        /// <param name="pointInTime"><see cref="DateTime"/> to act as "Now" when asserting time-based claims.</param>
        /// <exception cref="IdTokenValidationException">Exception thrown if <paramref name="token"/> fails to
        /// meet the requirements specified by <paramref name="required"/>.
        /// </exception>
        public static void AssertClaimsMeetRequirements(IdTokenRequirements required, JwtSecurityToken token, DateTime? pointInTime = null)
        {
            var epochNow = EpochTime.GetIntDate(pointInTime ?? DateTime.Now);

            // Issuer
            if (string.IsNullOrWhiteSpace(token.Issuer))
                throw new IdTokenValidationException("Issuer (iss) claim must be a string present in the ID token.");
            if (token.Issuer != required.Issuer)
                throw new IdTokenValidationException($"Issuer (iss) claim mismatch in the ID token; expected \"{required.Issuer}\", found \"{token.Issuer}\".");

            // Subject
            if (string.IsNullOrWhiteSpace(token.Subject))
                throw new IdTokenValidationException("Subject (sub) claim must be a string present in the ID token.");

            // Audience
            var audienceCount = token.Audiences.Count();
            if (audienceCount == 0)
                throw new IdTokenValidationException("Audience (aud) claim must be a string or array of strings present in the ID token.");
            if (!token.Audiences.Contains(required.Audience))
                throw new IdTokenValidationException($"Audience (aud) claim mismatch in the ID token; expected \"{required.Audience}\" but was not one of \"" +
                    $"{String.Join(", ", token.Audiences)}\".");

            {
                // Expires at
                var exp = GetEpoch(token.Claims, JwtRegisteredClaimNames.Exp);
                if (exp == null)
                    throw new IdTokenValidationException("Expiration Time (exp) claim must be an integer present in the ID token.");
                var expiration = exp + required.Leeway.TotalSeconds;
                if (epochNow >= expiration)
                    throw new IdTokenValidationException($"Expiration Time (exp) claim error in the ID token; current time ({epochNow}) is after expiration time ({exp}).");
            }

            // Issued at
            var iat = GetEpoch(token.Claims, JwtRegisteredClaimNames.Iat);
            if (iat == null)
                throw new IdTokenValidationException("Issued At (iat) claim must be an integer present in the ID token.");

            // Nonce
            if (required.Nonce != null)
            {
                if (string.IsNullOrWhiteSpace(token.Payload.Nonce))
                    throw new IdTokenValidationException("Nonce (nonce) claim must be a string present in the ID token.");
                if (token.Payload.Nonce != required.Nonce)
                    throw new IdTokenValidationException($"Nonce (nonce) claim mismatch in the ID token; expected \"{required.Nonce}\", found \"{token.Payload.Nonce}\".");
            }

            // Authorized Party
            if (audienceCount > 1)
            {
                if (string.IsNullOrWhiteSpace(token.Payload.Azp))
                    throw new IdTokenValidationException("Authorized Party (azp) claim must be a string present in the ID token when Audiences (aud) claim has multiple values.");
                if (token.Payload.Azp != required.Audience)
                    throw new IdTokenValidationException($"Authorized Party (azp) claim mismatch in the ID token; expected \"{required.Audience}\", found \"{token.Payload.Azp}\".");
            }

            // Authentication time
            if (required.MaxAge.HasValue)
            {
                var authTime = GetEpoch(token.Claims, JwtRegisteredClaimNames.AuthTime);
                if (!authTime.HasValue)
                    throw new IdTokenValidationException("Authentication Time (auth_time) claim must be an integer present in the ID token when MaxAge specified.");

                var authValidUntil = (long)(authTime + required.MaxAge.Value.TotalSeconds + required.Leeway.TotalSeconds);

                if (epochNow > authValidUntil)
                    throw new IdTokenValidationException($"Authentication Time (auth_time) claim in the ID token indicates that too much time has passed since the last end-user authentication. Current time ({epochNow}) is after last auth at {authValidUntil}.");
            }

            // Organization
            if (!string.IsNullOrWhiteSpace(required.Organization))
            {
                var organizationClaim = required.Organization.StartsWith("org_") ? Auth0ClaimNames.OrganizationId : Auth0ClaimNames.OrganizationName;
                var organization = GetClaimValue(token.Claims, organizationClaim);
                var expectedOrganization = organizationClaim == Auth0ClaimNames.OrganizationName ? required.Organization.ToLower() : required.Organization;

                if (string.IsNullOrWhiteSpace(organization))
                    throw new IdTokenValidationException($"Organization claim ({organizationClaim}) must be a string present in the ID token.");
                if (organization != expectedOrganization)
                    throw new IdTokenValidationException($"Organization claim ({organizationClaim}) mismatch in the ID token; expected \"{expectedOrganization}\", found \"{organization}\".");
            }

        }

        /// <summary>
        /// Get a epoch (Unix time) value for a given claim.
        /// </summary>
        /// <param name="claims"><see cref="IEnumerable{Claim}"/>Claims to search the <paramref name="claimType"/> for.</param>
        /// <param name="claimType">Type of claim to search the <paramref name="claims"/> for.  See <see cref="JwtRegisteredClaimNames"/> for possible names.</param>
        /// <returns>Nullable <see cref="long"/> containing the value containing the epoch value or <see langword="null"/> if no matching value was found.</returns>
        private static long? GetEpoch(IEnumerable<Claim> claims, string claimType)
        {
            var claim = claims.FirstOrDefault(t => t.Type == claimType);
            if (claim == null) return null;

            return (long)Convert.ToDouble(claim.Value, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Get the value for a given claim.
        /// </summary>
        /// <param name="claims"><see cref="IEnumerable{Claim}"/>Claims to search the <paramref name="claimType"/> for.</param>
        /// <param name="claimType">Type of claim to search the <paramref name="claims"/> for. See <see cref="JwtRegisteredClaimNames"/> or <see cref="Auth0ClaimNames"/> for possible names.</param>
        /// <returns><see cref="string"/> containing the value or <see langword="null"/> if no matching value was found.</returns>
        private static string GetClaimValue(IEnumerable<Claim> claims, string claimType)
        {
            var claim = claims.SingleOrDefault(t => t.Type == claimType);
            if (claim == null) return null;

            return claim.Value;
        }
    }
}
