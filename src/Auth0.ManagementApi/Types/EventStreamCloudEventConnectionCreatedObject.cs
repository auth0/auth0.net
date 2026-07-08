// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The event content.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventConnectionCreatedObject.JsonConverter))]
[Serializable]
public class EventStreamCloudEventConnectionCreatedObject
{
    private EventStreamCloudEventConnectionCreatedObject(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject0 value.
    /// </summary>
    public static EventStreamCloudEventConnectionCreatedObject FromEventStreamCloudEventConnectionCreatedObject0(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject0 value
    ) => new("eventStreamCloudEventConnectionCreatedObject0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject1 value.
    /// </summary>
    public static EventStreamCloudEventConnectionCreatedObject FromEventStreamCloudEventConnectionCreatedObject1(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject1 value
    ) => new("eventStreamCloudEventConnectionCreatedObject1", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject2 value.
    /// </summary>
    public static EventStreamCloudEventConnectionCreatedObject FromEventStreamCloudEventConnectionCreatedObject2(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject2 value
    ) => new("eventStreamCloudEventConnectionCreatedObject2", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject3 value.
    /// </summary>
    public static EventStreamCloudEventConnectionCreatedObject FromEventStreamCloudEventConnectionCreatedObject3(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject3 value
    ) => new("eventStreamCloudEventConnectionCreatedObject3", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject4 value.
    /// </summary>
    public static EventStreamCloudEventConnectionCreatedObject FromEventStreamCloudEventConnectionCreatedObject4(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject4 value
    ) => new("eventStreamCloudEventConnectionCreatedObject4", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject5 value.
    /// </summary>
    public static EventStreamCloudEventConnectionCreatedObject FromEventStreamCloudEventConnectionCreatedObject5(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject5 value
    ) => new("eventStreamCloudEventConnectionCreatedObject5", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject6 value.
    /// </summary>
    public static EventStreamCloudEventConnectionCreatedObject FromEventStreamCloudEventConnectionCreatedObject6(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject6 value
    ) => new("eventStreamCloudEventConnectionCreatedObject6", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject7 value.
    /// </summary>
    public static EventStreamCloudEventConnectionCreatedObject FromEventStreamCloudEventConnectionCreatedObject7(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject7 value
    ) => new("eventStreamCloudEventConnectionCreatedObject7", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionCreatedObject0"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionCreatedObject0() =>
        Type == "eventStreamCloudEventConnectionCreatedObject0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionCreatedObject1"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionCreatedObject1() =>
        Type == "eventStreamCloudEventConnectionCreatedObject1";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionCreatedObject2"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionCreatedObject2() =>
        Type == "eventStreamCloudEventConnectionCreatedObject2";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionCreatedObject3"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionCreatedObject3() =>
        Type == "eventStreamCloudEventConnectionCreatedObject3";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionCreatedObject4"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionCreatedObject4() =>
        Type == "eventStreamCloudEventConnectionCreatedObject4";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionCreatedObject5"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionCreatedObject5() =>
        Type == "eventStreamCloudEventConnectionCreatedObject5";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionCreatedObject6"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionCreatedObject6() =>
        Type == "eventStreamCloudEventConnectionCreatedObject6";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionCreatedObject7"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionCreatedObject7() =>
        Type == "eventStreamCloudEventConnectionCreatedObject7";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject0"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionCreatedObject0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionCreatedObject0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject0 AsEventStreamCloudEventConnectionCreatedObject0() =>
        IsEventStreamCloudEventConnectionCreatedObject0()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject0)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionCreatedObject0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject1"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionCreatedObject1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionCreatedObject1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject1 AsEventStreamCloudEventConnectionCreatedObject1() =>
        IsEventStreamCloudEventConnectionCreatedObject1()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject1)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionCreatedObject1'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject2"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionCreatedObject2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionCreatedObject2'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject2 AsEventStreamCloudEventConnectionCreatedObject2() =>
        IsEventStreamCloudEventConnectionCreatedObject2()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject2)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionCreatedObject2'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject3"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionCreatedObject3', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionCreatedObject3'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject3 AsEventStreamCloudEventConnectionCreatedObject3() =>
        IsEventStreamCloudEventConnectionCreatedObject3()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject3)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionCreatedObject3'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject4"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionCreatedObject4', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionCreatedObject4'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject4 AsEventStreamCloudEventConnectionCreatedObject4() =>
        IsEventStreamCloudEventConnectionCreatedObject4()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject4)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionCreatedObject4'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject5"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionCreatedObject5', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionCreatedObject5'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject5 AsEventStreamCloudEventConnectionCreatedObject5() =>
        IsEventStreamCloudEventConnectionCreatedObject5()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject5)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionCreatedObject5'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject6"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionCreatedObject6', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionCreatedObject6'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject6 AsEventStreamCloudEventConnectionCreatedObject6() =>
        IsEventStreamCloudEventConnectionCreatedObject6()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject6)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionCreatedObject6'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject7"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionCreatedObject7', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionCreatedObject7'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject7 AsEventStreamCloudEventConnectionCreatedObject7() =>
        IsEventStreamCloudEventConnectionCreatedObject7()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject7)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionCreatedObject7'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionCreatedObject0(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject0? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionCreatedObject0")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject0)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionCreatedObject1(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject1? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionCreatedObject1")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject1)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject2"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionCreatedObject2(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject2? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionCreatedObject2")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject2)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject3"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionCreatedObject3(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject3? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionCreatedObject3")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject3)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject4"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionCreatedObject4(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject4? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionCreatedObject4")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject4)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject5"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionCreatedObject5(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject5? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionCreatedObject5")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject5)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject6"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionCreatedObject6(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject6? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionCreatedObject6")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject6)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject7"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionCreatedObject7(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject7? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionCreatedObject7")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject7)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject0,
            T
        > onEventStreamCloudEventConnectionCreatedObject0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject1,
            T
        > onEventStreamCloudEventConnectionCreatedObject1,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject2,
            T
        > onEventStreamCloudEventConnectionCreatedObject2,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject3,
            T
        > onEventStreamCloudEventConnectionCreatedObject3,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject4,
            T
        > onEventStreamCloudEventConnectionCreatedObject4,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject5,
            T
        > onEventStreamCloudEventConnectionCreatedObject5,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject6,
            T
        > onEventStreamCloudEventConnectionCreatedObject6,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject7,
            T
        > onEventStreamCloudEventConnectionCreatedObject7
    )
    {
        return Type switch
        {
            "eventStreamCloudEventConnectionCreatedObject0" =>
                onEventStreamCloudEventConnectionCreatedObject0(
                    AsEventStreamCloudEventConnectionCreatedObject0()
                ),
            "eventStreamCloudEventConnectionCreatedObject1" =>
                onEventStreamCloudEventConnectionCreatedObject1(
                    AsEventStreamCloudEventConnectionCreatedObject1()
                ),
            "eventStreamCloudEventConnectionCreatedObject2" =>
                onEventStreamCloudEventConnectionCreatedObject2(
                    AsEventStreamCloudEventConnectionCreatedObject2()
                ),
            "eventStreamCloudEventConnectionCreatedObject3" =>
                onEventStreamCloudEventConnectionCreatedObject3(
                    AsEventStreamCloudEventConnectionCreatedObject3()
                ),
            "eventStreamCloudEventConnectionCreatedObject4" =>
                onEventStreamCloudEventConnectionCreatedObject4(
                    AsEventStreamCloudEventConnectionCreatedObject4()
                ),
            "eventStreamCloudEventConnectionCreatedObject5" =>
                onEventStreamCloudEventConnectionCreatedObject5(
                    AsEventStreamCloudEventConnectionCreatedObject5()
                ),
            "eventStreamCloudEventConnectionCreatedObject6" =>
                onEventStreamCloudEventConnectionCreatedObject6(
                    AsEventStreamCloudEventConnectionCreatedObject6()
                ),
            "eventStreamCloudEventConnectionCreatedObject7" =>
                onEventStreamCloudEventConnectionCreatedObject7(
                    AsEventStreamCloudEventConnectionCreatedObject7()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject0> onEventStreamCloudEventConnectionCreatedObject0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject1> onEventStreamCloudEventConnectionCreatedObject1,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject2> onEventStreamCloudEventConnectionCreatedObject2,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject3> onEventStreamCloudEventConnectionCreatedObject3,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject4> onEventStreamCloudEventConnectionCreatedObject4,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject5> onEventStreamCloudEventConnectionCreatedObject5,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject6> onEventStreamCloudEventConnectionCreatedObject6,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject7> onEventStreamCloudEventConnectionCreatedObject7
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventConnectionCreatedObject0":
                onEventStreamCloudEventConnectionCreatedObject0(
                    AsEventStreamCloudEventConnectionCreatedObject0()
                );
                break;
            case "eventStreamCloudEventConnectionCreatedObject1":
                onEventStreamCloudEventConnectionCreatedObject1(
                    AsEventStreamCloudEventConnectionCreatedObject1()
                );
                break;
            case "eventStreamCloudEventConnectionCreatedObject2":
                onEventStreamCloudEventConnectionCreatedObject2(
                    AsEventStreamCloudEventConnectionCreatedObject2()
                );
                break;
            case "eventStreamCloudEventConnectionCreatedObject3":
                onEventStreamCloudEventConnectionCreatedObject3(
                    AsEventStreamCloudEventConnectionCreatedObject3()
                );
                break;
            case "eventStreamCloudEventConnectionCreatedObject4":
                onEventStreamCloudEventConnectionCreatedObject4(
                    AsEventStreamCloudEventConnectionCreatedObject4()
                );
                break;
            case "eventStreamCloudEventConnectionCreatedObject5":
                onEventStreamCloudEventConnectionCreatedObject5(
                    AsEventStreamCloudEventConnectionCreatedObject5()
                );
                break;
            case "eventStreamCloudEventConnectionCreatedObject6":
                onEventStreamCloudEventConnectionCreatedObject6(
                    AsEventStreamCloudEventConnectionCreatedObject6()
                );
                break;
            case "eventStreamCloudEventConnectionCreatedObject7":
                onEventStreamCloudEventConnectionCreatedObject7(
                    AsEventStreamCloudEventConnectionCreatedObject7()
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
        if (obj is not EventStreamCloudEventConnectionCreatedObject other)
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

    public static implicit operator EventStreamCloudEventConnectionCreatedObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject0 value
    ) => new("eventStreamCloudEventConnectionCreatedObject0", value);

    public static implicit operator EventStreamCloudEventConnectionCreatedObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject1 value
    ) => new("eventStreamCloudEventConnectionCreatedObject1", value);

    public static implicit operator EventStreamCloudEventConnectionCreatedObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject2 value
    ) => new("eventStreamCloudEventConnectionCreatedObject2", value);

    public static implicit operator EventStreamCloudEventConnectionCreatedObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject3 value
    ) => new("eventStreamCloudEventConnectionCreatedObject3", value);

