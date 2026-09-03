// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The event content as it was prior to the change described by this event, when applicable.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventConnectionUpdatedPreviousObject.JsonConverter))]
[Serializable]
public class EventStreamCloudEventConnectionUpdatedPreviousObject
{
    private EventStreamCloudEventConnectionUpdatedPreviousObject(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject0 value.
    /// </summary>
    public static EventStreamCloudEventConnectionUpdatedPreviousObject FromEventStreamCloudEventConnectionUpdatedPreviousObject0(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject0 value
    ) => new("eventStreamCloudEventConnectionUpdatedPreviousObject0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject1 value.
    /// </summary>
    public static EventStreamCloudEventConnectionUpdatedPreviousObject FromEventStreamCloudEventConnectionUpdatedPreviousObject1(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject1 value
    ) => new("eventStreamCloudEventConnectionUpdatedPreviousObject1", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject2 value.
    /// </summary>
    public static EventStreamCloudEventConnectionUpdatedPreviousObject FromEventStreamCloudEventConnectionUpdatedPreviousObject2(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject2 value
    ) => new("eventStreamCloudEventConnectionUpdatedPreviousObject2", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject3 value.
    /// </summary>
    public static EventStreamCloudEventConnectionUpdatedPreviousObject FromEventStreamCloudEventConnectionUpdatedPreviousObject3(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject3 value
    ) => new("eventStreamCloudEventConnectionUpdatedPreviousObject3", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject4 value.
    /// </summary>
    public static EventStreamCloudEventConnectionUpdatedPreviousObject FromEventStreamCloudEventConnectionUpdatedPreviousObject4(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject4 value
    ) => new("eventStreamCloudEventConnectionUpdatedPreviousObject4", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject5 value.
    /// </summary>
    public static EventStreamCloudEventConnectionUpdatedPreviousObject FromEventStreamCloudEventConnectionUpdatedPreviousObject5(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject5 value
    ) => new("eventStreamCloudEventConnectionUpdatedPreviousObject5", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject6 value.
    /// </summary>
    public static EventStreamCloudEventConnectionUpdatedPreviousObject FromEventStreamCloudEventConnectionUpdatedPreviousObject6(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject6 value
    ) => new("eventStreamCloudEventConnectionUpdatedPreviousObject6", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject7 value.
    /// </summary>
    public static EventStreamCloudEventConnectionUpdatedPreviousObject FromEventStreamCloudEventConnectionUpdatedPreviousObject7(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject7 value
    ) => new("eventStreamCloudEventConnectionUpdatedPreviousObject7", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionUpdatedPreviousObject0"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionUpdatedPreviousObject0() =>
        Type == "eventStreamCloudEventConnectionUpdatedPreviousObject0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionUpdatedPreviousObject1"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionUpdatedPreviousObject1() =>
        Type == "eventStreamCloudEventConnectionUpdatedPreviousObject1";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionUpdatedPreviousObject2"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionUpdatedPreviousObject2() =>
        Type == "eventStreamCloudEventConnectionUpdatedPreviousObject2";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionUpdatedPreviousObject3"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionUpdatedPreviousObject3() =>
        Type == "eventStreamCloudEventConnectionUpdatedPreviousObject3";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionUpdatedPreviousObject4"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionUpdatedPreviousObject4() =>
        Type == "eventStreamCloudEventConnectionUpdatedPreviousObject4";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionUpdatedPreviousObject5"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionUpdatedPreviousObject5() =>
        Type == "eventStreamCloudEventConnectionUpdatedPreviousObject5";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionUpdatedPreviousObject6"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionUpdatedPreviousObject6() =>
        Type == "eventStreamCloudEventConnectionUpdatedPreviousObject6";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionUpdatedPreviousObject7"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionUpdatedPreviousObject7() =>
        Type == "eventStreamCloudEventConnectionUpdatedPreviousObject7";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject0"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionUpdatedPreviousObject0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionUpdatedPreviousObject0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject0 AsEventStreamCloudEventConnectionUpdatedPreviousObject0() =>
        IsEventStreamCloudEventConnectionUpdatedPreviousObject0()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject0)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionUpdatedPreviousObject0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject1"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionUpdatedPreviousObject1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionUpdatedPreviousObject1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject1 AsEventStreamCloudEventConnectionUpdatedPreviousObject1() =>
        IsEventStreamCloudEventConnectionUpdatedPreviousObject1()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject1)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionUpdatedPreviousObject1'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject2"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionUpdatedPreviousObject2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionUpdatedPreviousObject2'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject2 AsEventStreamCloudEventConnectionUpdatedPreviousObject2() =>
        IsEventStreamCloudEventConnectionUpdatedPreviousObject2()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject2)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionUpdatedPreviousObject2'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject3"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionUpdatedPreviousObject3', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionUpdatedPreviousObject3'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject3 AsEventStreamCloudEventConnectionUpdatedPreviousObject3() =>
        IsEventStreamCloudEventConnectionUpdatedPreviousObject3()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject3)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionUpdatedPreviousObject3'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject4"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionUpdatedPreviousObject4', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionUpdatedPreviousObject4'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject4 AsEventStreamCloudEventConnectionUpdatedPreviousObject4() =>
        IsEventStreamCloudEventConnectionUpdatedPreviousObject4()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject4)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionUpdatedPreviousObject4'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject5"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionUpdatedPreviousObject5', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionUpdatedPreviousObject5'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject5 AsEventStreamCloudEventConnectionUpdatedPreviousObject5() =>
        IsEventStreamCloudEventConnectionUpdatedPreviousObject5()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject5)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionUpdatedPreviousObject5'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject6"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionUpdatedPreviousObject6', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionUpdatedPreviousObject6'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject6 AsEventStreamCloudEventConnectionUpdatedPreviousObject6() =>
        IsEventStreamCloudEventConnectionUpdatedPreviousObject6()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject6)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionUpdatedPreviousObject6'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject7"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionUpdatedPreviousObject7', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionUpdatedPreviousObject7'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject7 AsEventStreamCloudEventConnectionUpdatedPreviousObject7() =>
        IsEventStreamCloudEventConnectionUpdatedPreviousObject7()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject7)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionUpdatedPreviousObject7'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionUpdatedPreviousObject0(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject0? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionUpdatedPreviousObject0")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject0)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionUpdatedPreviousObject1(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject1? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionUpdatedPreviousObject1")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject1)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject2"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionUpdatedPreviousObject2(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject2? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionUpdatedPreviousObject2")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject2)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject3"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionUpdatedPreviousObject3(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject3? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionUpdatedPreviousObject3")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject3)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject4"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionUpdatedPreviousObject4(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject4? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionUpdatedPreviousObject4")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject4)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject5"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionUpdatedPreviousObject5(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject5? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionUpdatedPreviousObject5")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject5)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject6"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionUpdatedPreviousObject6(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject6? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionUpdatedPreviousObject6")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject6)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject7"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionUpdatedPreviousObject7(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject7? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionUpdatedPreviousObject7")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject7)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject0,
            T
        > onEventStreamCloudEventConnectionUpdatedPreviousObject0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject1,
            T
        > onEventStreamCloudEventConnectionUpdatedPreviousObject1,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject2,
            T
        > onEventStreamCloudEventConnectionUpdatedPreviousObject2,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject3,
            T
        > onEventStreamCloudEventConnectionUpdatedPreviousObject3,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject4,
            T
        > onEventStreamCloudEventConnectionUpdatedPreviousObject4,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject5,
            T
        > onEventStreamCloudEventConnectionUpdatedPreviousObject5,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject6,
            T
        > onEventStreamCloudEventConnectionUpdatedPreviousObject6,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject7,
            T
        > onEventStreamCloudEventConnectionUpdatedPreviousObject7
    )
    {
        return Type switch
        {
            "eventStreamCloudEventConnectionUpdatedPreviousObject0" =>
                onEventStreamCloudEventConnectionUpdatedPreviousObject0(
                    AsEventStreamCloudEventConnectionUpdatedPreviousObject0()
                ),
            "eventStreamCloudEventConnectionUpdatedPreviousObject1" =>
                onEventStreamCloudEventConnectionUpdatedPreviousObject1(
                    AsEventStreamCloudEventConnectionUpdatedPreviousObject1()
                ),
            "eventStreamCloudEventConnectionUpdatedPreviousObject2" =>
                onEventStreamCloudEventConnectionUpdatedPreviousObject2(
                    AsEventStreamCloudEventConnectionUpdatedPreviousObject2()
                ),
            "eventStreamCloudEventConnectionUpdatedPreviousObject3" =>
                onEventStreamCloudEventConnectionUpdatedPreviousObject3(
                    AsEventStreamCloudEventConnectionUpdatedPreviousObject3()
                ),
            "eventStreamCloudEventConnectionUpdatedPreviousObject4" =>
                onEventStreamCloudEventConnectionUpdatedPreviousObject4(
                    AsEventStreamCloudEventConnectionUpdatedPreviousObject4()
                ),
            "eventStreamCloudEventConnectionUpdatedPreviousObject5" =>
                onEventStreamCloudEventConnectionUpdatedPreviousObject5(
                    AsEventStreamCloudEventConnectionUpdatedPreviousObject5()
                ),
            "eventStreamCloudEventConnectionUpdatedPreviousObject6" =>
                onEventStreamCloudEventConnectionUpdatedPreviousObject6(
                    AsEventStreamCloudEventConnectionUpdatedPreviousObject6()
                ),
            "eventStreamCloudEventConnectionUpdatedPreviousObject7" =>
                onEventStreamCloudEventConnectionUpdatedPreviousObject7(
                    AsEventStreamCloudEventConnectionUpdatedPreviousObject7()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject0> onEventStreamCloudEventConnectionUpdatedPreviousObject0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject1> onEventStreamCloudEventConnectionUpdatedPreviousObject1,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject2> onEventStreamCloudEventConnectionUpdatedPreviousObject2,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject3> onEventStreamCloudEventConnectionUpdatedPreviousObject3,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject4> onEventStreamCloudEventConnectionUpdatedPreviousObject4,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject5> onEventStreamCloudEventConnectionUpdatedPreviousObject5,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject6> onEventStreamCloudEventConnectionUpdatedPreviousObject6,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject7> onEventStreamCloudEventConnectionUpdatedPreviousObject7
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventConnectionUpdatedPreviousObject0":
                onEventStreamCloudEventConnectionUpdatedPreviousObject0(
                    AsEventStreamCloudEventConnectionUpdatedPreviousObject0()
                );
                break;
            case "eventStreamCloudEventConnectionUpdatedPreviousObject1":
                onEventStreamCloudEventConnectionUpdatedPreviousObject1(
                    AsEventStreamCloudEventConnectionUpdatedPreviousObject1()
                );
                break;
            case "eventStreamCloudEventConnectionUpdatedPreviousObject2":
                onEventStreamCloudEventConnectionUpdatedPreviousObject2(
                    AsEventStreamCloudEventConnectionUpdatedPreviousObject2()
                );
                break;
            case "eventStreamCloudEventConnectionUpdatedPreviousObject3":
                onEventStreamCloudEventConnectionUpdatedPreviousObject3(
                    AsEventStreamCloudEventConnectionUpdatedPreviousObject3()
                );
                break;
            case "eventStreamCloudEventConnectionUpdatedPreviousObject4":
                onEventStreamCloudEventConnectionUpdatedPreviousObject4(
                    AsEventStreamCloudEventConnectionUpdatedPreviousObject4()
                );
                break;
            case "eventStreamCloudEventConnectionUpdatedPreviousObject5":
                onEventStreamCloudEventConnectionUpdatedPreviousObject5(
                    AsEventStreamCloudEventConnectionUpdatedPreviousObject5()
                );
                break;
            case "eventStreamCloudEventConnectionUpdatedPreviousObject6":
                onEventStreamCloudEventConnectionUpdatedPreviousObject6(
                    AsEventStreamCloudEventConnectionUpdatedPreviousObject6()
                );
                break;
            case "eventStreamCloudEventConnectionUpdatedPreviousObject7":
                onEventStreamCloudEventConnectionUpdatedPreviousObject7(
                    AsEventStreamCloudEventConnectionUpdatedPreviousObject7()
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
        if (obj is not EventStreamCloudEventConnectionUpdatedPreviousObject other)
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

    public static implicit operator EventStreamCloudEventConnectionUpdatedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject0 value
    ) => new("eventStreamCloudEventConnectionUpdatedPreviousObject0", value);

    public static implicit operator EventStreamCloudEventConnectionUpdatedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject1 value
    ) => new("eventStreamCloudEventConnectionUpdatedPreviousObject1", value);

    public static implicit operator EventStreamCloudEventConnectionUpdatedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject2 value
    ) => new("eventStreamCloudEventConnectionUpdatedPreviousObject2", value);

    public static implicit operator EventStreamCloudEventConnectionUpdatedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject3 value
    ) => new("eventStreamCloudEventConnectionUpdatedPreviousObject3", value);

