using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Auth0;
using System.Configuration;
using SharpTestsEx;

namespace Auth0.Net_tests
{
    [TestFixture]
    public class UsersTests
    {
        private Client client;

        [TestFixtureSetUp]
        public void Setup() 
        {
            client = new Client(ConfigurationManager.AppSettings["AUTH0_CLIENT_ID"],
                                          ConfigurationManager.AppSettings["AUTH0_CLIENT_SECRET"],
                                          ConfigurationManager.AppSettings["AUTH0_CLIENT_DOMAIN"]);
        }

        [Test]
        public void can_get_users_by_connection()
        {
            var users = client.GetUsersByConnection("google-oauth2");
            var first = users.First();

            first.FamilyName.Should().Not.Be.NullOrEmpty();
            first.UserId.Should().Not.Be.NullOrEmpty();
            first.Identities.Should().Not.Be.Empty();
            first.Identities.First().AccessToken.Should().Not.Be.Empty();
            first.GivenName.Should().Not.Be.NullOrEmpty();
        }

        [Test]
        public void can_get_social_users()
        {
            var users = client.GetSocialUsers();
            var first = users.First();

            first.FamilyName.Should().Not.Be.NullOrEmpty();
            first.UserId.Should().Not.Be.NullOrEmpty();
            first.Identities.Should().Not.Be.Empty();
            first.Identities.First().AccessToken.Should().Not.Be.Empty();
            first.GivenName.Should().Not.Be.NullOrEmpty();
        }

        [Test]
        public void exchange_auth_code_with_wrong_code()
        {
            Assert.Throws<OAuthException>(() =>
                client.ExchangeAuthorizationCodePerAccessToken("httiadisad", "http://localhost/callback")
            ).Message.Should().Be.EqualTo("invalid code");

        }
    }
}
