// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The organization member access level granted to the connection for an organization.
/// </summary>
[JsonConverter(
    typeof(EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel.JsonConverter)
)]
[Serializable]
public class EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel
{
    private EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel(
        string type,
        object? value
    )
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel FromEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum",
            value
        );

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel FromEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum",
            value
        );

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel FromEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum",
            value
        );

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel FromEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum",
            value
        );

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum() =>
        Type
        == "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum() =>
        Type
        == "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum() =>
        Type
        == "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum() =>
        Type
        == "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum AsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum() =>
        IsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum AsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum() =>
        IsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum AsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum() =>
        IsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum AsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum() =>
        IsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum? value
    )
    {
        if (
            Type
            == "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum"
        )
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum? value
    )
    {
        if (
            Type
            == "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum"
        )
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum? value
    )
    {
        if (
            Type
            == "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum"
        )
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum? value
    )
    {
        if (
            Type
            == "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum"
        )
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum,
            T
        > onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum,
            T
        > onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum,
            T
        > onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum,
            T
        > onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum
    )
    {
        return Type switch
        {
            "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum" =>
                onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum(
                    AsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum()
                ),
            "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum" =>
                onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum(
                    AsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum()
                ),
            "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum" =>
                onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum(
                    AsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum()
                ),
            "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum" =>
                onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum(
                    AsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum> onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum> onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum> onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum> onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum":
                onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum(
                    AsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum()
                );
                break;
            case "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum":
                onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum(
                    AsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum()
                );
                break;
            case "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum":
                onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum(
                    AsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum()
                );
                break;
            case "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum":
                onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum(
                    AsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum()
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
        if (
            obj
            is not EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel other
        )
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

    public static implicit operator EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum",
            value
        );

    public static implicit operator EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum",
            value
        );

    public static implicit operator EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum",
            value
        );

    public static implicit operator EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum",
            value
        );

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel>
    {
        public override EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel? Read(
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
                        "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel0Enum)
                    ),
                    (
                        "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel1Enum)
                    ),
                    (
                        "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel2Enum)
                    ),
                    (
                        "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel3Enum)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel result =
                                new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel value,
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
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel result =
                new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationMemberAccessLevel value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
