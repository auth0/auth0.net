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
    typeof(EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel.JsonConverter)
)]
[Serializable]
public class EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel
{
    private EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel(
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel FromEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum",
            value
        );

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel FromEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum",
            value
        );

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel FromEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum",
            value
        );

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel FromEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum",
            value
        );

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum() =>
        Type == "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum() =>
        Type == "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum() =>
        Type == "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum() =>
        Type == "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum AsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum() =>
        IsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum AsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum() =>
        IsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum AsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum() =>
        IsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum AsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum() =>
        IsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum? value
    )
    {
        if (
            Type
            == "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum"
        )
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum? value
    )
    {
        if (
            Type
            == "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum"
        )
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum? value
    )
    {
        if (
            Type
            == "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum"
        )
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum? value
    )
    {
        if (
            Type
            == "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum"
        )
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum,
            T
        > onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum,
            T
        > onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum,
            T
        > onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum,
            T
        > onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum
    )
    {
        return Type switch
        {
            "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum" =>
                onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum(
                    AsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum()
                ),
            "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum" =>
                onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum(
                    AsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum()
                ),
            "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum" =>
                onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum(
                    AsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum()
                ),
            "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum" =>
                onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum(
                    AsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum> onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum> onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum> onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum> onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum":
                onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum(
                    AsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum()
                );
                break;
            case "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum":
                onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum(
                    AsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum()
                );
                break;
            case "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum":
                onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum(
                    AsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum()
                );
                break;
            case "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum":
                onEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum(
                    AsEventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum()
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
            is not EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel other
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

    public static implicit operator EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum",
            value
        );

    public static implicit operator EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum",
            value
        );

    public static implicit operator EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum",
            value
        );

    public static implicit operator EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum",
            value
        );

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel>
    {
        public override EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel? Read(
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
                        "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel0Enum)
                    ),
                    (
                        "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel1Enum)
                    ),
                    (
                        "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel2Enum)
                    ),
                    (
                        "eventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel3Enum)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel result =
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel value,
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

        public override EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel result =
                new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionAddedPreviousObjectOrganizationAccessLevel value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
