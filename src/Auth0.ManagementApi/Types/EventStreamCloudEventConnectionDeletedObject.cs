// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The event content.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventConnectionDeletedObject.JsonConverter))]
[Serializable]
public class EventStreamCloudEventConnectionDeletedObject
{
    private EventStreamCloudEventConnectionDeletedObject(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject0 value.
    /// </summary>
    public static EventStreamCloudEventConnectionDeletedObject FromEventStreamCloudEventConnectionDeletedObject0(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject0 value
    ) => new("eventStreamCloudEventConnectionDeletedObject0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject1 value.
    /// </summary>
    public static EventStreamCloudEventConnectionDeletedObject FromEventStreamCloudEventConnectionDeletedObject1(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject1 value
    ) => new("eventStreamCloudEventConnectionDeletedObject1", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject2 value.
    /// </summary>
    public static EventStreamCloudEventConnectionDeletedObject FromEventStreamCloudEventConnectionDeletedObject2(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject2 value
    ) => new("eventStreamCloudEventConnectionDeletedObject2", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject3 value.
    /// </summary>
    public static EventStreamCloudEventConnectionDeletedObject FromEventStreamCloudEventConnectionDeletedObject3(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject3 value
    ) => new("eventStreamCloudEventConnectionDeletedObject3", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject4 value.
    /// </summary>
    public static EventStreamCloudEventConnectionDeletedObject FromEventStreamCloudEventConnectionDeletedObject4(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject4 value
    ) => new("eventStreamCloudEventConnectionDeletedObject4", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject5 value.
    /// </summary>
    public static EventStreamCloudEventConnectionDeletedObject FromEventStreamCloudEventConnectionDeletedObject5(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject5 value
    ) => new("eventStreamCloudEventConnectionDeletedObject5", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject6 value.
    /// </summary>
    public static EventStreamCloudEventConnectionDeletedObject FromEventStreamCloudEventConnectionDeletedObject6(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject6 value
    ) => new("eventStreamCloudEventConnectionDeletedObject6", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject7 value.
    /// </summary>
    public static EventStreamCloudEventConnectionDeletedObject FromEventStreamCloudEventConnectionDeletedObject7(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject7 value
    ) => new("eventStreamCloudEventConnectionDeletedObject7", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionDeletedObject0"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionDeletedObject0() =>
        Type == "eventStreamCloudEventConnectionDeletedObject0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionDeletedObject1"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionDeletedObject1() =>
        Type == "eventStreamCloudEventConnectionDeletedObject1";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionDeletedObject2"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionDeletedObject2() =>
        Type == "eventStreamCloudEventConnectionDeletedObject2";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionDeletedObject3"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionDeletedObject3() =>
        Type == "eventStreamCloudEventConnectionDeletedObject3";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionDeletedObject4"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionDeletedObject4() =>
        Type == "eventStreamCloudEventConnectionDeletedObject4";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionDeletedObject5"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionDeletedObject5() =>
        Type == "eventStreamCloudEventConnectionDeletedObject5";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionDeletedObject6"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionDeletedObject6() =>
        Type == "eventStreamCloudEventConnectionDeletedObject6";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionDeletedObject7"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionDeletedObject7() =>
        Type == "eventStreamCloudEventConnectionDeletedObject7";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject0"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionDeletedObject0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionDeletedObject0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject0 AsEventStreamCloudEventConnectionDeletedObject0() =>
        IsEventStreamCloudEventConnectionDeletedObject0()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject0)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionDeletedObject0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject1"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionDeletedObject1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionDeletedObject1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject1 AsEventStreamCloudEventConnectionDeletedObject1() =>
        IsEventStreamCloudEventConnectionDeletedObject1()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject1)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionDeletedObject1'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject2"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionDeletedObject2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionDeletedObject2'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject2 AsEventStreamCloudEventConnectionDeletedObject2() =>
        IsEventStreamCloudEventConnectionDeletedObject2()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject2)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionDeletedObject2'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject3"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionDeletedObject3', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionDeletedObject3'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject3 AsEventStreamCloudEventConnectionDeletedObject3() =>
        IsEventStreamCloudEventConnectionDeletedObject3()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject3)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionDeletedObject3'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject4"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionDeletedObject4', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionDeletedObject4'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject4 AsEventStreamCloudEventConnectionDeletedObject4() =>
        IsEventStreamCloudEventConnectionDeletedObject4()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject4)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionDeletedObject4'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject5"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionDeletedObject5', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionDeletedObject5'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject5 AsEventStreamCloudEventConnectionDeletedObject5() =>
        IsEventStreamCloudEventConnectionDeletedObject5()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject5)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionDeletedObject5'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject6"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionDeletedObject6', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionDeletedObject6'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject6 AsEventStreamCloudEventConnectionDeletedObject6() =>
        IsEventStreamCloudEventConnectionDeletedObject6()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject6)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionDeletedObject6'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject7"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionDeletedObject7', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionDeletedObject7'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject7 AsEventStreamCloudEventConnectionDeletedObject7() =>
        IsEventStreamCloudEventConnectionDeletedObject7()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject7)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionDeletedObject7'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionDeletedObject0(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject0? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionDeletedObject0")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject0)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionDeletedObject1(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject1? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionDeletedObject1")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject1)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject2"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionDeletedObject2(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject2? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionDeletedObject2")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject2)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject3"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionDeletedObject3(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject3? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionDeletedObject3")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject3)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject4"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionDeletedObject4(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject4? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionDeletedObject4")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject4)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject5"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionDeletedObject5(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject5? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionDeletedObject5")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject5)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject6"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionDeletedObject6(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject6? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionDeletedObject6")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject6)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject7"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionDeletedObject7(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject7? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionDeletedObject7")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject7)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject0,
            T
        > onEventStreamCloudEventConnectionDeletedObject0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject1,
            T
        > onEventStreamCloudEventConnectionDeletedObject1,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject2,
            T
        > onEventStreamCloudEventConnectionDeletedObject2,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject3,
            T
        > onEventStreamCloudEventConnectionDeletedObject3,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject4,
            T
        > onEventStreamCloudEventConnectionDeletedObject4,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject5,
            T
        > onEventStreamCloudEventConnectionDeletedObject5,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject6,
            T
        > onEventStreamCloudEventConnectionDeletedObject6,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject7,
            T
        > onEventStreamCloudEventConnectionDeletedObject7
    )
    {
        return Type switch
        {
            "eventStreamCloudEventConnectionDeletedObject0" =>
                onEventStreamCloudEventConnectionDeletedObject0(
                    AsEventStreamCloudEventConnectionDeletedObject0()
                ),
            "eventStreamCloudEventConnectionDeletedObject1" =>
                onEventStreamCloudEventConnectionDeletedObject1(
                    AsEventStreamCloudEventConnectionDeletedObject1()
                ),
            "eventStreamCloudEventConnectionDeletedObject2" =>
                onEventStreamCloudEventConnectionDeletedObject2(
                    AsEventStreamCloudEventConnectionDeletedObject2()
                ),
            "eventStreamCloudEventConnectionDeletedObject3" =>
                onEventStreamCloudEventConnectionDeletedObject3(
                    AsEventStreamCloudEventConnectionDeletedObject3()
                ),
            "eventStreamCloudEventConnectionDeletedObject4" =>
                onEventStreamCloudEventConnectionDeletedObject4(
                    AsEventStreamCloudEventConnectionDeletedObject4()
                ),
            "eventStreamCloudEventConnectionDeletedObject5" =>
                onEventStreamCloudEventConnectionDeletedObject5(
                    AsEventStreamCloudEventConnectionDeletedObject5()
                ),
            "eventStreamCloudEventConnectionDeletedObject6" =>
                onEventStreamCloudEventConnectionDeletedObject6(
                    AsEventStreamCloudEventConnectionDeletedObject6()
                ),
            "eventStreamCloudEventConnectionDeletedObject7" =>
                onEventStreamCloudEventConnectionDeletedObject7(
                    AsEventStreamCloudEventConnectionDeletedObject7()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject0> onEventStreamCloudEventConnectionDeletedObject0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject1> onEventStreamCloudEventConnectionDeletedObject1,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject2> onEventStreamCloudEventConnectionDeletedObject2,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject3> onEventStreamCloudEventConnectionDeletedObject3,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject4> onEventStreamCloudEventConnectionDeletedObject4,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject5> onEventStreamCloudEventConnectionDeletedObject5,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject6> onEventStreamCloudEventConnectionDeletedObject6,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject7> onEventStreamCloudEventConnectionDeletedObject7
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventConnectionDeletedObject0":
                onEventStreamCloudEventConnectionDeletedObject0(
                    AsEventStreamCloudEventConnectionDeletedObject0()
                );
                break;
            case "eventStreamCloudEventConnectionDeletedObject1":
                onEventStreamCloudEventConnectionDeletedObject1(
                    AsEventStreamCloudEventConnectionDeletedObject1()
                );
                break;
            case "eventStreamCloudEventConnectionDeletedObject2":
                onEventStreamCloudEventConnectionDeletedObject2(
                    AsEventStreamCloudEventConnectionDeletedObject2()
                );
                break;
            case "eventStreamCloudEventConnectionDeletedObject3":
                onEventStreamCloudEventConnectionDeletedObject3(
                    AsEventStreamCloudEventConnectionDeletedObject3()
                );
                break;
            case "eventStreamCloudEventConnectionDeletedObject4":
                onEventStreamCloudEventConnectionDeletedObject4(
                    AsEventStreamCloudEventConnectionDeletedObject4()
                );
                break;
            case "eventStreamCloudEventConnectionDeletedObject5":
                onEventStreamCloudEventConnectionDeletedObject5(
                    AsEventStreamCloudEventConnectionDeletedObject5()
                );
                break;
            case "eventStreamCloudEventConnectionDeletedObject6":
                onEventStreamCloudEventConnectionDeletedObject6(
                    AsEventStreamCloudEventConnectionDeletedObject6()
                );
                break;
            case "eventStreamCloudEventConnectionDeletedObject7":
                onEventStreamCloudEventConnectionDeletedObject7(
                    AsEventStreamCloudEventConnectionDeletedObject7()
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
        if (obj is not EventStreamCloudEventConnectionDeletedObject other)
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

    public static implicit operator EventStreamCloudEventConnectionDeletedObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject0 value
    ) => new("eventStreamCloudEventConnectionDeletedObject0", value);

    public static implicit operator EventStreamCloudEventConnectionDeletedObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject1 value
    ) => new("eventStreamCloudEventConnectionDeletedObject1", value);

    public static implicit operator EventStreamCloudEventConnectionDeletedObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject2 value
    ) => new("eventStreamCloudEventConnectionDeletedObject2", value);

    public static implicit operator EventStreamCloudEventConnectionDeletedObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject3 value
    ) => new("eventStreamCloudEventConnectionDeletedObject3", value);

