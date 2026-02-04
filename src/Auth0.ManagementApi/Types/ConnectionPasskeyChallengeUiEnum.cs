using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ConnectionPasskeyChallengeUiEnum>))]
[Serializable]
public readonly record struct ConnectionPasskeyChallengeUiEnum : IStringEnum
{
    public static readonly ConnectionPasskeyChallengeUiEnum Both = new(Values.Both);

    public static readonly ConnectionPasskeyChallengeUiEnum Autofill = new(Values.Autofill);

    public static readonly ConnectionPasskeyChallengeUiEnum Button = new(Values.Button);

    public ConnectionPasskeyChallengeUiEnum(string value)
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
    public static ConnectionPasskeyChallengeUiEnum FromCustom(string value)
    {
        return new ConnectionPasskeyChallengeUiEnum(value);
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

    public static bool operator ==(ConnectionPasskeyChallengeUiEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionPasskeyChallengeUiEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionPasskeyChallengeUiEnum value) => value.Value;

    public static explicit operator ConnectionPasskeyChallengeUiEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Both = "both";

        public const string Autofill = "autofill";

        public const string Button = "button";
    }
}
