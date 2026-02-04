using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FormBlockImageConfigPositionEnum>))]
[Serializable]
public readonly record struct FormBlockImageConfigPositionEnum : IStringEnum
{
    public static readonly FormBlockImageConfigPositionEnum Left = new(Values.Left);

    public static readonly FormBlockImageConfigPositionEnum Center = new(Values.Center);

    public static readonly FormBlockImageConfigPositionEnum Right = new(Values.Right);

    public FormBlockImageConfigPositionEnum(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static FormBlockImageConfigPositionEnum FromCustom(string value)
    {
        return new FormBlockImageConfigPositionEnum(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(FormBlockImageConfigPositionEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FormBlockImageConfigPositionEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FormBlockImageConfigPositionEnum value) => value.Value;

    public static explicit operator FormBlockImageConfigPositionEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Left = "LEFT";

        public const string Center = "CENTER";

        public const string Right = "RIGHT";
    }
}
