using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.Extensions;

[TestFixture]
public class UserDateSchemaExtensionsTest
{
    [Test]
    public void ToDateTime_WithValidIso8601String_ReturnsUtcDateTime()
    {
        var schema = UserDateSchema.FromString("2024-03-15T10:30:00.000Z");

        var result = schema.ToDateTime();

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Value, Is.EqualTo(new DateTime(2024, 3, 15, 10, 30, 0, DateTimeKind.Utc)));
        Assert.That(result.Value.Kind, Is.EqualTo(DateTimeKind.Utc));
    }

    [Test]
    public void ToDateTime_WithNull_ReturnsNull()
    {
        UserDateSchema? schema = null;

        var result = schema.ToDateTime();

        Assert.That(result, Is.Null);
    }

    [Test]
    public void ToDateTime_WithMapType_ReturnsNull()
    {
        var schema = UserDateSchema.FromMapOfStringToUnknown(new Dictionary<string, object?>
        {
            { "some_key", "some_value" }
        });

        var result = schema.ToDateTime();

        Assert.That(result, Is.Null);
    }

    [Test]
    public void ToDateTime_WithMalformedString_ReturnsNull()
    {
        var schema = UserDateSchema.FromString("not-a-date");

        var result = schema.ToDateTime();

        Assert.That(result, Is.Null);
    }

    [Test]
    public void ToDateTime_WithOffsetString_PreservesLocalKind()
    {
        var schema = UserDateSchema.FromString("2024-06-20T14:00:00.000+05:30");

        var result = schema.ToDateTime();
        var expectedLocal = new DateTimeOffset(2024, 6, 20, 14, 0, 0, TimeSpan.FromMinutes(330)).LocalDateTime;

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Value, Is.EqualTo(expectedLocal));
        Assert.That(result.Value.Kind, Is.EqualTo(DateTimeKind.Local));
    }

    [Test]
    public void ToDateTime_WithDateTimeOffset_ReturnsUtcConverted()
    {
        var schema = UserDateSchema.FromString("2024-06-20T14:00:00.000+05:30");

        var result = schema.ToDateTime(TimeZoneInfo.Utc);

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Value.Kind, Is.EqualTo(DateTimeKind.Utc));
        Assert.That(result.Value, Is.EqualTo(new DateTime(2024, 6, 20, 8, 30, 0, DateTimeKind.Utc)));
    }

    [Test]
    public void ToDateTime_WithMalformedStringAndTargetTimeZone_ReturnsNull()
    {
        var schema = UserDateSchema.FromString("not-a-date");

        var result = schema.ToDateTime(TimeZoneInfo.Utc);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void ToDateTime_WithNullTargetTimeZone_ThrowsArgumentNullException()
    {
        var schema = UserDateSchema.FromString("2024-03-15T10:30:00.000Z");

        Assert.Throws<ArgumentNullException>(() => schema.ToDateTime(null!));
    }
}
