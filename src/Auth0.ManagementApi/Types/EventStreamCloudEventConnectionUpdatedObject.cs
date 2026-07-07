// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The event content.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventConnectionUpdatedObject.JsonConverter))]
[Serializable]
public class EventStreamCloudEventConnectionUpdatedObject
{
    private EventStreamCloudEventConnectionUpdatedObject(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject0 value.
    /// </summary>
    public static EventStreamCloudEventConnectionUpdatedObject FromEventStreamCloudEventConnectionUpdatedObject0(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject0 value
    ) => new("eventStreamCloudEventConnectionUpdatedObject0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject1 value.
    /// </summary>
    public static EventStreamCloudEventConnectionUpdatedObject FromEventStreamCloudEventConnectionUpdatedObject1(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject1 value
    ) => new("eventStreamCloudEventConnectionUpdatedObject1", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject2 value.
    /// </summary>
    public static EventStreamCloudEventConnectionUpdatedObject FromEventStreamCloudEventConnectionUpdatedObject2(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject2 value
    ) => new("eventStreamCloudEventConnectionUpdatedObject2", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject3 value.
    /// </summary>
    public static EventStreamCloudEventConnectionUpdatedObject FromEventStreamCloudEventConnectionUpdatedObject3(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject3 value
    ) => new("eventStreamCloudEventConnectionUpdatedObject3", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject4 value.
    /// </summary>
    public static EventStreamCloudEventConnectionUpdatedObject FromEventStreamCloudEventConnectionUpdatedObject4(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject4 value
    ) => new("eventStreamCloudEventConnectionUpdatedObject4", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject5 value.
    /// </summary>
    public static EventStreamCloudEventConnectionUpdatedObject FromEventStreamCloudEventConnectionUpdatedObject5(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject5 value
    ) => new("eventStreamCloudEventConnectionUpdatedObject5", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject6 value.
    /// </summary>
    public static EventStreamCloudEventConnectionUpdatedObject FromEventStreamCloudEventConnectionUpdatedObject6(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject6 value
    ) => new("eventStreamCloudEventConnectionUpdatedObject6", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject7 value.
    /// </summary>
    public static EventStreamCloudEventConnectionUpdatedObject FromEventStreamCloudEventConnectionUpdatedObject7(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject7 value
    ) => new("eventStreamCloudEventConnectionUpdatedObject7", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionUpdatedObject0"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionUpdatedObject0() =>
        Type == "eventStreamCloudEventConnectionUpdatedObject0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionUpdatedObject1"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionUpdatedObject1() =>
        Type == "eventStreamCloudEventConnectionUpdatedObject1";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionUpdatedObject2"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionUpdatedObject2() =>
        Type == "eventStreamCloudEventConnectionUpdatedObject2";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionUpdatedObject3"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionUpdatedObject3() =>
        Type == "eventStreamCloudEventConnectionUpdatedObject3";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionUpdatedObject4"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionUpdatedObject4() =>
        Type == "eventStreamCloudEventConnectionUpdatedObject4";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionUpdatedObject5"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionUpdatedObject5() =>
        Type == "eventStreamCloudEventConnectionUpdatedObject5";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionUpdatedObject6"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionUpdatedObject6() =>
        Type == "eventStreamCloudEventConnectionUpdatedObject6";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionUpdatedObject7"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionUpdatedObject7() =>
        Type == "eventStreamCloudEventConnectionUpdatedObject7";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject0"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionUpdatedObject0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionUpdatedObject0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject0 AsEventStreamCloudEventConnectionUpdatedObject0() =>
        IsEventStreamCloudEventConnectionUpdatedObject0()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject0)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionUpdatedObject0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject1"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionUpdatedObject1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionUpdatedObject1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject1 AsEventStreamCloudEventConnectionUpdatedObject1() =>
        IsEventStreamCloudEventConnectionUpdatedObject1()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject1)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionUpdatedObject1'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject2"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionUpdatedObject2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionUpdatedObject2'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject2 AsEventStreamCloudEventConnectionUpdatedObject2() =>
        IsEventStreamCloudEventConnectionUpdatedObject2()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject2)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionUpdatedObject2'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject3"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionUpdatedObject3', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionUpdatedObject3'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject3 AsEventStreamCloudEventConnectionUpdatedObject3() =>
        IsEventStreamCloudEventConnectionUpdatedObject3()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject3)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionUpdatedObject3'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject4"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionUpdatedObject4', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionUpdatedObject4'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject4 AsEventStreamCloudEventConnectionUpdatedObject4() =>
        IsEventStreamCloudEventConnectionUpdatedObject4()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject4)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionUpdatedObject4'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject5"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionUpdatedObject5', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionUpdatedObject5'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject5 AsEventStreamCloudEventConnectionUpdatedObject5() =>
        IsEventStreamCloudEventConnectionUpdatedObject5()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject5)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionUpdatedObject5'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject6"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionUpdatedObject6', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionUpdatedObject6'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject6 AsEventStreamCloudEventConnectionUpdatedObject6() =>
        IsEventStreamCloudEventConnectionUpdatedObject6()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject6)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionUpdatedObject6'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject7"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionUpdatedObject7', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionUpdatedObject7'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject7 AsEventStreamCloudEventConnectionUpdatedObject7() =>
        IsEventStreamCloudEventConnectionUpdatedObject7()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject7)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionUpdatedObject7'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionUpdatedObject0(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject0? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionUpdatedObject0")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject0)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionUpdatedObject1(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject1? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionUpdatedObject1")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject1)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject2"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionUpdatedObject2(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject2? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionUpdatedObject2")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject2)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject3"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionUpdatedObject3(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject3? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionUpdatedObject3")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject3)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject4"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionUpdatedObject4(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject4? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionUpdatedObject4")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject4)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject5"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionUpdatedObject5(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject5? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionUpdatedObject5")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject5)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject6"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionUpdatedObject6(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject6? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionUpdatedObject6")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject6)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject7"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionUpdatedObject7(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject7? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionUpdatedObject7")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject7)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject0,
            T
        > onEventStreamCloudEventConnectionUpdatedObject0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject1,
            T
        > onEventStreamCloudEventConnectionUpdatedObject1,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject2,
            T
        > onEventStreamCloudEventConnectionUpdatedObject2,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject3,
            T
        > onEventStreamCloudEventConnectionUpdatedObject3,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject4,
            T
        > onEventStreamCloudEventConnectionUpdatedObject4,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject5,
            T
        > onEventStreamCloudEventConnectionUpdatedObject5,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject6,
            T
        > onEventStreamCloudEventConnectionUpdatedObject6,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject7,
            T
        > onEventStreamCloudEventConnectionUpdatedObject7
    )
    {
        return Type switch
        {
            "eventStreamCloudEventConnectionUpdatedObject0" =>
                onEventStreamCloudEventConnectionUpdatedObject0(
                    AsEventStreamCloudEventConnectionUpdatedObject0()
                ),
            "eventStreamCloudEventConnectionUpdatedObject1" =>
                onEventStreamCloudEventConnectionUpdatedObject1(
                    AsEventStreamCloudEventConnectionUpdatedObject1()
                ),
            "eventStreamCloudEventConnectionUpdatedObject2" =>
                onEventStreamCloudEventConnectionUpdatedObject2(
                    AsEventStreamCloudEventConnectionUpdatedObject2()
                ),
            "eventStreamCloudEventConnectionUpdatedObject3" =>
                onEventStreamCloudEventConnectionUpdatedObject3(
                    AsEventStreamCloudEventConnectionUpdatedObject3()
                ),
            "eventStreamCloudEventConnectionUpdatedObject4" =>
                onEventStreamCloudEventConnectionUpdatedObject4(
                    AsEventStreamCloudEventConnectionUpdatedObject4()
                ),
            "eventStreamCloudEventConnectionUpdatedObject5" =>
                onEventStreamCloudEventConnectionUpdatedObject5(
                    AsEventStreamCloudEventConnectionUpdatedObject5()
                ),
            "eventStreamCloudEventConnectionUpdatedObject6" =>
                onEventStreamCloudEventConnectionUpdatedObject6(
                    AsEventStreamCloudEventConnectionUpdatedObject6()
                ),
            "eventStreamCloudEventConnectionUpdatedObject7" =>
                onEventStreamCloudEventConnectionUpdatedObject7(
                    AsEventStreamCloudEventConnectionUpdatedObject7()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject0> onEventStreamCloudEventConnectionUpdatedObject0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject1> onEventStreamCloudEventConnectionUpdatedObject1,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject2> onEventStreamCloudEventConnectionUpdatedObject2,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject3> onEventStreamCloudEventConnectionUpdatedObject3,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject4> onEventStreamCloudEventConnectionUpdatedObject4,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject5> onEventStreamCloudEventConnectionUpdatedObject5,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject6> onEventStreamCloudEventConnectionUpdatedObject6,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject7> onEventStreamCloudEventConnectionUpdatedObject7
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventConnectionUpdatedObject0":
                onEventStreamCloudEventConnectionUpdatedObject0(
                    AsEventStreamCloudEventConnectionUpdatedObject0()
                );
                break;
            case "eventStreamCloudEventConnectionUpdatedObject1":
                onEventStreamCloudEventConnectionUpdatedObject1(
                    AsEventStreamCloudEventConnectionUpdatedObject1()
                );
                break;
            case "eventStreamCloudEventConnectionUpdatedObject2":
                onEventStreamCloudEventConnectionUpdatedObject2(
                    AsEventStreamCloudEventConnectionUpdatedObject2()
                );
                break;
            case "eventStreamCloudEventConnectionUpdatedObject3":
                onEventStreamCloudEventConnectionUpdatedObject3(
                    AsEventStreamCloudEventConnectionUpdatedObject3()
                );
                break;
            case "eventStreamCloudEventConnectionUpdatedObject4":
                onEventStreamCloudEventConnectionUpdatedObject4(
                    AsEventStreamCloudEventConnectionUpdatedObject4()
                );
                break;
            case "eventStreamCloudEventConnectionUpdatedObject5":
                onEventStreamCloudEventConnectionUpdatedObject5(
                    AsEventStreamCloudEventConnectionUpdatedObject5()
                );
                break;
            case "eventStreamCloudEventConnectionUpdatedObject6":
                onEventStreamCloudEventConnectionUpdatedObject6(
                    AsEventStreamCloudEventConnectionUpdatedObject6()
                );
                break;
            case "eventStreamCloudEventConnectionUpdatedObject7":
                onEventStreamCloudEventConnectionUpdatedObject7(
                    AsEventStreamCloudEventConnectionUpdatedObject7()
                );
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
        if (obj is not EventStreamCloudEventConnectionUpdatedObject other)
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

    public static implicit operator EventStreamCloudEventConnectionUpdatedObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject0 value
    ) => new("eventStreamCloudEventConnectionUpdatedObject0", value);

    public static implicit operator EventStreamCloudEventConnectionUpdatedObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject1 value
    ) => new("eventStreamCloudEventConnectionUpdatedObject1", value);

    public static implicit operator EventStreamCloudEventConnectionUpdatedObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject2 value
    ) => new("eventStreamCloudEventConnectionUpdatedObject2", value);

