using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ClientMyOrganizationDeletionBehaviorEnum.ClientMyOrganizationDeletionBehaviorEnumSerializer)
)]
[Serializable]
public readonly record struct ClientMyOrganizationDeletionBehaviorEnum : IStringEnum
{
    public static readonly ClientMyOrganizationDeletionBehaviorEnum Allow = new(Values.Allow);

    public static readonly ClientMyOrganizationDeletionBehaviorEnum AllowIfEmpty = new(
        Values.AllowIfEmpty
    );

    public ClientMyOrganizationDeletionBehaviorEnum(string value)
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
    public static ClientMyOrganizationDeletionBehaviorEnum FromCustom(string value)
    {
        return new ClientMyOrganizationDeletionBehaviorEnum(value);
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
        ClientMyOrganizationDeletionBehaviorEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ClientMyOrganizationDeletionBehaviorEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ClientMyOrganizationDeletionBehaviorEnum value) =>
        value.Value;

    public static explicit operator ClientMyOrganizationDeletionBehaviorEnum(string value) =>
        new(value);

    internal class ClientMyOrganizationDeletionBehaviorEnumSerializer
        : JsonConverter<ClientMyOrganizationDeletionBehaviorEnum>
    {
        public override ClientMyOrganizationDeletionBehaviorEnum Read(
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
            return new ClientMyOrganizationDeletionBehaviorEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientMyOrganizationDeletionBehaviorEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientMyOrganizationDeletionBehaviorEnum ReadAsPropertyName(
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
            return new ClientMyOrganizationDeletionBehaviorEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientMyOrganizationDeletionBehaviorEnum value,
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
        public const string Allow = "allow";

        public const string AllowIfEmpty = "allow_if_empty";
    }
}
