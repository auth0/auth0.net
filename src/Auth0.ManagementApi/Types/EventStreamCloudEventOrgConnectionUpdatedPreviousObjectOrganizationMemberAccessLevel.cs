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
    typeof(EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel.JsonConverter)
)]
[Serializable]
public class EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel
{
    private EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel(
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
    /// Factory method to create a union from a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum"/> value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel FromEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum",
            value
        );

    /// <summary>
    /// Factory method to create a union from a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum"/> value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel FromEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum",
            value
        );

    /// <summary>
    /// Factory method to create a union from a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum"/> value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel FromEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum",
            value
        );

    /// <summary>
    /// Factory method to create a union from a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum"/> value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel FromEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum",
            value
        );

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum() =>
        Type
        == "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum() =>
        Type
        == "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum() =>
        Type
        == "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum() =>
        Type
        == "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum AsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum() =>
        IsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum AsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum() =>
        IsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum AsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum() =>
        IsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum AsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum() =>
        IsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum? value
    )
    {
        if (
            Type
            == "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum"
        )
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum? value
    )
    {
        if (
            Type
            == "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum"
        )
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum? value
    )
    {
        if (
            Type
            == "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum"
        )
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum? value
    )
    {
        if (
            Type
            == "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum"
        )
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum,
            T
        > onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum,
            T
        > onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum,
            T
        > onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum,
            T
        > onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum
    )
    {
        return Type switch
        {
            "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum" =>
                onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum()
                ),
            "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum" =>
                onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum()
                ),
            "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum" =>
                onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum()
                ),
            "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum" =>
                onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum> onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum> onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum> onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum> onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum":
                onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum()
                );
                break;
            case "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum":
                onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum()
                );
                break;
            case "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum":
                onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum()
                );
                break;
            case "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum":
                onEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum()
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
            is not EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel other
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

    public static implicit operator EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum",
            value
        );

    public static implicit operator EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum",
            value
        );

    public static implicit operator EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum",
            value
        );

    public static implicit operator EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum",
            value
        );

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel>
    {
        public override EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel? Read(
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
                        "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel0Enum)
                    ),
                    (
                        "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel1Enum)
                    ),
                    (
                        "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel2Enum)
                    ),
                    (
                        "eventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel3Enum)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel result =
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel value,
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

        public override EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel result =
                new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionUpdatedPreviousObjectOrganizationMemberAccessLevel value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
