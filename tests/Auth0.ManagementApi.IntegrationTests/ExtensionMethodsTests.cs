using System;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

public class ExtensionMethodsTests
{
    [Fact]
    public void ThrowsArgumentNullException_WhenInputIsNull()
    {
        // Act & Assert
        void ValidateInput(object input)
        {
            var exception = Assert.Throws<ArgumentNullException>(() => input.ThrowIfNull());
            exception.Message.Should().Contain($"{nameof(input)}");
        }
        ValidateInput(null);
    }

    [Fact]
    public void DoesNotThrowException_WhenInputIsNotNull()
    {
        // Act & Assert
        var input = new object();
        input.ThrowIfNull(); // Should not throw
    }
}