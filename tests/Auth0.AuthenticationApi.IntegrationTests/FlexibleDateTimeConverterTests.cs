using FluentAssertions;
using Newtonsoft.Json;
using System;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    public class FlexibleDateTimeConverterTests
    {
        [Fact]
        public void HandlesIsoStringDates()
        {

            var json = "{ \"DateValue\": \"2017-01-03T19:23:03.807Z\"}";
            var result = JsonConvert.DeserializeObject<TestClass>(json);

            result.DateValue.Should().Be(new DateTime(2017, 1, 3, 19, 23, 3, 807));
        }

        [Fact]
        public void HandlesEpochDates()
        {
            var json = "{ \"DateValue\": 1483650127 }";
            var result = JsonConvert.DeserializeObject<TestClass>(json);
            result.DateValue.Should().Be(new DateTime(2017, 1, 5, 21, 2, 7));
        }

        [Fact]
        public void HandlesMissingValues()
        {
            var json = "{}";
            var result = JsonConvert.DeserializeObject<TestClass>(json);
            result.DateValue.Should().Be(null);
        }

        internal class TestClass
        {
            [JsonConverter(typeof(FlexibleDateTimeConverter))]
            public DateTime? DateValue { get; set; }
        }
    }
}
