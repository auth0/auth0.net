// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Identity object when accounts are linked.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventUserCreatedObjectIdentitiesItem.JsonConverter))]
[Serializable]
public class EventStreamCloudEventUserCreatedObjectIdentitiesItem
{
    private EventStreamCloudEventUserCreatedObjectIdentitiesItem(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemCustom value.
    /// </summary>
    public static EventStreamCloudEventUserCreatedObjectIdentitiesItem FromEventStreamCloudEventUserCreatedObjectIdentitiesItemCustom(
        Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemCustom value
    ) => new("eventStreamCloudEventUserCreatedObjectIdentitiesItemCustom", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase value.
    /// </summary>
    public static EventStreamCloudEventUserCreatedObjectIdentitiesItem FromEventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase(
        Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase value
    ) => new("eventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise value.
    /// </summary>
    public static EventStreamCloudEventUserCreatedObjectIdentitiesItem FromEventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise(
        Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise value
    ) => new("eventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless value.
    /// </summary>
    public static EventStreamCloudEventUserCreatedObjectIdentitiesItem FromEventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless(
        Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless value
    ) => new("eventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemSocial value.
    /// </summary>
    public static EventStreamCloudEventUserCreatedObjectIdentitiesItem FromEventStreamCloudEventUserCreatedObjectIdentitiesItemSocial(
        Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemSocial value
    ) => new("eventStreamCloudEventUserCreatedObjectIdentitiesItemSocial", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserCreatedObjectIdentitiesItemCustom"
    /// </summary>
    public bool IsEventStreamCloudEventUserCreatedObjectIdentitiesItemCustom() =>
        Type == "eventStreamCloudEventUserCreatedObjectIdentitiesItemCustom";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase"
    /// </summary>
    public bool IsEventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase() =>
        Type == "eventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise"
    /// </summary>
    public bool IsEventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise() =>
        Type == "eventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless"
    /// </summary>
    public bool IsEventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless() =>
        Type == "eventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserCreatedObjectIdentitiesItemSocial"
    /// </summary>
    public bool IsEventStreamCloudEventUserCreatedObjectIdentitiesItemSocial() =>
        Type == "eventStreamCloudEventUserCreatedObjectIdentitiesItemSocial";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemCustom"/> if <see cref="Type"/> is 'eventStreamCloudEventUserCreatedObjectIdentitiesItemCustom', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserCreatedObjectIdentitiesItemCustom'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemCustom AsEventStreamCloudEventUserCreatedObjectIdentitiesItemCustom() =>
        IsEventStreamCloudEventUserCreatedObjectIdentitiesItemCustom()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemCustom)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserCreatedObjectIdentitiesItemCustom'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase"/> if <see cref="Type"/> is 'eventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase AsEventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase() =>
        IsEventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise"/> if <see cref="Type"/> is 'eventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise AsEventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise() =>
        IsEventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless"/> if <see cref="Type"/> is 'eventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless AsEventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless() =>
        IsEventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemSocial"/> if <see cref="Type"/> is 'eventStreamCloudEventUserCreatedObjectIdentitiesItemSocial', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserCreatedObjectIdentitiesItemSocial'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemSocial AsEventStreamCloudEventUserCreatedObjectIdentitiesItemSocial() =>
        IsEventStreamCloudEventUserCreatedObjectIdentitiesItemSocial()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemSocial)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserCreatedObjectIdentitiesItemSocial'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemCustom"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserCreatedObjectIdentitiesItemCustom(
        out Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemCustom? value
    )
    {
        if (Type == "eventStreamCloudEventUserCreatedObjectIdentitiesItemCustom")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemCustom)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase(
        out Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase? value
    )
    {
        if (Type == "eventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise(
        out Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise? value
    )
    {
        if (Type == "eventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless(
        out Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless? value
    )
    {
        if (Type == "eventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemSocial"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserCreatedObjectIdentitiesItemSocial(
        out Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemSocial? value
    )
    {
        if (Type == "eventStreamCloudEventUserCreatedObjectIdentitiesItemSocial")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemSocial)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemCustom,
            T
        > onEventStreamCloudEventUserCreatedObjectIdentitiesItemCustom,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase,
            T
        > onEventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise,
            T
        > onEventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless,
            T
        > onEventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemSocial,
            T
        > onEventStreamCloudEventUserCreatedObjectIdentitiesItemSocial
    )
    {
        return Type switch
        {
            "eventStreamCloudEventUserCreatedObjectIdentitiesItemCustom" =>
                onEventStreamCloudEventUserCreatedObjectIdentitiesItemCustom(
                    AsEventStreamCloudEventUserCreatedObjectIdentitiesItemCustom()
                ),
            "eventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase" =>
                onEventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase(
                    AsEventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase()
                ),
            "eventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise" =>
                onEventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise(
                    AsEventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise()
                ),
            "eventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless" =>
                onEventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless(
                    AsEventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless()
                ),
            "eventStreamCloudEventUserCreatedObjectIdentitiesItemSocial" =>
                onEventStreamCloudEventUserCreatedObjectIdentitiesItemSocial(
                    AsEventStreamCloudEventUserCreatedObjectIdentitiesItemSocial()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemCustom> onEventStreamCloudEventUserCreatedObjectIdentitiesItemCustom,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase> onEventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise> onEventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless> onEventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemSocial> onEventStreamCloudEventUserCreatedObjectIdentitiesItemSocial
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventUserCreatedObjectIdentitiesItemCustom":
                onEventStreamCloudEventUserCreatedObjectIdentitiesItemCustom(
                    AsEventStreamCloudEventUserCreatedObjectIdentitiesItemCustom()
                );
                break;
            case "eventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase":
                onEventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase(
                    AsEventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase()
                );
                break;
            case "eventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise":
                onEventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise(
                    AsEventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise()
                );
                break;
            case "eventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless":
                onEventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless(
                    AsEventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless()
                );
                break;
            case "eventStreamCloudEventUserCreatedObjectIdentitiesItemSocial":
                onEventStreamCloudEventUserCreatedObjectIdentitiesItemSocial(
                    AsEventStreamCloudEventUserCreatedObjectIdentitiesItemSocial()
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
        if (obj is not EventStreamCloudEventUserCreatedObjectIdentitiesItem other)
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

    public static implicit operator EventStreamCloudEventUserCreatedObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemCustom value
    ) => new("eventStreamCloudEventUserCreatedObjectIdentitiesItemCustom", value);

    public static implicit operator EventStreamCloudEventUserCreatedObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase value
    ) => new("eventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase", value);

    public static implicit operator EventStreamCloudEventUserCreatedObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise value
    ) => new("eventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise", value);

    public static implicit operator EventStreamCloudEventUserCreatedObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless value
    ) => new("eventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless", value);

    public static implicit operator EventStreamCloudEventUserCreatedObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemSocial value
    ) => new("eventStreamCloudEventUserCreatedObjectIdentitiesItemSocial", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventUserCreatedObjectIdentitiesItem>
    {
        public override EventStreamCloudEventUserCreatedObjectIdentitiesItem? Read(
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
                        "eventStreamCloudEventUserCreatedObjectIdentitiesItemCustom",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemCustom)
                    ),
                    (
                        "eventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemDatabase)
                    ),
                    (
                        "eventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterprise)
                    ),
                    (
                        "eventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemPasswordless)
                    ),
                    (
                        "eventStreamCloudEventUserCreatedObjectIdentitiesItemSocial",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserCreatedObjectIdentitiesItemSocial)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventUserCreatedObjectIdentitiesItem result = new(
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventUserCreatedObjectIdentitiesItem"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserCreatedObjectIdentitiesItem value,
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

        public override EventStreamCloudEventUserCreatedObjectIdentitiesItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventUserCreatedObjectIdentitiesItem result = new(
                "string",
                stringValue
            );
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserCreatedObjectIdentitiesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
