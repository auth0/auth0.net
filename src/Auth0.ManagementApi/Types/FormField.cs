// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FormField.JsonConverter))]
[Serializable]
public class FormField
{
    private FormField(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.FormFieldBoolean value.
    /// </summary>
    public static FormField FromFormFieldBoolean(Auth0.ManagementApi.FormFieldBoolean value) =>
        new("formFieldBoolean", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormFieldCards value.
    /// </summary>
    public static FormField FromFormFieldCards(Auth0.ManagementApi.FormFieldCards value) =>
        new("formFieldCards", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormFieldChoice value.
    /// </summary>
    public static FormField FromFormFieldChoice(Auth0.ManagementApi.FormFieldChoice value) =>
        new("formFieldChoice", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormFieldCustom value.
    /// </summary>
    public static FormField FromFormFieldCustom(Auth0.ManagementApi.FormFieldCustom value) =>
        new("formFieldCustom", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormFieldDate value.
    /// </summary>
    public static FormField FromFormFieldDate(Auth0.ManagementApi.FormFieldDate value) =>
        new("formFieldDate", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormFieldDropdown value.
    /// </summary>
    public static FormField FromFormFieldDropdown(Auth0.ManagementApi.FormFieldDropdown value) =>
        new("formFieldDropdown", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormFieldEmail value.
    /// </summary>
    public static FormField FromFormFieldEmail(Auth0.ManagementApi.FormFieldEmail value) =>
        new("formFieldEmail", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormFieldFile value.
    /// </summary>
    public static FormField FromFormFieldFile(Auth0.ManagementApi.FormFieldFile value) =>
        new("formFieldFile", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormFieldLegal value.
    /// </summary>
    public static FormField FromFormFieldLegal(Auth0.ManagementApi.FormFieldLegal value) =>
        new("formFieldLegal", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormFieldNumber value.
    /// </summary>
    public static FormField FromFormFieldNumber(Auth0.ManagementApi.FormFieldNumber value) =>
        new("formFieldNumber", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormFieldPassword value.
    /// </summary>
    public static FormField FromFormFieldPassword(Auth0.ManagementApi.FormFieldPassword value) =>
        new("formFieldPassword", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormFieldPayment value.
    /// </summary>
    public static FormField FromFormFieldPayment(Auth0.ManagementApi.FormFieldPayment value) =>
        new("formFieldPayment", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormFieldSocial value.
    /// </summary>
    public static FormField FromFormFieldSocial(Auth0.ManagementApi.FormFieldSocial value) =>
        new("formFieldSocial", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormFieldTel value.
    /// </summary>
    public static FormField FromFormFieldTel(Auth0.ManagementApi.FormFieldTel value) =>
        new("formFieldTel", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormFieldText value.
    /// </summary>
    public static FormField FromFormFieldText(Auth0.ManagementApi.FormFieldText value) =>
        new("formFieldText", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FormFieldUrl value.
    /// </summary>
    public static FormField FromFormFieldUrl(Auth0.ManagementApi.FormFieldUrl value) =>
        new("formFieldUrl", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formFieldBoolean"
    /// </summary>
    public bool IsFormFieldBoolean() => Type == "formFieldBoolean";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formFieldCards"
    /// </summary>
    public bool IsFormFieldCards() => Type == "formFieldCards";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formFieldChoice"
    /// </summary>
    public bool IsFormFieldChoice() => Type == "formFieldChoice";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formFieldCustom"
    /// </summary>
    public bool IsFormFieldCustom() => Type == "formFieldCustom";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formFieldDate"
    /// </summary>
    public bool IsFormFieldDate() => Type == "formFieldDate";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formFieldDropdown"
    /// </summary>
    public bool IsFormFieldDropdown() => Type == "formFieldDropdown";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formFieldEmail"
    /// </summary>
    public bool IsFormFieldEmail() => Type == "formFieldEmail";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formFieldFile"
    /// </summary>
    public bool IsFormFieldFile() => Type == "formFieldFile";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formFieldLegal"
    /// </summary>
    public bool IsFormFieldLegal() => Type == "formFieldLegal";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formFieldNumber"
    /// </summary>
    public bool IsFormFieldNumber() => Type == "formFieldNumber";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formFieldPassword"
    /// </summary>
    public bool IsFormFieldPassword() => Type == "formFieldPassword";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formFieldPayment"
    /// </summary>
    public bool IsFormFieldPayment() => Type == "formFieldPayment";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formFieldSocial"
    /// </summary>
    public bool IsFormFieldSocial() => Type == "formFieldSocial";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formFieldTel"
    /// </summary>
    public bool IsFormFieldTel() => Type == "formFieldTel";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formFieldText"
    /// </summary>
    public bool IsFormFieldText() => Type == "formFieldText";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formFieldUrl"
    /// </summary>
    public bool IsFormFieldUrl() => Type == "formFieldUrl";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormFieldBoolean"/> if <see cref="Type"/> is 'formFieldBoolean', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formFieldBoolean'.</exception>
    public Auth0.ManagementApi.FormFieldBoolean AsFormFieldBoolean() =>
        IsFormFieldBoolean()
            ? (Auth0.ManagementApi.FormFieldBoolean)Value!
            : throw new ManagementException("Union type is not 'formFieldBoolean'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormFieldCards"/> if <see cref="Type"/> is 'formFieldCards', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formFieldCards'.</exception>
    public Auth0.ManagementApi.FormFieldCards AsFormFieldCards() =>
        IsFormFieldCards()
            ? (Auth0.ManagementApi.FormFieldCards)Value!
            : throw new ManagementException("Union type is not 'formFieldCards'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormFieldChoice"/> if <see cref="Type"/> is 'formFieldChoice', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formFieldChoice'.</exception>
    public Auth0.ManagementApi.FormFieldChoice AsFormFieldChoice() =>
        IsFormFieldChoice()
            ? (Auth0.ManagementApi.FormFieldChoice)Value!
            : throw new ManagementException("Union type is not 'formFieldChoice'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormFieldCustom"/> if <see cref="Type"/> is 'formFieldCustom', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formFieldCustom'.</exception>
    public Auth0.ManagementApi.FormFieldCustom AsFormFieldCustom() =>
        IsFormFieldCustom()
            ? (Auth0.ManagementApi.FormFieldCustom)Value!
            : throw new ManagementException("Union type is not 'formFieldCustom'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormFieldDate"/> if <see cref="Type"/> is 'formFieldDate', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formFieldDate'.</exception>
    public Auth0.ManagementApi.FormFieldDate AsFormFieldDate() =>
        IsFormFieldDate()
            ? (Auth0.ManagementApi.FormFieldDate)Value!
            : throw new ManagementException("Union type is not 'formFieldDate'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormFieldDropdown"/> if <see cref="Type"/> is 'formFieldDropdown', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formFieldDropdown'.</exception>
    public Auth0.ManagementApi.FormFieldDropdown AsFormFieldDropdown() =>
        IsFormFieldDropdown()
            ? (Auth0.ManagementApi.FormFieldDropdown)Value!
            : throw new ManagementException("Union type is not 'formFieldDropdown'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormFieldEmail"/> if <see cref="Type"/> is 'formFieldEmail', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formFieldEmail'.</exception>
    public Auth0.ManagementApi.FormFieldEmail AsFormFieldEmail() =>
        IsFormFieldEmail()
            ? (Auth0.ManagementApi.FormFieldEmail)Value!
            : throw new ManagementException("Union type is not 'formFieldEmail'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormFieldFile"/> if <see cref="Type"/> is 'formFieldFile', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formFieldFile'.</exception>
    public Auth0.ManagementApi.FormFieldFile AsFormFieldFile() =>
        IsFormFieldFile()
            ? (Auth0.ManagementApi.FormFieldFile)Value!
            : throw new ManagementException("Union type is not 'formFieldFile'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormFieldLegal"/> if <see cref="Type"/> is 'formFieldLegal', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formFieldLegal'.</exception>
    public Auth0.ManagementApi.FormFieldLegal AsFormFieldLegal() =>
        IsFormFieldLegal()
            ? (Auth0.ManagementApi.FormFieldLegal)Value!
            : throw new ManagementException("Union type is not 'formFieldLegal'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormFieldNumber"/> if <see cref="Type"/> is 'formFieldNumber', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formFieldNumber'.</exception>
    public Auth0.ManagementApi.FormFieldNumber AsFormFieldNumber() =>
        IsFormFieldNumber()
            ? (Auth0.ManagementApi.FormFieldNumber)Value!
            : throw new ManagementException("Union type is not 'formFieldNumber'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormFieldPassword"/> if <see cref="Type"/> is 'formFieldPassword', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formFieldPassword'.</exception>
    public Auth0.ManagementApi.FormFieldPassword AsFormFieldPassword() =>
        IsFormFieldPassword()
            ? (Auth0.ManagementApi.FormFieldPassword)Value!
            : throw new ManagementException("Union type is not 'formFieldPassword'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormFieldPayment"/> if <see cref="Type"/> is 'formFieldPayment', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formFieldPayment'.</exception>
    public Auth0.ManagementApi.FormFieldPayment AsFormFieldPayment() =>
        IsFormFieldPayment()
            ? (Auth0.ManagementApi.FormFieldPayment)Value!
            : throw new ManagementException("Union type is not 'formFieldPayment'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormFieldSocial"/> if <see cref="Type"/> is 'formFieldSocial', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formFieldSocial'.</exception>
    public Auth0.ManagementApi.FormFieldSocial AsFormFieldSocial() =>
        IsFormFieldSocial()
            ? (Auth0.ManagementApi.FormFieldSocial)Value!
            : throw new ManagementException("Union type is not 'formFieldSocial'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormFieldTel"/> if <see cref="Type"/> is 'formFieldTel', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formFieldTel'.</exception>
    public Auth0.ManagementApi.FormFieldTel AsFormFieldTel() =>
        IsFormFieldTel()
            ? (Auth0.ManagementApi.FormFieldTel)Value!
            : throw new ManagementException("Union type is not 'formFieldTel'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormFieldText"/> if <see cref="Type"/> is 'formFieldText', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formFieldText'.</exception>
    public Auth0.ManagementApi.FormFieldText AsFormFieldText() =>
        IsFormFieldText()
            ? (Auth0.ManagementApi.FormFieldText)Value!
            : throw new ManagementException("Union type is not 'formFieldText'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FormFieldUrl"/> if <see cref="Type"/> is 'formFieldUrl', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formFieldUrl'.</exception>
    public Auth0.ManagementApi.FormFieldUrl AsFormFieldUrl() =>
        IsFormFieldUrl()
            ? (Auth0.ManagementApi.FormFieldUrl)Value!
            : throw new ManagementException("Union type is not 'formFieldUrl'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormFieldBoolean"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormFieldBoolean(out Auth0.ManagementApi.FormFieldBoolean? value)
    {
        if (Type == "formFieldBoolean")
        {
            value = (Auth0.ManagementApi.FormFieldBoolean)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormFieldCards"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormFieldCards(out Auth0.ManagementApi.FormFieldCards? value)
    {
        if (Type == "formFieldCards")
        {
            value = (Auth0.ManagementApi.FormFieldCards)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormFieldChoice"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormFieldChoice(out Auth0.ManagementApi.FormFieldChoice? value)
    {
        if (Type == "formFieldChoice")
        {
            value = (Auth0.ManagementApi.FormFieldChoice)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormFieldCustom"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormFieldCustom(out Auth0.ManagementApi.FormFieldCustom? value)
    {
        if (Type == "formFieldCustom")
        {
            value = (Auth0.ManagementApi.FormFieldCustom)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormFieldDate"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormFieldDate(out Auth0.ManagementApi.FormFieldDate? value)
    {
        if (Type == "formFieldDate")
        {
            value = (Auth0.ManagementApi.FormFieldDate)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormFieldDropdown"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormFieldDropdown(out Auth0.ManagementApi.FormFieldDropdown? value)
    {
        if (Type == "formFieldDropdown")
        {
            value = (Auth0.ManagementApi.FormFieldDropdown)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormFieldEmail"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormFieldEmail(out Auth0.ManagementApi.FormFieldEmail? value)
    {
        if (Type == "formFieldEmail")
        {
            value = (Auth0.ManagementApi.FormFieldEmail)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormFieldFile"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormFieldFile(out Auth0.ManagementApi.FormFieldFile? value)
    {
        if (Type == "formFieldFile")
        {
            value = (Auth0.ManagementApi.FormFieldFile)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormFieldLegal"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormFieldLegal(out Auth0.ManagementApi.FormFieldLegal? value)
    {
        if (Type == "formFieldLegal")
        {
            value = (Auth0.ManagementApi.FormFieldLegal)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormFieldNumber"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormFieldNumber(out Auth0.ManagementApi.FormFieldNumber? value)
    {
        if (Type == "formFieldNumber")
        {
            value = (Auth0.ManagementApi.FormFieldNumber)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormFieldPassword"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormFieldPassword(out Auth0.ManagementApi.FormFieldPassword? value)
    {
        if (Type == "formFieldPassword")
        {
            value = (Auth0.ManagementApi.FormFieldPassword)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormFieldPayment"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormFieldPayment(out Auth0.ManagementApi.FormFieldPayment? value)
    {
        if (Type == "formFieldPayment")
        {
            value = (Auth0.ManagementApi.FormFieldPayment)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormFieldSocial"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormFieldSocial(out Auth0.ManagementApi.FormFieldSocial? value)
    {
        if (Type == "formFieldSocial")
        {
            value = (Auth0.ManagementApi.FormFieldSocial)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormFieldTel"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormFieldTel(out Auth0.ManagementApi.FormFieldTel? value)
    {
        if (Type == "formFieldTel")
        {
            value = (Auth0.ManagementApi.FormFieldTel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormFieldText"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormFieldText(out Auth0.ManagementApi.FormFieldText? value)
    {
        if (Type == "formFieldText")
        {
            value = (Auth0.ManagementApi.FormFieldText)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FormFieldUrl"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormFieldUrl(out Auth0.ManagementApi.FormFieldUrl? value)
    {
        if (Type == "formFieldUrl")
        {
            value = (Auth0.ManagementApi.FormFieldUrl)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.ManagementApi.FormFieldBoolean, T> onFormFieldBoolean,
        Func<Auth0.ManagementApi.FormFieldCards, T> onFormFieldCards,
        Func<Auth0.ManagementApi.FormFieldChoice, T> onFormFieldChoice,
        Func<Auth0.ManagementApi.FormFieldCustom, T> onFormFieldCustom,
        Func<Auth0.ManagementApi.FormFieldDate, T> onFormFieldDate,
        Func<Auth0.ManagementApi.FormFieldDropdown, T> onFormFieldDropdown,
        Func<Auth0.ManagementApi.FormFieldEmail, T> onFormFieldEmail,
        Func<Auth0.ManagementApi.FormFieldFile, T> onFormFieldFile,
        Func<Auth0.ManagementApi.FormFieldLegal, T> onFormFieldLegal,
        Func<Auth0.ManagementApi.FormFieldNumber, T> onFormFieldNumber,
        Func<Auth0.ManagementApi.FormFieldPassword, T> onFormFieldPassword,
        Func<Auth0.ManagementApi.FormFieldPayment, T> onFormFieldPayment,
        Func<Auth0.ManagementApi.FormFieldSocial, T> onFormFieldSocial,
        Func<Auth0.ManagementApi.FormFieldTel, T> onFormFieldTel,
        Func<Auth0.ManagementApi.FormFieldText, T> onFormFieldText,
        Func<Auth0.ManagementApi.FormFieldUrl, T> onFormFieldUrl
    )
    {
        return Type switch
        {
            "formFieldBoolean" => onFormFieldBoolean(AsFormFieldBoolean()),
            "formFieldCards" => onFormFieldCards(AsFormFieldCards()),
            "formFieldChoice" => onFormFieldChoice(AsFormFieldChoice()),
            "formFieldCustom" => onFormFieldCustom(AsFormFieldCustom()),
            "formFieldDate" => onFormFieldDate(AsFormFieldDate()),
            "formFieldDropdown" => onFormFieldDropdown(AsFormFieldDropdown()),
            "formFieldEmail" => onFormFieldEmail(AsFormFieldEmail()),
            "formFieldFile" => onFormFieldFile(AsFormFieldFile()),
            "formFieldLegal" => onFormFieldLegal(AsFormFieldLegal()),
            "formFieldNumber" => onFormFieldNumber(AsFormFieldNumber()),
            "formFieldPassword" => onFormFieldPassword(AsFormFieldPassword()),
            "formFieldPayment" => onFormFieldPayment(AsFormFieldPayment()),
            "formFieldSocial" => onFormFieldSocial(AsFormFieldSocial()),
            "formFieldTel" => onFormFieldTel(AsFormFieldTel()),
            "formFieldText" => onFormFieldText(AsFormFieldText()),
            "formFieldUrl" => onFormFieldUrl(AsFormFieldUrl()),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.FormFieldBoolean> onFormFieldBoolean,
        System.Action<Auth0.ManagementApi.FormFieldCards> onFormFieldCards,
        System.Action<Auth0.ManagementApi.FormFieldChoice> onFormFieldChoice,
        System.Action<Auth0.ManagementApi.FormFieldCustom> onFormFieldCustom,
        System.Action<Auth0.ManagementApi.FormFieldDate> onFormFieldDate,
        System.Action<Auth0.ManagementApi.FormFieldDropdown> onFormFieldDropdown,
        System.Action<Auth0.ManagementApi.FormFieldEmail> onFormFieldEmail,
        System.Action<Auth0.ManagementApi.FormFieldFile> onFormFieldFile,
        System.Action<Auth0.ManagementApi.FormFieldLegal> onFormFieldLegal,
        System.Action<Auth0.ManagementApi.FormFieldNumber> onFormFieldNumber,
        System.Action<Auth0.ManagementApi.FormFieldPassword> onFormFieldPassword,
        System.Action<Auth0.ManagementApi.FormFieldPayment> onFormFieldPayment,
        System.Action<Auth0.ManagementApi.FormFieldSocial> onFormFieldSocial,
        System.Action<Auth0.ManagementApi.FormFieldTel> onFormFieldTel,
        System.Action<Auth0.ManagementApi.FormFieldText> onFormFieldText,
        System.Action<Auth0.ManagementApi.FormFieldUrl> onFormFieldUrl
    )
    {
        switch (Type)
        {
            case "formFieldBoolean":
                onFormFieldBoolean(AsFormFieldBoolean());
                break;
            case "formFieldCards":
                onFormFieldCards(AsFormFieldCards());
                break;
            case "formFieldChoice":
                onFormFieldChoice(AsFormFieldChoice());
                break;
            case "formFieldCustom":
                onFormFieldCustom(AsFormFieldCustom());
                break;
            case "formFieldDate":
                onFormFieldDate(AsFormFieldDate());
                break;
            case "formFieldDropdown":
                onFormFieldDropdown(AsFormFieldDropdown());
                break;
            case "formFieldEmail":
                onFormFieldEmail(AsFormFieldEmail());
                break;
            case "formFieldFile":
                onFormFieldFile(AsFormFieldFile());
                break;
            case "formFieldLegal":
                onFormFieldLegal(AsFormFieldLegal());
                break;
            case "formFieldNumber":
                onFormFieldNumber(AsFormFieldNumber());
                break;
            case "formFieldPassword":
                onFormFieldPassword(AsFormFieldPassword());
                break;
            case "formFieldPayment":
                onFormFieldPayment(AsFormFieldPayment());
                break;
            case "formFieldSocial":
                onFormFieldSocial(AsFormFieldSocial());
                break;
            case "formFieldTel":
                onFormFieldTel(AsFormFieldTel());
                break;
            case "formFieldText":
                onFormFieldText(AsFormFieldText());
                break;
            case "formFieldUrl":
                onFormFieldUrl(AsFormFieldUrl());
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
        if (obj is not FormField other)
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

    public static implicit operator FormField(Auth0.ManagementApi.FormFieldBoolean value) =>
        new("formFieldBoolean", value);

    public static implicit operator FormField(Auth0.ManagementApi.FormFieldCards value) =>
        new("formFieldCards", value);

    public static implicit operator FormField(Auth0.ManagementApi.FormFieldChoice value) =>
        new("formFieldChoice", value);

    public static implicit operator FormField(Auth0.ManagementApi.FormFieldCustom value) =>
        new("formFieldCustom", value);

    public static implicit operator FormField(Auth0.ManagementApi.FormFieldDate value) =>
        new("formFieldDate", value);

    public static implicit operator FormField(Auth0.ManagementApi.FormFieldDropdown value) =>
        new("formFieldDropdown", value);

    public static implicit operator FormField(Auth0.ManagementApi.FormFieldEmail value) =>
        new("formFieldEmail", value);

    public static implicit operator FormField(Auth0.ManagementApi.FormFieldFile value) =>
        new("formFieldFile", value);

    public static implicit operator FormField(Auth0.ManagementApi.FormFieldLegal value) =>
        new("formFieldLegal", value);

    public static implicit operator FormField(Auth0.ManagementApi.FormFieldNumber value) =>
        new("formFieldNumber", value);

    public static implicit operator FormField(Auth0.ManagementApi.FormFieldPassword value) =>
        new("formFieldPassword", value);

    public static implicit operator FormField(Auth0.ManagementApi.FormFieldPayment value) =>
        new("formFieldPayment", value);

    public static implicit operator FormField(Auth0.ManagementApi.FormFieldSocial value) =>
        new("formFieldSocial", value);

    public static implicit operator FormField(Auth0.ManagementApi.FormFieldTel value) =>
        new("formFieldTel", value);

    public static implicit operator FormField(Auth0.ManagementApi.FormFieldText value) =>
        new("formFieldText", value);

    public static implicit operator FormField(Auth0.ManagementApi.FormFieldUrl value) =>
        new("formFieldUrl", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FormField>
    {
        public override FormField? Read(
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
                    ("formFieldBoolean", typeof(Auth0.ManagementApi.FormFieldBoolean)),
                    ("formFieldCards", typeof(Auth0.ManagementApi.FormFieldCards)),
                    ("formFieldChoice", typeof(Auth0.ManagementApi.FormFieldChoice)),
                    ("formFieldCustom", typeof(Auth0.ManagementApi.FormFieldCustom)),
                    ("formFieldDate", typeof(Auth0.ManagementApi.FormFieldDate)),
                    ("formFieldDropdown", typeof(Auth0.ManagementApi.FormFieldDropdown)),
                    ("formFieldEmail", typeof(Auth0.ManagementApi.FormFieldEmail)),
                    ("formFieldFile", typeof(Auth0.ManagementApi.FormFieldFile)),
                    ("formFieldLegal", typeof(Auth0.ManagementApi.FormFieldLegal)),
                    ("formFieldNumber", typeof(Auth0.ManagementApi.FormFieldNumber)),
                    ("formFieldPassword", typeof(Auth0.ManagementApi.FormFieldPassword)),
                    ("formFieldPayment", typeof(Auth0.ManagementApi.FormFieldPayment)),
                    ("formFieldSocial", typeof(Auth0.ManagementApi.FormFieldSocial)),
                    ("formFieldTel", typeof(Auth0.ManagementApi.FormFieldTel)),
                    ("formFieldText", typeof(Auth0.ManagementApi.FormFieldText)),
                    ("formFieldUrl", typeof(Auth0.ManagementApi.FormFieldUrl)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            FormField result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into FormField"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            FormField value,
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
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override FormField ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            FormField result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FormField value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
