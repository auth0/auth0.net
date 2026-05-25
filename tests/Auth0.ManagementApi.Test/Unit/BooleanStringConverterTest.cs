using Auth0.ManagementApi.Core;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit;

[TestFixture]
public class BooleanStringConverterTest
{
    [Test]
    public void Deserialize_NativeBoolTrue_ReturnsTrue()
    {
        var result = JsonUtils.Deserialize<TestModel>("""{"value": true}""");
        Assert.That(result.Value, Is.EqualTo(true));
    }

    [Test]
    public void Deserialize_NativeBoolFalse_ReturnsFalse()
    {
        var result = JsonUtils.Deserialize<TestModel>("""{"value": false}""");
        Assert.That(result.Value, Is.EqualTo(false));
    }

    [Test]
    public void Deserialize_StringTrue_ReturnsTrue()
    {
        var result = JsonUtils.Deserialize<TestModel>("""{"value": "true"}""");
        Assert.That(result.Value, Is.EqualTo(true));
    }

    [Test]
    public void Deserialize_StringFalse_ReturnsFalse()
    {
        var result = JsonUtils.Deserialize<TestModel>("""{"value": "false"}""");
        Assert.That(result.Value, Is.EqualTo(false));
    }

    [Test]
    public void Deserialize_StringTrueMixedCase_ReturnsTrue()
    {
        var result = JsonUtils.Deserialize<TestModel>("""{"value": "True"}""");
        Assert.That(result.Value, Is.EqualTo(true));
    }

    [Test]
    public void Deserialize_StringFalseMixedCase_ReturnsFalse()
    {
        var result = JsonUtils.Deserialize<TestModel>("""{"value": "False"}""");
        Assert.That(result.Value, Is.EqualTo(false));
    }

    [Test]
    public void Deserialize_InvalidString_ThrowsJsonException()
    {
        Assert.Throws<System.Text.Json.JsonException>(
            () => JsonUtils.Deserialize<TestModel>("""{"value": "yes"}""")
        );
    }

    [Test]
    public void Deserialize_EmptyString_ThrowsJsonException()
    {
        Assert.Throws<System.Text.Json.JsonException>(
            () => JsonUtils.Deserialize<TestModel>("""{"value": ""}""")
        );
    }

    [Test]
    public void Deserialize_NullableNativeBoolTrue_ReturnsTrue()
    {
        var result = JsonUtils.Deserialize<TestModelNullable>("""{"value": true}""");
        Assert.That(result.Value, Is.EqualTo(true));
    }

    [Test]
    public void Deserialize_NullableStringTrue_ReturnsTrue()
    {
        var result = JsonUtils.Deserialize<TestModelNullable>("""{"value": "true"}""");
        Assert.That(result.Value, Is.EqualTo(true));
    }

    [Test]
    public void Deserialize_NullableNull_ReturnsNull()
    {
        var result = JsonUtils.Deserialize<TestModelNullable>("""{"value": null}""");
        Assert.That(result.Value, Is.Null);
    }

    [Test]
    public void Deserialize_NullableMissing_ReturnsNull()
    {
        var result = JsonUtils.Deserialize<TestModelNullable>("""{}""");
        Assert.That(result.Value, Is.Null);
    }

    [Test]
    public void Serialize_TrueValue_WritesNativeBool()
    {
        var json = JsonUtils.Serialize(new TestModel { Value = true });
        Assert.That(json, Does.Contain("true"));
        Assert.That(json, Does.Not.Contain("\"true\""));
    }

    [Test]
    public void Serialize_FalseValue_WritesNativeBool()
    {
        var json = JsonUtils.Serialize(new TestModel { Value = false });
        Assert.That(json, Does.Contain("false"));
        Assert.That(json, Does.Not.Contain("\"false\""));
    }

    private record TestModel
    {
        [System.Text.Json.Serialization.JsonPropertyName("value")]
        public bool Value { get; set; }
    }

    private record TestModelNullable
    {
        [System.Text.Json.Serialization.JsonPropertyName("value")]
        public bool? Value { get; set; }
    }
}
