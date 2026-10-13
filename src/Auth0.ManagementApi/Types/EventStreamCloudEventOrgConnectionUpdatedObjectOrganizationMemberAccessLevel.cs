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
    typeof(EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel.JsonConverter)
)]
[Serializable]
public class EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel
{
    private EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel(
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel FromEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum",
            value
        );

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel FromEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum",
            value
        );

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel FromEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum",
            value
        );

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum value.
    /// </summary>
    public static EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel FromEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum",
            value
        );

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum() =>
        Type == "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum() =>
        Type == "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum() =>
        Type == "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum"
    /// </summary>
    public bool IsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum() =>
        Type == "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum AsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum() =>
        IsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum AsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum() =>
        IsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum AsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum() =>
        IsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum AsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum() =>
        IsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum? value
    )
    {
        if (
            Type
            == "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum"
        )
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum? value
    )
    {
        if (
            Type
            == "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum"
        )
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum? value
    )
    {
        if (
            Type
            == "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum"
        )
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum(
        out Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum? value
    )
    {
        if (
            Type
            == "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum"
        )
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum,
            T
        > onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum,
            T
        > onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum,
            T
        > onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum,
            T
        > onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum
    )
    {
        return Type switch
        {
            "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum" =>
                onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum()
                ),
            "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum" =>
                onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum()
                ),
            "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum" =>
                onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum()
                ),
            "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum" =>
                onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum> onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum> onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum> onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum> onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum":
                onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum()
                );
                break;
            case "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum":
                onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum()
                );
                break;
            case "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum":
                onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum()
                );
                break;
            case "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum":
                onEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum(
                    AsEventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum()
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
            is not EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel other
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

    public static implicit operator EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum",
            value
        );

    public static implicit operator EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum",
            value
        );

    public static implicit operator EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum",
            value
        );

    public static implicit operator EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel(
        Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum value
    ) =>
        new(
            "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum",
            value
        );

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel>
    {
        public override EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel? Read(
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
                        "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel0Enum)
                    ),
                    (
                        "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel1Enum)
                    ),
                    (
                        "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel2Enum)
                    ),
                    (
                        "eventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel3Enum)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel result =
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel value,
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

        public override EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel result =
                new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgConnectionUpdatedObjectOrganizationMemberAccessLevel value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
