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
    typeof(EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel.JsonConverter)
)]
[Serializable]
public class EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel
{
    private EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel(
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel FromEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum",
            value
        );

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel FromEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum",
            value
        );

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel FromEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum",
            value
        );

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel FromEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum",
            value
        );

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum() =>
        Type
        == "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum() =>
        Type
        == "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum() =>
        Type
        == "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum() =>
        Type
        == "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum AsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum() =>
        IsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum AsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum() =>
        IsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum AsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum() =>
        IsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum AsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum() =>
        IsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum? value
    )
    {
        if (
            Type
            == "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum"
        )
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum? value
    )
    {
        if (
            Type
            == "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum"
        )
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum? value
    )
    {
        if (
            Type
            == "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum"
        )
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum? value
    )
    {
        if (
            Type
            == "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum"
        )
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum,
            T
        > onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum,
            T
        > onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum,
            T
        > onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum,
            T
        > onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum
    )
    {
        return Type switch
        {
            "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum" =>
                onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum()
                ),
            "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum" =>
                onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum()
                ),
            "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum" =>
                onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum()
                ),
            "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum" =>
                onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum> onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum> onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum> onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum> onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum":
                onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum()
                );
                break;
            case "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum":
                onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum()
                );
                break;
            case "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum":
                onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum()
                );
                break;
            case "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum":
                onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum()
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
            is not EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel other
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

    public static implicit operator EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum",
            value
        );

    public static implicit operator EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum",
            value
        );

    public static implicit operator EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum",
            value
        );

    public static implicit operator EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum",
            value
        );

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel>
    {
        public override EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel? Read(
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
                        "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel0Enum)
                    ),
                    (
                        "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel1Enum)
                    ),
                    (
                        "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel2Enum)
                    ),
                    (
                        "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel3Enum)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel result =
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel value,
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

        public override EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel result =
                new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationAccessLevel value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
