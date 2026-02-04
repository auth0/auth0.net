// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FormNode.JsonConverter))]
[Serializable]
public class FormNode
{
    private FormNode(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.FormFlow value.
    /// </summary>
    public static FormNode FromFormFlow(Auth0.ManagementApi.FormFlow value) =>
        new("formFlow", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormRouter value.
    /// </summary>
    public static FormNode FromFormRouter(Auth0.ManagementApi.FormRouter value) =>
        new("formRouter", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormStep value.
    /// </summary>
    public static FormNode FromFormStep(Auth0.ManagementApi.FormStep value) =>
        new("formStep", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formFlow"
    /// </summary>
    public bool IsFormFlow() => Type == "formFlow";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formRouter"
    /// </summary>
    public bool IsFormRouter() => Type == "formRouter";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formStep"
    /// </summary>
    public bool IsFormStep() => Type == "formStep";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormFlow"/> if <see cref="Type"/> is 'formFlow', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formFlow'.</exception>
    public Auth0.ManagementApi.FormFlow AsFormFlow() =>
        IsFormFlow()
            ? (Auth0.ManagementApi.FormFlow)Value!
            : throw new ManagementException("Union type is not 'formFlow'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormRouter"/> if <see cref="Type"/> is 'formRouter', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formRouter'.</exception>
    public Auth0.ManagementApi.FormRouter AsFormRouter() =>
        IsFormRouter()
            ? (Auth0.ManagementApi.FormRouter)Value!
            : throw new ManagementException("Union type is not 'formRouter'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormStep"/> if <see cref="Type"/> is 'formStep', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formStep'.</exception>
    public Auth0.ManagementApi.FormStep AsFormStep() =>
        IsFormStep()
            ? (Auth0.ManagementApi.FormStep)Value!
            : throw new ManagementException("Union type is not 'formStep'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormFlow"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormFlow(out Auth0.ManagementApi.FormFlow? value)
    {
        if (Type == "formFlow")
        {
            value = (Auth0.ManagementApi.FormFlow)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormRouter"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormRouter(out Auth0.ManagementApi.FormRouter? value)
    {
        if (Type == "formRouter")
        {
            value = (Auth0.ManagementApi.FormRouter)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormStep"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormStep(out Auth0.ManagementApi.FormStep? value)
    {
        if (Type == "formStep")
        {
            value = (Auth0.ManagementApi.FormStep)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.ManagementApi.FormFlow, T> onFormFlow,
        Func<Auth0.ManagementApi.FormRouter, T> onFormRouter,
        Func<Auth0.ManagementApi.FormStep, T> onFormStep
    )
    {
        return Type switch
        {
            "formFlow" => onFormFlow(AsFormFlow()),
            "formRouter" => onFormRouter(AsFormRouter()),
            "formStep" => onFormStep(AsFormStep()),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.FormFlow> onFormFlow,
        System.Action<Auth0.ManagementApi.FormRouter> onFormRouter,
        System.Action<Auth0.ManagementApi.FormStep> onFormStep
    )
    {
        switch (Type)
        {
            case "formFlow":
                onFormFlow(AsFormFlow());
                break;
            case "formRouter":
                onFormRouter(AsFormRouter());
                break;
            case "formStep":
                onFormStep(AsFormStep());
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
        if (obj is not FormNode other)
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

    public static implicit operator FormNode(Auth0.ManagementApi.FormFlow value) =>
        new("formFlow", value);

    public static implicit operator FormNode(Auth0.ManagementApi.FormRouter value) =>
        new("formRouter", value);

    public static implicit operator FormNode(Auth0.ManagementApi.FormStep value) =>
        new("formStep", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FormNode>
    {
        public override FormNode? Read(
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
                    ("formFlow", typeof(Auth0.ManagementApi.FormFlow)),
                    ("formRouter", typeof(Auth0.ManagementApi.FormRouter)),
                    ("formStep", typeof(Auth0.ManagementApi.FormStep)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            FormNode result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into FormNode"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            FormNode value,
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

        public override FormNode ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            FormNode result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FormNode value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
