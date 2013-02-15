using System;
using System.Collections.Generic;
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
        [SetUp]
        public void setup() 
        {
            auth0Client = new Auth0Client(ConfigurationManager.AppSettings["AUTH0_CLIENT_ID"],
                                          ConfigurationManager.AppSettings["AUTH0_CLIENT_SECRET"],
                                          ConfigurationManager.AppSettings["AUTH0_CLIENT_DOMAIN"]);
        }

        [Test]
        public void can_get_connections()
        {
            var result = auth0Client.GetConnections();
            var gc = result.First();
            gc.Name.Should().Be.EqualTo("google-oauth2");
            gc.Strategy.Should().Be.EqualTo("google-oauth2");
        }
    }
}
