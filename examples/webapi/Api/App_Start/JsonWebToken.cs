namespace Api.App_Start
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Web.Script.Serialization;

    public static class JsonWebToken
    {
        private const string NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
        private const string RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
        private const string ActorClaimType = "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/actor";
        private const string DefaultIssuer = "LOCAL AUTHORITY";
        private const string StringClaimValueType = "http://www.w3.org/2001/XMLSchema#string";

        // sort claim types by relevance
        private static string[] claimTypesForUserName = new string[] { "name", "email", "user_id", "sub" };
        private static string[] claimsToExclude = new string[] { "iss", "sub", "aud", "exp", "iat", "identities" };

        private static JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

        public static ClaimsPrincipal ValidateToken(string token, string secretKey, string audience = null, bool checkExpiration = false, string issuer = null)
        {
            var payloadJson = JWT.JsonWebToken.Decode(token, Convert.FromBase64String(secretKey), verify: true);
            var payloadData = jsonSerializer.Deserialize<Dictionary<string, object>>(payloadJson);

            // audience check
            object aud;
            if (!string.IsNullOrEmpty(audience) && payloadData.TryGetValue("aud", out aud))
            {
                if (!aud.ToString().Equals(audience, StringComparison.Ordinal))
                {
                    throw new TokenValidationException(string.Format("Audience mismatch. Expected: '{0}' and got: '{1}'", audience, aud));
                }
            }

            // expiration check
            object exp;
            if (checkExpiration && payloadData.TryGetValue("exp", out exp))
            {
                DateTime validTo = FromUnixTime(long.Parse(exp.ToString()));
                if (DateTime.Compare(validTo, DateTime.UtcNow) <= 0)
                {
                    throw new TokenValidationException(
                        string.Format("Token is expired. Expiration: '{0}'. Current: '{1}'", validTo, DateTime.UtcNow));
                }
            }

            // issuer check
            object iss;
            if (payloadData.TryGetValue("iss", out iss))
            {
                if (!string.IsNullOrEmpty(issuer))
                {
                    if (!iss.ToString().Equals(issuer, StringComparison.Ordinal))
                    {
                        throw new TokenValidationException(string.Format("Token issuer mismatch. Expected: '{0}' and got: '{1}'", issuer, iss));
                    }
                }
                else
                {
                    // if issuer is not specified, set issuer with jwt[iss]
                    issuer = iss.ToString();
                }
            }

            return new ClaimsPrincipal(ClaimsIdentityFromJwt(payloadData, issuer));
        }

        private static List<Claim> ClaimsFromJwt(IDictionary<string, object> jwtData, string issuer)
        {
            var list = new List<Claim>();
            issuer = issuer ?? DefaultIssuer;

            foreach (KeyValuePair<string, object> pair in jwtData)
            {
                var claimType = pair.Key;
                var source = pair.Value as ArrayList;

                if (source != null)
                {
                    foreach (var item in source)
                    {
                        list.Add(new Claim(claimType, item.ToString(), StringClaimValueType, issuer, issuer));
                    }

                    continue;
                }

                var claim = new Claim(claimType, pair.Value.ToString(), StringClaimValueType, issuer, issuer);
                list.Add(claim);
            }

            // set claim for user name
            for (int i = 0; i < claimTypesForUserName.Length; i++)
            {
                if (list.Any(c => c.Type == claimTypesForUserName[i]))
                {
                    var nameClaim = new Claim(NameClaimType, list.First(c => c.Type == claimTypesForUserName[i]).Value, StringClaimValueType, issuer, issuer);
                    list.Add(nameClaim);
                    break;
                }
            }

            // dont include specific jwt claims
            return list.Where(c => !claimsToExclude.Any(t => t == c.Type)).ToList();
        }

        private static ClaimsIdentity ClaimsIdentityFromJwt(IDictionary<string, object> jwtData, string issuer)
        {
            var subject = new ClaimsIdentity("Federation", NameClaimType, RoleClaimType);
            var claims = ClaimsFromJwt(jwtData, issuer);

            foreach (Claim claim in claims)
            {
                var type = claim.Type;
                if (type == ActorClaimType)
                {
                    if (subject.Actor != null)
                    {
                        throw new InvalidOperationException(string.Format(
                            "Jwt10401: Only a single 'Actor' is supported. Found second claim of type: '{0}', value: '{1}'", new object[] { "actor", claim.Value }));
                    }

                    var claim2 = new Claim(type, claim.Value, claim.ValueType, issuer, issuer, subject);
                    subject.AddClaim(claim2);

                    continue;
                }

                var claim3 = new Claim(type, claim.Value, claim.ValueType, issuer, issuer, subject);
                subject.AddClaim(claim3);
            }

            return subject;
        }

        private static DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

        public class TokenValidationException : Exception
        {
            public TokenValidationException(string message)
                : base(message)
            {
            }
        }
    }
}
