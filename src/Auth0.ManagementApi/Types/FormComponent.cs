// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FormComponent.JsonConverter))]
[Serializable]
public class FormComponent
{
    private FormComponent(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.FormBlock value.
    /// </summary>
    public static FormComponent FromFormBlock(Auth0.ManagementApi.FormBlock value) =>
        new("formBlock", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormWidget value.
    /// </summary>
    public static FormComponent FromFormWidget(Auth0.ManagementApi.FormWidget value) =>
        new("formWidget", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormField value.
    /// </summary>
    public static FormComponent FromFormField(Auth0.ManagementApi.FormField value) =>
        new("formField", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formBlock"
    /// </summary>
    public bool IsFormBlock() => Type == "formBlock";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formWidget"
    /// </summary>
    public bool IsFormWidget() => Type == "formWidget";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formField"
    /// </summary>
    public bool IsFormField() => Type == "formField";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormBlock"/> if <see cref="Type"/> is 'formBlock', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formBlock'.</exception>
    public Auth0.ManagementApi.FormBlock AsFormBlock() =>
        IsFormBlock()
            ? (Auth0.ManagementApi.FormBlock)Value!
            : throw new ManagementException("Union type is not 'formBlock'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormWidget"/> if <see cref="Type"/> is 'formWidget', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formWidget'.</exception>
    public Auth0.ManagementApi.FormWidget AsFormWidget() =>
        IsFormWidget()
            ? (Auth0.ManagementApi.FormWidget)Value!
            : throw new ManagementException("Union type is not 'formWidget'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormField"/> if <see cref="Type"/> is 'formField', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formField'.</exception>
    public Auth0.ManagementApi.FormField AsFormField() =>
        IsFormField()
            ? (Auth0.ManagementApi.FormField)Value!
            : throw new ManagementException("Union type is not 'formField'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormBlock"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormBlock(out Auth0.ManagementApi.FormBlock? value)
    {
        if (Type == "formBlock")
        {
            value = (Auth0.ManagementApi.FormBlock)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormWidget"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormWidget(out Auth0.ManagementApi.FormWidget? value)
    {
        if (Type == "formWidget")
        {
            value = (Auth0.ManagementApi.FormWidget)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormField"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormField(out Auth0.ManagementApi.FormField? value)
    {
        if (Type == "formField")
        {
            value = (Auth0.ManagementApi.FormField)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.ManagementApi.FormBlock, T> onFormBlock,
        Func<Auth0.ManagementApi.FormWidget, T> onFormWidget,
        Func<Auth0.ManagementApi.FormField, T> onFormField
    )
    {
        return Type switch
        {
            "formBlock" => onFormBlock(AsFormBlock()),
            "formWidget" => onFormWidget(AsFormWidget()),
            "formField" => onFormField(AsFormField()),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.FormBlock> onFormBlock,
        System.Action<Auth0.ManagementApi.FormWidget> onFormWidget,
        System.Action<Auth0.ManagementApi.FormField> onFormField
    )
    {
        switch (Type)
        {
            case "formBlock":
                onFormBlock(AsFormBlock());
                break;
            case "formWidget":
                onFormWidget(AsFormWidget());
                break;
            case "formField":
                onFormField(AsFormField());
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
        if (obj is not FormComponent other)
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

    public static implicit operator FormComponent(Auth0.ManagementApi.FormBlock value) =>
        new("formBlock", value);

    public static implicit operator FormComponent(Auth0.ManagementApi.FormWidget value) =>
        new("formWidget", value);

    public static implicit operator FormComponent(Auth0.ManagementApi.FormField value) =>
        new("formField", value);

    public static implicit operator FormComponent(Auth0.ManagementApi.FormBlockDivider value) =>
        new("formBlock", (FormBlock)value);

    public static implicit operator FormComponent(Auth0.ManagementApi.FormBlockHtml value) =>
        new("formBlock", (FormBlock)value);

    public static implicit operator FormComponent(Auth0.ManagementApi.FormBlockImage value) =>
        new("formBlock", (FormBlock)value);

    public static implicit operator FormComponent(Auth0.ManagementApi.FormBlockJumpButton value) =>
        new("formBlock", (FormBlock)value);

    public static implicit operator FormComponent(
        Auth0.ManagementApi.FormBlockResendButton value
    ) => new("formBlock", (FormBlock)value);

    public static implicit operator FormComponent(Auth0.ManagementApi.FormBlockNextButton value) =>
        new("formBlock", (FormBlock)value);

    public static implicit operator FormComponent(
        Auth0.ManagementApi.FormBlockPreviousButton value
    ) => new("formBlock", (FormBlock)value);

    public static implicit operator FormComponent(Auth0.ManagementApi.FormBlockRichText value) =>
        new("formBlock", (FormBlock)value);

    public static implicit operator FormComponent(
        Auth0.ManagementApi.FormWidgetAuth0VerifiableCredentials value
    ) => new("formWidget", (FormWidget)value);

    public static implicit operator FormComponent(
        Auth0.ManagementApi.FormWidgetGMapsAddress value
    ) => new("formWidget", (FormWidget)value);

    public static implicit operator FormComponent(Auth0.ManagementApi.FormWidgetRecaptcha value) =>
        new("formWidget", (FormWidget)value);

    public static implicit operator FormComponent(Auth0.ManagementApi.FormFieldBoolean value) =>
        new("formField", (FormField)value);

    public static implicit operator FormComponent(Auth0.ManagementApi.FormFieldCards value) =>
        new("formField", (FormField)value);

    public static implicit operator FormComponent(Auth0.ManagementApi.FormFieldChoice value) =>
        new("formField", (FormField)value);

    public static implicit operator FormComponent(Auth0.ManagementApi.FormFieldCustom value) =>
        new("formField", (FormField)value);

    public static implicit operator FormComponent(Auth0.ManagementApi.FormFieldDate value) =>
        new("formField", (FormField)value);

    public static implicit operator FormComponent(Auth0.ManagementApi.FormFieldDropdown value) =>
        new("formField", (FormField)value);

    public static implicit operator FormComponent(Auth0.ManagementApi.FormFieldEmail value) =>
        new("formField", (FormField)value);

    public static implicit operator FormComponent(Auth0.ManagementApi.FormFieldFile value) =>
        new("formField", (FormField)value);

    public static implicit operator FormComponent(Auth0.ManagementApi.FormFieldLegal value) =>
        new("formField", (FormField)value);

    public static implicit operator FormComponent(Auth0.ManagementApi.FormFieldNumber value) =>
        new("formField", (FormField)value);

    public static implicit operator FormComponent(Auth0.ManagementApi.FormFieldPassword value) =>
        new("formField", (FormField)value);

    public static implicit operator FormComponent(Auth0.ManagementApi.FormFieldPayment value) =>
        new("formField", (FormField)value);

    public static implicit operator FormComponent(Auth0.ManagementApi.FormFieldSocial value) =>
        new("formField", (FormField)value);

    public static implicit operator FormComponent(Auth0.ManagementApi.FormFieldTel value) =>
        new("formField", (FormField)value);

    public static implicit operator FormComponent(Auth0.ManagementApi.FormFieldText value) =>
        new("formField", (FormField)value);

    public static implicit operator FormComponent(Auth0.ManagementApi.FormFieldUrl value) =>
        new("formField", (FormField)value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FormComponent>
    {
        public override FormComponent? Read(
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
                    ("formBlock", typeof(Auth0.ManagementApi.FormBlock)),
                    ("formWidget", typeof(Auth0.ManagementApi.FormWidget)),
                    ("formField", typeof(Auth0.ManagementApi.FormField)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            FormComponent result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into FormComponent"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            FormComponent value,
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

        public override FormComponent ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            FormComponent result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FormComponent value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
