using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.AuthenticationApi;
using FluentAssertions;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests;

public class FlexibleDateTimeConverterTests
{
    private class TestClass
    {
        [JsonConverter(typeof(FlexibleDateTimeConverter))]
        public DateTime? DateValue { get; set; }
    }

    private static TestClass Parse(string json) =>
        JsonSerializer.Deserialize<TestClass>(json);

    [Fact]
    public void Handles_iso_string_with_z()
    {
        Parse("""{ "DateValue": "2017-01-03T19:23:03.807Z" }""")
            .DateValue.Should().Be(new DateTime(2017, 1, 3, 19, 23, 3, 807, DateTimeKind.Utc));
    }

    [Fact]
    public void Handles_iso_string_without_z()
    {
        Parse("""{ "DateValue": "2017-01-03T19:23:03" }""")
            .DateValue.Value.Year.Should().Be(2017);
    }

    [Fact]
    public void Handles_epoch_seconds()
    {
        Parse("""{ "DateValue": 1483650127 }""")
            .DateValue.Should().Be(new DateTime(2017, 1, 5, 21, 2, 7, DateTimeKind.Utc));
    }

    [Fact]
    public void Handles_missing_value()
    {
        Parse("{}").DateValue.Should().BeNull();
    }

    [Fact]
    public void Handles_null_value()
    {
        Parse("""{ "DateValue": null }""").DateValue.Should().BeNull();
    }
}
