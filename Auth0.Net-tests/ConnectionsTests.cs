﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Auth0;
using System.Configuration;
using SharpTestsEx;
using Newtonsoft.Json;

namespace Auth0.Net_tests
{
    [TestFixture]
    public class ConnectionTests
    {
        private Client client;

        [SetUp]
        public void setup() 
        {
            client = new Client(ConfigurationManager.AppSettings["AUTH0_CLIENT_ID"],
                                          ConfigurationManager.AppSettings["AUTH0_CLIENT_SECRET"],
                                          ConfigurationManager.AppSettings["AUTH0_CLIENT_DOMAIN"]);

            client.DeleteConnection("testconn");
            client.DeleteConnection("new-testconn");
        }

        [Test, Ignore]
        public void test1234()
        {
            var client1 = new Client("",
                                    "",
                                    "");

            var socialConnections = client1.GetSocialConnections();
        }

        [Test]
        public void can_get_connections()
        {
            var result = client.GetConnections();
            result.ToList().Count.Should().Be.GreaterThan(0);
        }

        [Test]
        public void can_get_social_connections()
        {
            client.GetSocialConnections()
                .Select(c => c.Strategy)
                .Should().Contain("google-oauth2")
                        .And.Contain("github")
                        .And.Contain("amazon")
                        .And.Not.Contain("office365");
        }

        [Test]
        public void can_get_enterprise_connections()
        {
            var result = client.GetEnterpriseConnections();
            result.Select(c => c.Strategy)
                  .Should().Contain("office365").And.Contain("google-apps");
        }

        [Test]
        public void can_create_connection()
        {
            var ticket = new Connection(
                name: "testconn",
                strategy: "google-apps",
                tenantDomain: "kluglabs.com"
            );

            ticket.Enabled = false;

            var connection = client.CreateConnection(ticket);

            connection.ProvisioningTicketUrl.Should().Not.Be.Null();
            connection.Enabled.Should().Be.False();
        }

        [Test]
        public void when_creating_a_connection_with_invalid_domain_throw_exception()
        {
            var ticket = new Connection(
                    name: "testconn",
                    strategy: "google-apps",
                    tenantDomain: "desopilante.com"
                );

            ticket.Enabled = true;

            Assert.Throws<InvalidOperationException>(() => client.CreateConnection(ticket)).Message
                .Should().Be.EqualTo("Bad Request - desopilante.com is not a valid google apps domain");

        }

        [Test, Ignore("need to change to free tier")]
        public void when_creating_a_connection_exceeding_limit_throw_exception()
        {
            var ticket = new Connection(
                    name: "new-testconn",
                    strategy: "google-apps",
                    tenantDomain: "kluglabs.com"
                );

            Assert.Throws<InvalidOperationException>(() => client.CreateConnection(ticket)).Message
                .Should().Be.EqualTo("Payment Required - You have reached the limit of enterprise connections (Max number: 1 - Plan: free)");

        }
    }
}
