using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CustomDomainStatusFilterEnum.CustomDomainStatusFilterEnumSerializer))]
[Serializable]
public readonly record struct CustomDomainStatusFilterEnum : IStringEnum
{
    public static readonly CustomDomainStatusFilterEnum PendingVerification = new(
        Values.PendingVerification
    );

    public static readonly CustomDomainStatusFilterEnum Ready = new(Values.Ready);

    public static readonly CustomDomainStatusFilterEnum Failed = new(Values.Failed);

    public CustomDomainStatusFilterEnum(string value)
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
    public static CustomDomainStatusFilterEnum FromCustom(string value)
    {
        return new CustomDomainStatusFilterEnum(value);
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

    public static bool operator ==(CustomDomainStatusFilterEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CustomDomainStatusFilterEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CustomDomainStatusFilterEnum value) => value.Value;

    public static explicit operator CustomDomainStatusFilterEnum(string value) => new(value);

    internal class CustomDomainStatusFilterEnumSerializer
        : JsonConverter<CustomDomainStatusFilterEnum>
    {
        public override CustomDomainStatusFilterEnum Read(
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
            return new CustomDomainStatusFilterEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CustomDomainStatusFilterEnum value,
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
        public const string PendingVerification = "pending_verification";

        public const string Ready = "ready";

        public const string Failed = "failed";
    }
}