    public static implicit operator EventStreamCloudEventConnectionUpdatedObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject3 value
    ) => new("eventStreamCloudEventConnectionUpdatedObject3", value);

    public static implicit operator EventStreamCloudEventConnectionUpdatedObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject4 value
    ) => new("eventStreamCloudEventConnectionUpdatedObject4", value);

    public static implicit operator EventStreamCloudEventConnectionUpdatedObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject5 value
    ) => new("eventStreamCloudEventConnectionUpdatedObject5", value);

    public static implicit operator EventStreamCloudEventConnectionUpdatedObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject6 value
    ) => new("eventStreamCloudEventConnectionUpdatedObject6", value);

    public static implicit operator EventStreamCloudEventConnectionUpdatedObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject7 value
    ) => new("eventStreamCloudEventConnectionUpdatedObject7", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventConnectionUpdatedObject>
    {
        public override EventStreamCloudEventConnectionUpdatedObject? Read(
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
                        "eventStreamCloudEventConnectionUpdatedObject0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject0)
                    ),
                    (
                        "eventStreamCloudEventConnectionUpdatedObject1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject1)
                    ),
                    (
                        "eventStreamCloudEventConnectionUpdatedObject2",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject2)
                    ),
                    (
                        "eventStreamCloudEventConnectionUpdatedObject3",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject3)
                    ),
                    (
                        "eventStreamCloudEventConnectionUpdatedObject4",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject4)
                    ),
                    (
                        "eventStreamCloudEventConnectionUpdatedObject5",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject5)
                    ),
                    (
                        "eventStreamCloudEventConnectionUpdatedObject6",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject6)
                    ),
                    (
                        "eventStreamCloudEventConnectionUpdatedObject7",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedObject7)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventConnectionUpdatedObject result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventConnectionUpdatedObject"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject value,
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
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override EventStreamCloudEventConnectionUpdatedObject ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventConnectionUpdatedObject result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
