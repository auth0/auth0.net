using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<DomainVerificationStatusEnum>))]
[Serializable]
public readonly record struct DomainVerificationStatusEnum : IStringEnum
{
    public static readonly DomainVerificationStatusEnum Verified = new(Values.Verified);

    public static readonly DomainVerificationStatusEnum Pending = new(Values.Pending);

    public static readonly DomainVerificationStatusEnum Failed = new(Values.Failed);

    public DomainVerificationStatusEnum(string value)
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
    public static DomainVerificationStatusEnum FromCustom(string value)
    {
        return new DomainVerificationStatusEnum(value);
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

    public static bool operator ==(DomainVerificationStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DomainVerificationStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DomainVerificationStatusEnum value) => value.Value;

    public static explicit operator DomainVerificationStatusEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Verified = "verified";

        public const string Pending = "pending";

        public const string Failed = "failed";
    }
}
