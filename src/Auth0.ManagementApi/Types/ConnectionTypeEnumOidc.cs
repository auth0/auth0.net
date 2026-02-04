using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ConnectionTypeEnumOidc>))]
[Serializable]
public readonly record struct ConnectionTypeEnumOidc : IStringEnum
{
    public static readonly ConnectionTypeEnumOidc BackChannel = new(Values.BackChannel);

    public static readonly ConnectionTypeEnumOidc FrontChannel = new(Values.FrontChannel);

    public ConnectionTypeEnumOidc(string value)
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
    public static ConnectionTypeEnumOidc FromCustom(string value)
    {
        return new ConnectionTypeEnumOidc(value);
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

    public static bool operator ==(ConnectionTypeEnumOidc value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionTypeEnumOidc value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionTypeEnumOidc value) => value.Value;

    public static explicit operator ConnectionTypeEnumOidc(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string BackChannel = "back_channel";

        public const string FrontChannel = "front_channel";
    }
}
