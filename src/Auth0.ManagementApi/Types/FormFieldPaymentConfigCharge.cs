// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FormFieldPaymentConfigCharge.JsonConverter))]
[Serializable]
public class FormFieldPaymentConfigCharge
{
    private FormFieldPaymentConfigCharge(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.FormFieldPaymentConfigChargeOneOff value.
    /// </summary>
    public static FormFieldPaymentConfigCharge FromFormFieldPaymentConfigChargeOneOff(
        Auth0.ManagementApi.FormFieldPaymentConfigChargeOneOff value
    ) => new("formFieldPaymentConfigChargeOneOff", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormFieldPaymentConfigChargeSubscription value.
    /// </summary>
    public static FormFieldPaymentConfigCharge FromFormFieldPaymentConfigChargeSubscription(
        Auth0.ManagementApi.FormFieldPaymentConfigChargeSubscription value
    ) => new("formFieldPaymentConfigChargeSubscription", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formFieldPaymentConfigChargeOneOff"
    /// </summary>
    public bool IsFormFieldPaymentConfigChargeOneOff() =>
        Type == "formFieldPaymentConfigChargeOneOff";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formFieldPaymentConfigChargeSubscription"
    /// </summary>
    public bool IsFormFieldPaymentConfigChargeSubscription() =>
        Type == "formFieldPaymentConfigChargeSubscription";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormFieldPaymentConfigChargeOneOff"/> if <see cref="Type"/> is 'formFieldPaymentConfigChargeOneOff', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formFieldPaymentConfigChargeOneOff'.</exception>
    public Auth0.ManagementApi.FormFieldPaymentConfigChargeOneOff AsFormFieldPaymentConfigChargeOneOff() =>
        IsFormFieldPaymentConfigChargeOneOff()
            ? (Auth0.ManagementApi.FormFieldPaymentConfigChargeOneOff)Value!
            : throw new ManagementException(
                "Union type is not 'formFieldPaymentConfigChargeOneOff'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormFieldPaymentConfigChargeSubscription"/> if <see cref="Type"/> is 'formFieldPaymentConfigChargeSubscription', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formFieldPaymentConfigChargeSubscription'.</exception>
    public Auth0.ManagementApi.FormFieldPaymentConfigChargeSubscription AsFormFieldPaymentConfigChargeSubscription() =>
        IsFormFieldPaymentConfigChargeSubscription()
            ? (Auth0.ManagementApi.FormFieldPaymentConfigChargeSubscription)Value!
            : throw new ManagementException(
                "Union type is not 'formFieldPaymentConfigChargeSubscription'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormFieldPaymentConfigChargeOneOff"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormFieldPaymentConfigChargeOneOff(
        out Auth0.ManagementApi.FormFieldPaymentConfigChargeOneOff? value
    )
    {
        if (Type == "formFieldPaymentConfigChargeOneOff")
        {
            value = (Auth0.ManagementApi.FormFieldPaymentConfigChargeOneOff)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormFieldPaymentConfigChargeSubscription"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormFieldPaymentConfigChargeSubscription(
        out Auth0.ManagementApi.FormFieldPaymentConfigChargeSubscription? value
    )
    {
        if (Type == "formFieldPaymentConfigChargeSubscription")
        {
            value = (Auth0.ManagementApi.FormFieldPaymentConfigChargeSubscription)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.FormFieldPaymentConfigChargeOneOff,
            T
        > onFormFieldPaymentConfigChargeOneOff,
        Func<
            Auth0.ManagementApi.FormFieldPaymentConfigChargeSubscription,
            T
        > onFormFieldPaymentConfigChargeSubscription
    )
    {
        return Type switch
        {
            "formFieldPaymentConfigChargeOneOff" => onFormFieldPaymentConfigChargeOneOff(
                AsFormFieldPaymentConfigChargeOneOff()
            ),
            "formFieldPaymentConfigChargeSubscription" =>
                onFormFieldPaymentConfigChargeSubscription(
                    AsFormFieldPaymentConfigChargeSubscription()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.FormFieldPaymentConfigChargeOneOff> onFormFieldPaymentConfigChargeOneOff,
        System.Action<Auth0.ManagementApi.FormFieldPaymentConfigChargeSubscription> onFormFieldPaymentConfigChargeSubscription
    )
    {
        switch (Type)
        {
            case "formFieldPaymentConfigChargeOneOff":
                onFormFieldPaymentConfigChargeOneOff(AsFormFieldPaymentConfigChargeOneOff());
                break;
            case "formFieldPaymentConfigChargeSubscription":
                onFormFieldPaymentConfigChargeSubscription(
                    AsFormFieldPaymentConfigChargeSubscription()
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
        if (obj is not FormFieldPaymentConfigCharge other)
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

    public static implicit operator FormFieldPaymentConfigCharge(
        Auth0.ManagementApi.FormFieldPaymentConfigChargeOneOff value
    ) => new("formFieldPaymentConfigChargeOneOff", value);

    public static implicit operator FormFieldPaymentConfigCharge(
        Auth0.ManagementApi.FormFieldPaymentConfigChargeSubscription value
    ) => new("formFieldPaymentConfigChargeSubscription", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FormFieldPaymentConfigCharge>
    {
        public override FormFieldPaymentConfigCharge? Read(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
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
                        "formFieldPaymentConfigChargeOneOff",
                        typeof(Auth0.ManagementApi.FormFieldPaymentConfigChargeOneOff)
                    ),
                    (
                        "formFieldPaymentConfigChargeSubscription",
                        typeof(Auth0.ManagementApi.FormFieldPaymentConfigChargeSubscription)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            FormFieldPaymentConfigCharge result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into FormFieldPaymentConfigCharge"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            FormFieldPaymentConfigCharge value,
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

        public override FormFieldPaymentConfigCharge ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            FormFieldPaymentConfigCharge result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FormFieldPaymentConfigCharge value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
