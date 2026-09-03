// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Identity object when accounts are linked.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItem.JsonConverter))]
[Serializable]
public class EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItem
{
    private EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItem(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom value.
    /// </summary>
    public static EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItem FromEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom(
        Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom value
    ) => new("eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase value.
    /// </summary>
    public static EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItem FromEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase(
        Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase value
    ) => new("eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise value.
    /// </summary>
    public static EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItem FromEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise(
        Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise value
    ) => new("eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless value.
    /// </summary>
    public static EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItem FromEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless(
        Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless value
    ) => new("eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial value.
    /// </summary>
    public static EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItem FromEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial(
        Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial value
    ) => new("eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom"
    /// </summary>
    public bool IsEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom() =>
        Type == "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase"
    /// </summary>
    public bool IsEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase() =>
        Type == "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise"
    /// </summary>
    public bool IsEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise() =>
        Type == "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless"
    /// </summary>
    public bool IsEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless() =>
        Type == "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial"
    /// </summary>
    public bool IsEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial() =>
        Type == "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom"/> if <see cref="Type"/> is 'eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom AsEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom() =>
        IsEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase"/> if <see cref="Type"/> is 'eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase AsEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase() =>
        IsEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise"/> if <see cref="Type"/> is 'eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise AsEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise() =>
        IsEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless"/> if <see cref="Type"/> is 'eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless AsEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless() =>
        IsEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial"/> if <see cref="Type"/> is 'eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial AsEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial() =>
        IsEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom(
        out Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom? value
    )
    {
        if (Type == "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase(
        out Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase? value
    )
    {
        if (Type == "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise(
        out Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise? value
    )
    {
        if (Type == "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless(
        out Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless? value
    )
    {
        if (Type == "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial(
        out Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial? value
    )
    {
        if (Type == "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom,
            T
        > onEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase,
            T
        > onEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise,
            T
        > onEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless,
            T
        > onEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial,
            T
        > onEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial
    )
    {
        return Type switch
        {
            "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom" =>
                onEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom(
                    AsEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom()
                ),
            "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase" =>
                onEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase(
                    AsEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase()
                ),
            "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise" =>
                onEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise(
                    AsEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise()
                ),
            "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless" =>
                onEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless(
                    AsEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless()
                ),
            "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial" =>
                onEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial(
                    AsEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom> onEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase> onEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise> onEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless> onEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial> onEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom":
                onEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom(
                    AsEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom()
                );
                break;
            case "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase":
                onEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase(
                    AsEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase()
                );
                break;
            case "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise":
                onEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise(
                    AsEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise()
                );
                break;
            case "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless":
                onEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless(
                    AsEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless()
                );
                break;
            case "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial":
                onEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial(
                    AsEventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial()
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
        if (obj is not EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItem other)
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

    public static implicit operator EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom value
    ) => new("eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom", value);

    public static implicit operator EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase value
    ) => new("eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase", value);

    public static implicit operator EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise value
    ) => new("eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise", value);

    public static implicit operator EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless value
    ) => new("eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless", value);

    public static implicit operator EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial value
    ) => new("eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItem>
    {
        public override EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItem? Read(
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
                        "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemCustom)
                    ),
                    (
                        "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemDatabase)
                    ),
                    (
                        "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemEnterprise)
                    ),
                    (
                        "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemPasswordless)
                    ),
                    (
                        "eventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocial)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItem result =
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItem"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItem value,
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
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItem result = new(
                "string",
                stringValue
            );
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
