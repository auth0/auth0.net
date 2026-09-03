// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Identity object when accounts are linked.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItem.JsonConverter))]
[Serializable]
public class EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItem
{
    private EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItem(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom value.
    /// </summary>
    public static EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItem FromEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom(
        Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom value
    ) => new("eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase value.
    /// </summary>
    public static EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItem FromEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase(
        Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase value
    ) => new("eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise value.
    /// </summary>
    public static EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItem FromEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise(
        Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise value
    ) => new("eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless value.
    /// </summary>
    public static EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItem FromEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless(
        Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless value
    ) => new("eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial value.
    /// </summary>
    public static EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItem FromEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial(
        Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial value
    ) => new("eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom"
    /// </summary>
    public bool IsEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom() =>
        Type == "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase"
    /// </summary>
    public bool IsEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase() =>
        Type == "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise"
    /// </summary>
    public bool IsEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise() =>
        Type == "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless"
    /// </summary>
    public bool IsEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless() =>
        Type == "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial"
    /// </summary>
    public bool IsEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial() =>
        Type == "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom"/> if <see cref="Type"/> is 'eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom AsEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom() =>
        IsEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase"/> if <see cref="Type"/> is 'eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase AsEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase() =>
        IsEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise"/> if <see cref="Type"/> is 'eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise AsEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise() =>
        IsEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless"/> if <see cref="Type"/> is 'eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless AsEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless() =>
        IsEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial"/> if <see cref="Type"/> is 'eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial AsEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial() =>
        IsEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom(
        out Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom? value
    )
    {
        if (Type == "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase(
        out Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase? value
    )
    {
        if (Type == "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise(
        out Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise? value
    )
    {
        if (Type == "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless(
        out Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless? value
    )
    {
        if (Type == "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial(
        out Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial? value
    )
    {
        if (Type == "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom,
            T
        > onEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase,
            T
        > onEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise,
            T
        > onEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless,
            T
        > onEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial,
            T
        > onEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial
    )
    {
        return Type switch
        {
            "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom" =>
                onEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom(
                    AsEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom()
                ),
            "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase" =>
                onEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase(
                    AsEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase()
                ),
            "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise" =>
                onEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise(
                    AsEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise()
                ),
            "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless" =>
                onEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless(
                    AsEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless()
                ),
            "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial" =>
                onEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial(
                    AsEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom> onEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase> onEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise> onEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless> onEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial> onEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom":
                onEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom(
                    AsEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom()
                );
                break;
            case "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase":
                onEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase(
                    AsEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase()
                );
                break;
            case "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise":
                onEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise(
                    AsEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise()
                );
                break;
            case "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless":
                onEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless(
                    AsEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless()
                );
                break;
            case "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial":
                onEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial(
                    AsEventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial()
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
        if (obj is not EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItem other)
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

    public static implicit operator EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom value
    ) => new("eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom", value);

    public static implicit operator EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase value
    ) => new("eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase", value);

    public static implicit operator EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise value
    ) => new("eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise", value);

    public static implicit operator EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless value
    ) => new("eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless", value);

    public static implicit operator EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial value
    ) => new("eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItem>
    {
        public override EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItem? Read(
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
                        "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemCustom)
                    ),
                    (
                        "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemDatabase)
                    ),
                    (
                        "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise)
                    ),
                    (
                        "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemPasswordless)
                    ),
                    (
                        "eventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocial)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItem result =
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItem"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItem value,
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

        public override EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItem result = new(
                "string",
                stringValue
            );
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
