using System;
using System.Configuration;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Auth0.ManagementApi.Client.FunctionalTests
{
    [TestFixture]
    [Ignore("Correct token not created")]
    public class BlacklistTests : TestBase
    {
        [Test]
        public async Task Test_blacklist_sequence()
        {
            // Generate a token to 
            string apiKey = GetVariable("AUTH0_API_KEY");
            string apiSecret = GetVariable("AUTH0_API_SECRET");

            var a = new
            {
                scopes = new
                {
                    actions = new string[] {"read"}
                }
            };
            string test = JsonConvert.SerializeObject(a);

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                        new Claim("aud", apiKey),
                        //new Claim("scopes", "{ \"clients\" : \"actions\" [ \"read\"]}"),
                        new Claim("scopes", test),
                        new Claim("jti", Guid.NewGuid().ToString("N"))
                    }),
                TokenIssuerName = "jerriep.auth0.com",
                Lifetime = new Lifetime(now, now.AddMinutes(10)),
                SigningCredentials = new SigningCredentials(
                            new InMemorySymmetricSecurityKey(TextEncodings.Base64Url.Decode(apiSecret)),
                            "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256",
                            "http://www.w3.org/2001/04/xmlenc#sha256"),
            };

            // Redirect back to Auth0.
            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(tokenDescriptor);
            string token = handler.WriteToken(securityToken);

            var apiClient = new ManagementApiClient(token, new Uri(GetVariable("AUTH0_API_URL")));
            var clients = await apiClient.Clients.GetAll();

        }
    }
}