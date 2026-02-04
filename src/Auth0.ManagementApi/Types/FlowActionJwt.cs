// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionJwt.JsonConverter))]
[Serializable]
public class FlowActionJwt
{
    private FlowActionJwt(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionJwtDecodeJwt value.
    /// </summary>
    public static FlowActionJwt FromFlowActionJwtDecodeJwt(
        Auth0.ManagementApi.FlowActionJwtDecodeJwt value
    ) => new("flowActionJwtDecodeJwt", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionJwtSignJwt value.
    /// </summary>
    public static FlowActionJwt FromFlowActionJwtSignJwt(
        Auth0.ManagementApi.FlowActionJwtSignJwt value
    ) => new("flowActionJwtSignJwt", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionJwtVerifyJwt value.
    /// </summary>
    public static FlowActionJwt FromFlowActionJwtVerifyJwt(
        Auth0.ManagementApi.FlowActionJwtVerifyJwt value
    ) => new("flowActionJwtVerifyJwt", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionJwtDecodeJwt"
    /// </summary>
    public bool IsFlowActionJwtDecodeJwt() => Type == "flowActionJwtDecodeJwt";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionJwtSignJwt"
    /// </summary>
    public bool IsFlowActionJwtSignJwt() => Type == "flowActionJwtSignJwt";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionJwtVerifyJwt"
    /// </summary>
    public bool IsFlowActionJwtVerifyJwt() => Type == "flowActionJwtVerifyJwt";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionJwtDecodeJwt"/> if <see cref="Type"/> is 'flowActionJwtDecodeJwt', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionJwtDecodeJwt'.</exception>
    public Auth0.ManagementApi.FlowActionJwtDecodeJwt AsFlowActionJwtDecodeJwt() =>
        IsFlowActionJwtDecodeJwt()
            ? (Auth0.ManagementApi.FlowActionJwtDecodeJwt)Value!
            : throw new ManagementException("Union type is not 'flowActionJwtDecodeJwt'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionJwtSignJwt"/> if <see cref="Type"/> is 'flowActionJwtSignJwt', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionJwtSignJwt'.</exception>
    public Auth0.ManagementApi.FlowActionJwtSignJwt AsFlowActionJwtSignJwt() =>
        IsFlowActionJwtSignJwt()
            ? (Auth0.ManagementApi.FlowActionJwtSignJwt)Value!
            : throw new ManagementException("Union type is not 'flowActionJwtSignJwt'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionJwtVerifyJwt"/> if <see cref="Type"/> is 'flowActionJwtVerifyJwt', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionJwtVerifyJwt'.</exception>
    public Auth0.ManagementApi.FlowActionJwtVerifyJwt AsFlowActionJwtVerifyJwt() =>
        IsFlowActionJwtVerifyJwt()
            ? (Auth0.ManagementApi.FlowActionJwtVerifyJwt)Value!
            : throw new ManagementException("Union type is not 'flowActionJwtVerifyJwt'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionJwtDecodeJwt"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionJwtDecodeJwt(out Auth0.ManagementApi.FlowActionJwtDecodeJwt? value)
    {
        if (Type == "flowActionJwtDecodeJwt")
        {
            value = (Auth0.ManagementApi.FlowActionJwtDecodeJwt)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionJwtSignJwt"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionJwtSignJwt(out Auth0.ManagementApi.FlowActionJwtSignJwt? value)
    {
        if (Type == "flowActionJwtSignJwt")
        {
            value = (Auth0.ManagementApi.FlowActionJwtSignJwt)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionJwtVerifyJwt"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionJwtVerifyJwt(out Auth0.ManagementApi.FlowActionJwtVerifyJwt? value)
    {
        if (Type == "flowActionJwtVerifyJwt")
        {
            value = (Auth0.ManagementApi.FlowActionJwtVerifyJwt)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.ManagementApi.FlowActionJwtDecodeJwt, T> onFlowActionJwtDecodeJwt,
        Func<Auth0.ManagementApi.FlowActionJwtSignJwt, T> onFlowActionJwtSignJwt,
        Func<Auth0.ManagementApi.FlowActionJwtVerifyJwt, T> onFlowActionJwtVerifyJwt
    )
    {
        return Type switch
        {
            "flowActionJwtDecodeJwt" => onFlowActionJwtDecodeJwt(AsFlowActionJwtDecodeJwt()),
            "flowActionJwtSignJwt" => onFlowActionJwtSignJwt(AsFlowActionJwtSignJwt()),
            "flowActionJwtVerifyJwt" => onFlowActionJwtVerifyJwt(AsFlowActionJwtVerifyJwt()),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.FlowActionJwtDecodeJwt> onFlowActionJwtDecodeJwt,
        System.Action<Auth0.ManagementApi.FlowActionJwtSignJwt> onFlowActionJwtSignJwt,
        System.Action<Auth0.ManagementApi.FlowActionJwtVerifyJwt> onFlowActionJwtVerifyJwt
    )
    {
        switch (Type)
        {
            case "flowActionJwtDecodeJwt":
                onFlowActionJwtDecodeJwt(AsFlowActionJwtDecodeJwt());
                break;
            case "flowActionJwtSignJwt":
                onFlowActionJwtSignJwt(AsFlowActionJwtSignJwt());
                break;
            case "flowActionJwtVerifyJwt":
                onFlowActionJwtVerifyJwt(AsFlowActionJwtVerifyJwt());
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
        if (obj is not FlowActionJwt other)
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

    public static implicit operator FlowActionJwt(
        Auth0.ManagementApi.FlowActionJwtDecodeJwt value
    ) => new("flowActionJwtDecodeJwt", value);

    public static implicit operator FlowActionJwt(Auth0.ManagementApi.FlowActionJwtSignJwt value) =>
        new("flowActionJwtSignJwt", value);

    public static implicit operator FlowActionJwt(
        Auth0.ManagementApi.FlowActionJwtVerifyJwt value
    ) => new("flowActionJwtVerifyJwt", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FlowActionJwt>
    {
        public override FlowActionJwt? Read(
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
                    ("flowActionJwtDecodeJwt", typeof(Auth0.ManagementApi.FlowActionJwtDecodeJwt)),
                    ("flowActionJwtSignJwt", typeof(Auth0.ManagementApi.FlowActionJwtSignJwt)),
                    ("flowActionJwtVerifyJwt", typeof(Auth0.ManagementApi.FlowActionJwtVerifyJwt)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            FlowActionJwt result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into FlowActionJwt"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionJwt value,
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

        public override FlowActionJwt ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            FlowActionJwt result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionJwt value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
