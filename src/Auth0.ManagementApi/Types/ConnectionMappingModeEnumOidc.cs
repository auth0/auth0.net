using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ConnectionMappingModeEnumOidc>))]
[Serializable]
public readonly record struct ConnectionMappingModeEnumOidc : IStringEnum
{
    public static readonly ConnectionMappingModeEnumOidc BindAll = new(Values.BindAll);

    public static readonly ConnectionMappingModeEnumOidc UseMap = new(Values.UseMap);

    public ConnectionMappingModeEnumOidc(string value)
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
    public static ConnectionMappingModeEnumOidc FromCustom(string value)
    {
        return new ConnectionMappingModeEnumOidc(value);
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

    public static bool operator ==(ConnectionMappingModeEnumOidc value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionMappingModeEnumOidc value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionMappingModeEnumOidc value) => value.Value;

    public static explicit operator ConnectionMappingModeEnumOidc(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string BindAll = "bind_all";

        public const string UseMap = "use_map";
    }
}
