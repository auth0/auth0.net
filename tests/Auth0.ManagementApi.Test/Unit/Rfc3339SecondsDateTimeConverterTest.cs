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
    public void Serialize_LocalTime_ConvertsToUtcZ()
    {
        var local = new DateTimeOffset(
            2026,
            7,
            1,
            2,
            0,
            0,
            TimeSpan.FromHours(2)
        ).DateTime;
        local = DateTime.SpecifyKind(local, DateTimeKind.Local);
        var model = new TestModel { Date = local };
        var value = SerializedDate(model);
        Assert.That(value, Does.EndWith("Z"));
        Assert.That(value, Does.Not.Contain("."));
        Assert.That(value.Length, Is.EqualTo(20));
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
