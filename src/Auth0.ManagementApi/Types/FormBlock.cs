// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FormBlock.JsonConverter))]
[Serializable]
public class FormBlock
{
    private FormBlock(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.FormBlockDivider value.
    /// </summary>
    public static FormBlock FromFormBlockDivider(Auth0.ManagementApi.FormBlockDivider value) =>
        new("formBlockDivider", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormBlockHtml value.
    /// </summary>
    public static FormBlock FromFormBlockHtml(Auth0.ManagementApi.FormBlockHtml value) =>
        new("formBlockHtml", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormBlockImage value.
    /// </summary>
    public static FormBlock FromFormBlockImage(Auth0.ManagementApi.FormBlockImage value) =>
        new("formBlockImage", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormBlockJumpButton value.
    /// </summary>
    public static FormBlock FromFormBlockJumpButton(
        Auth0.ManagementApi.FormBlockJumpButton value
    ) => new("formBlockJumpButton", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormBlockResendButton value.
    /// </summary>
    public static FormBlock FromFormBlockResendButton(
        Auth0.ManagementApi.FormBlockResendButton value
    ) => new("formBlockResendButton", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormBlockNextButton value.
    /// </summary>
    public static FormBlock FromFormBlockNextButton(
        Auth0.ManagementApi.FormBlockNextButton value
    ) => new("formBlockNextButton", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormBlockPreviousButton value.
    /// </summary>
    public static FormBlock FromFormBlockPreviousButton(
        Auth0.ManagementApi.FormBlockPreviousButton value
    ) => new("formBlockPreviousButton", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormBlockRichText value.
    /// </summary>
    public static FormBlock FromFormBlockRichText(Auth0.ManagementApi.FormBlockRichText value) =>
        new("formBlockRichText", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formBlockDivider"
    /// </summary>
    public bool IsFormBlockDivider() => Type == "formBlockDivider";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formBlockHtml"
    /// </summary>
    public bool IsFormBlockHtml() => Type == "formBlockHtml";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formBlockImage"
    /// </summary>
    public bool IsFormBlockImage() => Type == "formBlockImage";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formBlockJumpButton"
    /// </summary>
    public bool IsFormBlockJumpButton() => Type == "formBlockJumpButton";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formBlockResendButton"
    /// </summary>
    public bool IsFormBlockResendButton() => Type == "formBlockResendButton";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formBlockNextButton"
    /// </summary>
    public bool IsFormBlockNextButton() => Type == "formBlockNextButton";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formBlockPreviousButton"
    /// </summary>
    public bool IsFormBlockPreviousButton() => Type == "formBlockPreviousButton";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formBlockRichText"
    /// </summary>
    public bool IsFormBlockRichText() => Type == "formBlockRichText";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormBlockDivider"/> if <see cref="Type"/> is 'formBlockDivider', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formBlockDivider'.</exception>
    public Auth0.ManagementApi.FormBlockDivider AsFormBlockDivider() =>
        IsFormBlockDivider()
            ? (Auth0.ManagementApi.FormBlockDivider)Value!
            : throw new ManagementException("Union type is not 'formBlockDivider'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormBlockHtml"/> if <see cref="Type"/> is 'formBlockHtml', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formBlockHtml'.</exception>
    public Auth0.ManagementApi.FormBlockHtml AsFormBlockHtml() =>
        IsFormBlockHtml()
            ? (Auth0.ManagementApi.FormBlockHtml)Value!
            : throw new ManagementException("Union type is not 'formBlockHtml'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormBlockImage"/> if <see cref="Type"/> is 'formBlockImage', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formBlockImage'.</exception>
    public Auth0.ManagementApi.FormBlockImage AsFormBlockImage() =>
        IsFormBlockImage()
            ? (Auth0.ManagementApi.FormBlockImage)Value!
            : throw new ManagementException("Union type is not 'formBlockImage'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormBlockJumpButton"/> if <see cref="Type"/> is 'formBlockJumpButton', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formBlockJumpButton'.</exception>
    public Auth0.ManagementApi.FormBlockJumpButton AsFormBlockJumpButton() =>
        IsFormBlockJumpButton()
            ? (Auth0.ManagementApi.FormBlockJumpButton)Value!
            : throw new ManagementException("Union type is not 'formBlockJumpButton'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormBlockResendButton"/> if <see cref="Type"/> is 'formBlockResendButton', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formBlockResendButton'.</exception>
    public Auth0.ManagementApi.FormBlockResendButton AsFormBlockResendButton() =>
        IsFormBlockResendButton()
            ? (Auth0.ManagementApi.FormBlockResendButton)Value!
            : throw new ManagementException("Union type is not 'formBlockResendButton'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormBlockNextButton"/> if <see cref="Type"/> is 'formBlockNextButton', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formBlockNextButton'.</exception>
    public Auth0.ManagementApi.FormBlockNextButton AsFormBlockNextButton() =>
        IsFormBlockNextButton()
            ? (Auth0.ManagementApi.FormBlockNextButton)Value!
            : throw new ManagementException("Union type is not 'formBlockNextButton'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormBlockPreviousButton"/> if <see cref="Type"/> is 'formBlockPreviousButton', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formBlockPreviousButton'.</exception>
    public Auth0.ManagementApi.FormBlockPreviousButton AsFormBlockPreviousButton() =>
        IsFormBlockPreviousButton()
            ? (Auth0.ManagementApi.FormBlockPreviousButton)Value!
            : throw new ManagementException("Union type is not 'formBlockPreviousButton'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormBlockRichText"/> if <see cref="Type"/> is 'formBlockRichText', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formBlockRichText'.</exception>
    public Auth0.ManagementApi.FormBlockRichText AsFormBlockRichText() =>
        IsFormBlockRichText()
            ? (Auth0.ManagementApi.FormBlockRichText)Value!
            : throw new ManagementException("Union type is not 'formBlockRichText'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormBlockDivider"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormBlockDivider(out Auth0.ManagementApi.FormBlockDivider? value)
    {
        if (Type == "formBlockDivider")
        {
            value = (Auth0.ManagementApi.FormBlockDivider)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormBlockHtml"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormBlockHtml(out Auth0.ManagementApi.FormBlockHtml? value)
    {
        if (Type == "formBlockHtml")
        {
            value = (Auth0.ManagementApi.FormBlockHtml)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormBlockImage"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormBlockImage(out Auth0.ManagementApi.FormBlockImage? value)
    {
        if (Type == "formBlockImage")
        {
            value = (Auth0.ManagementApi.FormBlockImage)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormBlockJumpButton"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormBlockJumpButton(out Auth0.ManagementApi.FormBlockJumpButton? value)
    {
        if (Type == "formBlockJumpButton")
        {
            value = (Auth0.ManagementApi.FormBlockJumpButton)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormBlockResendButton"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormBlockResendButton(out Auth0.ManagementApi.FormBlockResendButton? value)
    {
        if (Type == "formBlockResendButton")
        {
            value = (Auth0.ManagementApi.FormBlockResendButton)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormBlockNextButton"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormBlockNextButton(out Auth0.ManagementApi.FormBlockNextButton? value)
    {
        if (Type == "formBlockNextButton")
        {
            value = (Auth0.ManagementApi.FormBlockNextButton)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormBlockPreviousButton"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormBlockPreviousButton(
        out Auth0.ManagementApi.FormBlockPreviousButton? value
    )
    {
        if (Type == "formBlockPreviousButton")
        {
            value = (Auth0.ManagementApi.FormBlockPreviousButton)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormBlockRichText"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormBlockRichText(out Auth0.ManagementApi.FormBlockRichText? value)
    {
        if (Type == "formBlockRichText")
        {
            value = (Auth0.ManagementApi.FormBlockRichText)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.ManagementApi.FormBlockDivider, T> onFormBlockDivider,
        Func<Auth0.ManagementApi.FormBlockHtml, T> onFormBlockHtml,
        Func<Auth0.ManagementApi.FormBlockImage, T> onFormBlockImage,
        Func<Auth0.ManagementApi.FormBlockJumpButton, T> onFormBlockJumpButton,
        Func<Auth0.ManagementApi.FormBlockResendButton, T> onFormBlockResendButton,
        Func<Auth0.ManagementApi.FormBlockNextButton, T> onFormBlockNextButton,
        Func<Auth0.ManagementApi.FormBlockPreviousButton, T> onFormBlockPreviousButton,
        Func<Auth0.ManagementApi.FormBlockRichText, T> onFormBlockRichText
    )
    {
        return Type switch
        {
            "formBlockDivider" => onFormBlockDivider(AsFormBlockDivider()),
            "formBlockHtml" => onFormBlockHtml(AsFormBlockHtml()),
            "formBlockImage" => onFormBlockImage(AsFormBlockImage()),
            "formBlockJumpButton" => onFormBlockJumpButton(AsFormBlockJumpButton()),
            "formBlockResendButton" => onFormBlockResendButton(AsFormBlockResendButton()),
            "formBlockNextButton" => onFormBlockNextButton(AsFormBlockNextButton()),
            "formBlockPreviousButton" => onFormBlockPreviousButton(AsFormBlockPreviousButton()),
            "formBlockRichText" => onFormBlockRichText(AsFormBlockRichText()),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.FormBlockDivider> onFormBlockDivider,
        global::System.Action<Auth0.ManagementApi.FormBlockHtml> onFormBlockHtml,
        global::System.Action<Auth0.ManagementApi.FormBlockImage> onFormBlockImage,
        global::System.Action<Auth0.ManagementApi.FormBlockJumpButton> onFormBlockJumpButton,
        global::System.Action<Auth0.ManagementApi.FormBlockResendButton> onFormBlockResendButton,
        global::System.Action<Auth0.ManagementApi.FormBlockNextButton> onFormBlockNextButton,
        global::System.Action<Auth0.ManagementApi.FormBlockPreviousButton> onFormBlockPreviousButton,
        global::System.Action<Auth0.ManagementApi.FormBlockRichText> onFormBlockRichText
    )
    {
        switch (Type)
        {
            case "formBlockDivider":
                onFormBlockDivider(AsFormBlockDivider());
                break;
            case "formBlockHtml":
                onFormBlockHtml(AsFormBlockHtml());
                break;
            case "formBlockImage":
                onFormBlockImage(AsFormBlockImage());
                break;
            case "formBlockJumpButton":
                onFormBlockJumpButton(AsFormBlockJumpButton());
                break;
            case "formBlockResendButton":
                onFormBlockResendButton(AsFormBlockResendButton());
                break;
            case "formBlockNextButton":
                onFormBlockNextButton(AsFormBlockNextButton());
                break;
            case "formBlockPreviousButton":
                onFormBlockPreviousButton(AsFormBlockPreviousButton());
                break;
            case "formBlockRichText":
                onFormBlockRichText(AsFormBlockRichText());
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
        if (obj is not FormBlock other)
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

    public static implicit operator FormBlock(Auth0.ManagementApi.FormBlockDivider value) =>
        new("formBlockDivider", value);

    public static implicit operator FormBlock(Auth0.ManagementApi.FormBlockHtml value) =>
        new("formBlockHtml", value);

    public static implicit operator FormBlock(Auth0.ManagementApi.FormBlockImage value) =>
        new("formBlockImage", value);

    public static implicit operator FormBlock(Auth0.ManagementApi.FormBlockJumpButton value) =>
        new("formBlockJumpButton", value);

    public static implicit operator FormBlock(Auth0.ManagementApi.FormBlockResendButton value) =>
        new("formBlockResendButton", value);

    public static implicit operator FormBlock(Auth0.ManagementApi.FormBlockNextButton value) =>
        new("formBlockNextButton", value);

    public static implicit operator FormBlock(Auth0.ManagementApi.FormBlockPreviousButton value) =>
        new("formBlockPreviousButton", value);

    public static implicit operator FormBlock(Auth0.ManagementApi.FormBlockRichText value) =>
        new("formBlockRichText", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FormBlock>
    {
        public override FormBlock? Read(
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
                    ("formBlockDivider", typeof(Auth0.ManagementApi.FormBlockDivider)),
                    ("formBlockHtml", typeof(Auth0.ManagementApi.FormBlockHtml)),
                    ("formBlockImage", typeof(Auth0.ManagementApi.FormBlockImage)),
                    ("formBlockJumpButton", typeof(Auth0.ManagementApi.FormBlockJumpButton)),
                    ("formBlockResendButton", typeof(Auth0.ManagementApi.FormBlockResendButton)),
                    ("formBlockNextButton", typeof(Auth0.ManagementApi.FormBlockNextButton)),
                    (
                        "formBlockPreviousButton",
                        typeof(Auth0.ManagementApi.FormBlockPreviousButton)
                    ),
                    ("formBlockRichText", typeof(Auth0.ManagementApi.FormBlockRichText)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            FormBlock result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into FormBlock"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            FormBlock value,
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
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override FormBlock ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            FormBlock result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FormBlock value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
