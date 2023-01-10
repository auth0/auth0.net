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

        public string GenerateToken(string issuer, string audience, string sub)
        {
            var signingCredentials = new SigningCredentials(securityKey, algorithm);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = CreateSecurityTokenDescriptor(issuer, audience, sub, signingCredentials);

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private static SecurityTokenDescriptor CreateSecurityTokenDescriptor(string issuer, string audience, string sub, SigningCredentials signingCredentials)
        {
            return new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, sub),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddSeconds(180),
                Issuer = issuer,
                Audience = audience,

                SigningCredentials = signingCredentials
            };
        }
    }
}
