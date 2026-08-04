using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit;

[TestFixture]
public class Rfc3339SecondsDateTimeConverterTest
{
    private class TestModel
    {
        [JsonPropertyName("date")]
        [JsonConverter(typeof(Rfc3339SecondsDateTimeConverter))]
        public DateTime? Date { get; set; }
    }

    private static string SerializedDate(TestModel model)
    {
        using var doc = JsonDocument.Parse(JsonUtils.Serialize(model));
        return doc.RootElement.GetProperty("date").GetString()!;
    }

    [Test]
    public void Serialize_WholeSecondUtc_EmitsTwentyCharValue()
    {
        var model = new TestModel
        {
            Date = new DateTime(2026, 7, 1, 0, 0, 0, DateTimeKind.Utc),
        };
        var value = SerializedDate(model);
        Assert.That(value, Is.EqualTo("2026-07-01T00:00:00Z"));
        Assert.That(value.Length, Is.EqualTo(20));
    }

    [Test]
    public void Serialize_WithSubSecondPrecision_TruncatesToSeconds()
    {
        var model = new TestModel
        {
            Date = new DateTime(2026, 7, 1, 0, 0, 0, 123, DateTimeKind.Utc),
        };
        var value = SerializedDate(model);
        Assert.That(value, Is.EqualTo("2026-07-01T00:00:00Z"));
        Assert.That(value.Length, Is.EqualTo(20));
    }

    [Test]
    public void Serialize_UnspecifiedKind_LabeledUtcWithoutShifting()
    {
        // Kind == Unspecified is the default for `new DateTime(...)`. The wall
        // clock must be preserved and simply labeled "Z" — never shifted by the
        // host machine's UTC offset. This assertion is timezone-independent.
        var model = new TestModel { Date = new DateTime(2026, 7, 1, 15, 30, 45) };
        var value = SerializedDate(model);
        Assert.That(value, Is.EqualTo("2026-07-01T15:30:45Z"));
        Assert.That(value.Length, Is.EqualTo(20));
    }

    [Test]
    public void Serialize_LocalTime_ConvertsToEquivalentUtcInstant()
    {
        // A Local-kind value must be shifted to its UTC equivalent before the
        // "Z" is appended. Rather than hardcode an offset (which varies by host
        // timezone), confirm the emitted value denotes the same instant.
        var local = new DateTime(2026, 7, 1, 12, 30, 45, DateTimeKind.Local);
        var model = new TestModel { Date = local };
        var value = SerializedDate(model);

        Assert.That(value, Does.EndWith("Z"));
        Assert.That(value, Does.Not.Contain("."));
        Assert.That(value.Length, Is.EqualTo(20));

        var parsed = DateTime.Parse(
            value,
            CultureInfo.InvariantCulture,
            DateTimeStyles.RoundtripKind
        );
        Assert.That(parsed.ToUniversalTime(), Is.EqualTo(local.ToUniversalTime()));
    }

    [Test]
    public void Roundtrip_Deserialize_ParsesBackToUtc()
    {
        var json = "{\"date\":\"2026-07-01T00:00:00Z\"}";
        var model = JsonUtils.Deserialize<TestModel>(json);
        Assert.That(model.Date, Is.Not.Null);
        Assert.That(
            model.Date!.Value.ToUniversalTime(),
            Is.EqualTo(new DateTime(2026, 7, 1, 0, 0, 0, DateTimeKind.Utc))
        );
    }
}
