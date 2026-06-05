using System;

using FluentAssertions;
using Auth0.AuthenticationApi.Models.Ciba;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests;

public class ClientInitiatedBackchannelAuthorizationTokenResponseTests
{
    [Fact]
    public void AuthorizationDetails_returns_null_when_raw_is_null()
    {
        var response = new ClientInitiatedBackchannelAuthorizationTokenResponse
        {
            AuthorizationDetailsRaw = null
        };

        response.AuthorizationDetails.Should().BeNull();
    }

    [Fact]
    public void AuthorizationDetails_returns_null_when_raw_is_empty()
    {
        var response = new ClientInitiatedBackchannelAuthorizationTokenResponse
        {
            AuthorizationDetailsRaw = ""
        };

        response.AuthorizationDetails.Should().BeNull();
    }

    [Fact]
    public void AuthorizationDetails_throws_InvalidOperationException_on_malformed_json()
    {
        var response = new ClientInitiatedBackchannelAuthorizationTokenResponse
        {
            AuthorizationDetailsRaw = "[{\"type\":"
        };

        Action act = () => _ = response.AuthorizationDetails;

        act.Should().Throw<InvalidOperationException>()
            .WithInnerException<System.Text.Json.JsonException>();
    }

    [Fact]
    public void AuthorizationDetails_caches_parsed_result_across_accesses()
    {
        var response = new ClientInitiatedBackchannelAuthorizationTokenResponse
        {
            AuthorizationDetailsRaw = "[{\"type\":\"payment_initiation\"}]"
        };

        var first = response.AuthorizationDetails;
        var second = response.AuthorizationDetails;

        first.Should().BeSameAs(second);
    }
}
