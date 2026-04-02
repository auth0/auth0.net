// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Provider credentials required to use authenticate to the provider.
/// </summary>
[JsonConverter(typeof(PhoneProviderCredentials.JsonConverter))]
[Serializable]
public class PhoneProviderCredentials
{
    private PhoneProviderCredentials(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.TwilioProviderCredentials value.
    /// </summary>
    public static PhoneProviderCredentials FromTwilioProviderCredentials(
        Auth0.ManagementApi.TwilioProviderCredentials value
    ) => new("twilioProviderCredentials", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CustomProviderCredentials value.
    /// </summary>
    public static PhoneProviderCredentials FromCustomProviderCredentials(
        Auth0.ManagementApi.CustomProviderCredentials value
    ) => new("customProviderCredentials", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "twilioProviderCredentials"
    /// </summary>
    public bool IsTwilioProviderCredentials() => Type == "twilioProviderCredentials";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "customProviderCredentials"
    /// </summary>
    public bool IsCustomProviderCredentials() => Type == "customProviderCredentials";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.TwilioProviderCredentials"/> if <see cref="Type"/> is 'twilioProviderCredentials', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'twilioProviderCredentials'.</exception>
    public Auth0.ManagementApi.TwilioProviderCredentials AsTwilioProviderCredentials() =>
        IsTwilioProviderCredentials()
            ? (Auth0.ManagementApi.TwilioProviderCredentials)Value!
            : throw new ManagementException("Union type is not 'twilioProviderCredentials'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CustomProviderCredentials"/> if <see cref="Type"/> is 'customProviderCredentials', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'customProviderCredentials'.</exception>
    public Auth0.ManagementApi.CustomProviderCredentials AsCustomProviderCredentials() =>
        IsCustomProviderCredentials()
            ? (Auth0.ManagementApi.CustomProviderCredentials)Value!
            : throw new ManagementException("Union type is not 'customProviderCredentials'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.TwilioProviderCredentials"/> and returns true if successful.
    /// </summary>
    public bool TryGetTwilioProviderCredentials(
        out Auth0.ManagementApi.TwilioProviderCredentials? value
    )
    {
        if (Type == "twilioProviderCredentials")
        {
            value = (Auth0.ManagementApi.TwilioProviderCredentials)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CustomProviderCredentials"/> and returns true if successful.
    /// </summary>
    public bool TryGetCustomProviderCredentials(
        out Auth0.ManagementApi.CustomProviderCredentials? value
    )
    {
        if (Type == "customProviderCredentials")
        {
            value = (Auth0.ManagementApi.CustomProviderCredentials)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.ManagementApi.TwilioProviderCredentials, T> onTwilioProviderCredentials,
        Func<Auth0.ManagementApi.CustomProviderCredentials, T> onCustomProviderCredentials
    )
    {
        return Type switch
        {
            "twilioProviderCredentials" => onTwilioProviderCredentials(
                AsTwilioProviderCredentials()
            ),
            "customProviderCredentials" => onCustomProviderCredentials(
                AsCustomProviderCredentials()
            ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.TwilioProviderCredentials> onTwilioProviderCredentials,
        global::System.Action<Auth0.ManagementApi.CustomProviderCredentials> onCustomProviderCredentials
    )
    {
        switch (Type)
        {
            case "twilioProviderCredentials":
                onTwilioProviderCredentials(AsTwilioProviderCredentials());
                break;
            case "customProviderCredentials":
                onCustomProviderCredentials(AsCustomProviderCredentials());
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
        if (obj is not PhoneProviderCredentials other)
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

    public static implicit operator PhoneProviderCredentials(
        Auth0.ManagementApi.TwilioProviderCredentials value
    ) => new("twilioProviderCredentials", value);

    public static implicit operator PhoneProviderCredentials(
        Auth0.ManagementApi.CustomProviderCredentials value
    ) => new("customProviderCredentials", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<PhoneProviderCredentials>
    {
        public override PhoneProviderCredentials? Read(
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
                        "twilioProviderCredentials",
                        typeof(Auth0.ManagementApi.TwilioProviderCredentials)
                    ),
                    (
                        "customProviderCredentials",
                        typeof(Auth0.ManagementApi.CustomProviderCredentials)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            PhoneProviderCredentials result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into PhoneProviderCredentials"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PhoneProviderCredentials value,
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
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override PhoneProviderCredentials ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            PhoneProviderCredentials result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PhoneProviderCredentials value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
