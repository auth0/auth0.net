using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ConnectionProfileProvisioningScimTokenScopeEnum.ConnectionProfileProvisioningScimTokenScopeEnumSerializer)
)]
[Serializable]
public readonly record struct ConnectionProfileProvisioningScimTokenScopeEnum : IStringEnum
{
    public static readonly ConnectionProfileProvisioningScimTokenScopeEnum GetUsers = new(
        Values.GetUsers
    );

    public static readonly ConnectionProfileProvisioningScimTokenScopeEnum PostUsers = new(
        Values.PostUsers
    );

    public static readonly ConnectionProfileProvisioningScimTokenScopeEnum PatchUsers = new(
        Values.PatchUsers
    );

    public static readonly ConnectionProfileProvisioningScimTokenScopeEnum DeleteUsers = new(
        Values.DeleteUsers
    );

    public static readonly ConnectionProfileProvisioningScimTokenScopeEnum PutUsers = new(
        Values.PutUsers
    );

    public ConnectionProfileProvisioningScimTokenScopeEnum(string value)
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
    public static ConnectionProfileProvisioningScimTokenScopeEnum FromCustom(string value)
    {
        return new ConnectionProfileProvisioningScimTokenScopeEnum(value);
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
        ConnectionProfileProvisioningScimTokenScopeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConnectionProfileProvisioningScimTokenScopeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionProfileProvisioningScimTokenScopeEnum value) =>
        value.Value;

    public static explicit operator ConnectionProfileProvisioningScimTokenScopeEnum(string value) =>
        new(value);

    internal class ConnectionProfileProvisioningScimTokenScopeEnumSerializer
        : JsonConverter<ConnectionProfileProvisioningScimTokenScopeEnum>
    {
        public override ConnectionProfileProvisioningScimTokenScopeEnum Read(
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
            return new ConnectionProfileProvisioningScimTokenScopeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionProfileProvisioningScimTokenScopeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionProfileProvisioningScimTokenScopeEnum ReadAsPropertyName(
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
            return new ConnectionProfileProvisioningScimTokenScopeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionProfileProvisioningScimTokenScopeEnum value,
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
        public const string GetUsers = "get:users";

        public const string PostUsers = "post:users";

        public const string PatchUsers = "patch:users";

        public const string DeleteUsers = "delete:users";

        public const string PutUsers = "put:users";
    }
}
