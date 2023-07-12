using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Auth0.AuthenticationApi
{
    internal class JwtTokenFactory
    {
        private readonly SecurityKey securityKey;
        private readonly string algorithm;

        public JwtTokenFactory(SecurityKey securityKey, string algorithm)
        {
            this.securityKey = securityKey;
            this.algorithm = algorithm;
        }

        public string GenerateToken(string issuer, string audience, string sub, IList<Claim> additionalClaims = null)
        {
            var signingCredentials = new SigningCredentials(securityKey, algorithm);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = CreateSecurityTokenDescriptor(issuer, audience, sub, signingCredentials, additionalClaims);

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private static SecurityTokenDescriptor CreateSecurityTokenDescriptor(string issuer, string audience, string sub, SigningCredentials signingCredentials, IList<Claim> additionalClaims = null)
        {
            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub, sub),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.AuthTime, DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds.ToString()),
            };

            if (additionalClaims != null)
            {
                claims.AddRange(additionalClaims);
            }

            return new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddSeconds(180),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = signingCredentials
            };
        }
    }
}
