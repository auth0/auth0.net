// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The event content as it was prior to the change described by this event, when applicable.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventConnectionDeletedPreviousObject.JsonConverter))]
[Serializable]
public class EventStreamCloudEventConnectionDeletedPreviousObject
{
    private EventStreamCloudEventConnectionDeletedPreviousObject(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject0 value.
    /// </summary>
    public static EventStreamCloudEventConnectionDeletedPreviousObject FromEventStreamCloudEventConnectionDeletedPreviousObject0(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject0 value
    ) => new("eventStreamCloudEventConnectionDeletedPreviousObject0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject1 value.
    /// </summary>
    public static EventStreamCloudEventConnectionDeletedPreviousObject FromEventStreamCloudEventConnectionDeletedPreviousObject1(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject1 value
    ) => new("eventStreamCloudEventConnectionDeletedPreviousObject1", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject2 value.
    /// </summary>
    public static EventStreamCloudEventConnectionDeletedPreviousObject FromEventStreamCloudEventConnectionDeletedPreviousObject2(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject2 value
    ) => new("eventStreamCloudEventConnectionDeletedPreviousObject2", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject3 value.
    /// </summary>
    public static EventStreamCloudEventConnectionDeletedPreviousObject FromEventStreamCloudEventConnectionDeletedPreviousObject3(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject3 value
    ) => new("eventStreamCloudEventConnectionDeletedPreviousObject3", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject4 value.
    /// </summary>
    public static EventStreamCloudEventConnectionDeletedPreviousObject FromEventStreamCloudEventConnectionDeletedPreviousObject4(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject4 value
    ) => new("eventStreamCloudEventConnectionDeletedPreviousObject4", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject5 value.
    /// </summary>
    public static EventStreamCloudEventConnectionDeletedPreviousObject FromEventStreamCloudEventConnectionDeletedPreviousObject5(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject5 value
    ) => new("eventStreamCloudEventConnectionDeletedPreviousObject5", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject6 value.
    /// </summary>
    public static EventStreamCloudEventConnectionDeletedPreviousObject FromEventStreamCloudEventConnectionDeletedPreviousObject6(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject6 value
    ) => new("eventStreamCloudEventConnectionDeletedPreviousObject6", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject7 value.
    /// </summary>
    public static EventStreamCloudEventConnectionDeletedPreviousObject FromEventStreamCloudEventConnectionDeletedPreviousObject7(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject7 value
    ) => new("eventStreamCloudEventConnectionDeletedPreviousObject7", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionDeletedPreviousObject0"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionDeletedPreviousObject0() =>
        Type == "eventStreamCloudEventConnectionDeletedPreviousObject0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionDeletedPreviousObject1"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionDeletedPreviousObject1() =>
        Type == "eventStreamCloudEventConnectionDeletedPreviousObject1";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionDeletedPreviousObject2"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionDeletedPreviousObject2() =>
        Type == "eventStreamCloudEventConnectionDeletedPreviousObject2";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionDeletedPreviousObject3"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionDeletedPreviousObject3() =>
        Type == "eventStreamCloudEventConnectionDeletedPreviousObject3";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionDeletedPreviousObject4"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionDeletedPreviousObject4() =>
        Type == "eventStreamCloudEventConnectionDeletedPreviousObject4";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionDeletedPreviousObject5"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionDeletedPreviousObject5() =>
        Type == "eventStreamCloudEventConnectionDeletedPreviousObject5";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionDeletedPreviousObject6"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionDeletedPreviousObject6() =>
        Type == "eventStreamCloudEventConnectionDeletedPreviousObject6";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventConnectionDeletedPreviousObject7"
    /// </summary>
    public bool IsEventStreamCloudEventConnectionDeletedPreviousObject7() =>
        Type == "eventStreamCloudEventConnectionDeletedPreviousObject7";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject0"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionDeletedPreviousObject0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionDeletedPreviousObject0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject0 AsEventStreamCloudEventConnectionDeletedPreviousObject0() =>
        IsEventStreamCloudEventConnectionDeletedPreviousObject0()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject0)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionDeletedPreviousObject0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject1"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionDeletedPreviousObject1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionDeletedPreviousObject1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject1 AsEventStreamCloudEventConnectionDeletedPreviousObject1() =>
        IsEventStreamCloudEventConnectionDeletedPreviousObject1()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject1)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionDeletedPreviousObject1'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject2"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionDeletedPreviousObject2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionDeletedPreviousObject2'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject2 AsEventStreamCloudEventConnectionDeletedPreviousObject2() =>
        IsEventStreamCloudEventConnectionDeletedPreviousObject2()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject2)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionDeletedPreviousObject2'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject3"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionDeletedPreviousObject3', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionDeletedPreviousObject3'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject3 AsEventStreamCloudEventConnectionDeletedPreviousObject3() =>
        IsEventStreamCloudEventConnectionDeletedPreviousObject3()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject3)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionDeletedPreviousObject3'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject4"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionDeletedPreviousObject4', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionDeletedPreviousObject4'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject4 AsEventStreamCloudEventConnectionDeletedPreviousObject4() =>
        IsEventStreamCloudEventConnectionDeletedPreviousObject4()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject4)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionDeletedPreviousObject4'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject5"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionDeletedPreviousObject5', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionDeletedPreviousObject5'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject5 AsEventStreamCloudEventConnectionDeletedPreviousObject5() =>
        IsEventStreamCloudEventConnectionDeletedPreviousObject5()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject5)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionDeletedPreviousObject5'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject6"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionDeletedPreviousObject6', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionDeletedPreviousObject6'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject6 AsEventStreamCloudEventConnectionDeletedPreviousObject6() =>
        IsEventStreamCloudEventConnectionDeletedPreviousObject6()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject6)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionDeletedPreviousObject6'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject7"/> if <see cref="Type"/> is 'eventStreamCloudEventConnectionDeletedPreviousObject7', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventConnectionDeletedPreviousObject7'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject7 AsEventStreamCloudEventConnectionDeletedPreviousObject7() =>
        IsEventStreamCloudEventConnectionDeletedPreviousObject7()
            ? (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject7)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventConnectionDeletedPreviousObject7'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionDeletedPreviousObject0(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject0? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionDeletedPreviousObject0")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject0)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionDeletedPreviousObject1(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject1? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionDeletedPreviousObject1")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject1)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject2"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionDeletedPreviousObject2(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject2? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionDeletedPreviousObject2")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject2)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject3"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionDeletedPreviousObject3(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject3? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionDeletedPreviousObject3")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject3)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject4"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionDeletedPreviousObject4(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject4? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionDeletedPreviousObject4")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject4)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject5"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionDeletedPreviousObject5(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject5? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionDeletedPreviousObject5")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject5)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject6"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionDeletedPreviousObject6(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject6? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionDeletedPreviousObject6")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject6)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject7"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventConnectionDeletedPreviousObject7(
        out Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject7? value
    )
    {
        if (Type == "eventStreamCloudEventConnectionDeletedPreviousObject7")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject7)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject0,
            T
        > onEventStreamCloudEventConnectionDeletedPreviousObject0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject1,
            T
        > onEventStreamCloudEventConnectionDeletedPreviousObject1,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject2,
            T
        > onEventStreamCloudEventConnectionDeletedPreviousObject2,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject3,
            T
        > onEventStreamCloudEventConnectionDeletedPreviousObject3,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject4,
            T
        > onEventStreamCloudEventConnectionDeletedPreviousObject4,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject5,
            T
        > onEventStreamCloudEventConnectionDeletedPreviousObject5,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject6,
            T
        > onEventStreamCloudEventConnectionDeletedPreviousObject6,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject7,
            T
        > onEventStreamCloudEventConnectionDeletedPreviousObject7
    )
    {
        return Type switch
        {
            "eventStreamCloudEventConnectionDeletedPreviousObject0" =>
                onEventStreamCloudEventConnectionDeletedPreviousObject0(
                    AsEventStreamCloudEventConnectionDeletedPreviousObject0()
                ),
            "eventStreamCloudEventConnectionDeletedPreviousObject1" =>
                onEventStreamCloudEventConnectionDeletedPreviousObject1(
                    AsEventStreamCloudEventConnectionDeletedPreviousObject1()
                ),
            "eventStreamCloudEventConnectionDeletedPreviousObject2" =>
                onEventStreamCloudEventConnectionDeletedPreviousObject2(
                    AsEventStreamCloudEventConnectionDeletedPreviousObject2()
                ),
            "eventStreamCloudEventConnectionDeletedPreviousObject3" =>
                onEventStreamCloudEventConnectionDeletedPreviousObject3(
                    AsEventStreamCloudEventConnectionDeletedPreviousObject3()
                ),
            "eventStreamCloudEventConnectionDeletedPreviousObject4" =>
                onEventStreamCloudEventConnectionDeletedPreviousObject4(
                    AsEventStreamCloudEventConnectionDeletedPreviousObject4()
                ),
            "eventStreamCloudEventConnectionDeletedPreviousObject5" =>
                onEventStreamCloudEventConnectionDeletedPreviousObject5(
                    AsEventStreamCloudEventConnectionDeletedPreviousObject5()
                ),
            "eventStreamCloudEventConnectionDeletedPreviousObject6" =>
                onEventStreamCloudEventConnectionDeletedPreviousObject6(
                    AsEventStreamCloudEventConnectionDeletedPreviousObject6()
                ),
            "eventStreamCloudEventConnectionDeletedPreviousObject7" =>
                onEventStreamCloudEventConnectionDeletedPreviousObject7(
                    AsEventStreamCloudEventConnectionDeletedPreviousObject7()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject0> onEventStreamCloudEventConnectionDeletedPreviousObject0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject1> onEventStreamCloudEventConnectionDeletedPreviousObject1,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject2> onEventStreamCloudEventConnectionDeletedPreviousObject2,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject3> onEventStreamCloudEventConnectionDeletedPreviousObject3,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject4> onEventStreamCloudEventConnectionDeletedPreviousObject4,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject5> onEventStreamCloudEventConnectionDeletedPreviousObject5,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject6> onEventStreamCloudEventConnectionDeletedPreviousObject6,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject7> onEventStreamCloudEventConnectionDeletedPreviousObject7
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventConnectionDeletedPreviousObject0":
                onEventStreamCloudEventConnectionDeletedPreviousObject0(
                    AsEventStreamCloudEventConnectionDeletedPreviousObject0()
                );
                break;
            case "eventStreamCloudEventConnectionDeletedPreviousObject1":
                onEventStreamCloudEventConnectionDeletedPreviousObject1(
                    AsEventStreamCloudEventConnectionDeletedPreviousObject1()
                );
                break;
            case "eventStreamCloudEventConnectionDeletedPreviousObject2":
                onEventStreamCloudEventConnectionDeletedPreviousObject2(
                    AsEventStreamCloudEventConnectionDeletedPreviousObject2()
                );
                break;
            case "eventStreamCloudEventConnectionDeletedPreviousObject3":
                onEventStreamCloudEventConnectionDeletedPreviousObject3(
                    AsEventStreamCloudEventConnectionDeletedPreviousObject3()
                );
                break;
            case "eventStreamCloudEventConnectionDeletedPreviousObject4":
                onEventStreamCloudEventConnectionDeletedPreviousObject4(
                    AsEventStreamCloudEventConnectionDeletedPreviousObject4()
                );
                break;
            case "eventStreamCloudEventConnectionDeletedPreviousObject5":
                onEventStreamCloudEventConnectionDeletedPreviousObject5(
                    AsEventStreamCloudEventConnectionDeletedPreviousObject5()
                );
                break;
            case "eventStreamCloudEventConnectionDeletedPreviousObject6":
                onEventStreamCloudEventConnectionDeletedPreviousObject6(
                    AsEventStreamCloudEventConnectionDeletedPreviousObject6()
                );
                break;
            case "eventStreamCloudEventConnectionDeletedPreviousObject7":
                onEventStreamCloudEventConnectionDeletedPreviousObject7(
                    AsEventStreamCloudEventConnectionDeletedPreviousObject7()
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
        if (obj is not EventStreamCloudEventConnectionDeletedPreviousObject other)
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

    public static implicit operator EventStreamCloudEventConnectionDeletedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject0 value
    ) => new("eventStreamCloudEventConnectionDeletedPreviousObject0", value);

    public static implicit operator EventStreamCloudEventConnectionDeletedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject1 value
    ) => new("eventStreamCloudEventConnectionDeletedPreviousObject1", value);

    public static implicit operator EventStreamCloudEventConnectionDeletedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject2 value
    ) => new("eventStreamCloudEventConnectionDeletedPreviousObject2", value);

    public static implicit operator EventStreamCloudEventConnectionDeletedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject3 value
    ) => new("eventStreamCloudEventConnectionDeletedPreviousObject3", value);

