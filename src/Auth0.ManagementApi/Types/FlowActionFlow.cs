// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionFlow.JsonConverter))]
[Serializable]
public class FlowActionFlow
{
    private FlowActionFlow(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionFlowBooleanCondition value.
    /// </summary>
    public static FlowActionFlow FromFlowActionFlowBooleanCondition(
        Auth0.ManagementApi.FlowActionFlowBooleanCondition value
    ) => new("flowActionFlowBooleanCondition", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionFlowDelayFlow value.
    /// </summary>
    public static FlowActionFlow FromFlowActionFlowDelayFlow(
        Auth0.ManagementApi.FlowActionFlowDelayFlow value
    ) => new("flowActionFlowDelayFlow", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionFlowDoNothing value.
    /// </summary>
    public static FlowActionFlow FromFlowActionFlowDoNothing(
        Auth0.ManagementApi.FlowActionFlowDoNothing value
    ) => new("flowActionFlowDoNothing", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionFlowErrorMessage value.
    /// </summary>
    public static FlowActionFlow FromFlowActionFlowErrorMessage(
        Auth0.ManagementApi.FlowActionFlowErrorMessage value
    ) => new("flowActionFlowErrorMessage", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionFlowMapValue value.
    /// </summary>
    public static FlowActionFlow FromFlowActionFlowMapValue(
        Auth0.ManagementApi.FlowActionFlowMapValue value
    ) => new("flowActionFlowMapValue", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionFlowReturnJson value.
    /// </summary>
    public static FlowActionFlow FromFlowActionFlowReturnJson(
        Auth0.ManagementApi.FlowActionFlowReturnJson value
    ) => new("flowActionFlowReturnJson", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionFlowStoreVars value.
    /// </summary>
    public static FlowActionFlow FromFlowActionFlowStoreVars(
        Auth0.ManagementApi.FlowActionFlowStoreVars value
    ) => new("flowActionFlowStoreVars", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionFlowBooleanCondition"
    /// </summary>
    public bool IsFlowActionFlowBooleanCondition() => Type == "flowActionFlowBooleanCondition";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionFlowDelayFlow"
    /// </summary>
    public bool IsFlowActionFlowDelayFlow() => Type == "flowActionFlowDelayFlow";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionFlowDoNothing"
    /// </summary>
    public bool IsFlowActionFlowDoNothing() => Type == "flowActionFlowDoNothing";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionFlowErrorMessage"
    /// </summary>
    public bool IsFlowActionFlowErrorMessage() => Type == "flowActionFlowErrorMessage";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionFlowMapValue"
    /// </summary>
    public bool IsFlowActionFlowMapValue() => Type == "flowActionFlowMapValue";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionFlowReturnJson"
    /// </summary>
    public bool IsFlowActionFlowReturnJson() => Type == "flowActionFlowReturnJson";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionFlowStoreVars"
    /// </summary>
    public bool IsFlowActionFlowStoreVars() => Type == "flowActionFlowStoreVars";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionFlowBooleanCondition"/> if <see cref="Type"/> is 'flowActionFlowBooleanCondition', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionFlowBooleanCondition'.</exception>
    public Auth0.ManagementApi.FlowActionFlowBooleanCondition AsFlowActionFlowBooleanCondition() =>
        IsFlowActionFlowBooleanCondition()
            ? (Auth0.ManagementApi.FlowActionFlowBooleanCondition)Value!
            : throw new ManagementException("Union type is not 'flowActionFlowBooleanCondition'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionFlowDelayFlow"/> if <see cref="Type"/> is 'flowActionFlowDelayFlow', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionFlowDelayFlow'.</exception>
    public Auth0.ManagementApi.FlowActionFlowDelayFlow AsFlowActionFlowDelayFlow() =>
        IsFlowActionFlowDelayFlow()
            ? (Auth0.ManagementApi.FlowActionFlowDelayFlow)Value!
            : throw new ManagementException("Union type is not 'flowActionFlowDelayFlow'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionFlowDoNothing"/> if <see cref="Type"/> is 'flowActionFlowDoNothing', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionFlowDoNothing'.</exception>
    public Auth0.ManagementApi.FlowActionFlowDoNothing AsFlowActionFlowDoNothing() =>
        IsFlowActionFlowDoNothing()
            ? (Auth0.ManagementApi.FlowActionFlowDoNothing)Value!
            : throw new ManagementException("Union type is not 'flowActionFlowDoNothing'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionFlowErrorMessage"/> if <see cref="Type"/> is 'flowActionFlowErrorMessage', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionFlowErrorMessage'.</exception>
    public Auth0.ManagementApi.FlowActionFlowErrorMessage AsFlowActionFlowErrorMessage() =>
        IsFlowActionFlowErrorMessage()
            ? (Auth0.ManagementApi.FlowActionFlowErrorMessage)Value!
            : throw new ManagementException("Union type is not 'flowActionFlowErrorMessage'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionFlowMapValue"/> if <see cref="Type"/> is 'flowActionFlowMapValue', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionFlowMapValue'.</exception>
    public Auth0.ManagementApi.FlowActionFlowMapValue AsFlowActionFlowMapValue() =>
        IsFlowActionFlowMapValue()
            ? (Auth0.ManagementApi.FlowActionFlowMapValue)Value!
            : throw new ManagementException("Union type is not 'flowActionFlowMapValue'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionFlowReturnJson"/> if <see cref="Type"/> is 'flowActionFlowReturnJson', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionFlowReturnJson'.</exception>
    public Auth0.ManagementApi.FlowActionFlowReturnJson AsFlowActionFlowReturnJson() =>
        IsFlowActionFlowReturnJson()
            ? (Auth0.ManagementApi.FlowActionFlowReturnJson)Value!
            : throw new ManagementException("Union type is not 'flowActionFlowReturnJson'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionFlowStoreVars"/> if <see cref="Type"/> is 'flowActionFlowStoreVars', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionFlowStoreVars'.</exception>
    public Auth0.ManagementApi.FlowActionFlowStoreVars AsFlowActionFlowStoreVars() =>
        IsFlowActionFlowStoreVars()
            ? (Auth0.ManagementApi.FlowActionFlowStoreVars)Value!
            : throw new ManagementException("Union type is not 'flowActionFlowStoreVars'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionFlowBooleanCondition"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionFlowBooleanCondition(
        out Auth0.ManagementApi.FlowActionFlowBooleanCondition? value
    )
    {
        if (Type == "flowActionFlowBooleanCondition")
        {
            value = (Auth0.ManagementApi.FlowActionFlowBooleanCondition)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionFlowDelayFlow"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionFlowDelayFlow(
        out Auth0.ManagementApi.FlowActionFlowDelayFlow? value
    )
    {
        if (Type == "flowActionFlowDelayFlow")
        {
            value = (Auth0.ManagementApi.FlowActionFlowDelayFlow)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionFlowDoNothing"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionFlowDoNothing(
        out Auth0.ManagementApi.FlowActionFlowDoNothing? value
    )
    {
        if (Type == "flowActionFlowDoNothing")
        {
            value = (Auth0.ManagementApi.FlowActionFlowDoNothing)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionFlowErrorMessage"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionFlowErrorMessage(
        out Auth0.ManagementApi.FlowActionFlowErrorMessage? value
    )
    {
        if (Type == "flowActionFlowErrorMessage")
        {
            value = (Auth0.ManagementApi.FlowActionFlowErrorMessage)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionFlowMapValue"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionFlowMapValue(out Auth0.ManagementApi.FlowActionFlowMapValue? value)
    {
        if (Type == "flowActionFlowMapValue")
        {
            value = (Auth0.ManagementApi.FlowActionFlowMapValue)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionFlowReturnJson"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionFlowReturnJson(
        out Auth0.ManagementApi.FlowActionFlowReturnJson? value
    )
    {
        if (Type == "flowActionFlowReturnJson")
        {
            value = (Auth0.ManagementApi.FlowActionFlowReturnJson)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionFlowStoreVars"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionFlowStoreVars(
        out Auth0.ManagementApi.FlowActionFlowStoreVars? value
    )
    {
        if (Type == "flowActionFlowStoreVars")
        {
            value = (Auth0.ManagementApi.FlowActionFlowStoreVars)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.FlowActionFlowBooleanCondition,
            T
        > onFlowActionFlowBooleanCondition,
        Func<Auth0.ManagementApi.FlowActionFlowDelayFlow, T> onFlowActionFlowDelayFlow,
        Func<Auth0.ManagementApi.FlowActionFlowDoNothing, T> onFlowActionFlowDoNothing,
        Func<Auth0.ManagementApi.FlowActionFlowErrorMessage, T> onFlowActionFlowErrorMessage,
        Func<Auth0.ManagementApi.FlowActionFlowMapValue, T> onFlowActionFlowMapValue,
        Func<Auth0.ManagementApi.FlowActionFlowReturnJson, T> onFlowActionFlowReturnJson,
        Func<Auth0.ManagementApi.FlowActionFlowStoreVars, T> onFlowActionFlowStoreVars
    )
    {
        return Type switch
        {
            "flowActionFlowBooleanCondition" => onFlowActionFlowBooleanCondition(
                AsFlowActionFlowBooleanCondition()
            ),
            "flowActionFlowDelayFlow" => onFlowActionFlowDelayFlow(AsFlowActionFlowDelayFlow()),
            "flowActionFlowDoNothing" => onFlowActionFlowDoNothing(AsFlowActionFlowDoNothing()),
            "flowActionFlowErrorMessage" => onFlowActionFlowErrorMessage(
                AsFlowActionFlowErrorMessage()
            ),
            "flowActionFlowMapValue" => onFlowActionFlowMapValue(AsFlowActionFlowMapValue()),
            "flowActionFlowReturnJson" => onFlowActionFlowReturnJson(AsFlowActionFlowReturnJson()),
            "flowActionFlowStoreVars" => onFlowActionFlowStoreVars(AsFlowActionFlowStoreVars()),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.FlowActionFlowBooleanCondition> onFlowActionFlowBooleanCondition,
        global::System.Action<Auth0.ManagementApi.FlowActionFlowDelayFlow> onFlowActionFlowDelayFlow,
        global::System.Action<Auth0.ManagementApi.FlowActionFlowDoNothing> onFlowActionFlowDoNothing,
        global::System.Action<Auth0.ManagementApi.FlowActionFlowErrorMessage> onFlowActionFlowErrorMessage,
        global::System.Action<Auth0.ManagementApi.FlowActionFlowMapValue> onFlowActionFlowMapValue,
        global::System.Action<Auth0.ManagementApi.FlowActionFlowReturnJson> onFlowActionFlowReturnJson,
        global::System.Action<Auth0.ManagementApi.FlowActionFlowStoreVars> onFlowActionFlowStoreVars
    )
    {
        switch (Type)
        {
            case "flowActionFlowBooleanCondition":
                onFlowActionFlowBooleanCondition(AsFlowActionFlowBooleanCondition());
                break;
            case "flowActionFlowDelayFlow":
                onFlowActionFlowDelayFlow(AsFlowActionFlowDelayFlow());
                break;
            case "flowActionFlowDoNothing":
                onFlowActionFlowDoNothing(AsFlowActionFlowDoNothing());
                break;
            case "flowActionFlowErrorMessage":
                onFlowActionFlowErrorMessage(AsFlowActionFlowErrorMessage());
                break;
            case "flowActionFlowMapValue":
                onFlowActionFlowMapValue(AsFlowActionFlowMapValue());
                break;
            case "flowActionFlowReturnJson":
                onFlowActionFlowReturnJson(AsFlowActionFlowReturnJson());
                break;
            case "flowActionFlowStoreVars":
                onFlowActionFlowStoreVars(AsFlowActionFlowStoreVars());
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
        if (obj is not FlowActionFlow other)
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

    public static implicit operator FlowActionFlow(
        Auth0.ManagementApi.FlowActionFlowBooleanCondition value
    ) => new("flowActionFlowBooleanCondition", value);

    public static implicit operator FlowActionFlow(
        Auth0.ManagementApi.FlowActionFlowDelayFlow value
    ) => new("flowActionFlowDelayFlow", value);

    public static implicit operator FlowActionFlow(
        Auth0.ManagementApi.FlowActionFlowDoNothing value
    ) => new("flowActionFlowDoNothing", value);

    public static implicit operator FlowActionFlow(
        Auth0.ManagementApi.FlowActionFlowErrorMessage value
    ) => new("flowActionFlowErrorMessage", value);

    public static implicit operator FlowActionFlow(
        Auth0.ManagementApi.FlowActionFlowMapValue value
    ) => new("flowActionFlowMapValue", value);

    public static implicit operator FlowActionFlow(
        Auth0.ManagementApi.FlowActionFlowReturnJson value
    ) => new("flowActionFlowReturnJson", value);

    public static implicit operator FlowActionFlow(
        Auth0.ManagementApi.FlowActionFlowStoreVars value
    ) => new("flowActionFlowStoreVars", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FlowActionFlow>
    {
        public override FlowActionFlow? Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
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
                        "flowActionFlowBooleanCondition",
                        typeof(Auth0.ManagementApi.FlowActionFlowBooleanCondition)
                    ),
                    (
                        "flowActionFlowDelayFlow",
                        typeof(Auth0.ManagementApi.FlowActionFlowDelayFlow)
                    ),
                    (
                        "flowActionFlowDoNothing",
                        typeof(Auth0.ManagementApi.FlowActionFlowDoNothing)
                    ),
                    (
                        "flowActionFlowErrorMessage",
                        typeof(Auth0.ManagementApi.FlowActionFlowErrorMessage)
                    ),
                    ("flowActionFlowMapValue", typeof(Auth0.ManagementApi.FlowActionFlowMapValue)),
                    (
                        "flowActionFlowReturnJson",
                        typeof(Auth0.ManagementApi.FlowActionFlowReturnJson)
                    ),
                    (
                        "flowActionFlowStoreVars",
                        typeof(Auth0.ManagementApi.FlowActionFlowStoreVars)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            FlowActionFlow result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into FlowActionFlow"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionFlow value,
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
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override FlowActionFlow ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            FlowActionFlow result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionFlow value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
