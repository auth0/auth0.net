using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionSalesforceSearchLeadsParamsSearchField.FlowActionSalesforceSearchLeadsParamsSearchFieldSerializer)
)]
[Serializable]
public readonly record struct FlowActionSalesforceSearchLeadsParamsSearchField : IStringEnum
{
    public static readonly FlowActionSalesforceSearchLeadsParamsSearchField Email = new(
        Values.Email
    );

    public static readonly FlowActionSalesforceSearchLeadsParamsSearchField Name = new(Values.Name);

    public static readonly FlowActionSalesforceSearchLeadsParamsSearchField Phone = new(
        Values.Phone
    );

    public static readonly FlowActionSalesforceSearchLeadsParamsSearchField All = new(Values.All);

    public FlowActionSalesforceSearchLeadsParamsSearchField(string value)
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
    public static FlowActionSalesforceSearchLeadsParamsSearchField FromCustom(string value)
    {
        return new FlowActionSalesforceSearchLeadsParamsSearchField(value);
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
        FlowActionSalesforceSearchLeadsParamsSearchField value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        FlowActionSalesforceSearchLeadsParamsSearchField value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        FlowActionSalesforceSearchLeadsParamsSearchField value
    ) => value.Value;

    public static explicit operator FlowActionSalesforceSearchLeadsParamsSearchField(
        string value
    ) => new(value);

    internal class FlowActionSalesforceSearchLeadsParamsSearchFieldSerializer
        : JsonConverter<FlowActionSalesforceSearchLeadsParamsSearchField>
    {
        public override FlowActionSalesforceSearchLeadsParamsSearchField Read(
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
            return new FlowActionSalesforceSearchLeadsParamsSearchField(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionSalesforceSearchLeadsParamsSearchField value,
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
        public const string Email = "email";

        public const string Name = "name";

        public const string Phone = "phone";

        public const string All = "all";
    }
}
