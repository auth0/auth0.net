using System;
using System.Linq;
using NUnit.Framework;
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
        public void can_get_users_by_connection_with_search()
        {
            var connection = "google-oauth2";
            var allUsers = client.GetUsersByConnection(connection);

            var email = allUsers.First().Email;
            var users = client.GetUsersByConnection(connection, email);

            // There may be more than one search result, just make sure it filtered to only this user
            users.All(u => u.Email == email).Should().Be.True();

            var first = users.First();
            first.Email.Should().Be.EqualTo(email);
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
            var allUsers = client.GetSocialUsers();

            var email = allUsers.First().Email;
            var users = client.GetSocialUsers(email);
            
            // There may be more than one search result, just make sure it filtered to only this user
            users.All(u => u.Email == email).Should().Be.True();
            
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
            var allUsers = client.GetEnterpriseUsers();

            var email = allUsers.First().Email;
            var users = client.GetEnterpriseUsers(email);

            // There may be more than one search result, just make sure it filtered to only this user
            users.All(u => u.Email == email).Should().Be.True();

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

        [Test]
        public void can_get_enterprise_users_pages()
        {
            var users = client.GetEnterpriseUsers(2);

            users.HasNextPage.Should().Be.True();
            users.GetNextPage().Count().Should().Be.GreaterThan(0);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        public void can_get_enterprise_users_using_different_size_pages(int pageSize)
        {
            var users = client.GetEnterpriseUsers(pageSize);

            users.Count().Should().Be.EqualTo(pageSize);
        }

        [Test]
        public void can_use_autopaged_to_enumerate_all_enterprise_users()
        {
            var users = client.GetEnterpriseUsers(2);
            var count = users.AutoPaged().Count();

            count.Should().Be.GreaterThan(2);
            // Ensure same user not returned twice
            users.AutoPaged().Select(u => u.GetHashCode()).Distinct().Count().Should().Be.EqualTo(count);
        }

        [Test]
        public void can_get_social_users_pages()
        {
            var users = client.GetSocialUsers(2);

            users.HasNextPage.Should().Be.True();
            users.GetNextPage().Count().Should().Be.GreaterThan(0);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        public void can_get_social_users_using_different_size_pages(int pageSize)
        {
            var users = client.GetSocialUsers(pageSize);

            users.Count().Should().Be.EqualTo(pageSize);
        }

        [Test]
        public void can_use_autopaged_to_enumerate_all_social_users()
        {
            var users = client.GetSocialUsers(20);
            var count = users.AutoPaged().Count();

            count.Should().Be.GreaterThan(20);
            // Ensure same user not returned twice
            users.AutoPaged().Select(u => u.GetHashCode()).Distinct().Count().Should().Be.EqualTo(count);
        }

        [Test]
        public void can_get_enterprise_users_by_connection_pages()
        {
            var users = client.GetUsersByConnection("google-oauth2", 2);

            users.HasNextPage.Should().Be.True();
            users.GetNextPage().Count().Should().Be.GreaterThan(0);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        public void can_get_enterprise_users_by_connection_using_different_size_pages(int pageSize)
        {
            var users = client.GetUsersByConnection("google-oauth2", pageSize);

            users.Count().Should().Be.EqualTo(pageSize);
        }

        [Test]
        public void can_use_autopaged_to_enumerate_all_enterprise_users_by_connection()
        {
            var users = client.GetUsersByConnection("google-oauth2", 2);
            var count = users.AutoPaged().Count();

            count.Should().Be.GreaterThan(2);
            // Ensure same user not returned twice
            users.AutoPaged().Select(u => u.GetHashCode()).Distinct().Count().Should().Be.EqualTo(count);
        }
    }
}
