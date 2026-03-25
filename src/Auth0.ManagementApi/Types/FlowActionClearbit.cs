// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionClearbit.JsonConverter))]
[Serializable]
public class FlowActionClearbit
{
    private FlowActionClearbit(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionClearbitFindPerson value.
    /// </summary>
    public static FlowActionClearbit FromFlowActionClearbitFindPerson(
        Auth0.ManagementApi.FlowActionClearbitFindPerson value
    ) => new("flowActionClearbitFindPerson", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionClearbitFindCompany value.
    /// </summary>
    public static FlowActionClearbit FromFlowActionClearbitFindCompany(
        Auth0.ManagementApi.FlowActionClearbitFindCompany value
    ) => new("flowActionClearbitFindCompany", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionClearbitFindPerson"
    /// </summary>
    public bool IsFlowActionClearbitFindPerson() => Type == "flowActionClearbitFindPerson";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionClearbitFindCompany"
    /// </summary>
    public bool IsFlowActionClearbitFindCompany() => Type == "flowActionClearbitFindCompany";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionClearbitFindPerson"/> if <see cref="Type"/> is 'flowActionClearbitFindPerson', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionClearbitFindPerson'.</exception>
    public Auth0.ManagementApi.FlowActionClearbitFindPerson AsFlowActionClearbitFindPerson() =>
        IsFlowActionClearbitFindPerson()
            ? (Auth0.ManagementApi.FlowActionClearbitFindPerson)Value!
            : throw new ManagementException("Union type is not 'flowActionClearbitFindPerson'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionClearbitFindCompany"/> if <see cref="Type"/> is 'flowActionClearbitFindCompany', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionClearbitFindCompany'.</exception>
    public Auth0.ManagementApi.FlowActionClearbitFindCompany AsFlowActionClearbitFindCompany() =>
        IsFlowActionClearbitFindCompany()
            ? (Auth0.ManagementApi.FlowActionClearbitFindCompany)Value!
            : throw new ManagementException("Union type is not 'flowActionClearbitFindCompany'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionClearbitFindPerson"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionClearbitFindPerson(
        out Auth0.ManagementApi.FlowActionClearbitFindPerson? value
    )
    {
        if (Type == "flowActionClearbitFindPerson")
        {
            value = (Auth0.ManagementApi.FlowActionClearbitFindPerson)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionClearbitFindCompany"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionClearbitFindCompany(
        out Auth0.ManagementApi.FlowActionClearbitFindCompany? value
    )
    {
        if (Type == "flowActionClearbitFindCompany")
        {
            value = (Auth0.ManagementApi.FlowActionClearbitFindCompany)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.ManagementApi.FlowActionClearbitFindPerson, T> onFlowActionClearbitFindPerson,
        Func<Auth0.ManagementApi.FlowActionClearbitFindCompany, T> onFlowActionClearbitFindCompany
    )
    {
        return Type switch
        {
            "flowActionClearbitFindPerson" => onFlowActionClearbitFindPerson(
                AsFlowActionClearbitFindPerson()
            ),
            "flowActionClearbitFindCompany" => onFlowActionClearbitFindCompany(
                AsFlowActionClearbitFindCompany()
            ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.FlowActionClearbitFindPerson> onFlowActionClearbitFindPerson,
        global::System.Action<Auth0.ManagementApi.FlowActionClearbitFindCompany> onFlowActionClearbitFindCompany
    )
    {
        switch (Type)
        {
            case "flowActionClearbitFindPerson":
                onFlowActionClearbitFindPerson(AsFlowActionClearbitFindPerson());
                break;
            case "flowActionClearbitFindCompany":
                onFlowActionClearbitFindCompany(AsFlowActionClearbitFindCompany());
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
        if (obj is not FlowActionClearbit other)
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

    public static implicit operator FlowActionClearbit(
        Auth0.ManagementApi.FlowActionClearbitFindPerson value
    ) => new("flowActionClearbitFindPerson", value);

    public static implicit operator FlowActionClearbit(
        Auth0.ManagementApi.FlowActionClearbitFindCompany value
    ) => new("flowActionClearbitFindCompany", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FlowActionClearbit>
    {
        public override FlowActionClearbit? Read(
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
                        "flowActionClearbitFindPerson",
                        typeof(Auth0.ManagementApi.FlowActionClearbitFindPerson)
                    ),
                    (
                        "flowActionClearbitFindCompany",
                        typeof(Auth0.ManagementApi.FlowActionClearbitFindCompany)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            FlowActionClearbit result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into FlowActionClearbit"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionClearbit value,
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

        public override FlowActionClearbit ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            FlowActionClearbit result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionClearbit value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
