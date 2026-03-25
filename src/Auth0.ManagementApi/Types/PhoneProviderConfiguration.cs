// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(PhoneProviderConfiguration.JsonConverter))]
[Serializable]
public class PhoneProviderConfiguration
{
    private PhoneProviderConfiguration(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.TwilioProviderConfiguration value.
    /// </summary>
    public static PhoneProviderConfiguration FromTwilioProviderConfiguration(
        Auth0.ManagementApi.TwilioProviderConfiguration value
    ) => new("twilioProviderConfiguration", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CustomProviderConfiguration value.
    /// </summary>
    public static PhoneProviderConfiguration FromCustomProviderConfiguration(
        Auth0.ManagementApi.CustomProviderConfiguration value
    ) => new("customProviderConfiguration", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "twilioProviderConfiguration"
    /// </summary>
    public bool IsTwilioProviderConfiguration() => Type == "twilioProviderConfiguration";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "customProviderConfiguration"
    /// </summary>
    public bool IsCustomProviderConfiguration() => Type == "customProviderConfiguration";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.TwilioProviderConfiguration"/> if <see cref="Type"/> is 'twilioProviderConfiguration', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'twilioProviderConfiguration'.</exception>
    public Auth0.ManagementApi.TwilioProviderConfiguration AsTwilioProviderConfiguration() =>
        IsTwilioProviderConfiguration()
            ? (Auth0.ManagementApi.TwilioProviderConfiguration)Value!
            : throw new ManagementException("Union type is not 'twilioProviderConfiguration'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CustomProviderConfiguration"/> if <see cref="Type"/> is 'customProviderConfiguration', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'customProviderConfiguration'.</exception>
    public Auth0.ManagementApi.CustomProviderConfiguration AsCustomProviderConfiguration() =>
        IsCustomProviderConfiguration()
            ? (Auth0.ManagementApi.CustomProviderConfiguration)Value!
            : throw new ManagementException("Union type is not 'customProviderConfiguration'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.TwilioProviderConfiguration"/> and returns true if successful.
    /// </summary>
    public bool TryGetTwilioProviderConfiguration(
        out Auth0.ManagementApi.TwilioProviderConfiguration? value
    )
    {
        if (Type == "twilioProviderConfiguration")
        {
            value = (Auth0.ManagementApi.TwilioProviderConfiguration)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CustomProviderConfiguration"/> and returns true if successful.
    /// </summary>
    public bool TryGetCustomProviderConfiguration(
        out Auth0.ManagementApi.CustomProviderConfiguration? value
    )
    {
        if (Type == "customProviderConfiguration")
        {
            value = (Auth0.ManagementApi.CustomProviderConfiguration)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.ManagementApi.TwilioProviderConfiguration, T> onTwilioProviderConfiguration,
        Func<Auth0.ManagementApi.CustomProviderConfiguration, T> onCustomProviderConfiguration
    )
    {
        return Type switch
        {
            "twilioProviderConfiguration" => onTwilioProviderConfiguration(
                AsTwilioProviderConfiguration()
            ),
            "customProviderConfiguration" => onCustomProviderConfiguration(
                AsCustomProviderConfiguration()
            ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.TwilioProviderConfiguration> onTwilioProviderConfiguration,
        global::System.Action<Auth0.ManagementApi.CustomProviderConfiguration> onCustomProviderConfiguration
    )
    {
        switch (Type)
        {
            case "twilioProviderConfiguration":
                onTwilioProviderConfiguration(AsTwilioProviderConfiguration());
                break;
            case "customProviderConfiguration":
                onCustomProviderConfiguration(AsCustomProviderConfiguration());
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
        if (obj is not PhoneProviderConfiguration other)
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

    public static implicit operator PhoneProviderConfiguration(
        Auth0.ManagementApi.TwilioProviderConfiguration value
    ) => new("twilioProviderConfiguration", value);

    public static implicit operator PhoneProviderConfiguration(
        Auth0.ManagementApi.CustomProviderConfiguration value
    ) => new("customProviderConfiguration", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<PhoneProviderConfiguration>
    {
        public override PhoneProviderConfiguration? Read(
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
                        "twilioProviderConfiguration",
                        typeof(Auth0.ManagementApi.TwilioProviderConfiguration)
                    ),
                    (
                        "customProviderConfiguration",
                        typeof(Auth0.ManagementApi.CustomProviderConfiguration)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            PhoneProviderConfiguration result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into PhoneProviderConfiguration"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PhoneProviderConfiguration value,
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

        public override PhoneProviderConfiguration ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            PhoneProviderConfiguration result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PhoneProviderConfiguration value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
