// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(SessionDate.JsonConverter))]
[Serializable]
public class SessionDate
{
    private SessionDate(string type, object? value)
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
    /// Factory method to create a union from a DateTime value.
    /// </summary>
    public static SessionDate FromDateTime(DateTime value) => new("dateTime", value);

    /// <summary>
    /// Factory method to create a union from a Dictionary<string, object?> value.
    /// </summary>
    public static SessionDate FromMapOfStringToUnknown(Dictionary<string, object?> value) =>
        new("map", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "dateTime"
    /// </summary>
    public bool IsDateTime() => Type == "dateTime";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "map"
    /// </summary>
    public bool IsMapOfStringToUnknown() => Type == "map";

    /// <summary>
    /// Returns the value as a <see cref="DateTime"/> if <see cref="Type"/> is 'dateTime', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'dateTime'.</exception>
    public DateTime AsDateTime() =>
        IsDateTime()
            ? (DateTime)Value!
            : throw new ManagementException("Union type is not 'dateTime'");

    /// <summary>
    /// Returns the value as a <see cref="Dictionary<string, object?>"/> if <see cref="Type"/> is 'map', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'map'.</exception>
    public Dictionary<string, object?> AsMapOfStringToUnknown() =>
        IsMapOfStringToUnknown()
            ? (Dictionary<string, object?>)Value!
            : throw new ManagementException("Union type is not 'map'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="DateTime"/> and returns true if successful.
    /// </summary>
    public bool TryGetDateTime(out DateTime? value)
    {
        if (Type == "dateTime")
        {
            value = (DateTime)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Dictionary<string, object?>"/> and returns true if successful.
    /// </summary>
    public bool TryGetMapOfStringToUnknown(out Dictionary<string, object?>? value)
    {
        if (Type == "map")
        {
            value = (Dictionary<string, object?>)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<DateTime, T> onDateTime,
        Func<Dictionary<string, object?>, T> onMapOfStringToUnknown
    )
    {
        return Type switch
        {
            "dateTime" => onDateTime(AsDateTime()),
            "map" => onMapOfStringToUnknown(AsMapOfStringToUnknown()),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<DateTime> onDateTime,
        global::System.Action<Dictionary<string, object?>> onMapOfStringToUnknown
    )
    {
        switch (Type)
        {
            case "dateTime":
                onDateTime(AsDateTime());
                break;
            case "map":
                onMapOfStringToUnknown(AsMapOfStringToUnknown());
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
        if (obj is not SessionDate other)
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

    public static implicit operator SessionDate(DateTime value) => new("dateTime", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<SessionDate>
    {
        public override SessionDate? Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.String)
            {
                var stringValue = reader.GetString()!;

                if (System.DateTime.TryParse(stringValue, out var dateTimeValue))
                {
                    SessionDate dateTimeResult = new("dateTime", dateTimeValue);
                    return dateTimeResult;
                }
            }

            if (reader.TokenType == JsonTokenType.StartArray)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, System.Type Type)[]
                {
                    ("map", typeof(Dictionary<string, object?>)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            SessionDate result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into SessionDate"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            SessionDate value,
            JsonSerializerOptions options
        )
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            value.Visit(
                dt => writer.WriteStringValue(dt.ToString("O")),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override SessionDate ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            SessionDate result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SessionDate value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