    public static implicit operator EventStreamCloudEventConnectionDeletedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject4 value
    ) => new("eventStreamCloudEventConnectionDeletedPreviousObject4", value);

    public static implicit operator EventStreamCloudEventConnectionDeletedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject5 value
    ) => new("eventStreamCloudEventConnectionDeletedPreviousObject5", value);

    public static implicit operator EventStreamCloudEventConnectionDeletedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject6 value
    ) => new("eventStreamCloudEventConnectionDeletedPreviousObject6", value);

    public static implicit operator EventStreamCloudEventConnectionDeletedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject7 value
    ) => new("eventStreamCloudEventConnectionDeletedPreviousObject7", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventConnectionDeletedPreviousObject>
    {
        public override EventStreamCloudEventConnectionDeletedPreviousObject? Read(
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
                        "eventStreamCloudEventConnectionDeletedPreviousObject0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject0)
                    ),
                    (
                        "eventStreamCloudEventConnectionDeletedPreviousObject1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject1)
                    ),
                    (
                        "eventStreamCloudEventConnectionDeletedPreviousObject2",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject2)
                    ),
                    (
                        "eventStreamCloudEventConnectionDeletedPreviousObject3",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject3)
                    ),
                    (
                        "eventStreamCloudEventConnectionDeletedPreviousObject4",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject4)
                    ),
                    (
                        "eventStreamCloudEventConnectionDeletedPreviousObject5",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject5)
                    ),
                    (
                        "eventStreamCloudEventConnectionDeletedPreviousObject6",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject6)
                    ),
                    (
                        "eventStreamCloudEventConnectionDeletedPreviousObject7",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventConnectionDeletedPreviousObject7)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventConnectionDeletedPreviousObject result = new(
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventConnectionDeletedPreviousObject"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedPreviousObject value,
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

        public override EventStreamCloudEventConnectionDeletedPreviousObject ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventConnectionDeletedPreviousObject result = new(
                "string",
                stringValue
            );
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedPreviousObject value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
