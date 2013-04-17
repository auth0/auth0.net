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
        public void can_get_social_users_with_search()
        {
            var email = "TODO@gmail.com";
            var users = client.GetSocialUsers(email);
            users.Count().Should().Be.EqualTo(1);
            
            var first = users.First();
            first.Email.Should().Be.EqualTo(email);
            first.FamilyName.Should().Not.Be.NullOrEmpty();
            first.UserId.Should().Not.Be.NullOrEmpty();
            first.Identities.Should().Not.Be.Empty();
            first.Identities.First().AccessToken.Should().Not.Be.Empty();
            first.GivenName.Should().Not.Be.NullOrEmpty();
        }

        [Test]
        public void can_get_enterprise_users()
        {
            var users = client.GetEnterpriseUsers();
            var first = users.First();

            first.FamilyName.Should().Not.Be.NullOrEmpty();
            first.UserId.Should().Not.Be.NullOrEmpty();
            first.Identities.Should().Not.Be.Empty();
            first.Identities.First().AccessToken.Should().Not.Be.Empty();
            first.GivenName.Should().Not.Be.NullOrEmpty();
        }

        [Test]
        public void can_get_enterprise_users_with_search()
        {
            var email = "TODO@contoso.com";
            var users = client.GetEnterpriseUsers(email);
            users.Count().Should().Be.EqualTo(1);

            var first = users.First();
            first.Email.Should().Be.EqualTo(email);
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
