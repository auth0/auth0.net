// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(RefreshTokenDate.JsonConverter))]
[Serializable]
public class RefreshTokenDate
{
    private RefreshTokenDate(string type, object? value)
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
    public static RefreshTokenDate FromDateTime(DateTime value) => new("dateTime", value);

    /// <summary>
    /// Factory method to create a union from a Dictionary<string, object?> value.
    /// </summary>
    public static RefreshTokenDate FromRefreshTokenDateObject(Dictionary<string, object?> value) =>
        new("refreshTokenDateObject", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "dateTime"
    /// </summary>
    public bool IsDateTime() => Type == "dateTime";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "refreshTokenDateObject"
    /// </summary>
    public bool IsRefreshTokenDateObject() => Type == "refreshTokenDateObject";

    /// <summary>
    /// Returns the value as a <see cref="DateTime"/> if <see cref="Type"/> is 'dateTime', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'dateTime'.</exception>
    public DateTime AsDateTime() =>
        IsDateTime()
            ? (DateTime)Value!
            : throw new ManagementException("Union type is not 'dateTime'");

    /// <summary>
    /// Returns the value as a <see cref="Dictionary<string, object?>"/> if <see cref="Type"/> is 'refreshTokenDateObject', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'refreshTokenDateObject'.</exception>
    public Dictionary<string, object?> AsRefreshTokenDateObject() =>
        IsRefreshTokenDateObject()
            ? (Dictionary<string, object?>)Value!
            : throw new ManagementException("Union type is not 'refreshTokenDateObject'");

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
    public bool TryGetRefreshTokenDateObject(out Dictionary<string, object?>? value)
    {
        if (Type == "refreshTokenDateObject")
        {
            value = (Dictionary<string, object?>)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<DateTime, T> onDateTime,
        Func<Dictionary<string, object?>, T> onRefreshTokenDateObject
    )
    {
        return Type switch
        {
            "dateTime" => onDateTime(AsDateTime()),
            "refreshTokenDateObject" => onRefreshTokenDateObject(AsRefreshTokenDateObject()),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<DateTime> onDateTime,
        global::System.Action<Dictionary<string, object?>> onRefreshTokenDateObject
    )
    {
        switch (Type)
        {
            case "dateTime":
                onDateTime(AsDateTime());
                break;
            case "refreshTokenDateObject":
                onRefreshTokenDateObject(AsRefreshTokenDateObject());
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
        if (obj is not RefreshTokenDate other)
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

    public static implicit operator RefreshTokenDate(DateTime value) => new("dateTime", value);

    public static implicit operator RefreshTokenDate(Dictionary<string, object?> value) =>
        new("refreshTokenDateObject", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<RefreshTokenDate>
    {
        public override RefreshTokenDate? Read(
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
                    RefreshTokenDate dateTimeResult = new("dateTime", dateTimeValue);
                    return dateTimeResult;
                }
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, System.Type Type)[]
                {
                    ("refreshTokenDateObject", typeof(Dictionary<string, object?>)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            RefreshTokenDate result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into RefreshTokenDate"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            RefreshTokenDate value,
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

        public override RefreshTokenDate ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            RefreshTokenDate result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RefreshTokenDate value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
