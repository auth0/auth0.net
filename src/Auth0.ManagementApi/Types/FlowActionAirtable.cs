// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionAirtable.JsonConverter))]
[Serializable]
public class FlowActionAirtable
{
    private FlowActionAirtable(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Type discriminator
    /// </summary>
    [JsonIgnore]
    public string Type { get; internal set; }

    /// <summary>
    /// Union value
    /// </summary>
    [JsonIgnore]
    public object? Value { get; internal set; }

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionAirtableCreateRecord value.
    /// </summary>
    public static FlowActionAirtable FromFlowActionAirtableCreateRecord(
        Auth0.ManagementApi.FlowActionAirtableCreateRecord value
    ) => new("flowActionAirtableCreateRecord", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionAirtableListRecords value.
    /// </summary>
    public static FlowActionAirtable FromFlowActionAirtableListRecords(
        Auth0.ManagementApi.FlowActionAirtableListRecords value
    ) => new("flowActionAirtableListRecords", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionAirtableUpdateRecord value.
    /// </summary>
    public static FlowActionAirtable FromFlowActionAirtableUpdateRecord(
        Auth0.ManagementApi.FlowActionAirtableUpdateRecord value
    ) => new("flowActionAirtableUpdateRecord", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionAirtableCreateRecord"
    /// </summary>
    public bool IsFlowActionAirtableCreateRecord() => Type == "flowActionAirtableCreateRecord";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionAirtableListRecords"
    /// </summary>
    public bool IsFlowActionAirtableListRecords() => Type == "flowActionAirtableListRecords";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionAirtableUpdateRecord"
    /// </summary>
    public bool IsFlowActionAirtableUpdateRecord() => Type == "flowActionAirtableUpdateRecord";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionAirtableCreateRecord"/> if <see cref="Type"/> is 'flowActionAirtableCreateRecord', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionAirtableCreateRecord'.</exception>
    public Auth0.ManagementApi.FlowActionAirtableCreateRecord AsFlowActionAirtableCreateRecord() =>
        IsFlowActionAirtableCreateRecord()
            ? (Auth0.ManagementApi.FlowActionAirtableCreateRecord)Value!
            : throw new ManagementException("Union type is not 'flowActionAirtableCreateRecord'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionAirtableListRecords"/> if <see cref="Type"/> is 'flowActionAirtableListRecords', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionAirtableListRecords'.</exception>
    public Auth0.ManagementApi.FlowActionAirtableListRecords AsFlowActionAirtableListRecords() =>
        IsFlowActionAirtableListRecords()
            ? (Auth0.ManagementApi.FlowActionAirtableListRecords)Value!
            : throw new ManagementException("Union type is not 'flowActionAirtableListRecords'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionAirtableUpdateRecord"/> if <see cref="Type"/> is 'flowActionAirtableUpdateRecord', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionAirtableUpdateRecord'.</exception>
    public Auth0.ManagementApi.FlowActionAirtableUpdateRecord AsFlowActionAirtableUpdateRecord() =>
        IsFlowActionAirtableUpdateRecord()
            ? (Auth0.ManagementApi.FlowActionAirtableUpdateRecord)Value!
            : throw new ManagementException("Union type is not 'flowActionAirtableUpdateRecord'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionAirtableCreateRecord"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionAirtableCreateRecord(
        out Auth0.ManagementApi.FlowActionAirtableCreateRecord? value
    )
    {
        if (Type == "flowActionAirtableCreateRecord")
        {
            value = (Auth0.ManagementApi.FlowActionAirtableCreateRecord)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionAirtableListRecords"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionAirtableListRecords(
        out Auth0.ManagementApi.FlowActionAirtableListRecords? value
    )
    {
        if (Type == "flowActionAirtableListRecords")
        {
            value = (Auth0.ManagementApi.FlowActionAirtableListRecords)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionAirtableUpdateRecord"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionAirtableUpdateRecord(
        out Auth0.ManagementApi.FlowActionAirtableUpdateRecord? value
    )
    {
        if (Type == "flowActionAirtableUpdateRecord")
        {
            value = (Auth0.ManagementApi.FlowActionAirtableUpdateRecord)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.FlowActionAirtableCreateRecord,
            T
        > onFlowActionAirtableCreateRecord,
        Func<Auth0.ManagementApi.FlowActionAirtableListRecords, T> onFlowActionAirtableListRecords,
        Func<Auth0.ManagementApi.FlowActionAirtableUpdateRecord, T> onFlowActionAirtableUpdateRecord
    )
    {
        return Type switch
        {
            "flowActionAirtableCreateRecord" => onFlowActionAirtableCreateRecord(
                AsFlowActionAirtableCreateRecord()
            ),
            "flowActionAirtableListRecords" => onFlowActionAirtableListRecords(
                AsFlowActionAirtableListRecords()
            ),
            "flowActionAirtableUpdateRecord" => onFlowActionAirtableUpdateRecord(
                AsFlowActionAirtableUpdateRecord()
            ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.FlowActionAirtableCreateRecord> onFlowActionAirtableCreateRecord,
        System.Action<Auth0.ManagementApi.FlowActionAirtableListRecords> onFlowActionAirtableListRecords,
        System.Action<Auth0.ManagementApi.FlowActionAirtableUpdateRecord> onFlowActionAirtableUpdateRecord
    )
    {
        switch (Type)
        {
            case "flowActionAirtableCreateRecord":
                onFlowActionAirtableCreateRecord(AsFlowActionAirtableCreateRecord());
                break;
            case "flowActionAirtableListRecords":
                onFlowActionAirtableListRecords(AsFlowActionAirtableListRecords());
                break;
            case "flowActionAirtableUpdateRecord":
                onFlowActionAirtableUpdateRecord(AsFlowActionAirtableUpdateRecord());
                break;
            default:
                throw new ManagementException($"Unknown union type: {Type}");
        }
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = Type.GetHashCode();
            if (Value != null)
            {
                hashCode = (hashCode * 397) ^ Value.GetHashCode();
            }
            return hashCode;
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj is not FlowActionAirtable other)
            return false;

        // Compare type discriminators
        if (Type != other.Type)
            return false;

        // Compare values using EqualityComparer for deep comparison
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator FlowActionAirtable(
        Auth0.ManagementApi.FlowActionAirtableCreateRecord value
    ) => new("flowActionAirtableCreateRecord", value);

    public static implicit operator FlowActionAirtable(
        Auth0.ManagementApi.FlowActionAirtableListRecords value
    ) => new("flowActionAirtableListRecords", value);

    public static implicit operator FlowActionAirtable(
        Auth0.ManagementApi.FlowActionAirtableUpdateRecord value
    ) => new("flowActionAirtableUpdateRecord", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FlowActionAirtable>
    {
        public override FlowActionAirtable? Read(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, System.Type Type)[]
                {
                    (
                        "flowActionAirtableCreateRecord",
                        typeof(Auth0.ManagementApi.FlowActionAirtableCreateRecord)
                    ),
                    (
                        "flowActionAirtableListRecords",
                        typeof(Auth0.ManagementApi.FlowActionAirtableListRecords)
                    ),
                    (
                        "flowActionAirtableUpdateRecord",
                        typeof(Auth0.ManagementApi.FlowActionAirtableUpdateRecord)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            FlowActionAirtable result = new(key, value);
                            return result;
                        }
                    }
                    catch (JsonException)
                    {
                        // Try next type;
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into FlowActionAirtable"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionAirtable value,
            JsonSerializerOptions options
        )
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            value.Visit(
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override FlowActionAirtable ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            FlowActionAirtable result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionAirtable value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
