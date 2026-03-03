using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<CreateConnectionRequestContentOffice365Strategy>))]
[Serializable]
public readonly record struct CreateConnectionRequestContentOffice365Strategy : IStringEnum
{
    public static readonly CreateConnectionRequestContentOffice365Strategy Office365 = new(
        Values.Office365
    );

    public CreateConnectionRequestContentOffice365Strategy(string value)
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
    public static CreateConnectionRequestContentOffice365Strategy FromCustom(string value)
    {
        return new CreateConnectionRequestContentOffice365Strategy(value);
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
        CreateConnectionRequestContentOffice365Strategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateConnectionRequestContentOffice365Strategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateConnectionRequestContentOffice365Strategy value) =>
        value.Value;

    public static explicit operator CreateConnectionRequestContentOffice365Strategy(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Office365 = "office365";
    }
}
