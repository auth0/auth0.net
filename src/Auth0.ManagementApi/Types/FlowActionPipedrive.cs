// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionPipedrive.JsonConverter))]
[Serializable]
public class FlowActionPipedrive
{
    private FlowActionPipedrive(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionPipedriveAddDeal value.
    /// </summary>
    public static FlowActionPipedrive FromFlowActionPipedriveAddDeal(
        Auth0.ManagementApi.FlowActionPipedriveAddDeal value
    ) => new("flowActionPipedriveAddDeal", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionPipedriveAddOrganization value.
    /// </summary>
    public static FlowActionPipedrive FromFlowActionPipedriveAddOrganization(
        Auth0.ManagementApi.FlowActionPipedriveAddOrganization value
    ) => new("flowActionPipedriveAddOrganization", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionPipedriveAddPerson value.
    /// </summary>
    public static FlowActionPipedrive FromFlowActionPipedriveAddPerson(
        Auth0.ManagementApi.FlowActionPipedriveAddPerson value
    ) => new("flowActionPipedriveAddPerson", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionPipedriveAddDeal"
    /// </summary>
    public bool IsFlowActionPipedriveAddDeal() => Type == "flowActionPipedriveAddDeal";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionPipedriveAddOrganization"
    /// </summary>
    public bool IsFlowActionPipedriveAddOrganization() =>
        Type == "flowActionPipedriveAddOrganization";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionPipedriveAddPerson"
    /// </summary>
    public bool IsFlowActionPipedriveAddPerson() => Type == "flowActionPipedriveAddPerson";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionPipedriveAddDeal"/> if <see cref="Type"/> is 'flowActionPipedriveAddDeal', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionPipedriveAddDeal'.</exception>
    public Auth0.ManagementApi.FlowActionPipedriveAddDeal AsFlowActionPipedriveAddDeal() =>
        IsFlowActionPipedriveAddDeal()
            ? (Auth0.ManagementApi.FlowActionPipedriveAddDeal)Value!
            : throw new ManagementException("Union type is not 'flowActionPipedriveAddDeal'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionPipedriveAddOrganization"/> if <see cref="Type"/> is 'flowActionPipedriveAddOrganization', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionPipedriveAddOrganization'.</exception>
    public Auth0.ManagementApi.FlowActionPipedriveAddOrganization AsFlowActionPipedriveAddOrganization() =>
        IsFlowActionPipedriveAddOrganization()
            ? (Auth0.ManagementApi.FlowActionPipedriveAddOrganization)Value!
            : throw new ManagementException(
                "Union type is not 'flowActionPipedriveAddOrganization'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionPipedriveAddPerson"/> if <see cref="Type"/> is 'flowActionPipedriveAddPerson', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionPipedriveAddPerson'.</exception>
    public Auth0.ManagementApi.FlowActionPipedriveAddPerson AsFlowActionPipedriveAddPerson() =>
        IsFlowActionPipedriveAddPerson()
            ? (Auth0.ManagementApi.FlowActionPipedriveAddPerson)Value!
            : throw new ManagementException("Union type is not 'flowActionPipedriveAddPerson'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionPipedriveAddDeal"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionPipedriveAddDeal(
        out Auth0.ManagementApi.FlowActionPipedriveAddDeal? value
    )
    {
        if (Type == "flowActionPipedriveAddDeal")
        {
            value = (Auth0.ManagementApi.FlowActionPipedriveAddDeal)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionPipedriveAddOrganization"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionPipedriveAddOrganization(
        out Auth0.ManagementApi.FlowActionPipedriveAddOrganization? value
    )
    {
        if (Type == "flowActionPipedriveAddOrganization")
        {
            value = (Auth0.ManagementApi.FlowActionPipedriveAddOrganization)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionPipedriveAddPerson"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionPipedriveAddPerson(
        out Auth0.ManagementApi.FlowActionPipedriveAddPerson? value
    )
    {
        if (Type == "flowActionPipedriveAddPerson")
        {
            value = (Auth0.ManagementApi.FlowActionPipedriveAddPerson)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.ManagementApi.FlowActionPipedriveAddDeal, T> onFlowActionPipedriveAddDeal,
        Func<
            Auth0.ManagementApi.FlowActionPipedriveAddOrganization,
            T
        > onFlowActionPipedriveAddOrganization,
        Func<Auth0.ManagementApi.FlowActionPipedriveAddPerson, T> onFlowActionPipedriveAddPerson
    )
    {
        return Type switch
        {
            "flowActionPipedriveAddDeal" => onFlowActionPipedriveAddDeal(
                AsFlowActionPipedriveAddDeal()
            ),
            "flowActionPipedriveAddOrganization" => onFlowActionPipedriveAddOrganization(
                AsFlowActionPipedriveAddOrganization()
            ),
            "flowActionPipedriveAddPerson" => onFlowActionPipedriveAddPerson(
                AsFlowActionPipedriveAddPerson()
            ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.FlowActionPipedriveAddDeal> onFlowActionPipedriveAddDeal,
        global::System.Action<Auth0.ManagementApi.FlowActionPipedriveAddOrganization> onFlowActionPipedriveAddOrganization,
        global::System.Action<Auth0.ManagementApi.FlowActionPipedriveAddPerson> onFlowActionPipedriveAddPerson
    )
    {
        switch (Type)
        {
            case "flowActionPipedriveAddDeal":
                onFlowActionPipedriveAddDeal(AsFlowActionPipedriveAddDeal());
                break;
            case "flowActionPipedriveAddOrganization":
                onFlowActionPipedriveAddOrganization(AsFlowActionPipedriveAddOrganization());
                break;
            case "flowActionPipedriveAddPerson":
                onFlowActionPipedriveAddPerson(AsFlowActionPipedriveAddPerson());
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
        if (obj is not FlowActionPipedrive other)
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

    public static implicit operator FlowActionPipedrive(
        Auth0.ManagementApi.FlowActionPipedriveAddDeal value
    ) => new("flowActionPipedriveAddDeal", value);

    public static implicit operator FlowActionPipedrive(
        Auth0.ManagementApi.FlowActionPipedriveAddOrganization value
    ) => new("flowActionPipedriveAddOrganization", value);

    public static implicit operator FlowActionPipedrive(
        Auth0.ManagementApi.FlowActionPipedriveAddPerson value
    ) => new("flowActionPipedriveAddPerson", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FlowActionPipedrive>
    {
        public override FlowActionPipedrive? Read(
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
                        "flowActionPipedriveAddDeal",
                        typeof(Auth0.ManagementApi.FlowActionPipedriveAddDeal)
                    ),
                    (
                        "flowActionPipedriveAddOrganization",
                        typeof(Auth0.ManagementApi.FlowActionPipedriveAddOrganization)
                    ),
                    (
                        "flowActionPipedriveAddPerson",
                        typeof(Auth0.ManagementApi.FlowActionPipedriveAddPerson)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            FlowActionPipedrive result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into FlowActionPipedrive"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionPipedrive value,
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

        public override FlowActionPipedrive ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            FlowActionPipedrive result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionPipedrive value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
