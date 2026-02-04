using System;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

public class ExtensionMethodsTests
{
    [Fact(Skip = "ThrowIfNull extension method no longer exists in new API")]
    public void ThrowsArgumentNullException_WhenInputIsNull()
    {
        // This test is skipped because ThrowIfNull extension no longer exists in the new Fern-generated API
    }

    [Fact(Skip = "ThrowIfNull extension method no longer exists in new API")]
    public void DoesNotThrowException_WhenInputIsNotNull()
    {
        // This test is skipped because ThrowIfNull extension no longer exists in the new Fern-generated API
    }
}