    public static implicit operator EventStreamCloudEventConnectionUpdatedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject4 value
    ) => new("eventStreamCloudEventConnectionUpdatedPreviousObject4", value);

    public static implicit operator EventStreamCloudEventConnectionUpdatedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject5 value
    ) => new("eventStreamCloudEventConnectionUpdatedPreviousObject5", value);

    public static implicit operator EventStreamCloudEventConnectionUpdatedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject6 value
    ) => new("eventStreamCloudEventConnectionUpdatedPreviousObject6", value);

    public static implicit operator EventStreamCloudEventConnectionUpdatedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject7 value
    ) => new("eventStreamCloudEventConnectionUpdatedPreviousObject7", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventConnectionUpdatedPreviousObject>
    {
        public override EventStreamCloudEventConnectionUpdatedPreviousObject? Read(
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
                        "eventStreamCloudEventConnectionUpdatedPreviousObject0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject0)
                    ),
                    (
                        "eventStreamCloudEventConnectionUpdatedPreviousObject1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject1)
                    ),
                    (
                        "eventStreamCloudEventConnectionUpdatedPreviousObject2",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject2)
                    ),
                    (
                        "eventStreamCloudEventConnectionUpdatedPreviousObject3",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject3)
                    ),
                    (
                        "eventStreamCloudEventConnectionUpdatedPreviousObject4",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject4)
                    ),
                    (
                        "eventStreamCloudEventConnectionUpdatedPreviousObject5",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject5)
                    ),
                    (
                        "eventStreamCloudEventConnectionUpdatedPreviousObject6",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject6)
                    ),
                    (
                        "eventStreamCloudEventConnectionUpdatedPreviousObject7",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionUpdatedPreviousObject7)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventConnectionUpdatedPreviousObject result = new(
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventConnectionUpdatedPreviousObject"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedPreviousObject value,
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

        public override EventStreamCloudEventConnectionUpdatedPreviousObject ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventConnectionUpdatedPreviousObject result = new(
                "string",
                stringValue
            );
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedPreviousObject value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
