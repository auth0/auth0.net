// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The event content as it was prior to the change described by this event, when applicable.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventConnectionCreatedPreviousObject.JsonConverter))]
[Serializable]
public class EventStreamCloudEventConnectionCreatedPreviousObject
{
    private EventStreamCloudEventConnectionCreatedPreviousObject(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject0 value.
    /// </summary>
    public static EventStreamCloudEventConnectionCreatedPreviousObject FromEventStreamCloudEventConnectionCreatedPreviousObject0(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject0 value
    ) => new("eventStreamCloudEventConnectionCreatedPreviousObject0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject1 value.
    /// </summary>
    public static EventStreamCloudEventConnectionCreatedPreviousObject FromEventStreamCloudEventConnectionCreatedPreviousObject1(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject1 value
    ) => new("eventStreamCloudEventConnectionCreatedPreviousObject1", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject2 value.
    /// </summary>
    public static EventStreamCloudEventConnectionCreatedPreviousObject FromEventStreamCloudEventConnectionCreatedPreviousObject2(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject2 value
    ) => new("eventStreamCloudEventConnectionCreatedPreviousObject2", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject3 value.
    /// </summary>
    public static EventStreamCloudEventConnectionCreatedPreviousObject FromEventStreamCloudEventConnectionCreatedPreviousObject3(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject3 value
    ) => new("eventStreamCloudEventConnectionCreatedPreviousObject3", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject4 value.
    /// </summary>
    public static EventStreamCloudEventConnectionCreatedPreviousObject FromEventStreamCloudEventConnectionCreatedPreviousObject4(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject4 value
    ) => new("eventStreamCloudEventConnectionCreatedPreviousObject4", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject5 value.
    /// </summary>
    public static EventStreamCloudEventConnectionCreatedPreviousObject FromEventStreamCloudEventConnectionCreatedPreviousObject5(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject5 value
    ) => new("eventStreamCloudEventConnectionCreatedPreviousObject5", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject6 value.
    /// </summary>
    public static EventStreamCloudEventConnectionCreatedPreviousObject FromEventStreamCloudEventConnectionCreatedPreviousObject6(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject6 value
    ) => new("eventStreamCloudEventConnectionCreatedPreviousObject6", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject7 value.
    /// </summary>
    public static EventStreamCloudEventConnectionCreatedPreviousObject FromEventStreamCloudEventConnectionCreatedPreviousObject7(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject7 value
    ) => new("eventStreamCloudEventConnectionCreatedPreviousObject7", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionCreatedPreviousObject0"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionCreatedPreviousObject0() =>
        Type == "eventStreamCloudEventConnectionCreatedPreviousObject0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionCreatedPreviousObject1"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionCreatedPreviousObject1() =>
        Type == "eventStreamCloudEventConnectionCreatedPreviousObject1";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionCreatedPreviousObject2"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionCreatedPreviousObject2() =>
        Type == "eventStreamCloudEventConnectionCreatedPreviousObject2";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionCreatedPreviousObject3"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionCreatedPreviousObject3() =>
        Type == "eventStreamCloudEventConnectionCreatedPreviousObject3";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionCreatedPreviousObject4"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionCreatedPreviousObject4() =>
        Type == "eventStreamCloudEventConnectionCreatedPreviousObject4";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionCreatedPreviousObject5"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionCreatedPreviousObject5() =>
        Type == "eventStreamCloudEventConnectionCreatedPreviousObject5";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionCreatedPreviousObject6"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionCreatedPreviousObject6() =>
        Type == "eventStreamCloudEventConnectionCreatedPreviousObject6";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionCreatedPreviousObject7"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionCreatedPreviousObject7() =>
        Type == "eventStreamCloudEventConnectionCreatedPreviousObject7";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject0"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionCreatedPreviousObject0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionCreatedPreviousObject0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject0 AsEventStreamCloudEventConnectionCreatedPreviousObject0() =>
        IsEventStreamCloudEventConnectionCreatedPreviousObject0()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject0)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionCreatedPreviousObject0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject1"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionCreatedPreviousObject1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionCreatedPreviousObject1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject1 AsEventStreamCloudEventConnectionCreatedPreviousObject1() =>
        IsEventStreamCloudEventConnectionCreatedPreviousObject1()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject1)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionCreatedPreviousObject1'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject2"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionCreatedPreviousObject2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionCreatedPreviousObject2'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject2 AsEventStreamCloudEventConnectionCreatedPreviousObject2() =>
        IsEventStreamCloudEventConnectionCreatedPreviousObject2()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject2)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionCreatedPreviousObject2'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject3"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionCreatedPreviousObject3', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionCreatedPreviousObject3'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject3 AsEventStreamCloudEventConnectionCreatedPreviousObject3() =>
        IsEventStreamCloudEventConnectionCreatedPreviousObject3()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject3)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionCreatedPreviousObject3'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject4"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionCreatedPreviousObject4', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionCreatedPreviousObject4'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject4 AsEventStreamCloudEventConnectionCreatedPreviousObject4() =>
        IsEventStreamCloudEventConnectionCreatedPreviousObject4()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject4)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionCreatedPreviousObject4'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject5"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionCreatedPreviousObject5', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionCreatedPreviousObject5'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject5 AsEventStreamCloudEventConnectionCreatedPreviousObject5() =>
        IsEventStreamCloudEventConnectionCreatedPreviousObject5()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject5)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionCreatedPreviousObject5'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject6"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionCreatedPreviousObject6', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionCreatedPreviousObject6'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject6 AsEventStreamCloudEventConnectionCreatedPreviousObject6() =>
        IsEventStreamCloudEventConnectionCreatedPreviousObject6()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject6)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionCreatedPreviousObject6'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject7"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionCreatedPreviousObject7', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionCreatedPreviousObject7'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject7 AsEventStreamCloudEventConnectionCreatedPreviousObject7() =>
        IsEventStreamCloudEventConnectionCreatedPreviousObject7()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject7)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionCreatedPreviousObject7'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionCreatedPreviousObject0(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject0? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionCreatedPreviousObject0")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject0)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionCreatedPreviousObject1(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject1? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionCreatedPreviousObject1")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject1)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject2"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionCreatedPreviousObject2(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject2? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionCreatedPreviousObject2")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject2)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject3"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionCreatedPreviousObject3(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject3? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionCreatedPreviousObject3")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject3)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject4"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionCreatedPreviousObject4(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject4? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionCreatedPreviousObject4")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject4)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject5"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionCreatedPreviousObject5(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject5? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionCreatedPreviousObject5")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject5)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject6"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionCreatedPreviousObject6(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject6? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionCreatedPreviousObject6")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject6)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject7"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionCreatedPreviousObject7(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject7? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionCreatedPreviousObject7")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject7)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject0,
            T
        > onEventStreamCloudEventConnectionCreatedPreviousObject0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject1,
            T
        > onEventStreamCloudEventConnectionCreatedPreviousObject1,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject2,
            T
        > onEventStreamCloudEventConnectionCreatedPreviousObject2,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject3,
            T
        > onEventStreamCloudEventConnectionCreatedPreviousObject3,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject4,
            T
        > onEventStreamCloudEventConnectionCreatedPreviousObject4,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject5,
            T
        > onEventStreamCloudEventConnectionCreatedPreviousObject5,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject6,
            T
        > onEventStreamCloudEventConnectionCreatedPreviousObject6,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject7,
            T
        > onEventStreamCloudEventConnectionCreatedPreviousObject7
    )
    {
        return Type switch
        {
            "eventStreamCloudEventConnectionCreatedPreviousObject0" =>
                onEventStreamCloudEventConnectionCreatedPreviousObject0(
                    AsEventStreamCloudEventConnectionCreatedPreviousObject0()
                ),
            "eventStreamCloudEventConnectionCreatedPreviousObject1" =>
                onEventStreamCloudEventConnectionCreatedPreviousObject1(
                    AsEventStreamCloudEventConnectionCreatedPreviousObject1()
                ),
            "eventStreamCloudEventConnectionCreatedPreviousObject2" =>
                onEventStreamCloudEventConnectionCreatedPreviousObject2(
                    AsEventStreamCloudEventConnectionCreatedPreviousObject2()
                ),
            "eventStreamCloudEventConnectionCreatedPreviousObject3" =>
                onEventStreamCloudEventConnectionCreatedPreviousObject3(
                    AsEventStreamCloudEventConnectionCreatedPreviousObject3()
                ),
            "eventStreamCloudEventConnectionCreatedPreviousObject4" =>
                onEventStreamCloudEventConnectionCreatedPreviousObject4(
                    AsEventStreamCloudEventConnectionCreatedPreviousObject4()
                ),
            "eventStreamCloudEventConnectionCreatedPreviousObject5" =>
                onEventStreamCloudEventConnectionCreatedPreviousObject5(
                    AsEventStreamCloudEventConnectionCreatedPreviousObject5()
                ),
            "eventStreamCloudEventConnectionCreatedPreviousObject6" =>
                onEventStreamCloudEventConnectionCreatedPreviousObject6(
                    AsEventStreamCloudEventConnectionCreatedPreviousObject6()
                ),
            "eventStreamCloudEventConnectionCreatedPreviousObject7" =>
                onEventStreamCloudEventConnectionCreatedPreviousObject7(
                    AsEventStreamCloudEventConnectionCreatedPreviousObject7()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject0> onEventStreamCloudEventConnectionCreatedPreviousObject0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject1> onEventStreamCloudEventConnectionCreatedPreviousObject1,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject2> onEventStreamCloudEventConnectionCreatedPreviousObject2,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject3> onEventStreamCloudEventConnectionCreatedPreviousObject3,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject4> onEventStreamCloudEventConnectionCreatedPreviousObject4,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject5> onEventStreamCloudEventConnectionCreatedPreviousObject5,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject6> onEventStreamCloudEventConnectionCreatedPreviousObject6,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject7> onEventStreamCloudEventConnectionCreatedPreviousObject7
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventConnectionCreatedPreviousObject0":
                onEventStreamCloudEventConnectionCreatedPreviousObject0(
                    AsEventStreamCloudEventConnectionCreatedPreviousObject0()
                );
                break;
            case "eventStreamCloudEventConnectionCreatedPreviousObject1":
                onEventStreamCloudEventConnectionCreatedPreviousObject1(
                    AsEventStreamCloudEventConnectionCreatedPreviousObject1()
                );
                break;
            case "eventStreamCloudEventConnectionCreatedPreviousObject2":
                onEventStreamCloudEventConnectionCreatedPreviousObject2(
                    AsEventStreamCloudEventConnectionCreatedPreviousObject2()
                );
                break;
            case "eventStreamCloudEventConnectionCreatedPreviousObject3":
                onEventStreamCloudEventConnectionCreatedPreviousObject3(
                    AsEventStreamCloudEventConnectionCreatedPreviousObject3()
                );
                break;
            case "eventStreamCloudEventConnectionCreatedPreviousObject4":
                onEventStreamCloudEventConnectionCreatedPreviousObject4(
                    AsEventStreamCloudEventConnectionCreatedPreviousObject4()
                );
                break;
            case "eventStreamCloudEventConnectionCreatedPreviousObject5":
                onEventStreamCloudEventConnectionCreatedPreviousObject5(
                    AsEventStreamCloudEventConnectionCreatedPreviousObject5()
                );
                break;
            case "eventStreamCloudEventConnectionCreatedPreviousObject6":
                onEventStreamCloudEventConnectionCreatedPreviousObject6(
                    AsEventStreamCloudEventConnectionCreatedPreviousObject6()
                );
                break;
            case "eventStreamCloudEventConnectionCreatedPreviousObject7":
                onEventStreamCloudEventConnectionCreatedPreviousObject7(
                    AsEventStreamCloudEventConnectionCreatedPreviousObject7()
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
        if (obj is not EventStreamCloudEventConnectionCreatedPreviousObject other)
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

    public static implicit operator EventStreamCloudEventConnectionCreatedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject0 value
    ) => new("eventStreamCloudEventConnectionCreatedPreviousObject0", value);

    public static implicit operator EventStreamCloudEventConnectionCreatedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject1 value
    ) => new("eventStreamCloudEventConnectionCreatedPreviousObject1", value);

    public static implicit operator EventStreamCloudEventConnectionCreatedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject2 value
    ) => new("eventStreamCloudEventConnectionCreatedPreviousObject2", value);

    public static implicit operator EventStreamCloudEventConnectionCreatedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject3 value
    ) => new("eventStreamCloudEventConnectionCreatedPreviousObject3", value);

