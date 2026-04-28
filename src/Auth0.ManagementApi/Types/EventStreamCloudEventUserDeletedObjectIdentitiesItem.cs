// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Identity object when accounts are linked.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventUserDeletedObjectIdentitiesItem.JsonConverter))]
[Serializable]
public class EventStreamCloudEventUserDeletedObjectIdentitiesItem
{
    private EventStreamCloudEventUserDeletedObjectIdentitiesItem(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemCustom value.
    /// </summary>
    public static EventStreamCloudEventUserDeletedObjectIdentitiesItem FromEventStreamCloudEventUserDeletedObjectIdentitiesItemCustom(
        Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemCustom value
    ) => new("eventStreamCloudEventUserDeletedObjectIdentitiesItemCustom", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase value.
    /// </summary>
    public static EventStreamCloudEventUserDeletedObjectIdentitiesItem FromEventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase(
        Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase value
    ) => new("eventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise value.
    /// </summary>
    public static EventStreamCloudEventUserDeletedObjectIdentitiesItem FromEventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise(
        Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise value
    ) => new("eventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless value.
    /// </summary>
    public static EventStreamCloudEventUserDeletedObjectIdentitiesItem FromEventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless(
        Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless value
    ) => new("eventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemSocial value.
    /// </summary>
    public static EventStreamCloudEventUserDeletedObjectIdentitiesItem FromEventStreamCloudEventUserDeletedObjectIdentitiesItemSocial(
        Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemSocial value
    ) => new("eventStreamCloudEventUserDeletedObjectIdentitiesItemSocial", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserDeletedObjectIdentitiesItemCustom"
    /// </summary>
    public bool IsEventStreamCloudEventUserDeletedObjectIdentitiesItemCustom() =>
        Type == "eventStreamCloudEventUserDeletedObjectIdentitiesItemCustom";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase"
    /// </summary>
    public bool IsEventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase() =>
        Type == "eventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise"
    /// </summary>
    public bool IsEventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise() =>
        Type == "eventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless"
    /// </summary>
    public bool IsEventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless() =>
        Type == "eventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserDeletedObjectIdentitiesItemSocial"
    /// </summary>
    public bool IsEventStreamCloudEventUserDeletedObjectIdentitiesItemSocial() =>
        Type == "eventStreamCloudEventUserDeletedObjectIdentitiesItemSocial";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemCustom"/> if <see cref="Type"/> is 'eventStreamCloudEventUserDeletedObjectIdentitiesItemCustom', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserDeletedObjectIdentitiesItemCustom'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemCustom AsEventStreamCloudEventUserDeletedObjectIdentitiesItemCustom() =>
        IsEventStreamCloudEventUserDeletedObjectIdentitiesItemCustom()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemCustom)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserDeletedObjectIdentitiesItemCustom'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase"/> if <see cref="Type"/> is 'eventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase AsEventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase() =>
        IsEventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise"/> if <see cref="Type"/> is 'eventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise AsEventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise() =>
        IsEventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless"/> if <see cref="Type"/> is 'eventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless AsEventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless() =>
        IsEventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemSocial"/> if <see cref="Type"/> is 'eventStreamCloudEventUserDeletedObjectIdentitiesItemSocial', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserDeletedObjectIdentitiesItemSocial'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemSocial AsEventStreamCloudEventUserDeletedObjectIdentitiesItemSocial() =>
        IsEventStreamCloudEventUserDeletedObjectIdentitiesItemSocial()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemSocial)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserDeletedObjectIdentitiesItemSocial'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemCustom"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserDeletedObjectIdentitiesItemCustom(
        out Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemCustom? value
    )
    {
        if (Type == "eventStreamCloudEventUserDeletedObjectIdentitiesItemCustom")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemCustom)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase(
        out Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase? value
    )
    {
        if (Type == "eventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise(
        out Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise? value
    )
    {
        if (Type == "eventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless(
        out Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless? value
    )
    {
        if (Type == "eventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemSocial"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserDeletedObjectIdentitiesItemSocial(
        out Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemSocial? value
    )
    {
        if (Type == "eventStreamCloudEventUserDeletedObjectIdentitiesItemSocial")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemSocial)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemCustom,
            T
        > onEventStreamCloudEventUserDeletedObjectIdentitiesItemCustom,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase,
            T
        > onEventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise,
            T
        > onEventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless,
            T
        > onEventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemSocial,
            T
        > onEventStreamCloudEventUserDeletedObjectIdentitiesItemSocial
    )
    {
        return Type switch
        {
            "eventStreamCloudEventUserDeletedObjectIdentitiesItemCustom" =>
                onEventStreamCloudEventUserDeletedObjectIdentitiesItemCustom(
                    AsEventStreamCloudEventUserDeletedObjectIdentitiesItemCustom()
                ),
            "eventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase" =>
                onEventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase(
                    AsEventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase()
                ),
            "eventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise" =>
                onEventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise(
                    AsEventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise()
                ),
            "eventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless" =>
                onEventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless(
                    AsEventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless()
                ),
            "eventStreamCloudEventUserDeletedObjectIdentitiesItemSocial" =>
                onEventStreamCloudEventUserDeletedObjectIdentitiesItemSocial(
                    AsEventStreamCloudEventUserDeletedObjectIdentitiesItemSocial()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemCustom> onEventStreamCloudEventUserDeletedObjectIdentitiesItemCustom,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase> onEventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise> onEventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless> onEventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemSocial> onEventStreamCloudEventUserDeletedObjectIdentitiesItemSocial
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventUserDeletedObjectIdentitiesItemCustom":
                onEventStreamCloudEventUserDeletedObjectIdentitiesItemCustom(
                    AsEventStreamCloudEventUserDeletedObjectIdentitiesItemCustom()
                );
                break;
            case "eventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase":
                onEventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase(
                    AsEventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase()
                );
                break;
            case "eventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise":
                onEventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise(
                    AsEventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise()
                );
                break;
            case "eventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless":
                onEventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless(
                    AsEventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless()
                );
                break;
            case "eventStreamCloudEventUserDeletedObjectIdentitiesItemSocial":
                onEventStreamCloudEventUserDeletedObjectIdentitiesItemSocial(
                    AsEventStreamCloudEventUserDeletedObjectIdentitiesItemSocial()
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
        if (obj is not EventStreamCloudEventUserDeletedObjectIdentitiesItem other)
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

    public static implicit operator EventStreamCloudEventUserDeletedObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemCustom value
    ) => new("eventStreamCloudEventUserDeletedObjectIdentitiesItemCustom", value);

    public static implicit operator EventStreamCloudEventUserDeletedObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase value
    ) => new("eventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase", value);

    public static implicit operator EventStreamCloudEventUserDeletedObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise value
    ) => new("eventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise", value);

    public static implicit operator EventStreamCloudEventUserDeletedObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless value
    ) => new("eventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless", value);

    public static implicit operator EventStreamCloudEventUserDeletedObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemSocial value
    ) => new("eventStreamCloudEventUserDeletedObjectIdentitiesItemSocial", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventUserDeletedObjectIdentitiesItem>
    {
        public override EventStreamCloudEventUserDeletedObjectIdentitiesItem? Read(
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
                        "eventStreamCloudEventUserDeletedObjectIdentitiesItemCustom",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemCustom)
                    ),
                    (
                        "eventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemDatabase)
                    ),
                    (
                        "eventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemEnterprise)
                    ),
                    (
                        "eventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemPasswordless)
                    ),
                    (
                        "eventStreamCloudEventUserDeletedObjectIdentitiesItemSocial",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserDeletedObjectIdentitiesItemSocial)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventUserDeletedObjectIdentitiesItem result = new(
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventUserDeletedObjectIdentitiesItem"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserDeletedObjectIdentitiesItem value,
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

        public override EventStreamCloudEventUserDeletedObjectIdentitiesItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventUserDeletedObjectIdentitiesItem result = new(
                "string",
                stringValue
            );
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserDeletedObjectIdentitiesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
