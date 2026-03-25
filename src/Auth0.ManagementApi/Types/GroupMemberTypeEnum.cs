using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(GroupMemberTypeEnum.GroupMemberTypeEnumSerializer))]
[Serializable]
public readonly record struct GroupMemberTypeEnum : IStringEnum
{
    public static readonly GroupMemberTypeEnum User = new(Values.User);

    public static readonly GroupMemberTypeEnum Group = new(Values.Group);

    public GroupMemberTypeEnum(string value)
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
    public static GroupMemberTypeEnum FromCustom(string value)
    {
        return new GroupMemberTypeEnum(value);
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

    public static bool operator ==(GroupMemberTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GroupMemberTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GroupMemberTypeEnum value) => value.Value;

    public static explicit operator GroupMemberTypeEnum(string value) => new(value);

    internal class GroupMemberTypeEnumSerializer : JsonConverter<GroupMemberTypeEnum>
    {
        public override GroupMemberTypeEnum Read(
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
            return new GroupMemberTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GroupMemberTypeEnum value,
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
        public const string User = "user";

        public const string Group = "group";
    }
}