    public static implicit operator EventStreamCloudEventConnectionDeletedObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject4 value
    ) => new("eventStreamCloudEventConnectionDeletedObject4", value);

    public static implicit operator EventStreamCloudEventConnectionDeletedObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject5 value
    ) => new("eventStreamCloudEventConnectionDeletedObject5", value);

    public static implicit operator EventStreamCloudEventConnectionDeletedObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject6 value
    ) => new("eventStreamCloudEventConnectionDeletedObject6", value);

    public static implicit operator EventStreamCloudEventConnectionDeletedObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject7 value
    ) => new("eventStreamCloudEventConnectionDeletedObject7", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventConnectionDeletedObject>
    {
        public override EventStreamCloudEventConnectionDeletedObject? Read(
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
                        "eventStreamCloudEventConnectionDeletedObject0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject0)
                    ),
                    (
                        "eventStreamCloudEventConnectionDeletedObject1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject1)
                    ),
                    (
                        "eventStreamCloudEventConnectionDeletedObject2",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject2)
                    ),
                    (
                        "eventStreamCloudEventConnectionDeletedObject3",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject3)
                    ),
                    (
                        "eventStreamCloudEventConnectionDeletedObject4",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject4)
                    ),
                    (
                        "eventStreamCloudEventConnectionDeletedObject5",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject5)
                    ),
                    (
                        "eventStreamCloudEventConnectionDeletedObject6",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject6)
                    ),
                    (
                        "eventStreamCloudEventConnectionDeletedObject7",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedObject7)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventConnectionDeletedObject result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventConnectionDeletedObject"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedObject value,
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

        public override EventStreamCloudEventConnectionDeletedObject ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventConnectionDeletedObject result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedObject value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
