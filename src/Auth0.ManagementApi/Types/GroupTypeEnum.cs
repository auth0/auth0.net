using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(GroupTypeEnum.GroupTypeEnumSerializer))]
[Serializable]
public readonly record struct GroupTypeEnum : IStringEnum
{
    public static readonly GroupTypeEnum Connection = new(Values.Connection);

    public static readonly GroupTypeEnum Organization = new(Values.Organization);

    public static readonly GroupTypeEnum Tenant = new(Values.Tenant);

    public GroupTypeEnum(string value)
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
    public static GroupTypeEnum FromCustom(string value)
    {
        return new GroupTypeEnum(value);
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

    public static bool operator ==(GroupTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GroupTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GroupTypeEnum value) => value.Value;

    public static explicit operator GroupTypeEnum(string value) => new(value);

    internal class GroupTypeEnumSerializer : JsonConverter<GroupTypeEnum>
    {
        public override GroupTypeEnum Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new GroupTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GroupTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Connection = "connection";

        public const string Organization = "organization";

        public const string Tenant = "tenant";
    }
}