    public static implicit operator EventStreamCloudEventConnectionCreatedObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject4 value
    ) => new("eventStreamCloudEventConnectionCreatedObject4", value);

    public static implicit operator EventStreamCloudEventConnectionCreatedObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject5 value
    ) => new("eventStreamCloudEventConnectionCreatedObject5", value);

    public static implicit operator EventStreamCloudEventConnectionCreatedObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject6 value
    ) => new("eventStreamCloudEventConnectionCreatedObject6", value);

    public static implicit operator EventStreamCloudEventConnectionCreatedObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject7 value
    ) => new("eventStreamCloudEventConnectionCreatedObject7", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventConnectionCreatedObject>
    {
        public override EventStreamCloudEventConnectionCreatedObject? Read(
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
                        "eventStreamCloudEventConnectionCreatedObject0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject0)
                    ),
                    (
                        "eventStreamCloudEventConnectionCreatedObject1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject1)
                    ),
                    (
                        "eventStreamCloudEventConnectionCreatedObject2",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject2)
                    ),
                    (
                        "eventStreamCloudEventConnectionCreatedObject3",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject3)
                    ),
                    (
                        "eventStreamCloudEventConnectionCreatedObject4",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject4)
                    ),
                    (
                        "eventStreamCloudEventConnectionCreatedObject5",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject5)
                    ),
                    (
                        "eventStreamCloudEventConnectionCreatedObject6",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject6)
                    ),
                    (
                        "eventStreamCloudEventConnectionCreatedObject7",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedObject7)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventConnectionCreatedObject result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventConnectionCreatedObject"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject value,
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

        public override EventStreamCloudEventConnectionCreatedObject ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventConnectionCreatedObject result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
