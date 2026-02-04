// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowAction.JsonConverter))]
[Serializable]
public class FlowAction
{
    private FlowAction(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionActivecampaign value.
    /// </summary>
    public static FlowAction FromFlowActionActivecampaign(
        Auth0.ManagementApi.FlowActionActivecampaign value
    ) => new("flowActionActivecampaign", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionAirtable value.
    /// </summary>
    public static FlowAction FromFlowActionAirtable(Auth0.ManagementApi.FlowActionAirtable value) =>
        new("flowActionAirtable", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionAuth0 value.
    /// </summary>
    public static FlowAction FromFlowActionAuth0(Auth0.ManagementApi.FlowActionAuth0 value) =>
        new("flowActionAuth0", value);

    /// <summary>
    /// Factory method to create a union from a FlowActionBigqueryInsertRows value.
    /// </summary>
    public static FlowAction FromFlowActionBigquery(FlowActionBigqueryInsertRows value) =>
        new("flowActionBigquery", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionClearbit value.
    /// </summary>
    public static FlowAction FromFlowActionClearbit(Auth0.ManagementApi.FlowActionClearbit value) =>
        new("flowActionClearbit", value);

    /// <summary>
    /// Factory method to create a union from a FlowActionEmailVerifyEmail value.
    /// </summary>
    public static FlowAction FromFlowActionEmail(FlowActionEmailVerifyEmail value) =>
        new("flowActionEmail", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionFlow value.
    /// </summary>
    public static FlowAction FromFlowActionFlow(Auth0.ManagementApi.FlowActionFlow value) =>
        new("flowActionFlow", value);

    /// <summary>
    /// Factory method to create a union from a FlowActionGoogleSheetsAddRow value.
    /// </summary>
    public static FlowAction FromFlowActionGoogleSheets(FlowActionGoogleSheetsAddRow value) =>
        new("flowActionGoogleSheets", value);

    /// <summary>
    /// Factory method to create a union from a FlowActionHttpSendRequest value.
    /// </summary>
    public static FlowAction FromFlowActionHttp(FlowActionHttpSendRequest value) =>
        new("flowActionHttp", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionHubspot value.
    /// </summary>
    public static FlowAction FromFlowActionHubspot(Auth0.ManagementApi.FlowActionHubspot value) =>
        new("flowActionHubspot", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionJson value.
    /// </summary>
    public static FlowAction FromFlowActionJson(Auth0.ManagementApi.FlowActionJson value) =>
        new("flowActionJson", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionJwt value.
    /// </summary>
    public static FlowAction FromFlowActionJwt(Auth0.ManagementApi.FlowActionJwt value) =>
        new("flowActionJwt", value);

    /// <summary>
    /// Factory method to create a union from a FlowActionMailchimpUpsertMember value.
    /// </summary>
    public static FlowAction FromFlowActionMailchimp(FlowActionMailchimpUpsertMember value) =>
        new("flowActionMailchimp", value);

    /// <summary>
    /// Factory method to create a union from a FlowActionMailjetSendEmail value.
    /// </summary>
    public static FlowAction FromFlowActionMailjet(FlowActionMailjetSendEmail value) =>
        new("flowActionMailjet", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionOtp value.
    /// </summary>
    public static FlowAction FromFlowActionOtp(Auth0.ManagementApi.FlowActionOtp value) =>
        new("flowActionOtp", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionPipedrive value.
    /// </summary>
    public static FlowAction FromFlowActionPipedrive(
        Auth0.ManagementApi.FlowActionPipedrive value
    ) => new("flowActionPipedrive", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionSalesforce value.
    /// </summary>
    public static FlowAction FromFlowActionSalesforce(
        Auth0.ManagementApi.FlowActionSalesforce value
    ) => new("flowActionSalesforce", value);

    /// <summary>
    /// Factory method to create a union from a FlowActionSendgridSendEmail value.
    /// </summary>
    public static FlowAction FromFlowActionSendgrid(FlowActionSendgridSendEmail value) =>
        new("flowActionSendgrid", value);

    /// <summary>
    /// Factory method to create a union from a FlowActionSlackPostMessage value.
    /// </summary>
    public static FlowAction FromFlowActionSlack(FlowActionSlackPostMessage value) =>
        new("flowActionSlack", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionStripe value.
    /// </summary>
    public static FlowAction FromFlowActionStripe(Auth0.ManagementApi.FlowActionStripe value) =>
        new("flowActionStripe", value);

    /// <summary>
    /// Factory method to create a union from a FlowActionTelegramSendMessage value.
    /// </summary>
    public static FlowAction FromFlowActionTelegram(FlowActionTelegramSendMessage value) =>
        new("flowActionTelegram", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionTwilio value.
    /// </summary>
    public static FlowAction FromFlowActionTwilio(Auth0.ManagementApi.FlowActionTwilio value) =>
        new("flowActionTwilio", value);

    /// <summary>
    /// Factory method to create a union from a FlowActionWhatsappSendMessage value.
    /// </summary>
    public static FlowAction FromFlowActionWhatsapp(FlowActionWhatsappSendMessage value) =>
        new("flowActionWhatsapp", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionXml value.
    /// </summary>
    public static FlowAction FromFlowActionXml(Auth0.ManagementApi.FlowActionXml value) =>
        new("flowActionXml", value);

    /// <summary>
    /// Factory method to create a union from a FlowActionZapierTriggerWebhook value.
    /// </summary>
    public static FlowAction FromFlowActionZapier(FlowActionZapierTriggerWebhook value) =>
        new("flowActionZapier", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionActivecampaign"
    /// </summary>
    public bool IsFlowActionActivecampaign() => Type == "flowActionActivecampaign";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionAirtable"
    /// </summary>
    public bool IsFlowActionAirtable() => Type == "flowActionAirtable";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionAuth0"
    /// </summary>
    public bool IsFlowActionAuth0() => Type == "flowActionAuth0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionBigquery"
    /// </summary>
    public bool IsFlowActionBigquery() => Type == "flowActionBigquery";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionClearbit"
    /// </summary>
    public bool IsFlowActionClearbit() => Type == "flowActionClearbit";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionEmail"
    /// </summary>
    public bool IsFlowActionEmail() => Type == "flowActionEmail";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionFlow"
    /// </summary>
    public bool IsFlowActionFlow() => Type == "flowActionFlow";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionGoogleSheets"
    /// </summary>
    public bool IsFlowActionGoogleSheets() => Type == "flowActionGoogleSheets";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionHttp"
    /// </summary>
    public bool IsFlowActionHttp() => Type == "flowActionHttp";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionHubspot"
    /// </summary>
    public bool IsFlowActionHubspot() => Type == "flowActionHubspot";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionJson"
    /// </summary>
    public bool IsFlowActionJson() => Type == "flowActionJson";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionJwt"
    /// </summary>
    public bool IsFlowActionJwt() => Type == "flowActionJwt";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionMailchimp"
    /// </summary>
    public bool IsFlowActionMailchimp() => Type == "flowActionMailchimp";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionMailjet"
    /// </summary>
    public bool IsFlowActionMailjet() => Type == "flowActionMailjet";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionOtp"
    /// </summary>
    public bool IsFlowActionOtp() => Type == "flowActionOtp";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionPipedrive"
    /// </summary>
    public bool IsFlowActionPipedrive() => Type == "flowActionPipedrive";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionSalesforce"
    /// </summary>
    public bool IsFlowActionSalesforce() => Type == "flowActionSalesforce";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionSendgrid"
    /// </summary>
    public bool IsFlowActionSendgrid() => Type == "flowActionSendgrid";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionSlack"
    /// </summary>
    public bool IsFlowActionSlack() => Type == "flowActionSlack";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionStripe"
    /// </summary>
    public bool IsFlowActionStripe() => Type == "flowActionStripe";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionTelegram"
    /// </summary>
    public bool IsFlowActionTelegram() => Type == "flowActionTelegram";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionTwilio"
    /// </summary>
    public bool IsFlowActionTwilio() => Type == "flowActionTwilio";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionWhatsapp"
    /// </summary>
    public bool IsFlowActionWhatsapp() => Type == "flowActionWhatsapp";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionXml"
    /// </summary>
    public bool IsFlowActionXml() => Type == "flowActionXml";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionZapier"
    /// </summary>
    public bool IsFlowActionZapier() => Type == "flowActionZapier";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionActivecampaign"/> if <see cref="Type"/> is 'flowActionActivecampaign', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionActivecampaign'.</exception>
    public Auth0.ManagementApi.FlowActionActivecampaign AsFlowActionActivecampaign() =>
        IsFlowActionActivecampaign()
            ? (Auth0.ManagementApi.FlowActionActivecampaign)Value!
            : throw new ManagementException("Union type is not 'flowActionActivecampaign'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionAirtable"/> if <see cref="Type"/> is 'flowActionAirtable', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionAirtable'.</exception>
    public Auth0.ManagementApi.FlowActionAirtable AsFlowActionAirtable() =>
        IsFlowActionAirtable()
            ? (Auth0.ManagementApi.FlowActionAirtable)Value!
            : throw new ManagementException("Union type is not 'flowActionAirtable'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionAuth0"/> if <see cref="Type"/> is 'flowActionAuth0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionAuth0'.</exception>
    public Auth0.ManagementApi.FlowActionAuth0 AsFlowActionAuth0() =>
        IsFlowActionAuth0()
            ? (Auth0.ManagementApi.FlowActionAuth0)Value!
            : throw new ManagementException("Union type is not 'flowActionAuth0'");

    /// <summary>
    /// Returns the value as a <see cref="FlowActionBigqueryInsertRows"/> if <see cref="Type"/> is 'flowActionBigquery', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionBigquery'.</exception>
    public FlowActionBigqueryInsertRows AsFlowActionBigquery() =>
        IsFlowActionBigquery()
            ? (FlowActionBigqueryInsertRows)Value!
            : throw new ManagementException("Union type is not 'flowActionBigquery'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionClearbit"/> if <see cref="Type"/> is 'flowActionClearbit', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionClearbit'.</exception>
    public Auth0.ManagementApi.FlowActionClearbit AsFlowActionClearbit() =>
        IsFlowActionClearbit()
            ? (Auth0.ManagementApi.FlowActionClearbit)Value!
            : throw new ManagementException("Union type is not 'flowActionClearbit'");

    /// <summary>
    /// Returns the value as a <see cref="FlowActionEmailVerifyEmail"/> if <see cref="Type"/> is 'flowActionEmail', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionEmail'.</exception>
    public FlowActionEmailVerifyEmail AsFlowActionEmail() =>
        IsFlowActionEmail()
            ? (FlowActionEmailVerifyEmail)Value!
            : throw new ManagementException("Union type is not 'flowActionEmail'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionFlow"/> if <see cref="Type"/> is 'flowActionFlow', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionFlow'.</exception>
    public Auth0.ManagementApi.FlowActionFlow AsFlowActionFlow() =>
        IsFlowActionFlow()
            ? (Auth0.ManagementApi.FlowActionFlow)Value!
            : throw new ManagementException("Union type is not 'flowActionFlow'");

    /// <summary>
    /// Returns the value as a <see cref="FlowActionGoogleSheetsAddRow"/> if <see cref="Type"/> is 'flowActionGoogleSheets', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionGoogleSheets'.</exception>
    public FlowActionGoogleSheetsAddRow AsFlowActionGoogleSheets() =>
        IsFlowActionGoogleSheets()
            ? (FlowActionGoogleSheetsAddRow)Value!
            : throw new ManagementException("Union type is not 'flowActionGoogleSheets'");

    /// <summary>
    /// Returns the value as a <see cref="FlowActionHttpSendRequest"/> if <see cref="Type"/> is 'flowActionHttp', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionHttp'.</exception>
    public FlowActionHttpSendRequest AsFlowActionHttp() =>
        IsFlowActionHttp()
            ? (FlowActionHttpSendRequest)Value!
            : throw new ManagementException("Union type is not 'flowActionHttp'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionHubspot"/> if <see cref="Type"/> is 'flowActionHubspot', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionHubspot'.</exception>
    public Auth0.ManagementApi.FlowActionHubspot AsFlowActionHubspot() =>
        IsFlowActionHubspot()
            ? (Auth0.ManagementApi.FlowActionHubspot)Value!
            : throw new ManagementException("Union type is not 'flowActionHubspot'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionJson"/> if <see cref="Type"/> is 'flowActionJson', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionJson'.</exception>
    public Auth0.ManagementApi.FlowActionJson AsFlowActionJson() =>
        IsFlowActionJson()
            ? (Auth0.ManagementApi.FlowActionJson)Value!
            : throw new ManagementException("Union type is not 'flowActionJson'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionJwt"/> if <see cref="Type"/> is 'flowActionJwt', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionJwt'.</exception>
    public Auth0.ManagementApi.FlowActionJwt AsFlowActionJwt() =>
        IsFlowActionJwt()
            ? (Auth0.ManagementApi.FlowActionJwt)Value!
            : throw new ManagementException("Union type is not 'flowActionJwt'");

    /// <summary>
    /// Returns the value as a <see cref="FlowActionMailchimpUpsertMember"/> if <see cref="Type"/> is 'flowActionMailchimp', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionMailchimp'.</exception>
    public FlowActionMailchimpUpsertMember AsFlowActionMailchimp() =>
        IsFlowActionMailchimp()
            ? (FlowActionMailchimpUpsertMember)Value!
            : throw new ManagementException("Union type is not 'flowActionMailchimp'");

    /// <summary>
    /// Returns the value as a <see cref="FlowActionMailjetSendEmail"/> if <see cref="Type"/> is 'flowActionMailjet', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionMailjet'.</exception>
    public FlowActionMailjetSendEmail AsFlowActionMailjet() =>
        IsFlowActionMailjet()
            ? (FlowActionMailjetSendEmail)Value!
            : throw new ManagementException("Union type is not 'flowActionMailjet'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionOtp"/> if <see cref="Type"/> is 'flowActionOtp', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionOtp'.</exception>
    public Auth0.ManagementApi.FlowActionOtp AsFlowActionOtp() =>
        IsFlowActionOtp()
            ? (Auth0.ManagementApi.FlowActionOtp)Value!
            : throw new ManagementException("Union type is not 'flowActionOtp'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionPipedrive"/> if <see cref="Type"/> is 'flowActionPipedrive', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionPipedrive'.</exception>
    public Auth0.ManagementApi.FlowActionPipedrive AsFlowActionPipedrive() =>
        IsFlowActionPipedrive()
            ? (Auth0.ManagementApi.FlowActionPipedrive)Value!
            : throw new ManagementException("Union type is not 'flowActionPipedrive'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionSalesforce"/> if <see cref="Type"/> is 'flowActionSalesforce', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionSalesforce'.</exception>
    public Auth0.ManagementApi.FlowActionSalesforce AsFlowActionSalesforce() =>
        IsFlowActionSalesforce()
            ? (Auth0.ManagementApi.FlowActionSalesforce)Value!
            : throw new ManagementException("Union type is not 'flowActionSalesforce'");

    /// <summary>
    /// Returns the value as a <see cref="FlowActionSendgridSendEmail"/> if <see cref="Type"/> is 'flowActionSendgrid', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionSendgrid'.</exception>
    public FlowActionSendgridSendEmail AsFlowActionSendgrid() =>
        IsFlowActionSendgrid()
            ? (FlowActionSendgridSendEmail)Value!
            : throw new ManagementException("Union type is not 'flowActionSendgrid'");

    /// <summary>
    /// Returns the value as a <see cref="FlowActionSlackPostMessage"/> if <see cref="Type"/> is 'flowActionSlack', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionSlack'.</exception>
    public FlowActionSlackPostMessage AsFlowActionSlack() =>
        IsFlowActionSlack()
            ? (FlowActionSlackPostMessage)Value!
            : throw new ManagementException("Union type is not 'flowActionSlack'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionStripe"/> if <see cref="Type"/> is 'flowActionStripe', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionStripe'.</exception>
    public Auth0.ManagementApi.FlowActionStripe AsFlowActionStripe() =>
        IsFlowActionStripe()
            ? (Auth0.ManagementApi.FlowActionStripe)Value!
            : throw new ManagementException("Union type is not 'flowActionStripe'");

    /// <summary>
    /// Returns the value as a <see cref="FlowActionTelegramSendMessage"/> if <see cref="Type"/> is 'flowActionTelegram', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionTelegram'.</exception>
    public FlowActionTelegramSendMessage AsFlowActionTelegram() =>
        IsFlowActionTelegram()
            ? (FlowActionTelegramSendMessage)Value!
            : throw new ManagementException("Union type is not 'flowActionTelegram'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionTwilio"/> if <see cref="Type"/> is 'flowActionTwilio', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionTwilio'.</exception>
    public Auth0.ManagementApi.FlowActionTwilio AsFlowActionTwilio() =>
        IsFlowActionTwilio()
            ? (Auth0.ManagementApi.FlowActionTwilio)Value!
            : throw new ManagementException("Union type is not 'flowActionTwilio'");

    /// <summary>
    /// Returns the value as a <see cref="FlowActionWhatsappSendMessage"/> if <see cref="Type"/> is 'flowActionWhatsapp', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionWhatsapp'.</exception>
    public FlowActionWhatsappSendMessage AsFlowActionWhatsapp() =>
        IsFlowActionWhatsapp()
            ? (FlowActionWhatsappSendMessage)Value!
            : throw new ManagementException("Union type is not 'flowActionWhatsapp'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionXml"/> if <see cref="Type"/> is 'flowActionXml', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionXml'.</exception>
    public Auth0.ManagementApi.FlowActionXml AsFlowActionXml() =>
        IsFlowActionXml()
            ? (Auth0.ManagementApi.FlowActionXml)Value!
            : throw new ManagementException("Union type is not 'flowActionXml'");

    /// <summary>
    /// Returns the value as a <see cref="FlowActionZapierTriggerWebhook"/> if <see cref="Type"/> is 'flowActionZapier', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionZapier'.</exception>
    public FlowActionZapierTriggerWebhook AsFlowActionZapier() =>
        IsFlowActionZapier()
            ? (FlowActionZapierTriggerWebhook)Value!
            : throw new ManagementException("Union type is not 'flowActionZapier'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionActivecampaign"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionActivecampaign(
        out Auth0.ManagementApi.FlowActionActivecampaign? value
    )
    {
        if (Type == "flowActionActivecampaign")
        {
            value = (Auth0.ManagementApi.FlowActionActivecampaign)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionAirtable"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionAirtable(out Auth0.ManagementApi.FlowActionAirtable? value)
    {
        if (Type == "flowActionAirtable")
        {
            value = (Auth0.ManagementApi.FlowActionAirtable)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionAuth0"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionAuth0(out Auth0.ManagementApi.FlowActionAuth0? value)
    {
        if (Type == "flowActionAuth0")
        {
            value = (Auth0.ManagementApi.FlowActionAuth0)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="FlowActionBigqueryInsertRows"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionBigquery(out FlowActionBigqueryInsertRows? value)
    {
        if (Type == "flowActionBigquery")
        {
            value = (FlowActionBigqueryInsertRows)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionClearbit"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionClearbit(out Auth0.ManagementApi.FlowActionClearbit? value)
    {
        if (Type == "flowActionClearbit")
        {
            value = (Auth0.ManagementApi.FlowActionClearbit)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="FlowActionEmailVerifyEmail"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionEmail(out FlowActionEmailVerifyEmail? value)
    {
        if (Type == "flowActionEmail")
        {
            value = (FlowActionEmailVerifyEmail)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionFlow"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionFlow(out Auth0.ManagementApi.FlowActionFlow? value)
    {
        if (Type == "flowActionFlow")
        {
            value = (Auth0.ManagementApi.FlowActionFlow)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="FlowActionGoogleSheetsAddRow"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionGoogleSheets(out FlowActionGoogleSheetsAddRow? value)
    {
        if (Type == "flowActionGoogleSheets")
        {
            value = (FlowActionGoogleSheetsAddRow)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="FlowActionHttpSendRequest"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionHttp(out FlowActionHttpSendRequest? value)
    {
        if (Type == "flowActionHttp")
        {
            value = (FlowActionHttpSendRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionHubspot"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionHubspot(out Auth0.ManagementApi.FlowActionHubspot? value)
    {
        if (Type == "flowActionHubspot")
        {
            value = (Auth0.ManagementApi.FlowActionHubspot)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionJson"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionJson(out Auth0.ManagementApi.FlowActionJson? value)
    {
        if (Type == "flowActionJson")
        {
            value = (Auth0.ManagementApi.FlowActionJson)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionJwt"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionJwt(out Auth0.ManagementApi.FlowActionJwt? value)
    {
        if (Type == "flowActionJwt")
        {
            value = (Auth0.ManagementApi.FlowActionJwt)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="FlowActionMailchimpUpsertMember"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionMailchimp(out FlowActionMailchimpUpsertMember? value)
    {
        if (Type == "flowActionMailchimp")
        {
            value = (FlowActionMailchimpUpsertMember)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="FlowActionMailjetSendEmail"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionMailjet(out FlowActionMailjetSendEmail? value)
    {
        if (Type == "flowActionMailjet")
        {
            value = (FlowActionMailjetSendEmail)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionOtp"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionOtp(out Auth0.ManagementApi.FlowActionOtp? value)
    {
        if (Type == "flowActionOtp")
        {
            value = (Auth0.ManagementApi.FlowActionOtp)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionPipedrive"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionPipedrive(out Auth0.ManagementApi.FlowActionPipedrive? value)
    {
        if (Type == "flowActionPipedrive")
        {
            value = (Auth0.ManagementApi.FlowActionPipedrive)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionSalesforce"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionSalesforce(out Auth0.ManagementApi.FlowActionSalesforce? value)
    {
        if (Type == "flowActionSalesforce")
        {
            value = (Auth0.ManagementApi.FlowActionSalesforce)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="FlowActionSendgridSendEmail"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionSendgrid(out FlowActionSendgridSendEmail? value)
    {
        if (Type == "flowActionSendgrid")
        {
            value = (FlowActionSendgridSendEmail)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="FlowActionSlackPostMessage"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionSlack(out FlowActionSlackPostMessage? value)
    {
        if (Type == "flowActionSlack")
        {
            value = (FlowActionSlackPostMessage)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionStripe"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionStripe(out Auth0.ManagementApi.FlowActionStripe? value)
    {
        if (Type == "flowActionStripe")
        {
            value = (Auth0.ManagementApi.FlowActionStripe)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="FlowActionTelegramSendMessage"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionTelegram(out FlowActionTelegramSendMessage? value)
    {
        if (Type == "flowActionTelegram")
        {
            value = (FlowActionTelegramSendMessage)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionTwilio"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionTwilio(out Auth0.ManagementApi.FlowActionTwilio? value)
    {
        if (Type == "flowActionTwilio")
        {
            value = (Auth0.ManagementApi.FlowActionTwilio)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="FlowActionWhatsappSendMessage"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionWhatsapp(out FlowActionWhatsappSendMessage? value)
    {
        if (Type == "flowActionWhatsapp")
        {
            value = (FlowActionWhatsappSendMessage)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionXml"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionXml(out Auth0.ManagementApi.FlowActionXml? value)
    {
        if (Type == "flowActionXml")
        {
            value = (Auth0.ManagementApi.FlowActionXml)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="FlowActionZapierTriggerWebhook"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionZapier(out FlowActionZapierTriggerWebhook? value)
    {
        if (Type == "flowActionZapier")
        {
            value = (FlowActionZapierTriggerWebhook)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.ManagementApi.FlowActionActivecampaign, T> onFlowActionActivecampaign,
        Func<Auth0.ManagementApi.FlowActionAirtable, T> onFlowActionAirtable,
        Func<Auth0.ManagementApi.FlowActionAuth0, T> onFlowActionAuth0,
        Func<FlowActionBigqueryInsertRows, T> onFlowActionBigquery,
        Func<Auth0.ManagementApi.FlowActionClearbit, T> onFlowActionClearbit,
        Func<FlowActionEmailVerifyEmail, T> onFlowActionEmail,
        Func<Auth0.ManagementApi.FlowActionFlow, T> onFlowActionFlow,
        Func<FlowActionGoogleSheetsAddRow, T> onFlowActionGoogleSheets,
        Func<FlowActionHttpSendRequest, T> onFlowActionHttp,
        Func<Auth0.ManagementApi.FlowActionHubspot, T> onFlowActionHubspot,
        Func<Auth0.ManagementApi.FlowActionJson, T> onFlowActionJson,
        Func<Auth0.ManagementApi.FlowActionJwt, T> onFlowActionJwt,
        Func<FlowActionMailchimpUpsertMember, T> onFlowActionMailchimp,
        Func<FlowActionMailjetSendEmail, T> onFlowActionMailjet,
        Func<Auth0.ManagementApi.FlowActionOtp, T> onFlowActionOtp,
        Func<Auth0.ManagementApi.FlowActionPipedrive, T> onFlowActionPipedrive,
        Func<Auth0.ManagementApi.FlowActionSalesforce, T> onFlowActionSalesforce,
        Func<FlowActionSendgridSendEmail, T> onFlowActionSendgrid,
        Func<FlowActionSlackPostMessage, T> onFlowActionSlack,
        Func<Auth0.ManagementApi.FlowActionStripe, T> onFlowActionStripe,
        Func<FlowActionTelegramSendMessage, T> onFlowActionTelegram,
        Func<Auth0.ManagementApi.FlowActionTwilio, T> onFlowActionTwilio,
        Func<FlowActionWhatsappSendMessage, T> onFlowActionWhatsapp,
        Func<Auth0.ManagementApi.FlowActionXml, T> onFlowActionXml,
        Func<FlowActionZapierTriggerWebhook, T> onFlowActionZapier
    )
    {
        return Type switch
        {
            "flowActionActivecampaign" => onFlowActionActivecampaign(AsFlowActionActivecampaign()),
            "flowActionAirtable" => onFlowActionAirtable(AsFlowActionAirtable()),
            "flowActionAuth0" => onFlowActionAuth0(AsFlowActionAuth0()),
            "flowActionBigquery" => onFlowActionBigquery(AsFlowActionBigquery()),
            "flowActionClearbit" => onFlowActionClearbit(AsFlowActionClearbit()),
            "flowActionEmail" => onFlowActionEmail(AsFlowActionEmail()),
            "flowActionFlow" => onFlowActionFlow(AsFlowActionFlow()),
            "flowActionGoogleSheets" => onFlowActionGoogleSheets(AsFlowActionGoogleSheets()),
            "flowActionHttp" => onFlowActionHttp(AsFlowActionHttp()),
            "flowActionHubspot" => onFlowActionHubspot(AsFlowActionHubspot()),
            "flowActionJson" => onFlowActionJson(AsFlowActionJson()),
            "flowActionJwt" => onFlowActionJwt(AsFlowActionJwt()),
            "flowActionMailchimp" => onFlowActionMailchimp(AsFlowActionMailchimp()),
            "flowActionMailjet" => onFlowActionMailjet(AsFlowActionMailjet()),
            "flowActionOtp" => onFlowActionOtp(AsFlowActionOtp()),
            "flowActionPipedrive" => onFlowActionPipedrive(AsFlowActionPipedrive()),
            "flowActionSalesforce" => onFlowActionSalesforce(AsFlowActionSalesforce()),
            "flowActionSendgrid" => onFlowActionSendgrid(AsFlowActionSendgrid()),
            "flowActionSlack" => onFlowActionSlack(AsFlowActionSlack()),
            "flowActionStripe" => onFlowActionStripe(AsFlowActionStripe()),
            "flowActionTelegram" => onFlowActionTelegram(AsFlowActionTelegram()),
            "flowActionTwilio" => onFlowActionTwilio(AsFlowActionTwilio()),
            "flowActionWhatsapp" => onFlowActionWhatsapp(AsFlowActionWhatsapp()),
            "flowActionXml" => onFlowActionXml(AsFlowActionXml()),
            "flowActionZapier" => onFlowActionZapier(AsFlowActionZapier()),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.FlowActionActivecampaign> onFlowActionActivecampaign,
        System.Action<Auth0.ManagementApi.FlowActionAirtable> onFlowActionAirtable,
        System.Action<Auth0.ManagementApi.FlowActionAuth0> onFlowActionAuth0,
        System.Action<FlowActionBigqueryInsertRows> onFlowActionBigquery,
        System.Action<Auth0.ManagementApi.FlowActionClearbit> onFlowActionClearbit,
        System.Action<FlowActionEmailVerifyEmail> onFlowActionEmail,
        System.Action<Auth0.ManagementApi.FlowActionFlow> onFlowActionFlow,
        System.Action<FlowActionGoogleSheetsAddRow> onFlowActionGoogleSheets,
        System.Action<FlowActionHttpSendRequest> onFlowActionHttp,
        System.Action<Auth0.ManagementApi.FlowActionHubspot> onFlowActionHubspot,
        System.Action<Auth0.ManagementApi.FlowActionJson> onFlowActionJson,
        System.Action<Auth0.ManagementApi.FlowActionJwt> onFlowActionJwt,
        System.Action<FlowActionMailchimpUpsertMember> onFlowActionMailchimp,
        System.Action<FlowActionMailjetSendEmail> onFlowActionMailjet,
        System.Action<Auth0.ManagementApi.FlowActionOtp> onFlowActionOtp,
        System.Action<Auth0.ManagementApi.FlowActionPipedrive> onFlowActionPipedrive,
        System.Action<Auth0.ManagementApi.FlowActionSalesforce> onFlowActionSalesforce,
        System.Action<FlowActionSendgridSendEmail> onFlowActionSendgrid,
        System.Action<FlowActionSlackPostMessage> onFlowActionSlack,
        System.Action<Auth0.ManagementApi.FlowActionStripe> onFlowActionStripe,
        System.Action<FlowActionTelegramSendMessage> onFlowActionTelegram,
        System.Action<Auth0.ManagementApi.FlowActionTwilio> onFlowActionTwilio,
        System.Action<FlowActionWhatsappSendMessage> onFlowActionWhatsapp,
        System.Action<Auth0.ManagementApi.FlowActionXml> onFlowActionXml,
        System.Action<FlowActionZapierTriggerWebhook> onFlowActionZapier
    )
    {
        switch (Type)
        {
            case "flowActionActivecampaign":
                onFlowActionActivecampaign(AsFlowActionActivecampaign());
                break;
            case "flowActionAirtable":
                onFlowActionAirtable(AsFlowActionAirtable());
                break;
            case "flowActionAuth0":
                onFlowActionAuth0(AsFlowActionAuth0());
                break;
            case "flowActionBigquery":
                onFlowActionBigquery(AsFlowActionBigquery());
                break;
            case "flowActionClearbit":
                onFlowActionClearbit(AsFlowActionClearbit());
                break;
            case "flowActionEmail":
                onFlowActionEmail(AsFlowActionEmail());
                break;
            case "flowActionFlow":
                onFlowActionFlow(AsFlowActionFlow());
                break;
            case "flowActionGoogleSheets":
                onFlowActionGoogleSheets(AsFlowActionGoogleSheets());
                break;
            case "flowActionHttp":
                onFlowActionHttp(AsFlowActionHttp());
                break;
            case "flowActionHubspot":
                onFlowActionHubspot(AsFlowActionHubspot());
                break;
            case "flowActionJson":
                onFlowActionJson(AsFlowActionJson());
                break;
            case "flowActionJwt":
                onFlowActionJwt(AsFlowActionJwt());
                break;
            case "flowActionMailchimp":
                onFlowActionMailchimp(AsFlowActionMailchimp());
                break;
            case "flowActionMailjet":
                onFlowActionMailjet(AsFlowActionMailjet());
                break;
            case "flowActionOtp":
                onFlowActionOtp(AsFlowActionOtp());
                break;
            case "flowActionPipedrive":
                onFlowActionPipedrive(AsFlowActionPipedrive());
                break;
            case "flowActionSalesforce":
                onFlowActionSalesforce(AsFlowActionSalesforce());
                break;
            case "flowActionSendgrid":
                onFlowActionSendgrid(AsFlowActionSendgrid());
                break;
            case "flowActionSlack":
                onFlowActionSlack(AsFlowActionSlack());
                break;
            case "flowActionStripe":
                onFlowActionStripe(AsFlowActionStripe());
                break;
            case "flowActionTelegram":
                onFlowActionTelegram(AsFlowActionTelegram());
                break;
            case "flowActionTwilio":
                onFlowActionTwilio(AsFlowActionTwilio());
                break;
            case "flowActionWhatsapp":
                onFlowActionWhatsapp(AsFlowActionWhatsapp());
                break;
            case "flowActionXml":
                onFlowActionXml(AsFlowActionXml());
                break;
            case "flowActionZapier":
                onFlowActionZapier(AsFlowActionZapier());
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
        if (obj is not FlowAction other)
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

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionActivecampaign value
    ) => new("flowActionActivecampaign", value);

    public static implicit operator FlowAction(Auth0.ManagementApi.FlowActionAirtable value) =>
        new("flowActionAirtable", value);

    public static implicit operator FlowAction(Auth0.ManagementApi.FlowActionAuth0 value) =>
        new("flowActionAuth0", value);

    public static implicit operator FlowAction(FlowActionBigqueryInsertRows value) =>
        new("flowActionBigquery", value);

    public static implicit operator FlowAction(Auth0.ManagementApi.FlowActionClearbit value) =>
        new("flowActionClearbit", value);

    public static implicit operator FlowAction(FlowActionEmailVerifyEmail value) =>
        new("flowActionEmail", value);

    public static implicit operator FlowAction(Auth0.ManagementApi.FlowActionFlow value) =>
        new("flowActionFlow", value);

    public static implicit operator FlowAction(FlowActionGoogleSheetsAddRow value) =>
        new("flowActionGoogleSheets", value);

    public static implicit operator FlowAction(FlowActionHttpSendRequest value) =>
        new("flowActionHttp", value);

    public static implicit operator FlowAction(Auth0.ManagementApi.FlowActionHubspot value) =>
        new("flowActionHubspot", value);

    public static implicit operator FlowAction(Auth0.ManagementApi.FlowActionJson value) =>
        new("flowActionJson", value);

    public static implicit operator FlowAction(Auth0.ManagementApi.FlowActionJwt value) =>
        new("flowActionJwt", value);

    public static implicit operator FlowAction(FlowActionMailchimpUpsertMember value) =>
        new("flowActionMailchimp", value);

    public static implicit operator FlowAction(FlowActionMailjetSendEmail value) =>
        new("flowActionMailjet", value);

    public static implicit operator FlowAction(Auth0.ManagementApi.FlowActionOtp value) =>
        new("flowActionOtp", value);

    public static implicit operator FlowAction(Auth0.ManagementApi.FlowActionPipedrive value) =>
        new("flowActionPipedrive", value);

    public static implicit operator FlowAction(Auth0.ManagementApi.FlowActionSalesforce value) =>
        new("flowActionSalesforce", value);

    public static implicit operator FlowAction(FlowActionSendgridSendEmail value) =>
        new("flowActionSendgrid", value);

    public static implicit operator FlowAction(FlowActionSlackPostMessage value) =>
        new("flowActionSlack", value);

    public static implicit operator FlowAction(Auth0.ManagementApi.FlowActionStripe value) =>
        new("flowActionStripe", value);

    public static implicit operator FlowAction(FlowActionTelegramSendMessage value) =>
        new("flowActionTelegram", value);

    public static implicit operator FlowAction(Auth0.ManagementApi.FlowActionTwilio value) =>
        new("flowActionTwilio", value);

    public static implicit operator FlowAction(FlowActionWhatsappSendMessage value) =>
        new("flowActionWhatsapp", value);

    public static implicit operator FlowAction(Auth0.ManagementApi.FlowActionXml value) =>
        new("flowActionXml", value);

    public static implicit operator FlowAction(FlowActionZapierTriggerWebhook value) =>
        new("flowActionZapier", value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionActivecampaignListContacts value
    ) => new("flowActionActivecampaign", (FlowActionActivecampaign)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionActivecampaignUpsertContact value
    ) => new("flowActionActivecampaign", (FlowActionActivecampaign)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionAirtableCreateRecord value
    ) => new("flowActionAirtable", (FlowActionAirtable)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionAirtableListRecords value
    ) => new("flowActionAirtable", (FlowActionAirtable)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionAirtableUpdateRecord value
    ) => new("flowActionAirtable", (FlowActionAirtable)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionAuth0CreateUser value
    ) => new("flowActionAuth0", (FlowActionAuth0)value);

    public static implicit operator FlowAction(Auth0.ManagementApi.FlowActionAuth0GetUser value) =>
        new("flowActionAuth0", (FlowActionAuth0)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionAuth0UpdateUser value
    ) => new("flowActionAuth0", (FlowActionAuth0)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionAuth0SendRequest value
    ) => new("flowActionAuth0", (FlowActionAuth0)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionAuth0SendEmail value
    ) => new("flowActionAuth0", (FlowActionAuth0)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionClearbitFindPerson value
    ) => new("flowActionClearbit", (FlowActionClearbit)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionClearbitFindCompany value
    ) => new("flowActionClearbit", (FlowActionClearbit)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionFlowBooleanCondition value
    ) => new("flowActionFlow", (FlowActionFlow)value);

    public static implicit operator FlowAction(Auth0.ManagementApi.FlowActionFlowDelayFlow value) =>
        new("flowActionFlow", (FlowActionFlow)value);

    public static implicit operator FlowAction(Auth0.ManagementApi.FlowActionFlowDoNothing value) =>
        new("flowActionFlow", (FlowActionFlow)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionFlowErrorMessage value
    ) => new("flowActionFlow", (FlowActionFlow)value);

    public static implicit operator FlowAction(Auth0.ManagementApi.FlowActionFlowMapValue value) =>
        new("flowActionFlow", (FlowActionFlow)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionFlowReturnJson value
    ) => new("flowActionFlow", (FlowActionFlow)value);

    public static implicit operator FlowAction(Auth0.ManagementApi.FlowActionFlowStoreVars value) =>
        new("flowActionFlow", (FlowActionFlow)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionHubspotEnrollContact value
    ) => new("flowActionHubspot", (FlowActionHubspot)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionHubspotGetContact value
    ) => new("flowActionHubspot", (FlowActionHubspot)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionHubspotUpsertContact value
    ) => new("flowActionHubspot", (FlowActionHubspot)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionJsonCreateJson value
    ) => new("flowActionJson", (FlowActionJson)value);

    public static implicit operator FlowAction(Auth0.ManagementApi.FlowActionJsonParseJson value) =>
        new("flowActionJson", (FlowActionJson)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionJsonSerializeJson value
    ) => new("flowActionJson", (FlowActionJson)value);

    public static implicit operator FlowAction(Auth0.ManagementApi.FlowActionJwtDecodeJwt value) =>
        new("flowActionJwt", (FlowActionJwt)value);

    public static implicit operator FlowAction(Auth0.ManagementApi.FlowActionJwtSignJwt value) =>
        new("flowActionJwt", (FlowActionJwt)value);

    public static implicit operator FlowAction(Auth0.ManagementApi.FlowActionJwtVerifyJwt value) =>
        new("flowActionJwt", (FlowActionJwt)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionOtpGenerateCode value
    ) => new("flowActionOtp", (FlowActionOtp)value);

    public static implicit operator FlowAction(Auth0.ManagementApi.FlowActionOtpVerifyCode value) =>
        new("flowActionOtp", (FlowActionOtp)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionPipedriveAddDeal value
    ) => new("flowActionPipedrive", (FlowActionPipedrive)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionPipedriveAddOrganization value
    ) => new("flowActionPipedrive", (FlowActionPipedrive)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionPipedriveAddPerson value
    ) => new("flowActionPipedrive", (FlowActionPipedrive)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionSalesforceCreateLead value
    ) => new("flowActionSalesforce", (FlowActionSalesforce)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionSalesforceGetLead value
    ) => new("flowActionSalesforce", (FlowActionSalesforce)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionSalesforceSearchLeads value
    ) => new("flowActionSalesforce", (FlowActionSalesforce)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionSalesforceUpdateLead value
    ) => new("flowActionSalesforce", (FlowActionSalesforce)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionStripeAddTaxId value
    ) => new("flowActionStripe", (FlowActionStripe)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionStripeCreateCustomer value
    ) => new("flowActionStripe", (FlowActionStripe)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionStripeCreatePortalSession value
    ) => new("flowActionStripe", (FlowActionStripe)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionStripeDeleteTaxId value
    ) => new("flowActionStripe", (FlowActionStripe)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionStripeFindCustomers value
    ) => new("flowActionStripe", (FlowActionStripe)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionStripeGetCustomer value
    ) => new("flowActionStripe", (FlowActionStripe)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionStripeUpdateCustomer value
    ) => new("flowActionStripe", (FlowActionStripe)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionTwilioMakeCall value
    ) => new("flowActionTwilio", (FlowActionTwilio)value);

    public static implicit operator FlowAction(Auth0.ManagementApi.FlowActionTwilioSendSms value) =>
        new("flowActionTwilio", (FlowActionTwilio)value);

    public static implicit operator FlowAction(Auth0.ManagementApi.FlowActionXmlParseXml value) =>
        new("flowActionXml", (FlowActionXml)value);

    public static implicit operator FlowAction(
        Auth0.ManagementApi.FlowActionXmlSerializeXml value
    ) => new("flowActionXml", (FlowActionXml)value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FlowAction>
    {
        public override FlowAction? Read(
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
                    ("flowActionBigquery", typeof(FlowActionBigqueryInsertRows)),
                    ("flowActionEmail", typeof(FlowActionEmailVerifyEmail)),
                    ("flowActionGoogleSheets", typeof(FlowActionGoogleSheetsAddRow)),
                    ("flowActionHttp", typeof(FlowActionHttpSendRequest)),
                    ("flowActionMailchimp", typeof(FlowActionMailchimpUpsertMember)),
                    ("flowActionMailjet", typeof(FlowActionMailjetSendEmail)),
                    ("flowActionSendgrid", typeof(FlowActionSendgridSendEmail)),
                    ("flowActionSlack", typeof(FlowActionSlackPostMessage)),
                    ("flowActionTelegram", typeof(FlowActionTelegramSendMessage)),
                    ("flowActionWhatsapp", typeof(FlowActionWhatsappSendMessage)),
                    ("flowActionZapier", typeof(FlowActionZapierTriggerWebhook)),
                    (
                        "flowActionActivecampaign",
                        typeof(Auth0.ManagementApi.FlowActionActivecampaign)
                    ),
                    ("flowActionAirtable", typeof(Auth0.ManagementApi.FlowActionAirtable)),
                    ("flowActionAuth0", typeof(Auth0.ManagementApi.FlowActionAuth0)),
                    ("flowActionClearbit", typeof(Auth0.ManagementApi.FlowActionClearbit)),
                    ("flowActionFlow", typeof(Auth0.ManagementApi.FlowActionFlow)),
                    ("flowActionHubspot", typeof(Auth0.ManagementApi.FlowActionHubspot)),
                    ("flowActionJson", typeof(Auth0.ManagementApi.FlowActionJson)),
                    ("flowActionJwt", typeof(Auth0.ManagementApi.FlowActionJwt)),
                    ("flowActionOtp", typeof(Auth0.ManagementApi.FlowActionOtp)),
                    ("flowActionPipedrive", typeof(Auth0.ManagementApi.FlowActionPipedrive)),
                    ("flowActionSalesforce", typeof(Auth0.ManagementApi.FlowActionSalesforce)),
                    ("flowActionStripe", typeof(Auth0.ManagementApi.FlowActionStripe)),
                    ("flowActionTwilio", typeof(Auth0.ManagementApi.FlowActionTwilio)),
                    ("flowActionXml", typeof(Auth0.ManagementApi.FlowActionXml)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            FlowAction result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into FlowAction"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowAction value,
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
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override FlowAction ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            FlowAction result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowAction value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
