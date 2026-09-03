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
    typeof(EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel.JsonConverter)
)]
[Serializable]
public class EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel
{
    private EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel(
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel FromEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum value
    ) => new("eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel FromEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum value
    ) => new("eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel FromEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum value
    ) => new("eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel FromEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum value
    ) => new("eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum() =>
        Type == "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum() =>
        Type == "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum() =>
        Type == "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum() =>
        Type == "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum AsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum() =>
        IsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum AsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum() =>
        IsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum AsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum() =>
        IsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum AsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum() =>
        IsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum? value
    )
    {
        if (Type == "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum? value
    )
    {
        if (Type == "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum? value
    )
    {
        if (Type == "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum? value
    )
    {
        if (Type == "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum,
            T
        > onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum,
            T
        > onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum,
            T
        > onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum,
            T
        > onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum
    )
    {
        return Type switch
        {
            "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum" =>
                onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum()
                ),
            "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum" =>
                onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum()
                ),
            "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum" =>
                onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum()
                ),
            "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum" =>
                onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum> onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum> onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum> onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum> onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum":
                onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum()
                );
                break;
            case "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum":
                onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum()
                );
                break;
            case "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum":
                onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum()
                );
                break;
            case "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum":
                onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum()
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
        if (obj is not EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel other)
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

    public static implicit operator EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum value
    ) => new("eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum", value);

    public static implicit operator EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum value
    ) => new("eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum", value);

    public static implicit operator EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum value
    ) => new("eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum", value);

    public static implicit operator EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum value
    ) => new("eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel>
    {
        public override EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel? Read(
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
                        "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel0Enum)
                    ),
                    (
                        "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel1Enum)
                    ),
                    (
                        "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel2Enum)
                    ),
                    (
                        "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel3Enum)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel result =
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel value,
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

        public override EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel result = new(
                "string",
                stringValue
            );
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationAccessLevel value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
