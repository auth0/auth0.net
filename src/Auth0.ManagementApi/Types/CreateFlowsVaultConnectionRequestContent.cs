// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CreateFlowsVaultConnectionRequestContent.JsonConverter))]
[Serializable]
public class CreateFlowsVaultConnectionRequestContent
{
    private CreateFlowsVaultConnectionRequestContent(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaign value.
    /// </summary>
    public static CreateFlowsVaultConnectionRequestContent FromCreateFlowsVaultConnectionActivecampaign(
        Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaign value
    ) => new("createFlowsVaultConnectionActivecampaign", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionAirtable value.
    /// </summary>
    public static CreateFlowsVaultConnectionRequestContent FromCreateFlowsVaultConnectionAirtable(
        Auth0.ManagementApi.CreateFlowsVaultConnectionAirtable value
    ) => new("createFlowsVaultConnectionAirtable", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0 value.
    /// </summary>
    public static CreateFlowsVaultConnectionRequestContent FromCreateFlowsVaultConnectionAuth0(
        Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0 value
    ) => new("createFlowsVaultConnectionAuth0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionBigquery value.
    /// </summary>
    public static CreateFlowsVaultConnectionRequestContent FromCreateFlowsVaultConnectionBigquery(
        Auth0.ManagementApi.CreateFlowsVaultConnectionBigquery value
    ) => new("createFlowsVaultConnectionBigquery", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionClearbit value.
    /// </summary>
    public static CreateFlowsVaultConnectionRequestContent FromCreateFlowsVaultConnectionClearbit(
        Auth0.ManagementApi.CreateFlowsVaultConnectionClearbit value
    ) => new("createFlowsVaultConnectionClearbit", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionDocusign value.
    /// </summary>
    public static CreateFlowsVaultConnectionRequestContent FromCreateFlowsVaultConnectionDocusign(
        Auth0.ManagementApi.CreateFlowsVaultConnectionDocusign value
    ) => new("createFlowsVaultConnectionDocusign", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheets value.
    /// </summary>
    public static CreateFlowsVaultConnectionRequestContent FromCreateFlowsVaultConnectionGoogleSheets(
        Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheets value
    ) => new("createFlowsVaultConnectionGoogleSheets", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionHttp value.
    /// </summary>
    public static CreateFlowsVaultConnectionRequestContent FromCreateFlowsVaultConnectionHttp(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHttp value
    ) => new("createFlowsVaultConnectionHttp", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionHubspot value.
    /// </summary>
    public static CreateFlowsVaultConnectionRequestContent FromCreateFlowsVaultConnectionHubspot(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHubspot value
    ) => new("createFlowsVaultConnectionHubspot", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionJwt value.
    /// </summary>
    public static CreateFlowsVaultConnectionRequestContent FromCreateFlowsVaultConnectionJwt(
        Auth0.ManagementApi.CreateFlowsVaultConnectionJwt value
    ) => new("createFlowsVaultConnectionJwt", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimp value.
    /// </summary>
    public static CreateFlowsVaultConnectionRequestContent FromCreateFlowsVaultConnectionMailchimp(
        Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimp value
    ) => new("createFlowsVaultConnectionMailchimp", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionMailjet value.
    /// </summary>
    public static CreateFlowsVaultConnectionRequestContent FromCreateFlowsVaultConnectionMailjet(
        Auth0.ManagementApi.CreateFlowsVaultConnectionMailjet value
    ) => new("createFlowsVaultConnectionMailjet", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionPipedrive value.
    /// </summary>
    public static CreateFlowsVaultConnectionRequestContent FromCreateFlowsVaultConnectionPipedrive(
        Auth0.ManagementApi.CreateFlowsVaultConnectionPipedrive value
    ) => new("createFlowsVaultConnectionPipedrive", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionSalesforce value.
    /// </summary>
    public static CreateFlowsVaultConnectionRequestContent FromCreateFlowsVaultConnectionSalesforce(
        Auth0.ManagementApi.CreateFlowsVaultConnectionSalesforce value
    ) => new("createFlowsVaultConnectionSalesforce", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionSendgrid value.
    /// </summary>
    public static CreateFlowsVaultConnectionRequestContent FromCreateFlowsVaultConnectionSendgrid(
        Auth0.ManagementApi.CreateFlowsVaultConnectionSendgrid value
    ) => new("createFlowsVaultConnectionSendgrid", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionSlack value.
    /// </summary>
    public static CreateFlowsVaultConnectionRequestContent FromCreateFlowsVaultConnectionSlack(
        Auth0.ManagementApi.CreateFlowsVaultConnectionSlack value
    ) => new("createFlowsVaultConnectionSlack", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionStripe value.
    /// </summary>
    public static CreateFlowsVaultConnectionRequestContent FromCreateFlowsVaultConnectionStripe(
        Auth0.ManagementApi.CreateFlowsVaultConnectionStripe value
    ) => new("createFlowsVaultConnectionStripe", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionTelegram value.
    /// </summary>
    public static CreateFlowsVaultConnectionRequestContent FromCreateFlowsVaultConnectionTelegram(
        Auth0.ManagementApi.CreateFlowsVaultConnectionTelegram value
    ) => new("createFlowsVaultConnectionTelegram", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionTwilio value.
    /// </summary>
    public static CreateFlowsVaultConnectionRequestContent FromCreateFlowsVaultConnectionTwilio(
        Auth0.ManagementApi.CreateFlowsVaultConnectionTwilio value
    ) => new("createFlowsVaultConnectionTwilio", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsapp value.
    /// </summary>
    public static CreateFlowsVaultConnectionRequestContent FromCreateFlowsVaultConnectionWhatsapp(
        Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsapp value
    ) => new("createFlowsVaultConnectionWhatsapp", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionZapier value.
    /// </summary>
    public static CreateFlowsVaultConnectionRequestContent FromCreateFlowsVaultConnectionZapier(
        Auth0.ManagementApi.CreateFlowsVaultConnectionZapier value
    ) => new("createFlowsVaultConnectionZapier", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionActivecampaign"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionActivecampaign() =>
        Type == "createFlowsVaultConnectionActivecampaign";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionAirtable"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionAirtable() =>
        Type == "createFlowsVaultConnectionAirtable";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionAuth0"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionAuth0() => Type == "createFlowsVaultConnectionAuth0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionBigquery"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionBigquery() =>
        Type == "createFlowsVaultConnectionBigquery";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionClearbit"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionClearbit() =>
        Type == "createFlowsVaultConnectionClearbit";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionDocusign"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionDocusign() =>
        Type == "createFlowsVaultConnectionDocusign";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionGoogleSheets"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionGoogleSheets() =>
        Type == "createFlowsVaultConnectionGoogleSheets";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionHttp"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionHttp() => Type == "createFlowsVaultConnectionHttp";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionHubspot"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionHubspot() =>
        Type == "createFlowsVaultConnectionHubspot";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionJwt"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionJwt() => Type == "createFlowsVaultConnectionJwt";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionMailchimp"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionMailchimp() =>
        Type == "createFlowsVaultConnectionMailchimp";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionMailjet"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionMailjet() =>
        Type == "createFlowsVaultConnectionMailjet";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionPipedrive"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionPipedrive() =>
        Type == "createFlowsVaultConnectionPipedrive";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionSalesforce"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionSalesforce() =>
        Type == "createFlowsVaultConnectionSalesforce";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionSendgrid"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionSendgrid() =>
        Type == "createFlowsVaultConnectionSendgrid";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionSlack"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionSlack() => Type == "createFlowsVaultConnectionSlack";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionStripe"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionStripe() => Type == "createFlowsVaultConnectionStripe";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionTelegram"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionTelegram() =>
        Type == "createFlowsVaultConnectionTelegram";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionTwilio"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionTwilio() => Type == "createFlowsVaultConnectionTwilio";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionWhatsapp"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionWhatsapp() =>
        Type == "createFlowsVaultConnectionWhatsapp";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionZapier"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionZapier() => Type == "createFlowsVaultConnectionZapier";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaign"/> if <see cref="Type"/> is 'createFlowsVaultConnectionActivecampaign', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionActivecampaign'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaign AsCreateFlowsVaultConnectionActivecampaign() =>
        IsCreateFlowsVaultConnectionActivecampaign()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaign)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionActivecampaign'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionAirtable"/> if <see cref="Type"/> is 'createFlowsVaultConnectionAirtable', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionAirtable'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionAirtable AsCreateFlowsVaultConnectionAirtable() =>
        IsCreateFlowsVaultConnectionAirtable()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionAirtable)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionAirtable'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0"/> if <see cref="Type"/> is 'createFlowsVaultConnectionAuth0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionAuth0'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0 AsCreateFlowsVaultConnectionAuth0() =>
        IsCreateFlowsVaultConnectionAuth0()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0)Value!
            : throw new ManagementException("Union type is not 'createFlowsVaultConnectionAuth0'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionBigquery"/> if <see cref="Type"/> is 'createFlowsVaultConnectionBigquery', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionBigquery'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionBigquery AsCreateFlowsVaultConnectionBigquery() =>
        IsCreateFlowsVaultConnectionBigquery()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionBigquery)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionBigquery'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionClearbit"/> if <see cref="Type"/> is 'createFlowsVaultConnectionClearbit', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionClearbit'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionClearbit AsCreateFlowsVaultConnectionClearbit() =>
        IsCreateFlowsVaultConnectionClearbit()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionClearbit)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionClearbit'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionDocusign"/> if <see cref="Type"/> is 'createFlowsVaultConnectionDocusign', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionDocusign'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionDocusign AsCreateFlowsVaultConnectionDocusign() =>
        IsCreateFlowsVaultConnectionDocusign()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionDocusign)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionDocusign'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheets"/> if <see cref="Type"/> is 'createFlowsVaultConnectionGoogleSheets', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionGoogleSheets'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheets AsCreateFlowsVaultConnectionGoogleSheets() =>
        IsCreateFlowsVaultConnectionGoogleSheets()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheets)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionGoogleSheets'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionHttp"/> if <see cref="Type"/> is 'createFlowsVaultConnectionHttp', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionHttp'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionHttp AsCreateFlowsVaultConnectionHttp() =>
        IsCreateFlowsVaultConnectionHttp()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionHttp)Value!
            : throw new ManagementException("Union type is not 'createFlowsVaultConnectionHttp'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionHubspot"/> if <see cref="Type"/> is 'createFlowsVaultConnectionHubspot', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionHubspot'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionHubspot AsCreateFlowsVaultConnectionHubspot() =>
        IsCreateFlowsVaultConnectionHubspot()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionHubspot)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionHubspot'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionJwt"/> if <see cref="Type"/> is 'createFlowsVaultConnectionJwt', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionJwt'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionJwt AsCreateFlowsVaultConnectionJwt() =>
        IsCreateFlowsVaultConnectionJwt()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionJwt)Value!
            : throw new ManagementException("Union type is not 'createFlowsVaultConnectionJwt'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimp"/> if <see cref="Type"/> is 'createFlowsVaultConnectionMailchimp', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionMailchimp'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimp AsCreateFlowsVaultConnectionMailchimp() =>
        IsCreateFlowsVaultConnectionMailchimp()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimp)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionMailchimp'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionMailjet"/> if <see cref="Type"/> is 'createFlowsVaultConnectionMailjet', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionMailjet'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionMailjet AsCreateFlowsVaultConnectionMailjet() =>
        IsCreateFlowsVaultConnectionMailjet()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionMailjet)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionMailjet'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionPipedrive"/> if <see cref="Type"/> is 'createFlowsVaultConnectionPipedrive', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionPipedrive'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionPipedrive AsCreateFlowsVaultConnectionPipedrive() =>
        IsCreateFlowsVaultConnectionPipedrive()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionPipedrive)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionPipedrive'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionSalesforce"/> if <see cref="Type"/> is 'createFlowsVaultConnectionSalesforce', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionSalesforce'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionSalesforce AsCreateFlowsVaultConnectionSalesforce() =>
        IsCreateFlowsVaultConnectionSalesforce()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionSalesforce)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionSalesforce'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionSendgrid"/> if <see cref="Type"/> is 'createFlowsVaultConnectionSendgrid', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionSendgrid'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionSendgrid AsCreateFlowsVaultConnectionSendgrid() =>
        IsCreateFlowsVaultConnectionSendgrid()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionSendgrid)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionSendgrid'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionSlack"/> if <see cref="Type"/> is 'createFlowsVaultConnectionSlack', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionSlack'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionSlack AsCreateFlowsVaultConnectionSlack() =>
        IsCreateFlowsVaultConnectionSlack()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionSlack)Value!
            : throw new ManagementException("Union type is not 'createFlowsVaultConnectionSlack'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionStripe"/> if <see cref="Type"/> is 'createFlowsVaultConnectionStripe', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionStripe'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionStripe AsCreateFlowsVaultConnectionStripe() =>
        IsCreateFlowsVaultConnectionStripe()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionStripe)Value!
            : throw new ManagementException("Union type is not 'createFlowsVaultConnectionStripe'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionTelegram"/> if <see cref="Type"/> is 'createFlowsVaultConnectionTelegram', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionTelegram'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionTelegram AsCreateFlowsVaultConnectionTelegram() =>
        IsCreateFlowsVaultConnectionTelegram()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionTelegram)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionTelegram'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionTwilio"/> if <see cref="Type"/> is 'createFlowsVaultConnectionTwilio', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionTwilio'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionTwilio AsCreateFlowsVaultConnectionTwilio() =>
        IsCreateFlowsVaultConnectionTwilio()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionTwilio)Value!
            : throw new ManagementException("Union type is not 'createFlowsVaultConnectionTwilio'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsapp"/> if <see cref="Type"/> is 'createFlowsVaultConnectionWhatsapp', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionWhatsapp'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsapp AsCreateFlowsVaultConnectionWhatsapp() =>
        IsCreateFlowsVaultConnectionWhatsapp()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsapp)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionWhatsapp'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionZapier"/> if <see cref="Type"/> is 'createFlowsVaultConnectionZapier', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionZapier'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionZapier AsCreateFlowsVaultConnectionZapier() =>
        IsCreateFlowsVaultConnectionZapier()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionZapier)Value!
            : throw new ManagementException("Union type is not 'createFlowsVaultConnectionZapier'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaign"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionActivecampaign(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaign? value
    )
    {
        if (Type == "createFlowsVaultConnectionActivecampaign")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaign)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionAirtable"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionAirtable(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionAirtable? value
    )
    {
        if (Type == "createFlowsVaultConnectionAirtable")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionAirtable)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionAuth0(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0? value
    )
    {
        if (Type == "createFlowsVaultConnectionAuth0")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionBigquery"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionBigquery(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionBigquery? value
    )
    {
        if (Type == "createFlowsVaultConnectionBigquery")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionBigquery)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionClearbit"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionClearbit(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionClearbit? value
    )
    {
        if (Type == "createFlowsVaultConnectionClearbit")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionClearbit)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionDocusign"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionDocusign(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionDocusign? value
    )
    {
        if (Type == "createFlowsVaultConnectionDocusign")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionDocusign)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheets"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionGoogleSheets(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheets? value
    )
    {
        if (Type == "createFlowsVaultConnectionGoogleSheets")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheets)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionHttp"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionHttp(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionHttp? value
    )
    {
        if (Type == "createFlowsVaultConnectionHttp")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionHttp)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionHubspot"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionHubspot(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionHubspot? value
    )
    {
        if (Type == "createFlowsVaultConnectionHubspot")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionHubspot)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionJwt"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionJwt(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionJwt? value
    )
    {
        if (Type == "createFlowsVaultConnectionJwt")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionJwt)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimp"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionMailchimp(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimp? value
    )
    {
        if (Type == "createFlowsVaultConnectionMailchimp")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimp)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionMailjet"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionMailjet(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionMailjet? value
    )
    {
        if (Type == "createFlowsVaultConnectionMailjet")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionMailjet)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionPipedrive"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionPipedrive(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionPipedrive? value
    )
    {
        if (Type == "createFlowsVaultConnectionPipedrive")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionPipedrive)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionSalesforce"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionSalesforce(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionSalesforce? value
    )
    {
        if (Type == "createFlowsVaultConnectionSalesforce")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionSalesforce)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionSendgrid"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionSendgrid(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionSendgrid? value
    )
    {
        if (Type == "createFlowsVaultConnectionSendgrid")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionSendgrid)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionSlack"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionSlack(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionSlack? value
    )
    {
        if (Type == "createFlowsVaultConnectionSlack")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionSlack)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionStripe"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionStripe(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionStripe? value
    )
    {
        if (Type == "createFlowsVaultConnectionStripe")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionStripe)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionTelegram"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionTelegram(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionTelegram? value
    )
    {
        if (Type == "createFlowsVaultConnectionTelegram")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionTelegram)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionTwilio"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionTwilio(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionTwilio? value
    )
    {
        if (Type == "createFlowsVaultConnectionTwilio")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionTwilio)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsapp"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionWhatsapp(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsapp? value
    )
    {
        if (Type == "createFlowsVaultConnectionWhatsapp")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsapp)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionZapier"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionZapier(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionZapier? value
    )
    {
        if (Type == "createFlowsVaultConnectionZapier")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionZapier)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaign,
            T
        > onCreateFlowsVaultConnectionActivecampaign,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionAirtable,
            T
        > onCreateFlowsVaultConnectionAirtable,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0,
            T
        > onCreateFlowsVaultConnectionAuth0,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionBigquery,
            T
        > onCreateFlowsVaultConnectionBigquery,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionClearbit,
            T
        > onCreateFlowsVaultConnectionClearbit,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionDocusign,
            T
        > onCreateFlowsVaultConnectionDocusign,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheets,
            T
        > onCreateFlowsVaultConnectionGoogleSheets,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionHttp,
            T
        > onCreateFlowsVaultConnectionHttp,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionHubspot,
            T
        > onCreateFlowsVaultConnectionHubspot,
        Func<Auth0.ManagementApi.CreateFlowsVaultConnectionJwt, T> onCreateFlowsVaultConnectionJwt,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimp,
            T
        > onCreateFlowsVaultConnectionMailchimp,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionMailjet,
            T
        > onCreateFlowsVaultConnectionMailjet,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionPipedrive,
            T
        > onCreateFlowsVaultConnectionPipedrive,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionSalesforce,
            T
        > onCreateFlowsVaultConnectionSalesforce,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionSendgrid,
            T
        > onCreateFlowsVaultConnectionSendgrid,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionSlack,
            T
        > onCreateFlowsVaultConnectionSlack,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionStripe,
            T
        > onCreateFlowsVaultConnectionStripe,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionTelegram,
            T
        > onCreateFlowsVaultConnectionTelegram,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionTwilio,
            T
        > onCreateFlowsVaultConnectionTwilio,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsapp,
            T
        > onCreateFlowsVaultConnectionWhatsapp,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionZapier,
            T
        > onCreateFlowsVaultConnectionZapier
    )
    {
        return Type switch
        {
            "createFlowsVaultConnectionActivecampaign" =>
                onCreateFlowsVaultConnectionActivecampaign(
                    AsCreateFlowsVaultConnectionActivecampaign()
                ),
            "createFlowsVaultConnectionAirtable" => onCreateFlowsVaultConnectionAirtable(
                AsCreateFlowsVaultConnectionAirtable()
            ),
            "createFlowsVaultConnectionAuth0" => onCreateFlowsVaultConnectionAuth0(
                AsCreateFlowsVaultConnectionAuth0()
            ),
            "createFlowsVaultConnectionBigquery" => onCreateFlowsVaultConnectionBigquery(
                AsCreateFlowsVaultConnectionBigquery()
            ),
            "createFlowsVaultConnectionClearbit" => onCreateFlowsVaultConnectionClearbit(
                AsCreateFlowsVaultConnectionClearbit()
            ),
            "createFlowsVaultConnectionDocusign" => onCreateFlowsVaultConnectionDocusign(
                AsCreateFlowsVaultConnectionDocusign()
            ),
            "createFlowsVaultConnectionGoogleSheets" => onCreateFlowsVaultConnectionGoogleSheets(
                AsCreateFlowsVaultConnectionGoogleSheets()
            ),
            "createFlowsVaultConnectionHttp" => onCreateFlowsVaultConnectionHttp(
                AsCreateFlowsVaultConnectionHttp()
            ),
            "createFlowsVaultConnectionHubspot" => onCreateFlowsVaultConnectionHubspot(
                AsCreateFlowsVaultConnectionHubspot()
            ),
            "createFlowsVaultConnectionJwt" => onCreateFlowsVaultConnectionJwt(
                AsCreateFlowsVaultConnectionJwt()
            ),
            "createFlowsVaultConnectionMailchimp" => onCreateFlowsVaultConnectionMailchimp(
                AsCreateFlowsVaultConnectionMailchimp()
            ),
            "createFlowsVaultConnectionMailjet" => onCreateFlowsVaultConnectionMailjet(
                AsCreateFlowsVaultConnectionMailjet()
            ),
            "createFlowsVaultConnectionPipedrive" => onCreateFlowsVaultConnectionPipedrive(
                AsCreateFlowsVaultConnectionPipedrive()
            ),
            "createFlowsVaultConnectionSalesforce" => onCreateFlowsVaultConnectionSalesforce(
                AsCreateFlowsVaultConnectionSalesforce()
            ),
            "createFlowsVaultConnectionSendgrid" => onCreateFlowsVaultConnectionSendgrid(
                AsCreateFlowsVaultConnectionSendgrid()
            ),
            "createFlowsVaultConnectionSlack" => onCreateFlowsVaultConnectionSlack(
                AsCreateFlowsVaultConnectionSlack()
            ),
            "createFlowsVaultConnectionStripe" => onCreateFlowsVaultConnectionStripe(
                AsCreateFlowsVaultConnectionStripe()
            ),
            "createFlowsVaultConnectionTelegram" => onCreateFlowsVaultConnectionTelegram(
                AsCreateFlowsVaultConnectionTelegram()
            ),
            "createFlowsVaultConnectionTwilio" => onCreateFlowsVaultConnectionTwilio(
                AsCreateFlowsVaultConnectionTwilio()
            ),
            "createFlowsVaultConnectionWhatsapp" => onCreateFlowsVaultConnectionWhatsapp(
                AsCreateFlowsVaultConnectionWhatsapp()
            ),
            "createFlowsVaultConnectionZapier" => onCreateFlowsVaultConnectionZapier(
                AsCreateFlowsVaultConnectionZapier()
            ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaign> onCreateFlowsVaultConnectionActivecampaign,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionAirtable> onCreateFlowsVaultConnectionAirtable,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0> onCreateFlowsVaultConnectionAuth0,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionBigquery> onCreateFlowsVaultConnectionBigquery,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionClearbit> onCreateFlowsVaultConnectionClearbit,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionDocusign> onCreateFlowsVaultConnectionDocusign,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheets> onCreateFlowsVaultConnectionGoogleSheets,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionHttp> onCreateFlowsVaultConnectionHttp,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionHubspot> onCreateFlowsVaultConnectionHubspot,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionJwt> onCreateFlowsVaultConnectionJwt,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimp> onCreateFlowsVaultConnectionMailchimp,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionMailjet> onCreateFlowsVaultConnectionMailjet,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionPipedrive> onCreateFlowsVaultConnectionPipedrive,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionSalesforce> onCreateFlowsVaultConnectionSalesforce,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionSendgrid> onCreateFlowsVaultConnectionSendgrid,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionSlack> onCreateFlowsVaultConnectionSlack,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionStripe> onCreateFlowsVaultConnectionStripe,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionTelegram> onCreateFlowsVaultConnectionTelegram,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionTwilio> onCreateFlowsVaultConnectionTwilio,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsapp> onCreateFlowsVaultConnectionWhatsapp,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionZapier> onCreateFlowsVaultConnectionZapier
    )
    {
        switch (Type)
        {
            case "createFlowsVaultConnectionActivecampaign":
                onCreateFlowsVaultConnectionActivecampaign(
                    AsCreateFlowsVaultConnectionActivecampaign()
                );
                break;
            case "createFlowsVaultConnectionAirtable":
                onCreateFlowsVaultConnectionAirtable(AsCreateFlowsVaultConnectionAirtable());
                break;
            case "createFlowsVaultConnectionAuth0":
                onCreateFlowsVaultConnectionAuth0(AsCreateFlowsVaultConnectionAuth0());
                break;
            case "createFlowsVaultConnectionBigquery":
                onCreateFlowsVaultConnectionBigquery(AsCreateFlowsVaultConnectionBigquery());
                break;
            case "createFlowsVaultConnectionClearbit":
                onCreateFlowsVaultConnectionClearbit(AsCreateFlowsVaultConnectionClearbit());
                break;
            case "createFlowsVaultConnectionDocusign":
                onCreateFlowsVaultConnectionDocusign(AsCreateFlowsVaultConnectionDocusign());
                break;
            case "createFlowsVaultConnectionGoogleSheets":
                onCreateFlowsVaultConnectionGoogleSheets(
                    AsCreateFlowsVaultConnectionGoogleSheets()
                );
                break;
            case "createFlowsVaultConnectionHttp":
                onCreateFlowsVaultConnectionHttp(AsCreateFlowsVaultConnectionHttp());
                break;
            case "createFlowsVaultConnectionHubspot":
                onCreateFlowsVaultConnectionHubspot(AsCreateFlowsVaultConnectionHubspot());
                break;
            case "createFlowsVaultConnectionJwt":
                onCreateFlowsVaultConnectionJwt(AsCreateFlowsVaultConnectionJwt());
                break;
            case "createFlowsVaultConnectionMailchimp":
                onCreateFlowsVaultConnectionMailchimp(AsCreateFlowsVaultConnectionMailchimp());
                break;
            case "createFlowsVaultConnectionMailjet":
                onCreateFlowsVaultConnectionMailjet(AsCreateFlowsVaultConnectionMailjet());
                break;
            case "createFlowsVaultConnectionPipedrive":
                onCreateFlowsVaultConnectionPipedrive(AsCreateFlowsVaultConnectionPipedrive());
                break;
            case "createFlowsVaultConnectionSalesforce":
                onCreateFlowsVaultConnectionSalesforce(AsCreateFlowsVaultConnectionSalesforce());
                break;
            case "createFlowsVaultConnectionSendgrid":
                onCreateFlowsVaultConnectionSendgrid(AsCreateFlowsVaultConnectionSendgrid());
                break;
            case "createFlowsVaultConnectionSlack":
                onCreateFlowsVaultConnectionSlack(AsCreateFlowsVaultConnectionSlack());
                break;
            case "createFlowsVaultConnectionStripe":
                onCreateFlowsVaultConnectionStripe(AsCreateFlowsVaultConnectionStripe());
                break;
            case "createFlowsVaultConnectionTelegram":
                onCreateFlowsVaultConnectionTelegram(AsCreateFlowsVaultConnectionTelegram());
                break;
            case "createFlowsVaultConnectionTwilio":
                onCreateFlowsVaultConnectionTwilio(AsCreateFlowsVaultConnectionTwilio());
                break;
            case "createFlowsVaultConnectionWhatsapp":
                onCreateFlowsVaultConnectionWhatsapp(AsCreateFlowsVaultConnectionWhatsapp());
                break;
            case "createFlowsVaultConnectionZapier":
                onCreateFlowsVaultConnectionZapier(AsCreateFlowsVaultConnectionZapier());
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
        if (obj is not CreateFlowsVaultConnectionRequestContent other)
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

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaign value
    ) => new("createFlowsVaultConnectionActivecampaign", value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionAirtable value
    ) => new("createFlowsVaultConnectionAirtable", value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0 value
    ) => new("createFlowsVaultConnectionAuth0", value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionBigquery value
    ) => new("createFlowsVaultConnectionBigquery", value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionClearbit value
    ) => new("createFlowsVaultConnectionClearbit", value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionDocusign value
    ) => new("createFlowsVaultConnectionDocusign", value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheets value
    ) => new("createFlowsVaultConnectionGoogleSheets", value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHttp value
    ) => new("createFlowsVaultConnectionHttp", value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHubspot value
    ) => new("createFlowsVaultConnectionHubspot", value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionJwt value
    ) => new("createFlowsVaultConnectionJwt", value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimp value
    ) => new("createFlowsVaultConnectionMailchimp", value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionMailjet value
    ) => new("createFlowsVaultConnectionMailjet", value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionPipedrive value
    ) => new("createFlowsVaultConnectionPipedrive", value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionSalesforce value
    ) => new("createFlowsVaultConnectionSalesforce", value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionSendgrid value
    ) => new("createFlowsVaultConnectionSendgrid", value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionSlack value
    ) => new("createFlowsVaultConnectionSlack", value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionStripe value
    ) => new("createFlowsVaultConnectionStripe", value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionTelegram value
    ) => new("createFlowsVaultConnectionTelegram", value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionTwilio value
    ) => new("createFlowsVaultConnectionTwilio", value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsapp value
    ) => new("createFlowsVaultConnectionWhatsapp", value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionZapier value
    ) => new("createFlowsVaultConnectionZapier", value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaignApiKey value
    ) =>
        new(
            "createFlowsVaultConnectionActivecampaign",
            (CreateFlowsVaultConnectionActivecampaign)value
        );

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaignUninitialized value
    ) =>
        new(
            "createFlowsVaultConnectionActivecampaign",
            (CreateFlowsVaultConnectionActivecampaign)value
        );

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionAirtableApiKey value
    ) => new("createFlowsVaultConnectionAirtable", (CreateFlowsVaultConnectionAirtable)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionAirtableUninitialized value
    ) => new("createFlowsVaultConnectionAirtable", (CreateFlowsVaultConnectionAirtable)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0OauthApp value
    ) => new("createFlowsVaultConnectionAuth0", (CreateFlowsVaultConnectionAuth0)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0Uninitialized value
    ) => new("createFlowsVaultConnectionAuth0", (CreateFlowsVaultConnectionAuth0)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionBigqueryJwt value
    ) => new("createFlowsVaultConnectionBigquery", (CreateFlowsVaultConnectionBigquery)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionBigqueryUninitialized value
    ) => new("createFlowsVaultConnectionBigquery", (CreateFlowsVaultConnectionBigquery)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionClearbitApiKey value
    ) => new("createFlowsVaultConnectionClearbit", (CreateFlowsVaultConnectionClearbit)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionClearbitUninitialized value
    ) => new("createFlowsVaultConnectionClearbit", (CreateFlowsVaultConnectionClearbit)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionDocusignOauthCode value
    ) => new("createFlowsVaultConnectionDocusign", (CreateFlowsVaultConnectionDocusign)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionDocusignUninitialized value
    ) => new("createFlowsVaultConnectionDocusign", (CreateFlowsVaultConnectionDocusign)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheetsOauthCode value
    ) =>
        new(
            "createFlowsVaultConnectionGoogleSheets",
            (CreateFlowsVaultConnectionGoogleSheets)value
        );

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheetsUninitialized value
    ) =>
        new(
            "createFlowsVaultConnectionGoogleSheets",
            (CreateFlowsVaultConnectionGoogleSheets)value
        );

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBearer value
    ) => new("createFlowsVaultConnectionHttp", (CreateFlowsVaultConnectionHttp)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBasicAuth value
    ) => new("createFlowsVaultConnectionHttp", (CreateFlowsVaultConnectionHttp)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHttpApiKey value
    ) => new("createFlowsVaultConnectionHttp", (CreateFlowsVaultConnectionHttp)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHttpOauthClientCredentials value
    ) => new("createFlowsVaultConnectionHttp", (CreateFlowsVaultConnectionHttp)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHttpUninitialized value
    ) => new("createFlowsVaultConnectionHttp", (CreateFlowsVaultConnectionHttp)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotApiKey value
    ) => new("createFlowsVaultConnectionHubspot", (CreateFlowsVaultConnectionHubspot)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotOauthCode value
    ) => new("createFlowsVaultConnectionHubspot", (CreateFlowsVaultConnectionHubspot)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotUninitialized value
    ) => new("createFlowsVaultConnectionHubspot", (CreateFlowsVaultConnectionHubspot)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionJwtJwt value
    ) => new("createFlowsVaultConnectionJwt", (CreateFlowsVaultConnectionJwt)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionJwtUninitialized value
    ) => new("createFlowsVaultConnectionJwt", (CreateFlowsVaultConnectionJwt)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpApiKey value
    ) => new("createFlowsVaultConnectionMailchimp", (CreateFlowsVaultConnectionMailchimp)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpOauthCode value
    ) => new("createFlowsVaultConnectionMailchimp", (CreateFlowsVaultConnectionMailchimp)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpUninitialized value
    ) => new("createFlowsVaultConnectionMailchimp", (CreateFlowsVaultConnectionMailchimp)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionMailjetApiKey value
    ) => new("createFlowsVaultConnectionMailjet", (CreateFlowsVaultConnectionMailjet)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionMailjetUninitialized value
    ) => new("createFlowsVaultConnectionMailjet", (CreateFlowsVaultConnectionMailjet)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveToken value
    ) => new("createFlowsVaultConnectionPipedrive", (CreateFlowsVaultConnectionPipedrive)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveOauthCode value
    ) => new("createFlowsVaultConnectionPipedrive", (CreateFlowsVaultConnectionPipedrive)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveUninitialized value
    ) => new("createFlowsVaultConnectionPipedrive", (CreateFlowsVaultConnectionPipedrive)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionSalesforceOauthCode value
    ) => new("createFlowsVaultConnectionSalesforce", (CreateFlowsVaultConnectionSalesforce)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionSalesforceUninitialized value
    ) => new("createFlowsVaultConnectionSalesforce", (CreateFlowsVaultConnectionSalesforce)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionSendgridApiKey value
    ) => new("createFlowsVaultConnectionSendgrid", (CreateFlowsVaultConnectionSendgrid)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionSendgridUninitialized value
    ) => new("createFlowsVaultConnectionSendgrid", (CreateFlowsVaultConnectionSendgrid)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionSlackWebhook value
    ) => new("createFlowsVaultConnectionSlack", (CreateFlowsVaultConnectionSlack)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionSlackOauthCode value
    ) => new("createFlowsVaultConnectionSlack", (CreateFlowsVaultConnectionSlack)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionSlackUninitialized value
    ) => new("createFlowsVaultConnectionSlack", (CreateFlowsVaultConnectionSlack)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionStripeKeyPair value
    ) => new("createFlowsVaultConnectionStripe", (CreateFlowsVaultConnectionStripe)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionStripeOauthCode value
    ) => new("createFlowsVaultConnectionStripe", (CreateFlowsVaultConnectionStripe)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionStripeUninitialized value
    ) => new("createFlowsVaultConnectionStripe", (CreateFlowsVaultConnectionStripe)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionTelegramToken value
    ) => new("createFlowsVaultConnectionTelegram", (CreateFlowsVaultConnectionTelegram)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionTelegramUninitialized value
    ) => new("createFlowsVaultConnectionTelegram", (CreateFlowsVaultConnectionTelegram)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionTwilioApiKey value
    ) => new("createFlowsVaultConnectionTwilio", (CreateFlowsVaultConnectionTwilio)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionTwilioUninitialized value
    ) => new("createFlowsVaultConnectionTwilio", (CreateFlowsVaultConnectionTwilio)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsappToken value
    ) => new("createFlowsVaultConnectionWhatsapp", (CreateFlowsVaultConnectionWhatsapp)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsappUninitialized value
    ) => new("createFlowsVaultConnectionWhatsapp", (CreateFlowsVaultConnectionWhatsapp)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionZapierWebhook value
    ) => new("createFlowsVaultConnectionZapier", (CreateFlowsVaultConnectionZapier)value);

    public static implicit operator CreateFlowsVaultConnectionRequestContent(
        Auth0.ManagementApi.CreateFlowsVaultConnectionZapierUninitialized value
    ) => new("createFlowsVaultConnectionZapier", (CreateFlowsVaultConnectionZapier)value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateFlowsVaultConnectionRequestContent>
    {
        public override CreateFlowsVaultConnectionRequestContent? Read(
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
                        "createFlowsVaultConnectionActivecampaign",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaign)
                    ),
                    (
                        "createFlowsVaultConnectionAirtable",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionAirtable)
                    ),
                    (
                        "createFlowsVaultConnectionAuth0",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0)
                    ),
                    (
                        "createFlowsVaultConnectionBigquery",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionBigquery)
                    ),
                    (
                        "createFlowsVaultConnectionClearbit",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionClearbit)
                    ),
                    (
                        "createFlowsVaultConnectionDocusign",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionDocusign)
                    ),
                    (
                        "createFlowsVaultConnectionGoogleSheets",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheets)
                    ),
                    (
                        "createFlowsVaultConnectionHttp",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionHttp)
                    ),
                    (
                        "createFlowsVaultConnectionHubspot",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionHubspot)
                    ),
                    (
                        "createFlowsVaultConnectionJwt",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionJwt)
                    ),
                    (
                        "createFlowsVaultConnectionMailchimp",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimp)
                    ),
                    (
                        "createFlowsVaultConnectionMailjet",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionMailjet)
                    ),
                    (
                        "createFlowsVaultConnectionPipedrive",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionPipedrive)
                    ),
                    (
                        "createFlowsVaultConnectionSalesforce",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionSalesforce)
                    ),
                    (
                        "createFlowsVaultConnectionSendgrid",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionSendgrid)
                    ),
                    (
                        "createFlowsVaultConnectionSlack",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionSlack)
                    ),
                    (
                        "createFlowsVaultConnectionStripe",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionStripe)
                    ),
                    (
                        "createFlowsVaultConnectionTelegram",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionTelegram)
                    ),
                    (
                        "createFlowsVaultConnectionTwilio",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionTwilio)
                    ),
                    (
                        "createFlowsVaultConnectionWhatsapp",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsapp)
                    ),
                    (
                        "createFlowsVaultConnectionZapier",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionZapier)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CreateFlowsVaultConnectionRequestContent result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CreateFlowsVaultConnectionRequestContent"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionRequestContent value,
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
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
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

        public override CreateFlowsVaultConnectionRequestContent ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CreateFlowsVaultConnectionRequestContent result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionRequestContent value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
