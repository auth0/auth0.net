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
    typeof(EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel.JsonConverter)
)]
[Serializable]
public class EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel
{
    private EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel(
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel FromEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum",
            value
        );

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel FromEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum",
            value
        );

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel FromEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum",
            value
        );

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel FromEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum",
            value
        );

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum() =>
        Type == "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum() =>
        Type == "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum() =>
        Type == "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum() =>
        Type == "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum AsEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum() =>
        IsEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum AsEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum() =>
        IsEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum AsEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum() =>
        IsEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum AsEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum() =>
        IsEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum? value
    )
    {
        if (
            Type
            == "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum"
        )
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum? value
    )
    {
        if (
            Type
            == "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum"
        )
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum? value
    )
    {
        if (
            Type
            == "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum"
        )
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum? value
    )
    {
        if (
            Type
            == "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum"
        )
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum,
            T
        > onEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum,
            T
        > onEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum,
            T
        > onEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum,
            T
        > onEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum
    )
    {
        return Type switch
        {
            "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum" =>
                onEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum(
                    AsEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum()
                ),
            "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum" =>
                onEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum(
                    AsEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum()
                ),
            "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum" =>
                onEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum(
                    AsEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum()
                ),
            "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum" =>
                onEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum(
                    AsEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum> onEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum> onEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum> onEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum> onEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum":
                onEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum(
                    AsEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum()
                );
                break;
            case "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum":
                onEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum(
                    AsEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum()
                );
                break;
            case "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum":
                onEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum(
                    AsEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum()
                );
                break;
            case "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum":
                onEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum(
                    AsEventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum()
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
            is not EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel other
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

    public static implicit operator EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum",
            value
        );

    public static implicit operator EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum",
            value
        );

    public static implicit operator EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum",
            value
        );

    public static implicit operator EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum",
            value
        );

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel>
    {
        public override EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel? Read(
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
                        "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel0Enum)
                    ),
                    (
                        "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel1Enum)
                    ),
                    (
                        "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel2Enum)
                    ),
                    (
                        "eventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel3Enum)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel result =
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel value,
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

        public override EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel result = new(
                "string",
                stringValue
            );
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionAddedObjectOrganizationMemberAccessLevel value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
