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
    public class ConnectionTests
    {
        private Client client;

        [TestFixtureSetUp]
        public void setup() 
        {
            client = new Client(ConfigurationManager.AppSettings["AUTH0_CLIENT_ID"],
                                          ConfigurationManager.AppSettings["AUTH0_CLIENT_SECRET"],
                                          ConfigurationManager.AppSettings["AUTH0_CLIENT_DOMAIN"]);

            client.DeleteConnection("testconn");
        }

        [Test]
        public void can_get_connections()
        {
            var result = client.GetConnections();
            var gc = result.First();
            gc.Name.Should().Be.EqualTo("google-oauth2");
            gc.Strategy.Should().Be.EqualTo("google-oauth2");
        }

        [Test]
        public void can_get_social_connections()
        {
            var result = client.GetConnections();
            var gc = result.First();
            gc.Name.Should().Be.EqualTo("google-oauth2");
            gc.Strategy.Should().Be.EqualTo("google-oauth2");
        }

        [Test]
        public void can_create_connection()
        {
            var ticket = new Connection (
                name: "testconn",
                strategy: "google-apps",
                tenantDomain: "kluglabs.com"
            );

            var connection = client.CreateConnection(ticket);

            connection.ProvisioningTicketUrl.Should().Not.Be.Null();
        }

    }
}