    public static implicit operator EventStreamCloudEventConnectionCreatedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject4 value
    ) => new("eventStreamCloudEventConnectionCreatedPreviousObject4", value);

    public static implicit operator EventStreamCloudEventConnectionCreatedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject5 value
    ) => new("eventStreamCloudEventConnectionCreatedPreviousObject5", value);

    public static implicit operator EventStreamCloudEventConnectionCreatedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject6 value
    ) => new("eventStreamCloudEventConnectionCreatedPreviousObject6", value);

    public static implicit operator EventStreamCloudEventConnectionCreatedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject7 value
    ) => new("eventStreamCloudEventConnectionCreatedPreviousObject7", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventConnectionCreatedPreviousObject>
    {
        public override EventStreamCloudEventConnectionCreatedPreviousObject? Read(
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
                        "eventStreamCloudEventConnectionCreatedPreviousObject0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject0)
                    ),
                    (
                        "eventStreamCloudEventConnectionCreatedPreviousObject1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject1)
                    ),
                    (
                        "eventStreamCloudEventConnectionCreatedPreviousObject2",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject2)
                    ),
                    (
                        "eventStreamCloudEventConnectionCreatedPreviousObject3",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject3)
                    ),
                    (
                        "eventStreamCloudEventConnectionCreatedPreviousObject4",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject4)
                    ),
                    (
                        "eventStreamCloudEventConnectionCreatedPreviousObject5",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject5)
                    ),
                    (
                        "eventStreamCloudEventConnectionCreatedPreviousObject6",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject6)
                    ),
                    (
                        "eventStreamCloudEventConnectionCreatedPreviousObject7",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionCreatedPreviousObject7)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventConnectionCreatedPreviousObject result = new(
                                key,
                                value
                            );
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventConnectionCreatedPreviousObject"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedPreviousObject value,
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

        public override EventStreamCloudEventConnectionCreatedPreviousObject ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventConnectionCreatedPreviousObject result = new(
                "string",
                stringValue
            );
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedPreviousObject value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
