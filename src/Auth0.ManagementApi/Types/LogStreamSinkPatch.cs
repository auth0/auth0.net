// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(LogStreamSinkPatch.JsonConverter))]
[Serializable]
public class LogStreamSinkPatch
{
    private LogStreamSinkPatch(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.LogStreamHttpSink value.
    /// </summary>
    public static LogStreamSinkPatch FromLogStreamHttpSink(
        Auth0.ManagementApi.LogStreamHttpSink value
    ) => new("logStreamHttpSink", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.LogStreamDatadogSink value.
    /// </summary>
    public static LogStreamSinkPatch FromLogStreamDatadogSink(
        Auth0.ManagementApi.LogStreamDatadogSink value
    ) => new("logStreamDatadogSink", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.LogStreamSplunkSink value.
    /// </summary>
    public static LogStreamSinkPatch FromLogStreamSplunkSink(
        Auth0.ManagementApi.LogStreamSplunkSink value
    ) => new("logStreamSplunkSink", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.LogStreamSumoSink value.
    /// </summary>
    public static LogStreamSinkPatch FromLogStreamSumoSink(
        Auth0.ManagementApi.LogStreamSumoSink value
    ) => new("logStreamSumoSink", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.LogStreamSegmentSink value.
    /// </summary>
    public static LogStreamSinkPatch FromLogStreamSegmentSink(
        Auth0.ManagementApi.LogStreamSegmentSink value
    ) => new("logStreamSegmentSink", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.LogStreamMixpanelSinkPatch value.
    /// </summary>
    public static LogStreamSinkPatch FromLogStreamMixpanelSinkPatch(
        Auth0.ManagementApi.LogStreamMixpanelSinkPatch value
    ) => new("logStreamMixpanelSinkPatch", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "logStreamHttpSink"
    /// </summary>
    public bool IsLogStreamHttpSink() => Type == "logStreamHttpSink";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "logStreamDatadogSink"
    /// </summary>
    public bool IsLogStreamDatadogSink() => Type == "logStreamDatadogSink";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "logStreamSplunkSink"
    /// </summary>
    public bool IsLogStreamSplunkSink() => Type == "logStreamSplunkSink";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "logStreamSumoSink"
    /// </summary>
    public bool IsLogStreamSumoSink() => Type == "logStreamSumoSink";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "logStreamSegmentSink"
    /// </summary>
    public bool IsLogStreamSegmentSink() => Type == "logStreamSegmentSink";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "logStreamMixpanelSinkPatch"
    /// </summary>
    public bool IsLogStreamMixpanelSinkPatch() => Type == "logStreamMixpanelSinkPatch";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.LogStreamHttpSink"/> if <see cref="Type"/> is 'logStreamHttpSink', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'logStreamHttpSink'.</exception>
    public Auth0.ManagementApi.LogStreamHttpSink AsLogStreamHttpSink() =>
        IsLogStreamHttpSink()
            ? (Auth0.ManagementApi.LogStreamHttpSink)Value!
            : throw new ManagementException("Union type is not 'logStreamHttpSink'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.LogStreamDatadogSink"/> if <see cref="Type"/> is 'logStreamDatadogSink', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'logStreamDatadogSink'.</exception>
    public Auth0.ManagementApi.LogStreamDatadogSink AsLogStreamDatadogSink() =>
        IsLogStreamDatadogSink()
            ? (Auth0.ManagementApi.LogStreamDatadogSink)Value!
            : throw new ManagementException("Union type is not 'logStreamDatadogSink'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.LogStreamSplunkSink"/> if <see cref="Type"/> is 'logStreamSplunkSink', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'logStreamSplunkSink'.</exception>
    public Auth0.ManagementApi.LogStreamSplunkSink AsLogStreamSplunkSink() =>
        IsLogStreamSplunkSink()
            ? (Auth0.ManagementApi.LogStreamSplunkSink)Value!
            : throw new ManagementException("Union type is not 'logStreamSplunkSink'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.LogStreamSumoSink"/> if <see cref="Type"/> is 'logStreamSumoSink', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'logStreamSumoSink'.</exception>
    public Auth0.ManagementApi.LogStreamSumoSink AsLogStreamSumoSink() =>
        IsLogStreamSumoSink()
            ? (Auth0.ManagementApi.LogStreamSumoSink)Value!
            : throw new ManagementException("Union type is not 'logStreamSumoSink'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.LogStreamSegmentSink"/> if <see cref="Type"/> is 'logStreamSegmentSink', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'logStreamSegmentSink'.</exception>
    public Auth0.ManagementApi.LogStreamSegmentSink AsLogStreamSegmentSink() =>
        IsLogStreamSegmentSink()
            ? (Auth0.ManagementApi.LogStreamSegmentSink)Value!
            : throw new ManagementException("Union type is not 'logStreamSegmentSink'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.LogStreamMixpanelSinkPatch"/> if <see cref="Type"/> is 'logStreamMixpanelSinkPatch', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'logStreamMixpanelSinkPatch'.</exception>
    public Auth0.ManagementApi.LogStreamMixpanelSinkPatch AsLogStreamMixpanelSinkPatch() =>
        IsLogStreamMixpanelSinkPatch()
            ? (Auth0.ManagementApi.LogStreamMixpanelSinkPatch)Value!
            : throw new ManagementException("Union type is not 'logStreamMixpanelSinkPatch'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.LogStreamHttpSink"/> and returns true if successful.
    /// </summary>
    public bool TryGetLogStreamHttpSink(out Auth0.ManagementApi.LogStreamHttpSink? value)
    {
        if (Type == "logStreamHttpSink")
        {
            value = (Auth0.ManagementApi.LogStreamHttpSink)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.LogStreamDatadogSink"/> and returns true if successful.
    /// </summary>
    public bool TryGetLogStreamDatadogSink(out Auth0.ManagementApi.LogStreamDatadogSink? value)
    {
        if (Type == "logStreamDatadogSink")
        {
            value = (Auth0.ManagementApi.LogStreamDatadogSink)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.LogStreamSplunkSink"/> and returns true if successful.
    /// </summary>
    public bool TryGetLogStreamSplunkSink(out Auth0.ManagementApi.LogStreamSplunkSink? value)
    {
        if (Type == "logStreamSplunkSink")
        {
            value = (Auth0.ManagementApi.LogStreamSplunkSink)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.LogStreamSumoSink"/> and returns true if successful.
    /// </summary>
    public bool TryGetLogStreamSumoSink(out Auth0.ManagementApi.LogStreamSumoSink? value)
    {
        if (Type == "logStreamSumoSink")
        {
            value = (Auth0.ManagementApi.LogStreamSumoSink)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.LogStreamSegmentSink"/> and returns true if successful.
    /// </summary>
    public bool TryGetLogStreamSegmentSink(out Auth0.ManagementApi.LogStreamSegmentSink? value)
    {
        if (Type == "logStreamSegmentSink")
        {
            value = (Auth0.ManagementApi.LogStreamSegmentSink)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.LogStreamMixpanelSinkPatch"/> and returns true if successful.
    /// </summary>
    public bool TryGetLogStreamMixpanelSinkPatch(
        out Auth0.ManagementApi.LogStreamMixpanelSinkPatch? value
    )
    {
        if (Type == "logStreamMixpanelSinkPatch")
        {
            value = (Auth0.ManagementApi.LogStreamMixpanelSinkPatch)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.ManagementApi.LogStreamHttpSink, T> onLogStreamHttpSink,
        Func<Auth0.ManagementApi.LogStreamDatadogSink, T> onLogStreamDatadogSink,
        Func<Auth0.ManagementApi.LogStreamSplunkSink, T> onLogStreamSplunkSink,
        Func<Auth0.ManagementApi.LogStreamSumoSink, T> onLogStreamSumoSink,
        Func<Auth0.ManagementApi.LogStreamSegmentSink, T> onLogStreamSegmentSink,
        Func<Auth0.ManagementApi.LogStreamMixpanelSinkPatch, T> onLogStreamMixpanelSinkPatch
    )
    {
        return Type switch
        {
            "logStreamHttpSink" => onLogStreamHttpSink(AsLogStreamHttpSink()),
            "logStreamDatadogSink" => onLogStreamDatadogSink(AsLogStreamDatadogSink()),
            "logStreamSplunkSink" => onLogStreamSplunkSink(AsLogStreamSplunkSink()),
            "logStreamSumoSink" => onLogStreamSumoSink(AsLogStreamSumoSink()),
            "logStreamSegmentSink" => onLogStreamSegmentSink(AsLogStreamSegmentSink()),
            "logStreamMixpanelSinkPatch" => onLogStreamMixpanelSinkPatch(
                AsLogStreamMixpanelSinkPatch()
            ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.LogStreamHttpSink> onLogStreamHttpSink,
        System.Action<Auth0.ManagementApi.LogStreamDatadogSink> onLogStreamDatadogSink,
        System.Action<Auth0.ManagementApi.LogStreamSplunkSink> onLogStreamSplunkSink,
        System.Action<Auth0.ManagementApi.LogStreamSumoSink> onLogStreamSumoSink,
        System.Action<Auth0.ManagementApi.LogStreamSegmentSink> onLogStreamSegmentSink,
        System.Action<Auth0.ManagementApi.LogStreamMixpanelSinkPatch> onLogStreamMixpanelSinkPatch
    )
    {
        switch (Type)
        {
            case "logStreamHttpSink":
                onLogStreamHttpSink(AsLogStreamHttpSink());
                break;
            case "logStreamDatadogSink":
                onLogStreamDatadogSink(AsLogStreamDatadogSink());
                break;
            case "logStreamSplunkSink":
                onLogStreamSplunkSink(AsLogStreamSplunkSink());
                break;
            case "logStreamSumoSink":
                onLogStreamSumoSink(AsLogStreamSumoSink());
                break;
            case "logStreamSegmentSink":
                onLogStreamSegmentSink(AsLogStreamSegmentSink());
                break;
            case "logStreamMixpanelSinkPatch":
                onLogStreamMixpanelSinkPatch(AsLogStreamMixpanelSinkPatch());
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
        if (obj is not LogStreamSinkPatch other)
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

    public static implicit operator LogStreamSinkPatch(
        Auth0.ManagementApi.LogStreamHttpSink value
    ) => new("logStreamHttpSink", value);

    public static implicit operator LogStreamSinkPatch(
        Auth0.ManagementApi.LogStreamDatadogSink value
    ) => new("logStreamDatadogSink", value);

    public static implicit operator LogStreamSinkPatch(
        Auth0.ManagementApi.LogStreamSplunkSink value
    ) => new("logStreamSplunkSink", value);

    public static implicit operator LogStreamSinkPatch(
        Auth0.ManagementApi.LogStreamSumoSink value
    ) => new("logStreamSumoSink", value);

    public static implicit operator LogStreamSinkPatch(
        Auth0.ManagementApi.LogStreamSegmentSink value
    ) => new("logStreamSegmentSink", value);

    public static implicit operator LogStreamSinkPatch(
        Auth0.ManagementApi.LogStreamMixpanelSinkPatch value
    ) => new("logStreamMixpanelSinkPatch", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<LogStreamSinkPatch>
    {
        public override LogStreamSinkPatch? Read(
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
                    ("logStreamHttpSink", typeof(Auth0.ManagementApi.LogStreamHttpSink)),
                    ("logStreamDatadogSink", typeof(Auth0.ManagementApi.LogStreamDatadogSink)),
                    ("logStreamSplunkSink", typeof(Auth0.ManagementApi.LogStreamSplunkSink)),
                    ("logStreamSumoSink", typeof(Auth0.ManagementApi.LogStreamSumoSink)),
                    ("logStreamSegmentSink", typeof(Auth0.ManagementApi.LogStreamSegmentSink)),
                    (
                        "logStreamMixpanelSinkPatch",
                        typeof(Auth0.ManagementApi.LogStreamMixpanelSinkPatch)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            LogStreamSinkPatch result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into LogStreamSinkPatch"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            LogStreamSinkPatch value,
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
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override LogStreamSinkPatch ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            LogStreamSinkPatch result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LogStreamSinkPatch value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
