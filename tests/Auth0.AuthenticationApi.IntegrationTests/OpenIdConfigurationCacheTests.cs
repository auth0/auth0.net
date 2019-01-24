using System;
using System.Threading.Tasks;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    public class OpenIdConfigurationCacheTests: TestBase
    {
        [Fact]
        public void Throws_When_Incorrect_Domain_Passed()
        {
            Func<Task> getTask = async () => await OpenIdConfigurationCache.Instance.GetAsync("invalid_domain");

            getTask.Should().Throw<Exception>();
        }

        [Fact]
        public void Does_Not_Throw_When_Domain_Without_Trailing_Slash_Is_Passed()
        {
            Func<Task> getTask = async () => await OpenIdConfigurationCache.Instance.GetAsync($"https://{GetVariable("AUTH0_AUTHENTICATION_API_URL")}");

            getTask.Should().NotThrow();
        }
    }
}