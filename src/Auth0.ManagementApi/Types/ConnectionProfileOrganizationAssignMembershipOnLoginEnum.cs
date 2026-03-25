using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionProfileOrganizationAssignMembershipOnLoginEnum.ConnectionProfileOrganizationAssignMembershipOnLoginEnumSerializer)
)]
[Serializable]
public readonly record struct ConnectionProfileOrganizationAssignMembershipOnLoginEnum : IStringEnum
{
    public static readonly ConnectionProfileOrganizationAssignMembershipOnLoginEnum None = new(
        Values.None
    );

    public static readonly ConnectionProfileOrganizationAssignMembershipOnLoginEnum Optional = new(
        Values.Optional
    );

    public static readonly ConnectionProfileOrganizationAssignMembershipOnLoginEnum Required = new(
        Values.Required
    );

    public ConnectionProfileOrganizationAssignMembershipOnLoginEnum(string value)
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
    public static ConnectionProfileOrganizationAssignMembershipOnLoginEnum FromCustom(string value)
    {
        return new ConnectionProfileOrganizationAssignMembershipOnLoginEnum(value);
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

    public static bool operator ==(
        ConnectionProfileOrganizationAssignMembershipOnLoginEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConnectionProfileOrganizationAssignMembershipOnLoginEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ConnectionProfileOrganizationAssignMembershipOnLoginEnum value
    ) => value.Value;

    public static explicit operator ConnectionProfileOrganizationAssignMembershipOnLoginEnum(
        string value
    ) => new(value);

    internal class ConnectionProfileOrganizationAssignMembershipOnLoginEnumSerializer
        : JsonConverter<ConnectionProfileOrganizationAssignMembershipOnLoginEnum>
    {
        public override ConnectionProfileOrganizationAssignMembershipOnLoginEnum Read(
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
            return new ConnectionProfileOrganizationAssignMembershipOnLoginEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionProfileOrganizationAssignMembershipOnLoginEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionProfileOrganizationAssignMembershipOnLoginEnum ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new ConnectionProfileOrganizationAssignMembershipOnLoginEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionProfileOrganizationAssignMembershipOnLoginEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string None = "none";

        public const string Optional = "optional";

        public const string Required = "required";
    }
}
