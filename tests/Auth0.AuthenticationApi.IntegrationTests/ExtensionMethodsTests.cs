using System;
using System.Collections.Generic;

using FluentAssertions;
using Xunit;

using Auth0.AuthenticationApi.Models.Mfa;
using Auth0.Tests.Shared;

namespace Auth0.AuthenticationApi.IntegrationTests;

public class ExtensionMethodsTests : TestBase
{
    [Fact]
    public void ThrowIfNull_Should_Throw_For_Null_Input()
    {
        MfaOtpTokenRequest request = null;
        Assert.Throws<ArgumentNullException>(request.ThrowIfNull);
    }

    [Fact]
    public void ThrowIfNull_Should_Not_Throw_For_Non_Null_Input()
    {
        MfaOtpTokenRequest request = new MfaOtpTokenRequest();
        var ex = Record.Exception(() => request.ThrowIfNull());
        ex.Should().BeNull();
    }

    [Fact]
    public void AddIfNotEmpty_Should_Add_Non_Empty_Value()
    {
        var dictionary = new Dictionary<string, string>();
        dictionary.AddIfNotEmpty("key", "value");
        dictionary.Should().ContainKey("key");
        dictionary["key"].Should().Be("value");
    }

    [Fact]
    public void AddIfNotEmpty_Should_Not_Add_Empty_Value()
    {
        var dictionary = new Dictionary<string, string>();
        // Empty Value
        dictionary.AddIfNotEmpty("key", "");
        dictionary.Should().NotContainKey("key");

        // Null Value
        dictionary.AddIfNotEmpty("key", "");
        dictionary.Should().NotContainKey("key");
    }

    [Fact]
    public void AddAll_Should_Add_All_Items()
    {
        var targetDictionary = new Dictionary<string, string>
        {
            { "key1", "value" },
        };
        var sourceDictionary = new Dictionary<string, string>
        {
            { "key1", "value1" },
            { "key2", "value2" }
        };

        targetDictionary.AddAll(sourceDictionary);

        targetDictionary.Should().ContainKey("key1");
        targetDictionary.Should().ContainKey("key2");
        targetDictionary["key1"].Should().Be("value1");
        targetDictionary["key2"].Should().Be("value2");
    }
}