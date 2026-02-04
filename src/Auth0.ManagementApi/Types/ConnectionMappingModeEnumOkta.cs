using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ConnectionMappingModeEnumOkta>))]
[Serializable]
public readonly record struct ConnectionMappingModeEnumOkta : IStringEnum
{
    public static readonly ConnectionMappingModeEnumOkta BasicProfile = new(Values.BasicProfile);

    public static readonly ConnectionMappingModeEnumOkta UseMap = new(Values.UseMap);

    public ConnectionMappingModeEnumOkta(string value)
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
    public static ConnectionMappingModeEnumOkta FromCustom(string value)
    {
        return new ConnectionMappingModeEnumOkta(value);
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

    public static bool operator ==(ConnectionMappingModeEnumOkta value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionMappingModeEnumOkta value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionMappingModeEnumOkta value) => value.Value;

    public static explicit operator ConnectionMappingModeEnumOkta(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string BasicProfile = "basic_profile";

        public const string UseMap = "use_map";
    }
}
