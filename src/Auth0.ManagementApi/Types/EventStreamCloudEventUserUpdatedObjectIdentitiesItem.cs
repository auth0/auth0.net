// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Identity object when accounts are linked.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventUserUpdatedObjectIdentitiesItem.JsonConverter))]
[Serializable]
public class EventStreamCloudEventUserUpdatedObjectIdentitiesItem
{
    private EventStreamCloudEventUserUpdatedObjectIdentitiesItem(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom value.
    /// </summary>
    public static EventStreamCloudEventUserUpdatedObjectIdentitiesItem FromEventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom(
        Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom value
    ) => new("eventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase value.
    /// </summary>
    public static EventStreamCloudEventUserUpdatedObjectIdentitiesItem FromEventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase(
        Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase value
    ) => new("eventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise value.
    /// </summary>
    public static EventStreamCloudEventUserUpdatedObjectIdentitiesItem FromEventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise(
        Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise value
    ) => new("eventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless value.
    /// </summary>
    public static EventStreamCloudEventUserUpdatedObjectIdentitiesItem FromEventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless(
        Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless value
    ) => new("eventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial value.
    /// </summary>
    public static EventStreamCloudEventUserUpdatedObjectIdentitiesItem FromEventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial(
        Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial value
    ) => new("eventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom"
    /// </summary>
    public bool IsEventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom() =>
        Type == "eventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase"
    /// </summary>
    public bool IsEventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase() =>
        Type == "eventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise"
    /// </summary>
    public bool IsEventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise() =>
        Type == "eventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless"
    /// </summary>
    public bool IsEventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless() =>
        Type == "eventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial"
    /// </summary>
    public bool IsEventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial() =>
        Type == "eventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom"/> if <see cref="Type"/> is 'eventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom AsEventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom() =>
        IsEventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase"/> if <see cref="Type"/> is 'eventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase AsEventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase() =>
        IsEventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise"/> if <see cref="Type"/> is 'eventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise AsEventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise() =>
        IsEventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless"/> if <see cref="Type"/> is 'eventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless AsEventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless() =>
        IsEventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial"/> if <see cref="Type"/> is 'eventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial AsEventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial() =>
        IsEventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial()
            ? (Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom(
        out Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom? value
    )
    {
        if (Type == "eventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase(
        out Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase? value
    )
    {
        if (Type == "eventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise(
        out Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise? value
    )
    {
        if (Type == "eventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless(
        out Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless? value
    )
    {
        if (Type == "eventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial(
        out Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial? value
    )
    {
        if (Type == "eventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom,
            T
        > onEventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase,
            T
        > onEventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise,
            T
        > onEventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless,
            T
        > onEventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial,
            T
        > onEventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial
    )
    {
        return Type switch
        {
            "eventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom" =>
                onEventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom(
                    AsEventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom()
                ),
            "eventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase" =>
                onEventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase(
                    AsEventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase()
                ),
            "eventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise" =>
                onEventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise(
                    AsEventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise()
                ),
            "eventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless" =>
                onEventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless(
                    AsEventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless()
                ),
            "eventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial" =>
                onEventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial(
                    AsEventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom> onEventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase> onEventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise> onEventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless> onEventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial> onEventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom":
                onEventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom(
                    AsEventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom()
                );
                break;
            case "eventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase":
                onEventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase(
                    AsEventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase()
                );
                break;
            case "eventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise":
                onEventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise(
                    AsEventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise()
                );
                break;
            case "eventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless":
                onEventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless(
                    AsEventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless()
                );
                break;
            case "eventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial":
                onEventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial(
                    AsEventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial()
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
        if (obj is not EventStreamCloudEventUserUpdatedObjectIdentitiesItem other)
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

    public static implicit operator EventStreamCloudEventUserUpdatedObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom value
    ) => new("eventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom", value);

    public static implicit operator EventStreamCloudEventUserUpdatedObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase value
    ) => new("eventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase", value);

    public static implicit operator EventStreamCloudEventUserUpdatedObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise value
    ) => new("eventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise", value);

    public static implicit operator EventStreamCloudEventUserUpdatedObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless value
    ) => new("eventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless", value);

    public static implicit operator EventStreamCloudEventUserUpdatedObjectIdentitiesItem(
        Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial value
    ) => new("eventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventUserUpdatedObjectIdentitiesItem>
    {
        public override EventStreamCloudEventUserUpdatedObjectIdentitiesItem? Read(
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
                        "eventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemCustom)
                    ),
                    (
                        "eventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemDatabase)
                    ),
                    (
                        "eventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise)
                    ),
                    (
                        "eventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemPasswordless)
                    ),
                    (
                        "eventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocial)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventUserUpdatedObjectIdentitiesItem result = new(
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventUserUpdatedObjectIdentitiesItem"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserUpdatedObjectIdentitiesItem value,
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

        public override EventStreamCloudEventUserUpdatedObjectIdentitiesItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventUserUpdatedObjectIdentitiesItem result = new(
                "string",
                stringValue
            );
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserUpdatedObjectIdentitiesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
