using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Auth0.Net;
using System.Configuration;
using SharpTestsEx;

namespace Auth0.Net_tests
{
    [TestFixture]
    public class ConnectionTests
    {
        private Auth0Client auth0Client;

        [TestFixtureSetUp]
        public void setup() 
        {
            auth0Client = new Auth0Client(ConfigurationManager.AppSettings["AUTH0_CLIENT_ID"],
                                          ConfigurationManager.AppSettings["AUTH0_CLIENT_SECRET"],
                                          ConfigurationManager.AppSettings["AUTH0_CLIENT_DOMAIN"]);

            auth0Client.DeleteConnection("testconn");
        }

        [Test]
        public void can_get_connections()
        {
            var result = auth0Client.GetConnections();
            var gc = result.First();
            gc.Name.Should().Be.EqualTo("google-oauth2");
            gc.Strategy.Should().Be.EqualTo("google-oauth2");
        }

        [Test]
        public void can_get_social_connections()
        {
            var result = auth0Client.GetConnections();
            var gc = result.First();
            gc.Name.Should().Be.EqualTo("google-oauth2");
            gc.Strategy.Should().Be.EqualTo("google-oauth2");
        }

        [Test]
        public void can_create_connection()
        {
            var ticket = new Auth0Connection (
                name: "testconn",
                strategy: "google-apps",
                tenantDomain: "kluglabs.com"
            );

            var connection = auth0Client.CreateConnection(ticket);

            connection.ProvisioningTicketUrl.Should().Not.Be.Null();
        }

    }
}
