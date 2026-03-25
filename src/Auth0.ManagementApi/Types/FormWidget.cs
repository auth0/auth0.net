// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FormWidget.JsonConverter))]
[Serializable]
public class FormWidget
{
    private FormWidget(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.FormWidgetAuth0VerifiableCredentials value.
    /// </summary>
    public static FormWidget FromFormWidgetAuth0VerifiableCredentials(
        Auth0.ManagementApi.FormWidgetAuth0VerifiableCredentials value
    ) => new("formWidgetAuth0VerifiableCredentials", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormWidgetGMapsAddress value.
    /// </summary>
    public static FormWidget FromFormWidgetGMapsAddress(
        Auth0.ManagementApi.FormWidgetGMapsAddress value
    ) => new("formWidgetGMapsAddress", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormWidgetRecaptcha value.
    /// </summary>
    public static FormWidget FromFormWidgetRecaptcha(
        Auth0.ManagementApi.FormWidgetRecaptcha value
    ) => new("formWidgetRecaptcha", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formWidgetAuth0VerifiableCredentials"
    /// </summary>
    public bool IsFormWidgetAuth0VerifiableCredentials() =>
        Type == "formWidgetAuth0VerifiableCredentials";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formWidgetGMapsAddress"
    /// </summary>
    public bool IsFormWidgetGMapsAddress() => Type == "formWidgetGMapsAddress";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formWidgetRecaptcha"
    /// </summary>
    public bool IsFormWidgetRecaptcha() => Type == "formWidgetRecaptcha";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormWidgetAuth0VerifiableCredentials"/> if <see cref="Type"/> is 'formWidgetAuth0VerifiableCredentials', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formWidgetAuth0VerifiableCredentials'.</exception>
    public Auth0.ManagementApi.FormWidgetAuth0VerifiableCredentials AsFormWidgetAuth0VerifiableCredentials() =>
        IsFormWidgetAuth0VerifiableCredentials()
            ? (Auth0.ManagementApi.FormWidgetAuth0VerifiableCredentials)Value!
            : throw new ManagementException(
                "Union type is not 'formWidgetAuth0VerifiableCredentials'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormWidgetGMapsAddress"/> if <see cref="Type"/> is 'formWidgetGMapsAddress', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formWidgetGMapsAddress'.</exception>
    public Auth0.ManagementApi.FormWidgetGMapsAddress AsFormWidgetGMapsAddress() =>
        IsFormWidgetGMapsAddress()
            ? (Auth0.ManagementApi.FormWidgetGMapsAddress)Value!
            : throw new ManagementException("Union type is not 'formWidgetGMapsAddress'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormWidgetRecaptcha"/> if <see cref="Type"/> is 'formWidgetRecaptcha', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formWidgetRecaptcha'.</exception>
    public Auth0.ManagementApi.FormWidgetRecaptcha AsFormWidgetRecaptcha() =>
        IsFormWidgetRecaptcha()
            ? (Auth0.ManagementApi.FormWidgetRecaptcha)Value!
            : throw new ManagementException("Union type is not 'formWidgetRecaptcha'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormWidgetAuth0VerifiableCredentials"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormWidgetAuth0VerifiableCredentials(
        out Auth0.ManagementApi.FormWidgetAuth0VerifiableCredentials? value
    )
    {
        if (Type == "formWidgetAuth0VerifiableCredentials")
        {
            value = (Auth0.ManagementApi.FormWidgetAuth0VerifiableCredentials)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormWidgetGMapsAddress"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormWidgetGMapsAddress(out Auth0.ManagementApi.FormWidgetGMapsAddress? value)
    {
        if (Type == "formWidgetGMapsAddress")
        {
            value = (Auth0.ManagementApi.FormWidgetGMapsAddress)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormWidgetRecaptcha"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormWidgetRecaptcha(out Auth0.ManagementApi.FormWidgetRecaptcha? value)
    {
        if (Type == "formWidgetRecaptcha")
        {
            value = (Auth0.ManagementApi.FormWidgetRecaptcha)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.FormWidgetAuth0VerifiableCredentials,
            T
        > onFormWidgetAuth0VerifiableCredentials,
        Func<Auth0.ManagementApi.FormWidgetGMapsAddress, T> onFormWidgetGMapsAddress,
        Func<Auth0.ManagementApi.FormWidgetRecaptcha, T> onFormWidgetRecaptcha
    )
    {
        return Type switch
        {
            "formWidgetAuth0VerifiableCredentials" => onFormWidgetAuth0VerifiableCredentials(
                AsFormWidgetAuth0VerifiableCredentials()
            ),
            "formWidgetGMapsAddress" => onFormWidgetGMapsAddress(AsFormWidgetGMapsAddress()),
            "formWidgetRecaptcha" => onFormWidgetRecaptcha(AsFormWidgetRecaptcha()),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.FormWidgetAuth0VerifiableCredentials> onFormWidgetAuth0VerifiableCredentials,
        global::System.Action<Auth0.ManagementApi.FormWidgetGMapsAddress> onFormWidgetGMapsAddress,
        global::System.Action<Auth0.ManagementApi.FormWidgetRecaptcha> onFormWidgetRecaptcha
    )
    {
        switch (Type)
        {
            case "formWidgetAuth0VerifiableCredentials":
                onFormWidgetAuth0VerifiableCredentials(AsFormWidgetAuth0VerifiableCredentials());
                break;
            case "formWidgetGMapsAddress":
                onFormWidgetGMapsAddress(AsFormWidgetGMapsAddress());
                break;
            case "formWidgetRecaptcha":
                onFormWidgetRecaptcha(AsFormWidgetRecaptcha());
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
        if (obj is not FormWidget other)
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

    public static implicit operator FormWidget(
        Auth0.ManagementApi.FormWidgetAuth0VerifiableCredentials value
    ) => new("formWidgetAuth0VerifiableCredentials", value);

    public static implicit operator FormWidget(Auth0.ManagementApi.FormWidgetGMapsAddress value) =>
        new("formWidgetGMapsAddress", value);

    public static implicit operator FormWidget(Auth0.ManagementApi.FormWidgetRecaptcha value) =>
        new("formWidgetRecaptcha", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FormWidget>
    {
        public override FormWidget? Read(
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
                        "formWidgetAuth0VerifiableCredentials",
                        typeof(Auth0.ManagementApi.FormWidgetAuth0VerifiableCredentials)
                    ),
                    ("formWidgetGMapsAddress", typeof(Auth0.ManagementApi.FormWidgetGMapsAddress)),
                    ("formWidgetRecaptcha", typeof(Auth0.ManagementApi.FormWidgetRecaptcha)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            FormWidget result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into FormWidget"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            FormWidget value,
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
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override FormWidget ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            FormWidget result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FormWidget value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
