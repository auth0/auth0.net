using Auth0.Core.Serialization;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Auth0.Core.UnitTests
{
    [TestFixture]
    public class FlexibleDateTimeConverterTests
    {
        [Test]
        public void HandlesIsoStringDates()
        {

            var json = "{ \"DateValue\": \"2017-01-03T19:23:03.807Z\"}";
            var result = JsonConvert.DeserializeObject<TestClass>(json);

            result.DateValue.Should().Be(new DateTime(2017, 1, 3, 19, 23, 3, 807));
        }

        [Test]
        public void HandlesEpochDates()
        {
            var json = "{ \"DateValue\": 1483650127 }";
            var result = JsonConvert.DeserializeObject<TestClass>(json);
            result.DateValue.Should().Be(new DateTime(2017, 1, 5, 21, 2, 7));
        }

        [Test]
        public void HandlesMissingValues()
        {
            var json = "{}";
            var result = JsonConvert.DeserializeObject<TestClass>(json);
            result.DateValue.Should().Be(null);
        }

        public class TestClass
        {
            [JsonConverter(typeof(FlexibleDateTimeConverter))]
            public DateTime? DateValue { get; set; }
        }
    }
}
