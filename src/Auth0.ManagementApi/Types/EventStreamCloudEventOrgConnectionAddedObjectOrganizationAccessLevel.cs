// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The access level granted to the connection for an organization.
/// </summary>
[JsonConverter(
    typeof(EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel.JsonConverter)
)]
[Serializable]
public class EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel
{
    private EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel(
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel FromEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum value
    ) => new("eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel FromEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum value
    ) => new("eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel FromEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum value
    ) => new("eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel FromEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum value
    ) => new("eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum() =>
        Type == "eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum() =>
        Type == "eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum() =>
        Type == "eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum() =>
        Type == "eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum AsEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum() =>
        IsEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum AsEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum() =>
        IsEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum AsEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum() =>
        IsEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum AsEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum() =>
        IsEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum? value
    )
    {
        if (Type == "eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum? value
    )
    {
        if (Type == "eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum? value
    )
    {
        if (Type == "eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum? value
    )
    {
        if (Type == "eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum,
            T
        > onEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum,
            T
        > onEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum,
            T
        > onEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum,
            T
        > onEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum
    )
    {
        return Type switch
        {
            "eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum" =>
                onEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum(
                    AsEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum()
                ),
            "eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum" =>
                onEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum(
                    AsEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum()
                ),
            "eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum" =>
                onEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum(
                    AsEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum()
                ),
            "eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum" =>
                onEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum(
                    AsEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum> onEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum> onEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum> onEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum> onEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum":
                onEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum(
                    AsEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum()
                );
                break;
            case "eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum":
                onEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum(
                    AsEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum()
                );
                break;
            case "eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum":
                onEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum(
                    AsEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum()
                );
                break;
            case "eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum":
                onEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum(
                    AsEventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum()
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
        if (obj is not EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel other)
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

    public static implicit operator EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum value
    ) => new("eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum", value);

    public static implicit operator EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum value
    ) => new("eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum", value);

    public static implicit operator EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum value
    ) => new("eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum", value);

    public static implicit operator EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum value
    ) => new("eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel>
    {
        public override EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel? Read(
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
                        "eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel0Enum)
                    ),
                    (
                        "eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel1Enum)
                    ),
                    (
                        "eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel2Enum)
                    ),
                    (
                        "eventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel3Enum)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel result =
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel value,
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

        public override EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel result = new(
                "string",
                stringValue
            );
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionAddedObjectOrganizationAccessLevel value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
