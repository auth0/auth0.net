using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionProfileOrganizationShowAsButtonEnum.ConnectionProfileOrganizationShowAsButtonEnumSerializer)
)]
[Serializable]
public readonly record struct ConnectionProfileOrganizationShowAsButtonEnum : IStringEnum
{
    public static readonly ConnectionProfileOrganizationShowAsButtonEnum None = new(Values.None);

    public static readonly ConnectionProfileOrganizationShowAsButtonEnum Optional = new(
        Values.Optional
    );

    public static readonly ConnectionProfileOrganizationShowAsButtonEnum Required = new(
        Values.Required
    );

    public ConnectionProfileOrganizationShowAsButtonEnum(string value)
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
    public static ConnectionProfileOrganizationShowAsButtonEnum FromCustom(string value)
    {
        return new ConnectionProfileOrganizationShowAsButtonEnum(value);
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
        ConnectionProfileOrganizationShowAsButtonEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConnectionProfileOrganizationShowAsButtonEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionProfileOrganizationShowAsButtonEnum value) =>
        value.Value;

    public static explicit operator ConnectionProfileOrganizationShowAsButtonEnum(string value) =>
        new(value);

    internal class ConnectionProfileOrganizationShowAsButtonEnumSerializer
        : JsonConverter<ConnectionProfileOrganizationShowAsButtonEnum>
    {
        public override ConnectionProfileOrganizationShowAsButtonEnum Read(
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
            return new ConnectionProfileOrganizationShowAsButtonEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionProfileOrganizationShowAsButtonEnum value,
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
        public const string None = "none";

        public const string Optional = "optional";

        public const string Required = "required";
    }
}
