// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(SegmentMatchExpression.JsonConverter))]
[Serializable]
public class SegmentMatchExpression
{
    private SegmentMatchExpression(string type, object? value)
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
    /// Factory method to create a union from a IEnumerable<string> value.
    /// </summary>
    public static SegmentMatchExpression FromListOfString(IEnumerable<string> value) =>
        new("list", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.SegmentContainsExpression value.
    /// </summary>
    public static SegmentMatchExpression FromSegmentContainsExpression(
        Auth0.ManagementApi.SegmentContainsExpression value
    ) => new("segmentContainsExpression", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.SegmentStartsWithExpression value.
    /// </summary>
    public static SegmentMatchExpression FromSegmentStartsWithExpression(
        Auth0.ManagementApi.SegmentStartsWithExpression value
    ) => new("segmentStartsWithExpression", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.SegmentEndsWithExpression value.
    /// </summary>
    public static SegmentMatchExpression FromSegmentEndsWithExpression(
        Auth0.ManagementApi.SegmentEndsWithExpression value
    ) => new("segmentEndsWithExpression", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.SegmentExistsExpression value.
    /// </summary>
    public static SegmentMatchExpression FromSegmentExistsExpression(
        Auth0.ManagementApi.SegmentExistsExpression value
    ) => new("segmentExistsExpression", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "list"
    /// </summary>
    public bool IsListOfString() => Type == "list";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "segmentContainsExpression"
    /// </summary>
    public bool IsSegmentContainsExpression() => Type == "segmentContainsExpression";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "segmentStartsWithExpression"
    /// </summary>
    public bool IsSegmentStartsWithExpression() => Type == "segmentStartsWithExpression";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "segmentEndsWithExpression"
    /// </summary>
    public bool IsSegmentEndsWithExpression() => Type == "segmentEndsWithExpression";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "segmentExistsExpression"
    /// </summary>
    public bool IsSegmentExistsExpression() => Type == "segmentExistsExpression";

    /// <summary>
    /// Returns the value as a <see cref="IEnumerable<string>"/> if <see cref="Type"/> is 'list', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'list'.</exception>
    public IEnumerable<string> AsListOfString() =>
        IsListOfString()
            ? (IEnumerable<string>)Value!
            : throw new ManagementException("Union type is not 'list'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.SegmentContainsExpression"/> if <see cref="Type"/> is 'segmentContainsExpression', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'segmentContainsExpression'.</exception>
    public Auth0.ManagementApi.SegmentContainsExpression AsSegmentContainsExpression() =>
        IsSegmentContainsExpression()
            ? (Auth0.ManagementApi.SegmentContainsExpression)Value!
            : throw new ManagementException("Union type is not 'segmentContainsExpression'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.SegmentStartsWithExpression"/> if <see cref="Type"/> is 'segmentStartsWithExpression', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'segmentStartsWithExpression'.</exception>
    public Auth0.ManagementApi.SegmentStartsWithExpression AsSegmentStartsWithExpression() =>
        IsSegmentStartsWithExpression()
            ? (Auth0.ManagementApi.SegmentStartsWithExpression)Value!
            : throw new ManagementException("Union type is not 'segmentStartsWithExpression'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.SegmentEndsWithExpression"/> if <see cref="Type"/> is 'segmentEndsWithExpression', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'segmentEndsWithExpression'.</exception>
    public Auth0.ManagementApi.SegmentEndsWithExpression AsSegmentEndsWithExpression() =>
        IsSegmentEndsWithExpression()
            ? (Auth0.ManagementApi.SegmentEndsWithExpression)Value!
            : throw new ManagementException("Union type is not 'segmentEndsWithExpression'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.SegmentExistsExpression"/> if <see cref="Type"/> is 'segmentExistsExpression', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'segmentExistsExpression'.</exception>
    public Auth0.ManagementApi.SegmentExistsExpression AsSegmentExistsExpression() =>
        IsSegmentExistsExpression()
            ? (Auth0.ManagementApi.SegmentExistsExpression)Value!
            : throw new ManagementException("Union type is not 'segmentExistsExpression'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="IEnumerable<string>"/> and returns true if successful.
    /// </summary>
    public bool TryGetListOfString(out IEnumerable<string>? value)
    {
        if (Type == "list")
        {
            value = (IEnumerable<string>)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.SegmentContainsExpression"/> and returns true if successful.
    /// </summary>
    public bool TryGetSegmentContainsExpression(
        out Auth0.ManagementApi.SegmentContainsExpression? value
    )
    {
        if (Type == "segmentContainsExpression")
        {
            value = (Auth0.ManagementApi.SegmentContainsExpression)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.SegmentStartsWithExpression"/> and returns true if successful.
    /// </summary>
    public bool TryGetSegmentStartsWithExpression(
        out Auth0.ManagementApi.SegmentStartsWithExpression? value
    )
    {
        if (Type == "segmentStartsWithExpression")
        {
            value = (Auth0.ManagementApi.SegmentStartsWithExpression)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.SegmentEndsWithExpression"/> and returns true if successful.
    /// </summary>
    public bool TryGetSegmentEndsWithExpression(
        out Auth0.ManagementApi.SegmentEndsWithExpression? value
    )
    {
        if (Type == "segmentEndsWithExpression")
        {
            value = (Auth0.ManagementApi.SegmentEndsWithExpression)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.SegmentExistsExpression"/> and returns true if successful.
    /// </summary>
    public bool TryGetSegmentExistsExpression(
        out Auth0.ManagementApi.SegmentExistsExpression? value
    )
    {
        if (Type == "segmentExistsExpression")
        {
            value = (Auth0.ManagementApi.SegmentExistsExpression)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<IEnumerable<string>, T> onListOfString,
        Func<Auth0.ManagementApi.SegmentContainsExpression, T> onSegmentContainsExpression,
        Func<Auth0.ManagementApi.SegmentStartsWithExpression, T> onSegmentStartsWithExpression,
        Func<Auth0.ManagementApi.SegmentEndsWithExpression, T> onSegmentEndsWithExpression,
        Func<Auth0.ManagementApi.SegmentExistsExpression, T> onSegmentExistsExpression
    )
    {
        return Type switch
        {
            "list" => onListOfString(AsListOfString()),
            "segmentContainsExpression" => onSegmentContainsExpression(
                AsSegmentContainsExpression()
            ),
            "segmentStartsWithExpression" => onSegmentStartsWithExpression(
                AsSegmentStartsWithExpression()
            ),
            "segmentEndsWithExpression" => onSegmentEndsWithExpression(
                AsSegmentEndsWithExpression()
            ),
            "segmentExistsExpression" => onSegmentExistsExpression(AsSegmentExistsExpression()),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<IEnumerable<string>> onListOfString,
        global::System.Action<Auth0.ManagementApi.SegmentContainsExpression> onSegmentContainsExpression,
        global::System.Action<Auth0.ManagementApi.SegmentStartsWithExpression> onSegmentStartsWithExpression,
        global::System.Action<Auth0.ManagementApi.SegmentEndsWithExpression> onSegmentEndsWithExpression,
        global::System.Action<Auth0.ManagementApi.SegmentExistsExpression> onSegmentExistsExpression
    )
    {
        switch (Type)
        {
            case "list":
                onListOfString(AsListOfString());
                break;
            case "segmentContainsExpression":
                onSegmentContainsExpression(AsSegmentContainsExpression());
                break;
            case "segmentStartsWithExpression":
                onSegmentStartsWithExpression(AsSegmentStartsWithExpression());
                break;
            case "segmentEndsWithExpression":
                onSegmentEndsWithExpression(AsSegmentEndsWithExpression());
                break;
            case "segmentExistsExpression":
                onSegmentExistsExpression(AsSegmentExistsExpression());
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
        if (obj is not SegmentMatchExpression other)
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

    public static implicit operator SegmentMatchExpression(
        Auth0.ManagementApi.SegmentContainsExpression value
    ) => new("segmentContainsExpression", value);

    public static implicit operator SegmentMatchExpression(
        Auth0.ManagementApi.SegmentStartsWithExpression value
    ) => new("segmentStartsWithExpression", value);

    public static implicit operator SegmentMatchExpression(
        Auth0.ManagementApi.SegmentEndsWithExpression value
    ) => new("segmentEndsWithExpression", value);

    public static implicit operator SegmentMatchExpression(
        Auth0.ManagementApi.SegmentExistsExpression value
    ) => new("segmentExistsExpression", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<SegmentMatchExpression>
    {
        public override SegmentMatchExpression? Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.StartArray)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, System.Type Type)[]
                {
                    ("list", typeof(IEnumerable<string>)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            SegmentMatchExpression result = new(key, value);
                            return result;
                        }
                    }
                    catch (JsonException)
                    {
                        // Try next type;
                    }
                }
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, System.Type Type)[]
                {
                    (
                        "segmentContainsExpression",
                        typeof(Auth0.ManagementApi.SegmentContainsExpression)
                    ),
                    (
                        "segmentStartsWithExpression",
                        typeof(Auth0.ManagementApi.SegmentStartsWithExpression)
                    ),
                    (
                        "segmentEndsWithExpression",
                        typeof(Auth0.ManagementApi.SegmentEndsWithExpression)
                    ),
                    (
                        "segmentExistsExpression",
                        typeof(Auth0.ManagementApi.SegmentExistsExpression)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            SegmentMatchExpression result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into SegmentMatchExpression"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            SegmentMatchExpression value,
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
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override SegmentMatchExpression ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            SegmentMatchExpression result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SegmentMatchExpression value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
