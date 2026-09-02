// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Identity object when accounts are linked.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItem.JsonConverter))]
[Serializable]
public class EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItem
{
    private EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItem(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom value.
    /// </summary>
    public static EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItem FromEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom(
        Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom value
    ) => new("eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase value.
    /// </summary>
    public static EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItem FromEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase(
        Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase value
    ) => new("eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise value.
    /// </summary>
    public static EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItem FromEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise(
        Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise value
    ) => new("eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless value.
    /// </summary>
    public static EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItem FromEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless(
        Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless value
    ) => new("eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial value.
    /// </summary>
    public static EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItem FromEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial(
        Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial value
    ) => new("eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom"
    /// </summary>
    public bool IsEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom() =>
        Type == "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase"
    /// </summary>
    public bool IsEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase() =>
        Type == "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise"
    /// </summary>
    public bool IsEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise() =>
        Type == "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless"
    /// </summary>
    public bool IsEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless() =>
        Type == "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial"
    /// </summary>
    public bool IsEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial() =>
        Type == "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom"/> if <see cref="Type"/> is 'eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom AsEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom() =>
        IsEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase"/> if <see cref="Type"/> is 'eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase AsEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase() =>
        IsEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise"/> if <see cref="Type"/> is 'eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise AsEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise() =>
        IsEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless"/> if <see cref="Type"/> is 'eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless AsEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless() =>
        IsEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial"/> if <see cref="Type"/> is 'eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial AsEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial() =>
        IsEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom(
        out Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom? value
    )
    {
        if (Type == "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase(
        out Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase? value
    )
    {
        if (Type == "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise(
        out Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise? value
    )
    {
        if (Type == "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless(
        out Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless? value
    )
    {
        if (Type == "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial(
        out Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial? value
    )
    {
        if (Type == "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom,
            T
        > onEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase,
            T
        > onEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise,
            T
        > onEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless,
            T
        > onEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial,
            T
        > onEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial
    )
    {
        return Type switch
        {
            "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom" =>
                onEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom(
                    AsEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom()
                ),
            "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase" =>
                onEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase(
                    AsEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase()
                ),
            "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise" =>
                onEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise(
                    AsEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise()
                ),
            "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless" =>
                onEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless(
                    AsEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless()
                ),
            "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial" =>
                onEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial(
                    AsEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom> onEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase> onEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise> onEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless> onEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial> onEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom":
                onEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom(
                    AsEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom()
                );
                break;
            case "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase":
                onEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase(
                    AsEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase()
                );
                break;
            case "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise":
                onEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise(
                    AsEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise()
                );
                break;
            case "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless":
                onEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless(
                    AsEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless()
                );
                break;
            case "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial":
                onEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial(
                    AsEventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial()
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
        if (obj is not EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItem other)
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

    public static implicit operator EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom value
    ) => new("eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom", value);

    public static implicit operator EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase value
    ) => new("eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase", value);

    public static implicit operator EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise value
    ) => new("eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise", value);

    public static implicit operator EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless value
    ) => new("eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless", value);

    public static implicit operator EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial value
    ) => new("eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItem>
    {
        public override EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItem? Read(
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
                        "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemCustom)
                    ),
                    (
                        "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemDatabase)
                    ),
                    (
                        "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemEnterprise)
                    ),
                    (
                        "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemPasswordless)
                    ),
                    (
                        "eventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItemSocial)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItem result =
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItem"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItem value,
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

        public override EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItem result = new(
                "string",
                stringValue
            );
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserDeletedPreviousObjectIdentitiesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
